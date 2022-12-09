namespace Azure.ResourceManager.DataFactory
{
    public partial class DataFactoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryResource>, System.Collections.IEnumerable
    {
        protected DataFactoryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string factoryName, Azure.ResourceManager.DataFactory.DataFactoryData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.DataFactoryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string factoryName, Azure.ResourceManager.DataFactory.DataFactoryData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> Get(string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> GetAsync(string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.DataFactoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.DataFactoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.DataFactoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.DataFactoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataFactoryData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DataFactoryData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryEncryptionConfiguration Encryption { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterSpecification> GlobalParameters { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PurviewResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryRepoConfiguration RepoConfiguration { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public static partial class DataFactoryExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> ConfigureFactoryRepoInformation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationId, Azure.ResourceManager.DataFactory.Models.FactoryRepoUpdate factoryRepoUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> ConfigureFactoryRepoInformationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationId, Azure.ResourceManager.DataFactory.Models.FactoryRepoUpdate factoryRepoUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryCollection GetDataFactories(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataFactory.DataFactoryResource> GetDataFactories(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataFactory.DataFactoryResource> GetDataFactoriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> GetDataFactory(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> GetDataFactoryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string factoryName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataFactory.DataFactoryResource GetDataFactoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.FactoryDataFlowResource GetFactoryDataFlowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.FactoryDatasetResource GetFactoryDatasetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource GetFactoryGlobalParameterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource GetFactoryIntegrationRuntimeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource GetFactoryLinkedServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.FactoryPipelineResource GetFactoryPipelineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource GetFactoryPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource GetFactoryPrivateEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.FactoryTriggerResource GetFactoryTriggerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource GetFactoryVirtualNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlResult> GetFeatureValueExposureControl(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationId, Azure.ResourceManager.DataFactory.Models.ExposureControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlResult>> GetFeatureValueExposureControlAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationId, Azure.ResourceManager.DataFactory.Models.ExposureControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFactoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataFactoryResource() { }
        public virtual Azure.ResourceManager.DataFactory.DataFactoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.FactoryDataFlowStartDebugSessionResult> AddDataFlowToDebugSession(Azure.ResourceManager.DataFactory.Models.FactoryDataFlowDebugPackageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.FactoryDataFlowStartDebugSessionResult>> AddDataFlowToDebugSessionAsync(Azure.ResourceManager.DataFactory.Models.FactoryDataFlowDebugPackageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelPipelineRun(string runId, bool? isRecursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelPipelineRunAsync(string runId, bool? isRecursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.FactoryDataFlowCreateDebugSessionResult> CreateDataFlowDebugSession(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.FactoryDataFlowDebugSessionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.FactoryDataFlowCreateDebugSessionResult>> CreateDataFlowDebugSessionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.FactoryDataFlowDebugSessionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDataFlowDebugSession(Azure.ResourceManager.DataFactory.Models.DeleteDataFlowDebugSessionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDataFlowDebugSessionAsync(Azure.ResourceManager.DataFactory.Models.DeleteDataFlowDebugSessionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.FactoryDataFlowDebugCommandResult> ExecuteDataFlowDebugSessionCommand(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.FactoryDataFlowDebugCommandResult>> ExecuteDataFlowDebugSessionCommandAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.ActivityRunInfo> GetActivityRun(string runId, Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.ActivityRunInfo> GetActivityRunAsync(string runId, Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.DataFlowDebugSessionInfo> GetDataFlowDebugSessions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.DataFlowDebugSessionInfo> GetDataFlowDebugSessionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.FactoryDataPlaneAccessPolicyResult> GetDataPlaneAccess(Azure.ResourceManager.DataFactory.Models.FactoryDataPlaneUserAccessPolicy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.FactoryDataPlaneAccessPolicyResult>> GetDataPlaneAccessAsync(Azure.ResourceManager.DataFactory.Models.FactoryDataPlaneUserAccessPolicy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlResult> GetExposureControlFeature(Azure.ResourceManager.DataFactory.Models.ExposureControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlResult>> GetExposureControlFeatureAsync(Azure.ResourceManager.DataFactory.Models.ExposureControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlBatchResult> GetExposureControlFeatures(Azure.ResourceManager.DataFactory.Models.ExposureControlBatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.ExposureControlBatchResult>> GetExposureControlFeaturesAsync(Azure.ResourceManager.DataFactory.Models.ExposureControlBatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryDataFlowResource> GetFactoryDataFlow(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryDataFlowResource>> GetFactoryDataFlowAsync(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.FactoryDataFlowCollection GetFactoryDataFlows() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryDatasetResource> GetFactoryDataset(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryDatasetResource>> GetFactoryDatasetAsync(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.FactoryDatasetCollection GetFactoryDatasets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource> GetFactoryGlobalParameter(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource>> GetFactoryGlobalParameterAsync(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.FactoryGlobalParameterCollection GetFactoryGlobalParameters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource> GetFactoryIntegrationRuntime(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource>> GetFactoryIntegrationRuntimeAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeCollection GetFactoryIntegrationRuntimes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource> GetFactoryLinkedService(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource>> GetFactoryLinkedServiceAsync(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.FactoryLinkedServiceCollection GetFactoryLinkedServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryPipelineResource> GetFactoryPipeline(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryPipelineResource>> GetFactoryPipelineAsync(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.FactoryPipelineCollection GetFactoryPipelines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource> GetFactoryPrivateEndpointConnection(string privateEndpointConnectionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource>> GetFactoryPrivateEndpointConnectionAsync(string privateEndpointConnectionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionCollection GetFactoryPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryTriggerResource> GetFactoryTrigger(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryTriggerResource>> GetFactoryTriggerAsync(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.FactoryTriggerCollection GetFactoryTriggers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource> GetFactoryVirtualNetwork(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource>> GetFactoryVirtualNetworkAsync(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.FactoryVirtualNetworkCollection GetFactoryVirtualNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.GitHubAccessTokenResult> GetGitHubAccessToken(Azure.ResourceManager.DataFactory.Models.GitHubAccessTokenContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.GitHubAccessTokenResult>> GetGitHubAccessTokenAsync(Azure.ResourceManager.DataFactory.Models.GitHubAccessTokenContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.FactoryPipelineRunInfo> GetPipelineRun(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.FactoryPipelineRunInfo>> GetPipelineRunAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.FactoryPipelineRunInfo> GetPipelineRuns(Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.FactoryPipelineRunInfo> GetPipelineRunsAsync(Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.FactoryPrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.FactoryPrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.FactoryTriggerRun> GetTriggerRuns(Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.FactoryTriggerRun> GetTriggerRunsAsync(Azure.ResourceManager.DataFactory.Models.RunFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.FactoryTriggerResource> GetTriggers(Azure.ResourceManager.DataFactory.Models.TriggerFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.FactoryTriggerResource> GetTriggersAsync(Azure.ResourceManager.DataFactory.Models.TriggerFilterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource> Update(Azure.ResourceManager.DataFactory.Models.DataFactoryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.DataFactoryResource>> UpdateAsync(Azure.ResourceManager.DataFactory.Models.DataFactoryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FactoryDataFlowCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryDataFlowResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryDataFlowResource>, System.Collections.IEnumerable
    {
        protected FactoryDataFlowCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryDataFlowResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataFlowName, Azure.ResourceManager.DataFactory.FactoryDataFlowData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryDataFlowResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataFlowName, Azure.ResourceManager.DataFactory.FactoryDataFlowData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryDataFlowResource> Get(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.FactoryDataFlowResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.FactoryDataFlowResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryDataFlowResource>> GetAsync(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.FactoryDataFlowResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryDataFlowResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.FactoryDataFlowResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryDataFlowResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FactoryDataFlowData : Azure.ResourceManager.Models.ResourceData
    {
        public FactoryDataFlowData(Azure.ResourceManager.DataFactory.Models.FactoryDataFlowDefinition properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryDataFlowDefinition Properties { get { throw null; } set { } }
    }
    public partial class FactoryDataFlowResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FactoryDataFlowResource() { }
        public virtual Azure.ResourceManager.DataFactory.FactoryDataFlowData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string dataFlowName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryDataFlowResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryDataFlowResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryDataFlowResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryDataFlowData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryDataFlowResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryDataFlowData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FactoryDatasetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryDatasetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryDatasetResource>, System.Collections.IEnumerable
    {
        protected FactoryDatasetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryDatasetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string datasetName, Azure.ResourceManager.DataFactory.FactoryDatasetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryDatasetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string datasetName, Azure.ResourceManager.DataFactory.FactoryDatasetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryDatasetResource> Get(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.FactoryDatasetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.FactoryDatasetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryDatasetResource>> GetAsync(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.FactoryDatasetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryDatasetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.FactoryDatasetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryDatasetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FactoryDatasetData : Azure.ResourceManager.Models.ResourceData
    {
        public FactoryDatasetData(Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition Properties { get { throw null; } set { } }
    }
    public partial class FactoryDatasetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FactoryDatasetResource() { }
        public virtual Azure.ResourceManager.DataFactory.FactoryDatasetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string datasetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryDatasetResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryDatasetResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryDatasetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryDatasetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryDatasetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryDatasetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FactoryGlobalParameterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource>, System.Collections.IEnumerable
    {
        protected FactoryGlobalParameterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string globalParameterName, Azure.ResourceManager.DataFactory.FactoryGlobalParameterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string globalParameterName, Azure.ResourceManager.DataFactory.FactoryGlobalParameterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource> Get(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource>> GetAsync(string globalParameterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FactoryGlobalParameterData : Azure.ResourceManager.Models.ResourceData
    {
        public FactoryGlobalParameterData(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterSpecification> properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterSpecification> Properties { get { throw null; } }
    }
    public partial class FactoryGlobalParameterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FactoryGlobalParameterResource() { }
        public virtual Azure.ResourceManager.DataFactory.FactoryGlobalParameterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string globalParameterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryGlobalParameterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryGlobalParameterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryGlobalParameterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FactoryIntegrationRuntimeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource>, System.Collections.IEnumerable
    {
        protected FactoryIntegrationRuntimeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string integrationRuntimeName, Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string integrationRuntimeName, Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource> Get(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource>> GetAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FactoryIntegrationRuntimeData : Azure.ResourceManager.Models.ResourceData
    {
        public FactoryIntegrationRuntimeData(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeDefinition properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeDefinition Properties { get { throw null; } set { } }
    }
    public partial class FactoryIntegrationRuntimeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FactoryIntegrationRuntimeResource() { }
        public virtual Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatusResult> CreateLinkedIntegrationRuntime(Azure.ResourceManager.DataFactory.Models.CreateLinkedIntegrationRuntimeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatusResult>> CreateLinkedIntegrationRuntimeAsync(Azure.ResourceManager.DataFactory.Models.CreateLinkedIntegrationRuntimeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string integrationRuntimeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteIntegrationRuntimeNode(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteIntegrationRuntimeNodeAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata> GetAllIntegrationRuntimeObjectMetadata(Azure.ResourceManager.DataFactory.Models.GetSsisObjectMetadataContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata> GetAllIntegrationRuntimeObjectMetadataAsync(Azure.ResourceManager.DataFactory.Models.GetSsisObjectMetadataContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeys> GetAuthKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeys>> GetAuthKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeConnectionInfo> GetConnectionInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeConnectionInfo>> GetConnectionInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNode> GetIntegrationRuntimeNode(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNode>> GetIntegrationRuntimeNodeAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeNodeIPAddress> GetIPAddressIntegrationRuntimeNode(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeNodeIPAddress>> GetIPAddressIntegrationRuntimeNodeAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeMonitoringData> GetMonitoringData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeMonitoringData>> GetMonitoringDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint> GetOutboundNetworkDependencies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint> GetOutboundNetworkDependenciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatusResult> GetStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatusResult>> GetStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.SsisObjectMetadataStatusResult> RefreshIntegrationRuntimeObjectMetadata(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.SsisObjectMetadataStatusResult>> RefreshIntegrationRuntimeObjectMetadataAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeys> RegenerateAuthKey(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeys>> RegenerateAuthKeyAsync(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveLinks(Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntimeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveLinksAsync(Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntimeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatusResult> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatusResult>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SyncCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource> Update(Azure.ResourceManager.DataFactory.Models.FactoryIntegrationRuntimePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryIntegrationRuntimeResource>> UpdateAsync(Azure.ResourceManager.DataFactory.Models.FactoryIntegrationRuntimePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNode> UpdateIntegrationRuntimeNode(string nodeName, Azure.ResourceManager.DataFactory.Models.UpdateIntegrationRuntimeNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNode>> UpdateIntegrationRuntimeNodeAsync(string nodeName, Azure.ResourceManager.DataFactory.Models.UpdateIntegrationRuntimeNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Upgrade(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpgradeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FactoryLinkedServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource>, System.Collections.IEnumerable
    {
        protected FactoryLinkedServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string linkedServiceName, Azure.ResourceManager.DataFactory.FactoryLinkedServiceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string linkedServiceName, Azure.ResourceManager.DataFactory.FactoryLinkedServiceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource> Get(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource>> GetAsync(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FactoryLinkedServiceData : Azure.ResourceManager.Models.ResourceData
    {
        public FactoryLinkedServiceData(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition Properties { get { throw null; } set { } }
    }
    public partial class FactoryLinkedServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FactoryLinkedServiceResource() { }
        public virtual Azure.ResourceManager.DataFactory.FactoryLinkedServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string linkedServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryLinkedServiceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryLinkedServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryLinkedServiceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FactoryPipelineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryPipelineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryPipelineResource>, System.Collections.IEnumerable
    {
        protected FactoryPipelineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryPipelineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string pipelineName, Azure.ResourceManager.DataFactory.FactoryPipelineData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryPipelineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string pipelineName, Azure.ResourceManager.DataFactory.FactoryPipelineData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryPipelineResource> Get(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.FactoryPipelineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.FactoryPipelineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryPipelineResource>> GetAsync(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.FactoryPipelineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryPipelineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.FactoryPipelineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryPipelineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FactoryPipelineData : Azure.ResourceManager.Models.ResourceData
    {
        public FactoryPipelineData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivity> Activities { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public int? Concurrency { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.TimeSpan? ElapsedTimeMetricDuration { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string FolderName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.EntityParameterSpecification> Parameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> RunDimensions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.PipelineVariableSpecification> Variables { get { throw null; } }
    }
    public partial class FactoryPipelineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FactoryPipelineResource() { }
        public virtual Azure.ResourceManager.DataFactory.FactoryPipelineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string pipelineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.PipelineCreateRunResult> CreateRun(System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValueSpecification = null, string referencePipelineRunId = null, bool? isRecovery = default(bool?), string startActivityName = null, bool? startFromFailure = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.PipelineCreateRunResult>> CreateRunAsync(System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValueSpecification = null, string referencePipelineRunId = null, bool? isRecovery = default(bool?), string startActivityName = null, bool? startFromFailure = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryPipelineResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryPipelineResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryPipelineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryPipelineData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryPipelineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryPipelineData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FactoryPrivateEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource>, System.Collections.IEnumerable
    {
        protected FactoryPrivateEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedPrivateEndpointName, Azure.ResourceManager.DataFactory.FactoryPrivateEndpointData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedPrivateEndpointName, Azure.ResourceManager.DataFactory.FactoryPrivateEndpointData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource> Get(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource>> GetAsync(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FactoryPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected FactoryPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DataFactory.Models.FactoryPrivateEndpointConnectionCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DataFactory.Models.FactoryPrivateEndpointConnectionCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FactoryPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public FactoryPrivateEndpointConnectionData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryPrivateEndpointProperties Properties { get { throw null; } set { } }
    }
    public partial class FactoryPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FactoryPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.FactoryPrivateEndpointConnectionCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.Models.FactoryPrivateEndpointConnectionCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FactoryPrivateEndpointData : Azure.ResourceManager.Models.ResourceData
    {
        public FactoryPrivateEndpointData(Azure.ResourceManager.DataFactory.Models.ManagedPrivateEndpoint properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.ManagedPrivateEndpoint Properties { get { throw null; } set { } }
    }
    public partial class FactoryPrivateEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FactoryPrivateEndpointResource() { }
        public virtual Azure.ResourceManager.DataFactory.FactoryPrivateEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string managedVirtualNetworkName, string managedPrivateEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryPrivateEndpointData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryPrivateEndpointData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FactoryTriggerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryTriggerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryTriggerResource>, System.Collections.IEnumerable
    {
        protected FactoryTriggerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryTriggerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string triggerName, Azure.ResourceManager.DataFactory.FactoryTriggerData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryTriggerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string triggerName, Azure.ResourceManager.DataFactory.FactoryTriggerData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryTriggerResource> Get(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.FactoryTriggerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.FactoryTriggerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryTriggerResource>> GetAsync(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.FactoryTriggerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryTriggerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.FactoryTriggerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryTriggerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FactoryTriggerData : Azure.ResourceManager.Models.ResourceData
    {
        public FactoryTriggerData(Azure.ResourceManager.DataFactory.Models.FactoryTriggerDefinition properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryTriggerDefinition Properties { get { throw null; } set { } }
    }
    public partial class FactoryTriggerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FactoryTriggerResource() { }
        public virtual Azure.ResourceManager.DataFactory.FactoryTriggerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response CancelTriggerRun(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelTriggerRunAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string triggerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryTriggerResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryTriggerResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.Models.FactoryTriggerSubscriptionOperationResult> GetEventSubscriptionStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.Models.FactoryTriggerSubscriptionOperationResult>> GetEventSubscriptionStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RerunTriggerRun(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RerunTriggerRunAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.FactoryTriggerSubscriptionOperationResult> SubscribeToEvents(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.FactoryTriggerSubscriptionOperationResult>> SubscribeToEventsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.FactoryTriggerSubscriptionOperationResult> UnsubscribeFromEvents(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.Models.FactoryTriggerSubscriptionOperationResult>> UnsubscribeFromEventsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryTriggerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryTriggerData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryTriggerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryTriggerData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FactoryVirtualNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource>, System.Collections.IEnumerable
    {
        protected FactoryVirtualNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedVirtualNetworkName, Azure.ResourceManager.DataFactory.FactoryVirtualNetworkData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedVirtualNetworkName, Azure.ResourceManager.DataFactory.FactoryVirtualNetworkData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource> Get(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource>> GetAsync(string managedVirtualNetworkName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FactoryVirtualNetworkData : Azure.ResourceManager.Models.ResourceData
    {
        public FactoryVirtualNetworkData(Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetwork properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetwork Properties { get { throw null; } set { } }
    }
    public partial class FactoryVirtualNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FactoryVirtualNetworkResource() { }
        public virtual Azure.ResourceManager.DataFactory.FactoryVirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string factoryName, string managedVirtualNetworkName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource> GetFactoryPrivateEndpoint(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataFactory.FactoryPrivateEndpointResource>> GetFactoryPrivateEndpointAsync(string managedPrivateEndpointName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataFactory.FactoryPrivateEndpointCollection GetFactoryPrivateEndpoints() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryVirtualNetworkData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataFactory.FactoryVirtualNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataFactory.FactoryVirtualNetworkData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataFactory.Models
{
    public partial class ActivityDependency
    {
        public ActivityDependency(string activity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.DependencyCondition> dependencyConditions) { }
        public string Activity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DependencyCondition> DependencyConditions { get { throw null; } }
    }
    public partial class ActivityPolicy
    {
        public ActivityPolicy() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public bool? EnableSecureInput { get { throw null; } set { } }
        public bool? EnableSecureOutput { get { throw null; } set { } }
        public System.BinaryData Retry { get { throw null; } set { } }
        public int? RetryIntervalInSeconds { get { throw null; } set { } }
        public System.BinaryData Timeout { get { throw null; } set { } }
    }
    public partial class ActivityRunInfo
    {
        internal ActivityRunInfo() { }
        public string ActivityName { get { throw null; } }
        public System.Guid? ActivityRunId { get { throw null; } }
        public System.DateTimeOffset? ActivityRunStart { get { throw null; } }
        public string ActivityType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? DurationInMs { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.BinaryData Error { get { throw null; } }
        public System.BinaryData Input { get { throw null; } }
        public string LinkedServiceName { get { throw null; } }
        public System.BinaryData Output { get { throw null; } }
        public string PipelineName { get { throw null; } }
        public System.Guid? PipelineRunId { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ActivityUserProperty
    {
        public ActivityUserProperty(string name, System.BinaryData value) { }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class AmazonMwsLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AmazonMwsLinkedService(System.BinaryData endpoint, System.BinaryData marketplaceId, System.BinaryData sellerId, System.BinaryData accessKeyId) { }
        public System.BinaryData AccessKeyId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public System.BinaryData MarketplaceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition MwsAuthToken { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition SecretKey { get { throw null; } set { } }
        public System.BinaryData SellerId { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class AmazonMwsObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AmazonMwsObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AmazonMwsSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AmazonMwsSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOracleLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AmazonRdsForOracleLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOraclePartitionSettings
    {
        public AmazonRdsForOraclePartitionSettings() { }
        public System.BinaryData PartitionColumnName { get { throw null; } set { } }
        public System.BinaryData PartitionLowerBound { get { throw null; } set { } }
        public System.BinaryData PartitionNames { get { throw null; } set { } }
        public System.BinaryData PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOracleSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public AmazonRdsForOracleSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData OracleReaderQuery { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AmazonRdsForOraclePartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOracleTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AmazonRdsForOracleTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
    }
    public partial class AmazonRdsForSqlServerLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AmazonRdsForSqlServerLinkedService(System.BinaryData connectionString) { }
        public Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class AmazonRdsForSqlServerSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AmazonRdsForSqlServerSource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData ProduceAdditionalTypes { get { throw null; } set { } }
        public System.BinaryData SqlReaderQuery { get { throw null; } set { } }
        public System.BinaryData SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
    }
    public partial class AmazonRdsForSqlServerTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AmazonRdsForSqlServerTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
    }
    public partial class AmazonRedshiftLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AmazonRedshiftLinkedService(System.BinaryData server, System.BinaryData database) { }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class AmazonRedshiftSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AmazonRedshiftSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.RedshiftUnloadSettings RedshiftUnloadSettings { get { throw null; } set { } }
    }
    public partial class AmazonRedshiftTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AmazonRedshiftTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AmazonS3CompatibleLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AmazonS3CompatibleLinkedService() { }
        public System.BinaryData AccessKeyId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData ForcePathStyle { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition SecretAccessKey { get { throw null; } set { } }
        public System.BinaryData ServiceUri { get { throw null; } set { } }
    }
    public partial class AmazonS3CompatibleLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AmazonS3CompatibleLocation() { }
        public System.BinaryData BucketName { get { throw null; } set { } }
        public System.BinaryData Version { get { throw null; } set { } }
    }
    public partial class AmazonS3CompatibleReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AmazonS3CompatibleReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Prefix { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AmazonS3Dataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AmazonS3Dataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData bucketName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData BucketName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public System.BinaryData Key { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData Prefix { get { throw null; } set { } }
        public System.BinaryData Version { get { throw null; } set { } }
    }
    public partial class AmazonS3LinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AmazonS3LinkedService() { }
        public System.BinaryData AccessKeyId { get { throw null; } set { } }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition SecretAccessKey { get { throw null; } set { } }
        public System.BinaryData ServiceUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition SessionToken { get { throw null; } set { } }
    }
    public partial class AmazonS3Location : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AmazonS3Location() { }
        public System.BinaryData BucketName { get { throw null; } set { } }
        public System.BinaryData Version { get { throw null; } set { } }
    }
    public partial class AmazonS3ReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AmazonS3ReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Prefix { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AppendVariableActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public AppendVariableActivity(string name) : base (default(string)) { }
        public System.BinaryData Value { get { throw null; } set { } }
        public string VariableName { get { throw null; } set { } }
    }
    public partial class AppFiguresLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AppFiguresLinkedService(System.BinaryData userName, Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition password, Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition clientKey) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ClientKey { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class AsanaLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AsanaLinkedService(Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition apiToken) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ApiToken { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
    }
    public partial class AvroDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AvroDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData AvroCompressionCodec { get { throw null; } set { } }
        public int? AvroCompressionLevel { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
    }
    public partial class AvroSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AvroSink() { }
        public Azure.ResourceManager.DataFactory.Models.AvroWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class AvroSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public AvroSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class AvroWriteSettings : Azure.ResourceManager.DataFactory.Models.FormatWriteSettings
    {
        public AvroWriteSettings() { }
        public System.BinaryData FileNamePrefix { get { throw null; } set { } }
        public System.BinaryData MaxRowsPerFile { get { throw null; } set { } }
        public string RecordName { get { throw null; } set { } }
        public string RecordNamespace { get { throw null; } set { } }
    }
    public partial class AzPowerShellSetup : Azure.ResourceManager.DataFactory.Models.CustomSetupBase
    {
        public AzPowerShellSetup(string version) { }
        public string Version { get { throw null; } set { } }
    }
    public partial class AzureBatchLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureBatchLinkedService(System.BinaryData accountName, System.BinaryData batchUri, System.BinaryData poolName, Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition AccessKey { get { throw null; } set { } }
        public System.BinaryData AccountName { get { throw null; } set { } }
        public System.BinaryData BatchUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public System.BinaryData PoolName { get { throw null; } set { } }
    }
    public partial class AzureBlobDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AzureBlobDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public System.BinaryData FileName { get { throw null; } set { } }
        public System.BinaryData FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData TableRootLocation { get { throw null; } set { } }
    }
    public partial class AzureBlobEventsTrigger : Azure.ResourceManager.DataFactory.Models.MultiplePipelineTrigger
    {
        public AzureBlobEventsTrigger(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.AzureBlobEventType> events, string scope) { }
        public string BlobPathBeginsWith { get { throw null; } set { } }
        public string BlobPathEndsWith { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.AzureBlobEventType> Events { get { throw null; } }
        public bool? IgnoreEmptyBlobs { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureBlobEventType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.AzureBlobEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureBlobEventType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.AzureBlobEventType MicrosoftStorageBlobCreated { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureBlobEventType MicrosoftStorageBlobDeleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.AzureBlobEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.AzureBlobEventType left, Azure.ResourceManager.DataFactory.Models.AzureBlobEventType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.AzureBlobEventType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.AzureBlobEventType left, Azure.ResourceManager.DataFactory.Models.AzureBlobEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureBlobFSDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AzureBlobFSDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public System.BinaryData FileName { get { throw null; } set { } }
        public System.BinaryData FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
    }
    public partial class AzureBlobFSLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureBlobFSLinkedService(System.BinaryData uri) { }
        public System.BinaryData AccountKey { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalCredential { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalCredentialType { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
    }
    public partial class AzureBlobFSLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AzureBlobFSLocation() { }
        public System.BinaryData FileSystem { get { throw null; } set { } }
    }
    public partial class AzureBlobFSReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AzureBlobFSReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureBlobFSSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureBlobFSSink() { }
        public System.BinaryData CopyBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.FactoryMetadataItemInfo> Metadata { get { throw null; } }
    }
    public partial class AzureBlobFSSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public AzureBlobFSSource() { }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData SkipHeaderLineCount { get { throw null; } set { } }
        public System.BinaryData TreatEmptyAsNull { get { throw null; } set { } }
    }
    public partial class AzureBlobFSWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public AzureBlobFSWriteSettings() { }
        public System.BinaryData BlockSizeInMB { get { throw null; } set { } }
    }
    public partial class AzureBlobSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureBlobSink() { }
        public System.BinaryData BlobWriterAddHeader { get { throw null; } set { } }
        public System.BinaryData BlobWriterDateTimeFormat { get { throw null; } set { } }
        public System.BinaryData BlobWriterOverwriteFiles { get { throw null; } set { } }
        public System.BinaryData CopyBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.FactoryMetadataItemInfo> Metadata { get { throw null; } }
    }
    public partial class AzureBlobSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public AzureBlobSource() { }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData SkipHeaderLineCount { get { throw null; } set { } }
        public System.BinaryData TreatEmptyAsNull { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureBlobStorageLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public string AccountKind { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public System.BinaryData SasUri { get { throw null; } set { } }
        public string ServiceEndpoint { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AzureBlobStorageLocation() { }
        public System.BinaryData Container { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AzureBlobStorageReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Prefix { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public AzureBlobStorageWriteSettings() { }
        public System.BinaryData BlockSizeInMB { get { throw null; } set { } }
    }
    public partial class AzureBlobTrigger : Azure.ResourceManager.DataFactory.Models.MultiplePipelineTrigger
    {
        public AzureBlobTrigger(string folderPath, int maxConcurrency, Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedService) { }
        public string FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference LinkedService { get { throw null; } set { } }
        public int MaxConcurrency { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AzureDatabricksDeltaLakeDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeExportCommand : Azure.ResourceManager.DataFactory.Models.ExportSettings
    {
        public AzureDatabricksDeltaLakeExportCommand() { }
        public System.BinaryData DateFormat { get { throw null; } set { } }
        public System.BinaryData TimestampFormat { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeImportCommand : Azure.ResourceManager.DataFactory.Models.ImportSettings
    {
        public AzureDatabricksDeltaLakeImportCommand() { }
        public System.BinaryData DateFormat { get { throw null; } set { } }
        public System.BinaryData TimestampFormat { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureDatabricksDeltaLakeLinkedService(System.BinaryData domain) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition AccessToken { get { throw null; } set { } }
        public System.BinaryData ClusterId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData Domain { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData WorkspaceResourceId { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureDatabricksDeltaLakeSink() { }
        public Azure.ResourceManager.DataFactory.Models.AzureDatabricksDeltaLakeImportCommand ImportSettings { get { throw null; } set { } }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public AzureDatabricksDeltaLakeSource() { }
        public Azure.ResourceManager.DataFactory.Models.AzureDatabricksDeltaLakeExportCommand ExportSettings { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class AzureDatabricksLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureDatabricksLinkedService(System.BinaryData domain) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition AccessToken { get { throw null; } set { } }
        public System.BinaryData Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData Domain { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData ExistingClusterId { get { throw null; } set { } }
        public System.BinaryData InstancePoolId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> NewClusterCustomTags { get { throw null; } }
        public System.BinaryData NewClusterDriverNodeType { get { throw null; } set { } }
        public System.BinaryData NewClusterEnableElasticDisk { get { throw null; } set { } }
        public System.BinaryData NewClusterInitScripts { get { throw null; } set { } }
        public System.BinaryData NewClusterLogDestination { get { throw null; } set { } }
        public System.BinaryData NewClusterNodeType { get { throw null; } set { } }
        public System.BinaryData NewClusterNumOfWorker { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> NewClusterSparkConf { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> NewClusterSparkEnvVars { get { throw null; } }
        public System.BinaryData NewClusterVersion { get { throw null; } set { } }
        public System.BinaryData PolicyId { get { throw null; } set { } }
        public System.BinaryData WorkspaceResourceId { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerCommandActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public AzureDataExplorerCommandActivity(string name, System.BinaryData command) : base (default(string)) { }
        public System.BinaryData Command { get { throw null; } set { } }
        public System.BinaryData CommandTimeout { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureDataExplorerLinkedService(System.BinaryData endpoint, System.BinaryData database) { }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureDataExplorerSink() { }
        public System.BinaryData FlushImmediately { get { throw null; } set { } }
        public System.BinaryData IngestionMappingAsJson { get { throw null; } set { } }
        public System.BinaryData IngestionMappingName { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public AzureDataExplorerSource(System.BinaryData query) { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData NoTruncation { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AzureDataExplorerTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Table { get { throw null; } set { } }
    }
    public partial class AzureDataLakeAnalyticsLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureDataLakeAnalyticsLinkedService(System.BinaryData accountName, System.BinaryData tenant) { }
        public System.BinaryData AccountName { get { throw null; } set { } }
        public System.BinaryData DataLakeAnalyticsUri { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData ResourceGroupName { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData SubscriptionId { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AzureDataLakeStoreDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public System.BinaryData FileName { get { throw null; } set { } }
        public System.BinaryData FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureDataLakeStoreLinkedService(System.BinaryData dataLakeStoreUri) { }
        public System.BinaryData AccountName { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData DataLakeStoreUri { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData ResourceGroupName { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData SubscriptionId { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AzureDataLakeStoreLocation() { }
    }
    public partial class AzureDataLakeStoreReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AzureDataLakeStoreReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ListAfter { get { throw null; } set { } }
        public System.BinaryData ListBefore { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureDataLakeStoreSink() { }
        public System.BinaryData CopyBehavior { get { throw null; } set { } }
        public System.BinaryData EnableAdlsSingleFileParallel { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public AzureDataLakeStoreSource() { }
        public System.BinaryData Recursive { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public AzureDataLakeStoreWriteSettings() { }
        public System.BinaryData ExpiryDateTime { get { throw null; } set { } }
    }
    public partial class AzureFileStorageLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureFileStorageLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData FileShare { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public System.BinaryData SasUri { get { throw null; } set { } }
        public System.BinaryData Snapshot { get { throw null; } set { } }
        public System.BinaryData UserId { get { throw null; } set { } }
    }
    public partial class AzureFileStorageLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public AzureFileStorageLocation() { }
    }
    public partial class AzureFileStorageReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public AzureFileStorageReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Prefix { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureFileStorageWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public AzureFileStorageWriteSettings() { }
    }
    public partial class AzureFunctionActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public AzureFunctionActivity(string name, Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod method, System.BinaryData functionName) : base (default(string)) { }
        public System.BinaryData Body { get { throw null; } set { } }
        public System.BinaryData FunctionName { get { throw null; } set { } }
        public System.BinaryData Headers { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Method { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureFunctionActivityMethod : System.IEquatable<Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureFunctionActivityMethod(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Delete { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Get { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Head { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Options { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Post { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Put { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod Trace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod left, Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod left, Azure.ResourceManager.DataFactory.Models.AzureFunctionActivityMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureFunctionLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureFunctionLinkedService(System.BinaryData functionAppUri) { }
        public System.BinaryData Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData FunctionAppUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition FunctionKey { get { throw null; } set { } }
        public System.BinaryData ResourceId { get { throw null; } set { } }
    }
    public partial class AzureKeyVaultLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureKeyVaultLinkedService(System.BinaryData baseUri) { }
        public System.BinaryData BaseUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
    }
    public partial class AzureKeyVaultSecretReference : Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition
    {
        public AzureKeyVaultSecretReference(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference store, System.BinaryData secretName) { }
        public System.BinaryData SecretName { get { throw null; } set { } }
        public System.BinaryData SecretVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference Store { get { throw null; } set { } }
    }
    public partial class AzureMariaDBLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureMariaDBLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class AzureMariaDBSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AzureMariaDBSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class AzureMariaDBTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AzureMariaDBTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AzureMLBatchExecutionActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public AzureMLBatchExecutionActivity(string name) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> GlobalParameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.AzureMLWebServiceFile> WebServiceInputs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.AzureMLWebServiceFile> WebServiceOutputs { get { throw null; } }
    }
    public partial class AzureMLExecutePipelineActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public AzureMLExecutePipelineActivity(string name) : base (default(string)) { }
        public System.BinaryData ContinueOnStepFailure { get { throw null; } set { } }
        public System.BinaryData DataPathAssignments { get { throw null; } set { } }
        public System.BinaryData ExperimentName { get { throw null; } set { } }
        public System.BinaryData MlParentRunId { get { throw null; } set { } }
        public System.BinaryData MlPipelineEndpointId { get { throw null; } set { } }
        public System.BinaryData MlPipelineId { get { throw null; } set { } }
        public System.BinaryData MlPipelineParameters { get { throw null; } set { } }
        public System.BinaryData Version { get { throw null; } set { } }
    }
    public partial class AzureMLLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureMLLinkedService(System.BinaryData mlEndpoint, Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition apiKey) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ApiKey { get { throw null; } set { } }
        public System.BinaryData Authentication { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData MlEndpoint { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
        public System.BinaryData UpdateResourceEndpoint { get { throw null; } set { } }
    }
    public partial class AzureMLServiceLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureMLServiceLinkedService(System.BinaryData subscriptionId, System.BinaryData resourceGroupName, System.BinaryData mlWorkspaceName) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData MlWorkspaceName { get { throw null; } set { } }
        public System.BinaryData ResourceGroupName { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData SubscriptionId { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureMLUpdateResourceActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public AzureMLUpdateResourceActivity(string name, System.BinaryData trainedModelName, Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference trainedModelLinkedServiceName, System.BinaryData trainedModelFilePath) : base (default(string)) { }
        public System.BinaryData TrainedModelFilePath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference TrainedModelLinkedServiceName { get { throw null; } set { } }
        public System.BinaryData TrainedModelName { get { throw null; } set { } }
    }
    public partial class AzureMLWebServiceFile
    {
        public AzureMLWebServiceFile(System.BinaryData filePath, Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) { }
        public System.BinaryData FilePath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
    }
    public partial class AzureMySqlLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureMySqlLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class AzureMySqlSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureMySqlSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class AzureMySqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AzureMySqlSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class AzureMySqlTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AzureMySqlTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzurePostgreSqlLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzurePostgreSqlSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AzurePostgreSqlSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AzurePostgreSqlTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AzureQueueSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureQueueSink() { }
    }
    public partial class AzureSearchIndexDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AzureSearchIndexDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData indexName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData IndexName { get { throw null; } set { } }
    }
    public partial class AzureSearchIndexSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureSearchIndexSink() { }
        public Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType? WriteBehavior { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSearchIndexWriteBehaviorType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSearchIndexWriteBehaviorType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType Merge { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType Upload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType left, Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType left, Azure.ResourceManager.DataFactory.Models.AzureSearchIndexWriteBehaviorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureSearchLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureSearchLinkedService(System.BinaryData uri) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Key { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
    }
    public partial class AzureSqlDatabaseLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureSqlDatabaseLinkedService(System.BinaryData connectionString) { }
        public Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureSqlDWLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureSqlDWLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureSqlDWTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AzureSqlDWTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AzureSqlMILinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureSqlMILinkedService(System.BinaryData connectionString) { }
        public Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class AzureSqlMITableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AzureSqlMITableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AzureSqlSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureSqlSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
        public System.BinaryData SqlWriterStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData SqlWriterTableType { get { throw null; } set { } }
        public System.BinaryData SqlWriterUseTableLock { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
        public System.BinaryData StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public System.BinaryData TableOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class AzureSqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AzureSqlSource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData ProduceAdditionalTypes { get { throw null; } set { } }
        public System.BinaryData SqlReaderQuery { get { throw null; } set { } }
        public System.BinaryData SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
    }
    public partial class AzureSqlTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AzureSqlTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AzureStorageLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureStorageLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public System.BinaryData SasUri { get { throw null; } set { } }
    }
    public partial class AzureTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public AzureTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData tableName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class AzureTableSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public AzureTableSink() { }
        public System.BinaryData AzureTableDefaultPartitionKeyValue { get { throw null; } set { } }
        public System.BinaryData AzureTableInsertType { get { throw null; } set { } }
        public System.BinaryData AzureTablePartitionKeyName { get { throw null; } set { } }
        public System.BinaryData AzureTableRowKeyName { get { throw null; } set { } }
    }
    public partial class AzureTableSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public AzureTableSource() { }
        public System.BinaryData AzureTableSourceIgnoreTableNotFound { get { throw null; } set { } }
        public System.BinaryData AzureTableSourceQuery { get { throw null; } set { } }
    }
    public partial class AzureTableStorageLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public AzureTableStorageLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public System.BinaryData SasUri { get { throw null; } set { } }
    }
    public partial class BinaryDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public BinaryDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
    }
    public partial class BinaryReadSettings : Azure.ResourceManager.DataFactory.Models.FormatReadSettings
    {
        public BinaryReadSettings() { }
        public Azure.ResourceManager.DataFactory.Models.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
    }
    public partial class BinarySink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public BinarySink() { }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class BinarySource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public BinarySource() { }
        public Azure.ResourceManager.DataFactory.Models.BinaryReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class CassandraLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public CassandraLinkedService(System.BinaryData host) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class CassandraSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public CassandraSource() { }
        public Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel? ConsistencyLevel { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CassandraSourceReadConsistencyLevel : System.IEquatable<Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CassandraSourceReadConsistencyLevel(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel All { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel EachQuorum { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel LocalOne { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel LocalQuorum { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel LocalSerial { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel One { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel Quorum { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel Serial { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel Three { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel Two { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel left, Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel left, Azure.ResourceManager.DataFactory.Models.CassandraSourceReadConsistencyLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CassandraTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public CassandraTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Keyspace { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class ChainingTrigger : Azure.ResourceManager.DataFactory.Models.FactoryTriggerDefinition
    {
        public ChainingTrigger(Azure.ResourceManager.DataFactory.Models.TriggerPipelineReference pipeline, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.FactoryPipelineReference> dependsOn, string runDimension) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.FactoryPipelineReference> DependsOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.TriggerPipelineReference Pipeline { get { throw null; } set { } }
        public string RunDimension { get { throw null; } set { } }
    }
    public partial class CmdkeySetup : Azure.ResourceManager.DataFactory.Models.CustomSetupBase
    {
        public CmdkeySetup(System.BinaryData targetName, System.BinaryData userName, Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition password) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData TargetName { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class CommonDataServiceForAppsEntityDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public CommonDataServiceForAppsEntityDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData EntityName { get { throw null; } set { } }
    }
    public partial class CommonDataServiceForAppsLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public CommonDataServiceForAppsLinkedService(System.BinaryData deploymentType, System.BinaryData authenticationType) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData DeploymentType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData HostName { get { throw null; } set { } }
        public System.BinaryData OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalCredential { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalCredentialType { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public System.BinaryData ServiceUri { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class CommonDataServiceForAppsSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public CommonDataServiceForAppsSink(Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior writeBehavior) { }
        public System.BinaryData AlternateKeyName { get { throw null; } set { } }
        public System.BinaryData IgnoreNullValues { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior WriteBehavior { get { throw null; } set { } }
    }
    public partial class CommonDataServiceForAppsSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public CommonDataServiceForAppsSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class ComponentSetup : Azure.ResourceManager.DataFactory.Models.CustomSetupBase
    {
        public ComponentSetup(string componentName) { }
        public string ComponentName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition LicenseKey { get { throw null; } set { } }
    }
    public partial class CompressionReadSettings
    {
        public CompressionReadSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
    }
    public partial class ConcurLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public ConcurLinkedService(System.BinaryData clientId, System.BinaryData username) { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class ConcurObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public ConcurObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class ConcurSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ConcurSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class ConnectionStateProperties
    {
        public ConnectionStateProperties() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ControlActivity : Azure.ResourceManager.DataFactory.Models.PipelineActivity
    {
        public ControlActivity(string name) : base (default(string)) { }
    }
    public partial class CopyActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public CopyActivity(string name, Azure.ResourceManager.DataFactory.Models.CopyActivitySource source, Azure.ResourceManager.DataFactory.Models.CopySink sink) : base (default(string)) { }
        public System.BinaryData DataIntegrationUnits { get { throw null; } set { } }
        public System.BinaryData EnableSkipIncompatibleRow { get { throw null; } set { } }
        public System.BinaryData EnableStaging { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DatasetReference> Inputs { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.LogSettings LogSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LogStorageSettings LogStorageSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DatasetReference> Outputs { get { throw null; } }
        public System.BinaryData ParallelCopies { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Preserve { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> PreserveRules { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.RedirectIncompatibleRowSettings RedirectIncompatibleRowSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CopySink Sink { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SkipErrorFile SkipErrorFile { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CopyActivitySource Source { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StagingSettings StagingSettings { get { throw null; } set { } }
        public System.BinaryData Translator { get { throw null; } set { } }
        public System.BinaryData ValidateDataConsistency { get { throw null; } set { } }
    }
    public partial class CopyActivityLogSettings
    {
        public CopyActivityLogSettings() { }
        public System.BinaryData EnableReliableLogging { get { throw null; } set { } }
        public System.BinaryData LogLevel { get { throw null; } set { } }
    }
    public partial class CopyActivitySource
    {
        public CopyActivitySource() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData DisableMetricsCollection { get { throw null; } set { } }
        public System.BinaryData MaxConcurrentConnections { get { throw null; } set { } }
        public System.BinaryData SourceRetryCount { get { throw null; } set { } }
        public System.BinaryData SourceRetryWait { get { throw null; } set { } }
    }
    public partial class CopySink
    {
        public CopySink() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData DisableMetricsCollection { get { throw null; } set { } }
        public System.BinaryData MaxConcurrentConnections { get { throw null; } set { } }
        public System.BinaryData SinkRetryCount { get { throw null; } set { } }
        public System.BinaryData SinkRetryWait { get { throw null; } set { } }
        public System.BinaryData WriteBatchSize { get { throw null; } set { } }
        public System.BinaryData WriteBatchTimeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBConnectionMode : System.IEquatable<Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBConnectionMode(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode Direct { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode Gateway { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode left, Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode left, Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public CosmosDBLinkedService() { }
        public System.BinaryData AccountEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition AccountKey { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CosmosDBConnectionMode? ConnectionMode { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CosmosDBServicePrincipalCredentialType? ServicePrincipalCredentialType { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
    }
    public partial class CosmosDBMongoDBApiCollectionDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public CosmosDBMongoDBApiCollectionDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData collection) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Collection { get { throw null; } set { } }
    }
    public partial class CosmosDBMongoDBApiLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public CosmosDBMongoDBApiLinkedService(System.BinaryData connectionString, System.BinaryData database) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData IsServerVersionAbove32 { get { throw null; } set { } }
    }
    public partial class CosmosDBMongoDBApiSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public CosmosDBMongoDBApiSink() { }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class CosmosDBMongoDBApiSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public CosmosDBMongoDBApiSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData BatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MongoDBCursorMethodsProperties CursorMethods { get { throw null; } set { } }
        public System.BinaryData Filter { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBServicePrincipalCredentialType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.CosmosDBServicePrincipalCredentialType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBServicePrincipalCredentialType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.CosmosDBServicePrincipalCredentialType ServicePrincipalCert { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.CosmosDBServicePrincipalCredentialType ServicePrincipalKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.CosmosDBServicePrincipalCredentialType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.CosmosDBServicePrincipalCredentialType left, Azure.ResourceManager.DataFactory.Models.CosmosDBServicePrincipalCredentialType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.CosmosDBServicePrincipalCredentialType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.CosmosDBServicePrincipalCredentialType left, Azure.ResourceManager.DataFactory.Models.CosmosDBServicePrincipalCredentialType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBSqlApiCollectionDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public CosmosDBSqlApiCollectionDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData collectionName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData CollectionName { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlApiSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public CosmosDBSqlApiSink() { }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlApiSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public CosmosDBSqlApiSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData DetectDatetime { get { throw null; } set { } }
        public System.BinaryData PageSize { get { throw null; } set { } }
        public System.BinaryData PreferredRegions { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class CouchbaseLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public CouchbaseLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference CredString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
    }
    public partial class CouchbaseSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public CouchbaseSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class CouchbaseTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public CouchbaseTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class CreateLinkedIntegrationRuntimeContent
    {
        public CreateLinkedIntegrationRuntimeContent() { }
        public Azure.Core.AzureLocation? DataFactoryLocation { get { throw null; } set { } }
        public string DataFactoryName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class CustomActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public CustomActivity(string name, System.BinaryData command) : base (default(string)) { }
        public System.BinaryData AutoUserSpecification { get { throw null; } set { } }
        public System.BinaryData Command { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ExtendedProperties { get { throw null; } }
        public System.BinaryData FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CustomActivityReferenceObject ReferenceObjects { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference ResourceLinkedService { get { throw null; } set { } }
        public System.BinaryData RetentionTimeInDays { get { throw null; } set { } }
    }
    public partial class CustomActivityReferenceObject
    {
        public CustomActivityReferenceObject() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DatasetReference> Datasets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference> LinkedServices { get { throw null; } }
    }
    public partial class CustomDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public CustomDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TypeProperties { get { throw null; } set { } }
    }
    public partial class CustomDataSourceLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public CustomDataSourceLinkedService(System.BinaryData typeProperties) { }
        public System.BinaryData TypeProperties { get { throw null; } set { } }
    }
    public partial class CustomEventsTrigger : Azure.ResourceManager.DataFactory.Models.MultiplePipelineTrigger
    {
        public CustomEventsTrigger(System.Collections.Generic.IEnumerable<System.BinaryData> events, string scope) { }
        public System.Collections.Generic.IList<System.BinaryData> Events { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public string SubjectBeginsWith { get { throw null; } set { } }
        public string SubjectEndsWith { get { throw null; } set { } }
    }
    public abstract partial class CustomSetupBase
    {
        protected CustomSetupBase() { }
    }
    public partial class DatabricksNotebookActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DatabricksNotebookActivity(string name, System.BinaryData notebookPath) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> BaseParameters { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Libraries { get { throw null; } }
        public System.BinaryData NotebookPath { get { throw null; } set { } }
    }
    public partial class DatabricksSparkJarActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DatabricksSparkJarActivity(string name, System.BinaryData mainClassName) : base (default(string)) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Libraries { get { throw null; } }
        public System.BinaryData MainClassName { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Parameters { get { throw null; } }
    }
    public partial class DatabricksSparkPythonActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DatabricksSparkPythonActivity(string name, System.BinaryData pythonFile) : base (default(string)) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Libraries { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Parameters { get { throw null; } }
        public System.BinaryData PythonFile { get { throw null; } set { } }
    }
    public partial class DataFactoryPatch
    {
        public DataFactoryPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFlowComputeType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFlowComputeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFlowComputeType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFlowComputeType ComputeOptimized { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFlowComputeType General { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFlowComputeType MemoryOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFlowComputeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFlowComputeType left, Azure.ResourceManager.DataFactory.Models.DataFlowComputeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFlowComputeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFlowComputeType left, Azure.ResourceManager.DataFactory.Models.DataFlowComputeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFlowDebugCommandContent
    {
        public DataFlowDebugCommandContent() { }
        public Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType? Command { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandPayload CommandPayload { get { throw null; } set { } }
        public System.Guid? SessionId { get { throw null; } set { } }
    }
    public partial class DataFlowDebugCommandPayload
    {
        public DataFlowDebugCommandPayload(string streamName) { }
        public System.Collections.Generic.IList<string> Columns { get { throw null; } }
        public string Expression { get { throw null; } set { } }
        public int? RowLimits { get { throw null; } set { } }
        public string StreamName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFlowDebugCommandType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFlowDebugCommandType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType ExecuteExpressionQuery { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType ExecutePreviewQuery { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType ExecuteStatisticsQuery { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType left, Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType left, Azure.ResourceManager.DataFactory.Models.DataFlowDebugCommandType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFlowDebugPackageDebugSettings
    {
        public DataFlowDebugPackageDebugSettings() { }
        public System.BinaryData DatasetParameters { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowSourceSetting> SourceSettings { get { throw null; } }
    }
    public partial class DataFlowDebugSessionInfo
    {
        internal DataFlowDebugSessionInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ComputeType { get { throw null; } }
        public int? CoreCount { get { throw null; } }
        public string DataFlowName { get { throw null; } }
        public string IntegrationRuntimeName { get { throw null; } }
        public System.DateTimeOffset? LastActivityOn { get { throw null; } }
        public int? NodeCount { get { throw null; } }
        public System.Guid? SessionId { get { throw null; } }
        public string StartOn { get { throw null; } }
        public int? TimeToLiveInMinutes { get { throw null; } }
    }
    public partial class DataFlowReference
    {
        public DataFlowReference(Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType referenceType, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData DatasetParameters { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFlowReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFlowReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType DataFlowReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType left, Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType left, Azure.ResourceManager.DataFactory.Models.DataFlowReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFlowSink : Azure.ResourceManager.DataFactory.Models.DataFlowTransformation
    {
        public DataFlowSink(string name) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference RejectedDataLinkedService { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference SchemaLinkedService { get { throw null; } set { } }
    }
    public partial class DataFlowSource : Azure.ResourceManager.DataFactory.Models.DataFlowTransformation
    {
        public DataFlowSource(string name) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference SchemaLinkedService { get { throw null; } set { } }
    }
    public partial class DataFlowSourceSetting
    {
        public DataFlowSourceSetting() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? RowLimit { get { throw null; } set { } }
        public string SourceName { get { throw null; } set { } }
    }
    public partial class DataFlowStagingInfo
    {
        public DataFlowStagingInfo() { }
        public System.BinaryData FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference LinkedService { get { throw null; } set { } }
    }
    public partial class DataFlowTransformation
    {
        public DataFlowTransformation(string name) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetReference Dataset { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowReference Flowlet { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference LinkedService { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class DataLakeAnalyticsUsqlActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DataLakeAnalyticsUsqlActivity(string name, System.BinaryData scriptPath, Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference scriptLinkedService) : base (default(string)) { }
        public System.BinaryData CompilationMode { get { throw null; } set { } }
        public System.BinaryData DegreeOfParallelism { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public System.BinaryData Priority { get { throw null; } set { } }
        public System.BinaryData RuntimeVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference ScriptLinkedService { get { throw null; } set { } }
        public System.BinaryData ScriptPath { get { throw null; } set { } }
    }
    public partial class DatasetAvroFormat : Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat
    {
        public DatasetAvroFormat() { }
    }
    public partial class DatasetCompression
    {
        public DatasetCompression(System.BinaryData datasetCompressionType) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData DatasetCompressionType { get { throw null; } set { } }
        public System.BinaryData Level { get { throw null; } set { } }
    }
    public partial class DatasetJsonFormat : Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat
    {
        public DatasetJsonFormat() { }
        public System.BinaryData EncodingName { get { throw null; } set { } }
        public System.BinaryData FilePattern { get { throw null; } set { } }
        public System.BinaryData JsonNodeReference { get { throw null; } set { } }
        public System.BinaryData JsonPathDefinition { get { throw null; } set { } }
        public System.BinaryData NestingSeparator { get { throw null; } set { } }
    }
    public partial class DatasetLocation
    {
        public DatasetLocation() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData FileName { get { throw null; } set { } }
        public System.BinaryData FolderPath { get { throw null; } set { } }
    }
    public partial class DatasetOrcFormat : Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat
    {
        public DatasetOrcFormat() { }
    }
    public partial class DatasetParquetFormat : Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat
    {
        public DatasetParquetFormat() { }
    }
    public partial class DatasetReference
    {
        public DatasetReference(Azure.ResourceManager.DataFactory.Models.DatasetReferenceType referenceType, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatasetReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DatasetReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatasetReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DatasetReferenceType DatasetReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DatasetReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DatasetReferenceType left, Azure.ResourceManager.DataFactory.Models.DatasetReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DatasetReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DatasetReferenceType left, Azure.ResourceManager.DataFactory.Models.DatasetReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatasetStorageFormat
    {
        public DatasetStorageFormat() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData Deserializer { get { throw null; } set { } }
        public System.BinaryData Serializer { get { throw null; } set { } }
    }
    public partial class DatasetTextFormat : Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat
    {
        public DatasetTextFormat() { }
        public System.BinaryData ColumnDelimiter { get { throw null; } set { } }
        public System.BinaryData EncodingName { get { throw null; } set { } }
        public System.BinaryData EscapeChar { get { throw null; } set { } }
        public System.BinaryData FirstRowAsHeader { get { throw null; } set { } }
        public System.BinaryData NullValue { get { throw null; } set { } }
        public System.BinaryData QuoteChar { get { throw null; } set { } }
        public System.BinaryData RowDelimiter { get { throw null; } set { } }
        public System.BinaryData SkipLineCount { get { throw null; } set { } }
        public System.BinaryData TreatEmptyAsNull { get { throw null; } set { } }
    }
    public partial class DataworldLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public DataworldLinkedService(Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition apiToken) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ApiToken { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
    }
    public enum DayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Db2AuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Db2AuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType left, Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType left, Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Db2LinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public Db2LinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.Db2AuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData CertificateCommonName { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData PackageCollection { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class Db2Source : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public Db2Source() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class Db2TableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public Db2TableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class DeleteActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public DeleteActivity(string name, Azure.ResourceManager.DataFactory.Models.DatasetReference dataset) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetReference Dataset { get { throw null; } set { } }
        public System.BinaryData EnableLogging { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LogStorageSettings LogStorageSettings { get { throw null; } set { } }
        public int? MaxConcurrentConnections { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class DeleteDataFlowDebugSessionContent
    {
        public DeleteDataFlowDebugSessionContent() { }
        public System.Guid? SessionId { get { throw null; } set { } }
    }
    public partial class DelimitedTextDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public DelimitedTextDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData ColumnDelimiter { get { throw null; } set { } }
        public System.BinaryData CompressionCodec { get { throw null; } set { } }
        public System.BinaryData CompressionLevel { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
        public System.BinaryData EncodingName { get { throw null; } set { } }
        public System.BinaryData EscapeChar { get { throw null; } set { } }
        public System.BinaryData FirstRowAsHeader { get { throw null; } set { } }
        public System.BinaryData NullValue { get { throw null; } set { } }
        public System.BinaryData QuoteChar { get { throw null; } set { } }
        public System.BinaryData RowDelimiter { get { throw null; } set { } }
    }
    public partial class DelimitedTextReadSettings : Azure.ResourceManager.DataFactory.Models.FormatReadSettings
    {
        public DelimitedTextReadSettings() { }
        public Azure.ResourceManager.DataFactory.Models.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
        public System.BinaryData SkipLineCount { get { throw null; } set { } }
    }
    public partial class DelimitedTextSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public DelimitedTextSink() { }
        public Azure.ResourceManager.DataFactory.Models.DelimitedTextWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class DelimitedTextSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public DelimitedTextSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DelimitedTextReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class DelimitedTextWriteSettings : Azure.ResourceManager.DataFactory.Models.FormatWriteSettings
    {
        public DelimitedTextWriteSettings(System.BinaryData fileExtension) { }
        public System.BinaryData FileExtension { get { throw null; } set { } }
        public System.BinaryData FileNamePrefix { get { throw null; } set { } }
        public System.BinaryData MaxRowsPerFile { get { throw null; } set { } }
        public System.BinaryData QuoteAllText { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DependencyCondition : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DependencyCondition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DependencyCondition(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DependencyCondition Completed { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DependencyCondition Failed { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DependencyCondition Skipped { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.DependencyCondition Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DependencyCondition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DependencyCondition left, Azure.ResourceManager.DataFactory.Models.DependencyCondition right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DependencyCondition (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DependencyCondition left, Azure.ResourceManager.DataFactory.Models.DependencyCondition right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DependencyReference
    {
        protected DependencyReference() { }
    }
    public partial class DistcpSettings
    {
        public DistcpSettings(System.BinaryData resourceManagerEndpoint, System.BinaryData tempScriptPath) { }
        public System.BinaryData DistcpOptions { get { throw null; } set { } }
        public System.BinaryData ResourceManagerEndpoint { get { throw null; } set { } }
        public System.BinaryData TempScriptPath { get { throw null; } set { } }
    }
    public partial class DocumentDBCollectionDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public DocumentDBCollectionDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData collectionName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData CollectionName { get { throw null; } set { } }
    }
    public partial class DocumentDBCollectionSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public DocumentDBCollectionSink() { }
        public System.BinaryData NestingSeparator { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class DocumentDBCollectionSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public DocumentDBCollectionSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData NestingSeparator { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    public partial class DrillLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public DrillLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class DrillSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public DrillSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class DrillTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public DrillTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class DWCopyCommandDefaultValue
    {
        public DWCopyCommandDefaultValue() { }
        public System.BinaryData ColumnName { get { throw null; } set { } }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
    }
    public partial class DWCopyCommandSettings
    {
        public DWCopyCommandSettings() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalOptions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DWCopyCommandDefaultValue> DefaultValues { get { throw null; } }
    }
    public partial class DynamicsAXLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public DynamicsAXLinkedService(System.BinaryData uri, System.BinaryData servicePrincipalId, Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition servicePrincipalKey, System.BinaryData tenant, System.BinaryData aadResourceId) { }
        public System.BinaryData AadResourceId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
    }
    public partial class DynamicsAXResourceDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public DynamicsAXResourceDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData path) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class DynamicsAXSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public DynamicsAXSource() { }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class DynamicsCrmEntityDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public DynamicsCrmEntityDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData EntityName { get { throw null; } set { } }
    }
    public partial class DynamicsCrmLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public DynamicsCrmLinkedService(System.BinaryData deploymentType, System.BinaryData authenticationType) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData DeploymentType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData HostName { get { throw null; } set { } }
        public System.BinaryData OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalCredential { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalCredentialType { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public System.BinaryData ServiceUri { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class DynamicsCrmSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public DynamicsCrmSink(Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior writeBehavior) { }
        public System.BinaryData AlternateKeyName { get { throw null; } set { } }
        public System.BinaryData IgnoreNullValues { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior WriteBehavior { get { throw null; } set { } }
    }
    public partial class DynamicsCrmSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public DynamicsCrmSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class DynamicsEntityDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public DynamicsEntityDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData EntityName { get { throw null; } set { } }
    }
    public partial class DynamicsLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public DynamicsLinkedService(System.BinaryData deploymentType, System.BinaryData authenticationType) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData DeploymentType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData HostName { get { throw null; } set { } }
        public System.BinaryData OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalCredential { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalCredentialType { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public System.BinaryData ServiceUri { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class DynamicsSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public DynamicsSink(Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior writeBehavior) { }
        public System.BinaryData AlternateKeyName { get { throw null; } set { } }
        public System.BinaryData IgnoreNullValues { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior WriteBehavior { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynamicsSinkWriteBehavior : System.IEquatable<Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynamicsSinkWriteBehavior(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior Upsert { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior left, Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior left, Azure.ResourceManager.DataFactory.Models.DynamicsSinkWriteBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DynamicsSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public DynamicsSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class EloquaLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public EloquaLinkedService(System.BinaryData endpoint, System.BinaryData username) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class EloquaObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public EloquaObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class EloquaSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public EloquaSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class EntityParameterSpecification
    {
        public EntityParameterSpecification(Azure.ResourceManager.DataFactory.Models.EntityParameterType parameterType) { }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.EntityParameterType ParameterType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityParameterType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.EntityParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityParameterType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.EntityParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EntityParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EntityParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EntityParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EntityParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EntityParameterType SecureString { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EntityParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.EntityParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.EntityParameterType left, Azure.ResourceManager.DataFactory.Models.EntityParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.EntityParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.EntityParameterType left, Azure.ResourceManager.DataFactory.Models.EntityParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityReference
    {
        public EntityReference() { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType? IntegrationRuntimeEntityReferenceType { get { throw null; } set { } }
        public string ReferenceName { get { throw null; } set { } }
    }
    public partial class EnvironmentVariableSetup : Azure.ResourceManager.DataFactory.Models.CustomSetupBase
    {
        public EnvironmentVariableSetup(string variableName, string variableValue) { }
        public string VariableName { get { throw null; } set { } }
        public string VariableValue { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventSubscriptionStatus : System.IEquatable<Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus Deprovisioning { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus left, Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus left, Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExcelDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public ExcelDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
        public System.BinaryData FirstRowAsHeader { get { throw null; } set { } }
        public System.BinaryData NullValue { get { throw null; } set { } }
        public System.BinaryData Range { get { throw null; } set { } }
        public System.BinaryData SheetIndex { get { throw null; } set { } }
        public System.BinaryData SheetName { get { throw null; } set { } }
    }
    public partial class ExcelSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public ExcelSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class ExecuteDataFlowActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public ExecuteDataFlowActivity(string name, Azure.ResourceManager.DataFactory.Models.DataFlowReference dataFlow) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.ExecuteDataFlowActivityTypePropertiesCompute Compute { get { throw null; } set { } }
        public System.BinaryData ContinueOnError { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowReference DataFlow { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference IntegrationRuntime { get { throw null; } set { } }
        public System.BinaryData RunConcurrently { get { throw null; } set { } }
        public System.BinaryData SourceStagingConcurrency { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowStagingInfo Staging { get { throw null; } set { } }
        public System.BinaryData TraceLevel { get { throw null; } set { } }
    }
    public partial class ExecuteDataFlowActivityTypePropertiesCompute
    {
        public ExecuteDataFlowActivityTypePropertiesCompute() { }
        public System.BinaryData ComputeType { get { throw null; } set { } }
        public System.BinaryData CoreCount { get { throw null; } set { } }
    }
    public partial class ExecutePipelineActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public ExecutePipelineActivity(string name, Azure.ResourceManager.DataFactory.Models.FactoryPipelineReference pipeline) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryPipelineReference Pipeline { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ExecutePipelineActivityPolicy Policy { get { throw null; } set { } }
        public bool? WaitOnCompletion { get { throw null; } set { } }
    }
    public partial class ExecutePipelineActivityPolicy
    {
        public ExecutePipelineActivityPolicy() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public bool? EnableSecureInput { get { throw null; } set { } }
    }
    public partial class ExecuteSsisPackageActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public ExecuteSsisPackageActivity(string name, Azure.ResourceManager.DataFactory.Models.SsisPackageLocation packageLocation, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference connectVia) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference ConnectVia { get { throw null; } set { } }
        public System.BinaryData EnvironmentPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SsisExecutionCredential ExecutionCredential { get { throw null; } set { } }
        public System.BinaryData LoggingLevel { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SsisLogLocation LogLocation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.SsisExecutionParameter>> PackageConnectionManagers { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.SsisPackageLocation PackageLocation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.SsisExecutionParameter> PackageParameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.SsisExecutionParameter>> ProjectConnectionManagers { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.SsisExecutionParameter> ProjectParameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.SsisPropertyOverride> PropertyOverrides { get { throw null; } }
        public System.BinaryData Runtime { get { throw null; } set { } }
    }
    public partial class ExecuteWranglingDataflowActivity : Azure.ResourceManager.DataFactory.Models.PipelineActivity
    {
        public ExecuteWranglingDataflowActivity(string name, Azure.ResourceManager.DataFactory.Models.DataFlowReference dataFlow) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.ExecuteDataFlowActivityTypePropertiesCompute Compute { get { throw null; } set { } }
        public System.BinaryData ContinueOnError { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowReference DataFlow { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference IntegrationRuntime { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ActivityPolicy Policy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PowerQuerySinkMapping> Queries { get { throw null; } }
        public System.BinaryData RunConcurrently { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.PowerQuerySink> Sinks { get { throw null; } }
        public System.BinaryData SourceStagingConcurrency { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowStagingInfo Staging { get { throw null; } set { } }
        public System.BinaryData TraceLevel { get { throw null; } set { } }
    }
    public partial class ExecutionActivity : Azure.ResourceManager.DataFactory.Models.PipelineActivity
    {
        public ExecutionActivity(string name) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ActivityPolicy Policy { get { throw null; } set { } }
    }
    public partial class ExportSettings
    {
        public ExportSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
    }
    public partial class ExposureControlBatchContent
    {
        public ExposureControlBatchContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.ExposureControlContent> exposureControlRequests) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.ExposureControlContent> ExposureControlRequests { get { throw null; } }
    }
    public partial class ExposureControlBatchResult
    {
        internal ExposureControlBatchResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.ExposureControlResult> ExposureControlResults { get { throw null; } }
    }
    public partial class ExposureControlContent
    {
        public ExposureControlContent() { }
        public string FeatureName { get { throw null; } set { } }
        public string FeatureType { get { throw null; } set { } }
    }
    public partial class ExposureControlResult
    {
        internal ExposureControlResult() { }
        public string FeatureName { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class FactoryCredentialReference
    {
        public FactoryCredentialReference(Azure.ResourceManager.DataFactory.Models.FactoryCredentialReferenceType referenceType, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FactoryCredentialReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.FactoryCredentialReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FactoryCredentialReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.FactoryCredentialReferenceType CredentialReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.FactoryCredentialReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.FactoryCredentialReferenceType left, Azure.ResourceManager.DataFactory.Models.FactoryCredentialReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.FactoryCredentialReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.FactoryCredentialReferenceType left, Azure.ResourceManager.DataFactory.Models.FactoryCredentialReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FactoryDataFlowCreateDebugSessionResult
    {
        internal FactoryDataFlowCreateDebugSessionResult() { }
        public System.Guid? SessionId { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class FactoryDataFlowDebugCommandResult
    {
        internal FactoryDataFlowDebugCommandResult() { }
        public string Data { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class FactoryDataFlowDebugInfo : Azure.ResourceManager.DataFactory.Models.FactoryDebugInfo
    {
        public FactoryDataFlowDebugInfo(Azure.ResourceManager.DataFactory.Models.FactoryDataFlowDefinition properties) { }
        public Azure.ResourceManager.DataFactory.Models.FactoryDataFlowDefinition Properties { get { throw null; } }
    }
    public partial class FactoryDataFlowDebugPackageContent
    {
        public FactoryDataFlowDebugPackageContent() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryDataFlowDebugInfo DataFlow { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.FactoryDataFlowDebugInfo> DataFlows { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.FactoryDatasetDebugInfo> Datasets { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowDebugPackageDebugSettings DebugSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDebugInfo> LinkedServices { get { throw null; } }
        public System.Guid? SessionId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowStagingInfo Staging { get { throw null; } set { } }
    }
    public partial class FactoryDataFlowDebugSessionContent
    {
        public FactoryDataFlowDebugSessionContent() { }
        public string ComputeType { get { throw null; } set { } }
        public int? CoreCount { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryIntegrationRuntimeDebugInfo IntegrationRuntime { get { throw null; } set { } }
        public int? TimeToLiveInMinutes { get { throw null; } set { } }
    }
    public abstract partial class FactoryDataFlowDefinition
    {
        protected FactoryDataFlowDefinition() { }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string FolderName { get { throw null; } set { } }
    }
    public partial class FactoryDataFlowStartDebugSessionResult
    {
        internal FactoryDataFlowStartDebugSessionResult() { }
        public string JobVersion { get { throw null; } }
    }
    public partial class FactoryDataPlaneAccessPolicyResult
    {
        internal FactoryDataPlaneAccessPolicyResult() { }
        public string AccessToken { get { throw null; } }
        public System.Uri DataPlaneUri { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryDataPlaneUserAccessPolicy Policy { get { throw null; } }
    }
    public partial class FactoryDataPlaneUserAccessPolicy
    {
        public FactoryDataPlaneUserAccessPolicy() { }
        public string AccessResourcePath { get { throw null; } set { } }
        public string ExpireTime { get { throw null; } set { } }
        public string Permissions { get { throw null; } set { } }
        public string ProfileName { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
    }
    public partial class FactoryDatasetDebugInfo : Azure.ResourceManager.DataFactory.Models.FactoryDebugInfo
    {
        public FactoryDatasetDebugInfo(Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition properties) { }
        public Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition Properties { get { throw null; } }
    }
    public partial class FactoryDatasetDefinition
    {
        public FactoryDatasetDefinition(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string FolderName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.EntityParameterSpecification> Parameters { get { throw null; } }
        public System.BinaryData Schema { get { throw null; } set { } }
        public System.BinaryData Structure { get { throw null; } set { } }
    }
    public enum FactoryDayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public partial class FactoryDebugInfo
    {
        public FactoryDebugInfo() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class FactoryEncryptionConfiguration
    {
        public FactoryEncryptionConfiguration(string keyName, System.Uri vaultBaseUri) { }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
        public System.Uri VaultBaseUri { get { throw null; } set { } }
    }
    public partial class FactoryExpressionDefinition
    {
        public FactoryExpressionDefinition(Azure.ResourceManager.DataFactory.Models.FactoryExpressionType expressionType, string value) { }
        public Azure.ResourceManager.DataFactory.Models.FactoryExpressionType ExpressionType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FactoryExpressionType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.FactoryExpressionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FactoryExpressionType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.FactoryExpressionType Expression { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.FactoryExpressionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.FactoryExpressionType left, Azure.ResourceManager.DataFactory.Models.FactoryExpressionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.FactoryExpressionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.FactoryExpressionType left, Azure.ResourceManager.DataFactory.Models.FactoryExpressionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FactoryFlowletDefinition : Azure.ResourceManager.DataFactory.Models.FactoryDataFlowDefinition
    {
        public FactoryFlowletDefinition() { }
        public string Script { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ScriptLines { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowSink> Sinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowSource> Sources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowTransformation> Transformations { get { throw null; } }
    }
    public partial class FactoryGitHubConfiguration : Azure.ResourceManager.DataFactory.Models.FactoryRepoConfiguration
    {
        public FactoryGitHubConfiguration(string accountName, string repositoryName, string collaborationBranch, string rootFolder) : base (default(string), default(string), default(string), default(string)) { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.GitHubClientSecret ClientSecret { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
    }
    public partial class FactoryGlobalParameterSpecification
    {
        public FactoryGlobalParameterSpecification(Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterType parameterType, System.BinaryData value) { }
        public Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterType ParameterType { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FactoryGlobalParameterType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FactoryGlobalParameterType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterType left, Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterType left, Azure.ResourceManager.DataFactory.Models.FactoryGlobalParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FactoryIntegrationRuntimeDebugInfo : Azure.ResourceManager.DataFactory.Models.FactoryDebugInfo
    {
        public FactoryIntegrationRuntimeDebugInfo(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeDefinition properties) { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeDefinition Properties { get { throw null; } }
    }
    public partial class FactoryIntegrationRuntimePatch
    {
        public FactoryIntegrationRuntimePatch() { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate? AutoUpdate { get { throw null; } set { } }
        public System.TimeSpan? UpdateDelayOffset { get { throw null; } set { } }
    }
    public partial class FactoryLinkedServiceDebugInfo : Azure.ResourceManager.DataFactory.Models.FactoryDebugInfo
    {
        public FactoryLinkedServiceDebugInfo(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition properties) { }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition Properties { get { throw null; } }
    }
    public partial class FactoryLinkedServiceDefinition
    {
        public FactoryLinkedServiceDefinition() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference ConnectVia { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.EntityParameterSpecification> Parameters { get { throw null; } }
    }
    public partial class FactoryLinkedServiceReference
    {
        public FactoryLinkedServiceReference(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReferenceType referenceType, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FactoryLinkedServiceReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FactoryLinkedServiceReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReferenceType LinkedServiceReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReferenceType left, Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReferenceType left, Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FactoryMappingDataFlowDefinition : Azure.ResourceManager.DataFactory.Models.FactoryDataFlowDefinition
    {
        public FactoryMappingDataFlowDefinition() { }
        public string Script { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ScriptLines { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowSink> Sinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowSource> Sources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DataFlowTransformation> Transformations { get { throw null; } }
    }
    public partial class FactoryMetadataItemInfo
    {
        public FactoryMetadataItemInfo() { }
        public System.BinaryData Name { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class FactoryPipelineReference
    {
        public FactoryPipelineReference(Azure.ResourceManager.DataFactory.Models.FactoryPipelineReferenceType referenceType, string referenceName) { }
        public string Name { get { throw null; } set { } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryPipelineReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FactoryPipelineReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.FactoryPipelineReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FactoryPipelineReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.FactoryPipelineReferenceType PipelineReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.FactoryPipelineReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.FactoryPipelineReferenceType left, Azure.ResourceManager.DataFactory.Models.FactoryPipelineReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.FactoryPipelineReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.FactoryPipelineReferenceType left, Azure.ResourceManager.DataFactory.Models.FactoryPipelineReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FactoryPipelineRunInfo
    {
        internal FactoryPipelineRunInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? DurationInMs { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryPipelineRunInvokedByInfo InvokedBy { get { throw null; } }
        public bool? IsLatest { get { throw null; } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Parameters { get { throw null; } }
        public string PipelineName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> RunDimensions { get { throw null; } }
        public System.DateTimeOffset? RunEnd { get { throw null; } }
        public string RunGroupId { get { throw null; } }
        public System.Guid? RunId { get { throw null; } }
        public System.DateTimeOffset? RunStart { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class FactoryPipelineRunInvokedByInfo
    {
        internal FactoryPipelineRunInvokedByInfo() { }
        public string Id { get { throw null; } }
        public string InvokedByType { get { throw null; } }
        public string Name { get { throw null; } }
        public string PipelineName { get { throw null; } }
        public System.Guid? PipelineRunId { get { throw null; } }
    }
    public partial class FactoryPrivateEndpointConnectionCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public FactoryPrivateEndpointConnectionCreateOrUpdateContent() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.PrivateLinkConnectionApprovalRequest Properties { get { throw null; } set { } }
    }
    public partial class FactoryPrivateEndpointProperties
    {
        public FactoryPrivateEndpointProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class FactoryPrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public FactoryPrivateLinkResource() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryPrivateLinkResourceProperties Properties { get { throw null; } set { } }
    }
    public partial class FactoryPrivateLinkResourceProperties
    {
        public FactoryPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FactoryPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.DataFactory.Models.FactoryPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FactoryPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.FactoryPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.FactoryPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.FactoryPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.FactoryPublicNetworkAccess left, Azure.ResourceManager.DataFactory.Models.FactoryPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.FactoryPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.FactoryPublicNetworkAccess left, Azure.ResourceManager.DataFactory.Models.FactoryPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class FactoryRepoConfiguration
    {
        protected FactoryRepoConfiguration(string accountName, string repositoryName, string collaborationBranch, string rootFolder) { }
        public string AccountName { get { throw null; } set { } }
        public string CollaborationBranch { get { throw null; } set { } }
        public string LastCommitId { get { throw null; } set { } }
        public string RepositoryName { get { throw null; } set { } }
        public string RootFolder { get { throw null; } set { } }
    }
    public partial class FactoryRepoUpdate
    {
        public FactoryRepoUpdate() { }
        public Azure.Core.ResourceIdentifier FactoryResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryRepoConfiguration RepoConfiguration { get { throw null; } set { } }
    }
    public abstract partial class FactorySecretBaseDefinition
    {
        protected FactorySecretBaseDefinition() { }
    }
    public partial class FactorySecretString : Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition
    {
        public FactorySecretString(string value) { }
        public string Value { get { throw null; } set { } }
    }
    public partial class FactoryTriggerDefinition
    {
        public FactoryTriggerDefinition() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Annotations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryTriggerRuntimeState? RuntimeState { get { throw null; } }
    }
    public partial class FactoryTriggerReference
    {
        public FactoryTriggerReference(Azure.ResourceManager.DataFactory.Models.FactoryTriggerReferenceType referenceType, string referenceName) { }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryTriggerReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FactoryTriggerReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.FactoryTriggerReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FactoryTriggerReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.FactoryTriggerReferenceType TriggerReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.FactoryTriggerReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.FactoryTriggerReferenceType left, Azure.ResourceManager.DataFactory.Models.FactoryTriggerReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.FactoryTriggerReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.FactoryTriggerReferenceType left, Azure.ResourceManager.DataFactory.Models.FactoryTriggerReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FactoryTriggerRun
    {
        internal FactoryTriggerRun() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> DependencyStatus { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> RunDimension { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryTriggerRunStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TriggeredPipelines { get { throw null; } }
        public string TriggerName { get { throw null; } }
        public string TriggerRunId { get { throw null; } }
        public System.DateTimeOffset? TriggerRunTimestamp { get { throw null; } }
        public string TriggerType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FactoryTriggerRunStatus : System.IEquatable<Azure.ResourceManager.DataFactory.Models.FactoryTriggerRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FactoryTriggerRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.FactoryTriggerRunStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.FactoryTriggerRunStatus Inprogress { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.FactoryTriggerRunStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.FactoryTriggerRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.FactoryTriggerRunStatus left, Azure.ResourceManager.DataFactory.Models.FactoryTriggerRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.FactoryTriggerRunStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.FactoryTriggerRunStatus left, Azure.ResourceManager.DataFactory.Models.FactoryTriggerRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FactoryTriggerRuntimeState : System.IEquatable<Azure.ResourceManager.DataFactory.Models.FactoryTriggerRuntimeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FactoryTriggerRuntimeState(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.FactoryTriggerRuntimeState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.FactoryTriggerRuntimeState Started { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.FactoryTriggerRuntimeState Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.FactoryTriggerRuntimeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.FactoryTriggerRuntimeState left, Azure.ResourceManager.DataFactory.Models.FactoryTriggerRuntimeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.FactoryTriggerRuntimeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.FactoryTriggerRuntimeState left, Azure.ResourceManager.DataFactory.Models.FactoryTriggerRuntimeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FactoryTriggerSubscriptionOperationResult
    {
        internal FactoryTriggerSubscriptionOperationResult() { }
        public Azure.ResourceManager.DataFactory.Models.EventSubscriptionStatus? Status { get { throw null; } }
        public string TriggerName { get { throw null; } }
    }
    public partial class FactoryVstsConfiguration : Azure.ResourceManager.DataFactory.Models.FactoryRepoConfiguration
    {
        public FactoryVstsConfiguration(string accountName, string repositoryName, string collaborationBranch, string rootFolder, string projectName) : base (default(string), default(string), default(string), default(string)) { }
        public string ProjectName { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class FactoryWranglingDataFlowDefinition : Azure.ResourceManager.DataFactory.Models.FactoryDataFlowDefinition
    {
        public FactoryWranglingDataFlowDefinition() { }
        public string DocumentLocale { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PowerQuerySource> Sources { get { throw null; } }
    }
    public partial class FailActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public FailActivity(string name, System.BinaryData message, System.BinaryData errorCode) : base (default(string)) { }
        public System.BinaryData ErrorCode { get { throw null; } set { } }
        public System.BinaryData Message { get { throw null; } set { } }
    }
    public partial class FileServerLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public FileServerLinkedService(System.BinaryData host) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData UserId { get { throw null; } set { } }
    }
    public partial class FileServerLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public FileServerLocation() { }
    }
    public partial class FileServerReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public FileServerReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileFilter { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class FileServerWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public FileServerWriteSettings() { }
    }
    public partial class FileShareDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public FileShareDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public System.BinaryData FileFilter { get { throw null; } set { } }
        public System.BinaryData FileName { get { throw null; } set { } }
        public System.BinaryData FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
    }
    public partial class FileSystemSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public FileSystemSink() { }
        public System.BinaryData CopyBehavior { get { throw null; } set { } }
    }
    public partial class FileSystemSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public FileSystemSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
    }
    public partial class FilterActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public FilterActivity(string name, Azure.ResourceManager.DataFactory.Models.FactoryExpressionDefinition items, Azure.ResourceManager.DataFactory.Models.FactoryExpressionDefinition condition) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.FactoryExpressionDefinition Condition { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryExpressionDefinition Items { get { throw null; } set { } }
    }
    public partial class ForEachActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public ForEachActivity(string name, Azure.ResourceManager.DataFactory.Models.FactoryExpressionDefinition items, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.PipelineActivity> activities) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivity> Activities { get { throw null; } }
        public int? BatchCount { get { throw null; } set { } }
        public bool? IsSequential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryExpressionDefinition Items { get { throw null; } set { } }
    }
    public partial class FormatReadSettings
    {
        public FormatReadSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
    }
    public partial class FormatWriteSettings
    {
        public FormatWriteSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FtpAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FtpAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType left, Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType left, Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FtpReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public FtpReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public System.BinaryData DisableChunking { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public bool? UseBinaryTransfer { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class FtpServerLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public FtpServerLinkedService(System.BinaryData host) { }
        public Azure.ResourceManager.DataFactory.Models.FtpAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EnableServerCertificateValidation { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class FtpServerLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public FtpServerLocation() { }
    }
    public partial class GetDatasetMetadataActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public GetDatasetMetadataActivity(string name, Azure.ResourceManager.DataFactory.Models.DatasetReference dataset) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetReference Dataset { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> FieldList { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FormatReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class GetSsisObjectMetadataContent
    {
        public GetSsisObjectMetadataContent() { }
        public string MetadataPath { get { throw null; } set { } }
    }
    public partial class GitHubAccessTokenContent
    {
        public GitHubAccessTokenContent(string gitHubAccessCode, System.Uri gitHubAccessTokenBaseUri) { }
        public string GitHubAccessCode { get { throw null; } }
        public System.Uri GitHubAccessTokenBaseUri { get { throw null; } }
        public string GitHubClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.GitHubClientSecret GitHubClientSecret { get { throw null; } set { } }
    }
    public partial class GitHubAccessTokenResult
    {
        internal GitHubAccessTokenResult() { }
        public string GitHubAccessToken { get { throw null; } }
    }
    public partial class GitHubClientSecret
    {
        public GitHubClientSecret() { }
        public System.Uri ByoaSecretAkvUri { get { throw null; } set { } }
        public string ByoaSecretName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GoogleAdWordsAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GoogleAdWordsAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType ServiceAuthentication { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType UserAuthentication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType left, Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType left, Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GoogleAdWordsLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public GoogleAdWordsLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.GoogleAdWordsAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ClientCustomerId { get { throw null; } set { } }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition DeveloperToken { get { throw null; } set { } }
        public System.BinaryData Email { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData KeyFilePath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition RefreshToken { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class GoogleAdWordsObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public GoogleAdWordsObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class GoogleAdWordsSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public GoogleAdWordsSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GoogleBigQueryAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GoogleBigQueryAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType ServiceAuthentication { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType UserAuthentication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType left, Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType left, Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GoogleBigQueryLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public GoogleBigQueryLinkedService(System.BinaryData project, Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType authenticationType) { }
        public System.BinaryData AdditionalProjects { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.GoogleBigQueryAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public System.BinaryData Email { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData KeyFilePath { get { throw null; } set { } }
        public System.BinaryData Project { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition RefreshToken { get { throw null; } set { } }
        public System.BinaryData RequestGoogleDriveScope { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class GoogleBigQueryObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public GoogleBigQueryObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Dataset { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class GoogleBigQuerySource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public GoogleBigQuerySource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class GoogleCloudStorageLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public GoogleCloudStorageLinkedService() { }
        public System.BinaryData AccessKeyId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition SecretAccessKey { get { throw null; } set { } }
        public System.BinaryData ServiceUri { get { throw null; } set { } }
    }
    public partial class GoogleCloudStorageLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public GoogleCloudStorageLocation() { }
        public System.BinaryData BucketName { get { throw null; } set { } }
        public System.BinaryData Version { get { throw null; } set { } }
    }
    public partial class GoogleCloudStorageReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public GoogleCloudStorageReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Prefix { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class GreenplumLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public GreenplumLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class GreenplumSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public GreenplumSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class GreenplumTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public GreenplumTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HBaseAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HBaseAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType left, Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType left, Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HBaseLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public HBaseLinkedService(System.BinaryData host, Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType authenticationType) { }
        public System.BinaryData AllowHostNameCNMismatch { get { throw null; } set { } }
        public System.BinaryData AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.HBaseAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData HttpPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class HBaseObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public HBaseObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class HBaseSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public HBaseSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class HdfsLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public HdfsLinkedService(System.BinaryData uri) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class HdfsLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public HdfsLocation() { }
    }
    public partial class HdfsReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public HdfsReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DistcpSettings DistcpSettings { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class HdfsSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public HdfsSource() { }
        public Azure.ResourceManager.DataFactory.Models.DistcpSettings DistcpSettings { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightActivityDebugInfoOptionSetting : System.IEquatable<Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightActivityDebugInfoOptionSetting(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting Always { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting Failure { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting left, Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting left, Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightHiveActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public HDInsightHiveActivity(string name) : base (default(string)) { }
        public System.Collections.Generic.IList<System.BinaryData> Arguments { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Defines { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting? GetDebugInfo { get { throw null; } set { } }
        public int? QueryTimeout { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference ScriptLinkedService { get { throw null; } set { } }
        public System.BinaryData ScriptPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference> StorageLinkedServices { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Variables { get { throw null; } }
    }
    public partial class HDInsightLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public HDInsightLinkedService(System.BinaryData clusterUri) { }
        public System.BinaryData ClusterUri { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData FileSystem { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference HcatalogLinkedServiceName { get { throw null; } set { } }
        public System.BinaryData IsEspEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class HDInsightMapReduceActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public HDInsightMapReduceActivity(string name, System.BinaryData className, System.BinaryData jarFilePath) : base (default(string)) { }
        public System.Collections.Generic.IList<System.BinaryData> Arguments { get { throw null; } }
        public System.BinaryData ClassName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Defines { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting? GetDebugInfo { get { throw null; } set { } }
        public System.BinaryData JarFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> JarLibs { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference JarLinkedService { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference> StorageLinkedServices { get { throw null; } }
    }
    public partial class HDInsightOnDemandLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public HDInsightOnDemandLinkedService(System.BinaryData clusterSize, System.BinaryData timeToLiveExpression, System.BinaryData version, Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData hostSubscriptionId, System.BinaryData tenant, System.BinaryData clusterResourceGroup) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference> AdditionalLinkedServiceNames { get { throw null; } }
        public System.BinaryData ClusterNamePrefix { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ClusterPassword { get { throw null; } set { } }
        public System.BinaryData ClusterResourceGroup { get { throw null; } set { } }
        public System.BinaryData ClusterSize { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ClusterSshPassword { get { throw null; } set { } }
        public System.BinaryData ClusterSshUserName { get { throw null; } set { } }
        public System.BinaryData ClusterType { get { throw null; } set { } }
        public System.BinaryData ClusterUserName { get { throw null; } set { } }
        public System.BinaryData CoreConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData DataNodeSize { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData HBaseConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference HcatalogLinkedServiceName { get { throw null; } set { } }
        public System.BinaryData HdfsConfiguration { get { throw null; } set { } }
        public System.BinaryData HeadNodeSize { get { throw null; } set { } }
        public System.BinaryData HiveConfiguration { get { throw null; } set { } }
        public System.BinaryData HostSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public System.BinaryData MapReduceConfiguration { get { throw null; } set { } }
        public System.BinaryData OozieConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.ScriptAction> ScriptActions { get { throw null; } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData SparkVersion { get { throw null; } set { } }
        public System.BinaryData StormConfiguration { get { throw null; } set { } }
        public System.BinaryData SubnetName { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
        public System.BinaryData TimeToLiveExpression { get { throw null; } set { } }
        public System.BinaryData Version { get { throw null; } set { } }
        public System.BinaryData VirtualNetworkId { get { throw null; } set { } }
        public System.BinaryData YarnConfiguration { get { throw null; } set { } }
        public System.BinaryData ZookeeperNodeSize { get { throw null; } set { } }
    }
    public partial class HDInsightPigActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public HDInsightPigActivity(string name) : base (default(string)) { }
        public System.BinaryData Arguments { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Defines { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting? GetDebugInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference ScriptLinkedService { get { throw null; } set { } }
        public System.BinaryData ScriptPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference> StorageLinkedServices { get { throw null; } }
    }
    public partial class HDInsightSparkActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public HDInsightSparkActivity(string name, System.BinaryData rootPath, System.BinaryData entryFilePath) : base (default(string)) { }
        public System.Collections.Generic.IList<System.BinaryData> Arguments { get { throw null; } }
        public string ClassName { get { throw null; } set { } }
        public System.BinaryData EntryFilePath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting? GetDebugInfo { get { throw null; } set { } }
        public System.BinaryData ProxyUser { get { throw null; } set { } }
        public System.BinaryData RootPath { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> SparkConfig { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference SparkJobLinkedService { get { throw null; } set { } }
    }
    public partial class HDInsightStreamingActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public HDInsightStreamingActivity(string name, System.BinaryData mapper, System.BinaryData reducer, System.BinaryData input, System.BinaryData output, System.Collections.Generic.IEnumerable<System.BinaryData> filePaths) : base (default(string)) { }
        public System.Collections.Generic.IList<System.BinaryData> Arguments { get { throw null; } }
        public System.BinaryData Combiner { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> CommandEnvironment { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Defines { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference FileLinkedService { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> FilePaths { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.HDInsightActivityDebugInfoOptionSetting? GetDebugInfo { get { throw null; } set { } }
        public System.BinaryData Input { get { throw null; } set { } }
        public System.BinaryData Mapper { get { throw null; } set { } }
        public System.BinaryData Output { get { throw null; } set { } }
        public System.BinaryData Reducer { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference> StorageLinkedServices { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HiveAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HiveAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType Username { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType UsernameAndPassword { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType WindowsAzureHDInsightService { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType left, Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType left, Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HiveLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public HiveLinkedService(System.BinaryData host, Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType authenticationType) { }
        public System.BinaryData AllowHostNameCNMismatch { get { throw null; } set { } }
        public System.BinaryData AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.HiveAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData HttpPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.HiveServerType? ServerType { get { throw null; } set { } }
        public System.BinaryData ServiceDiscoveryMode { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol? ThriftTransportProtocol { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData UseNativeQuery { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
        public System.BinaryData UseSystemTrustStore { get { throw null; } set { } }
        public System.BinaryData ZooKeeperNameSpace { get { throw null; } set { } }
    }
    public partial class HiveObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public HiveObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HiveServerType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.HiveServerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HiveServerType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.HiveServerType HiveServer1 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HiveServerType HiveServer2 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HiveServerType HiveThriftServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.HiveServerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.HiveServerType left, Azure.ResourceManager.DataFactory.Models.HiveServerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.HiveServerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.HiveServerType left, Azure.ResourceManager.DataFactory.Models.HiveServerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HiveSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public HiveSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HiveThriftTransportProtocol : System.IEquatable<Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HiveThriftTransportProtocol(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol Binary { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol Sasl { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol left, Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol left, Azure.ResourceManager.DataFactory.Models.HiveThriftTransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType ClientCertificate { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType Digest { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType left, Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType left, Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HttpFileDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public HttpFileDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData AdditionalHeaders { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public System.BinaryData RelativeUri { get { throw null; } set { } }
        public System.BinaryData RequestBody { get { throw null; } set { } }
        public System.BinaryData RequestMethod { get { throw null; } set { } }
    }
    public partial class HttpFileSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public HttpFileSource() { }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
    }
    public partial class HttpLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public HttpLinkedService(System.BinaryData uri) { }
        public Azure.ResourceManager.DataFactory.Models.HttpAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData AuthHeaders { get { throw null; } set { } }
        public System.BinaryData CertThumbprint { get { throw null; } set { } }
        public System.BinaryData EmbeddedCertData { get { throw null; } set { } }
        public System.BinaryData EnableServerCertificateValidation { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class HttpReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public HttpReadSettings() { }
        public System.BinaryData AdditionalHeaders { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData RequestBody { get { throw null; } set { } }
        public System.BinaryData RequestMethod { get { throw null; } set { } }
        public System.BinaryData RequestTimeout { get { throw null; } set { } }
    }
    public partial class HttpServerLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public HttpServerLocation() { }
        public System.BinaryData RelativeUri { get { throw null; } set { } }
    }
    public partial class HubspotLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public HubspotLinkedService(System.BinaryData clientId) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition AccessToken { get { throw null; } set { } }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition RefreshToken { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class HubspotObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public HubspotObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class HubspotSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public HubspotSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class IfConditionActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public IfConditionActivity(string name, Azure.ResourceManager.DataFactory.Models.FactoryExpressionDefinition expression) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.FactoryExpressionDefinition Expression { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivity> IfFalseActivities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivity> IfTrueActivities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImpalaAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImpalaAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType SaslUsername { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType UsernameAndPassword { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImpalaLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public ImpalaLinkedService(System.BinaryData host, Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType authenticationType) { }
        public System.BinaryData AllowHostNameCNMismatch { get { throw null; } set { } }
        public System.BinaryData AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ImpalaAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
        public System.BinaryData UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class ImpalaObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public ImpalaObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class ImpalaSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ImpalaSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class ImportSettings
    {
        public ImportSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
    }
    public partial class InformixLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public InformixLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class InformixSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public InformixSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class InformixSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public InformixSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class InformixTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public InformixTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeAuthKeyName : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeAuthKeyName(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName AuthKey1 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName AuthKey2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeAuthKeys
    {
        internal IntegrationRuntimeAuthKeys() { }
        public string AuthKey1 { get { throw null; } }
        public string AuthKey2 { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeAutoUpdate : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeAutoUpdate(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate Off { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeComputeProperties
    {
        public IntegrationRuntimeComputeProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeDataFlowProperties DataFlowProperties { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public int? MaxParallelExecutionsPerNode { get { throw null; } set { } }
        public string NodeSize { get { throw null; } set { } }
        public int? NumberOfNodes { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeVNetProperties VNetProperties { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeConnectionInfo
    {
        internal IntegrationRuntimeConnectionInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Uri HostServiceUri { get { throw null; } }
        public string IdentityCertThumbprint { get { throw null; } }
        public bool? IsIdentityCertExprired { get { throw null; } }
        public string PublicKey { get { throw null; } }
        public string ServiceToken { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class IntegrationRuntimeCustomSetupScriptProperties
    {
        public IntegrationRuntimeCustomSetupScriptProperties() { }
        public System.Uri BlobContainerUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretString SasToken { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeDataFlowProperties
    {
        public IntegrationRuntimeDataFlowProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DataFlowComputeType? ComputeType { get { throw null; } set { } }
        public int? CoreCount { get { throw null; } set { } }
        public bool? ShouldCleanupAfterTtl { get { throw null; } set { } }
        public int? TimeToLiveInMinutes { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeDataProxyProperties
    {
        public IntegrationRuntimeDataProxyProperties() { }
        public Azure.ResourceManager.DataFactory.Models.EntityReference ConnectVia { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.EntityReference StagingLinkedService { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeDefinition
    {
        public IntegrationRuntimeDefinition() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Description { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeEdition : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeEdition(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition Enterprise { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeEntityReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeEntityReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType IntegrationRuntimeReference { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType LinkedServiceReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEntityReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeInternalChannelEncryptionMode : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeInternalChannelEncryptionMode(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode NotEncrypted { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode NotSet { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode SslEncrypted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeLicenseType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType BasePrice { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType LicenseIncluded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeMonitoringData
    {
        internal IntegrationRuntimeMonitoringData() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeNodeMonitoringData> Nodes { get { throw null; } }
    }
    public partial class IntegrationRuntimeNodeIPAddress
    {
        internal IntegrationRuntimeNodeIPAddress() { }
        public System.Net.IPAddress IPAddress { get { throw null; } }
    }
    public partial class IntegrationRuntimeNodeMonitoringData
    {
        internal IntegrationRuntimeNodeMonitoringData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? AvailableMemoryInMB { get { throw null; } }
        public int? ConcurrentJobsLimit { get { throw null; } }
        public int? ConcurrentJobsRunning { get { throw null; } }
        public int? CpuUtilization { get { throw null; } }
        public int? MaxConcurrentJobs { get { throw null; } }
        public string NodeName { get { throw null; } }
        public float? ReceivedBytes { get { throw null; } }
        public float? SentBytes { get { throw null; } }
    }
    public partial class IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint
    {
        internal IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeOutboundNetworkDependenciesEndpoint> Endpoints { get { throw null; } }
    }
    public partial class IntegrationRuntimeOutboundNetworkDependenciesEndpoint
    {
        internal IntegrationRuntimeOutboundNetworkDependenciesEndpoint() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeOutboundNetworkDependenciesEndpointDetails> EndpointDetails { get { throw null; } }
    }
    public partial class IntegrationRuntimeOutboundNetworkDependenciesEndpointDetails
    {
        internal IntegrationRuntimeOutboundNetworkDependenciesEndpointDetails() { }
        public int? Port { get { throw null; } }
    }
    public partial class IntegrationRuntimeReference
    {
        public IntegrationRuntimeReference(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType referenceType, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType IntegrationRuntimeReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeRegenerateKeyContent
    {
        public IntegrationRuntimeRegenerateKeyContent() { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAuthKeyName? KeyName { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeSsisCatalogInfo
    {
        public IntegrationRuntimeSsisCatalogInfo() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretString CatalogAdminPassword { get { throw null; } set { } }
        public string CatalogAdminUserName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier? CatalogPricingTier { get { throw null; } set { } }
        public string CatalogServerEndpoint { get { throw null; } set { } }
        public string DualStandbyPairName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeSsisCatalogPricingTier : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeSsisCatalogPricingTier(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier Premium { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier PremiumRS { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogPricingTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeSsisPackageStore
    {
        public IntegrationRuntimeSsisPackageStore(string name, Azure.ResourceManager.DataFactory.Models.EntityReference packageStoreLinkedService) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.EntityReference PackageStoreLinkedService { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeSsisProperties
    {
        public IntegrationRuntimeSsisProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisCatalogInfo CatalogInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeCustomSetupScriptProperties CustomSetupScriptProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeDataProxyProperties DataProxyProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeEdition? Edition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.CustomSetupBase> ExpressCustomSetupProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeLicenseType? LicenseType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisPackageStore> PackageStores { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeState : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeState(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState AccessDenied { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Initial { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Limited { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState NeedRegistration { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Offline { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Online { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Started { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Starting { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Stopped { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeStatus
    {
        internal IntegrationRuntimeStatus() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string DataFactoryName { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState? State { get { throw null; } }
    }
    public partial class IntegrationRuntimeStatusResult
    {
        internal IntegrationRuntimeStatusResult() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatus Properties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeUpdateResult : System.IEquatable<Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeUpdateResult(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult Fail { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult None { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult Succeed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult left, Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeVNetProperties
    {
        public IntegrationRuntimeVNetProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<string> PublicIPs { get { throw null; } }
        public string Subnet { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public System.Guid? VnetId { get { throw null; } set { } }
    }
    public partial class JiraLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public JiraLinkedService(System.BinaryData host, System.BinaryData username) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class JiraObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public JiraObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class JiraSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public JiraSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class JsonDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public JsonDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
        public System.BinaryData EncodingName { get { throw null; } set { } }
    }
    public partial class JsonReadSettings : Azure.ResourceManager.DataFactory.Models.FormatReadSettings
    {
        public JsonReadSettings() { }
        public Azure.ResourceManager.DataFactory.Models.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
    }
    public partial class JsonSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public JsonSink() { }
        public Azure.ResourceManager.DataFactory.Models.JsonWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class JsonSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public JsonSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.JsonReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class JsonWriteSettings : Azure.ResourceManager.DataFactory.Models.FormatWriteSettings
    {
        public JsonWriteSettings() { }
        public System.BinaryData FilePattern { get { throw null; } set { } }
    }
    public partial class LinkedIntegrationRuntime
    {
        internal LinkedIntegrationRuntime() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.AzureLocation? DataFactoryLocation { get { throw null; } }
        public string DataFactoryName { get { throw null; } }
        public string Name { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class LinkedIntegrationRuntimeContent
    {
        public LinkedIntegrationRuntimeContent(string linkedFactoryName) { }
        public string LinkedFactoryName { get { throw null; } }
    }
    public partial class LinkedIntegrationRuntimeKeyAuthorization : Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntimeType
    {
        public LinkedIntegrationRuntimeKeyAuthorization(Azure.ResourceManager.DataFactory.Models.FactorySecretString key) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretString Key { get { throw null; } set { } }
    }
    public partial class LinkedIntegrationRuntimeRbacAuthorization : Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntimeType
    {
        public LinkedIntegrationRuntimeRbacAuthorization(string resourceId) { }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public abstract partial class LinkedIntegrationRuntimeType
    {
        protected LinkedIntegrationRuntimeType() { }
    }
    public partial class LogLocationSettings
    {
        public LogLocationSettings(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) { }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class LogSettings
    {
        public LogSettings(Azure.ResourceManager.DataFactory.Models.LogLocationSettings logLocationSettings) { }
        public Azure.ResourceManager.DataFactory.Models.CopyActivityLogSettings CopyActivityLogSettings { get { throw null; } set { } }
        public System.BinaryData EnableCopyActivityLog { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LogLocationSettings LogLocationSettings { get { throw null; } set { } }
    }
    public partial class LogStorageSettings
    {
        public LogStorageSettings(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData EnableReliableLogging { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public System.BinaryData LogLevel { get { throw null; } set { } }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class LookupActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public LookupActivity(string name, Azure.ResourceManager.DataFactory.Models.CopyActivitySource source, Azure.ResourceManager.DataFactory.Models.DatasetReference dataset) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetReference Dataset { get { throw null; } set { } }
        public System.BinaryData FirstRowOnly { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.CopyActivitySource Source { get { throw null; } set { } }
    }
    public partial class MagentoLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public MagentoLinkedService(System.BinaryData host) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition AccessToken { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class MagentoObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public MagentoObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class MagentoSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public MagentoSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class ManagedIntegrationRuntime : Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeDefinition
    {
        public ManagedIntegrationRuntime() { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeComputeProperties ComputeProperties { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CustomerVirtualNetworkSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReference ManagedVirtualNetwork { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeSsisProperties SsisProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeState? State { get { throw null; } }
    }
    public partial class ManagedIntegrationRuntimeError
    {
        internal ManagedIntegrationRuntimeError() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Parameters { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public partial class ManagedIntegrationRuntimeNode
    {
        internal ManagedIntegrationRuntimeNode() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeError> Errors { get { throw null; } }
        public string NodeId { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedIntegrationRuntimeNodeStatus : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedIntegrationRuntimeNodeStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus Available { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus Recycling { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNodeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedIntegrationRuntimeOperationResult
    {
        internal ManagedIntegrationRuntimeOperationResult() { }
        public string ActivityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ManagedIntegrationRuntimeOperationResultType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Parameters { get { throw null; } }
        public string Result { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class ManagedIntegrationRuntimeStatus : Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatus
    {
        internal ManagedIntegrationRuntimeStatus() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeOperationResult LastOperation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeNode> Nodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.ManagedIntegrationRuntimeError> OtherErrors { get { throw null; } }
    }
    public partial class ManagedPrivateEndpoint
    {
        public ManagedPrivateEndpoint() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.ConnectionStateProperties ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Fqdns { get { throw null; } }
        public string GroupId { get { throw null; } set { } }
        public bool? IsReserved { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ManagedVirtualNetwork
    {
        public ManagedVirtualNetwork() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Alias { get { throw null; } }
        public System.Guid? VnetId { get { throw null; } }
    }
    public partial class ManagedVirtualNetworkReference
    {
        public ManagedVirtualNetworkReference(Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType referenceType, string referenceName) { }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedVirtualNetworkReferenceType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedVirtualNetworkReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType ManagedVirtualNetworkReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType left, Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType left, Azure.ResourceManager.DataFactory.Models.ManagedVirtualNetworkReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MariaDBLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public MariaDBLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class MariaDBSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public MariaDBSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class MariaDBTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public MariaDBTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class MarketoLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public MarketoLinkedService(System.BinaryData endpoint, System.BinaryData clientId) { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class MarketoObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public MarketoObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class MarketoSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public MarketoSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class MicrosoftAccessLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public MicrosoftAccessLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class MicrosoftAccessSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public MicrosoftAccessSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class MicrosoftAccessSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public MicrosoftAccessSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class MicrosoftAccessTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public MicrosoftAccessTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class MongoDBAtlasCollectionDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public MongoDBAtlasCollectionDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData collection) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Collection { get { throw null; } set { } }
    }
    public partial class MongoDBAtlasLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public MongoDBAtlasLinkedService(System.BinaryData connectionString, System.BinaryData database) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData Database { get { throw null; } set { } }
    }
    public partial class MongoDBAtlasSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public MongoDBAtlasSink() { }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class MongoDBAtlasSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public MongoDBAtlasSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData BatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MongoDBCursorMethodsProperties CursorMethods { get { throw null; } set { } }
        public System.BinaryData Filter { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoDBAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoDBAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType left, Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType left, Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoDBCollectionDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public MongoDBCollectionDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData collectionName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData CollectionName { get { throw null; } set { } }
    }
    public partial class MongoDBCursorMethodsProperties
    {
        public MongoDBCursorMethodsProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData Limit { get { throw null; } set { } }
        public System.BinaryData Project { get { throw null; } set { } }
        public System.BinaryData Skip { get { throw null; } set { } }
        public System.BinaryData Sort { get { throw null; } set { } }
    }
    public partial class MongoDBLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public MongoDBLinkedService(System.BinaryData server, System.BinaryData databaseName) { }
        public System.BinaryData AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MongoDBAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData AuthSource { get { throw null; } set { } }
        public System.BinaryData DatabaseName { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class MongoDBSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public MongoDBSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class MongoDBV2CollectionDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public MongoDBV2CollectionDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData collection) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Collection { get { throw null; } set { } }
    }
    public partial class MongoDBV2LinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public MongoDBV2LinkedService(System.BinaryData connectionString, System.BinaryData database) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData Database { get { throw null; } set { } }
    }
    public partial class MongoDBV2Sink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public MongoDBV2Sink() { }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class MongoDBV2Source : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public MongoDBV2Source() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData BatchSize { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.MongoDBCursorMethodsProperties CursorMethods { get { throw null; } set { } }
        public System.BinaryData Filter { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    public partial class MultiplePipelineTrigger : Azure.ResourceManager.DataFactory.Models.FactoryTriggerDefinition
    {
        public MultiplePipelineTrigger() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.TriggerPipelineReference> Pipelines { get { throw null; } }
    }
    public partial class MySqlLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public MySqlLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class MySqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public MySqlSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class MySqlTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public MySqlTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class NetezzaLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public NetezzaLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class NetezzaPartitionSettings
    {
        public NetezzaPartitionSettings() { }
        public System.BinaryData PartitionColumnName { get { throw null; } set { } }
        public System.BinaryData PartitionLowerBound { get { throw null; } set { } }
        public System.BinaryData PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class NetezzaSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public NetezzaSource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.NetezzaPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class NetezzaTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public NetezzaTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ODataAadServicePrincipalCredentialType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ODataAadServicePrincipalCredentialType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType ServicePrincipalCert { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType ServicePrincipalKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType left, Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType left, Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ODataAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ODataAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType AadServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType ManagedServiceIdentity { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ODataLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public ODataLinkedService(System.BinaryData uri) { }
        public System.BinaryData AadResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ODataAadServicePrincipalCredentialType? AadServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ODataAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData AuthHeaders { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalEmbeddedCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalEmbeddedCertPassword { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class ODataResourceDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public ODataResourceDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class ODataSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public ODataSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class OdbcLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public OdbcLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Credential { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class OdbcSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public OdbcSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class OdbcSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public OdbcSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class OdbcTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public OdbcTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class Office365Dataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public Office365Dataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData tableName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Predicate { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class Office365LinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public Office365LinkedService(System.BinaryData office365TenantId, System.BinaryData servicePrincipalTenantId, System.BinaryData servicePrincipalId, Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition servicePrincipalKey) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Office365TenantId { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalTenantId { get { throw null; } set { } }
    }
    public partial class Office365Source : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public Office365Source() { }
        public System.BinaryData AllowedGroups { get { throw null; } set { } }
        public System.BinaryData DateFilterColumn { get { throw null; } set { } }
        public System.BinaryData EndOn { get { throw null; } set { } }
        public System.BinaryData OutputColumns { get { throw null; } set { } }
        public System.BinaryData StartOn { get { throw null; } set { } }
        public System.BinaryData UserScopeFilterUri { get { throw null; } set { } }
    }
    public partial class OracleCloudStorageLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public OracleCloudStorageLinkedService() { }
        public System.BinaryData AccessKeyId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition SecretAccessKey { get { throw null; } set { } }
        public System.BinaryData ServiceUri { get { throw null; } set { } }
    }
    public partial class OracleCloudStorageLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public OracleCloudStorageLocation() { }
        public System.BinaryData BucketName { get { throw null; } set { } }
        public System.BinaryData Version { get { throw null; } set { } }
    }
    public partial class OracleCloudStorageReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public OracleCloudStorageReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Prefix { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class OracleLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public OracleLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class OraclePartitionSettings
    {
        public OraclePartitionSettings() { }
        public System.BinaryData PartitionColumnName { get { throw null; } set { } }
        public System.BinaryData PartitionLowerBound { get { throw null; } set { } }
        public System.BinaryData PartitionNames { get { throw null; } set { } }
        public System.BinaryData PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class OracleServiceCloudLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public OracleServiceCloudLinkedService(System.BinaryData host, System.BinaryData username, Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition password) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class OracleServiceCloudObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public OracleServiceCloudObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class OracleServiceCloudSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public OracleServiceCloudSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class OracleSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public OracleSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class OracleSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public OracleSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData OracleReaderQuery { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.OraclePartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    public partial class OracleTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public OracleTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class OrcDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public OrcDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
        public System.BinaryData OrcCompressionCodec { get { throw null; } set { } }
    }
    public partial class OrcSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public OrcSink() { }
        public Azure.ResourceManager.DataFactory.Models.OrcWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class OrcSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public OrcSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class OrcWriteSettings : Azure.ResourceManager.DataFactory.Models.FormatWriteSettings
    {
        public OrcWriteSettings() { }
        public System.BinaryData FileNamePrefix { get { throw null; } set { } }
        public System.BinaryData MaxRowsPerFile { get { throw null; } set { } }
    }
    public partial class ParquetDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public ParquetDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData CompressionCodec { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
    }
    public partial class ParquetSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public ParquetSink() { }
        public Azure.ResourceManager.DataFactory.Models.ParquetWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class ParquetSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public ParquetSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class ParquetWriteSettings : Azure.ResourceManager.DataFactory.Models.FormatWriteSettings
    {
        public ParquetWriteSettings() { }
        public System.BinaryData FileNamePrefix { get { throw null; } set { } }
        public System.BinaryData MaxRowsPerFile { get { throw null; } set { } }
    }
    public partial class PaypalLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public PaypalLinkedService(System.BinaryData host, System.BinaryData clientId) { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class PaypalObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public PaypalObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class PaypalSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public PaypalSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoenixAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoenixAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType UsernameAndPassword { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType WindowsAzureHDInsightService { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType left, Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType left, Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoenixLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public PhoenixLinkedService(System.BinaryData host, Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType authenticationType) { }
        public System.BinaryData AllowHostNameCNMismatch { get { throw null; } set { } }
        public System.BinaryData AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PhoenixAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData HttpPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
        public System.BinaryData UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class PhoenixObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public PhoenixObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class PhoenixSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public PhoenixSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class PipelineActivity
    {
        public PipelineActivity(string name) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.ActivityDependency> DependsOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.ActivityUserProperty> UserProperties { get { throw null; } }
    }
    public partial class PipelineCreateRunResult
    {
        internal PipelineCreateRunResult() { }
        public System.Guid RunId { get { throw null; } }
    }
    public partial class PipelineVariableSpecification
    {
        public PipelineVariableSpecification(Azure.ResourceManager.DataFactory.Models.PipelineVariableType variableType) { }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PipelineVariableType VariableType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineVariableType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.PipelineVariableType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineVariableType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.PipelineVariableType Array { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.PipelineVariableType Bool { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.PipelineVariableType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.PipelineVariableType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.PipelineVariableType left, Azure.ResourceManager.DataFactory.Models.PipelineVariableType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.PipelineVariableType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.PipelineVariableType left, Azure.ResourceManager.DataFactory.Models.PipelineVariableType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolybaseSettings
    {
        public PolybaseSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData RejectSampleValue { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType? RejectType { get { throw null; } set { } }
        public System.BinaryData RejectValue { get { throw null; } set { } }
        public System.BinaryData UseTypeDefault { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolybaseSettingsRejectType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolybaseSettingsRejectType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType Percentage { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType Value { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType left, Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType left, Azure.ResourceManager.DataFactory.Models.PolybaseSettingsRejectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public PostgreSqlLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class PostgreSqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public PostgreSqlSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class PostgreSqlTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public PostgreSqlTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class PowerQuerySink : Azure.ResourceManager.DataFactory.Models.DataFlowSink
    {
        public PowerQuerySink(string name) : base (default(string)) { }
        public string Script { get { throw null; } set { } }
    }
    public partial class PowerQuerySinkMapping
    {
        public PowerQuerySinkMapping() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PowerQuerySink> DataflowSinks { get { throw null; } }
        public string QueryName { get { throw null; } set { } }
    }
    public partial class PowerQuerySource : Azure.ResourceManager.DataFactory.Models.DataFlowSource
    {
        public PowerQuerySource(string name) : base (default(string)) { }
        public string Script { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrestoAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrestoAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType Ldap { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType left, Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType left, Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrestoLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public PrestoLinkedService(System.BinaryData host, System.BinaryData serverVersion, System.BinaryData catalog, Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType authenticationType) { }
        public System.BinaryData AllowHostNameCNMismatch { get { throw null; } set { } }
        public System.BinaryData AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PrestoAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData Catalog { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public System.BinaryData ServerVersion { get { throw null; } set { } }
        public System.BinaryData TimeZoneId { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
        public System.BinaryData UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class PrestoObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public PrestoObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class PrestoSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public PrestoSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class PrivateLinkConnectionApprovalRequest
    {
        public PrivateLinkConnectionApprovalRequest() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
    }
    public partial class PrivateLinkConnectionState
    {
        public PrivateLinkConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class QuickbaseLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public QuickbaseLinkedService(System.BinaryData uri, Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition userToken) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition UserToken { get { throw null; } set { } }
    }
    public partial class QuickBooksLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public QuickBooksLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition AccessToken { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition AccessTokenSecret { get { throw null; } set { } }
        public System.BinaryData CompanyId { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public System.BinaryData ConsumerKey { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ConsumerSecret { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
    }
    public partial class QuickBooksObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public QuickBooksObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class QuickBooksSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public QuickBooksSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecurrenceFrequency : System.IEquatable<Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecurrenceFrequency(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency Day { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency Hour { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency Minute { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency Month { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency Week { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency Year { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency left, Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency left, Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecurrenceSchedule
    {
        public RecurrenceSchedule() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<int> MonthDays { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.RecurrenceScheduleOccurrence> MonthlyOccurrences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.FactoryDayOfWeek> WeekDays { get { throw null; } }
    }
    public partial class RecurrenceScheduleOccurrence
    {
        public RecurrenceScheduleOccurrence() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.DayOfWeek? Day { get { throw null; } set { } }
        public int? Occurrence { get { throw null; } set { } }
    }
    public partial class RedirectIncompatibleRowSettings
    {
        public RedirectIncompatibleRowSettings(System.BinaryData linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData LinkedServiceName { get { throw null; } set { } }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class RedshiftUnloadSettings
    {
        public RedshiftUnloadSettings(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference s3LinkedServiceName, System.BinaryData bucketName) { }
        public System.BinaryData BucketName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference S3LinkedServiceName { get { throw null; } set { } }
    }
    public partial class RelationalSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public RelationalSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class RelationalTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public RelationalTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class RerunTumblingWindowTrigger : Azure.ResourceManager.DataFactory.Models.FactoryTriggerDefinition
    {
        public RerunTumblingWindowTrigger(System.BinaryData parentTrigger, System.DateTimeOffset requestedStartOn, System.DateTimeOffset requestedEndOn, int rerunConcurrency) { }
        public System.BinaryData ParentTrigger { get { throw null; } set { } }
        public System.DateTimeOffset RequestedEndOn { get { throw null; } set { } }
        public System.DateTimeOffset RequestedStartOn { get { throw null; } set { } }
        public int RerunConcurrency { get { throw null; } set { } }
    }
    public partial class ResponsysLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public ResponsysLinkedService(System.BinaryData endpoint, System.BinaryData clientId) { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class ResponsysObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public ResponsysObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class ResponsysSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ResponsysSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class RestResourceDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public RestResourceDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData AdditionalHeaders { get { throw null; } set { } }
        public System.BinaryData PaginationRules { get { throw null; } set { } }
        public System.BinaryData RelativeUri { get { throw null; } set { } }
        public System.BinaryData RequestBody { get { throw null; } set { } }
        public System.BinaryData RequestMethod { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestServiceAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestServiceAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType AadServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType ManagedServiceIdentity { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType OAuth2ClientCredential { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType left, Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType left, Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestServiceLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public RestServiceLinkedService(System.BinaryData uri, Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType authenticationType) { }
        public System.BinaryData AadResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.RestServiceAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData AuthHeaders { get { throw null; } set { } }
        public System.BinaryData AzureCloudType { get { throw null; } set { } }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData EnableServerCertificateValidation { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Resource { get { throw null; } set { } }
        public System.BinaryData Scope { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData Tenant { get { throw null; } set { } }
        public System.BinaryData TokenEndpoint { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class RestSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public RestSink() { }
        public System.BinaryData AdditionalHeaders { get { throw null; } set { } }
        public System.BinaryData HttpCompressionType { get { throw null; } set { } }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
        public System.BinaryData RequestInterval { get { throw null; } set { } }
        public System.BinaryData RequestMethod { get { throw null; } set { } }
    }
    public partial class RestSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public RestSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData AdditionalHeaders { get { throw null; } set { } }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
        public System.BinaryData PaginationRules { get { throw null; } set { } }
        public System.BinaryData RequestBody { get { throw null; } set { } }
        public System.BinaryData RequestInterval { get { throw null; } set { } }
        public System.BinaryData RequestMethod { get { throw null; } set { } }
    }
    public partial class RetryPolicy
    {
        public RetryPolicy() { }
        public System.BinaryData Count { get { throw null; } set { } }
        public int? IntervalInSeconds { get { throw null; } set { } }
    }
    public partial class RunFilterContent
    {
        public RunFilterContent(System.DateTimeOffset lastUpdatedAfter, System.DateTimeOffset lastUpdatedBefore) { }
        public string ContinuationToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.RunQueryFilter> Filters { get { throw null; } }
        public System.DateTimeOffset LastUpdatedAfter { get { throw null; } }
        public System.DateTimeOffset LastUpdatedBefore { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.RunQueryOrderBy> OrderBy { get { throw null; } }
    }
    public partial class RunQueryFilter
    {
        public RunQueryFilter(Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand operand, Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand Operand { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator Operator { get { throw null; } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunQueryFilterOperand : System.IEquatable<Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunQueryFilterOperand(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand ActivityName { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand ActivityRunEnd { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand ActivityRunStart { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand ActivityType { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand LatestOnly { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand PipelineName { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand RunEnd { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand RunGroupId { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand RunStart { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand Status { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand TriggerName { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand TriggerRunTimestamp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand left, Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand left, Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperand right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunQueryFilterOperator : System.IEquatable<Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunQueryFilterOperator(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator In { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator NotEquals { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator NotIn { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator left, Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator left, Azure.ResourceManager.DataFactory.Models.RunQueryFilterOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunQueryOrder : System.IEquatable<Azure.ResourceManager.DataFactory.Models.RunQueryOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunQueryOrder(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrder Asc { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrder Desc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.RunQueryOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.RunQueryOrder left, Azure.ResourceManager.DataFactory.Models.RunQueryOrder right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.RunQueryOrder (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.RunQueryOrder left, Azure.ResourceManager.DataFactory.Models.RunQueryOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunQueryOrderBy
    {
        public RunQueryOrderBy(Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField orderBy, Azure.ResourceManager.DataFactory.Models.RunQueryOrder order) { }
        public Azure.ResourceManager.DataFactory.Models.RunQueryOrder Order { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField OrderBy { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunQueryOrderByField : System.IEquatable<Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunQueryOrderByField(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField ActivityName { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField ActivityRunEnd { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField ActivityRunStart { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField PipelineName { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField RunEnd { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField RunStart { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField Status { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField TriggerName { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField TriggerRunTimestamp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField left, Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField left, Azure.ResourceManager.DataFactory.Models.RunQueryOrderByField right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SalesforceLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SalesforceLinkedService() { }
        public System.BinaryData ApiVersion { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData EnvironmentUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition SecurityToken { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class SalesforceMarketingCloudLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SalesforceMarketingCloudLinkedService() { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class SalesforceMarketingCloudObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SalesforceMarketingCloudObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class SalesforceMarketingCloudSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SalesforceMarketingCloudSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SalesforceObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SalesforceObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData ObjectApiName { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SalesforceServiceCloudLinkedService() { }
        public System.BinaryData ApiVersion { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData EnvironmentUri { get { throw null; } set { } }
        public System.BinaryData ExtendedProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition SecurityToken { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SalesforceServiceCloudObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData ObjectApiName { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SalesforceServiceCloudSink() { }
        public System.BinaryData ExternalIdFieldName { get { throw null; } set { } }
        public System.BinaryData IgnoreNullValues { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior? WriteBehavior { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public SalesforceServiceCloudSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior? ReadBehavior { get { throw null; } set { } }
    }
    public partial class SalesforceSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SalesforceSink() { }
        public System.BinaryData ExternalIdFieldName { get { throw null; } set { } }
        public System.BinaryData IgnoreNullValues { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior? WriteBehavior { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SalesforceSinkWriteBehavior : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SalesforceSinkWriteBehavior(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior Insert { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior Upsert { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior left, Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior left, Azure.ResourceManager.DataFactory.Models.SalesforceSinkWriteBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SalesforceSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SalesforceSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior? ReadBehavior { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SalesforceSourceReadBehavior : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SalesforceSourceReadBehavior(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior Query { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior QueryAll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior left, Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior left, Azure.ResourceManager.DataFactory.Models.SalesforceSourceReadBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapBwCubeDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SapBwCubeDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
    }
    public partial class SapBWLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SapBWLinkedService(System.BinaryData server, System.BinaryData systemNumber, System.BinaryData clientId) { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData SystemNumber { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SapBwSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapBwSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SapCloudForCustomerLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SapCloudForCustomerLinkedService(System.BinaryData uri) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class SapCloudForCustomerResourceDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SapCloudForCustomerResourceDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData path) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class SapCloudForCustomerSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SapCloudForCustomerSink() { }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior? WriteBehavior { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapCloudForCustomerSinkWriteBehavior : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapCloudForCustomerSinkWriteBehavior(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior Insert { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior left, Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior left, Azure.ResourceManager.DataFactory.Models.SapCloudForCustomerSinkWriteBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapCloudForCustomerSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapCloudForCustomerSource() { }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SapEccLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SapEccLinkedService(System.Uri uri) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class SapEccResourceDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SapEccResourceDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData path) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class SapEccSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapEccSource() { }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapHanaAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapHanaAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapHanaLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SapHanaLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.SapHanaAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SapHanaSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapHanaSource() { }
        public System.BinaryData PacketSize { get { throw null; } set { } }
        public System.BinaryData PartitionColumnName { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SapHanaTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SapHanaTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
    }
    public partial class SapOdpLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SapOdpLinkedService() { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Language { get { throw null; } set { } }
        public System.BinaryData LogonGroup { get { throw null; } set { } }
        public System.BinaryData MessageServer { get { throw null; } set { } }
        public System.BinaryData MessageServerService { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData SncLibraryPath { get { throw null; } set { } }
        public System.BinaryData SncMode { get { throw null; } set { } }
        public System.BinaryData SncMyName { get { throw null; } set { } }
        public System.BinaryData SncPartnerName { get { throw null; } set { } }
        public System.BinaryData SncQop { get { throw null; } set { } }
        public System.BinaryData SubscriberName { get { throw null; } set { } }
        public System.BinaryData SystemId { get { throw null; } set { } }
        public System.BinaryData SystemNumber { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
        public System.BinaryData X509CertificatePath { get { throw null; } set { } }
    }
    public partial class SapOdpResourceDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SapOdpResourceDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData context, System.BinaryData objectName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Context { get { throw null; } set { } }
        public System.BinaryData ObjectName { get { throw null; } set { } }
    }
    public partial class SapOdpSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapOdpSource() { }
        public System.BinaryData ExtractionMode { get { throw null; } set { } }
        public System.BinaryData Projection { get { throw null; } set { } }
        public System.BinaryData Selection { get { throw null; } set { } }
        public System.BinaryData SubscriberProcess { get { throw null; } set { } }
    }
    public partial class SapOpenHubLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SapOpenHubLinkedService() { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Language { get { throw null; } set { } }
        public System.BinaryData LogonGroup { get { throw null; } set { } }
        public System.BinaryData MessageServer { get { throw null; } set { } }
        public System.BinaryData MessageServerService { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData SystemId { get { throw null; } set { } }
        public System.BinaryData SystemNumber { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SapOpenHubSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapOpenHubSource() { }
        public System.BinaryData BaseRequestId { get { throw null; } set { } }
        public System.BinaryData CustomRfcReadTableFunctionModule { get { throw null; } set { } }
        public System.BinaryData ExcludeLastRequest { get { throw null; } set { } }
        public System.BinaryData SapDataColumnDelimiter { get { throw null; } set { } }
    }
    public partial class SapOpenHubTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SapOpenHubTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData openHubDestinationName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData BaseRequestId { get { throw null; } set { } }
        public System.BinaryData ExcludeLastRequest { get { throw null; } set { } }
        public System.BinaryData OpenHubDestinationName { get { throw null; } set { } }
    }
    public partial class SapTableLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SapTableLinkedService() { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Language { get { throw null; } set { } }
        public System.BinaryData LogonGroup { get { throw null; } set { } }
        public System.BinaryData MessageServer { get { throw null; } set { } }
        public System.BinaryData MessageServerService { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData SncLibraryPath { get { throw null; } set { } }
        public System.BinaryData SncMode { get { throw null; } set { } }
        public System.BinaryData SncMyName { get { throw null; } set { } }
        public System.BinaryData SncPartnerName { get { throw null; } set { } }
        public System.BinaryData SncQop { get { throw null; } set { } }
        public System.BinaryData SystemId { get { throw null; } set { } }
        public System.BinaryData SystemNumber { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SapTablePartitionSettings
    {
        public SapTablePartitionSettings() { }
        public System.BinaryData MaxPartitionsNumber { get { throw null; } set { } }
        public System.BinaryData PartitionColumnName { get { throw null; } set { } }
        public System.BinaryData PartitionLowerBound { get { throw null; } set { } }
        public System.BinaryData PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class SapTableResourceDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SapTableResourceDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData tableName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class SapTableSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SapTableSource() { }
        public System.BinaryData BatchSize { get { throw null; } set { } }
        public System.BinaryData CustomRfcReadTableFunctionModule { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SapTablePartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData RfcTableFields { get { throw null; } set { } }
        public System.BinaryData RfcTableOptions { get { throw null; } set { } }
        public System.BinaryData RowCount { get { throw null; } set { } }
        public System.BinaryData RowSkips { get { throw null; } set { } }
        public System.BinaryData SapDataColumnDelimiter { get { throw null; } set { } }
    }
    public partial class ScheduleTrigger : Azure.ResourceManager.DataFactory.Models.MultiplePipelineTrigger
    {
        public ScheduleTrigger(Azure.ResourceManager.DataFactory.Models.ScheduleTriggerRecurrence recurrence) { }
        public Azure.ResourceManager.DataFactory.Models.ScheduleTriggerRecurrence Recurrence { get { throw null; } set { } }
    }
    public partial class ScheduleTriggerRecurrence
    {
        public ScheduleTriggerRecurrence() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.RecurrenceFrequency? Frequency { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.RecurrenceSchedule Schedule { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class ScriptAction
    {
        public ScriptAction(string name, System.Uri uri, System.BinaryData roles) { }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public System.BinaryData Roles { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ScriptActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public ScriptActivity(string name) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.ScriptActivityTypePropertiesLogSettings LogSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.ScriptActivityScriptBlock> Scripts { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptActivityLogDestination : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptActivityLogDestination(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination ActivityOutput { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination ExternalStore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination left, Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination left, Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptActivityParameter
    {
        public ScriptActivityParameter() { }
        public Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection? Direction { get { throw null; } set { } }
        public System.BinaryData Name { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType? ParameterType { get { throw null; } set { } }
        public int? Size { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptActivityParameterDirection : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptActivityParameterDirection(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection Input { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection InputOutput { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection Output { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection left, Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection left, Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptActivityParameterType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptActivityParameterType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Boolean { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType DateTime { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType DateTimeOffset { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Decimal { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Double { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Guid { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Int16 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Int32 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Int64 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType Single { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType String { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType TimeSpan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType left, Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType left, Azure.ResourceManager.DataFactory.Models.ScriptActivityParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptActivityScriptBlock
    {
        public ScriptActivityScriptBlock(System.BinaryData text, Azure.ResourceManager.DataFactory.Models.ScriptType scriptType) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.ScriptActivityParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.ScriptType ScriptType { get { throw null; } set { } }
        public System.BinaryData Text { get { throw null; } set { } }
    }
    public partial class ScriptActivityTypePropertiesLogSettings
    {
        public ScriptActivityTypePropertiesLogSettings(Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination logDestination) { }
        public Azure.ResourceManager.DataFactory.Models.ScriptActivityLogDestination LogDestination { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.LogLocationSettings LogLocationSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ScriptType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ScriptType NonQuery { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ScriptType Query { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ScriptType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ScriptType left, Azure.ResourceManager.DataFactory.Models.ScriptType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ScriptType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ScriptType left, Azure.ResourceManager.DataFactory.Models.ScriptType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelfDependencyTumblingWindowTriggerReference : Azure.ResourceManager.DataFactory.Models.DependencyReference
    {
        public SelfDependencyTumblingWindowTriggerReference(string offset) { }
        public string Offset { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
    }
    public partial class SelfHostedIntegrationRuntime : Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeDefinition
    {
        public SelfHostedIntegrationRuntime() { }
        public Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntimeType LinkedInfo { get { throw null; } set { } }
    }
    public partial class SelfHostedIntegrationRuntimeNode
    {
        internal SelfHostedIntegrationRuntimeNode() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public int? ConcurrentJobsLimit { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public System.Uri HostServiceUri { get { throw null; } }
        public bool? IsActiveDispatcher { get { throw null; } }
        public System.DateTimeOffset? LastConnectOn { get { throw null; } }
        public System.DateTimeOffset? LastEndUpdateOn { get { throw null; } }
        public System.DateTimeOffset? LastStartOn { get { throw null; } }
        public System.DateTimeOffset? LastStartUpdateOn { get { throw null; } }
        public System.DateTimeOffset? LastStopOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeUpdateResult? LastUpdateResult { get { throw null; } }
        public string MachineName { get { throw null; } }
        public int? MaxConcurrentJobs { get { throw null; } }
        public string NodeName { get { throw null; } }
        public System.DateTimeOffset? RegisterOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus? Status { get { throw null; } }
        public string Version { get { throw null; } }
        public string VersionStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelfHostedIntegrationRuntimeNodeStatus : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelfHostedIntegrationRuntimeNodeStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus InitializeFailed { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus Initializing { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus Limited { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus NeedRegistration { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus Online { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNodeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelfHostedIntegrationRuntimeStatus : Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeStatus
    {
        internal SelfHostedIntegrationRuntimeStatus() { }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeAutoUpdate? AutoUpdate { get { throw null; } }
        public System.DateTimeOffset? AutoUpdateEta { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeInternalChannelEncryptionMode? InternalChannelEncryption { get { throw null; } }
        public string LatestVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.LinkedIntegrationRuntime> Links { get { throw null; } }
        public System.TimeSpan? LocalTimeZoneOffset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.SelfHostedIntegrationRuntimeNode> Nodes { get { throw null; } }
        public string PushedVersion { get { throw null; } }
        public System.DateTimeOffset? ScheduledUpdateOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Uri> ServiceUris { get { throw null; } }
        public System.Guid? TaskQueueId { get { throw null; } }
        public System.TimeSpan? UpdateDelayOffset { get { throw null; } }
        public string Version { get { throw null; } }
        public string VersionStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceNowAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceNowAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType OAuth2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceNowLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public ServiceNowLinkedService(System.BinaryData endpoint, Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType authenticationType) { }
        public Azure.ResourceManager.DataFactory.Models.ServiceNowAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class ServiceNowObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public ServiceNowObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class ServiceNowSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ServiceNowSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SetVariableActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public SetVariableActivity(string name) : base (default(string)) { }
        public System.BinaryData Value { get { throw null; } set { } }
        public string VariableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SftpAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SftpAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType MultiFactor { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType SshPublicKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SftpLocation : Azure.ResourceManager.DataFactory.Models.DatasetLocation
    {
        public SftpLocation() { }
    }
    public partial class SftpReadSettings : Azure.ResourceManager.DataFactory.Models.StoreReadSettings
    {
        public SftpReadSettings() { }
        public System.BinaryData DeleteFilesAfterCompletion { get { throw null; } set { } }
        public System.BinaryData DisableChunking { get { throw null; } set { } }
        public bool? EnablePartitionDiscovery { get { throw null; } set { } }
        public System.BinaryData FileListPath { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeEnd { get { throw null; } set { } }
        public System.BinaryData ModifiedDatetimeStart { get { throw null; } set { } }
        public System.BinaryData PartitionRootPath { get { throw null; } set { } }
        public System.BinaryData Recursive { get { throw null; } set { } }
        public System.BinaryData WildcardFileName { get { throw null; } set { } }
        public System.BinaryData WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class SftpServerLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SftpServerLinkedService(System.BinaryData host) { }
        public Azure.ResourceManager.DataFactory.Models.SftpAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData HostKeyFingerprint { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition PassPhrase { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition PrivateKeyContent { get { throw null; } set { } }
        public System.BinaryData PrivateKeyPath { get { throw null; } set { } }
        public System.BinaryData SkipHostKeyValidation { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SftpWriteSettings : Azure.ResourceManager.DataFactory.Models.StoreWriteSettings
    {
        public SftpWriteSettings() { }
        public System.BinaryData OperationTimeout { get { throw null; } set { } }
        public System.BinaryData UseTempFileRename { get { throw null; } set { } }
    }
    public partial class SharePointOnlineListLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SharePointOnlineListLinkedService(System.BinaryData siteUri, System.BinaryData tenantId, System.BinaryData servicePrincipalId, Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition servicePrincipalKey) { }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
        public System.BinaryData SiteUri { get { throw null; } set { } }
        public System.BinaryData TenantId { get { throw null; } set { } }
    }
    public partial class SharePointOnlineListResourceDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SharePointOnlineListResourceDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData ListName { get { throw null; } set { } }
    }
    public partial class SharePointOnlineListSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public SharePointOnlineListSource() { }
        public System.BinaryData HttpRequestTimeout { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class ShopifyLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public ShopifyLinkedService(System.BinaryData host) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition AccessToken { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class ShopifyObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public ShopifyObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class ShopifySource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ShopifySource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SkipErrorFile
    {
        public SkipErrorFile() { }
        public System.BinaryData DataInconsistency { get { throw null; } set { } }
        public System.BinaryData FileMissing { get { throw null; } set { } }
    }
    public partial class SmartsheetLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SmartsheetLinkedService(Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition apiToken) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ApiToken { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
    }
    public partial class SnowflakeDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SnowflakeDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
    }
    public partial class SnowflakeExportCopyCommand : Azure.ResourceManager.DataFactory.Models.ExportSettings
    {
        public SnowflakeExportCopyCommand() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalCopyOptions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalFormatOptions { get { throw null; } }
    }
    public partial class SnowflakeImportCopyCommand : Azure.ResourceManager.DataFactory.Models.ImportSettings
    {
        public SnowflakeImportCopyCommand() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalCopyOptions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalFormatOptions { get { throw null; } }
    }
    public partial class SnowflakeLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SnowflakeLinkedService(System.BinaryData connectionString) { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class SnowflakeSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SnowflakeSink() { }
        public Azure.ResourceManager.DataFactory.Models.SnowflakeImportCopyCommand ImportSettings { get { throw null; } set { } }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
    }
    public partial class SnowflakeSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public SnowflakeSource() { }
        public Azure.ResourceManager.DataFactory.Models.SnowflakeExportCopyCommand ExportSettings { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType Anonymous { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType Username { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType UsernameAndPassword { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType WindowsAzureHDInsightService { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SparkLinkedService(System.BinaryData host, System.BinaryData port, Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType authenticationType) { }
        public System.BinaryData AllowHostNameCNMismatch { get { throw null; } set { } }
        public System.BinaryData AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SparkAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EnableSsl { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData HttpPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Port { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SparkServerType? ServerType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol? ThriftTransportProtocol { get { throw null; } set { } }
        public System.BinaryData TrustedCertPath { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
        public System.BinaryData UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class SparkObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SparkObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkServerType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SparkServerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkServerType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SparkServerType SharkServer { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SparkServerType SharkServer2 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SparkServerType SparkThriftServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SparkServerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SparkServerType left, Azure.ResourceManager.DataFactory.Models.SparkServerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SparkServerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SparkServerType left, Azure.ResourceManager.DataFactory.Models.SparkServerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SparkSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkThriftTransportProtocol : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkThriftTransportProtocol(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol Binary { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol Sasl { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol left, Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol left, Azure.ResourceManager.DataFactory.Models.SparkThriftTransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlAlwaysEncryptedAkvAuthType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlAlwaysEncryptedAkvAuthType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType left, Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType left, Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlAlwaysEncryptedProperties
    {
        public SqlAlwaysEncryptedProperties(Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType alwaysEncryptedAkvAuthType) { }
        public Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedAkvAuthType AlwaysEncryptedAkvAuthType { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public System.BinaryData ServicePrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ServicePrincipalKey { get { throw null; } set { } }
    }
    public partial class SqlDWSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SqlDWSink() { }
        public System.BinaryData AllowCopyCommand { get { throw null; } set { } }
        public System.BinaryData AllowPolyBase { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DWCopyCommandSettings CopyCommandSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.PolybaseSettings PolyBaseSettings { get { throw null; } set { } }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
        public System.BinaryData SqlWriterUseTableLock { get { throw null; } set { } }
        public System.BinaryData TableOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlDWUpsertSettings UpsertSettings { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class SqlDWSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SqlDWSource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData SqlReaderQuery { get { throw null; } set { } }
        public System.BinaryData SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class SqlDWUpsertSettings
    {
        public SqlDWUpsertSettings() { }
        public System.BinaryData InterimSchemaName { get { throw null; } set { } }
        public System.BinaryData Keys { get { throw null; } set { } }
    }
    public partial class SqlMISink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SqlMISink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
        public System.BinaryData SqlWriterStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData SqlWriterTableType { get { throw null; } set { } }
        public System.BinaryData SqlWriterUseTableLock { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
        public System.BinaryData StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public System.BinaryData TableOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class SqlMISource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SqlMISource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData ProduceAdditionalTypes { get { throw null; } set { } }
        public System.BinaryData SqlReaderQuery { get { throw null; } set { } }
        public System.BinaryData SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
    }
    public partial class SqlPartitionSettings
    {
        public SqlPartitionSettings() { }
        public System.BinaryData PartitionColumnName { get { throw null; } set { } }
        public System.BinaryData PartitionLowerBound { get { throw null; } set { } }
        public System.BinaryData PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class SqlServerLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SqlServerLinkedService(System.BinaryData connectionString) { }
        public Azure.ResourceManager.DataFactory.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SqlServerSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SqlServerSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
        public System.BinaryData SqlWriterStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData SqlWriterTableType { get { throw null; } set { } }
        public System.BinaryData SqlWriterUseTableLock { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
        public System.BinaryData StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public System.BinaryData TableOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class SqlServerSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SqlServerSource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData ProduceAdditionalTypes { get { throw null; } set { } }
        public System.BinaryData SqlReaderQuery { get { throw null; } set { } }
        public System.BinaryData SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
    }
    public partial class SqlServerStoredProcedureActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public SqlServerStoredProcedureActivity(string name, System.BinaryData storedProcedureName) : base (default(string)) { }
        public System.BinaryData StoredProcedureName { get { throw null; } set { } }
        public System.BinaryData StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class SqlServerTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SqlServerTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class SqlSink : Azure.ResourceManager.DataFactory.Models.CopySink
    {
        public SqlSink() { }
        public System.BinaryData PreCopyScript { get { throw null; } set { } }
        public System.BinaryData SqlWriterStoredProcedureName { get { throw null; } set { } }
        public System.BinaryData SqlWriterTableType { get { throw null; } set { } }
        public System.BinaryData SqlWriterUseTableLock { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
        public System.BinaryData StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public System.BinaryData TableOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public System.BinaryData WriteBehavior { get { throw null; } set { } }
    }
    public partial class SqlSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SqlSource() { }
        public System.BinaryData IsolationLevel { get { throw null; } set { } }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData SqlReaderQuery { get { throw null; } set { } }
        public System.BinaryData SqlReaderStoredProcedureName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameter> StoredProcedureParameters { get { throw null; } }
    }
    public partial class SqlUpsertSettings
    {
        public SqlUpsertSettings() { }
        public System.BinaryData InterimSchemaName { get { throw null; } set { } }
        public System.BinaryData Keys { get { throw null; } set { } }
        public System.BinaryData UseTempDB { get { throw null; } set { } }
    }
    public partial class SquareLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SquareLinkedService() { }
        public System.BinaryData ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ClientSecret { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public System.BinaryData RedirectUri { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class SquareObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SquareObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class SquareSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SquareSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SsisAccessCredential
    {
        public SsisAccessCredential(System.BinaryData domain, System.BinaryData userName, Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition password) { }
        public System.BinaryData Domain { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SsisChildPackage
    {
        public SsisChildPackage(System.BinaryData packagePath, System.BinaryData packageContent) { }
        public System.BinaryData PackageContent { get { throw null; } set { } }
        public string PackageLastModifiedDate { get { throw null; } set { } }
        public string PackageName { get { throw null; } set { } }
        public System.BinaryData PackagePath { get { throw null; } set { } }
    }
    public partial class SsisEnvironment : Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata
    {
        internal SsisEnvironment() { }
        public long? FolderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.SsisVariable> Variables { get { throw null; } }
    }
    public partial class SsisEnvironmentReference
    {
        internal SsisEnvironmentReference() { }
        public string EnvironmentFolderName { get { throw null; } }
        public string EnvironmentName { get { throw null; } }
        public long? Id { get { throw null; } }
        public string ReferenceType { get { throw null; } }
    }
    public partial class SsisExecutionCredential
    {
        public SsisExecutionCredential(System.BinaryData domain, System.BinaryData userName, Azure.ResourceManager.DataFactory.Models.FactorySecretString password) { }
        public System.BinaryData Domain { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretString Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SsisExecutionParameter
    {
        public SsisExecutionParameter(System.BinaryData value) { }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class SsisFolder : Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata
    {
        internal SsisFolder() { }
    }
    public partial class SsisLogLocation
    {
        public SsisLogLocation(System.BinaryData logPath, Azure.ResourceManager.DataFactory.Models.SsisLogLocationType locationType) { }
        public Azure.ResourceManager.DataFactory.Models.SsisAccessCredential AccessCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SsisLogLocationType LocationType { get { throw null; } set { } }
        public System.BinaryData LogPath { get { throw null; } set { } }
        public System.BinaryData LogRefreshInterval { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SsisLogLocationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SsisLogLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SsisLogLocationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SsisLogLocationType File { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SsisLogLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SsisLogLocationType left, Azure.ResourceManager.DataFactory.Models.SsisLogLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SsisLogLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SsisLogLocationType left, Azure.ResourceManager.DataFactory.Models.SsisLogLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class SsisObjectMetadata
    {
        protected SsisObjectMetadata() { }
        public string Description { get { throw null; } }
        public long? Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class SsisObjectMetadataStatusResult
    {
        internal SsisObjectMetadataStatusResult() { }
        public string Error { get { throw null; } }
        public string Name { get { throw null; } }
        public string Properties { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class SsisPackage : Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata
    {
        internal SsisPackage() { }
        public long? FolderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.SsisParameterInfo> Parameters { get { throw null; } }
        public long? ProjectId { get { throw null; } }
        public long? ProjectVersion { get { throw null; } }
    }
    public partial class SsisPackageLocation
    {
        public SsisPackageLocation() { }
        public Azure.ResourceManager.DataFactory.Models.SsisAccessCredential AccessCredential { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.SsisChildPackage> ChildPackages { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.SsisAccessCredential ConfigurationAccessCredential { get { throw null; } set { } }
        public System.BinaryData ConfigurationPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType? LocationType { get { throw null; } set { } }
        public System.BinaryData PackageContent { get { throw null; } set { } }
        public string PackageLastModifiedDate { get { throw null; } set { } }
        public string PackageName { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition PackagePassword { get { throw null; } set { } }
        public System.BinaryData PackagePath { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SsisPackageLocationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SsisPackageLocationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType File { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType InlinePackage { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType PackageStore { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType SsisDB { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType left, Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType left, Azure.ResourceManager.DataFactory.Models.SsisPackageLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SsisParameterInfo
    {
        internal SsisParameterInfo() { }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string DesignDefaultValue { get { throw null; } }
        public bool? HasValueSet { get { throw null; } }
        public long? Id { get { throw null; } }
        public bool? IsRequired { get { throw null; } }
        public bool? IsSensitive { get { throw null; } }
        public string Name { get { throw null; } }
        public string SensitiveDefaultValue { get { throw null; } }
        public string ValueType { get { throw null; } }
        public string Variable { get { throw null; } }
    }
    public partial class SsisProject : Azure.ResourceManager.DataFactory.Models.SsisObjectMetadata
    {
        internal SsisProject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.SsisEnvironmentReference> EnvironmentRefs { get { throw null; } }
        public long? FolderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataFactory.Models.SsisParameterInfo> Parameters { get { throw null; } }
        public long? Version { get { throw null; } }
    }
    public partial class SsisPropertyOverride
    {
        public SsisPropertyOverride(System.BinaryData value) { }
        public bool? IsSensitive { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class SsisVariable
    {
        internal SsisVariable() { }
        public string DataType { get { throw null; } }
        public string Description { get { throw null; } }
        public long? Id { get { throw null; } }
        public bool? IsSensitive { get { throw null; } }
        public string Name { get { throw null; } }
        public string SensitiveValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class StagingSettings
    {
        public StagingSettings(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData EnableCompression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class StoredProcedureParameter
    {
        public StoredProcedureParameter() { }
        public Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType? ParameterType { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StoredProcedureParameterType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StoredProcedureParameterType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType Boolean { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType Date { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType Decimal { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType Guid { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType Int64 { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType left, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType left, Azure.ResourceManager.DataFactory.Models.StoredProcedureParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StoreReadSettings
    {
        public StoreReadSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData DisableMetricsCollection { get { throw null; } set { } }
        public System.BinaryData MaxConcurrentConnections { get { throw null; } set { } }
    }
    public partial class StoreWriteSettings
    {
        public StoreWriteSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.BinaryData CopyBehavior { get { throw null; } set { } }
        public System.BinaryData DisableMetricsCollection { get { throw null; } set { } }
        public System.BinaryData MaxConcurrentConnections { get { throw null; } set { } }
    }
    public partial class SwitchActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public SwitchActivity(string name, Azure.ResourceManager.DataFactory.Models.FactoryExpressionDefinition on) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.SwitchCaseActivity> Cases { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivity> DefaultActivities { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryExpressionDefinition On { get { throw null; } set { } }
    }
    public partial class SwitchCaseActivity
    {
        public SwitchCaseActivity() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivity> Activities { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SybaseAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SybaseAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType left, Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SybaseLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public SybaseLinkedService(System.BinaryData server, System.BinaryData database) { }
        public Azure.ResourceManager.DataFactory.Models.SybaseAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Schema { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class SybaseSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public SybaseSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class SybaseTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public SybaseTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class TabularSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public TabularSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public System.BinaryData QueryTimeout { get { throw null; } set { } }
    }
    public partial class TarGzipReadSettings : Azure.ResourceManager.DataFactory.Models.CompressionReadSettings
    {
        public TarGzipReadSettings() { }
        public System.BinaryData PreserveCompressionFileNameAsFolder { get { throw null; } set { } }
    }
    public partial class TarReadSettings : Azure.ResourceManager.DataFactory.Models.CompressionReadSettings
    {
        public TarReadSettings() { }
        public System.BinaryData PreserveCompressionFileNameAsFolder { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TeamDeskAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TeamDeskAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType Token { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType left, Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType left, Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TeamDeskLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public TeamDeskLinkedService(Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType authenticationType, System.BinaryData uri) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ApiToken { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.TeamDeskAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TeradataAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TeradataAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType left, Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType left, Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TeradataLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public TeradataLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.TeradataAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Server { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class TeradataPartitionSettings
    {
        public TeradataPartitionSettings() { }
        public System.BinaryData PartitionColumnName { get { throw null; } set { } }
        public System.BinaryData PartitionLowerBound { get { throw null; } set { } }
        public System.BinaryData PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class TeradataSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public TeradataSource() { }
        public System.BinaryData PartitionOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.TeradataPartitionSettings PartitionSettings { get { throw null; } set { } }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class TeradataTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public TeradataTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Database { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
    }
    public partial class TriggerDependencyReference : Azure.ResourceManager.DataFactory.Models.DependencyReference
    {
        public TriggerDependencyReference(Azure.ResourceManager.DataFactory.Models.FactoryTriggerReference referenceTrigger) { }
        public Azure.ResourceManager.DataFactory.Models.FactoryTriggerReference ReferenceTrigger { get { throw null; } set { } }
    }
    public partial class TriggerFilterContent
    {
        public TriggerFilterContent() { }
        public string ContinuationToken { get { throw null; } set { } }
        public string ParentTriggerName { get { throw null; } set { } }
    }
    public partial class TriggerPipelineReference
    {
        public TriggerPipelineReference() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryPipelineReference PipelineReference { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TumblingWindowFrequency : System.IEquatable<Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TumblingWindowFrequency(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency Hour { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency Minute { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency Month { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency left, Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency left, Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TumblingWindowTrigger : Azure.ResourceManager.DataFactory.Models.FactoryTriggerDefinition
    {
        public TumblingWindowTrigger(Azure.ResourceManager.DataFactory.Models.TriggerPipelineReference pipeline, Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency frequency, int interval, System.DateTimeOffset startOn, int maxConcurrency) { }
        public System.BinaryData Delay { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DependencyReference> DependsOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.TumblingWindowFrequency Frequency { get { throw null; } set { } }
        public int Interval { get { throw null; } set { } }
        public int MaxConcurrency { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.TriggerPipelineReference Pipeline { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.RetryPolicy RetryPolicy { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
    }
    public partial class TumblingWindowTriggerDependencyReference : Azure.ResourceManager.DataFactory.Models.TriggerDependencyReference
    {
        public TumblingWindowTriggerDependencyReference(Azure.ResourceManager.DataFactory.Models.FactoryTriggerReference referenceTrigger) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryTriggerReference)) { }
        public string Offset { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
    }
    public partial class TwilioLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public TwilioLinkedService(System.BinaryData userName, Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition password) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class UntilActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public UntilActivity(string name, Azure.ResourceManager.DataFactory.Models.FactoryExpressionDefinition expression, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataFactory.Models.PipelineActivity> activities) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.PipelineActivity> Activities { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.FactoryExpressionDefinition Expression { get { throw null; } set { } }
        public System.BinaryData Timeout { get { throw null; } set { } }
    }
    public partial class UpdateIntegrationRuntimeNodeContent
    {
        public UpdateIntegrationRuntimeNodeContent() { }
        public int? ConcurrentJobsLimit { get { throw null; } set { } }
    }
    public partial class ValidationActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public ValidationActivity(string name, Azure.ResourceManager.DataFactory.Models.DatasetReference dataset) : base (default(string)) { }
        public System.BinaryData ChildItems { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetReference Dataset { get { throw null; } set { } }
        public System.BinaryData MinimumSize { get { throw null; } set { } }
        public System.BinaryData Sleep { get { throw null; } set { } }
        public System.BinaryData Timeout { get { throw null; } set { } }
    }
    public partial class VerticaLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public VerticaLinkedService() { }
        public System.BinaryData ConnectionString { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class VerticaSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public VerticaSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class VerticaTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public VerticaTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData SchemaTypePropertiesSchema { get { throw null; } set { } }
        public System.BinaryData Table { get { throw null; } set { } }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class WaitActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public WaitActivity(string name, System.BinaryData waitTimeInSeconds) : base (default(string)) { }
        public System.BinaryData WaitTimeInSeconds { get { throw null; } set { } }
    }
    public partial class WebActivity : Azure.ResourceManager.DataFactory.Models.ExecutionActivity
    {
        public WebActivity(string name, Azure.ResourceManager.DataFactory.Models.WebActivityMethod method, System.BinaryData uri) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.WebActivityAuthentication Authentication { get { throw null; } set { } }
        public System.BinaryData Body { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.IntegrationRuntimeReference ConnectVia { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.DatasetReference> Datasets { get { throw null; } }
        public bool? DisableCertValidation { get { throw null; } set { } }
        public System.BinaryData Headers { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference> LinkedServices { get { throw null; } }
        public Azure.ResourceManager.DataFactory.Models.WebActivityMethod Method { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
    }
    public partial class WebActivityAuthentication
    {
        public WebActivityAuthentication() { }
        public Azure.ResourceManager.DataFactory.Models.FactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Pfx { get { throw null; } set { } }
        public System.BinaryData Resource { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
        public System.BinaryData UserTenant { get { throw null; } set { } }
        public string WebActivityAuthenticationType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebActivityMethod : System.IEquatable<Azure.ResourceManager.DataFactory.Models.WebActivityMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebActivityMethod(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.WebActivityMethod Delete { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.WebActivityMethod Get { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.WebActivityMethod Post { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.WebActivityMethod Put { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.WebActivityMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.WebActivityMethod left, Azure.ResourceManager.DataFactory.Models.WebActivityMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.WebActivityMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.WebActivityMethod left, Azure.ResourceManager.DataFactory.Models.WebActivityMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebAnonymousAuthentication : Azure.ResourceManager.DataFactory.Models.WebLinkedServiceTypeProperties
    {
        public WebAnonymousAuthentication(System.BinaryData uri) : base (default(System.BinaryData)) { }
    }
    public partial class WebBasicAuthentication : Azure.ResourceManager.DataFactory.Models.WebLinkedServiceTypeProperties
    {
        public WebBasicAuthentication(System.BinaryData uri, System.BinaryData username, Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition password) : base (default(System.BinaryData)) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Username { get { throw null; } set { } }
    }
    public partial class WebClientCertificateAuthentication : Azure.ResourceManager.DataFactory.Models.WebLinkedServiceTypeProperties
    {
        public WebClientCertificateAuthentication(System.BinaryData uri, Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition pfx, Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition password) : base (default(System.BinaryData)) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Pfx { get { throw null; } set { } }
    }
    public partial class WebHookActivity : Azure.ResourceManager.DataFactory.Models.ControlActivity
    {
        public WebHookActivity(string name, Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod method, System.BinaryData uri) : base (default(string)) { }
        public Azure.ResourceManager.DataFactory.Models.WebActivityAuthentication Authentication { get { throw null; } set { } }
        public System.BinaryData Body { get { throw null; } set { } }
        public System.BinaryData Headers { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod Method { get { throw null; } set { } }
        public System.BinaryData ReportStatusOnCallBack { get { throw null; } set { } }
        public string Timeout { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebHookActivityMethod : System.IEquatable<Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebHookActivityMethod(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod Post { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod left, Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod left, Azure.ResourceManager.DataFactory.Models.WebHookActivityMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public WebLinkedService(Azure.ResourceManager.DataFactory.Models.WebLinkedServiceTypeProperties typeProperties) { }
        public Azure.ResourceManager.DataFactory.Models.WebLinkedServiceTypeProperties TypeProperties { get { throw null; } set { } }
    }
    public abstract partial class WebLinkedServiceTypeProperties
    {
        protected WebLinkedServiceTypeProperties(System.BinaryData uri) { }
        public System.BinaryData Uri { get { throw null; } set { } }
    }
    public partial class WebSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public WebSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
    }
    public partial class WebTableDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public WebTableDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName, System.BinaryData index) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData Index { get { throw null; } set { } }
        public System.BinaryData Path { get { throw null; } set { } }
    }
    public partial class XeroLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public XeroLinkedService() { }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ConsumerKey { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Host { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition PrivateKey { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class XeroObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public XeroObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class XeroSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public XeroSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
    public partial class XmlDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public XmlDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public Azure.ResourceManager.DataFactory.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.DatasetLocation DataLocation { get { throw null; } set { } }
        public System.BinaryData EncodingName { get { throw null; } set { } }
        public System.BinaryData NullValue { get { throw null; } set { } }
    }
    public partial class XmlReadSettings : Azure.ResourceManager.DataFactory.Models.FormatReadSettings
    {
        public XmlReadSettings() { }
        public Azure.ResourceManager.DataFactory.Models.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
        public System.BinaryData DetectDataType { get { throw null; } set { } }
        public System.BinaryData NamespacePrefixes { get { throw null; } set { } }
        public System.BinaryData Namespaces { get { throw null; } set { } }
        public System.BinaryData ValidationMode { get { throw null; } set { } }
    }
    public partial class XmlSource : Azure.ResourceManager.DataFactory.Models.CopyActivitySource
    {
        public XmlSource() { }
        public System.BinaryData AdditionalColumns { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.XmlReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZendeskAuthenticationType : System.IEquatable<Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZendeskAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType Basic { get { throw null; } }
        public static Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType Token { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType left, Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ZendeskLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public ZendeskLinkedService(Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType authenticationType, System.BinaryData uri) { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition ApiToken { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.ZendeskAuthenticationType AuthenticationType { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition Password { get { throw null; } set { } }
        public System.BinaryData Uri { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class ZipDeflateReadSettings : Azure.ResourceManager.DataFactory.Models.CompressionReadSettings
    {
        public ZipDeflateReadSettings() { }
        public System.BinaryData PreserveZipFileNameAsFolder { get { throw null; } set { } }
    }
    public partial class ZohoLinkedService : Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceDefinition
    {
        public ZohoLinkedService() { }
        public Azure.ResourceManager.DataFactory.Models.FactorySecretBaseDefinition AccessToken { get { throw null; } set { } }
        public System.BinaryData ConnectionProperties { get { throw null; } set { } }
        public System.BinaryData EncryptedCredential { get { throw null; } set { } }
        public System.BinaryData Endpoint { get { throw null; } set { } }
        public System.BinaryData UseEncryptedEndpoints { get { throw null; } set { } }
        public System.BinaryData UseHostVerification { get { throw null; } set { } }
        public System.BinaryData UsePeerVerification { get { throw null; } set { } }
    }
    public partial class ZohoObjectDataset : Azure.ResourceManager.DataFactory.Models.FactoryDatasetDefinition
    {
        public ZohoObjectDataset(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference linkedServiceName) : base (default(Azure.ResourceManager.DataFactory.Models.FactoryLinkedServiceReference)) { }
        public System.BinaryData TableName { get { throw null; } set { } }
    }
    public partial class ZohoSource : Azure.ResourceManager.DataFactory.Models.TabularSource
    {
        public ZohoSource() { }
        public System.BinaryData Query { get { throw null; } set { } }
    }
}
