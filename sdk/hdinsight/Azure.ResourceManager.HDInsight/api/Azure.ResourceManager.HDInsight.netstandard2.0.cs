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
namespace Azure.ResourceManager.HDInsight.Mock
{
    public partial class HDInsightClusterResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected HDInsightClusterResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetHDInsightClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.HDInsightClusterResource> GetHDInsightClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.HDInsight.HDInsightClusterCollection GetHDInsightClusters() { throw null; }
    }
    public partial class SubscriptionResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SubscriptionResourceExtensionClient() { }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult> CheckHDInsightNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityResult>> CheckHDInsightNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult> GetHDInsightBillingSpecs(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightBillingSpecsListResult>> GetHDInsightBillingSpecsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult> GetHDInsightCapabilities(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightCapabilitiesResult>> GetHDInsightCapabilitiesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Models.HDInsightUsage> GetHDInsightUsages(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Models.HDInsightUsage> GetHDInsightUsagesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult> ValidateHDInsightClusterCreation(Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateResult>> ValidateHDInsightClusterCreationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Models.HDInsightClusterCreationValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HDInsight.Models
{
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
    public partial class ClientGroupInfo
    {
        public ClientGroupInfo() { }
        public string GroupId { get { throw null; } set { } }
        public string GroupName { get { throw null; } set { } }
    }
    public partial class ConnectivityEndpoint
    {
        public ConnectivityEndpoint() { }
        public string EndpointLocation { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
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
    public partial class HDInsightApplicationEndpoint
    {
        public HDInsightApplicationEndpoint() { }
        public int? DestinationPort { get { throw null; } set { } }
        public string EndpointLocation { get { throw null; } set { } }
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } set { } }
        public int? PublicPort { get { throw null; } set { } }
    }
    public partial class HDInsightApplicationHttpsEndpoint
    {
        public HDInsightApplicationHttpsEndpoint() { }
        public System.Collections.Generic.IList<string> AccessModes { get { throw null; } }
        public int? DestinationPort { get { throw null; } set { } }
        public bool? DisableGatewayAuth { get { throw null; } set { } }
        public string EndpointLocation { get { throw null; } }
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } set { } }
        public int? PublicPort { get { throw null; } }
        public string SubDomainSuffix { get { throw null; } set { } }
    }
    public partial class HDInsightApplicationProperties
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
    }
    public partial class HDInsightAsyncOperationResult
    {
        internal HDInsightAsyncOperationResult() { }
        public Azure.ResponseError Error { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightDayOfWeek> Days { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAutoScaleTimeAndCapacity TimeAndCapacity { get { throw null; } set { } }
    }
    public partial class HDInsightAutoScaleTimeAndCapacity
    {
        public HDInsightAutoScaleTimeAndCapacity() { }
        public int? MaxInstanceCount { get { throw null; } set { } }
        public int? MinInstanceCount { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
    }
    public partial class HDInsightAzureMonitorExtensionEnableContent
    {
        public HDInsightAzureMonitorExtensionEnableContent() { }
        public string PrimaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations SelectedConfigurations { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    public partial class HDInsightAzureMonitorExtensionStatus
    {
        internal HDInsightAzureMonitorExtensionStatus() { }
        public bool? IsClusterMonitoringEnabled { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorSelectedConfigurations SelectedConfigurations { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
    }
    public partial class HDInsightAzureMonitorSelectedConfigurations
    {
        public HDInsightAzureMonitorSelectedConfigurations() { }
        public string ConfigurationVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> GlobalConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightAzureMonitorTableConfiguration> TableList { get { throw null; } }
    }
    public partial class HDInsightAzureMonitorTableConfiguration
    {
        public HDInsightAzureMonitorTableConfiguration() { }
        public string Name { get { throw null; } set { } }
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
        public Azure.Core.AzureLocation? Region { get { throw null; } }
    }
    public partial class HDInsightBillingSpecsListResult
    {
        internal HDInsightBillingSpecsListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightBillingResources> BillingResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeCompatibilityFilterV2> VmSizeFilters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightVmSizeProperty> VmSizeProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VmSizes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VmSizesWithEncryptionAtHost { get { throw null; } }
    }
    public partial class HDInsightCapabilitiesResult
    {
        internal HDInsightCapabilitiesResult() { }
        public System.Collections.Generic.IReadOnlyList<string> Features { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.QuotaCapability Quota { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Models.RegionsCapability> Regions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Models.HDInsightVersionsCapability> Versions { get { throw null; } }
    }
    public partial class HDInsightClusterAaddsDetail
    {
        internal HDInsightClusterAaddsDetail() { }
        public string DomainName { get { throw null; } }
        public bool? IsInitialSyncComplete { get { throw null; } }
        public bool? IsLdapsEnabled { get { throw null; } }
        public string LdapsPublicCertificateInBase64 { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
    }
    public partial class HDInsightClusterConfigurations
    {
        internal HDInsightClusterConfigurations() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IDictionary<string, string>> Configurations { get { throw null; } }
    }
    public partial class HDInsightClusterCreateExtensionContent
    {
        public HDInsightClusterCreateExtensionContent() { }
        public string PrimaryKey { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
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
    public partial class HDInsightClusterDataDiskGroup
    {
        public HDInsightClusterDataDiskGroup() { }
        public int? DiskSizeInGB { get { throw null; } }
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
    public partial class HDInsightClusterEnableClusterMonitoringContent
    {
        public HDInsightClusterEnableClusterMonitoringContent() { }
        public string PrimaryKey { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    public partial class HDInsightClusterExtensionStatus
    {
        internal HDInsightClusterExtensionStatus() { }
        public bool? IsClusterMonitoringEnabled { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
    }
    public partial class HDInsightClusterGatewaySettings
    {
        internal HDInsightClusterGatewaySettings() { }
        public bool? IsCredentialEnabled { get { throw null; } }
        public string Password { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    public partial class HDInsightClusterHostInfo
    {
        internal HDInsightClusterHostInfo() { }
        public System.Uri EffectiveDiskEncryptionKeyUri { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class HDInsightClusterNetworkProperties
    {
        public HDInsightClusterNetworkProperties() { }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkState? PrivateLink { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightResourceProviderConnection? ResourceProviderConnection { get { throw null; } set { } }
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
    }
    public partial class HDInsightClusterUpdateGatewaySettingsContent
    {
        public HDInsightClusterUpdateGatewaySettingsContent() { }
        public bool? IsCredentialEnabled { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class HDInsightClusterUpdateIdentityCertificateContent
    {
        public HDInsightClusterUpdateIdentityCertificateContent() { }
        public string ApplicationId { get { throw null; } set { } }
        public string Certificate { get { throw null; } set { } }
        public string CertificatePassword { get { throw null; } set { } }
    }
    public partial class HDInsightClusterValidationErrorInfo
    {
        internal HDInsightClusterValidationErrorInfo() { }
        public string Code { get { throw null; } }
        public string ErrorResource { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> MessageArguments { get { throw null; } }
    }
    public partial class HDInsightComputeIsolationProperties
    {
        public HDInsightComputeIsolationProperties() { }
        public bool? EnableComputeIsolation { get { throw null; } set { } }
        public string HostSku { get { throw null; } set { } }
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
    public partial class HDInsightDiskBillingMeters
    {
        internal HDInsightDiskBillingMeters() { }
        public string DiskRpMeter { get { throw null; } }
        public string Sku { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightTier? Tier { get { throw null; } }
    }
    public partial class HDInsightDiskEncryptionProperties
    {
        public HDInsightDiskEncryptionProperties() { }
        public Azure.ResourceManager.HDInsight.Models.JsonWebKeyEncryptionAlgorithm? EncryptionAlgorithm { get { throw null; } set { } }
        public bool? IsEncryptionAtHostEnabled { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MsiResourceId { get { throw null; } set { } }
        public System.Uri VaultUri { get { throw null; } set { } }
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
    public partial class HDInsightIPConfiguration
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
    }
    public partial class HDInsightLinuxOSProfile
    {
        public HDInsightLinuxOSProfile() { }
        public string Password { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightSshPublicKey> SshPublicKeys { get { throw null; } }
        public string Username { get { throw null; } set { } }
    }
    public partial class HDInsightLocalizedName
    {
        internal HDInsightLocalizedName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class HDInsightNameAvailabilityContent
    {
        public HDInsightNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class HDInsightNameAvailabilityResult
    {
        internal HDInsightNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
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
    public partial class HDInsightPrivateLinkConfiguration
    {
        public HDInsightPrivateLinkConfiguration(string name, string groupId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration> ipConfigurations) { }
        public string GroupId { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Models.HDInsightIPConfiguration> IPConfigurations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
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
    public partial class HDInsightPrivateLinkServiceConnectionState
    {
        public HDInsightPrivateLinkServiceConnectionState(Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus status) { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Models.HDInsightPrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
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
    public partial class HDInsightSecurityProfile
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
    }
    public partial class HDInsightSshPublicKey
    {
        public HDInsightSshPublicKey() { }
        public string CertificateData { get { throw null; } set { } }
    }
    public partial class HDInsightStorageAccountInfo
    {
        public HDInsightStorageAccountInfo() { }
        public string Container { get { throw null; } set { } }
        public string Fileshare { get { throw null; } set { } }
        public string FileSystem { get { throw null; } set { } }
        public bool? IsDefault { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MsiResourceId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public string SasKey { get { throw null; } set { } }
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
        public Azure.ResourceManager.HDInsight.Models.HDInsightLocalizedName Name { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class HDInsightVersionsCapability
    {
        internal HDInsightVersionsCapability() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.HDInsightVersionSpec> Available { get { throw null; } }
    }
    public partial class HDInsightVersionSpec
    {
        internal HDInsightVersionSpec() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ComponentVersions { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public bool? IsDefault { get { throw null; } }
    }
    public partial class HDInsightVirtualNetworkProfile
    {
        public HDInsightVirtualNetworkProfile() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Subnet { get { throw null; } set { } }
    }
    public partial class HDInsightVmSizeCompatibilityFilterV2
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
    }
    public partial class HDInsightVmSizeProperty
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
        public Azure.Core.AzureLocation? Region { get { throw null; } }
    }
    public partial class RegionsCapability
    {
        internal RegionsCapability() { }
        public System.Collections.Generic.IReadOnlyList<string> Available { get { throw null; } }
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
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Models.ScriptActionExecutionSummary> ExecutionSummary { get { throw null; } }
        public string Operation { get { throw null; } }
        public long? ScriptExecutionId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
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
}
