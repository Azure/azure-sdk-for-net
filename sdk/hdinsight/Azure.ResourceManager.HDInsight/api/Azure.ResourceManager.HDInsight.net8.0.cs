namespace Azure.ResourceManager.HDInsight
{
    public partial class AzureResourceManagerHDInsightContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerHDInsightContext() { }
        public static Azure.ResourceManager.HDInsight.AzureResourceManagerHDInsightContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class HDInsightApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>, System.Collections.IEnumerable
    {
        protected HDInsightApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.HDInsight.HDInsightApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.HDInsight.HDInsightApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> GetIfExists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>> GetIfExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HDInsightApplicationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>
    {
        public HDInsightApplicationData() { }
        public string ETag { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.HDInsightApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.HDInsightApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightApplicationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HDInsightApplicationResource() { }
        public virtual Azure.ResourceManager.HDInsight.HDInsightApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HDInsight.HDInsightApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.HDInsightApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.HDInsightApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.HDInsightApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HDInsightClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.HDInsightClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.HDInsightClusterResource>, System.Collections.IEnumerable
    {
        protected HDInsightClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.HDInsightClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended clusterCreateParametersExtended, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended clusterCreateParametersExtended, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.HDInsightClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.HDInsightClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.HDInsightClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.HDInsightClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HDInsightClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>
    {
        internal HDInsightClusterData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.ClusterIdentity Identity { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties Properties { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.HDInsightClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.HDInsightClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HDInsightClusterResource() { }
        public virtual Azure.ResourceManager.HDInsight.HDInsightClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DisableAzureMonitor(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DisableAzureMonitorAgent(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DisableAzureMonitorAgentAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DisableAzureMonitorAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DisableMonitoring(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DisableMonitoringAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableAzureMonitor(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableAzureMonitorAgent(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableAzureMonitorAgentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableAzureMonitorAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableMonitoring(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableMonitoringAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ExecuteScriptActions(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteScriptActionsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations>> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus> GetAzureMonitorAgentStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus>> GetAzureMonitorAgentStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus> GetAzureMonitorStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus>> GetAzureMonitorStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetByCluster(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetByClusterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings> GetGatewaySettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>> GetGatewaySettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> GetHDInsightApplication(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>> GetHDInsightApplicationAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.HDInsightApplicationCollection GetHDInsightApplications() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo> GetHosts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo> GetHostsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus> GetMonitoringStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>> GetMonitoringStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource> GetPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource>> GetPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.PrivateLinkResource> GetPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.PrivateLinkResource>> GetPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.PrivateLinkResourceCollection GetPrivateLinkResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetScriptExecutionHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetScriptExecutionHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Promote(string scriptExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PromoteAsync(string scriptExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resize(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightRoleName roleName, Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResizeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightRoleName roleName, Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestartHosts(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> hosts, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartHostsAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> hosts, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RotateDiskEncryptionKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RotateDiskEncryptionKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HDInsight.HDInsightClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.HDInsightClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> Update(Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> UpdateAsync(Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateAutoScaleConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightRoleName roleName, Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAutoScaleConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightRoleName roleName, Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateGatewaySettings(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateGatewaySettingsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateIdentityCertificate(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateIdentityCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateIdentityCertificateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateIdentityCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HDInsightExtensions
    {
        public static Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult> CheckNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult>> CheckNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation Create(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string resourceGroupName, string extensionName, System.Guid subscriptionId, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string resourceGroupName, string extensionName, System.Guid subscriptionId, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation Delete(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string resourceGroupName, string extensionName, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string resourceGroupName, string extensionName, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult> GetBillingSpecs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>> GetBillingSpecsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult> GetCapabilities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult>> GetCapabilitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<System.Collections.Generic.IDictionary<string, string>> GetConfiguration(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceGroupName, string configurationName, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IDictionary<string, string>>> GetConfigurationAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceGroupName, string configurationName, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetExecutionDetail(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceGroupName, string scriptExecutionId, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>> GetExecutionDetailAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceGroupName, string scriptExecutionId, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus> GetExtension(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceGroupName, string extensionName, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>> GetExtensionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceGroupName, string extensionName, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightApplicationResource GetHDInsightApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetHDInsightCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> GetHDInsightClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightClusterResource GetHDInsightClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightClusterCollection GetHDInsightClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetHDInsightClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetHDInsightClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HDInsight.PrivateLinkResource GetPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HDInsight.Models.UsagesListResult> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.UsagesListResult>> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation Update(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string resourceGroupName, string configurationName, System.Guid subscriptionId, System.Collections.Generic.IDictionary<string, string> parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string resourceGroupName, string configurationName, System.Guid subscriptionId, System.Collections.Generic.IDictionary<string, string> parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult> ValidateClusterCreateRequest(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>> ValidateClusterCreateRequestAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HDInsightPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>
    {
        public HDInsightPrivateEndpointConnectionData(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState privateLinkServiceConnectionState) { }
        public string LinkIdentifier { get { throw null; } }
        public string PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>
    {
        internal HDInsightPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateLinkResource() { }
        public virtual Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.PrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.PrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.PrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.PrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.PrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.PrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.PrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.PrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HDInsight.PrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HDInsight.PrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.PrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.PrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.PrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.PrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
}
namespace Azure.ResourceManager.HDInsight.Mocking
{
    public partial class MockableHDInsightArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHDInsightArmClient() { }
        public virtual Azure.ResourceManager.HDInsight.HDInsightApplicationResource GetHDInsightApplicationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.HDInsightClusterResource GetHDInsightClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.PrivateLinkResource GetPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHDInsightResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHDInsightResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetHDInsightCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> GetHDInsightClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.HDInsightClusterCollection GetHDInsightClusters() { throw null; }
    }
    public partial class MockableHDInsightSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHDInsightSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult> CheckNameAvailability(string location, Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult>> CheckNameAvailabilityAsync(string location, Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult> GetBillingSpecs(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>> GetBillingSpecsAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult> GetCapabilities(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult>> GetCapabilitiesAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetHDInsightClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetHDInsightClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.UsagesListResult> GetUsages(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.UsagesListResult>> GetUsagesAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult> ValidateClusterCreateRequest(string location, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>> ValidateClusterCreateRequestAsync(string location, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableHDInsightTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHDInsightTenantResource() { }
        public virtual Azure.ResourceManager.ArmOperation Create(Azure.WaitUntil waitUntil, string resourceGroupName, string extensionName, System.Guid subscriptionId, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateAsync(Azure.WaitUntil waitUntil, string resourceGroupName, string extensionName, System.Guid subscriptionId, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string resourceGroupName, string extensionName, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string resourceGroupName, string extensionName, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IDictionary<string, string>> GetConfiguration(string resourceGroupName, string configurationName, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IDictionary<string, string>>> GetConfigurationAsync(string resourceGroupName, string configurationName, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetExecutionDetail(string resourceGroupName, string scriptExecutionId, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>> GetExecutionDetailAsync(string resourceGroupName, string scriptExecutionId, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus> GetExtension(string resourceGroupName, string extensionName, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>> GetExtensionAsync(string resourceGroupName, string extensionName, System.Guid subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, string resourceGroupName, string configurationName, System.Guid subscriptionId, System.Collections.Generic.IDictionary<string, string> parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, string resourceGroupName, string configurationName, System.Guid subscriptionId, System.Collections.Generic.IDictionary<string, string> parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HDInsight.Models
{
    public static partial class ArmHDInsightModelFactory
    {
        public static Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended ClusterCreateParametersExtended(string location = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties properties = null, Azure.ResourceManager.HDInsight.Models.ClusterIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.ClusterIdentity ClusterIdentity(string principalId = null, string tenantId = null, Azure.ResourceManager.HDInsight.Models.ResourceIdentityType? type = default(Azure.ResourceManager.HDInsight.Models.ResourceIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HDInsight.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint ConnectivityEndpoint(string name = null, string protocol = null, string endpointLocation = null, int? port = default(int?), string privateIPAddress = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig ExcludedServicesConfig(string excludedServicesConfigId = null, string excludedServicesList = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionParameters ExecuteScriptActionParameters(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction> scriptActions = null, bool persistOnSuccess = false) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightApplicationData HDInsightApplicationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties properties = null, string etag = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint HDInsightApplicationHttpsEndpoint(System.Collections.Generic.IEnumerable<string> accessModes = null, string endpointLocation = null, int? destinationPort = default(int?), int? publicPort = default(int?), string privateIPAddress = null, string subDomainSuffix = null, bool? disableGatewayAuth = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties HDInsightApplicationProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole> computeRoles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction> installScriptActions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction> uninstallScriptActions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint> httpsEndpoints = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint> sshEndpoints = null, string provisioningState = null, string applicationType = null, string applicationState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.Errors> errors = null, string createdDate = null, string marketplaceIdentifier = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration> privateLinkConfigurations = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleRecurrence HDInsightAutoScaleRecurrence(string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleSchedule> schedule = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleSchedule HDInsightAutoScaleSchedule(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek> days = null, Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleTimeAndCapacity timeAndCapacity = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus HDInsightAzureMonitorExtensionStatus(bool? clusterMonitoringEnabled = default(bool?), string workspaceId = null, Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations selectedConfigurations = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations HDInsightAzureMonitorSelectedConfigurations(string configurationVersion = null, System.Collections.Generic.IDictionary<string, string> globalConfigurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorTableConfiguration> tableList = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters HDInsightBillingMeters(string meterParameter = null, string meter = null, string unit = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources HDInsightBillingResources(string region = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters> billingMeters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters> diskBillingMeters = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult HDInsightBillingSpecsListResult(System.Collections.Generic.IEnumerable<string> vmSizes = null, System.Collections.Generic.IEnumerable<string> vmSizesWithEncryptionAtHost = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2> vmSizeFilters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty> vmSizeProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources> billingResources = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult HDInsightCapabilitiesResult(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability> versions = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HDInsight.Models.RegionsCapability> regions = null, System.Collections.Generic.IEnumerable<string> features = null, Azure.ResourceManager.HDInsight.Models.QuotaCapability quota = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail HDInsightClusterAaddsDetail(string domainName = null, bool? initialSyncComplete = default(bool?), bool? ldapsEnabled = default(bool?), string ldapsPublicCertificateInBase64 = null, string resourceId = null, string subnetId = null, string tenantId = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations HDInsightClusterConfigurations(System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, string>> configurations = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties HDInsightClusterCreateOrUpdateProperties(string clusterVersion = null, Azure.ResourceManager.HDInsight.Models.HDInsightOSType? osType = default(Azure.ResourceManager.HDInsight.Models.HDInsightOSType?), Azure.ResourceManager.HDInsight.Models.HDInsightTier? tier = default(Azure.ResourceManager.HDInsight.Models.HDInsightTier?), Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition clusterDefinition = null, Azure.ResourceManager.HDInsight.Models.KafkaRestProperties kafkaRestProperties = null, Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile securityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole> computeRoles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo> storageStorageaccounts = null, Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties diskEncryptionProperties = null, bool? isEncryptionInTransitEnabled = default(bool?), string minSupportedTlsVersion = null, Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties networkProperties = null, Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties computeIsolationProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration> privateLinkConfigurations = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent HDInsightClusterCreationValidateContent(string location = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties properties = null, Azure.ResourceManager.HDInsight.Models.ClusterIdentity identity = null, string name = null, string type = null, string tenantId = null, bool? fetchAaddsResource = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult HDInsightClusterCreationValidateResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo> validationErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo> validationWarnings = null, System.TimeSpan? estimatedCreationDuration = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail> aaddsResourcesDetails = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightClusterData HDInsightClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties properties = null, string etag = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.HDInsight.Models.ClusterIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup HDInsightClusterDataDiskGroup(int? disksPerNode = default(int?), string storageAccountType = null, int? diskSizeGB = default(int?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition HDInsightClusterDefinition(string blueprint = null, string kind = null, System.Collections.Generic.IDictionary<string, string> componentVersion = null, System.BinaryData configurations = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus HDInsightClusterExtensionStatus(bool? clusterMonitoringEnabled = default(bool?), string workspaceId = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings HDInsightClusterGatewaySettings(string isCredentialEnabled = null, string userName = null, string password = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.EntraUserInfo> restAuthEntraUsers = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo HDInsightClusterHostInfo(string name = null, string fqdn = null, string effectiveDiskEncryptionKeyUri = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties HDInsightClusterProperties(string clusterVersion = null, string clusterHdpVersion = null, Azure.ResourceManager.HDInsight.Models.HDInsightOSType? osType = default(Azure.ResourceManager.HDInsight.Models.HDInsightOSType?), Azure.ResourceManager.HDInsight.Models.HDInsightTier? tier = default(Azure.ResourceManager.HDInsight.Models.HDInsightTier?), string clusterId = null, Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition clusterDefinition = null, Azure.ResourceManager.HDInsight.Models.KafkaRestProperties kafkaRestProperties = null, Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile securityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole> computeRoles = null, Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState? provisioningState = default(Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState?), string createdDate = null, string clusterState = null, int? quotaInfoCoresUsed = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.Errors> errors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint> connectivityEndpoints = null, Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties diskEncryptionProperties = null, bool? isEncryptionInTransitEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo> storageStorageaccounts = null, string minSupportedTlsVersion = null, Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig excludedServicesConfig = null, Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties networkProperties = null, Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties computeIsolationProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration> privateLinkConfigurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole HDInsightClusterRole(string name = null, int? minInstanceCount = default(int?), int? targetInstanceCount = default(int?), string vmGroupName = null, Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration autoscaleConfiguration = null, string hardwareVmSize = null, Azure.ResourceManager.HDInsight.Models.HDInsightLinuxOSProfile osLinuxOperatingSystemProfile = null, Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile virtualNetworkProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup> dataDisksGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.ScriptAction> scriptActions = null, bool? encryptDataDisks = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent HDInsightClusterUpdateGatewaySettingsContent(bool? isCredentialEnabled = default(bool?), string userName = null, string password = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.EntraUserInfo> restAuthEntraUsers = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo HDInsightClusterValidationErrorInfo(string code = null, string message = null, string errorResource = null, System.Collections.Generic.IEnumerable<string> messageArguments = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters HDInsightDiskBillingMeters(string diskRpMeter = null, string sku = null, Azure.ResourceManager.HDInsight.Models.HDInsightTier? tier = default(Azure.ResourceManager.HDInsight.Models.HDInsightTier?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration HDInsightIPConfiguration(string id = null, string name = null, string type = null, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState?), bool? primary = default(bool?), string privateIPAddress = null, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod? privateIPAllocationMethod = default(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod?), string subnetId = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName HDInsightLocalizedName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult HDInsightNameAvailabilityResult(bool? nameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData HDInsightPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, string linkIdentifier = null, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState?), string privateEndpointId = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration HDInsightPrivateLinkConfiguration(string id = null, string name = null, string type = null, string groupId = null, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration> ipConfigurations = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData HDInsightPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile HDInsightSecurityProfile(Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType? directoryType = default(Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType?), string domain = null, string organizationalUnitDN = null, System.Collections.Generic.IEnumerable<string> ldapsUrls = null, string domainUsername = null, string domainUserPassword = null, System.Collections.Generic.IEnumerable<string> clusterUsersGroupDNs = null, string aaddsResourceId = null, string msiResourceId = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightUsage HDInsightUsage(string unit = null, long? currentValue = default(long?), long? limit = default(long?), Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName name = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability HDInsightVersionsCapability(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec> available = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec HDInsightVersionSpec(string friendlyName = null, string displayName = null, bool? isDefault = default(bool?), System.Collections.Generic.IDictionary<string, string> componentVersions = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2 HDInsightVmSizeCompatibilityFilterV2(Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode? filterMode = default(Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode?), System.Collections.Generic.IEnumerable<string> regions = null, System.Collections.Generic.IEnumerable<string> clusterFlavors = null, System.Collections.Generic.IEnumerable<string> nodeTypes = null, System.Collections.Generic.IEnumerable<string> clusterVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightOSType> osType = null, System.Collections.Generic.IEnumerable<string> vmSizes = null, string espApplied = null, string computeIsolationSupported = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty HDInsightVmSizeProperty(string name = null, int? cores = default(int?), string dataDiskStorageTier = null, string label = null, long? maxDataDiskCount = default(long?), long? memoryInMb = default(long?), bool? supportedByVirtualMachines = default(bool?), bool? supportedByWebWorkerRoles = default(bool?), long? virtualMachineResourceDiskSizeInMb = default(long?), long? webWorkerResourceDiskSizeInMb = default(long?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.KafkaRestProperties KafkaRestProperties(Azure.ResourceManager.HDInsight.Models.ClientGroupInfo clientGroupInfo = null, System.Collections.Generic.IDictionary<string, string> configurationOverride = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.QuotaCapability QuotaCapability(long? coresUsed = default(long?), long? maxCoresAllowed = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability> regionalQuotas = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability RegionalQuotaCapability(string regionName = null, long? coresUsed = default(long?), long? coresAvailable = default(long?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.RegionsCapability RegionsCapability(System.Collections.Generic.IEnumerable<string> available = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction RuntimeScriptAction(string name = null, string uri = null, string parameters = null, System.Collections.Generic.IEnumerable<string> roles = null, string applicationName = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail RuntimeScriptActionDetail(string name = null, string uri = null, string parameters = null, System.Collections.Generic.IEnumerable<string> roles = null, string applicationName = null, long? scriptExecutionId = default(long?), string startTime = null, string endTime = null, string status = null, string operation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary> executionSummary = null, string debugInformation = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary ScriptActionExecutionSummary(string status = null, int? instanceCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.UsagesListResult UsagesListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightUsage> value = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.UserAssignedIdentity UserAssignedIdentity(string principalId = null, string clientId = null, string tenantId = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthenticationDirectoryType : System.IEquatable<Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationDirectoryType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType ActiveDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType left, Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType left, Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClientGroupInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ClientGroupInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClientGroupInfo>
    {
        public ClientGroupInfo() { }
        public string GroupId { get { throw null; } set { } }
        public string GroupName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.ClientGroupInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.ClientGroupInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.ClientGroupInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ClientGroupInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ClientGroupInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.ClientGroupInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClientGroupInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClientGroupInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClientGroupInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterCreateParametersExtended : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended>
    {
        public ClusterCreateParametersExtended() { }
        public Azure.ResourceManager.HDInsight.Models.ClusterIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ClusterIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClusterIdentity>
    {
        public ClusterIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.ResourceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HDInsight.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.ClusterIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.ClusterIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.ClusterIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ClusterIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ClusterIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.ClusterIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClusterIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClusterIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClusterIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectivityEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint>
    {
        internal ConnectivityEndpoint() { }
        public string EndpointLocation { get { throw null; } }
        public string Name { get { throw null; } }
        public int? Port { get { throw null; } }
        public string PrivateIPAddress { get { throw null; } }
        public string Protocol { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntraUserInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.EntraUserInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.EntraUserInfo>
    {
        public EntraUserInfo() { }
        public string DisplayName { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.EntraUserInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.EntraUserInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.EntraUserInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.EntraUserInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.EntraUserInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.EntraUserInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.EntraUserInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.EntraUserInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.EntraUserInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Errors : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.Errors>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.Errors>
    {
        public Errors() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.Errors JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.Errors PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.Errors System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.Errors>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.Errors>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.Errors System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.Errors>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.Errors>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.Errors>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExcludedServicesConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig>
    {
        internal ExcludedServicesConfig() { }
        public string ExcludedServicesConfigId { get { throw null; } }
        public string ExcludedServicesList { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteScriptActionParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionParameters>
    {
        public ExecuteScriptActionParameters(bool persistOnSuccess) { }
        public bool PersistOnSuccess { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction> ScriptActions { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightApplicationEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint>
    {
        public HDInsightApplicationEndpoint() { }
        public int? DestinationPort { get { throw null; } set { } }
        public string EndpointLocation { get { throw null; } set { } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public int? PublicPort { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightApplicationHttpsEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint>
    {
        public HDInsightApplicationHttpsEndpoint() { }
        public System.Collections.Generic.IList<string> AccessModes { get { throw null; } }
        public int? DestinationPort { get { throw null; } set { } }
        public bool? DisableGatewayAuth { get { throw null; } set { } }
        public string EndpointLocation { get { throw null; } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public int? PublicPort { get { throw null; } }
        public string SubDomainSuffix { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightApplicationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties>
    {
        public HDInsightApplicationProperties() { }
        public string ApplicationState { get { throw null; } }
        public string ApplicationType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole> ComputeRoles { get { throw null; } }
        public string CreatedDate { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.Errors> Errors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint> HttpsEndpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction> InstallScriptActions { get { throw null; } }
        public string MarketplaceIdentifier { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration> PrivateLinkConfigurations { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint> SshEndpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction> UninstallScriptActions { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightAutoScaleCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleCapacity>
    {
        public HDInsightAutoScaleCapacity() { }
        public int? MaxInstanceCount { get { throw null; } set { } }
        public int? MinInstanceCount { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleCapacity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleCapacity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightAutoScaleConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration>
    {
        public HDInsightAutoScaleConfiguration() { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleCapacity Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleRecurrence Recurrence { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightAutoScaleConfigurationUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent>
    {
        public HDInsightAutoScaleConfigurationUpdateContent() { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration Autoscale { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightAutoScaleRecurrence : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleRecurrence>
    {
        public HDInsightAutoScaleRecurrence() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleSchedule> Schedule { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleRecurrence JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleRecurrence PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightAutoScaleSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleSchedule>
    {
        public HDInsightAutoScaleSchedule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek> Days { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleTimeAndCapacity TimeAndCapacity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightAutoScaleTimeAndCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleTimeAndCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleTimeAndCapacity>
    {
        public HDInsightAutoScaleTimeAndCapacity() { }
        public int? MaxInstanceCount { get { throw null; } set { } }
        public int? MinInstanceCount { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleTimeAndCapacity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleTimeAndCapacity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleTimeAndCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleTimeAndCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleTimeAndCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleTimeAndCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleTimeAndCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleTimeAndCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleTimeAndCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightAzureMonitorExtensionEnableContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent>
    {
        public HDInsightAzureMonitorExtensionEnableContent() { }
        public string PrimaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations SelectedConfigurations { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightAzureMonitorExtensionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus>
    {
        internal HDInsightAzureMonitorExtensionStatus() { }
        public bool? ClusterMonitoringEnabled { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations SelectedConfigurations { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightAzureMonitorSelectedConfigurations : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations>
    {
        public HDInsightAzureMonitorSelectedConfigurations() { }
        public string ConfigurationVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> GlobalConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorTableConfiguration> TableList { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightAzureMonitorTableConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorTableConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorTableConfiguration>
    {
        public HDInsightAzureMonitorTableConfiguration() { }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorTableConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorTableConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorTableConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorTableConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorTableConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorTableConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorTableConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorTableConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorTableConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightBillingMeters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters>
    {
        internal HDInsightBillingMeters() { }
        public string Meter { get { throw null; } }
        public string MeterParameter { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightBillingResources : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources>
    {
        internal HDInsightBillingResources() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters> BillingMeters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters> DiskBillingMeters { get { throw null; } }
        public string Region { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightBillingSpecsListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>
    {
        internal HDInsightBillingSpecsListResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources> BillingResources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2> VmSizeFilters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty> VmSizeProperties { get { throw null; } }
        public System.Collections.Generic.IList<string> VmSizes { get { throw null; } }
        public System.Collections.Generic.IList<string> VmSizesWithEncryptionAtHost { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightCapabilitiesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult>
    {
        internal HDInsightCapabilitiesResult() { }
        public System.Collections.Generic.IList<string> Features { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.QuotaCapability Quota { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HDInsight.Models.RegionsCapability> Regions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability> Versions { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterAaddsDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail>
    {
        internal HDInsightClusterAaddsDetail() { }
        public string DomainName { get { throw null; } }
        public bool? InitialSyncComplete { get { throw null; } }
        public bool? LdapsEnabled { get { throw null; } }
        public string LdapsPublicCertificateInBase64 { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string SubnetId { get { throw null; } }
        public string TenantId { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterConfigurations : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations>
    {
        internal HDInsightClusterConfigurations() { }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, string>> Configurations { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterCreateExtensionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent>
    {
        public HDInsightClusterCreateExtensionContent() { }
        public string PrimaryKey { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterCreateOrUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties>
    {
        public HDInsightClusterCreateOrUpdateProperties() { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition ClusterDefinition { get { throw null; } set { } }
        public string ClusterVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties ComputeIsolationProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole> ComputeRoles { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties DiskEncryptionProperties { get { throw null; } set { } }
        public bool? IsEncryptionInTransitEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.KafkaRestProperties KafkaRestProperties { get { throw null; } set { } }
        public string MinSupportedTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties NetworkProperties { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightOSType? OsType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration> PrivateLinkConfigurations { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile SecurityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo> StorageStorageaccounts { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterCreationValidateContent : Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent>
    {
        public HDInsightClusterCreationValidateContent() { }
        public bool? FetchAaddsResource { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected override Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.HDInsight.Models.ClusterCreateParametersExtended PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterCreationValidateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>
    {
        internal HDInsightClusterCreationValidateResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail> AaddsResourcesDetails { get { throw null; } }
        public System.TimeSpan? EstimatedCreationDuration { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo> ValidationErrors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo> ValidationWarnings { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterDataDiskGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>
    {
        public HDInsightClusterDataDiskGroup() { }
        public int? DiskSizeGB { get { throw null; } }
        public int? DisksPerNode { get { throw null; } set { } }
        public string StorageAccountType { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition>
    {
        public HDInsightClusterDefinition() { }
        public string Blueprint { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ComponentVersion { get { throw null; } }
        public System.BinaryData Configurations { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterDiskEncryptionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent>
    {
        public HDInsightClusterDiskEncryptionContent() { }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public string VaultUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterEnableClusterMonitoringContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent>
    {
        public HDInsightClusterEnableClusterMonitoringContent() { }
        public string PrimaryKey { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterExtensionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>
    {
        internal HDInsightClusterExtensionStatus() { }
        public bool? ClusterMonitoringEnabled { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterGatewaySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>
    {
        internal HDInsightClusterGatewaySettings() { }
        public string IsCredentialEnabled { get { throw null; } }
        public string Password { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.EntraUserInfo> RestAuthEntraUsers { get { throw null; } }
        public string UserName { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterHostInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo>
    {
        internal HDInsightClusterHostInfo() { }
        public string EffectiveDiskEncryptionKeyUri { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterIPTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterIPTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterIPTag>
    {
        public HDInsightClusterIPTag(string ipTagType, string tag) { }
        public string IpTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterIPTag JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterIPTag PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterIPTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterIPTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterIPTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterIPTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterIPTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterIPTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterIPTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterNetworkProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties>
    {
        public HDInsightClusterNetworkProperties() { }
        public Azure.ResourceManager.HDInsight.Models.OutboundDependenciesManagedType? OutboundDependenciesManagedType { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState? PrivateLink { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterIPTag PublicIpTag { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection? ResourceProviderConnection { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch>
    {
        public HDInsightClusterPatch() { }
        public Azure.ResourceManager.HDInsight.Models.ClusterIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties>
    {
        internal HDInsightClusterProperties() { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition ClusterDefinition { get { throw null; } }
        public string ClusterHdpVersion { get { throw null; } }
        public string ClusterId { get { throw null; } }
        public string ClusterState { get { throw null; } }
        public string ClusterVersion { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties ComputeIsolationProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole> ComputeRoles { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint> ConnectivityEndpoints { get { throw null; } }
        public string CreatedDate { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties DiskEncryptionProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.Errors> Errors { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig ExcludedServicesConfig { get { throw null; } }
        public bool? IsEncryptionInTransitEnabled { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.KafkaRestProperties KafkaRestProperties { get { throw null; } }
        public string MinSupportedTlsVersion { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties NetworkProperties { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightOSType? OsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration> PrivateLinkConfigurations { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState? ProvisioningState { get { throw null; } }
        public int? QuotaInfoCoresUsed { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile SecurityProfile { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo> StorageStorageaccounts { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightTier? Tier { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightClusterProvisioningState : System.IEquatable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState left, Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState left, Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightClusterResizeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent>
    {
        public HDInsightClusterResizeContent() { }
        public int? TargetInstanceCount { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterRole : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole>
    {
        public HDInsightClusterRole() { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration AutoscaleConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup> DataDisksGroups { get { throw null; } }
        public bool? EncryptDataDisks { get { throw null; } set { } }
        public string HardwareVmSize { get { throw null; } set { } }
        public int? MinInstanceCount { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightLinuxOSProfile OsLinuxOperatingSystemProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.ScriptAction> ScriptActions { get { throw null; } }
        public int? TargetInstanceCount { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile VirtualNetworkProfile { get { throw null; } set { } }
        public string VMGroupName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterUpdateGatewaySettingsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent>
    {
        public HDInsightClusterUpdateGatewaySettingsContent() { }
        public bool? IsCredentialEnabled { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.EntraUserInfo> RestAuthEntraUsers { get { throw null; } }
        public string UserName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterUpdateIdentityCertificateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateIdentityCertificateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateIdentityCertificateContent>
    {
        public HDInsightClusterUpdateIdentityCertificateContent() { }
        public string ApplicationId { get { throw null; } set { } }
        public string Certificate { get { throw null; } set { } }
        public string CertificatePassword { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateIdentityCertificateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateIdentityCertificateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateIdentityCertificateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateIdentityCertificateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateIdentityCertificateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateIdentityCertificateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateIdentityCertificateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateIdentityCertificateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateIdentityCertificateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterValidationErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo>
    {
        internal HDInsightClusterValidationErrorInfo() { }
        public string Code { get { throw null; } }
        public string ErrorResource { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IList<string> MessageArguments { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightComputeIsolationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties>
    {
        public HDInsightComputeIsolationProperties() { }
        public bool? EnableComputeIsolation { get { throw null; } set { } }
        public string HostSku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightDayOfWeek : System.IEquatable<Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightDayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek left, Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek left, Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightDiskBillingMeters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters>
    {
        internal HDInsightDiskBillingMeters() { }
        public string DiskRpMeter { get { throw null; } }
        public string Sku { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightTier? Tier { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightDiskEncryptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties>
    {
        public HDInsightDiskEncryptionProperties() { }
        public Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm? EncryptionAlgorithm { get { throw null; } set { } }
        public bool? EncryptionAtHost { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public string MsiResourceId { get { throw null; } set { } }
        public string VaultUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightFilterMode : System.IEquatable<Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightFilterMode(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode Default { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode Exclude { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode Include { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode Recommend { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode left, Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode left, Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration>
    {
        public HDInsightIPConfiguration(string name) { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod? PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public string SubnetId { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightLinuxOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightLinuxOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightLinuxOSProfile>
    {
        public HDInsightLinuxOSProfile() { }
        public string Password { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightSshPublicKey> SshPublicKeys { get { throw null; } }
        public string Username { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightLinuxOSProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightLinuxOSProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightLinuxOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightLinuxOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightLinuxOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightLinuxOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightLinuxOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightLinuxOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightLinuxOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightLocalizedName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName>
    {
        internal HDInsightLocalizedName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent>
    {
        public HDInsightNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult>
    {
        internal HDInsightNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightOSType : System.IEquatable<Azure.ResourceManager.HDInsight.Models.HDInsightOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightOSType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.HDInsightOSType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightOSType left, Azure.ResourceManager.HDInsight.Models.HDInsightOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightOSType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightOSType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightOSType left, Azure.ResourceManager.HDInsight.Models.HDInsightOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightPrivateIPAllocationMethod : System.IEquatable<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightPrivateIPAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightPrivateLinkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration>
    {
        public HDInsightPrivateLinkConfiguration(string name, string groupId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration> ipConfigurations) { }
        public string GroupId { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration> IpConfigurations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightPrivateLinkConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightPrivateLinkConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState>
    {
        public HDInsightPrivateLinkServiceConnectionState(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus status) { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightPrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightPrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus Removed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightPrivateLinkState : System.IEquatable<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightPrivateLinkState(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightResourceProviderConnection : System.IEquatable<Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightResourceProviderConnection(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection Inbound { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection left, Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection left, Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightRoleName : System.IEquatable<Azure.ResourceManager.HDInsight.Models.HDInsightRoleName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightRoleName(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightRoleName Workernode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.HDInsightRoleName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightRoleName left, Azure.ResourceManager.HDInsight.Models.HDInsightRoleName right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightRoleName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightRoleName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightRoleName left, Azure.ResourceManager.HDInsight.Models.HDInsightRoleName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile>
    {
        public HDInsightSecurityProfile() { }
        public string AaddsResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ClusterUsersGroupDNs { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType? DirectoryType { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string DomainUsername { get { throw null; } set { } }
        public string DomainUserPassword { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LdapsUrls { get { throw null; } }
        public string MsiResourceId { get { throw null; } set { } }
        public string OrganizationalUnitDN { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightSshPublicKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightSshPublicKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightSshPublicKey>
    {
        public HDInsightSshPublicKey() { }
        public string CertificateData { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightSshPublicKey JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightSshPublicKey PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightSshPublicKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightSshPublicKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightSshPublicKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightSshPublicKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightSshPublicKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightSshPublicKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightSshPublicKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightStorageAccountInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo>
    {
        public HDInsightStorageAccountInfo() { }
        public string Container { get { throw null; } set { } }
        public bool? EnableSecureChannel { get { throw null; } set { } }
        public string Fileshare { get { throw null; } set { } }
        public string FileSystem { get { throw null; } set { } }
        public bool? IsDefault { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public string MsiResourceId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string Saskey { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightTier : System.IEquatable<Azure.ResourceManager.HDInsight.Models.HDInsightTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightTier(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightTier Premium { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.HDInsightTier other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightTier left, Azure.ResourceManager.HDInsight.Models.HDInsightTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightTier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightTier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightTier left, Azure.ResourceManager.HDInsight.Models.HDInsightTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightUsage>
    {
        internal HDInsightUsage() { }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName Name { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightVersionsCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability>
    {
        internal HDInsightVersionsCapability() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec> Available { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightVersionSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec>
    {
        internal HDInsightVersionSpec() { }
        public System.Collections.Generic.IDictionary<string, string> ComponentVersions { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public bool? IsDefault { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightVirtualNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile>
    {
        public HDInsightVirtualNetworkProfile() { }
        public string Id { get { throw null; } set { } }
        public string Subnet { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightVmSizeCompatibilityFilterV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2>
    {
        internal HDInsightVmSizeCompatibilityFilterV2() { }
        public System.Collections.Generic.IList<string> ClusterFlavors { get { throw null; } }
        public System.Collections.Generic.IList<string> ClusterVersions { get { throw null; } }
        public string ComputeIsolationSupported { get { throw null; } }
        public string EspApplied { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode? FilterMode { get { throw null; } }
        public System.Collections.Generic.IList<string> NodeTypes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightOSType> OsType { get { throw null; } }
        public System.Collections.Generic.IList<string> Regions { get { throw null; } }
        public System.Collections.Generic.IList<string> VmSizes { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2 JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2 PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightVmSizeProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty>
    {
        internal HDInsightVmSizeProperty() { }
        public int? Cores { get { throw null; } }
        public string DataDiskStorageTier { get { throw null; } }
        public string Label { get { throw null; } }
        public long? MaxDataDiskCount { get { throw null; } }
        public long? MemoryInMb { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? SupportedByVirtualMachines { get { throw null; } }
        public bool? SupportedByWebWorkerRoles { get { throw null; } }
        public long? VirtualMachineResourceDiskSizeInMb { get { throw null; } }
        public long? WebWorkerResourceDiskSizeInMb { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JsonWebKeyEncryptionAlgorithm : System.IEquatable<Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JsonWebKeyEncryptionAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm RSA15 { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm RSAOAEP { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm RSAOAEP256 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm left, Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm left, Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KafkaRestProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.KafkaRestProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.KafkaRestProperties>
    {
        public KafkaRestProperties() { }
        public Azure.ResourceManager.HDInsight.Models.ClientGroupInfo ClientGroupInfo { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationOverride { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.KafkaRestProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.KafkaRestProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.KafkaRestProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.KafkaRestProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.KafkaRestProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.KafkaRestProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.KafkaRestProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.KafkaRestProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.KafkaRestProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OutboundDependenciesManagedType : System.IEquatable<Azure.ResourceManager.HDInsight.Models.OutboundDependenciesManagedType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OutboundDependenciesManagedType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.OutboundDependenciesManagedType External { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.OutboundDependenciesManagedType Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.OutboundDependenciesManagedType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.OutboundDependenciesManagedType left, Azure.ResourceManager.HDInsight.Models.OutboundDependenciesManagedType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.OutboundDependenciesManagedType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.OutboundDependenciesManagedType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.OutboundDependenciesManagedType left, Azure.ResourceManager.HDInsight.Models.OutboundDependenciesManagedType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.QuotaCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.QuotaCapability>
    {
        internal QuotaCapability() { }
        public long? CoresUsed { get { throw null; } }
        public long? MaxCoresAllowed { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability> RegionalQuotas { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.QuotaCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.QuotaCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.QuotaCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.QuotaCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.QuotaCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.QuotaCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.QuotaCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.QuotaCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.QuotaCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegionalQuotaCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability>
    {
        internal RegionalQuotaCapability() { }
        public long? CoresAvailable { get { throw null; } }
        public long? CoresUsed { get { throw null; } }
        public string RegionName { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegionsCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RegionsCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RegionsCapability>
    {
        internal RegionsCapability() { }
        public System.Collections.Generic.IList<string> Available { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.RegionsCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.RegionsCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.RegionsCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RegionsCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RegionsCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.RegionsCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RegionsCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RegionsCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RegionsCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceIdentityType : System.IEquatable<Azure.ResourceManager.HDInsight.Models.ResourceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.ResourceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.ResourceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.ResourceIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.ResourceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.ResourceIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.ResourceIdentityType left, Azure.ResourceManager.HDInsight.Models.ResourceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.ResourceIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.ResourceIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.ResourceIdentityType left, Azure.ResourceManager.HDInsight.Models.ResourceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RuntimeScriptAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction>
    {
        public RuntimeScriptAction(string name, string uri, System.Collections.Generic.IEnumerable<string> roles) { }
        public string ApplicationName { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RuntimeScriptActionDetail : Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>
    {
        internal RuntimeScriptActionDetail() : base (default(string), default(string), default(System.Collections.Generic.IEnumerable<string>)) { }
        public string DebugInformation { get { throw null; } }
        public string EndTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary> ExecutionSummary { get { throw null; } }
        public string Operation { get { throw null; } }
        public long? ScriptExecutionId { get { throw null; } }
        public string StartTime { get { throw null; } }
        public string Status { get { throw null; } }
        protected override Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScriptAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ScriptAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ScriptAction>
    {
        public ScriptAction(string name, string uri, string parameters) { }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.ScriptAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.ScriptAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.ScriptAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ScriptAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ScriptAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.ScriptAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ScriptAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ScriptAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ScriptAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScriptActionExecutionSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary>
    {
        internal ScriptActionExecutionSummary() { }
        public int? InstanceCount { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UsagesListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.UsagesListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.UsagesListResult>
    {
        internal UsagesListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightUsage> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.HDInsight.Models.UsagesListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.UsagesListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.UsagesListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.UsagesListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.UsagesListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.UsagesListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.UsagesListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.UsagesListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.UsagesListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAssignedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.UserAssignedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.UserAssignedIdentity>
    {
        public UserAssignedIdentity() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HDInsight.Models.UserAssignedIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HDInsight.Models.UserAssignedIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HDInsight.Models.UserAssignedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.UserAssignedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.UserAssignedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.UserAssignedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.UserAssignedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.UserAssignedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.UserAssignedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
