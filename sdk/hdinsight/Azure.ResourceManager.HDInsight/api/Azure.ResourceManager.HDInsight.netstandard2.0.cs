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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HDInsightApplicationData : Azure.ResourceManager.Models.ResourceData
    {
        public HDInsightApplicationData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightApplicationProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.HDInsightClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.HDInsightClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.HDInsightClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.HDInsightClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HDInsightClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HDInsightClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class HDInsightClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HDInsightClusterResource() { }
        public virtual Azure.ResourceManager.HDInsight.HDInsightClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateExtension(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.HDInsight.Models.Extension extension, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateExtensionAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.HDInsight.Models.Extension extension, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteExtension(Azure.WaitUntil waitUntil, string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteExtensionAsync(Azure.WaitUntil waitUntil, string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteScriptAction(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteScriptActionAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DisableAzureMonitorExtension(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DisableAzureMonitorExtensionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DisableMonitoringExtension(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DisableMonitoringExtensionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableAzureMonitorExtension(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.AzureMonitorContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableAzureMonitorExtensionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.AzureMonitorContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableMonitoringExtension(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.ClusterMonitoringContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableMonitoringExtensionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.ClusterMonitoringContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ExecuteScriptActions(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteScriptActionsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.ExecuteScriptActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult> GetAsyncOperationStatusVirtualMachine(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>> GetAsyncOperationStatusVirtualMachineAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult> GetAzureAsyncOperationStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>> GetAzureAsyncOperationStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult> GetAzureAsyncOperationStatusExtension(string extensionName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>> GetAzureAsyncOperationStatusExtensionAsync(string extensionName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.AzureMonitorResponse> GetAzureMonitorStatusExtension(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.AzureMonitorResponse>> GetAzureMonitorStatusExtensionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, string>> GetConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations> GetConfiguration(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, string>>> GetConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterConfigurations>> GetConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult> GetExecutionAsyncOperationStatusScriptAction(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationResult>> GetExecutionAsyncOperationStatusScriptActionAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetExecutionDetailScriptAction(string scriptExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail>> GetExecutionDetailScriptActionAsync(string scriptExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.ClusterMonitoringResponse> GetExtension(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.ClusterMonitoringResponse>> GetExtensionAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.GatewaySettings> GetGatewaySettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.GatewaySettings>> GetGatewaySettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource> GetHDInsightApplication(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightApplicationResource>> GetHDInsightApplicationAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.HDInsightApplicationCollection GetHDInsightApplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource> GetHDInsightPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource>> GetHDInsightPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionCollection GetHDInsightPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource> GetHDInsightPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource>> GetHDInsightPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResourceCollection GetHDInsightPrivateLinkResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Models.HostInfo> GetHostsVirtualMachines(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Models.HostInfo> GetHostsVirtualMachinesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.ClusterMonitoringResponse> GetMonitoringStatusExtension(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.ClusterMonitoringResponse>> GetMonitoringStatusExtensionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetScriptActions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetScriptActionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetScriptExecutionHistories(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Models.RuntimeScriptActionDetail> GetScriptExecutionHistoriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PromoteScriptExecutionHistory(string scriptExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PromoteScriptExecutionHistoryAsync(string scriptExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resize(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.RoleName roleName, Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResizeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.RoleName roleName, Azure.ResourceManager.HDInsight.Models.HDInsightClusterResizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestartHostsVirtualMachine(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartHostsVirtualMachineAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<string> content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RotateDiskEncryptionKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RotateDiskEncryptionKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.HDInsightClusterDiskEncryptionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource> Update(Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.HDInsightClusterResource>> UpdateAsync(Azure.ResourceManager.HDInsight.Models.HDInsightClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateAutoScaleConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.RoleName roleName, Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAutoScaleConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.RoleName roleName, Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfigurationUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateConfiguration(Azure.WaitUntil waitUntil, string configurationName, System.Collections.Generic.IDictionary<string, string> clusterConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateConfigurationAsync(Azure.WaitUntil waitUntil, string configurationName, System.Collections.Generic.IDictionary<string, string> clusterConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateGatewaySettings(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.UpdateGatewaySettingsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateGatewaySettingsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.UpdateGatewaySettingsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateIdentityCertificate(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.UpdateClusterIdentityCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateIdentityCertificateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Models.UpdateClusterIdentityCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HDInsightPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public HDInsightPrivateEndpointConnectionData(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState connectionState) { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public string LinkIdentifier { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.HDInsightPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HDInsightPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public HDInsightPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
}
namespace Azure.ResourceManager.HDInsight.Models
{
    public partial class AzureMonitorContent
    {
        public AzureMonitorContent() { }
        public string PrimaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.AzureMonitorSelectedConfigurations SelectedConfigurations { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    public partial class AzureMonitorResponse
    {
        internal AzureMonitorResponse() { }
        public bool? ClusterMonitoringEnabled { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.AzureMonitorSelectedConfigurations SelectedConfigurations { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
    }
    public partial class AzureMonitorSelectedConfigurations
    {
        public AzureMonitorSelectedConfigurations() { }
        public string ConfigurationVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> GlobalConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.AzureMonitorTableConfiguration> TableList { get { throw null; } }
    }
    public partial class AzureMonitorTableConfiguration
    {
        public AzureMonitorTableConfiguration() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class ClientGroupInfo
    {
        public ClientGroupInfo() { }
        public string GroupId { get { throw null; } set { } }
        public string GroupName { get { throw null; } set { } }
    }
    public partial class ClusterMonitoringContent
    {
        public ClusterMonitoringContent() { }
        public string PrimaryKey { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    public partial class ClusterMonitoringResponse
    {
        internal ClusterMonitoringResponse() { }
        public bool? ClusterMonitoringEnabled { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
    }
    public partial class ComputeIsolationProperties
    {
        public ComputeIsolationProperties() { }
        public bool? EnableComputeIsolation { get { throw null; } set { } }
        public string HostSku { get { throw null; } set { } }
    }
    public partial class ConnectivityEndpoint
    {
        public ConnectivityEndpoint() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DaysOfWeek : System.IEquatable<Azure.ResourceManager.HDInsight.Models.DaysOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DaysOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.DaysOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.DaysOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.DaysOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.DaysOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.DaysOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.DaysOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.DaysOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.DaysOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.DaysOfWeek left, Azure.ResourceManager.HDInsight.Models.DaysOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.DaysOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.DaysOfWeek left, Azure.ResourceManager.HDInsight.Models.DaysOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DirectoryType : System.IEquatable<Azure.ResourceManager.HDInsight.Models.DirectoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DirectoryType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.DirectoryType ActiveDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.DirectoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.DirectoryType left, Azure.ResourceManager.HDInsight.Models.DirectoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.DirectoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.DirectoryType left, Azure.ResourceManager.HDInsight.Models.DirectoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskEncryptionProperties
    {
        public DiskEncryptionProperties() { }
        public Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm? EncryptionAlgorithm { get { throw null; } set { } }
        public bool? EncryptionAtHost { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public string MsiResourceId { get { throw null; } set { } }
        public System.Uri VaultUri { get { throw null; } set { } }
    }
    public partial class Errors
    {
        public Errors() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    public partial class ExcludedServicesConfig
    {
        public ExcludedServicesConfig() { }
        public string ExcludedServicesConfigId { get { throw null; } set { } }
        public string ExcludedServicesList { get { throw null; } set { } }
    }
    public partial class ExecuteScriptActionContent
    {
        public ExecuteScriptActionContent(bool persistOnSuccess) { }
        public bool PersistOnSuccess { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction> ScriptActions { get { throw null; } }
    }
    public partial class Extension
    {
        public Extension() { }
        public string PrimaryKey { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FilterMode : System.IEquatable<Azure.ResourceManager.HDInsight.Models.FilterMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FilterMode(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.FilterMode Default { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.FilterMode Exclude { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.FilterMode Include { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.FilterMode Recommend { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.FilterMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.FilterMode left, Azure.ResourceManager.HDInsight.Models.FilterMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.FilterMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.FilterMode left, Azure.ResourceManager.HDInsight.Models.FilterMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GatewaySettings
    {
        internal GatewaySettings() { }
        public string IsCredentialEnabled { get { throw null; } }
        public string Password { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    public partial class HDInsightApplicationEndpoint
    {
        public HDInsightApplicationEndpoint() { }
        public int? DestinationPort { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public int? PublicPort { get { throw null; } set { } }
    }
    public partial class HDInsightApplicationHttpsEndpoint
    {
        public HDInsightApplicationHttpsEndpoint() { }
        public System.Collections.Generic.IList<string> AccessModes { get { throw null; } }
        public int? DestinationPort { get { throw null; } set { } }
        public bool? DisableGatewayAuth { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public int? PublicPort { get { throw null; } }
        public string SubDomainSuffix { get { throw null; } set { } }
    }
    public partial class HDInsightApplicationProperties
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
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.PrivateLinkConfiguration> PrivateLinkConfigurations { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightApplicationEndpoint> SshEndpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction> UninstallScriptActions { get { throw null; } }
    }
    public partial class HDInsightAsyncOperationResult
    {
        internal HDInsightAsyncOperationResult() { }
        public Azure.ResourceManager.HDInsight.Models.Errors Error { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAsyncOperationState? Status { get { throw null; } }
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
    public partial class HDInsightAutoScaleCapacity
    {
        public HDInsightAutoScaleCapacity() { }
        public int? MaxInstanceCount { get { throw null; } set { } }
        public int? MinInstanceCount { get { throw null; } set { } }
    }
    public partial class HDInsightAutoScaleConfiguration
    {
        public HDInsightAutoScaleConfiguration() { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleCapacity Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleRecurrence Recurrence { get { throw null; } set { } }
    }
    public partial class HDInsightAutoScaleConfigurationUpdateContent
    {
        public HDInsightAutoScaleConfigurationUpdateContent() { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration AutoScale { get { throw null; } set { } }
    }
    public partial class HDInsightAutoScaleRecurrence
    {
        public HDInsightAutoScaleRecurrence() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleSchedule> Schedule { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class HDInsightAutoScaleSchedule
    {
        public HDInsightAutoScaleSchedule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.DaysOfWeek> Days { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleTimeAndCapacity TimeAndCapacity { get { throw null; } set { } }
    }
    public partial class HDInsightAutoScaleTimeAndCapacity
    {
        public HDInsightAutoScaleTimeAndCapacity() { }
        public int? MaxInstanceCount { get { throw null; } set { } }
        public int? MinInstanceCount { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
    }
    public partial class HDInsightBillingMeters
    {
        internal HDInsightBillingMeters() { }
        public string Meter { get { throw null; } }
        public string MeterParameter { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class HDInsightBillingResources
    {
        internal HDInsightBillingResources() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightBillingMeters> BillingMeters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightDiskBillingMeters> DiskBillingMeters { get { throw null; } }
        public string Region { get { throw null; } }
    }
    public partial class HDInsightBillingSpecsListResult
    {
        internal HDInsightBillingSpecsListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources> BillingResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.VmSizeCompatibilityFilterV2> VmSizeFilters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.VmSizeProperty> VmSizeProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VmSizes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VmSizesWithEncryptionAtHost { get { throw null; } }
    }
    public partial class HDInsightCapabilitiesResult
    {
        internal HDInsightCapabilitiesResult() { }
        public System.Collections.Generic.IReadOnlyList<string> Features { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.QuotaCapability Quota { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Models.RegionsCapability> Regions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Models.VersionsCapability> Versions { get { throw null; } }
    }
    public partial class HDInsightClusterAaddsDetail
    {
        internal HDInsightClusterAaddsDetail() { }
        public string DomainName { get { throw null; } }
        public bool? IsInitialSyncComplete { get { throw null; } }
        public bool? IsLdapsEnabled { get { throw null; } }
        public string LdapsPublicCertificateInBase64 { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string SubnetId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
    }
    public partial class HDInsightClusterConfigurations
    {
        internal HDInsightClusterConfigurations() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IDictionary<string, string>> Configurations { get { throw null; } }
    }
    public partial class HDInsightClusterCreateOrUpdateContent
    {
        public HDInsightClusterCreateOrUpdateContent() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class HDInsightClusterCreateOrUpdateProperties
    {
        public HDInsightClusterCreateOrUpdateProperties() { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition ClusterDefinition { get { throw null; } set { } }
        public string ClusterVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.ComputeIsolationProperties ComputeIsolationProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole> ComputeRoles { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.DiskEncryptionProperties DiskEncryptionProperties { get { throw null; } set { } }
        public bool? IsEncryptionInTransitEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.KafkaRestProperties KafkaRestProperties { get { throw null; } set { } }
        public string MinSupportedTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.NetworkProperties NetworkProperties { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.OSType? OSType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.PrivateLinkConfiguration> PrivateLinkConfigurations { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.StorageAccount> StorageStorageaccounts { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightTier? Tier { get { throw null; } set { } }
    }
    public partial class HDInsightClusterCreationValidateContent : Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreateOrUpdateContent
    {
        public HDInsightClusterCreationValidateContent() { }
        public string ClusterCreateRequestValidationParametersType { get { throw null; } set { } }
        public bool? FetchAaddsResource { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class HDInsightClusterCreationValidateResult
    {
        internal HDInsightClusterCreationValidateResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterAaddsDetail> AaddsResourcesDetails { get { throw null; } }
        public System.TimeSpan? EstimatedCreationDuration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo> ValidationErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterValidationErrorInfo> ValidationWarnings { get { throw null; } }
    }
    public partial class HDInsightClusterDataDisksGroup
    {
        public HDInsightClusterDataDisksGroup() { }
        public int? DiskSizeGB { get { throw null; } }
        public int? DisksPerNode { get { throw null; } set { } }
        public string StorageAccountType { get { throw null; } }
    }
    public partial class HDInsightClusterDefinition
    {
        public HDInsightClusterDefinition() { }
        public string Blueprint { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ComponentVersion { get { throw null; } }
        public System.BinaryData Configurations { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
    }
    public partial class HDInsightClusterDiskEncryptionContent
    {
        public HDInsightClusterDiskEncryptionContent() { }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public System.Uri VaultUri { get { throw null; } set { } }
    }
    public partial class HDInsightClusterPatch
    {
        public HDInsightClusterPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class HDInsightClusterProperties
    {
        public HDInsightClusterProperties(Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition clusterDefinition) { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterDefinition ClusterDefinition { get { throw null; } set { } }
        public string ClusterHdpVersion { get { throw null; } set { } }
        public string ClusterId { get { throw null; } set { } }
        public string ClusterState { get { throw null; } set { } }
        public string ClusterVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.ComputeIsolationProperties ComputeIsolationProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterRole> ComputeRoles { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.ConnectivityEndpoint> ConnectivityEndpoints { get { throw null; } }
        public string CreatedDate { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.DiskEncryptionProperties DiskEncryptionProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.Errors> Errors { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.ExcludedServicesConfig ExcludedServicesConfig { get { throw null; } set { } }
        public bool? IsEncryptionInTransitEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.KafkaRestProperties KafkaRestProperties { get { throw null; } set { } }
        public string MinSupportedTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.NetworkProperties NetworkProperties { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.OSType? OSType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.HDInsightPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.PrivateLinkConfiguration> PrivateLinkConfigurations { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightClusterProvisioningState? ProvisioningState { get { throw null; } set { } }
        public int? QuotaInfoCoresUsed { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.StorageAccount> StorageStorageaccounts { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightTier? Tier { get { throw null; } set { } }
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
    public partial class HDInsightClusterResizeContent
    {
        public HDInsightClusterResizeContent() { }
        public int? TargetInstanceCount { get { throw null; } set { } }
    }
    public partial class HDInsightClusterRole
    {
        public HDInsightClusterRole() { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleConfiguration AutoScaleConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDisksGroup> DataDisksGroups { get { throw null; } }
        public bool? EncryptDataDisks { get { throw null; } set { } }
        public string HardwareVmSize { get { throw null; } set { } }
        public int? MinInstanceCount { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.LinuxOperatingSystemProfile OSLinuxOperatingSystemProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.ScriptAction> ScriptActions { get { throw null; } }
        public int? TargetInstanceCount { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.VirtualNetworkProfile VirtualNetworkProfile { get { throw null; } set { } }
        public string VmGroupName { get { throw null; } set { } }
    }
    public partial class HDInsightClusterValidationErrorInfo
    {
        internal HDInsightClusterValidationErrorInfo() { }
        public string Code { get { throw null; } }
        public string ErrorResource { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> MessageArguments { get { throw null; } }
    }
    public partial class HDInsightDiskBillingMeters
    {
        internal HDInsightDiskBillingMeters() { }
        public string DiskRpMeter { get { throw null; } }
        public string Sku { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightTier? Tier { get { throw null; } }
    }
    public partial class HDInsightNameAvailabilityContent
    {
        public HDInsightNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class HDInsightNameAvailabilityResult
    {
        internal HDInsightNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
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
    public partial class HDInsightPrivateLinkServiceConnectionState
    {
        public HDInsightPrivateLinkServiceConnectionState(Azure.ResourceManager.HDInsight.Models.PrivateLinkServiceConnectionStatus status) { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.PrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
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
    public partial class HDInsightUsage
    {
        internal HDInsightUsage() { }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.LocalizedName Name { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class HostInfo
    {
        internal HostInfo() { }
        public System.Uri EffectiveDiskEncryptionKeyUri { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class IPConfiguration
    {
        public IPConfiguration(string name) { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.PrivateIPAllocationMethod? PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.PrivateLinkConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
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
    public partial class KafkaRestProperties
    {
        public KafkaRestProperties() { }
        public Azure.ResourceManager.HDInsight.Models.ClientGroupInfo ClientGroupInfo { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationOverride { get { throw null; } }
    }
    public partial class LinuxOperatingSystemProfile
    {
        public LinuxOperatingSystemProfile() { }
        public string Password { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.SshPublicKey> SshPublicKeys { get { throw null; } }
        public string Username { get { throw null; } set { } }
    }
    public partial class LocalizedName
    {
        internal LocalizedName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class NetworkProperties
    {
        public NetworkProperties() { }
        public Azure.ResourceManager.HDInsight.Models.PrivateLink? PrivateLink { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.ResourceProviderConnection? ResourceProviderConnection { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSType : System.IEquatable<Azure.ResourceManager.HDInsight.Models.OSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.OSType Linux { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.OSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.OSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.OSType left, Azure.ResourceManager.HDInsight.Models.OSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.OSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.OSType left, Azure.ResourceManager.HDInsight.Models.OSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateIPAllocationMethod : System.IEquatable<Azure.ResourceManager.HDInsight.Models.PrivateIPAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateIPAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.PrivateIPAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.PrivateIPAllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.PrivateIPAllocationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.PrivateIPAllocationMethod left, Azure.ResourceManager.HDInsight.Models.PrivateIPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.PrivateIPAllocationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.PrivateIPAllocationMethod left, Azure.ResourceManager.HDInsight.Models.PrivateIPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLink : System.IEquatable<Azure.ResourceManager.HDInsight.Models.PrivateLink>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLink(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.PrivateLink Disabled { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.PrivateLink Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.PrivateLink other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.PrivateLink left, Azure.ResourceManager.HDInsight.Models.PrivateLink right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.PrivateLink (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.PrivateLink left, Azure.ResourceManager.HDInsight.Models.PrivateLink right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkConfiguration
    {
        public PrivateLinkConfiguration(string name, string groupId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.IPConfiguration> ipConfigurations) { }
        public string GroupId { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.IPConfiguration> IPConfigurations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.PrivateLinkConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.HDInsight.Models.PrivateLinkConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.PrivateLinkConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.PrivateLinkConfigurationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.PrivateLinkConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.PrivateLinkConfigurationProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.PrivateLinkConfigurationProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.PrivateLinkConfigurationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.PrivateLinkConfigurationProvisioningState left, Azure.ResourceManager.HDInsight.Models.PrivateLinkConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.PrivateLinkConfigurationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.PrivateLinkConfigurationProvisioningState left, Azure.ResourceManager.HDInsight.Models.PrivateLinkConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.HDInsight.Models.PrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.PrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.PrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.PrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.PrivateLinkServiceConnectionStatus Removed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.PrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.HDInsight.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.PrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.HDInsight.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaCapability
    {
        internal QuotaCapability() { }
        public long? CoresUsed { get { throw null; } }
        public long? MaxCoresAllowed { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.RegionalQuotaCapability> RegionalQuotas { get { throw null; } }
    }
    public partial class RegionalQuotaCapability
    {
        internal RegionalQuotaCapability() { }
        public long? CoresAvailable { get { throw null; } }
        public long? CoresUsed { get { throw null; } }
        public string RegionName { get { throw null; } }
    }
    public partial class RegionsCapability
    {
        internal RegionsCapability() { }
        public System.Collections.Generic.IReadOnlyList<string> Available { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProviderConnection : System.IEquatable<Azure.ResourceManager.HDInsight.Models.ResourceProviderConnection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProviderConnection(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.ResourceProviderConnection Inbound { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Models.ResourceProviderConnection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.ResourceProviderConnection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.ResourceProviderConnection left, Azure.ResourceManager.HDInsight.Models.ResourceProviderConnection right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.ResourceProviderConnection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.ResourceProviderConnection left, Azure.ResourceManager.HDInsight.Models.ResourceProviderConnection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleName : System.IEquatable<Azure.ResourceManager.HDInsight.Models.RoleName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleName(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Models.RoleName Workernode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Models.RoleName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Models.RoleName left, Azure.ResourceManager.HDInsight.Models.RoleName right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Models.RoleName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Models.RoleName left, Azure.ResourceManager.HDInsight.Models.RoleName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RuntimeScriptAction
    {
        public RuntimeScriptAction(string name, System.Uri uri, System.Collections.Generic.IEnumerable<string> roles) { }
        public string ApplicationName { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class RuntimeScriptActionDetail : Azure.ResourceManager.HDInsight.Models.RuntimeScriptAction
    {
        public RuntimeScriptActionDetail(string name, System.Uri uri, System.Collections.Generic.IEnumerable<string> roles) : base (default(string), default(System.Uri), default(System.Collections.Generic.IEnumerable<string>)) { }
        public string DebugInformation { get { throw null; } }
        public string EndTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary> ExecutionSummary { get { throw null; } }
        public string Operation { get { throw null; } }
        public long? ScriptExecutionId { get { throw null; } }
        public string StartTime { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ScriptAction
    {
        public ScriptAction(string name, System.Uri uri, string parameters) { }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ScriptActionExecutionSummary
    {
        internal ScriptActionExecutionSummary() { }
        public int? InstanceCount { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class SecurityProfile
    {
        public SecurityProfile() { }
        public string AaddsResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ClusterUsersGroupDNs { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.DirectoryType? DirectoryType { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string DomainUsername { get { throw null; } set { } }
        public string DomainUserPassword { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LdapsUrls { get { throw null; } }
        public string MsiResourceId { get { throw null; } set { } }
        public string OrganizationalUnitDN { get { throw null; } set { } }
    }
    public partial class SshPublicKey
    {
        public SshPublicKey() { }
        public string CertificateData { get { throw null; } set { } }
    }
    public partial class StorageAccount
    {
        public StorageAccount() { }
        public string Container { get { throw null; } set { } }
        public string Fileshare { get { throw null; } set { } }
        public string FileSystem { get { throw null; } set { } }
        public bool? IsDefault { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public string MsiResourceId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string SasKey { get { throw null; } set { } }
    }
    public partial class UpdateClusterIdentityCertificateContent
    {
        public UpdateClusterIdentityCertificateContent() { }
        public string ApplicationId { get { throw null; } set { } }
        public string Certificate { get { throw null; } set { } }
        public string CertificatePassword { get { throw null; } set { } }
    }
    public partial class UpdateGatewaySettingsContent
    {
        public UpdateGatewaySettingsContent() { }
        public bool? IsCredentialEnabled { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class VersionsCapability
    {
        internal VersionsCapability() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.VersionSpec> Available { get { throw null; } }
    }
    public partial class VersionSpec
    {
        internal VersionSpec() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ComponentVersions { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public bool? IsDefault { get { throw null; } }
    }
    public partial class VirtualNetworkProfile
    {
        public VirtualNetworkProfile() { }
        public string Id { get { throw null; } set { } }
        public string Subnet { get { throw null; } set { } }
    }
    public partial class VmSizeCompatibilityFilterV2
    {
        internal VmSizeCompatibilityFilterV2() { }
        public System.Collections.Generic.IReadOnlyList<string> ClusterFlavors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ClusterVersions { get { throw null; } }
        public string ComputeIsolationSupported { get { throw null; } }
        public string EspApplied { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.FilterMode? FilterMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NodeTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.OSType> OSType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Regions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VmSizes { get { throw null; } }
    }
    public partial class VmSizeProperty
    {
        internal VmSizeProperty() { }
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
    }
}
