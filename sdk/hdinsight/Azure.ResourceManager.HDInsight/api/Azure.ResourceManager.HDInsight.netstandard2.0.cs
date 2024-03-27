namespace Azure.ResourceManager.HDInsight
{
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
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.HDInsight.HDInsightApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.HDInsightApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightApplicationResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult> GetAzureAsyncOperationStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>> GetAzureAsyncOperationStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.HDInsightApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.HDInsightApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HDInsightClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.HDInsightClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.HDInsightClusterResource>, System.Collections.IEnumerable
    {
        protected HDInsightClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.HDInsightClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public HDInsightClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.HDInsight.HDInsightClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.HDInsightClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HDInsightClusterResource() { }
        public virtual Azure.ResourceManager.HDInsight.HDInsightClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateExtension(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateExtensionAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteExtension(Azure.WaitUntil waitUntil, string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteExtensionAsync(Azure.WaitUntil waitUntil, string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteScriptAction(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteScriptActionAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DisableAzureMonitorExtension(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DisableAzureMonitorExtensionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DisableClusterMonitoringExtension(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DisableClusterMonitoringExtensionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableAzureMonitorExtension(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableAzureMonitorExtensionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableClusterMonitoringExtension(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableClusterMonitoringExtensionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ExecuteScriptActions(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteScriptActionsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult> GetAsyncOperationStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>> GetAsyncOperationStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus> GetAzureMonitorExtensionStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus>> GetAzureMonitorExtensionStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus> GetClusterMonitoringExtensionStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>> GetClusterMonitoringExtensionStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, string>> GetConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations> GetConfiguration(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, string>>> GetConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations>> GetConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus> GetExtension(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>> GetExtensionAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult> GetExtensionAsyncOperationStatus(string extensionName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>> GetExtensionAsyncOperationStatusAsync(string extensionName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings> GetGatewaySettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>> GetGatewaySettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> GetHDInsightApplication(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>> GetHDInsightApplicationAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.HDInsightApplicationCollection GetHDInsightApplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource> GetHDInsightPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource>> GetHDInsightPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionCollection GetHDInsightPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource> GetHDInsightPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource>> GetHDInsightPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceCollection GetHDInsightPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult> GetScriptActionExecutionAsyncOperationStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>> GetScriptActionExecutionAsyncOperationStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetScriptActionExecutionDetail(string scriptExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>> GetScriptActionExecutionDetailAsync(string scriptExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetScriptActions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetScriptActionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetScriptExecutionHistories(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetScriptExecutionHistoriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult> GetVirtualMachineAsyncOperationStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>> GetVirtualMachineAsyncOperationStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo> GetVirtualMachineHosts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo> GetVirtualMachineHostsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PromoteScriptExecutionHistory(string scriptExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PromoteScriptExecutionHistoryAsync(string scriptExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resize(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightRoleName roleName, Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResizeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightRoleName roleName, Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestartVirtualMachineHosts(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartVirtualMachineHostsAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RotateDiskEncryptionKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RotateDiskEncryptionKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> Update(Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> UpdateAsync(Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateAutoScaleConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightRoleName roleName, Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAutoScaleConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightRoleName roleName, Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateConfiguration(Azure.WaitUntil waitUntil, string configurationName, System.Collections.Generic.IDictionary<string, string> clusterConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateConfigurationAsync(Azure.WaitUntil waitUntil, string configurationName, System.Collections.Generic.IDictionary<string, string> clusterConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateGatewaySettings(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateGatewaySettingsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateGatewaySettingsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateIdentityCertificate(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateIdentityCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateIdentityCertificateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterUpdateIdentityCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HDInsightExtensions
    {
        public static Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult> CheckHDInsightNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult>> CheckHDInsightNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightApplicationResource GetHDInsightApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult> GetHDInsightBillingSpecs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>> GetHDInsightBillingSpecsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult> GetHDInsightCapabilities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult>> GetHDInsightCapabilitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetHDInsightCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> GetHDInsightClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightClusterResource GetHDInsightClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightClusterCollection GetHDInsightClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetHDInsightClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetHDInsightClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource GetHDInsightPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource GetHDInsightPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HDInsight.Models.HDInsightUsage> GetHDInsightUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Models.HDInsightUsage> GetHDInsightUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult> ValidateHDInsightClusterCreation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>> ValidateHDInsightClusterCreationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HDInsightPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected HDInsightPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HDInsightPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>
    {
        public HDInsightPrivateEndpointConnectionData(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState connectionState) { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public string LinkIdentifier { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HDInsightPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HDInsightPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HDInsightPrivateLinkResource() { }
        public virtual Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HDInsightPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected HDInsightPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HDInsightPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>
    {
        public HDInsightPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.HDInsight.Mocking
{
    public partial class MockableHDInsightArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHDInsightArmClient() { }
        public virtual Azure.ResourceManager.HDInsight.HDInsightApplicationResource GetHDInsightApplicationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.HDInsightClusterResource GetHDInsightClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource GetHDInsightPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource GetHDInsightPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult> CheckHDInsightNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult>> CheckHDInsightNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult> GetHDInsightBillingSpecs(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>> GetHDInsightBillingSpecsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult> GetHDInsightCapabilities(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult>> GetHDInsightCapabilitiesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetHDInsightClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetHDInsightClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Models.HDInsightUsage> GetHDInsightUsages(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Models.HDInsightUsage> GetHDInsightUsagesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult> ValidateHDInsightClusterCreation(Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>> ValidateHDInsightClusterCreationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HDInsight.Models
{
    public static partial class ArmHDInsightModelFactory
    {
        public static Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionContent ExecuteScriptActionContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction> scriptActions = null, bool persistOnSuccess = false) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightApplicationData HDInsightApplicationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint HDInsightApplicationHttpsEndpoint(System.Collections.Generic.IEnumerable<string> accessModes = null, string endpointLocation = null, int? destinationPort = default(int?), int? publicPort = default(int?), System.Net.IPAddress privateIPAddress = null, string subDomainSuffix = null, bool? disableGatewayAuth = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties HDInsightApplicationProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole> computeRoles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction> installScriptActions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction> uninstallScriptActions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint> httpsEndpoints = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint> sshEndpoints = null, string provisioningState = null, string applicationType = null, string applicationState = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string marketplaceIdentifier = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration> privateLinkConfigurations = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult HDInsightAsyncOperationResult(Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationState? status = default(Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationState?), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus HDInsightAzureMonitorExtensionStatus(bool? isClusterMonitoringEnabled = default(bool?), string workspaceId = null, Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations selectedConfigurations = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters HDInsightBillingMeters(string meterParameter = null, string meter = null, string unit = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources HDInsightBillingResources(Azure.Core.AzureLocation? region = default(Azure.Core.AzureLocation?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters> billingMeters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters> diskBillingMeters = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult HDInsightBillingSpecsListResult(System.Collections.Generic.IEnumerable<string> vmSizes = null, System.Collections.Generic.IEnumerable<string> vmSizesWithEncryptionAtHost = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2> vmSizeFilters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty> vmSizeProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources> billingResources = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult HDInsightCapabilitiesResult(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability> versions = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Models.RegionsCapability> regions = null, System.Collections.Generic.IEnumerable<string> features = null, Azure.ResourceManager.HDInsight.Models.QuotaCapability quota = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail HDInsightClusterAaddsDetail(string domainName = null, bool? isInitialSyncComplete = default(bool?), bool? isLdapsEnabled = default(bool?), string ldapsPublicCertificateInBase64 = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.ResourceIdentifier subnetId = null, System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations HDInsightClusterConfigurations(System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IDictionary<string, string>> configurations = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult HDInsightClusterCreationValidateResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo> validationErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo> validationWarnings = null, System.TimeSpan? estimatedCreationDuration = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail> aaddsResourcesDetails = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightClusterData HDInsightClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup HDInsightClusterDataDiskGroup(int? disksPerNode = default(int?), string storageAccountType = null, int? diskSizeInGB = default(int?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus HDInsightClusterExtensionStatus(bool? isClusterMonitoringEnabled = default(bool?), string workspaceId = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo HDInsightClusterHostInfo(string name = null, string fqdn = null, System.Uri effectiveDiskEncryptionKeyUri = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties HDInsightClusterProperties(string clusterVersion = null, string clusterHdpVersion = null, Azure.ResourceManager.HDInsight.Models.HDInsightOSType? osType = default(Azure.ResourceManager.HDInsight.Models.HDInsightOSType?), Azure.ResourceManager.HDInsight.Models.HDInsightTier? tier = default(Azure.ResourceManager.HDInsight.Models.HDInsightTier?), string clusterId = null, Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition clusterDefinition = null, Azure.ResourceManager.HDInsight.Models.KafkaRestProperties kafkaRestProperties = null, Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile securityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole> computeRoles = null, Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState? provisioningState = default(Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string clusterState = null, int? quotaInfoCoresUsed = default(int?), System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint> connectivityEndpoints = null, Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties diskEncryptionProperties = null, bool? isEncryptionInTransitEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo> storageAccounts = null, string minSupportedTlsVersion = null, Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig excludedServicesConfig = null, Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties networkProperties = null, Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties computeIsolationProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration> privateLinkConfigurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo HDInsightClusterValidationErrorInfo(string code = null, string message = null, string errorResource = null, System.Collections.Generic.IEnumerable<string> messageArguments = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters HDInsightDiskBillingMeters(string diskRpMeter = null, string sku = null, Azure.ResourceManager.HDInsight.Models.HDInsightTier? tier = default(Azure.ResourceManager.HDInsight.Models.HDInsightTier?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration HDInsightIPConfiguration(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState?), bool? isPrimary = default(bool?), System.Net.IPAddress privateIPAddress = null, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod? privateIPAllocationMethod = default(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod?), Azure.Core.ResourceIdentifier subnetId = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName HDInsightLocalizedName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult HDInsightNameAvailabilityResult(bool? isNameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData HDInsightPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState connectionState = null, string linkIdentifier = null, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration HDInsightPrivateLinkConfiguration(string id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string groupId = null, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration> ipConfigurations = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceData HDInsightPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightUsage HDInsightUsage(string unit = null, long? currentValue = default(long?), long? limit = default(long?), Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName name = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability HDInsightVersionsCapability(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec> available = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec HDInsightVersionSpec(string friendlyName = null, string displayName = null, bool? isDefault = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> componentVersions = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2 HDInsightVmSizeCompatibilityFilterV2(Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode? filterMode = default(Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode?), System.Collections.Generic.IEnumerable<string> regions = null, System.Collections.Generic.IEnumerable<string> clusterFlavors = null, System.Collections.Generic.IEnumerable<string> nodeTypes = null, System.Collections.Generic.IEnumerable<string> clusterVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightOSType> osType = null, System.Collections.Generic.IEnumerable<string> vmSizes = null, string espApplied = null, string isComputeIsolationSupported = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty HDInsightVmSizeProperty(string name = null, int? cores = default(int?), string dataDiskStorageTier = null, string label = null, long? maxDataDiskCount = default(long?), long? memoryInMB = default(long?), bool? isSupportedByVirtualMachines = default(bool?), bool? isSupportedByWebWorkerRoles = default(bool?), long? virtualMachineResourceDiskSizeInMB = default(long?), long? webWorkerResourceDiskSizeInMB = default(long?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.QuotaCapability QuotaCapability(long? coresUsed = default(long?), long? maxCoresAllowed = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability> regionalQuotas = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability RegionalQuotaCapability(Azure.Core.AzureLocation? region = default(Azure.Core.AzureLocation?), long? coresUsed = default(long?), long? coresAvailable = default(long?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.RegionsCapability RegionsCapability(System.Collections.Generic.IEnumerable<string> available = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction RuntimeScriptAction(string name = null, System.Uri uri = null, string parameters = null, System.Collections.Generic.IEnumerable<string> roles = null, string applicationName = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail RuntimeScriptActionDetail(string name = null, System.Uri uri = null, string parameters = null, System.Collections.Generic.IEnumerable<string> roles = null, string applicationName = null, long? scriptExecutionId = default(long?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string status = null, string operation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary> executionSummary = null, string debugInformation = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary ScriptActionExecutionSummary(string status = null, int? instanceCount = default(int?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthenticationDirectoryType : System.IEquatable<Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationDirectoryType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType ActiveDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType left, Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType left, Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClientGroupInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ClientGroupInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClientGroupInfo>
    {
        public ClientGroupInfo() { }
        public string GroupId { get { throw null; } set { } }
        public string GroupName { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Models.ClientGroupInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ClientGroupInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ClientGroupInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.ClientGroupInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClientGroupInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClientGroupInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ClientGroupInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectivityEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint>
    {
        public ConnectivityEndpoint() { }
        public string EndpointLocation { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExcludedServicesConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig>
    {
        public ExcludedServicesConfig() { }
        public string ExcludedServicesConfigId { get { throw null; } set { } }
        public string ExcludedServicesList { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteScriptActionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionContent>
    {
        public ExecuteScriptActionContent(bool persistOnSuccess) { }
        public bool PersistOnSuccess { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction> ScriptActions { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightApplicationEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint>
    {
        public HDInsightApplicationEndpoint() { }
        public int? DestinationPort { get { throw null; } set { } }
        public string EndpointLocation { get { throw null; } set { } }
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } set { } }
        public int? PublicPort { get { throw null; } set { } }
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
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } set { } }
        public int? PublicPort { get { throw null; } }
        public string SubDomainSuffix { get { throw null; } set { } }
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
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResponseError> Errors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationHttpsEndpoint> HttpsEndpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction> InstallScriptActions { get { throw null; } }
        public string MarketplaceIdentifier { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration> PrivateLinkConfigurations { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint> SshEndpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction> UninstallScriptActions { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightAsyncOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>
    {
        internal HDInsightAsyncOperationResult() { }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationState? Status { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightAsyncOperationState : System.IEquatable<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightAsyncOperationState(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationState Failed { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationState InProgress { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationState left, Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationState left, Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightAutoScaleCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleCapacity>
    {
        public HDInsightAutoScaleCapacity() { }
        public int? MaxInstanceCount { get { throw null; } set { } }
        public int? MinInstanceCount { get { throw null; } set { } }
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
        Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightAutoScaleConfigurationUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent>
    {
        public HDInsightAutoScaleConfigurationUpdateContent() { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration AutoScale { get { throw null; } set { } }
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
        Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionEnableContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightAzureMonitorExtensionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorExtensionStatus>
    {
        internal HDInsightAzureMonitorExtensionStatus() { }
        public bool? IsClusterMonitoringEnabled { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations SelectedConfigurations { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
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
        Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightBillingResources : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources>
    {
        internal HDInsightBillingResources() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters> BillingMeters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters> DiskBillingMeters { get { throw null; } }
        public Azure.Core.AzureLocation? Region { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightBillingSpecsListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>
    {
        internal HDInsightBillingSpecsListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources> BillingResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2> VmSizeFilters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty> VmSizeProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VmSizes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VmSizesWithEncryptionAtHost { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightCapabilitiesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult>
    {
        internal HDInsightCapabilitiesResult() { }
        public System.Collections.Generic.IReadOnlyList<string> Features { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.QuotaCapability Quota { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Models.RegionsCapability> Regions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability> Versions { get { throw null; } }
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
        public bool? IsInitialSyncComplete { get { throw null; } }
        public bool? IsLdapsEnabled { get { throw null; } }
        public string LdapsPublicCertificateInBase64 { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterConfigurations : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations>
    {
        internal HDInsightClusterConfigurations() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IDictionary<string, string>> Configurations { get { throw null; } }
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
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateExtensionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateContent>
    {
        public HDInsightClusterCreateOrUpdateContent() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.HDInsight.Models.HDInsightOSType? OSType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration> PrivateLinkConfigurations { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile SecurityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo> StorageAccounts { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightTier? Tier { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterCreationValidateContent : Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent>
    {
        public HDInsightClusterCreationValidateContent() { }
        public string ClusterCreateRequestValidationParametersType { get { throw null; } set { } }
        public bool? FetchAaddsResource { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterCreationValidateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>
    {
        internal HDInsightClusterCreationValidateResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail> AaddsResourcesDetails { get { throw null; } }
        public System.TimeSpan? EstimatedCreationDuration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo> ValidationErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo> ValidationWarnings { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterDataDiskGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>
    {
        public HDInsightClusterDataDiskGroup() { }
        public int? DiskSizeInGB { get { throw null; } }
        public int? DisksPerNode { get { throw null; } set { } }
        public string StorageAccountType { get { throw null; } }
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
        public System.Uri VaultUri { get { throw null; } set { } }
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
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterEnableClusterMonitoringContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterExtensionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>
    {
        internal HDInsightClusterExtensionStatus() { }
        public bool? IsClusterMonitoringEnabled { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterExtensionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterGatewaySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>
    {
        internal HDInsightClusterGatewaySettings() { }
        public bool? IsCredentialEnabled { get { throw null; } }
        public string Password { get { throw null; } }
        public string UserName { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterGatewaySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterHostInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo>
    {
        internal HDInsightClusterHostInfo() { }
        public System.Uri EffectiveDiskEncryptionKeyUri { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterHostInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterNetworkProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties>
    {
        public HDInsightClusterNetworkProperties() { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState? PrivateLink { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection? ResourceProviderConnection { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch>
    {
        public HDInsightClusterPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties>
    {
        public HDInsightClusterProperties(Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition clusterDefinition) { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition ClusterDefinition { get { throw null; } set { } }
        public string ClusterHdpVersion { get { throw null; } set { } }
        public string ClusterId { get { throw null; } set { } }
        public string ClusterState { get { throw null; } set { } }
        public string ClusterVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightComputeIsolationProperties ComputeIsolationProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole> ComputeRoles { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint> ConnectivityEndpoints { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties DiskEncryptionProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResponseError> Errors { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig ExcludedServicesConfig { get { throw null; } set { } }
        public bool? IsEncryptionInTransitEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.KafkaRestProperties KafkaRestProperties { get { throw null; } set { } }
        public string MinSupportedTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterNetworkProperties NetworkProperties { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightOSType? OSType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration> PrivateLinkConfigurations { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState? ProvisioningState { get { throw null; } set { } }
        public int? QuotaInfoCoresUsed { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile SecurityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightStorageAccountInfo> StorageAccounts { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightTier? Tier { get { throw null; } set { } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState left, Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState left, Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightClusterResizeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent>
    {
        public HDInsightClusterResizeContent() { }
        public int? TargetInstanceCount { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterRole : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole>
    {
        public HDInsightClusterRole() { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration AutoScaleConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup> DataDisksGroups { get { throw null; } }
        public bool? EncryptDataDisks { get { throw null; } set { } }
        public string HardwareVmSize { get { throw null; } set { } }
        public int? MinInstanceCount { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightLinuxOSProfile OSLinuxProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.ScriptAction> ScriptActions { get { throw null; } }
        public int? TargetInstanceCount { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile VirtualNetworkProfile { get { throw null; } set { } }
        public string VmGroupName { get { throw null; } set { } }
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
        public string UserName { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<string> MessageArguments { get { throw null; } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek left, Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek left, Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightDiskBillingMeters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters>
    {
        internal HDInsightDiskBillingMeters() { }
        public string DiskRpMeter { get { throw null; } }
        public string Sku { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightTier? Tier { get { throw null; } }
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
        public bool? IsEncryptionAtHostEnabled { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MsiResourceId { get { throw null; } set { } }
        public System.Uri VaultUri { get { throw null; } set { } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode left, Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode left, Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration>
    {
        public HDInsightIPConfiguration(string name) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public bool? IsPrimary { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod? PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
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
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult>
    {
        internal HDInsightNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightOSType left, Azure.ResourceManager.HDInsight.Models.HDInsightOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightOSType (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateIPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightPrivateLinkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfiguration>
    {
        public HDInsightPrivateLinkConfiguration(string name, string groupId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration> ipConfigurations) { }
        public string GroupId { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration> IPConfigurations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState>
    {
        public HDInsightPrivateLinkServiceConnectionState(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus status) { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState left, Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection left, Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightRoleName left, Azure.ResourceManager.HDInsight.Models.HDInsightRoleName right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightRoleName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.HDInsightRoleName left, Azure.ResourceManager.HDInsight.Models.HDInsightRoleName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightSecurityProfile>
    {
        public HDInsightSecurityProfile() { }
        public Azure.Core.ResourceIdentifier AaddsResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ClusterUsersGroupDNs { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.AuthenticationDirectoryType? DirectoryType { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string DomainUsername { get { throw null; } set { } }
        public string DomainUserPassword { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Uri> LdapUris { get { throw null; } }
        public Azure.Core.ResourceIdentifier MsiResourceId { get { throw null; } set { } }
        public string OrganizationalUnitDN { get { throw null; } set { } }
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
        public Azure.Core.ResourceIdentifier MsiResourceId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public string SasKey { get { throw null; } set { } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.HDInsightTier left, Azure.ResourceManager.HDInsight.Models.HDInsightTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.HDInsightTier (string value) { throw null; }
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
        Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightVersionSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec>
    {
        internal HDInsightVersionSpec() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ComponentVersions { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public bool? IsDefault { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightVirtualNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile>
    {
        public HDInsightVirtualNetworkProfile() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Subnet { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVirtualNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightVmSizeCompatibilityFilterV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2>
    {
        internal HDInsightVmSizeCompatibilityFilterV2() { }
        public System.Collections.Generic.IReadOnlyList<string> ClusterFlavors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ClusterVersions { get { throw null; } }
        public string EspApplied { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightFilterMode? FilterMode { get { throw null; } }
        public string IsComputeIsolationSupported { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NodeTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightOSType> OSType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Regions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VmSizes { get { throw null; } }
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
        public bool? IsSupportedByVirtualMachines { get { throw null; } }
        public bool? IsSupportedByWebWorkerRoles { get { throw null; } }
        public string Label { get { throw null; } }
        public long? MaxDataDiskCount { get { throw null; } }
        public long? MemoryInMB { get { throw null; } }
        public string Name { get { throw null; } }
        public long? VirtualMachineResourceDiskSizeInMB { get { throw null; } }
        public long? WebWorkerResourceDiskSizeInMB { get { throw null; } }
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
        public static Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm Rsa15 { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm RsaOaep { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm RsaOaep256 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm left, Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm left, Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KafkaRestProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.KafkaRestProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.KafkaRestProperties>
    {
        public KafkaRestProperties() { }
        public Azure.ResourceManager.HDInsight.Models.ClientGroupInfo ClientGroupInfo { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationOverride { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.KafkaRestProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.KafkaRestProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.KafkaRestProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.KafkaRestProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.KafkaRestProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.KafkaRestProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.KafkaRestProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotaCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.QuotaCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.QuotaCapability>
    {
        internal QuotaCapability() { }
        public long? CoresUsed { get { throw null; } }
        public long? MaxCoresAllowed { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability> RegionalQuotas { get { throw null; } }
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
        public Azure.Core.AzureLocation? Region { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegionsCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RegionsCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RegionsCapability>
    {
        internal RegionsCapability() { }
        public System.Collections.Generic.IReadOnlyList<string> Available { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.RegionsCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RegionsCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RegionsCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.RegionsCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RegionsCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RegionsCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RegionsCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RuntimeScriptAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction>
    {
        public RuntimeScriptAction(string name, System.Uri uri, System.Collections.Generic.IEnumerable<string> roles) { }
        public string ApplicationName { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RuntimeScriptActionDetail : Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>
    {
        public RuntimeScriptActionDetail(string name, System.Uri uri, System.Collections.Generic.IEnumerable<string> roles) : base (default(string), default(System.Uri), default(System.Collections.Generic.IEnumerable<string>)) { }
        public string DebugInformation { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary> ExecutionSummary { get { throw null; } }
        public string Operation { get { throw null; } }
        public long? ScriptExecutionId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScriptAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ScriptAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ScriptAction>
    {
        public ScriptAction(string name, System.Uri uri, string parameters) { }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
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
        Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
