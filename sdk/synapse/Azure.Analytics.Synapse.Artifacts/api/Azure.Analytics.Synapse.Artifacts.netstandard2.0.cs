namespace Azure.Analytics.Synapse.Artifacts
{
    public partial class ArtifactsClientOptions : Azure.Core.ClientOptions
    {
        public ArtifactsClientOptions(Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions.ServiceVersion version = Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions.ServiceVersion.V2023_04_18_Preview) { }
        public enum ServiceVersion
        {
            V2020_12_01 = 1,
            V2021_06_01_Preview = 2,
            V2021_07_01_Preview = 3,
            V2021_11_01_Preview = 4,
            V2022_03_01_Preview = 5,
            V2023_04_18_Preview = 6,
        }
    }
    public partial class BigDataPoolsClient
    {
        protected BigDataPoolsClient() { }
        public BigDataPoolsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolResourceInfo> Get(string bigDataPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolResourceInfo>> GetAsync(string bigDataPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolResourceInfoListResult> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolResourceInfoListResult>> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFlowClient
    {
        protected DataFlowClient() { }
        public DataFlowClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DataFlowResource> GetDataFlow(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DataFlowResource>> GetDataFlowAsync(string dataFlowName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.Artifacts.Models.DataFlowResource> GetDataFlowsByWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.Artifacts.Models.DataFlowResource> GetDataFlowsByWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.DataFlowCreateOrUpdateDataFlowOperation StartCreateOrUpdateDataFlow(string dataFlowName, Azure.Analytics.Synapse.Artifacts.Models.DataFlowResource dataFlow, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.DataFlowCreateOrUpdateDataFlowOperation> StartCreateOrUpdateDataFlowAsync(string dataFlowName, Azure.Analytics.Synapse.Artifacts.Models.DataFlowResource dataFlow, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.DataFlowDeleteDataFlowOperation StartDeleteDataFlow(string dataFlowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.DataFlowDeleteDataFlowOperation> StartDeleteDataFlowAsync(string dataFlowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.DataFlowRenameDataFlowOperation StartRenameDataFlow(string dataFlowName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.DataFlowRenameDataFlowOperation> StartRenameDataFlowAsync(string dataFlowName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFlowCreateOrUpdateDataFlowOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.DataFlowResource>
    {
        protected DataFlowCreateOrUpdateDataFlowOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.DataFlowResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DataFlowResource> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DataFlowResource> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DataFlowResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DataFlowResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFlowDebugSessionClient
    {
        protected DataFlowDebugSessionClient() { }
        public DataFlowDebugSessionClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.AddDataFlowToDebugSessionResponse> AddDataFlow(Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugPackage request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.AddDataFlowToDebugSessionResponse>> AddDataFlowAsync(Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugPackage request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDataFlowDebugSession(Azure.Analytics.Synapse.Artifacts.Models.DeleteDataFlowDebugSessionRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDataFlowDebugSessionAsync(Azure.Analytics.Synapse.Artifacts.Models.DeleteDataFlowDebugSessionRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugSessionInfo> QueryDataFlowDebugSessionsByWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugSessionInfo> QueryDataFlowDebugSessionsByWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.DataFlowDebugSessionCreateDataFlowDebugSessionOperation StartCreateDataFlowDebugSession(Azure.Analytics.Synapse.Artifacts.Models.CreateDataFlowDebugSessionRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.DataFlowDebugSessionCreateDataFlowDebugSessionOperation> StartCreateDataFlowDebugSessionAsync(Azure.Analytics.Synapse.Artifacts.Models.CreateDataFlowDebugSessionRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.DataFlowDebugSessionExecuteCommandOperation StartExecuteCommand(Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.DataFlowDebugSessionExecuteCommandOperation> StartExecuteCommandAsync(Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFlowDebugSessionCreateDataFlowDebugSessionOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.CreateDataFlowDebugSessionResponse>
    {
        protected DataFlowDebugSessionCreateDataFlowDebugSessionOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.CreateDataFlowDebugSessionResponse Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.CreateDataFlowDebugSessionResponse> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.CreateDataFlowDebugSessionResponse> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.CreateDataFlowDebugSessionResponse>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.CreateDataFlowDebugSessionResponse>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFlowDebugSessionExecuteCommandOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandResponse>
    {
        protected DataFlowDebugSessionExecuteCommandOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandResponse Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandResponse> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandResponse> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandResponse>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandResponse>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFlowDeleteDataFlowOperation : Azure.Operation
    {
        protected DataFlowDeleteDataFlowOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataFlowRenameDataFlowOperation : Azure.Operation
    {
        protected DataFlowRenameDataFlowOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatasetClient
    {
        protected DatasetClient() { }
        public DatasetClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DatasetResource> GetDataset(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DatasetResource>> GetDatasetAsync(string datasetName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.Artifacts.Models.DatasetResource> GetDatasetsByWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.Artifacts.Models.DatasetResource> GetDatasetsByWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.DatasetCreateOrUpdateDatasetOperation StartCreateOrUpdateDataset(string datasetName, Azure.Analytics.Synapse.Artifacts.Models.DatasetResource dataset, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.DatasetCreateOrUpdateDatasetOperation> StartCreateOrUpdateDatasetAsync(string datasetName, Azure.Analytics.Synapse.Artifacts.Models.DatasetResource dataset, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.DatasetDeleteDatasetOperation StartDeleteDataset(string datasetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.DatasetDeleteDatasetOperation> StartDeleteDatasetAsync(string datasetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.DatasetRenameDatasetOperation StartRenameDataset(string datasetName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.DatasetRenameDatasetOperation> StartRenameDatasetAsync(string datasetName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatasetCreateOrUpdateDatasetOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.DatasetResource>
    {
        protected DatasetCreateOrUpdateDatasetOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.DatasetResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DatasetResource> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DatasetResource> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DatasetResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.DatasetResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatasetDeleteDatasetOperation : Azure.Operation
    {
        protected DatasetDeleteDatasetOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatasetRenameDatasetOperation : Azure.Operation
    {
        protected DatasetRenameDatasetOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationRuntimesClient
    {
        protected IntegrationRuntimesClient() { }
        public IntegrationRuntimesClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeResource> Get(string integrationRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeResource>> GetAsync(string integrationRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeListResponse> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeListResponse>> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KqlScriptClient
    {
        protected KqlScriptClient() { }
        public KqlScriptClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.KqlScriptResource> GetByName(string kqlScriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.KqlScriptResource>> GetByNameAsync(string kqlScriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.KqlScriptCreateOrUpdateOperation StartCreateOrUpdate(string kqlScriptName, Azure.Analytics.Synapse.Artifacts.Models.KqlScriptResource kqlScript, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.KqlScriptCreateOrUpdateOperation> StartCreateOrUpdateAsync(string kqlScriptName, Azure.Analytics.Synapse.Artifacts.Models.KqlScriptResource kqlScript, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.KqlScriptDeleteByNameOperation StartDeleteByName(string kqlScriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.KqlScriptDeleteByNameOperation> StartDeleteByNameAsync(string kqlScriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.KqlScriptRenameOperation StartRename(string kqlScriptName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest renameRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.KqlScriptRenameOperation> StartRenameAsync(string kqlScriptName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest renameRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KqlScriptCreateOrUpdateOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.KqlScriptResource>
    {
        protected KqlScriptCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.KqlScriptResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.KqlScriptResource> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.KqlScriptResource> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.KqlScriptResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.KqlScriptResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KqlScriptDeleteByNameOperation : Azure.Operation
    {
        protected KqlScriptDeleteByNameOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KqlScriptRenameOperation : Azure.Operation
    {
        protected KqlScriptRenameOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KqlScriptsClient
    {
        protected KqlScriptsClient() { }
        public KqlScriptsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.Artifacts.Models.KqlScriptResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.Artifacts.Models.KqlScriptResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LibraryClient
    {
        protected LibraryClient() { }
        public LibraryClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response Append(string libraryName, System.IO.Stream content, long? blobConditionAppendPosition = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AppendAsync(string libraryName, System.IO.Stream content, long? blobConditionAppendPosition = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LibraryResource> Get(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LibraryResource>> GetAsync(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<object> GetOperationResult(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<object>> GetOperationResultAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.Artifacts.Models.LibraryResource> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.Artifacts.Models.LibraryResource> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.LibraryCreateOperation StartCreate(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.LibraryCreateOperation> StartCreateAsync(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.LibraryDeleteOperation StartDelete(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.LibraryDeleteOperation> StartDeleteAsync(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.LibraryFlushOperation StartFlush(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.LibraryFlushOperation> StartFlushAsync(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LibraryCreateOperation : Azure.Operation
    {
        protected LibraryCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LibraryDeleteOperation : Azure.Operation
    {
        protected LibraryDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LibraryFlushOperation : Azure.Operation
    {
        protected LibraryFlushOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkConnectionClient
    {
        protected LinkConnectionClient() { }
        public LinkConnectionClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionResource> CreateOrUpdate(string linkConnectionName, Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionResource linkConnection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionResource>> CreateOrUpdateAsync(string linkConnectionName, Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionResource linkConnection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EditTables(string linkConnectionName, Azure.Analytics.Synapse.Artifacts.Models.EditTablesRequest editTablesRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EditTablesAsync(string linkConnectionName, Azure.Analytics.Synapse.Artifacts.Models.EditTablesRequest editTablesRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionResource> Get(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionResource>> GetAsync(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionDetailedStatus> GetDetailedStatus(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionDetailedStatus>> GetDetailedStatusAsync(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionResource> ListByWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionResource> ListByWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkTableListResponse> ListLinkTables(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkTableListResponse>> ListLinkTablesAsync(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Pause(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PauseAsync(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionQueryTableStatus> QueryTableStatus(string linkConnectionName, Azure.Analytics.Synapse.Artifacts.Models.QueryTableStatusRequest queryTableStatusRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionQueryTableStatus>> QueryTableStatusAsync(string linkConnectionName, Azure.Analytics.Synapse.Artifacts.Models.QueryTableStatusRequest queryTableStatusRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Resume(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeAsync(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Start(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartAsync(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(string linkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateLandingZoneCredential(string linkConnectionName, Azure.Analytics.Synapse.Artifacts.Models.UpdateLandingZoneCredential updateLandingZoneCredentialRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateLandingZoneCredentialAsync(string linkConnectionName, Azure.Analytics.Synapse.Artifacts.Models.UpdateLandingZoneCredential updateLandingZoneCredentialRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkedServiceClient
    {
        protected LinkedServiceClient() { }
        public LinkedServiceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceResource> GetLinkedService(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceResource>> GetLinkedServiceAsync(string linkedServiceName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceResource> GetLinkedServicesByWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceResource> GetLinkedServicesByWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.LinkedServiceCreateOrUpdateLinkedServiceOperation StartCreateOrUpdateLinkedService(string linkedServiceName, Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceResource linkedService, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.LinkedServiceCreateOrUpdateLinkedServiceOperation> StartCreateOrUpdateLinkedServiceAsync(string linkedServiceName, Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceResource linkedService, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.LinkedServiceDeleteLinkedServiceOperation StartDeleteLinkedService(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.LinkedServiceDeleteLinkedServiceOperation> StartDeleteLinkedServiceAsync(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.LinkedServiceRenameLinkedServiceOperation StartRenameLinkedService(string linkedServiceName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.LinkedServiceRenameLinkedServiceOperation> StartRenameLinkedServiceAsync(string linkedServiceName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkedServiceCreateOrUpdateLinkedServiceOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceResource>
    {
        protected LinkedServiceCreateOrUpdateLinkedServiceOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceResource> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceResource> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkedServiceDeleteLinkedServiceOperation : Azure.Operation
    {
        protected LinkedServiceDeleteLinkedServiceOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkedServiceReferenceType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.LinkedServiceReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkedServiceReferenceType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.LinkedServiceReferenceType LinkedServiceReference { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.LinkedServiceReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.LinkedServiceReferenceType left, Azure.Analytics.Synapse.Artifacts.LinkedServiceReferenceType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.LinkedServiceReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.LinkedServiceReferenceType left, Azure.Analytics.Synapse.Artifacts.LinkedServiceReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinkedServiceRenameLinkedServiceOperation : Azure.Operation
    {
        protected LinkedServiceRenameLinkedServiceOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetastoreClient
    {
        protected MetastoreClient() { }
        public MetastoreClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response Delete(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.MetastoreRequestSuccessResponse> GetDatabaseOperations(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.MetastoreRequestSuccessResponse>> GetDatabaseOperationsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.MetastoreRegistrationResponse> Register(string id, Azure.Analytics.Synapse.Artifacts.Models.MetastoreRegisterObject registerBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.MetastoreRegistrationResponse>> RegisterAsync(string id, Azure.Analytics.Synapse.Artifacts.Models.MetastoreRegisterObject registerBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.MetastoreUpdationResponse> Update(string id, Azure.Analytics.Synapse.Artifacts.Models.MetastoreUpdateObject updateBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.MetastoreUpdationResponse>> UpdateAsync(string id, Azure.Analytics.Synapse.Artifacts.Models.MetastoreUpdateObject updateBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotebookClient
    {
        protected NotebookClient() { }
        public NotebookClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.NotebookResource> GetNotebook(string notebookName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.NotebookResource>> GetNotebookAsync(string notebookName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.Artifacts.Models.NotebookResource> GetNotebooksByWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.Artifacts.Models.NotebookResource> GetNotebooksByWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.Artifacts.Models.NotebookResource> GetNotebookSummaryByWorkSpace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.Artifacts.Models.NotebookResource> GetNotebookSummaryByWorkSpaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.NotebookCreateOrUpdateNotebookOperation StartCreateOrUpdateNotebook(string notebookName, Azure.Analytics.Synapse.Artifacts.Models.NotebookResource notebook, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.NotebookCreateOrUpdateNotebookOperation> StartCreateOrUpdateNotebookAsync(string notebookName, Azure.Analytics.Synapse.Artifacts.Models.NotebookResource notebook, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.NotebookDeleteNotebookOperation StartDeleteNotebook(string notebookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.NotebookDeleteNotebookOperation> StartDeleteNotebookAsync(string notebookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.NotebookRenameNotebookOperation StartRenameNotebook(string notebookName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.NotebookRenameNotebookOperation> StartRenameNotebookAsync(string notebookName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotebookCreateOrUpdateNotebookOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.NotebookResource>
    {
        protected NotebookCreateOrUpdateNotebookOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.NotebookResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.NotebookResource> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.NotebookResource> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.NotebookResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.NotebookResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotebookDeleteNotebookOperation : Azure.Operation
    {
        protected NotebookDeleteNotebookOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotebookOperationResultClient
    {
        protected NotebookOperationResultClient() { }
        public NotebookOperationResultClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response Get(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotebookRenameNotebookOperation : Azure.Operation
    {
        protected NotebookRenameNotebookOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PipelineClient
    {
        protected PipelineClient() { }
        public PipelineClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.CreateRunResponse> CreatePipelineRun(string pipelineName, string referencePipelineRunId = null, bool? isRecovery = default(bool?), string startActivityName = null, System.Collections.Generic.IDictionary<string, object> parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.CreateRunResponse>> CreatePipelineRunAsync(string pipelineName, string referencePipelineRunId = null, bool? isRecovery = default(bool?), string startActivityName = null, System.Collections.Generic.IDictionary<string, object> parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.PipelineResource> GetPipeline(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.PipelineResource>> GetPipelineAsync(string pipelineName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.Artifacts.Models.PipelineResource> GetPipelinesByWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.Artifacts.Models.PipelineResource> GetPipelinesByWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.PipelineCreateOrUpdatePipelineOperation StartCreateOrUpdatePipeline(string pipelineName, Azure.Analytics.Synapse.Artifacts.Models.PipelineResource pipeline, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.PipelineCreateOrUpdatePipelineOperation> StartCreateOrUpdatePipelineAsync(string pipelineName, Azure.Analytics.Synapse.Artifacts.Models.PipelineResource pipeline, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.PipelineDeletePipelineOperation StartDeletePipeline(string pipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.PipelineDeletePipelineOperation> StartDeletePipelineAsync(string pipelineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.PipelineRenamePipelineOperation StartRenamePipeline(string pipelineName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.PipelineRenamePipelineOperation> StartRenamePipelineAsync(string pipelineName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PipelineCreateOrUpdatePipelineOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.PipelineResource>
    {
        protected PipelineCreateOrUpdatePipelineOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.PipelineResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.PipelineResource> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.PipelineResource> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.PipelineResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.PipelineResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PipelineDeletePipelineOperation : Azure.Operation
    {
        protected PipelineDeletePipelineOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PipelineRenamePipelineOperation : Azure.Operation
    {
        protected PipelineRenamePipelineOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PipelineRunClient
    {
        protected PipelineRunClient() { }
        public PipelineRunClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response CancelPipelineRun(string runId, bool? isRecursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelPipelineRunAsync(string runId, bool? isRecursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.PipelineRun> GetPipelineRun(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.PipelineRun>> GetPipelineRunAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.ActivityRunsQueryResponse> QueryActivityRuns(string pipelineName, string runId, Azure.Analytics.Synapse.Artifacts.Models.RunFilterParameters filterParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.ActivityRunsQueryResponse>> QueryActivityRunsAsync(string pipelineName, string runId, Azure.Analytics.Synapse.Artifacts.Models.RunFilterParameters filterParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.PipelineRunsQueryResponse> QueryPipelineRunsByWorkspace(Azure.Analytics.Synapse.Artifacts.Models.RunFilterParameters filterParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.PipelineRunsQueryResponse>> QueryPipelineRunsByWorkspaceAsync(Azure.Analytics.Synapse.Artifacts.Models.RunFilterParameters filterParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RunNotebookClient
    {
        protected RunNotebookClient() { }
        public RunNotebookClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.RunNotebookResponse> CancelRun(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.RunNotebookResponse>> CancelRunAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.RunNotebookSnapshotResponse> GetSnapshot(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.RunNotebookSnapshotResponse>> GetSnapshotAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.RunNotebookResponse> GetStatus(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.RunNotebookResponse>> GetStatusAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.RunNotebookCreateRunOperation StartCreateRun(string runId, Azure.Analytics.Synapse.Artifacts.Models.RunNotebookRequest runNotebookRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.RunNotebookCreateRunOperation> StartCreateRunAsync(string runId, Azure.Analytics.Synapse.Artifacts.Models.RunNotebookRequest runNotebookRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RunNotebookCreateRunOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.RunNotebookResponse>
    {
        protected RunNotebookCreateRunOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.RunNotebookResponse Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.RunNotebookResponse> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.RunNotebookResponse> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.RunNotebookResponse>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.RunNotebookResponse>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SparkConfigurationClient
    {
        protected SparkConfigurationClient() { }
        public SparkConfigurationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationResource> GetSparkConfiguration(string sparkConfigurationName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationResource>> GetSparkConfigurationAsync(string sparkConfigurationName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationResource> GetSparkConfigurationsByWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationResource> GetSparkConfigurationsByWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.SparkConfigurationCreateOrUpdateSparkConfigurationOperation StartCreateOrUpdateSparkConfiguration(string sparkConfigurationName, Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationResource sparkConfiguration, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.SparkConfigurationCreateOrUpdateSparkConfigurationOperation> StartCreateOrUpdateSparkConfigurationAsync(string sparkConfigurationName, Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationResource sparkConfiguration, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.SparkConfigurationDeleteSparkConfigurationOperation StartDeleteSparkConfiguration(string sparkConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.SparkConfigurationDeleteSparkConfigurationOperation> StartDeleteSparkConfigurationAsync(string sparkConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.SparkConfigurationRenameSparkConfigurationOperation StartRenameSparkConfiguration(string sparkConfigurationName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.SparkConfigurationRenameSparkConfigurationOperation> StartRenameSparkConfigurationAsync(string sparkConfigurationName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SparkConfigurationCreateOrUpdateSparkConfigurationOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationResource>
    {
        protected SparkConfigurationCreateOrUpdateSparkConfigurationOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationResource> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationResource> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SparkConfigurationDeleteSparkConfigurationOperation : Azure.Operation
    {
        protected SparkConfigurationDeleteSparkConfigurationOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SparkConfigurationRenameSparkConfigurationOperation : Azure.Operation
    {
        protected SparkConfigurationRenameSparkConfigurationOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SparkJobDefinitionClient
    {
        protected SparkJobDefinitionClient() { }
        public SparkJobDefinitionClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionResource> GetSparkJobDefinition(string sparkJobDefinitionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionResource>> GetSparkJobDefinitionAsync(string sparkJobDefinitionName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionResource> GetSparkJobDefinitionsByWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionResource> GetSparkJobDefinitionsByWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.SparkJobDefinitionCreateOrUpdateSparkJobDefinitionOperation StartCreateOrUpdateSparkJobDefinition(string sparkJobDefinitionName, Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionResource sparkJobDefinition, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.SparkJobDefinitionCreateOrUpdateSparkJobDefinitionOperation> StartCreateOrUpdateSparkJobDefinitionAsync(string sparkJobDefinitionName, Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionResource sparkJobDefinition, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.SparkJobDefinitionDebugSparkJobDefinitionOperation StartDebugSparkJobDefinition(Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionResource sparkJobDefinitionAzureResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.SparkJobDefinitionDebugSparkJobDefinitionOperation> StartDebugSparkJobDefinitionAsync(Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionResource sparkJobDefinitionAzureResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.SparkJobDefinitionDeleteSparkJobDefinitionOperation StartDeleteSparkJobDefinition(string sparkJobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.SparkJobDefinitionDeleteSparkJobDefinitionOperation> StartDeleteSparkJobDefinitionAsync(string sparkJobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.SparkJobDefinitionExecuteSparkJobDefinitionOperation StartExecuteSparkJobDefinition(string sparkJobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.SparkJobDefinitionExecuteSparkJobDefinitionOperation> StartExecuteSparkJobDefinitionAsync(string sparkJobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.SparkJobDefinitionRenameSparkJobDefinitionOperation StartRenameSparkJobDefinition(string sparkJobDefinitionName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.SparkJobDefinitionRenameSparkJobDefinitionOperation> StartRenameSparkJobDefinitionAsync(string sparkJobDefinitionName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SparkJobDefinitionCreateOrUpdateSparkJobDefinitionOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionResource>
    {
        protected SparkJobDefinitionCreateOrUpdateSparkJobDefinitionOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionResource> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionResource> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SparkJobDefinitionDebugSparkJobDefinitionOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJob>
    {
        protected SparkJobDefinitionDebugSparkJobDefinitionOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJob Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJob> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJob> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJob>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJob>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SparkJobDefinitionDeleteSparkJobDefinitionOperation : Azure.Operation
    {
        protected SparkJobDefinitionDeleteSparkJobDefinitionOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SparkJobDefinitionExecuteSparkJobDefinitionOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJob>
    {
        protected SparkJobDefinitionExecuteSparkJobDefinitionOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJob Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJob> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJob> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJob>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJob>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SparkJobDefinitionRenameSparkJobDefinitionOperation : Azure.Operation
    {
        protected SparkJobDefinitionRenameSparkJobDefinitionOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlPoolsClient
    {
        protected SqlPoolsClient() { }
        public SqlPoolsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SqlPool> Get(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SqlPool>> GetAsync(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SqlPoolInfoListResult> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SqlPoolInfoListResult>> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlScriptClient
    {
        protected SqlScriptClient() { }
        public SqlScriptClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SqlScriptResource> GetSqlScript(string sqlScriptName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SqlScriptResource>> GetSqlScriptAsync(string sqlScriptName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.Artifacts.Models.SqlScriptResource> GetSqlScriptsByWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.Artifacts.Models.SqlScriptResource> GetSqlScriptsByWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.SqlScriptCreateOrUpdateSqlScriptOperation StartCreateOrUpdateSqlScript(string sqlScriptName, Azure.Analytics.Synapse.Artifacts.Models.SqlScriptResource sqlScript, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.SqlScriptCreateOrUpdateSqlScriptOperation> StartCreateOrUpdateSqlScriptAsync(string sqlScriptName, Azure.Analytics.Synapse.Artifacts.Models.SqlScriptResource sqlScript, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.SqlScriptDeleteSqlScriptOperation StartDeleteSqlScript(string sqlScriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.SqlScriptDeleteSqlScriptOperation> StartDeleteSqlScriptAsync(string sqlScriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.SqlScriptRenameSqlScriptOperation StartRenameSqlScript(string sqlScriptName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.SqlScriptRenameSqlScriptOperation> StartRenameSqlScriptAsync(string sqlScriptName, Azure.Analytics.Synapse.Artifacts.Models.ArtifactRenameRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlScriptCreateOrUpdateSqlScriptOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.SqlScriptResource>
    {
        protected SqlScriptCreateOrUpdateSqlScriptOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.SqlScriptResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SqlScriptResource> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SqlScriptResource> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SqlScriptResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.SqlScriptResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlScriptDeleteSqlScriptOperation : Azure.Operation
    {
        protected SqlScriptDeleteSqlScriptOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlScriptRenameSqlScriptOperation : Azure.Operation
    {
        protected SqlScriptRenameSqlScriptOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TriggerClient
    {
        protected TriggerClient() { }
        public TriggerClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerSubscriptionOperationStatus> GetEventSubscriptionStatus(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerSubscriptionOperationStatus>> GetEventSubscriptionStatusAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerResource> GetTrigger(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerResource>> GetTriggerAsync(string triggerName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.Artifacts.Models.TriggerResource> GetTriggersByWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.Artifacts.Models.TriggerResource> GetTriggersByWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.TriggerCreateOrUpdateTriggerOperation StartCreateOrUpdateTrigger(string triggerName, Azure.Analytics.Synapse.Artifacts.Models.TriggerResource trigger, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.TriggerCreateOrUpdateTriggerOperation> StartCreateOrUpdateTriggerAsync(string triggerName, Azure.Analytics.Synapse.Artifacts.Models.TriggerResource trigger, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.TriggerDeleteTriggerOperation StartDeleteTrigger(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.TriggerDeleteTriggerOperation> StartDeleteTriggerAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.TriggerStartTriggerOperation StartStartTrigger(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.TriggerStartTriggerOperation> StartStartTriggerAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.TriggerStopTriggerOperation StartStopTrigger(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.TriggerStopTriggerOperation> StartStopTriggerAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.TriggerSubscribeTriggerToEventsOperation StartSubscribeTriggerToEvents(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.TriggerSubscribeTriggerToEventsOperation> StartSubscribeTriggerToEventsAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Artifacts.TriggerUnsubscribeTriggerFromEventsOperation StartUnsubscribeTriggerFromEvents(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Artifacts.TriggerUnsubscribeTriggerFromEventsOperation> StartUnsubscribeTriggerFromEventsAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TriggerCreateOrUpdateTriggerOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.TriggerResource>
    {
        protected TriggerCreateOrUpdateTriggerOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.TriggerResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerResource> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerResource> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TriggerDeleteTriggerOperation : Azure.Operation
    {
        protected TriggerDeleteTriggerOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TriggerRunClient
    {
        protected TriggerRunClient() { }
        public TriggerRunClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response CancelTriggerInstance(string triggerName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelTriggerInstanceAsync(string triggerName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerRunsQueryResponse> QueryTriggerRunsByWorkspace(Azure.Analytics.Synapse.Artifacts.Models.RunFilterParameters filterParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerRunsQueryResponse>> QueryTriggerRunsByWorkspaceAsync(Azure.Analytics.Synapse.Artifacts.Models.RunFilterParameters filterParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RerunTriggerInstance(string triggerName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RerunTriggerInstanceAsync(string triggerName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TriggerStartTriggerOperation : Azure.Operation
    {
        protected TriggerStartTriggerOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TriggerStopTriggerOperation : Azure.Operation
    {
        protected TriggerStopTriggerOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TriggerSubscribeTriggerToEventsOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.TriggerSubscriptionOperationStatus>
    {
        protected TriggerSubscribeTriggerToEventsOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.TriggerSubscriptionOperationStatus Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerSubscriptionOperationStatus> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerSubscriptionOperationStatus> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerSubscriptionOperationStatus>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerSubscriptionOperationStatus>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TriggerUnsubscribeTriggerFromEventsOperation : Azure.Operation<Azure.Analytics.Synapse.Artifacts.Models.TriggerSubscriptionOperationStatus>
    {
        protected TriggerUnsubscribeTriggerFromEventsOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Artifacts.Models.TriggerSubscriptionOperationStatus Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerSubscriptionOperationStatus> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerSubscriptionOperationStatus> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerSubscriptionOperationStatus>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.TriggerSubscriptionOperationStatus>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceClient
    {
        protected WorkspaceClient() { }
        public WorkspaceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.Workspace> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.Workspace>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceGitRepoManagementClient
    {
        protected WorkspaceGitRepoManagementClient() { }
        public WorkspaceGitRepoManagementClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.GitHubAccessTokenResponse> GetGitHubAccessToken(Azure.Analytics.Synapse.Artifacts.Models.GitHubAccessTokenRequest gitHubAccessTokenRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Artifacts.Models.GitHubAccessTokenResponse>> GetGitHubAccessTokenAsync(Azure.Analytics.Synapse.Artifacts.Models.GitHubAccessTokenRequest gitHubAccessTokenRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Analytics.Synapse.Artifacts.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionOnExistingTargetTable : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ActionOnExistingTargetTable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionOnExistingTargetTable(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ActionOnExistingTargetTable DropAndRecreateTable { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ActionOnExistingTargetTable FailOnNonEmptyTable { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ActionOnExistingTargetTable MergeWithExistingData { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ActionOnExistingTargetTable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ActionOnExistingTargetTable left, Azure.Analytics.Synapse.Artifacts.Models.ActionOnExistingTargetTable right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ActionOnExistingTargetTable (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ActionOnExistingTargetTable left, Azure.Analytics.Synapse.Artifacts.Models.ActionOnExistingTargetTable right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class Activity
    {
        protected Activity(string name) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.ActivityDependency> DependsOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.ActivityOnInactiveMarkAs? OnInactiveMarkAs { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.ActivityState? State { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.UserProperty> UserProperties { get { throw null; } }
    }
    public partial class ActivityDependency
    {
        public ActivityDependency(string activity, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.DependencyCondition> dependencyConditions) { }
        public string Activity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DependencyCondition> DependencyConditions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActivityOnInactiveMarkAs : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ActivityOnInactiveMarkAs>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActivityOnInactiveMarkAs(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ActivityOnInactiveMarkAs Failed { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ActivityOnInactiveMarkAs Skipped { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ActivityOnInactiveMarkAs Succeeded { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ActivityOnInactiveMarkAs other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ActivityOnInactiveMarkAs left, Azure.Analytics.Synapse.Artifacts.Models.ActivityOnInactiveMarkAs right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ActivityOnInactiveMarkAs (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ActivityOnInactiveMarkAs left, Azure.Analytics.Synapse.Artifacts.Models.ActivityOnInactiveMarkAs right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ActivityPolicy
    {
        public ActivityPolicy() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object Retry { get { throw null; } set { } }
        public int? RetryIntervalInSeconds { get { throw null; } set { } }
        public bool? SecureInput { get { throw null; } set { } }
        public bool? SecureOutput { get { throw null; } set { } }
        public object Timeout { get { throw null; } set { } }
    }
    public partial class ActivityRun
    {
        internal ActivityRun() { }
        public string ActivityName { get { throw null; } }
        public System.DateTimeOffset? ActivityRunEnd { get { throw null; } }
        public string ActivityRunId { get { throw null; } }
        public System.DateTimeOffset? ActivityRunStart { get { throw null; } }
        public string ActivityType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> AdditionalProperties { get { throw null; } }
        public int? DurationInMs { get { throw null; } }
        public object Error { get { throw null; } }
        public object Input { get { throw null; } }
        public string LinkedServiceName { get { throw null; } }
        public object Output { get { throw null; } }
        public string PipelineName { get { throw null; } }
        public string PipelineRunId { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ActivityRunsQueryResponse
    {
        internal ActivityRunsQueryResponse() { }
        public string ContinuationToken { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Artifacts.Models.ActivityRun> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActivityState : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ActivityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActivityState(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ActivityState Active { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ActivityState Inactive { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ActivityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ActivityState left, Azure.Analytics.Synapse.Artifacts.Models.ActivityState right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ActivityState (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ActivityState left, Azure.Analytics.Synapse.Artifacts.Models.ActivityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AddDataFlowToDebugSessionResponse
    {
        internal AddDataFlowToDebugSessionResponse() { }
        public string JobVersion { get { throw null; } }
    }
    public partial class AmazonMWSLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AmazonMWSLinkedService(object endpoint, object marketplaceID, object sellerID, object accessKeyId) { }
        public object AccessKeyId { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Endpoint { get { throw null; } set { } }
        public object MarketplaceID { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase MwsAuthToken { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase SecretKey { get { throw null; } set { } }
        public object SellerID { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
    }
    public partial class AmazonMWSObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AmazonMWSObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class AmazonMWSSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public AmazonMWSSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOracleLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AmazonRdsForOracleLinkedService(object connectionString) { }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOraclePartitionSettings
    {
        public AmazonRdsForOraclePartitionSettings() { }
        public object PartitionColumnName { get { throw null; } set { } }
        public object PartitionLowerBound { get { throw null; } set { } }
        public object PartitionNames { get { throw null; } set { } }
        public object PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOracleSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public AmazonRdsForOracleSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object OracleReaderQuery { get { throw null; } set { } }
        public object PartitionOption { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AmazonRdsForOraclePartitionSettings PartitionSettings { get { throw null; } set { } }
        public object QueryTimeout { get { throw null; } set { } }
    }
    public partial class AmazonRdsForOracleTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AmazonRdsForOracleTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
    }
    public partial class AmazonRdsForSqlServerLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AmazonRdsForSqlServerLinkedService(object connectionString) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class AmazonRdsForSqlServerSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public AmazonRdsForSqlServerSource() { }
        public object IsolationLevel { get { throw null; } set { } }
        public object PartitionOption { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public object ProduceAdditionalTypes { get { throw null; } set { } }
        public object SqlReaderQuery { get { throw null; } set { } }
        public object SqlReaderStoredProcedureName { get { throw null; } set { } }
        public object StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class AmazonRdsForSqlServerTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AmazonRdsForSqlServerTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
    }
    public partial class AmazonRedshiftLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AmazonRedshiftLinkedService(object server, object database) { }
        public object Database { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Port { get { throw null; } set { } }
        public object Server { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class AmazonRedshiftSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public AmazonRedshiftSource() { }
        public object Query { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.RedshiftUnloadSettings RedshiftUnloadSettings { get { throw null; } set { } }
    }
    public partial class AmazonRedshiftTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AmazonRedshiftTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class AmazonS3Dataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AmazonS3Dataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object bucketName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object BucketName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public object Key { get { throw null; } set { } }
        public object ModifiedDatetimeEnd { get { throw null; } set { } }
        public object ModifiedDatetimeStart { get { throw null; } set { } }
        public object Prefix { get { throw null; } set { } }
        public object Version { get { throw null; } set { } }
    }
    public partial class AmazonS3LinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AmazonS3LinkedService() { }
        public object AccessKeyId { get { throw null; } set { } }
        public object AuthenticationType { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase SecretAccessKey { get { throw null; } set { } }
        public object ServiceUrl { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase SessionToken { get { throw null; } set { } }
    }
    public partial class AmazonS3Location : Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation
    {
        public AmazonS3Location() { }
        public object BucketName { get { throw null; } set { } }
        public object Version { get { throw null; } set { } }
    }
    public partial class AmazonS3ReadSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings
    {
        public AmazonS3ReadSettings() { }
        public object DeleteFilesAfterCompletion { get { throw null; } set { } }
        public object EnablePartitionDiscovery { get { throw null; } set { } }
        public object FileListPath { get { throw null; } set { } }
        public object ModifiedDatetimeEnd { get { throw null; } set { } }
        public object ModifiedDatetimeStart { get { throw null; } set { } }
        public object PartitionRootPath { get { throw null; } set { } }
        public object Prefix { get { throw null; } set { } }
        public object Recursive { get { throw null; } set { } }
        public object WildcardFileName { get { throw null; } set { } }
        public object WildcardFolderPath { get { throw null; } set { } }
    }
    public static partial class AnalyticsSynapseArtifactsModelFactory
    {
        public static Azure.Analytics.Synapse.Artifacts.Models.ActivityRun ActivityRun(string pipelineName = null, string pipelineRunId = null, string activityName = null, string activityType = null, string activityRunId = null, string linkedServiceName = null, string status = null, System.DateTimeOffset? activityRunStart = default(System.DateTimeOffset?), System.DateTimeOffset? activityRunEnd = default(System.DateTimeOffset?), int? durationInMs = default(int?), object input = null, object output = null, object error = null, System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ActivityRunsQueryResponse ActivityRunsQueryResponse(System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.ActivityRun> value = null, string continuationToken = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.AddDataFlowToDebugSessionResponse AddDataFlowToDebugSessionResponse(string jobVersion = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.AzureEntityResource AzureEntityResource(string id = null, string name = null, string type = null, string etag = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolResourceInfo BigDataPoolResourceInfo(string id = null, string name = null, string type = null, System.Collections.Generic.IDictionary<string, string> tags = null, string location = null, string provisioningState = null, Azure.Analytics.Synapse.Artifacts.Models.AutoScaleProperties autoScale = null, System.DateTimeOffset? creationDate = default(System.DateTimeOffset?), Azure.Analytics.Synapse.Artifacts.Models.AutoPauseProperties autoPause = null, bool? isComputeIsolationEnabled = default(bool?), bool? sessionLevelPackagesEnabled = default(bool?), int? cacheSize = default(int?), Azure.Analytics.Synapse.Artifacts.Models.DynamicExecutorAllocation dynamicExecutorAllocation = null, string sparkEventsFolder = null, int? nodeCount = default(int?), Azure.Analytics.Synapse.Artifacts.Models.LibraryRequirements libraryRequirements = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.LibraryInfo> customLibraries = null, Azure.Analytics.Synapse.Artifacts.Models.LibraryRequirements sparkConfigProperties = null, string sparkVersion = null, string defaultSparkLogFolder = null, Azure.Analytics.Synapse.Artifacts.Models.NodeSize? nodeSize = default(Azure.Analytics.Synapse.Artifacts.Models.NodeSize?), Azure.Analytics.Synapse.Artifacts.Models.NodeSizeFamily? nodeSizeFamily = default(Azure.Analytics.Synapse.Artifacts.Models.NodeSizeFamily?), System.DateTimeOffset? lastSucceededTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolResourceInfoListResult BigDataPoolResourceInfoListResult(string nextLink = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolResourceInfo> value = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.BlobEventsTrigger BlobEventsTrigger(string description = null, Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState? runtimeState = default(Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState?), System.Collections.Generic.IEnumerable<object> annotations = null, System.Collections.Generic.IDictionary<string, object> additionalProperties = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.TriggerPipelineReference> pipelines = null, string blobPathBeginsWith = null, string blobPathEndsWith = null, bool? ignoreEmptyBlobs = default(bool?), System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.BlobEventType> events = null, string scope = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.BlobTrigger BlobTrigger(string description = null, Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState? runtimeState = default(Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState?), System.Collections.Generic.IEnumerable<object> annotations = null, System.Collections.Generic.IDictionary<string, object> additionalProperties = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.TriggerPipelineReference> pipelines = null, string folderPath = null, int maxConcurrency = 0, Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedService = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ChainingTrigger ChainingTrigger(string description = null, Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState? runtimeState = default(Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState?), System.Collections.Generic.IEnumerable<object> annotations = null, System.Collections.Generic.IDictionary<string, object> additionalProperties = null, Azure.Analytics.Synapse.Artifacts.Models.TriggerPipelineReference pipeline = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.PipelineReference> dependsOn = null, string runDimension = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.CloudError CloudError(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.CloudError> details = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.CreateDataFlowDebugSessionResponse CreateDataFlowDebugSessionResponse(string sessionId = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.CreateRunResponse CreateRunResponse(string runId = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.CustomerManagedKeyDetails CustomerManagedKeyDetails(string status = null, Azure.Analytics.Synapse.Artifacts.Models.WorkspaceKeyDetails key = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.CustomEventsTrigger CustomEventsTrigger(string description = null, Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState? runtimeState = default(Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState?), System.Collections.Generic.IEnumerable<object> annotations = null, System.Collections.Generic.IDictionary<string, object> additionalProperties = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.TriggerPipelineReference> pipelines = null, string subjectBeginsWith = null, string subjectEndsWith = null, System.Collections.Generic.IEnumerable<object> events = null, string scope = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandResponse DataFlowDebugCommandResponse(string status = null, string data = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugSessionInfo DataFlowDebugSessionInfo(string dataFlowName = null, string computeType = null, int? coreCount = default(int?), int? nodeCount = default(int?), string integrationRuntimeName = null, string sessionId = null, string startTime = null, int? timeToLiveInMinutes = default(int?), string lastActivityTime = null, System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.DataFlowResource DataFlowResource(string id = null, string name = null, string type = null, string etag = null, Azure.Analytics.Synapse.Artifacts.Models.DataFlow properties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.DatasetResource DatasetResource(string id = null, string name = null, string type = null, string etag = null, Azure.Analytics.Synapse.Artifacts.Models.Dataset properties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.EncryptionDetails EncryptionDetails(bool? doubleEncryptionEnabled = default(bool?), Azure.Analytics.Synapse.Artifacts.Models.CustomerManagedKeyDetails cmk = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ExposureControlResponse ExposureControlResponse(string featureName = null, string value = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.GitHubAccessTokenResponse GitHubAccessTokenResponse(string gitHubAccessToken = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeListResponse IntegrationRuntimeListResponse(System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeResource> value = null, string nextLink = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeResource IntegrationRuntimeResource(string id = null, string name = null, string type = null, string etag = null, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntime properties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.LibraryInfo LibraryInfo(string name = null, string path = null, string containerName = null, System.DateTimeOffset? uploadedTimestamp = default(System.DateTimeOffset?), string type = null, string provisioningStatus = null, string creatorId = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.LibraryRequirements LibraryRequirements(System.DateTimeOffset? time = default(System.DateTimeOffset?), string content = null, string filename = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.LibraryResource LibraryResource(string id = null, string name = null, string type = null, string etag = null, Azure.Analytics.Synapse.Artifacts.Models.LibraryResourceProperties properties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.LibraryResourceInfo LibraryResourceInfo(string id = null, int? recordId = default(int?), string state = null, string created = null, string changed = null, string type = null, string name = null, string operationId = null, string artifactId = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.LibraryResourceProperties LibraryResourceProperties(string name = null, string path = null, string containerName = null, string uploadedTimestamp = null, string type = null, string provisioningStatus = null, string creatorId = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionDetailedStatus LinkConnectionDetailedStatus(string id = null, string name = null, bool? isApplyingChanges = default(bool?), bool? isPartiallyFailed = default(bool?), object startTime = null, object stopTime = null, string status = null, string continuousRunId = null, object error = null, Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionRefreshStatus refreshStatus = null, System.DateTimeOffset? landingZoneCredentialExpireTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionQueryTableStatus LinkConnectionQueryTableStatus(System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.LinkTableStatus> value = null, object continuationToken = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionRefreshStatus LinkConnectionRefreshStatus(string refreshStatus = null, string errorMessage = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceResource LinkedServiceResource(string id = null, string name = null, string type = null, string etag = null, Azure.Analytics.Synapse.Artifacts.Models.LinkedService properties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.LinkTableListResponse LinkTableListResponse(System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.LinkTableResource> value = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.LinkTableResource LinkTableResource(string id = null, string name = null, Azure.Analytics.Synapse.Artifacts.Models.LinkTableRequestSource source = null, Azure.Analytics.Synapse.Artifacts.Models.LinkTableRequestTarget target = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.LinkTableStatus LinkTableStatus(string id = null, string status = null, string errorMessage = null, object startTime = null, object stopTime = null, string linkTableId = null, string errorCode = null, System.DateTimeOffset? lastProcessedData = default(System.DateTimeOffset?), System.DateTimeOffset? lastTransactionCommitTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ManagedIdentity ManagedIdentity(string principalId = null, System.Guid? tenantId = default(System.Guid?), Azure.Analytics.Synapse.Artifacts.Models.ResourceIdentityType? type = default(Azure.Analytics.Synapse.Artifacts.Models.ResourceIdentityType?)) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ManagedIntegrationRuntime ManagedIntegrationRuntime(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeType type = default(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeType), string description = null, System.Collections.Generic.IDictionary<string, object> additionalProperties = null, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState? state = default(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState?), Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkReference managedVirtualNetwork = null, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeComputeProperties computeProperties = null, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeSsisProperties ssisProperties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkReference ManagedVirtualNetworkReference(Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkReferenceType type = default(Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkReferenceType), string referenceName = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.MetastoreRegistrationResponse MetastoreRegistrationResponse(Azure.Analytics.Synapse.Artifacts.Models.RequestStatus? status = default(Azure.Analytics.Synapse.Artifacts.Models.RequestStatus?)) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.MetastoreRequestSuccessResponse MetastoreRequestSuccessResponse(Azure.Analytics.Synapse.Artifacts.Models.ResourceStatus? status = default(Azure.Analytics.Synapse.Artifacts.Models.ResourceStatus?)) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.MetastoreUpdationResponse MetastoreUpdationResponse(Azure.Analytics.Synapse.Artifacts.Models.RequestStatus? status = default(Azure.Analytics.Synapse.Artifacts.Models.RequestStatus?)) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.MultiplePipelineTrigger MultiplePipelineTrigger(string description = null, Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState? runtimeState = default(Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState?), System.Collections.Generic.IEnumerable<object> annotations = null, System.Collections.Generic.IDictionary<string, object> additionalProperties = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.TriggerPipelineReference> pipelines = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.NotebookResource NotebookResource(string id = null, string name = null, string type = null, string etag = null, Azure.Analytics.Synapse.Artifacts.Models.Notebook properties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.OperationResult OperationResult(string status = null, string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.CloudError> details = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.PipelineResource PipelineResource(string id = null, string name = null, string type = null, string etag = null, string description = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.Activity> activities = null, System.Collections.Generic.IDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.ParameterSpecification> parameters = null, System.Collections.Generic.IDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.VariableSpecification> variables = null, int? concurrency = default(int?), System.Collections.Generic.IEnumerable<object> annotations = null, System.Collections.Generic.IDictionary<string, object> runDimensions = null, Azure.Analytics.Synapse.Artifacts.Models.PipelineFolder folder = null, System.Collections.Generic.IDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.PipelineRun PipelineRun(string runId = null, string runGroupId = null, bool? isLatest = default(bool?), string pipelineName = null, System.Collections.Generic.IReadOnlyDictionary<string, string> parameters = null, Azure.Analytics.Synapse.Artifacts.Models.PipelineRunInvokedBy invokedBy = null, System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?), System.DateTimeOffset? runStart = default(System.DateTimeOffset?), System.DateTimeOffset? runEnd = default(System.DateTimeOffset?), int? durationInMs = default(int?), string status = null, string message = null, System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.PipelineRunInvokedBy PipelineRunInvokedBy(string name = null, string id = null, string invokedByType = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.PipelineRunsQueryResponse PipelineRunsQueryResponse(System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.PipelineRun> value = null, string continuationToken = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.PrivateEndpoint PrivateEndpoint(string id = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.PrivateEndpointConnection PrivateEndpointConnection(string id = null, string name = null, string type = null, Azure.Analytics.Synapse.Artifacts.Models.PrivateEndpoint privateEndpoint = null, Azure.Analytics.Synapse.Artifacts.Models.PrivateLinkServiceConnectionState connectionState = null, string provisioningState = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState(string status = null, string description = null, string actionsRequired = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ProxyResource ProxyResource(string id = null, string name = null, string type = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RerunTriggerListResponse RerunTriggerListResponse(System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.RerunTriggerResource> value = null, string nextLink = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RerunTriggerResource RerunTriggerResource(string id = null, string name = null, string type = null, string etag = null, Azure.Analytics.Synapse.Artifacts.Models.RerunTumblingWindowTrigger properties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RerunTumblingWindowTrigger RerunTumblingWindowTrigger(string description = null, Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState? runtimeState = default(Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState?), System.Collections.Generic.IEnumerable<object> annotations = null, System.Collections.Generic.IDictionary<string, object> additionalProperties = null, object parentTrigger = null, System.DateTimeOffset requestedStartTime = default(System.DateTimeOffset), System.DateTimeOffset requestedEndTime = default(System.DateTimeOffset), int rerunConcurrency = 0) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.Resource Resource(string id = null, string name = null, string type = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunNotebookError RunNotebookError(string ename = null, string evalue = null, System.Collections.Generic.IEnumerable<string> traceback = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunNotebookResponse RunNotebookResponse(string message = null, Azure.Analytics.Synapse.Artifacts.Models.RunNotebookResult result = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunNotebookResult RunNotebookResult(string runId = null, string runStatus = null, string lastCheckedOn = null, string sessionId = null, string sparkPool = null, object sessionDetail = null, string exitValue = null, Azure.Analytics.Synapse.Artifacts.Models.RunNotebookError error = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunNotebookSnapshot RunNotebookSnapshot(string exitValue = null, string id = null, string notebook = null, Azure.Analytics.Synapse.Artifacts.Models.RunNotebookSparkSessionOptions sessionOptions = null, bool? honorSessionTimeToLive = default(bool?), string sessionId = null, string sparkPool = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.RunNotebookParameter> parameters = null, Azure.Analytics.Synapse.Artifacts.Models.NotebookResource notebookContent = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunNotebookSnapshotResponse RunNotebookSnapshotResponse(string message = null, Azure.Analytics.Synapse.Artifacts.Models.RunNotebookSnapshotResult result = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunNotebookSnapshotResult RunNotebookSnapshotResult(Azure.Analytics.Synapse.Artifacts.Models.RunNotebookSnapshot snapshot = null, Azure.Analytics.Synapse.Artifacts.Models.RunNotebookError error = null, string runId = null, string runStatus = null, string lastCheckedOn = null, string sessionId = null, string sparkPool = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScheduleTrigger ScheduleTrigger(string description = null, Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState? runtimeState = default(Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState?), System.Collections.Generic.IEnumerable<object> annotations = null, System.Collections.Generic.IDictionary<string, object> additionalProperties = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.TriggerPipelineReference> pipelines = null, Azure.Analytics.Synapse.Artifacts.Models.ScheduleTriggerRecurrence recurrence = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJob SparkBatchJob(Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobState livyInfo = null, string name = null, string workspaceName = null, string sparkPoolName = null, string submitterName = null, string submitterId = null, string artifactId = null, Azure.Analytics.Synapse.Artifacts.Models.SparkJobType? jobType = default(Azure.Analytics.Synapse.Artifacts.Models.SparkJobType?), Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobResultType? result = default(Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobResultType?), Azure.Analytics.Synapse.Artifacts.Models.SparkScheduler scheduler = null, Azure.Analytics.Synapse.Artifacts.Models.SparkServicePlugin plugin = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.SparkServiceError> errors = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, int id = 0, string appId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> appInfo = null, Azure.Analytics.Synapse.Artifacts.Models.LivyStates? state = default(Azure.Analytics.Synapse.Artifacts.Models.LivyStates?), System.Collections.Generic.IEnumerable<string> logLines = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobState SparkBatchJobState(System.DateTimeOffset? notStartedAt = default(System.DateTimeOffset?), System.DateTimeOffset? startingAt = default(System.DateTimeOffset?), System.DateTimeOffset? runningAt = default(System.DateTimeOffset?), System.DateTimeOffset? deadAt = default(System.DateTimeOffset?), System.DateTimeOffset? successAt = default(System.DateTimeOffset?), System.DateTimeOffset? terminatedAt = default(System.DateTimeOffset?), System.DateTimeOffset? recoveringAt = default(System.DateTimeOffset?), string currentState = null, Azure.Analytics.Synapse.Artifacts.Models.SparkRequest jobCreationRequest = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationResource SparkConfigurationResource(string id = null, string name = null, string type = null, string etag = null, Azure.Analytics.Synapse.Artifacts.Models.SparkConfiguration properties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionResource SparkJobDefinitionResource(string id = null, string name = null, string type = null, string etag = null, Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinition properties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkRequest SparkRequest(string name = null, string file = null, string className = null, System.Collections.Generic.IEnumerable<string> arguments = null, System.Collections.Generic.IEnumerable<string> jars = null, System.Collections.Generic.IEnumerable<string> pythonFiles = null, System.Collections.Generic.IEnumerable<string> files = null, System.Collections.Generic.IEnumerable<string> archives = null, System.Collections.Generic.IReadOnlyDictionary<string, string> configuration = null, string driverMemory = null, int? driverCores = default(int?), string executorMemory = null, int? executorCores = default(int?), int? executorCount = default(int?)) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkScheduler SparkScheduler(System.DateTimeOffset? submittedAt = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledAt = default(System.DateTimeOffset?), System.DateTimeOffset? endedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancellationRequestedAt = default(System.DateTimeOffset?), Azure.Analytics.Synapse.Artifacts.Models.SchedulerCurrentState? currentState = default(Azure.Analytics.Synapse.Artifacts.Models.SchedulerCurrentState?)) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkServiceError SparkServiceError(string message = null, string errorCode = null, Azure.Analytics.Synapse.Artifacts.Models.SparkErrorSource? source = default(Azure.Analytics.Synapse.Artifacts.Models.SparkErrorSource?)) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkServicePlugin SparkServicePlugin(System.DateTimeOffset? preparationStartedAt = default(System.DateTimeOffset?), System.DateTimeOffset? resourceAcquisitionStartedAt = default(System.DateTimeOffset?), System.DateTimeOffset? submissionStartedAt = default(System.DateTimeOffset?), System.DateTimeOffset? monitoringStartedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cleanupStartedAt = default(System.DateTimeOffset?), Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState? currentState = default(Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState?)) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SqlPool SqlPool(string id = null, string name = null, string type = null, System.Collections.Generic.IDictionary<string, string> tags = null, string location = null, Azure.Analytics.Synapse.Artifacts.Models.Sku sku = null, long? maxSizeBytes = default(long?), string collation = null, string sourceDatabaseId = null, string recoverableDatabaseId = null, string provisioningState = null, string status = null, string restorePointInTime = null, Azure.Analytics.Synapse.Artifacts.Models.CreateMode? createMode = default(Azure.Analytics.Synapse.Artifacts.Models.CreateMode?), System.DateTimeOffset? creationDate = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SqlPoolInfoListResult SqlPoolInfoListResult(string nextLink = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.SqlPool> value = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SqlScriptResource SqlScriptResource(string id = null, string name = null, string type = null, string etag = null, Azure.Analytics.Synapse.Artifacts.Models.SqlScript properties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SubResource SubResource(string id = null, string name = null, string type = null, string etag = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.TrackedResource TrackedResource(string id = null, string name = null, string type = null, System.Collections.Generic.IDictionary<string, string> tags = null, string location = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.Trigger Trigger(string type = null, string description = null, Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState? runtimeState = default(Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState?), System.Collections.Generic.IEnumerable<object> annotations = null, System.Collections.Generic.IDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.TriggerResource TriggerResource(string id = null, string name = null, string type = null, string etag = null, Azure.Analytics.Synapse.Artifacts.Models.Trigger properties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.TriggerRun TriggerRun(string triggerRunId = null, string triggerName = null, string triggerType = null, System.DateTimeOffset? triggerRunTimestamp = default(System.DateTimeOffset?), Azure.Analytics.Synapse.Artifacts.Models.TriggerRunStatus? status = default(Azure.Analytics.Synapse.Artifacts.Models.TriggerRunStatus?), string message = null, System.Collections.Generic.IReadOnlyDictionary<string, string> properties = null, System.Collections.Generic.IReadOnlyDictionary<string, string> triggeredPipelines = null, System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.TriggerRunsQueryResponse TriggerRunsQueryResponse(System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.TriggerRun> value = null, string continuationToken = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.TriggerSubscriptionOperationStatus TriggerSubscriptionOperationStatus(string triggerName = null, Azure.Analytics.Synapse.Artifacts.Models.EventSubscriptionStatus? status = default(Azure.Analytics.Synapse.Artifacts.Models.EventSubscriptionStatus?)) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.TumblingWindowTrigger TumblingWindowTrigger(string description = null, Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState? runtimeState = default(Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState?), System.Collections.Generic.IEnumerable<object> annotations = null, System.Collections.Generic.IDictionary<string, object> additionalProperties = null, Azure.Analytics.Synapse.Artifacts.Models.TriggerPipelineReference pipeline = null, Azure.Analytics.Synapse.Artifacts.Models.TumblingWindowFrequency frequency = default(Azure.Analytics.Synapse.Artifacts.Models.TumblingWindowFrequency), int interval = 0, System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), object delay = null, int maxConcurrency = 0, Azure.Analytics.Synapse.Artifacts.Models.RetryPolicy retryPolicy = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.DependencyReference> dependsOn = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.Workspace Workspace(string id = null, string name = null, string type = null, System.Collections.Generic.IDictionary<string, string> tags = null, string location = null, Azure.Analytics.Synapse.Artifacts.Models.ManagedIdentity identity = null, Azure.Analytics.Synapse.Artifacts.Models.DataLakeStorageAccountDetails defaultDataLakeStorage = null, string sqlAdministratorLoginPassword = null, string managedResourceGroupName = null, string provisioningState = null, string sqlAdministratorLogin = null, Azure.Analytics.Synapse.Artifacts.Models.VirtualNetworkProfile virtualNetworkProfile = null, System.Collections.Generic.IDictionary<string, string> connectivityEndpoints = null, string managedVirtualNetwork = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.PrivateEndpointConnection> privateEndpointConnections = null, Azure.Analytics.Synapse.Artifacts.Models.EncryptionDetails encryption = null, System.Guid? workspaceUID = default(System.Guid?), System.Collections.Generic.IReadOnlyDictionary<string, object> extraProperties = null, Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkSettings managedVirtualNetworkSettings = null, Azure.Analytics.Synapse.Artifacts.Models.WorkspaceRepositoryConfiguration workspaceRepositoryConfiguration = null, Azure.Analytics.Synapse.Artifacts.Models.PurviewConfiguration purviewConfiguration = null, string adlaResourceId = null) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.WorkspaceIdentity WorkspaceIdentity(Azure.Analytics.Synapse.Artifacts.Models.WorkspaceIdentityType type = default(Azure.Analytics.Synapse.Artifacts.Models.WorkspaceIdentityType), string principalId = null, string tenantId = null) { throw null; }
    }
    public partial class AppendVariableActivity : Azure.Analytics.Synapse.Artifacts.Models.ControlActivity
    {
        public AppendVariableActivity(string name) : base (default(string)) { }
        public object Value { get { throw null; } set { } }
        public string VariableName { get { throw null; } set { } }
    }
    public partial class AppFiguresLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AppFiguresLinkedService(object userName, Azure.Analytics.Synapse.Artifacts.Models.SecretBase password, Azure.Analytics.Synapse.Artifacts.Models.SecretBase clientKey) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ClientKey { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class ArtifactRenameRequest
    {
        public ArtifactRenameRequest() { }
        public string NewName { get { throw null; } set { } }
    }
    public partial class AsanaLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AsanaLinkedService(Azure.Analytics.Synapse.Artifacts.Models.SecretBase apiToken) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ApiToken { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
    }
    public partial class AutoPauseProperties
    {
        public AutoPauseProperties() { }
        public int? DelayInMinutes { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class AutoScaleProperties
    {
        public AutoScaleProperties() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? MaxNodeCount { get { throw null; } set { } }
        public int? MinNodeCount { get { throw null; } set { } }
    }
    public partial class AvroDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AvroDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object AvroCompressionCodec { get { throw null; } set { } }
        public int? AvroCompressionLevel { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation Location { get { throw null; } set { } }
    }
    public partial class AvroFormat : Azure.Analytics.Synapse.Artifacts.Models.DatasetStorageFormat
    {
        public AvroFormat() { }
    }
    public partial class AvroSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public AvroSink() { }
        public Azure.Analytics.Synapse.Artifacts.Models.AvroWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class AvroSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public AvroSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class AvroWriteSettings : Azure.Analytics.Synapse.Artifacts.Models.FormatWriteSettings
    {
        public AvroWriteSettings() { }
        public object FileNamePrefix { get { throw null; } set { } }
        public object MaxRowsPerFile { get { throw null; } set { } }
        public string RecordName { get { throw null; } set { } }
        public string RecordNamespace { get { throw null; } set { } }
    }
    public partial class AzureBatchLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureBatchLinkedService(object accountName, object batchUri, object poolName, Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase AccessKey { get { throw null; } set { } }
        public object AccountName { get { throw null; } set { } }
        public object BatchUri { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public object PoolName { get { throw null; } set { } }
    }
    public partial class AzureBlobDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AzureBlobDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetCompression Compression { get { throw null; } set { } }
        public object FileName { get { throw null; } set { } }
        public object FolderPath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public object ModifiedDatetimeEnd { get { throw null; } set { } }
        public object ModifiedDatetimeStart { get { throw null; } set { } }
        public object TableRootLocation { get { throw null; } set { } }
    }
    public partial class AzureBlobFSDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AzureBlobFSDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetCompression Compression { get { throw null; } set { } }
        public object FileName { get { throw null; } set { } }
        public object FolderPath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetStorageFormat Format { get { throw null; } set { } }
    }
    public partial class AzureBlobFSLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureBlobFSLinkedService() { }
        public object AccountKey { get { throw null; } set { } }
        public object AzureCloudType { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase SasToken { get { throw null; } set { } }
        public object SasUri { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalCredential { get { throw null; } set { } }
        public object ServicePrincipalCredentialType { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object Tenant { get { throw null; } set { } }
        public object Url { get { throw null; } set { } }
    }
    public partial class AzureBlobFSLocation : Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation
    {
        public AzureBlobFSLocation() { }
        public object FileSystem { get { throw null; } set { } }
    }
    public partial class AzureBlobFSReadSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings
    {
        public AzureBlobFSReadSettings() { }
        public object DeleteFilesAfterCompletion { get { throw null; } set { } }
        public object EnablePartitionDiscovery { get { throw null; } set { } }
        public object FileListPath { get { throw null; } set { } }
        public object ModifiedDatetimeEnd { get { throw null; } set { } }
        public object ModifiedDatetimeStart { get { throw null; } set { } }
        public object PartitionRootPath { get { throw null; } set { } }
        public object Recursive { get { throw null; } set { } }
        public object WildcardFileName { get { throw null; } set { } }
        public object WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureBlobFSSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public AzureBlobFSSink() { }
        public object CopyBehavior { get { throw null; } set { } }
    }
    public partial class AzureBlobFSSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public AzureBlobFSSource() { }
        public object Recursive { get { throw null; } set { } }
        public object SkipHeaderLineCount { get { throw null; } set { } }
        public object TreatEmptyAsNull { get { throw null; } set { } }
    }
    public partial class AzureBlobFSWriteSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreWriteSettings
    {
        public AzureBlobFSWriteSettings() { }
        public object BlockSizeInMB { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureBlobStorageLinkedService() { }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public string AccountKind { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureStorageAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public object AzureCloudType { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public object ContainerUri { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public object SasUri { get { throw null; } set { } }
        public string ServiceEndpoint { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object Tenant { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageLocation : Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation
    {
        public AzureBlobStorageLocation() { }
        public object Container { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageReadSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings
    {
        public AzureBlobStorageReadSettings() { }
        public object DeleteFilesAfterCompletion { get { throw null; } set { } }
        public object EnablePartitionDiscovery { get { throw null; } set { } }
        public object FileListPath { get { throw null; } set { } }
        public object ModifiedDatetimeEnd { get { throw null; } set { } }
        public object ModifiedDatetimeStart { get { throw null; } set { } }
        public object PartitionRootPath { get { throw null; } set { } }
        public object Prefix { get { throw null; } set { } }
        public object Recursive { get { throw null; } set { } }
        public object WildcardFileName { get { throw null; } set { } }
        public object WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageWriteSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreWriteSettings
    {
        public AzureBlobStorageWriteSettings() { }
        public object BlockSizeInMB { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AzureDatabricksDeltaLakeDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Database { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeExportCommand : Azure.Analytics.Synapse.Artifacts.Models.ExportSettings
    {
        public AzureDatabricksDeltaLakeExportCommand() { }
        public object DateFormat { get { throw null; } set { } }
        public object TimestampFormat { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeImportCommand : Azure.Analytics.Synapse.Artifacts.Models.ImportSettings
    {
        public AzureDatabricksDeltaLakeImportCommand() { }
        public object DateFormat { get { throw null; } set { } }
        public object TimestampFormat { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureDatabricksDeltaLakeLinkedService(object domain, Azure.Analytics.Synapse.Artifacts.Models.SecretBase accessToken) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase AccessToken { get { throw null; } set { } }
        public object ClusterId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public object Domain { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public AzureDatabricksDeltaLakeSink() { }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureDatabricksDeltaLakeImportCommand ImportSettings { get { throw null; } set { } }
        public object PreCopyScript { get { throw null; } set { } }
    }
    public partial class AzureDatabricksDeltaLakeSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public AzureDatabricksDeltaLakeSource() { }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureDatabricksDeltaLakeExportCommand ExportSettings { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    public partial class AzureDatabricksLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureDatabricksLinkedService(object domain) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase AccessToken { get { throw null; } set { } }
        public object Authentication { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public object Domain { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object ExistingClusterId { get { throw null; } set { } }
        public object InstancePoolId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> NewClusterCustomTags { get { throw null; } }
        public object NewClusterDriverNodeType { get { throw null; } set { } }
        public object NewClusterEnableElasticDisk { get { throw null; } set { } }
        public object NewClusterInitScripts { get { throw null; } set { } }
        public object NewClusterLogDestination { get { throw null; } set { } }
        public object NewClusterNodeType { get { throw null; } set { } }
        public object NewClusterNumOfWorker { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> NewClusterSparkConf { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> NewClusterSparkEnvVars { get { throw null; } }
        public object NewClusterVersion { get { throw null; } set { } }
        public object PolicyId { get { throw null; } set { } }
        public object WorkspaceResourceId { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerCommandActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public AzureDataExplorerCommandActivity(string name, object command) : base (default(string)) { }
        public object Command { get { throw null; } set { } }
        public object CommandTimeout { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureDataExplorerLinkedService(object endpoint, object database) { }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public object Database { get { throw null; } set { } }
        public object Endpoint { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object Tenant { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public AzureDataExplorerSink() { }
        public object FlushImmediately { get { throw null; } set { } }
        public object IngestionMappingAsJson { get { throw null; } set { } }
        public object IngestionMappingName { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public AzureDataExplorerSource(object query) { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object NoTruncation { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
        public object QueryTimeout { get { throw null; } set { } }
    }
    public partial class AzureDataExplorerTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AzureDataExplorerTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Table { get { throw null; } set { } }
    }
    public partial class AzureDataLakeAnalyticsLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureDataLakeAnalyticsLinkedService(object accountName, object tenant) { }
        public object AccountName { get { throw null; } set { } }
        public object DataLakeAnalyticsUri { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object ResourceGroupName { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object SubscriptionId { get { throw null; } set { } }
        public object Tenant { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AzureDataLakeStoreDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetCompression Compression { get { throw null; } set { } }
        public object FileName { get { throw null; } set { } }
        public object FolderPath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetStorageFormat Format { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureDataLakeStoreLinkedService(object dataLakeStoreUri) { }
        public object AccountName { get { throw null; } set { } }
        public object AzureCloudType { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public object DataLakeStoreUri { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object ResourceGroupName { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object SubscriptionId { get { throw null; } set { } }
        public object Tenant { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreLocation : Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation
    {
        public AzureDataLakeStoreLocation() { }
    }
    public partial class AzureDataLakeStoreReadSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings
    {
        public AzureDataLakeStoreReadSettings() { }
        public object DeleteFilesAfterCompletion { get { throw null; } set { } }
        public object EnablePartitionDiscovery { get { throw null; } set { } }
        public object FileListPath { get { throw null; } set { } }
        public object ListAfter { get { throw null; } set { } }
        public object ListBefore { get { throw null; } set { } }
        public object ModifiedDatetimeEnd { get { throw null; } set { } }
        public object ModifiedDatetimeStart { get { throw null; } set { } }
        public object PartitionRootPath { get { throw null; } set { } }
        public object Recursive { get { throw null; } set { } }
        public object WildcardFileName { get { throw null; } set { } }
        public object WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public AzureDataLakeStoreSink() { }
        public object CopyBehavior { get { throw null; } set { } }
        public object EnableAdlsSingleFileParallel { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public AzureDataLakeStoreSource() { }
        public object Recursive { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreWriteSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreWriteSettings
    {
        public AzureDataLakeStoreWriteSettings() { }
        public object ExpiryDateTime { get { throw null; } set { } }
    }
    public partial class AzureEntityResource : Azure.Analytics.Synapse.Artifacts.Models.Resource
    {
        public AzureEntityResource() { }
        public string Etag { get { throw null; } }
    }
    public partial class AzureFileStorageLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureFileStorageLinkedService(object host) { }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object FileShare { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public object SasUri { get { throw null; } set { } }
        public object Snapshot { get { throw null; } set { } }
        public object UserId { get { throw null; } set { } }
    }
    public partial class AzureFileStorageLocation : Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation
    {
        public AzureFileStorageLocation() { }
    }
    public partial class AzureFileStorageReadSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings
    {
        public AzureFileStorageReadSettings() { }
        public object DeleteFilesAfterCompletion { get { throw null; } set { } }
        public object EnablePartitionDiscovery { get { throw null; } set { } }
        public object FileListPath { get { throw null; } set { } }
        public object ModifiedDatetimeEnd { get { throw null; } set { } }
        public object ModifiedDatetimeStart { get { throw null; } set { } }
        public object PartitionRootPath { get { throw null; } set { } }
        public object Prefix { get { throw null; } set { } }
        public object Recursive { get { throw null; } set { } }
        public object WildcardFileName { get { throw null; } set { } }
        public object WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class AzureFileStorageWriteSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreWriteSettings
    {
        public AzureFileStorageWriteSettings() { }
    }
    public partial class AzureFunctionActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public AzureFunctionActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod method, object functionName) : base (default(string)) { }
        public object Body { get { throw null; } set { } }
        public object FunctionName { get { throw null; } set { } }
        public object Headers { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod Method { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureFunctionActivityMethod : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureFunctionActivityMethod(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod Delete { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod GET { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod Head { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod Options { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod Post { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod PUT { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod Trace { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod left, Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod left, Azure.Analytics.Synapse.Artifacts.Models.AzureFunctionActivityMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureFunctionLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureFunctionLinkedService(object functionAppUrl) { }
        public object Authentication { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object FunctionAppUrl { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase FunctionKey { get { throw null; } set { } }
        public object ResourceId { get { throw null; } set { } }
    }
    public partial class AzureKeyVaultLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureKeyVaultLinkedService(object baseUrl) { }
        public object BaseUrl { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
    }
    public partial class AzureKeyVaultSecretReference : Azure.Analytics.Synapse.Artifacts.Models.SecretBase
    {
        public AzureKeyVaultSecretReference(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference store, object secretName) { }
        public object SecretName { get { throw null; } set { } }
        public object SecretVersion { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference Store { get { throw null; } set { } }
    }
    public partial class AzureMariaDBLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureMariaDBLinkedService() { }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference Pwd { get { throw null; } set { } }
    }
    public partial class AzureMariaDBSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public AzureMariaDBSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class AzureMariaDBTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AzureMariaDBTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class AzureMLBatchExecutionActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public AzureMLBatchExecutionActivity(string name) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, object> GlobalParameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.AzureMLWebServiceFile> WebServiceInputs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.AzureMLWebServiceFile> WebServiceOutputs { get { throw null; } }
    }
    public partial class AzureMLExecutePipelineActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public AzureMLExecutePipelineActivity(string name, object mlPipelineId) : base (default(string)) { }
        public object ContinueOnStepFailure { get { throw null; } set { } }
        public object ExperimentName { get { throw null; } set { } }
        public object MlParentRunId { get { throw null; } set { } }
        public object MlPipelineId { get { throw null; } set { } }
        public object MlPipelineParameters { get { throw null; } set { } }
    }
    public partial class AzureMLLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureMLLinkedService(object mlEndpoint, Azure.Analytics.Synapse.Artifacts.Models.SecretBase apiKey) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ApiKey { get { throw null; } set { } }
        public object Authentication { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object MlEndpoint { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object Tenant { get { throw null; } set { } }
        public object UpdateResourceEndpoint { get { throw null; } set { } }
    }
    public partial class AzureMLServiceLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureMLServiceLinkedService(object subscriptionId, object resourceGroupName, object mlWorkspaceName) { }
        public object Authentication { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object MlWorkspaceName { get { throw null; } set { } }
        public object ResourceGroupName { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object SubscriptionId { get { throw null; } set { } }
        public object Tenant { get { throw null; } set { } }
    }
    public partial class AzureMLUpdateResourceActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public AzureMLUpdateResourceActivity(string name, object trainedModelName, Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference trainedModelLinkedServiceName, object trainedModelFilePath) : base (default(string)) { }
        public object TrainedModelFilePath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference TrainedModelLinkedServiceName { get { throw null; } set { } }
        public object TrainedModelName { get { throw null; } set { } }
    }
    public partial class AzureMLWebServiceFile
    {
        public AzureMLWebServiceFile(object filePath, Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) { }
        public object FilePath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
    }
    public partial class AzureMySqlLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureMySqlLinkedService(object connectionString) { }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class AzureMySqlSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public AzureMySqlSink() { }
        public object PreCopyScript { get { throw null; } set { } }
    }
    public partial class AzureMySqlSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public AzureMySqlSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class AzureMySqlTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AzureMySqlTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzurePostgreSqlLinkedService() { }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public AzurePostgreSqlSink() { }
        public object PreCopyScript { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public AzurePostgreSqlSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class AzurePostgreSqlTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AzurePostgreSqlTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class AzureQueueSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public AzureQueueSink() { }
    }
    public partial class AzureSearchIndexDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AzureSearchIndexDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object indexName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object IndexName { get { throw null; } set { } }
    }
    public partial class AzureSearchIndexSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public AzureSearchIndexSink() { }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureSearchIndexWriteBehaviorType? WriteBehavior { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSearchIndexWriteBehaviorType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.AzureSearchIndexWriteBehaviorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSearchIndexWriteBehaviorType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.AzureSearchIndexWriteBehaviorType Merge { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.AzureSearchIndexWriteBehaviorType Upload { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.AzureSearchIndexWriteBehaviorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.AzureSearchIndexWriteBehaviorType left, Azure.Analytics.Synapse.Artifacts.Models.AzureSearchIndexWriteBehaviorType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.AzureSearchIndexWriteBehaviorType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.AzureSearchIndexWriteBehaviorType left, Azure.Analytics.Synapse.Artifacts.Models.AzureSearchIndexWriteBehaviorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureSearchLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureSearchLinkedService(object url) { }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Key { get { throw null; } set { } }
        public object Url { get { throw null; } set { } }
    }
    public partial class AzureSqlDatabaseLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureSqlDatabaseLinkedService(object connectionString) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public object AzureCloudType { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object Tenant { get { throw null; } set { } }
    }
    public partial class AzureSqlDWLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureSqlDWLinkedService(object connectionString) { }
        public object AzureCloudType { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object Tenant { get { throw null; } set { } }
    }
    public partial class AzureSqlDWTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AzureSqlDWTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class AzureSqlMILinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureSqlMILinkedService(object connectionString) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public object AzureCloudType { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object Tenant { get { throw null; } set { } }
    }
    public partial class AzureSqlMITableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AzureSqlMITableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class AzureSqlSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public AzureSqlSink() { }
        public object PreCopyScript { get { throw null; } set { } }
        public object SqlWriterStoredProcedureName { get { throw null; } set { } }
        public object SqlWriterTableType { get { throw null; } set { } }
        public object StoredProcedureParameters { get { throw null; } set { } }
        public object StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public object TableOption { get { throw null; } set { } }
    }
    public partial class AzureSqlSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public AzureSqlSource() { }
        public object IsolationLevel { get { throw null; } set { } }
        public object PartitionOption { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public object ProduceAdditionalTypes { get { throw null; } set { } }
        public object SqlReaderQuery { get { throw null; } set { } }
        public object SqlReaderStoredProcedureName { get { throw null; } set { } }
        public object StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class AzureSqlTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AzureSqlTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureStorageAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.AzureStorageAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureStorageAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.AzureStorageAuthenticationType AccountKey { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.AzureStorageAuthenticationType Anonymous { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.AzureStorageAuthenticationType Msi { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.AzureStorageAuthenticationType SasUri { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.AzureStorageAuthenticationType ServicePrincipal { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.AzureStorageAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.AzureStorageAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.AzureStorageAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.AzureStorageAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.AzureStorageAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.AzureStorageAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureStorageLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureStorageLinkedService() { }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public object SasUri { get { throw null; } set { } }
    }
    public partial class AzureSynapseArtifactsLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureSynapseArtifactsLinkedService(object endpoint) { }
        public object Authentication { get { throw null; } set { } }
        public object Endpoint { get { throw null; } set { } }
        public object WorkspaceResourceId { get { throw null; } set { } }
    }
    public partial class AzureTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public AzureTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object tableName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class AzureTableSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public AzureTableSink() { }
        public object AzureTableDefaultPartitionKeyValue { get { throw null; } set { } }
        public object AzureTableInsertType { get { throw null; } set { } }
        public object AzureTablePartitionKeyName { get { throw null; } set { } }
        public object AzureTableRowKeyName { get { throw null; } set { } }
    }
    public partial class AzureTableSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public AzureTableSource() { }
        public object AzureTableSourceIgnoreTableNotFound { get { throw null; } set { } }
        public object AzureTableSourceQuery { get { throw null; } set { } }
    }
    public partial class AzureTableStorageLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public AzureTableStorageLinkedService() { }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference AccountKey { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference SasToken { get { throw null; } set { } }
        public object SasUri { get { throw null; } set { } }
    }
    public partial class BigDataPoolParametrizationReference
    {
        public BigDataPoolParametrizationReference(Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolReferenceType type, object referenceName) { }
        public object ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolReferenceType Type { get { throw null; } set { } }
    }
    public partial class BigDataPoolReference
    {
        public BigDataPoolReference(Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolReferenceType type, string referenceName) { }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolReferenceType Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BigDataPoolReferenceType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BigDataPoolReferenceType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolReferenceType BigDataPoolReference { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolReferenceType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BigDataPoolResourceInfo : Azure.Analytics.Synapse.Artifacts.Models.TrackedResource
    {
        public BigDataPoolResourceInfo(string location) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.AutoPauseProperties AutoPause { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AutoScaleProperties AutoScale { get { throw null; } set { } }
        public int? CacheSize { get { throw null; } set { } }
        public System.DateTimeOffset? CreationDate { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.LibraryInfo> CustomLibraries { get { throw null; } }
        public string DefaultSparkLogFolder { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DynamicExecutorAllocation DynamicExecutorAllocation { get { throw null; } set { } }
        public bool? IsComputeIsolationEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastSucceededTimestamp { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.LibraryRequirements LibraryRequirements { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.NodeSize? NodeSize { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.NodeSizeFamily? NodeSizeFamily { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public bool? SessionLevelPackagesEnabled { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LibraryRequirements SparkConfigProperties { get { throw null; } set { } }
        public string SparkEventsFolder { get { throw null; } set { } }
        public string SparkVersion { get { throw null; } set { } }
    }
    public partial class BigDataPoolResourceInfoListResult
    {
        internal BigDataPoolResourceInfoListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolResourceInfo> Value { get { throw null; } }
    }
    public partial class BinaryDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public BinaryDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation Location { get { throw null; } set { } }
    }
    public partial class BinaryReadSettings : Azure.Analytics.Synapse.Artifacts.Models.FormatReadSettings
    {
        public BinaryReadSettings() { }
        public Azure.Analytics.Synapse.Artifacts.Models.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
    }
    public partial class BinarySink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public BinarySink() { }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class BinarySource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public BinarySource() { }
        public Azure.Analytics.Synapse.Artifacts.Models.BinaryReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class BlobEventsTrigger : Azure.Analytics.Synapse.Artifacts.Models.MultiplePipelineTrigger
    {
        public BlobEventsTrigger(System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.BlobEventType> events, string scope) { }
        public string BlobPathBeginsWith { get { throw null; } set { } }
        public string BlobPathEndsWith { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.BlobEventType> Events { get { throw null; } }
        public bool? IgnoreEmptyBlobs { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobEventType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.BlobEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobEventType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.BlobEventType MicrosoftStorageBlobCreated { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.BlobEventType MicrosoftStorageBlobDeleted { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.BlobEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.BlobEventType left, Azure.Analytics.Synapse.Artifacts.Models.BlobEventType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.BlobEventType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.BlobEventType left, Azure.Analytics.Synapse.Artifacts.Models.BlobEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlobSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public BlobSink() { }
        public object BlobWriterAddHeader { get { throw null; } set { } }
        public object BlobWriterDateTimeFormat { get { throw null; } set { } }
        public object BlobWriterOverwriteFiles { get { throw null; } set { } }
        public object CopyBehavior { get { throw null; } set { } }
    }
    public partial class BlobSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public BlobSource() { }
        public object Recursive { get { throw null; } set { } }
        public object SkipHeaderLineCount { get { throw null; } set { } }
        public object TreatEmptyAsNull { get { throw null; } set { } }
    }
    public partial class BlobTrigger : Azure.Analytics.Synapse.Artifacts.Models.MultiplePipelineTrigger
    {
        public BlobTrigger(string folderPath, int maxConcurrency, Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedService) { }
        public string FolderPath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference LinkedService { get { throw null; } set { } }
        public int MaxConcurrency { get { throw null; } set { } }
    }
    public partial class CassandraLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public CassandraLinkedService(object host) { }
        public object AuthenticationType { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Port { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class CassandraSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public CassandraSource() { }
        public Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels? ConsistencyLevel { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CassandraSourceReadConsistencyLevels : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CassandraSourceReadConsistencyLevels(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels ALL { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels EachQuorum { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels LocalONE { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels LocalQuorum { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels LocalSerial { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels ONE { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels Quorum { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels Serial { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels Three { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels TWO { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels left, Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels left, Azure.Analytics.Synapse.Artifacts.Models.CassandraSourceReadConsistencyLevels right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CassandraTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public CassandraTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Keyspace { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CellOutputType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.CellOutputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CellOutputType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.CellOutputType DisplayData { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.CellOutputType Error { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.CellOutputType ExecuteResult { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.CellOutputType Stream { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.CellOutputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.CellOutputType left, Azure.Analytics.Synapse.Artifacts.Models.CellOutputType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.CellOutputType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.CellOutputType left, Azure.Analytics.Synapse.Artifacts.Models.CellOutputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChainingTrigger : Azure.Analytics.Synapse.Artifacts.Models.Trigger
    {
        public ChainingTrigger(Azure.Analytics.Synapse.Artifacts.Models.TriggerPipelineReference pipeline, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.PipelineReference> dependsOn, string runDimension) { }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.PipelineReference> DependsOn { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.TriggerPipelineReference Pipeline { get { throw null; } set { } }
        public string RunDimension { get { throw null; } set { } }
    }
    public partial class CloudError
    {
        internal CloudError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Artifacts.Models.CloudError> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class CommonDataServiceForAppsEntityDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public CommonDataServiceForAppsEntityDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object EntityName { get { throw null; } set { } }
    }
    public partial class CommonDataServiceForAppsLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public CommonDataServiceForAppsLinkedService(object deploymentType, object authenticationType) { }
        public object AuthenticationType { get { throw null; } set { } }
        public object DeploymentType { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object HostName { get { throw null; } set { } }
        public object OrganizationName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Port { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalCredential { get { throw null; } set { } }
        public object ServicePrincipalCredentialType { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public object ServiceUri { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class CommonDataServiceForAppsSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public CommonDataServiceForAppsSink(Azure.Analytics.Synapse.Artifacts.Models.DynamicsSinkWriteBehavior writeBehavior) { }
        public object AlternateKeyName { get { throw null; } set { } }
        public object IgnoreNullValues { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DynamicsSinkWriteBehavior WriteBehavior { get { throw null; } set { } }
    }
    public partial class CommonDataServiceForAppsSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public CommonDataServiceForAppsSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    public abstract partial class CompressionReadSettings
    {
        protected CompressionReadSettings() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
    }
    public partial class ConcurLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public ConcurLinkedService(object clientId, object username) { }
        public object ClientId { get { throw null; } set { } }
        public object ConnectionProperties { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class ConcurObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public ConcurObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class ConcurSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public ConcurSource() { }
        public object Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ConfigurationType Artifact { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ConfigurationType Customized { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ConfigurationType Default { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ConfigurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ConfigurationType left, Azure.Analytics.Synapse.Artifacts.Models.ConfigurationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ConfigurationType left, Azure.Analytics.Synapse.Artifacts.Models.ConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ControlActivity : Azure.Analytics.Synapse.Artifacts.Models.Activity
    {
        public ControlActivity(string name) : base (default(string)) { }
    }
    public partial class CopyActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public CopyActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.CopySource source, Azure.Analytics.Synapse.Artifacts.Models.CopySink sink) : base (default(string)) { }
        public object DataIntegrationUnits { get { throw null; } set { } }
        public object EnableSkipIncompatibleRow { get { throw null; } set { } }
        public object EnableStaging { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DatasetReference> Inputs { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.LogSettings LogSettings { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LogStorageSettings LogStorageSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DatasetReference> Outputs { get { throw null; } }
        public object ParallelCopies { get { throw null; } set { } }
        public System.Collections.Generic.IList<object> Preserve { get { throw null; } }
        public System.Collections.Generic.IList<object> PreserveRules { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.RedirectIncompatibleRowSettings RedirectIncompatibleRowSettings { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CopySink Sink { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SkipErrorFile SkipErrorFile { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CopySource Source { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StagingSettings StagingSettings { get { throw null; } set { } }
        public object Translator { get { throw null; } set { } }
        public object ValidateDataConsistency { get { throw null; } set { } }
    }
    public partial class CopyActivityLogSettings
    {
        public CopyActivityLogSettings() { }
        public object EnableReliableLogging { get { throw null; } set { } }
        public object LogLevel { get { throw null; } set { } }
    }
    public abstract partial class CopySink
    {
        protected CopySink() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object MaxConcurrentConnections { get { throw null; } set { } }
        public object SinkRetryCount { get { throw null; } set { } }
        public object SinkRetryWait { get { throw null; } set { } }
        public object WriteBatchSize { get { throw null; } set { } }
        public object WriteBatchTimeout { get { throw null; } set { } }
    }
    public abstract partial class CopySource
    {
        protected CopySource() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object MaxConcurrentConnections { get { throw null; } set { } }
        public object SourceRetryCount { get { throw null; } set { } }
        public object SourceRetryWait { get { throw null; } set { } }
    }
    public abstract partial class CopyTranslator
    {
        protected CopyTranslator() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
    }
    public partial class CosmosDbLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public CosmosDbLinkedService() { }
        public object AccountEndpoint { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase AccountKey { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public object Database { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
    }
    public partial class CosmosDbMongoDbApiCollectionDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public CosmosDbMongoDbApiCollectionDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object collection) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Collection { get { throw null; } set { } }
    }
    public partial class CosmosDbMongoDbApiLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public CosmosDbMongoDbApiLinkedService(object connectionString, object database) { }
        public object ConnectionString { get { throw null; } set { } }
        public object Database { get { throw null; } set { } }
    }
    public partial class CosmosDbMongoDbApiSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public CosmosDbMongoDbApiSink() { }
        public object WriteBehavior { get { throw null; } set { } }
    }
    public partial class CosmosDbMongoDbApiSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public CosmosDbMongoDbApiSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object BatchSize { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.MongoDbCursorMethodsProperties CursorMethods { get { throw null; } set { } }
        public object Filter { get { throw null; } set { } }
        public object QueryTimeout { get { throw null; } set { } }
    }
    public partial class CosmosDbSqlApiCollectionDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public CosmosDbSqlApiCollectionDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object collectionName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object CollectionName { get { throw null; } set { } }
    }
    public partial class CosmosDbSqlApiSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public CosmosDbSqlApiSink() { }
        public object WriteBehavior { get { throw null; } set { } }
    }
    public partial class CosmosDbSqlApiSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public CosmosDbSqlApiSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object DetectDatetime { get { throw null; } set { } }
        public object PageSize { get { throw null; } set { } }
        public object PreferredRegions { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    public partial class CouchbaseLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public CouchbaseLinkedService() { }
        public object ConnectionString { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference CredString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
    }
    public partial class CouchbaseSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public CouchbaseSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class CouchbaseTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public CouchbaseTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class CreateDataFlowDebugSessionRequest
    {
        public CreateDataFlowDebugSessionRequest() { }
        public string ComputeType { get { throw null; } set { } }
        public int? CoreCount { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeDebugResource IntegrationRuntime { get { throw null; } set { } }
        public int? TimeToLive { get { throw null; } set { } }
    }
    public partial class CreateDataFlowDebugSessionResponse
    {
        internal CreateDataFlowDebugSessionResponse() { }
        public string SessionId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateMode : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.CreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateMode(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.CreateMode Default { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.CreateMode PointInTimeRestore { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.CreateMode Recovery { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.CreateMode Restore { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.CreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.CreateMode left, Azure.Analytics.Synapse.Artifacts.Models.CreateMode right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.CreateMode (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.CreateMode left, Azure.Analytics.Synapse.Artifacts.Models.CreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreateRunResponse
    {
        internal CreateRunResponse() { }
        public string RunId { get { throw null; } }
    }
    public partial class CredentialReference
    {
        public CredentialReference(Azure.Analytics.Synapse.Artifacts.Models.CredentialReferenceType type, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReferenceType Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CredentialReferenceType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.CredentialReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CredentialReferenceType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.CredentialReferenceType CredentialReference { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.CredentialReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.CredentialReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.CredentialReferenceType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.CredentialReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.CredentialReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.CredentialReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public CustomActivity(string name, object command) : base (default(string)) { }
        public object AutoUserSpecification { get { throw null; } set { } }
        public object Command { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> ExtendedProperties { get { throw null; } }
        public object FolderPath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CustomActivityReferenceObject ReferenceObjects { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference ResourceLinkedService { get { throw null; } set { } }
        public object RetentionTimeInDays { get { throw null; } set { } }
    }
    public partial class CustomActivityReferenceObject
    {
        public CustomActivityReferenceObject() { }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DatasetReference> Datasets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference> LinkedServices { get { throw null; } }
    }
    public partial class CustomDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public CustomDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TypeProperties { get { throw null; } set { } }
    }
    public partial class CustomDataSourceLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public CustomDataSourceLinkedService(object typeProperties) { }
        public object TypeProperties { get { throw null; } set { } }
    }
    public partial class CustomerManagedKeyDetails
    {
        public CustomerManagedKeyDetails() { }
        public Azure.Analytics.Synapse.Artifacts.Models.WorkspaceKeyDetails Key { get { throw null; } set { } }
        public string Status { get { throw null; } }
    }
    public partial class CustomEventsTrigger : Azure.Analytics.Synapse.Artifacts.Models.MultiplePipelineTrigger
    {
        public CustomEventsTrigger(System.Collections.Generic.IEnumerable<object> events, string scope) { }
        public System.Collections.Generic.IList<object> Events { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public string SubjectBeginsWith { get { throw null; } set { } }
        public string SubjectEndsWith { get { throw null; } set { } }
    }
    public partial class CustomSetupBase
    {
        public CustomSetupBase() { }
    }
    public partial class DatabricksNotebookActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public DatabricksNotebookActivity(string name, object notebookPath) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, object> BaseParameters { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, object>> Libraries { get { throw null; } }
        public object NotebookPath { get { throw null; } set { } }
    }
    public partial class DatabricksSparkJarActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public DatabricksSparkJarActivity(string name, object mainClassName) : base (default(string)) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, object>> Libraries { get { throw null; } }
        public object MainClassName { get { throw null; } set { } }
        public System.Collections.Generic.IList<object> Parameters { get { throw null; } }
    }
    public partial class DatabricksSparkPythonActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public DatabricksSparkPythonActivity(string name, object pythonFile) : base (default(string)) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, object>> Libraries { get { throw null; } }
        public System.Collections.Generic.IList<object> Parameters { get { throw null; } }
        public object PythonFile { get { throw null; } set { } }
    }
    public partial class DataFlow
    {
        public DataFlow() { }
        public System.Collections.Generic.IList<object> Annotations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DataFlowFolder Folder { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFlowComputeType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.DataFlowComputeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFlowComputeType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.DataFlowComputeType ComputeOptimized { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.DataFlowComputeType General { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.DataFlowComputeType MemoryOptimized { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.DataFlowComputeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.DataFlowComputeType left, Azure.Analytics.Synapse.Artifacts.Models.DataFlowComputeType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.DataFlowComputeType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.DataFlowComputeType left, Azure.Analytics.Synapse.Artifacts.Models.DataFlowComputeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFlowDebugCommandPayload
    {
        public DataFlowDebugCommandPayload(string streamName) { }
        public System.Collections.Generic.IList<string> Columns { get { throw null; } }
        public string Expression { get { throw null; } set { } }
        public int? RowLimits { get { throw null; } set { } }
        public string StreamName { get { throw null; } }
    }
    public partial class DataFlowDebugCommandRequest
    {
        public DataFlowDebugCommandRequest() { }
        public Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandType? Command { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandPayload CommandPayload { get { throw null; } set { } }
        public string SessionId { get { throw null; } set { } }
    }
    public partial class DataFlowDebugCommandResponse
    {
        internal DataFlowDebugCommandResponse() { }
        public string Data { get { throw null; } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFlowDebugCommandType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFlowDebugCommandType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandType ExecuteExpressionQuery { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandType ExecutePreviewQuery { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandType ExecuteStatisticsQuery { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandType left, Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandType left, Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugCommandType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFlowDebugPackage
    {
        public DataFlowDebugPackage() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugResource DataFlow { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugResource> DataFlows { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DatasetDebugResource> Datasets { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.DataFlowDebugPackageDebugSettings DebugSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceDebugResource> LinkedServices { get { throw null; } }
        public string SessionId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DataFlowStagingInfo Staging { get { throw null; } set { } }
    }
    public partial class DataFlowDebugPackageDebugSettings
    {
        public DataFlowDebugPackageDebugSettings() { }
        public object DatasetParameters { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DataFlowSourceSetting> SourceSettings { get { throw null; } }
    }
    public partial class DataFlowDebugPreviewDataRequest
    {
        public DataFlowDebugPreviewDataRequest() { }
        public string DataFlowName { get { throw null; } set { } }
        public int? RowLimits { get { throw null; } set { } }
        public string SessionId { get { throw null; } set { } }
        public string StreamName { get { throw null; } set { } }
    }
    public partial class DataFlowDebugQueryResponse
    {
        public DataFlowDebugQueryResponse() { }
        public string RunId { get { throw null; } set { } }
    }
    public partial class DataFlowDebugResource : Azure.Analytics.Synapse.Artifacts.Models.SubResourceDebugResource
    {
        public DataFlowDebugResource(Azure.Analytics.Synapse.Artifacts.Models.DataFlow properties) { }
        public Azure.Analytics.Synapse.Artifacts.Models.DataFlow Properties { get { throw null; } set { } }
    }
    public partial class DataFlowDebugResultResponse
    {
        public DataFlowDebugResultResponse() { }
        public string Data { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class DataFlowDebugSessionInfo
    {
        internal DataFlowDebugSessionInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> AdditionalProperties { get { throw null; } }
        public string ComputeType { get { throw null; } }
        public int? CoreCount { get { throw null; } }
        public string DataFlowName { get { throw null; } }
        public string IntegrationRuntimeName { get { throw null; } }
        public string LastActivityTime { get { throw null; } }
        public int? NodeCount { get { throw null; } }
        public string SessionId { get { throw null; } }
        public string StartTime { get { throw null; } }
        public int? TimeToLiveInMinutes { get { throw null; } }
    }
    public partial class DataFlowDebugStatisticsRequest
    {
        public DataFlowDebugStatisticsRequest() { }
        public System.Collections.Generic.IList<string> Columns { get { throw null; } }
        public string DataFlowName { get { throw null; } set { } }
        public string SessionId { get { throw null; } set { } }
        public string StreamName { get { throw null; } set { } }
    }
    public partial class DataFlowFolder
    {
        public DataFlowFolder() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class DataFlowReference
    {
        public DataFlowReference(Azure.Analytics.Synapse.Artifacts.Models.DataFlowReferenceType type, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object DatasetParameters { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DataFlowReferenceType Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFlowReferenceType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.DataFlowReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFlowReferenceType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.DataFlowReferenceType DataFlowReference { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.DataFlowReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.DataFlowReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.DataFlowReferenceType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.DataFlowReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.DataFlowReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.DataFlowReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFlowResource : Azure.Analytics.Synapse.Artifacts.Models.SubResource
    {
        public DataFlowResource(Azure.Analytics.Synapse.Artifacts.Models.DataFlow properties) { }
        public Azure.Analytics.Synapse.Artifacts.Models.DataFlow Properties { get { throw null; } set { } }
    }
    public partial class DataFlowSink : Azure.Analytics.Synapse.Artifacts.Models.Transformation
    {
        public DataFlowSink(string name) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference RejectedDataLinkedService { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference SchemaLinkedService { get { throw null; } set { } }
    }
    public partial class DataFlowSource : Azure.Analytics.Synapse.Artifacts.Models.Transformation
    {
        public DataFlowSource(string name) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference SchemaLinkedService { get { throw null; } set { } }
    }
    public partial class DataFlowSourceSetting
    {
        public DataFlowSourceSetting() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public int? RowLimit { get { throw null; } set { } }
        public string SourceName { get { throw null; } set { } }
    }
    public partial class DataFlowStagingInfo
    {
        public DataFlowStagingInfo() { }
        public object FolderPath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference LinkedService { get { throw null; } set { } }
    }
    public partial class DataLakeAnalyticsUsqlActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public DataLakeAnalyticsUsqlActivity(string name, object scriptPath, Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference scriptLinkedService) : base (default(string)) { }
        public object CompilationMode { get { throw null; } set { } }
        public object DegreeOfParallelism { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
        public object Priority { get { throw null; } set { } }
        public object RuntimeVersion { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference ScriptLinkedService { get { throw null; } set { } }
        public object ScriptPath { get { throw null; } set { } }
    }
    public partial class DataLakeStorageAccountDetails
    {
        public DataLakeStorageAccountDetails() { }
        public string AccountUrl { get { throw null; } set { } }
        public string Filesystem { get { throw null; } set { } }
    }
    public partial class Dataset
    {
        public Dataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<object> Annotations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetFolder Folder { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.ParameterSpecification> Parameters { get { throw null; } }
        public object Schema { get { throw null; } set { } }
        public object Structure { get { throw null; } set { } }
    }
    public partial class DatasetCompression
    {
        public DatasetCompression(object type) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object Level { get { throw null; } set { } }
        public object Type { get { throw null; } set { } }
    }
    public partial class DatasetDataElement
    {
        public DatasetDataElement() { }
        public object Name { get { throw null; } set { } }
        public object Type { get { throw null; } set { } }
    }
    public partial class DatasetDebugResource : Azure.Analytics.Synapse.Artifacts.Models.SubResourceDebugResource
    {
        public DatasetDebugResource(Azure.Analytics.Synapse.Artifacts.Models.Dataset properties) { }
        public Azure.Analytics.Synapse.Artifacts.Models.Dataset Properties { get { throw null; } set { } }
    }
    public partial class DatasetFolder
    {
        public DatasetFolder() { }
        public string Name { get { throw null; } set { } }
    }
    public abstract partial class DatasetLocation
    {
        protected DatasetLocation() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object FileName { get { throw null; } set { } }
        public object FolderPath { get { throw null; } set { } }
    }
    public partial class DatasetReference
    {
        public DatasetReference(Azure.Analytics.Synapse.Artifacts.Models.DatasetReferenceType type, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetReferenceType Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatasetReferenceType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.DatasetReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatasetReferenceType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.DatasetReferenceType DatasetReference { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.DatasetReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.DatasetReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.DatasetReferenceType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.DatasetReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.DatasetReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.DatasetReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatasetResource : Azure.Analytics.Synapse.Artifacts.Models.SubResource
    {
        public DatasetResource(Azure.Analytics.Synapse.Artifacts.Models.Dataset properties) { }
        public Azure.Analytics.Synapse.Artifacts.Models.Dataset Properties { get { throw null; } set { } }
    }
    public partial class DatasetSchemaDataElement
    {
        public DatasetSchemaDataElement() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object Name { get { throw null; } set { } }
        public object Type { get { throw null; } set { } }
    }
    public abstract partial class DatasetStorageFormat
    {
        protected DatasetStorageFormat() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object Deserializer { get { throw null; } set { } }
        public object Serializer { get { throw null; } set { } }
    }
    public partial class DataworldLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public DataworldLinkedService(Azure.Analytics.Synapse.Artifacts.Models.SecretBase apiToken) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ApiToken { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
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
    public readonly partial struct Db2AuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.Db2AuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Db2AuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.Db2AuthenticationType Basic { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.Db2AuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.Db2AuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.Db2AuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.Db2AuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.Db2AuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.Db2AuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Db2LinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public Db2LinkedService(object server, object database) { }
        public Azure.Analytics.Synapse.Artifacts.Models.Db2AuthenticationType? AuthenticationType { get { throw null; } set { } }
        public object CertificateCommonName { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public object Database { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object PackageCollection { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Server { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class Db2Source : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public Db2Source() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class Db2TableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public Db2TableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class DeleteActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public DeleteActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.DatasetReference dataset) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetReference Dataset { get { throw null; } set { } }
        public object EnableLogging { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LogStorageSettings LogStorageSettings { get { throw null; } set { } }
        public int? MaxConcurrentConnections { get { throw null; } set { } }
        public object Recursive { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class DeleteDataFlowDebugSessionRequest
    {
        public DeleteDataFlowDebugSessionRequest() { }
        public string DataFlowName { get { throw null; } set { } }
        public string SessionId { get { throw null; } set { } }
    }
    public partial class DelimitedTextDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public DelimitedTextDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object ColumnDelimiter { get { throw null; } set { } }
        public object CompressionCodec { get { throw null; } set { } }
        public object CompressionLevel { get { throw null; } set { } }
        public object EncodingName { get { throw null; } set { } }
        public object EscapeChar { get { throw null; } set { } }
        public object FirstRowAsHeader { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation Location { get { throw null; } set { } }
        public object NullValue { get { throw null; } set { } }
        public object QuoteChar { get { throw null; } set { } }
        public object RowDelimiter { get { throw null; } set { } }
    }
    public partial class DelimitedTextReadSettings : Azure.Analytics.Synapse.Artifacts.Models.FormatReadSettings
    {
        public DelimitedTextReadSettings() { }
        public Azure.Analytics.Synapse.Artifacts.Models.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
        public object SkipLineCount { get { throw null; } set { } }
    }
    public partial class DelimitedTextSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public DelimitedTextSink() { }
        public Azure.Analytics.Synapse.Artifacts.Models.DelimitedTextWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class DelimitedTextSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public DelimitedTextSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DelimitedTextReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class DelimitedTextWriteSettings : Azure.Analytics.Synapse.Artifacts.Models.FormatWriteSettings
    {
        public DelimitedTextWriteSettings(object fileExtension) { }
        public object FileExtension { get { throw null; } set { } }
        public object FileNamePrefix { get { throw null; } set { } }
        public object MaxRowsPerFile { get { throw null; } set { } }
        public object QuoteAllText { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DependencyCondition : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.DependencyCondition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DependencyCondition(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.DependencyCondition Completed { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.DependencyCondition Failed { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.DependencyCondition Skipped { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.DependencyCondition Succeeded { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.DependencyCondition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.DependencyCondition left, Azure.Analytics.Synapse.Artifacts.Models.DependencyCondition right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.DependencyCondition (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.DependencyCondition left, Azure.Analytics.Synapse.Artifacts.Models.DependencyCondition right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DependencyReference
    {
        public DependencyReference() { }
    }
    public partial class DistcpSettings
    {
        public DistcpSettings(object resourceManagerEndpoint, object tempScriptPath) { }
        public object DistcpOptions { get { throw null; } set { } }
        public object ResourceManagerEndpoint { get { throw null; } set { } }
        public object TempScriptPath { get { throw null; } set { } }
    }
    public partial class DocumentDbCollectionDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public DocumentDbCollectionDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object collectionName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object CollectionName { get { throw null; } set { } }
    }
    public partial class DocumentDbCollectionSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public DocumentDbCollectionSink() { }
        public object NestingSeparator { get { throw null; } set { } }
        public object WriteBehavior { get { throw null; } set { } }
    }
    public partial class DocumentDbCollectionSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public DocumentDbCollectionSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object NestingSeparator { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
        public object QueryTimeout { get { throw null; } set { } }
    }
    public partial class DrillLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public DrillLinkedService() { }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference Pwd { get { throw null; } set { } }
    }
    public partial class DrillSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public DrillSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class DrillTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public DrillTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class DWCopyCommandDefaultValue
    {
        public DWCopyCommandDefaultValue() { }
        public object ColumnName { get { throw null; } set { } }
        public object DefaultValue { get { throw null; } set { } }
    }
    public partial class DWCopyCommandSettings
    {
        public DWCopyCommandSettings() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalOptions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DWCopyCommandDefaultValue> DefaultValues { get { throw null; } }
    }
    public partial class DynamicExecutorAllocation
    {
        public DynamicExecutorAllocation() { }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class DynamicsAXLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public DynamicsAXLinkedService(object url, object servicePrincipalId, Azure.Analytics.Synapse.Artifacts.Models.SecretBase servicePrincipalKey, object tenant, object aadResourceId) { }
        public object AadResourceId { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object Tenant { get { throw null; } set { } }
        public object Url { get { throw null; } set { } }
    }
    public partial class DynamicsAXResourceDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public DynamicsAXResourceDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object path) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Path { get { throw null; } set { } }
    }
    public partial class DynamicsAXSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public DynamicsAXSource() { }
        public object HttpRequestTimeout { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    public partial class DynamicsCrmEntityDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public DynamicsCrmEntityDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object EntityName { get { throw null; } set { } }
    }
    public partial class DynamicsCrmLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public DynamicsCrmLinkedService(object deploymentType, object authenticationType) { }
        public object AuthenticationType { get { throw null; } set { } }
        public object DeploymentType { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object HostName { get { throw null; } set { } }
        public object OrganizationName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Port { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalCredential { get { throw null; } set { } }
        public object ServicePrincipalCredentialType { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public object ServiceUri { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class DynamicsCrmSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public DynamicsCrmSink(Azure.Analytics.Synapse.Artifacts.Models.DynamicsSinkWriteBehavior writeBehavior) { }
        public object AlternateKeyName { get { throw null; } set { } }
        public object IgnoreNullValues { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DynamicsSinkWriteBehavior WriteBehavior { get { throw null; } set { } }
    }
    public partial class DynamicsCrmSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public DynamicsCrmSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    public partial class DynamicsEntityDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public DynamicsEntityDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object EntityName { get { throw null; } set { } }
    }
    public partial class DynamicsLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public DynamicsLinkedService(object deploymentType, object authenticationType) { }
        public object AuthenticationType { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public object DeploymentType { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object HostName { get { throw null; } set { } }
        public object OrganizationName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Port { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalCredential { get { throw null; } set { } }
        public object ServicePrincipalCredentialType { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public object ServiceUri { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class DynamicsSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public DynamicsSink(Azure.Analytics.Synapse.Artifacts.Models.DynamicsSinkWriteBehavior writeBehavior) { }
        public object AlternateKeyName { get { throw null; } set { } }
        public object IgnoreNullValues { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DynamicsSinkWriteBehavior WriteBehavior { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynamicsSinkWriteBehavior : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.DynamicsSinkWriteBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynamicsSinkWriteBehavior(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.DynamicsSinkWriteBehavior Upsert { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.DynamicsSinkWriteBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.DynamicsSinkWriteBehavior left, Azure.Analytics.Synapse.Artifacts.Models.DynamicsSinkWriteBehavior right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.DynamicsSinkWriteBehavior (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.DynamicsSinkWriteBehavior left, Azure.Analytics.Synapse.Artifacts.Models.DynamicsSinkWriteBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DynamicsSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public DynamicsSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    public partial class EditTablesRequest
    {
        public EditTablesRequest() { }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.LinkTableRequest> LinkTables { get { throw null; } }
    }
    public partial class EloquaLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public EloquaLinkedService(object endpoint, object username) { }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Endpoint { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class EloquaObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public EloquaObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class EloquaSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public EloquaSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class EncryptionDetails
    {
        public EncryptionDetails() { }
        public Azure.Analytics.Synapse.Artifacts.Models.CustomerManagedKeyDetails Cmk { get { throw null; } set { } }
        public bool? DoubleEncryptionEnabled { get { throw null; } }
    }
    public partial class EntityReference
    {
        public EntityReference() { }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEntityReferenceType? Type { get { throw null; } set { } }
    }
    public partial class EvaluateDataFlowExpressionRequest
    {
        public EvaluateDataFlowExpressionRequest() { }
        public string DataFlowName { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public int? RowLimits { get { throw null; } set { } }
        public string SessionId { get { throw null; } set { } }
        public string StreamName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventSubscriptionStatus : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.EventSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventSubscriptionStatus(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.EventSubscriptionStatus Deprovisioning { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.EventSubscriptionStatus Disabled { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.EventSubscriptionStatus Enabled { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.EventSubscriptionStatus Provisioning { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.EventSubscriptionStatus Unknown { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.EventSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.EventSubscriptionStatus left, Azure.Analytics.Synapse.Artifacts.Models.EventSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.EventSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.EventSubscriptionStatus left, Azure.Analytics.Synapse.Artifacts.Models.EventSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExcelDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public ExcelDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetCompression Compression { get { throw null; } set { } }
        public object FirstRowAsHeader { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation Location { get { throw null; } set { } }
        public object NullValue { get { throw null; } set { } }
        public object Range { get { throw null; } set { } }
        public object SheetIndex { get { throw null; } set { } }
        public object SheetName { get { throw null; } set { } }
    }
    public partial class ExcelSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public ExcelSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class ExecuteDataFlowActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public ExecuteDataFlowActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.DataFlowReference dataflow) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.ExecuteDataFlowActivityTypePropertiesCompute Compute { get { throw null; } set { } }
        public object ContinueOnError { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DataFlowReference Dataflow { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeReference IntegrationRuntime { get { throw null; } set { } }
        public object RunConcurrently { get { throw null; } set { } }
        public object SourceStagingConcurrency { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DataFlowStagingInfo Staging { get { throw null; } set { } }
        public object TraceLevel { get { throw null; } set { } }
    }
    public partial class ExecuteDataFlowActivityTypePropertiesCompute
    {
        public ExecuteDataFlowActivityTypePropertiesCompute() { }
        public Azure.Analytics.Synapse.Artifacts.Models.DataFlowComputeType? ComputeType { get { throw null; } set { } }
        public int? CoreCount { get { throw null; } set { } }
    }
    public partial class ExecutePipelineActivity : Azure.Analytics.Synapse.Artifacts.Models.ControlActivity
    {
        public ExecutePipelineActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.PipelineReference pipeline) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.PipelineReference Pipeline { get { throw null; } set { } }
        public bool? WaitOnCompletion { get { throw null; } set { } }
    }
    public partial class ExecuteSsisPackageActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public ExecuteSsisPackageActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.SsisPackageLocation packageLocation, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeReference connectVia) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeReference ConnectVia { get { throw null; } set { } }
        public object EnvironmentPath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SsisExecutionCredential ExecutionCredential { get { throw null; } set { } }
        public object LoggingLevel { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SsisLogLocation LogLocation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.SsisExecutionParameter>> PackageConnectionManagers { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.SsisPackageLocation PackageLocation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.SsisExecutionParameter> PackageParameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.SsisExecutionParameter>> ProjectConnectionManagers { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.SsisExecutionParameter> ProjectParameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.SsisPropertyOverride> PropertyOverrides { get { throw null; } }
        public object Runtime { get { throw null; } set { } }
    }
    public partial class ExecutionActivity : Azure.Analytics.Synapse.Artifacts.Models.Activity
    {
        public ExecutionActivity(string name) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.ActivityPolicy Policy { get { throw null; } set { } }
    }
    public abstract partial class ExportSettings
    {
        protected ExportSettings() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
    }
    public partial class ExposureControlRequest
    {
        public ExposureControlRequest() { }
        public string FeatureName { get { throw null; } set { } }
        public string FeatureType { get { throw null; } set { } }
    }
    public partial class ExposureControlResponse
    {
        public ExposureControlResponse() { }
        public string FeatureName { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class Expression
    {
        public Expression(Azure.Analytics.Synapse.Artifacts.Models.ExpressionType type, string value) { }
        public Azure.Analytics.Synapse.Artifacts.Models.ExpressionType Type { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpressionType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ExpressionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpressionType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ExpressionType Expression { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ExpressionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ExpressionType left, Azure.Analytics.Synapse.Artifacts.Models.ExpressionType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ExpressionType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ExpressionType left, Azure.Analytics.Synapse.Artifacts.Models.ExpressionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FailActivity : Azure.Analytics.Synapse.Artifacts.Models.ControlActivity
    {
        public FailActivity(string name, object message, object errorCode) : base (default(string)) { }
        public object ErrorCode { get { throw null; } set { } }
        public object Message { get { throw null; } set { } }
    }
    public partial class FileServerLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public FileServerLinkedService(object host) { }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object UserId { get { throw null; } set { } }
    }
    public partial class FileServerLocation : Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation
    {
        public FileServerLocation() { }
    }
    public partial class FileServerReadSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings
    {
        public FileServerReadSettings() { }
        public object DeleteFilesAfterCompletion { get { throw null; } set { } }
        public object EnablePartitionDiscovery { get { throw null; } set { } }
        public object FileFilter { get { throw null; } set { } }
        public object FileListPath { get { throw null; } set { } }
        public object ModifiedDatetimeEnd { get { throw null; } set { } }
        public object ModifiedDatetimeStart { get { throw null; } set { } }
        public object PartitionRootPath { get { throw null; } set { } }
        public object Recursive { get { throw null; } set { } }
        public object WildcardFileName { get { throw null; } set { } }
        public object WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class FileServerWriteSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreWriteSettings
    {
        public FileServerWriteSettings() { }
    }
    public partial class FileShareDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public FileShareDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetCompression Compression { get { throw null; } set { } }
        public object FileFilter { get { throw null; } set { } }
        public object FileName { get { throw null; } set { } }
        public object FolderPath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public object ModifiedDatetimeEnd { get { throw null; } set { } }
        public object ModifiedDatetimeStart { get { throw null; } set { } }
    }
    public partial class FileSystemSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public FileSystemSink() { }
        public object CopyBehavior { get { throw null; } set { } }
    }
    public partial class FileSystemSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public FileSystemSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object Recursive { get { throw null; } set { } }
    }
    public partial class FilterActivity : Azure.Analytics.Synapse.Artifacts.Models.ControlActivity
    {
        public FilterActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.Expression items, Azure.Analytics.Synapse.Artifacts.Models.Expression condition) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.Expression Condition { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.Expression Items { get { throw null; } set { } }
    }
    public partial class Flowlet : Azure.Analytics.Synapse.Artifacts.Models.DataFlow
    {
        public Flowlet() { }
        public string Script { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ScriptLines { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DataFlowSink> Sinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DataFlowSource> Sources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.Transformation> Transformations { get { throw null; } }
    }
    public partial class ForEachActivity : Azure.Analytics.Synapse.Artifacts.Models.ControlActivity
    {
        public ForEachActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.Expression items, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.Activity> activities) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.Activity> Activities { get { throw null; } }
        public int? BatchCount { get { throw null; } set { } }
        public bool? IsSequential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.Expression Items { get { throw null; } set { } }
    }
    public abstract partial class FormatReadSettings
    {
        protected FormatReadSettings() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
    }
    public abstract partial class FormatWriteSettings
    {
        protected FormatWriteSettings() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FtpAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.FtpAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FtpAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.FtpAuthenticationType Anonymous { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.FtpAuthenticationType Basic { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.FtpAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.FtpAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.FtpAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.FtpAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.FtpAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.FtpAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FtpReadSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings
    {
        public FtpReadSettings() { }
        public object DeleteFilesAfterCompletion { get { throw null; } set { } }
        public object DisableChunking { get { throw null; } set { } }
        public object EnablePartitionDiscovery { get { throw null; } set { } }
        public object FileListPath { get { throw null; } set { } }
        public object PartitionRootPath { get { throw null; } set { } }
        public object Recursive { get { throw null; } set { } }
        public object UseBinaryTransfer { get { throw null; } set { } }
        public object WildcardFileName { get { throw null; } set { } }
        public object WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class FtpServerLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public FtpServerLinkedService(object host) { }
        public Azure.Analytics.Synapse.Artifacts.Models.FtpAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public object EnableServerCertificateValidation { get { throw null; } set { } }
        public object EnableSsl { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Port { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class FtpServerLocation : Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation
    {
        public FtpServerLocation() { }
    }
    public partial class GetMetadataActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public GetMetadataActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.DatasetReference dataset) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetReference Dataset { get { throw null; } set { } }
        public System.Collections.Generic.IList<object> FieldList { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.FormatReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class GetSsisObjectMetadataRequest
    {
        public GetSsisObjectMetadataRequest() { }
        public string MetadataPath { get { throw null; } set { } }
    }
    public partial class GitHubAccessTokenRequest
    {
        public GitHubAccessTokenRequest(string gitHubClientId, string gitHubAccessCode, string gitHubAccessTokenBaseUrl) { }
        public string GitHubAccessCode { get { throw null; } }
        public string GitHubAccessTokenBaseUrl { get { throw null; } }
        public string GitHubClientId { get { throw null; } }
    }
    public partial class GitHubAccessTokenResponse
    {
        internal GitHubAccessTokenResponse() { }
        public string GitHubAccessToken { get { throw null; } }
    }
    public partial class GitHubClientSecret
    {
        public GitHubClientSecret() { }
        public string ByoaSecretAkvUrl { get { throw null; } set { } }
        public string ByoaSecretName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GoogleAdWordsAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.GoogleAdWordsAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GoogleAdWordsAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.GoogleAdWordsAuthenticationType ServiceAuthentication { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.GoogleAdWordsAuthenticationType UserAuthentication { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.GoogleAdWordsAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.GoogleAdWordsAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.GoogleAdWordsAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.GoogleAdWordsAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.GoogleAdWordsAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.GoogleAdWordsAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GoogleAdWordsLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public GoogleAdWordsLinkedService() { }
        public Azure.Analytics.Synapse.Artifacts.Models.GoogleAdWordsAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public object ClientCustomerID { get { throw null; } set { } }
        public object ClientId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public object ConnectionProperties { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase DeveloperToken { get { throw null; } set { } }
        public object Email { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object KeyFilePath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase RefreshToken { get { throw null; } set { } }
        public object TrustedCertPath { get { throw null; } set { } }
        public object UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class GoogleAdWordsObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public GoogleAdWordsObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class GoogleAdWordsSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public GoogleAdWordsSource() { }
        public object Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GoogleBigQueryAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.GoogleBigQueryAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GoogleBigQueryAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.GoogleBigQueryAuthenticationType ServiceAuthentication { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.GoogleBigQueryAuthenticationType UserAuthentication { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.GoogleBigQueryAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.GoogleBigQueryAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.GoogleBigQueryAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.GoogleBigQueryAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.GoogleBigQueryAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.GoogleBigQueryAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GoogleBigQueryLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public GoogleBigQueryLinkedService(object project, Azure.Analytics.Synapse.Artifacts.Models.GoogleBigQueryAuthenticationType authenticationType) { }
        public object AdditionalProjects { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.GoogleBigQueryAuthenticationType AuthenticationType { get { throw null; } set { } }
        public object ClientId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public object Email { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object KeyFilePath { get { throw null; } set { } }
        public object Project { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase RefreshToken { get { throw null; } set { } }
        public object RequestGoogleDriveScope { get { throw null; } set { } }
        public object TrustedCertPath { get { throw null; } set { } }
        public object UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class GoogleBigQueryObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public GoogleBigQueryObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Dataset { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class GoogleBigQuerySource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public GoogleBigQuerySource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class GoogleCloudStorageLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public GoogleCloudStorageLinkedService() { }
        public object AccessKeyId { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase SecretAccessKey { get { throw null; } set { } }
        public object ServiceUrl { get { throw null; } set { } }
    }
    public partial class GoogleCloudStorageLocation : Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation
    {
        public GoogleCloudStorageLocation() { }
        public object BucketName { get { throw null; } set { } }
        public object Version { get { throw null; } set { } }
    }
    public partial class GoogleCloudStorageReadSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings
    {
        public GoogleCloudStorageReadSettings() { }
        public object DeleteFilesAfterCompletion { get { throw null; } set { } }
        public object EnablePartitionDiscovery { get { throw null; } set { } }
        public object FileListPath { get { throw null; } set { } }
        public object ModifiedDatetimeEnd { get { throw null; } set { } }
        public object ModifiedDatetimeStart { get { throw null; } set { } }
        public object PartitionRootPath { get { throw null; } set { } }
        public object Prefix { get { throw null; } set { } }
        public object Recursive { get { throw null; } set { } }
        public object WildcardFileName { get { throw null; } set { } }
        public object WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class GoogleSheetsLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public GoogleSheetsLinkedService(Azure.Analytics.Synapse.Artifacts.Models.SecretBase apiToken) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ApiToken { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
    }
    public partial class GreenplumLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public GreenplumLinkedService() { }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference Pwd { get { throw null; } set { } }
    }
    public partial class GreenplumSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public GreenplumSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class GreenplumTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public GreenplumTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HBaseAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.HBaseAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HBaseAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.HBaseAuthenticationType Anonymous { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.HBaseAuthenticationType Basic { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.HBaseAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.HBaseAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.HBaseAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.HBaseAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.HBaseAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.HBaseAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HBaseLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public HBaseLinkedService(object host, Azure.Analytics.Synapse.Artifacts.Models.HBaseAuthenticationType authenticationType) { }
        public object AllowHostNameCNMismatch { get { throw null; } set { } }
        public object AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.HBaseAuthenticationType AuthenticationType { get { throw null; } set { } }
        public object EnableSsl { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public object HttpPath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Port { get { throw null; } set { } }
        public object TrustedCertPath { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class HBaseObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public HBaseObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class HBaseSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public HBaseSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class HdfsLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public HdfsLinkedService(object url) { }
        public object AuthenticationType { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Url { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class HdfsLocation : Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation
    {
        public HdfsLocation() { }
    }
    public partial class HdfsReadSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings
    {
        public HdfsReadSettings() { }
        public object DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DistcpSettings DistcpSettings { get { throw null; } set { } }
        public object EnablePartitionDiscovery { get { throw null; } set { } }
        public object FileListPath { get { throw null; } set { } }
        public object ModifiedDatetimeEnd { get { throw null; } set { } }
        public object ModifiedDatetimeStart { get { throw null; } set { } }
        public object PartitionRootPath { get { throw null; } set { } }
        public object Recursive { get { throw null; } set { } }
        public object WildcardFileName { get { throw null; } set { } }
        public object WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class HdfsSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public HdfsSource() { }
        public Azure.Analytics.Synapse.Artifacts.Models.DistcpSettings DistcpSettings { get { throw null; } set { } }
        public object Recursive { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightActivityDebugInfoOption : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.HDInsightActivityDebugInfoOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightActivityDebugInfoOption(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.HDInsightActivityDebugInfoOption Always { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.HDInsightActivityDebugInfoOption Failure { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.HDInsightActivityDebugInfoOption None { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.HDInsightActivityDebugInfoOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.HDInsightActivityDebugInfoOption left, Azure.Analytics.Synapse.Artifacts.Models.HDInsightActivityDebugInfoOption right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.HDInsightActivityDebugInfoOption (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.HDInsightActivityDebugInfoOption left, Azure.Analytics.Synapse.Artifacts.Models.HDInsightActivityDebugInfoOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightHiveActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public HDInsightHiveActivity(string name) : base (default(string)) { }
        public System.Collections.Generic.IList<object> Arguments { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> Defines { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.HDInsightActivityDebugInfoOption? GetDebugInfo { get { throw null; } set { } }
        public int? QueryTimeout { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference ScriptLinkedService { get { throw null; } set { } }
        public object ScriptPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference> StorageLinkedServices { get { throw null; } }
        public System.Collections.Generic.IList<object> Variables { get { throw null; } }
    }
    public partial class HDInsightLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public HDInsightLinkedService(object clusterUri) { }
        public object ClusterUri { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object FileSystem { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference HcatalogLinkedServiceName { get { throw null; } set { } }
        public object IsEspEnabled { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class HDInsightMapReduceActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public HDInsightMapReduceActivity(string name, object className, object jarFilePath) : base (default(string)) { }
        public System.Collections.Generic.IList<object> Arguments { get { throw null; } }
        public object ClassName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Defines { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.HDInsightActivityDebugInfoOption? GetDebugInfo { get { throw null; } set { } }
        public object JarFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<object> JarLibs { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference JarLinkedService { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference> StorageLinkedServices { get { throw null; } }
    }
    public partial class HDInsightOnDemandLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public HDInsightOnDemandLinkedService(object clusterSize, object timeToLive, object version, Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object hostSubscriptionId, object tenant, object clusterResourceGroup) { }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference> AdditionalLinkedServiceNames { get { throw null; } }
        public object ClusterNamePrefix { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ClusterPassword { get { throw null; } set { } }
        public object ClusterResourceGroup { get { throw null; } set { } }
        public object ClusterSize { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ClusterSshPassword { get { throw null; } set { } }
        public object ClusterSshUserName { get { throw null; } set { } }
        public object ClusterType { get { throw null; } set { } }
        public object ClusterUserName { get { throw null; } set { } }
        public object CoreConfiguration { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public object DataNodeSize { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object HBaseConfiguration { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference HcatalogLinkedServiceName { get { throw null; } set { } }
        public object HdfsConfiguration { get { throw null; } set { } }
        public object HeadNodeSize { get { throw null; } set { } }
        public object HiveConfiguration { get { throw null; } set { } }
        public object HostSubscriptionId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public object MapReduceConfiguration { get { throw null; } set { } }
        public object OozieConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.ScriptAction> ScriptActions { get { throw null; } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object SparkVersion { get { throw null; } set { } }
        public object StormConfiguration { get { throw null; } set { } }
        public object SubnetName { get { throw null; } set { } }
        public object Tenant { get { throw null; } set { } }
        public object TimeToLive { get { throw null; } set { } }
        public object Version { get { throw null; } set { } }
        public object VirtualNetworkId { get { throw null; } set { } }
        public object YarnConfiguration { get { throw null; } set { } }
        public object ZookeeperNodeSize { get { throw null; } set { } }
    }
    public partial class HDInsightPigActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public HDInsightPigActivity(string name) : base (default(string)) { }
        public object Arguments { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Defines { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.HDInsightActivityDebugInfoOption? GetDebugInfo { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference ScriptLinkedService { get { throw null; } set { } }
        public object ScriptPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference> StorageLinkedServices { get { throw null; } }
    }
    public partial class HDInsightSparkActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public HDInsightSparkActivity(string name, object rootPath, object entryFilePath) : base (default(string)) { }
        public System.Collections.Generic.IList<object> Arguments { get { throw null; } }
        public string ClassName { get { throw null; } set { } }
        public object EntryFilePath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.HDInsightActivityDebugInfoOption? GetDebugInfo { get { throw null; } set { } }
        public object ProxyUser { get { throw null; } set { } }
        public object RootPath { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> SparkConfig { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference SparkJobLinkedService { get { throw null; } set { } }
    }
    public partial class HDInsightStreamingActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public HDInsightStreamingActivity(string name, object mapper, object reducer, object input, object output, System.Collections.Generic.IEnumerable<object> filePaths) : base (default(string)) { }
        public System.Collections.Generic.IList<object> Arguments { get { throw null; } }
        public object Combiner { get { throw null; } set { } }
        public System.Collections.Generic.IList<object> CommandEnvironment { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> Defines { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference FileLinkedService { get { throw null; } set { } }
        public System.Collections.Generic.IList<object> FilePaths { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.HDInsightActivityDebugInfoOption? GetDebugInfo { get { throw null; } set { } }
        public object Input { get { throw null; } set { } }
        public object Mapper { get { throw null; } set { } }
        public object Output { get { throw null; } set { } }
        public object Reducer { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference> StorageLinkedServices { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HiveAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.HiveAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HiveAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.HiveAuthenticationType Anonymous { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.HiveAuthenticationType Username { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.HiveAuthenticationType UsernameAndPassword { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.HiveAuthenticationType WindowsAzureHDInsightService { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.HiveAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.HiveAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.HiveAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.HiveAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.HiveAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.HiveAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HiveLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public HiveLinkedService(object host, Azure.Analytics.Synapse.Artifacts.Models.HiveAuthenticationType authenticationType) { }
        public object AllowHostNameCNMismatch { get { throw null; } set { } }
        public object AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.HiveAuthenticationType AuthenticationType { get { throw null; } set { } }
        public object EnableSsl { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public object HttpPath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Port { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.HiveServerType? ServerType { get { throw null; } set { } }
        public object ServiceDiscoveryMode { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.HiveThriftTransportProtocol? ThriftTransportProtocol { get { throw null; } set { } }
        public object TrustedCertPath { get { throw null; } set { } }
        public object UseNativeQuery { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
        public object UseSystemTrustStore { get { throw null; } set { } }
        public object ZooKeeperNameSpace { get { throw null; } set { } }
    }
    public partial class HiveObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public HiveObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HiveServerType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.HiveServerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HiveServerType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.HiveServerType HiveServer1 { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.HiveServerType HiveServer2 { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.HiveServerType HiveThriftServer { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.HiveServerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.HiveServerType left, Azure.Analytics.Synapse.Artifacts.Models.HiveServerType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.HiveServerType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.HiveServerType left, Azure.Analytics.Synapse.Artifacts.Models.HiveServerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HiveSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public HiveSource() { }
        public object Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HiveThriftTransportProtocol : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.HiveThriftTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HiveThriftTransportProtocol(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.HiveThriftTransportProtocol Binary { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.HiveThriftTransportProtocol Http { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.HiveThriftTransportProtocol Sasl { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.HiveThriftTransportProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.HiveThriftTransportProtocol left, Azure.Analytics.Synapse.Artifacts.Models.HiveThriftTransportProtocol right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.HiveThriftTransportProtocol (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.HiveThriftTransportProtocol left, Azure.Analytics.Synapse.Artifacts.Models.HiveThriftTransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.HttpAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.HttpAuthenticationType Anonymous { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.HttpAuthenticationType Basic { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.HttpAuthenticationType ClientCertificate { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.HttpAuthenticationType Digest { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.HttpAuthenticationType Windows { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.HttpAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.HttpAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.HttpAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.HttpAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.HttpAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.HttpAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HttpDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public HttpDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object AdditionalHeaders { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetStorageFormat Format { get { throw null; } set { } }
        public object RelativeUrl { get { throw null; } set { } }
        public object RequestBody { get { throw null; } set { } }
        public object RequestMethod { get { throw null; } set { } }
    }
    public partial class HttpLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public HttpLinkedService(object url) { }
        public Azure.Analytics.Synapse.Artifacts.Models.HttpAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public object CertThumbprint { get { throw null; } set { } }
        public object EmbeddedCertData { get { throw null; } set { } }
        public object EnableServerCertificateValidation { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Url { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class HttpReadSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings
    {
        public HttpReadSettings() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object AdditionalHeaders { get { throw null; } set { } }
        public object EnablePartitionDiscovery { get { throw null; } set { } }
        public object PartitionRootPath { get { throw null; } set { } }
        public object RequestBody { get { throw null; } set { } }
        public object RequestMethod { get { throw null; } set { } }
        public object RequestTimeout { get { throw null; } set { } }
    }
    public partial class HttpServerLocation : Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation
    {
        public HttpServerLocation() { }
        public object RelativeUrl { get { throw null; } set { } }
    }
    public partial class HttpSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public HttpSource() { }
        public object HttpRequestTimeout { get { throw null; } set { } }
    }
    public partial class HubspotLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public HubspotLinkedService(object clientId) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase AccessToken { get { throw null; } set { } }
        public object ClientId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase RefreshToken { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
    }
    public partial class HubspotObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public HubspotObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class HubspotSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public HubspotSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class IfConditionActivity : Azure.Analytics.Synapse.Artifacts.Models.ControlActivity
    {
        public IfConditionActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.Expression expression) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.Expression Expression { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.Activity> IfFalseActivities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.Activity> IfTrueActivities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImpalaAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ImpalaAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImpalaAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ImpalaAuthenticationType Anonymous { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ImpalaAuthenticationType SaslUsername { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ImpalaAuthenticationType UsernameAndPassword { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ImpalaAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ImpalaAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.ImpalaAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ImpalaAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ImpalaAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.ImpalaAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImpalaLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public ImpalaLinkedService(object host, Azure.Analytics.Synapse.Artifacts.Models.ImpalaAuthenticationType authenticationType) { }
        public object AllowHostNameCNMismatch { get { throw null; } set { } }
        public object AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.ImpalaAuthenticationType AuthenticationType { get { throw null; } set { } }
        public object EnableSsl { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Port { get { throw null; } set { } }
        public object TrustedCertPath { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
        public object UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class ImpalaObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public ImpalaObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class ImpalaSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public ImpalaSource() { }
        public object Query { get { throw null; } set { } }
    }
    public abstract partial class ImportSettings
    {
        protected ImportSettings() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
    }
    public partial class InformixLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public InformixLinkedService(object connectionString) { }
        public object AuthenticationType { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Credential { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class InformixSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public InformixSink() { }
        public object PreCopyScript { get { throw null; } set { } }
    }
    public partial class InformixSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public InformixSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class InformixTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public InformixTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public abstract partial class IntegrationRuntime
    {
        protected IntegrationRuntime() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public string Description { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeComputeProperties
    {
        public IntegrationRuntimeComputeProperties() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeDataFlowProperties DataFlowProperties { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public int? MaxParallelExecutionsPerNode { get { throw null; } set { } }
        public string NodeSize { get { throw null; } set { } }
        public int? NumberOfNodes { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeVNetProperties VNetProperties { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeCustomSetupScriptProperties
    {
        public IntegrationRuntimeCustomSetupScriptProperties() { }
        public string BlobContainerUri { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecureString SasToken { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeDataFlowProperties
    {
        public IntegrationRuntimeDataFlowProperties() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public bool? Cleanup { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DataFlowComputeType? ComputeType { get { throw null; } set { } }
        public int? CoreCount { get { throw null; } set { } }
        public int? TimeToLive { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeDataProxyProperties
    {
        public IntegrationRuntimeDataProxyProperties() { }
        public Azure.Analytics.Synapse.Artifacts.Models.EntityReference ConnectVia { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.EntityReference StagingLinkedService { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeDebugResource : Azure.Analytics.Synapse.Artifacts.Models.SubResourceDebugResource
    {
        public IntegrationRuntimeDebugResource(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntime properties) { }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntime Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeEdition : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEdition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeEdition(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEdition Enterprise { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEdition Standard { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEdition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEdition left, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEdition right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEdition (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEdition left, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEdition right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeEntityReferenceType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEntityReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeEntityReferenceType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEntityReferenceType IntegrationRuntimeReference { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEntityReferenceType LinkedServiceReference { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEntityReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEntityReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEntityReferenceType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEntityReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEntityReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEntityReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeLicenseType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeLicenseType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeLicenseType BasePrice { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeLicenseType LicenseIncluded { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeLicenseType left, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeLicenseType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeLicenseType left, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeListResponse
    {
        internal IntegrationRuntimeListResponse() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeResource> Value { get { throw null; } }
    }
    public partial class IntegrationRuntimeReference
    {
        public IntegrationRuntimeReference(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeReferenceType type, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeReferenceType Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeReferenceType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeReferenceType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeReferenceType IntegrationRuntimeReference { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeReferenceType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeResource : Azure.Analytics.Synapse.Artifacts.Models.SubResource
    {
        public IntegrationRuntimeResource(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntime properties) { }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntime Properties { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeSsisCatalogInfo
    {
        public IntegrationRuntimeSsisCatalogInfo() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecureString CatalogAdminPassword { get { throw null; } set { } }
        public string CatalogAdminUserName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeSsisCatalogPricingTier? CatalogPricingTier { get { throw null; } set { } }
        public string CatalogServerEndpoint { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeSsisCatalogPricingTier : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeSsisCatalogPricingTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeSsisCatalogPricingTier(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeSsisCatalogPricingTier Basic { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeSsisCatalogPricingTier Premium { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeSsisCatalogPricingTier PremiumRS { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeSsisCatalogPricingTier Standard { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeSsisCatalogPricingTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeSsisCatalogPricingTier left, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeSsisCatalogPricingTier right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeSsisCatalogPricingTier (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeSsisCatalogPricingTier left, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeSsisCatalogPricingTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeSsisProperties
    {
        public IntegrationRuntimeSsisProperties() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeSsisCatalogInfo CatalogInfo { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeCustomSetupScriptProperties CustomSetupScriptProperties { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeDataProxyProperties DataProxyProperties { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeEdition? Edition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.CustomSetupBase> ExpressCustomSetupProperties { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeLicenseType? LicenseType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeState : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeState(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState AccessDenied { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState Initial { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState Limited { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState NeedRegistration { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState Offline { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState Online { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState Started { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState Starting { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState Stopped { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState Stopping { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState left, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState left, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeType Managed { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeType SelfHosted { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeType left, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeType left, Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeVNetProperties
    {
        public IntegrationRuntimeVNetProperties() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<string> PublicIPs { get { throw null; } }
        public string Subnet { get { throw null; } set { } }
        public string VNetId { get { throw null; } set { } }
    }
    public partial class JiraLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public JiraLinkedService(object host, object username) { }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Port { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class JiraObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public JiraObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class JiraSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public JiraSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class JsonDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public JsonDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetCompression Compression { get { throw null; } set { } }
        public object EncodingName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation Location { get { throw null; } set { } }
    }
    public partial class JsonFormat : Azure.Analytics.Synapse.Artifacts.Models.DatasetStorageFormat
    {
        public JsonFormat() { }
        public object EncodingName { get { throw null; } set { } }
        public object FilePattern { get { throw null; } set { } }
        public object JsonNodeReference { get { throw null; } set { } }
        public object JsonPathDefinition { get { throw null; } set { } }
        public object NestingSeparator { get { throw null; } set { } }
    }
    public partial class JsonReadSettings : Azure.Analytics.Synapse.Artifacts.Models.FormatReadSettings
    {
        public JsonReadSettings() { }
        public Azure.Analytics.Synapse.Artifacts.Models.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
    }
    public partial class JsonSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public JsonSink() { }
        public Azure.Analytics.Synapse.Artifacts.Models.JsonWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class JsonSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public JsonSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.JsonReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class JsonWriteSettings : Azure.Analytics.Synapse.Artifacts.Models.FormatWriteSettings
    {
        public JsonWriteSettings() { }
        public object FilePattern { get { throw null; } set { } }
    }
    public partial class KqlScript
    {
        public KqlScript() { }
        public Azure.Analytics.Synapse.Artifacts.Models.KqlScriptContent Content { get { throw null; } set { } }
    }
    public partial class KqlScriptContent
    {
        public KqlScriptContent() { }
        public Azure.Analytics.Synapse.Artifacts.Models.KqlScriptContentCurrentConnection CurrentConnection { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.KqlScriptContentMetadata Metadata { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
    }
    public partial class KqlScriptContentCurrentConnection
    {
        public KqlScriptContentCurrentConnection() { }
        public string DatabaseName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string PoolName { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    public partial class KqlScriptContentMetadata
    {
        public KqlScriptContentMetadata() { }
        public string Language { get { throw null; } set { } }
    }
    public partial class KqlScriptResource
    {
        public KqlScriptResource() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.KqlScript Properties { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    public partial class LibraryInfo
    {
        public LibraryInfo() { }
        public string ContainerName { get { throw null; } set { } }
        public string CreatorId { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string ProvisioningStatus { get { throw null; } }
        public string Type { get { throw null; } set { } }
        public System.DateTimeOffset? UploadedTimestamp { get { throw null; } set { } }
    }
    public partial class LibraryRequirements
    {
        public LibraryRequirements() { }
        public string Content { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public partial class LibraryResource : Azure.Analytics.Synapse.Artifacts.Models.SubResource
    {
        public LibraryResource(Azure.Analytics.Synapse.Artifacts.Models.LibraryResourceProperties properties) { }
        public Azure.Analytics.Synapse.Artifacts.Models.LibraryResourceProperties Properties { get { throw null; } set { } }
    }
    public partial class LibraryResourceInfo
    {
        internal LibraryResourceInfo() { }
        public string ArtifactId { get { throw null; } }
        public string Changed { get { throw null; } }
        public string Created { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string OperationId { get { throw null; } }
        public int? RecordId { get { throw null; } }
        public string State { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class LibraryResourceProperties
    {
        public LibraryResourceProperties() { }
        public string ContainerName { get { throw null; } }
        public string CreatorId { get { throw null; } }
        public string Name { get { throw null; } }
        public string Path { get { throw null; } }
        public string ProvisioningStatus { get { throw null; } }
        public string Type { get { throw null; } }
        public string UploadedTimestamp { get { throw null; } }
    }
    public partial class LinkConnection
    {
        public LinkConnection() { }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionCompute Compute { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionLandingZone LandingZone { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionSourceDatabase SourceDatabase { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionTargetDatabase TargetDatabase { get { throw null; } set { } }
    }
    public partial class LinkConnectionCompute
    {
        public LinkConnectionCompute() { }
        public string ComputeType { get { throw null; } set { } }
        public int? CoreCount { get { throw null; } set { } }
        public int? DataProcessIntervalMinutes { get { throw null; } set { } }
    }
    public partial class LinkConnectionDetailedStatus
    {
        internal LinkConnectionDetailedStatus() { }
        public string ContinuousRunId { get { throw null; } }
        public object Error { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsApplyingChanges { get { throw null; } }
        public bool? IsPartiallyFailed { get { throw null; } }
        public System.DateTimeOffset? LandingZoneCredentialExpireTime { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionRefreshStatus RefreshStatus { get { throw null; } }
        public object StartTime { get { throw null; } }
        public string Status { get { throw null; } }
        public object StopTime { get { throw null; } }
    }
    public partial class LinkConnectionLandingZone
    {
        public LinkConnectionLandingZone() { }
        public string FileSystem { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference LinkedService { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecureString SasToken { get { throw null; } set { } }
    }
    public partial class LinkConnectionQueryTableStatus
    {
        internal LinkConnectionQueryTableStatus() { }
        public object ContinuationToken { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Artifacts.Models.LinkTableStatus> Value { get { throw null; } }
    }
    public partial class LinkConnectionRefreshStatus
    {
        internal LinkConnectionRefreshStatus() { }
        public string ErrorMessage { get { throw null; } }
        public string RefreshStatus { get { throw null; } }
    }
    public partial class LinkConnectionResource
    {
        public LinkConnectionResource(Azure.Analytics.Synapse.Artifacts.Models.LinkConnection properties) { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkConnection Properties { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    public partial class LinkConnectionSourceDatabase
    {
        public LinkConnectionSourceDatabase() { }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference LinkedService { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionSourceDatabaseTypeProperties TypeProperties { get { throw null; } set { } }
    }
    public partial class LinkConnectionSourceDatabaseTypeProperties
    {
        public LinkConnectionSourceDatabaseTypeProperties() { }
        public string PrincipalId { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class LinkConnectionTargetDatabase
    {
        public LinkConnectionTargetDatabase() { }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference LinkedService { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkConnectionTargetDatabaseTypeProperties TypeProperties { get { throw null; } set { } }
    }
    public partial class LinkConnectionTargetDatabaseTypeProperties
    {
        public LinkConnectionTargetDatabaseTypeProperties() { }
        public Azure.Analytics.Synapse.Artifacts.Models.ActionOnExistingTargetTable? ActionOnExistingTargetTable { get { throw null; } set { } }
        public bool? CrossTableTransaction { get { throw null; } set { } }
        public bool? DropExistingTargetTableOnStart { get { throw null; } set { } }
    }
    public partial class LinkedIntegrationRuntimeKeyAuthorization : Azure.Analytics.Synapse.Artifacts.Models.LinkedIntegrationRuntimeType
    {
        public LinkedIntegrationRuntimeKeyAuthorization(Azure.Analytics.Synapse.Artifacts.Models.SecureString key) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecureString Key { get { throw null; } set { } }
    }
    public partial class LinkedIntegrationRuntimeRbacAuthorization : Azure.Analytics.Synapse.Artifacts.Models.LinkedIntegrationRuntimeType
    {
        public LinkedIntegrationRuntimeRbacAuthorization(string resourceId) { }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class LinkedIntegrationRuntimeType
    {
        public LinkedIntegrationRuntimeType() { }
    }
    public abstract partial class LinkedService
    {
        protected LinkedService() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<object> Annotations { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeReference ConnectVia { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.ParameterSpecification> Parameters { get { throw null; } }
    }
    public partial class LinkedServiceDebugResource : Azure.Analytics.Synapse.Artifacts.Models.SubResourceDebugResource
    {
        public LinkedServiceDebugResource(Azure.Analytics.Synapse.Artifacts.Models.LinkedService properties) { }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedService Properties { get { throw null; } set { } }
    }
    public partial class LinkedServiceReference
    {
        public LinkedServiceReference(Azure.Analytics.Synapse.Artifacts.LinkedServiceReferenceType type, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.LinkedServiceReferenceType Type { get { throw null; } set { } }
    }
    public partial class LinkedServiceResource : Azure.Analytics.Synapse.Artifacts.Models.SubResource
    {
        public LinkedServiceResource(Azure.Analytics.Synapse.Artifacts.Models.LinkedService properties) { }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedService Properties { get { throw null; } set { } }
    }
    public partial class LinkTableListResponse
    {
        internal LinkTableListResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Artifacts.Models.LinkTableResource> Value { get { throw null; } }
    }
    public partial class LinkTableRequest
    {
        public LinkTableRequest() { }
        public string Id { get { throw null; } set { } }
        public string OperationType { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkTableRequestSource Source { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkTableRequestTarget Target { get { throw null; } set { } }
    }
    public partial class LinkTableRequestSource
    {
        public LinkTableRequestSource() { }
        public string SchemaName { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    public partial class LinkTableRequestTarget
    {
        public LinkTableRequestTarget() { }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkTableRequestTargetDistributionOptions DistributionOptions { get { throw null; } set { } }
        public string SchemaName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkTableRequestTargetStructureOptions StructureOptions { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    public partial class LinkTableRequestTargetDistributionOptions
    {
        public LinkTableRequestTargetDistributionOptions() { }
        public string DistributionColumn { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    public partial class LinkTableRequestTargetStructureOptions
    {
        public LinkTableRequestTargetStructureOptions() { }
        public string Type { get { throw null; } set { } }
    }
    public partial class LinkTableResource
    {
        internal LinkTableResource() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkTableRequestSource Source { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkTableRequestTarget Target { get { throw null; } }
    }
    public partial class LinkTableStatus
    {
        internal LinkTableStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastProcessedData { get { throw null; } }
        public System.DateTimeOffset? LastTransactionCommitTime { get { throw null; } }
        public string LinkTableId { get { throw null; } }
        public object StartTime { get { throw null; } }
        public string Status { get { throw null; } }
        public object StopTime { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LivyStates : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.LivyStates>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LivyStates(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.LivyStates Busy { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.LivyStates Dead { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.LivyStates Error { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.LivyStates Idle { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.LivyStates Killed { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.LivyStates NotStarted { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.LivyStates Recovering { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.LivyStates Running { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.LivyStates ShuttingDown { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.LivyStates Starting { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.LivyStates Success { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.LivyStates other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.LivyStates left, Azure.Analytics.Synapse.Artifacts.Models.LivyStates right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.LivyStates (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.LivyStates left, Azure.Analytics.Synapse.Artifacts.Models.LivyStates right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogLocationSettings
    {
        public LogLocationSettings(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) { }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public object Path { get { throw null; } set { } }
    }
    public partial class LogSettings
    {
        public LogSettings(Azure.Analytics.Synapse.Artifacts.Models.LogLocationSettings logLocationSettings) { }
        public Azure.Analytics.Synapse.Artifacts.Models.CopyActivityLogSettings CopyActivityLogSettings { get { throw null; } set { } }
        public object EnableCopyActivityLog { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LogLocationSettings LogLocationSettings { get { throw null; } set { } }
    }
    public partial class LogStorageSettings
    {
        public LogStorageSettings(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object EnableReliableLogging { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public object LogLevel { get { throw null; } set { } }
        public object Path { get { throw null; } set { } }
    }
    public partial class LookupActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public LookupActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.CopySource source, Azure.Analytics.Synapse.Artifacts.Models.DatasetReference dataset) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetReference Dataset { get { throw null; } set { } }
        public object FirstRowOnly { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CopySource Source { get { throw null; } set { } }
    }
    public partial class MagentoLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public MagentoLinkedService(object host) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase AccessToken { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
    }
    public partial class MagentoObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public MagentoObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class MagentoSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public MagentoSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class ManagedIdentity
    {
        public ManagedIdentity() { }
        public string PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.ResourceIdentityType? Type { get { throw null; } set { } }
    }
    public partial class ManagedIntegrationRuntime : Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntime
    {
        public ManagedIntegrationRuntime() { }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeComputeProperties ComputeProperties { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkReference ManagedVirtualNetwork { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeSsisProperties SsisProperties { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeState? State { get { throw null; } }
    }
    public partial class ManagedVirtualNetworkReference
    {
        public ManagedVirtualNetworkReference(string referenceName) { }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkReferenceType Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedVirtualNetworkReferenceType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedVirtualNetworkReferenceType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkReferenceType ManagedVirtualNetworkReference { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkReferenceType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedVirtualNetworkSettings
    {
        public ManagedVirtualNetworkSettings() { }
        public System.Collections.Generic.IList<string> AllowedAadTenantIdsForLinking { get { throw null; } }
        public bool? LinkedAccessCheckOnTargetResource { get { throw null; } set { } }
        public bool? PreventDataExfiltration { get { throw null; } set { } }
    }
    public partial class MappingDataFlow : Azure.Analytics.Synapse.Artifacts.Models.DataFlow
    {
        public MappingDataFlow() { }
        public string Script { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ScriptLines { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DataFlowSink> Sinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DataFlowSource> Sources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.Transformation> Transformations { get { throw null; } }
    }
    public partial class MariaDBLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public MariaDBLinkedService() { }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference Pwd { get { throw null; } set { } }
    }
    public partial class MariaDBSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public MariaDBSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class MariaDBTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public MariaDBTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class MarketoLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public MarketoLinkedService(object endpoint, object clientId) { }
        public object ClientId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Endpoint { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
    }
    public partial class MarketoObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public MarketoObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class MarketoSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public MarketoSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class MetastoreRegisterObject
    {
        public MetastoreRegisterObject(string inputFolder) { }
        public string InputFolder { get { throw null; } }
    }
    public partial class MetastoreRegistrationResponse
    {
        internal MetastoreRegistrationResponse() { }
        public Azure.Analytics.Synapse.Artifacts.Models.RequestStatus? Status { get { throw null; } }
    }
    public partial class MetastoreRequestSuccessResponse
    {
        internal MetastoreRequestSuccessResponse() { }
        public Azure.Analytics.Synapse.Artifacts.Models.ResourceStatus? Status { get { throw null; } }
    }
    public partial class MetastoreUpdateObject
    {
        public MetastoreUpdateObject(string inputFolder) { }
        public string InputFolder { get { throw null; } }
    }
    public partial class MetastoreUpdationResponse
    {
        internal MetastoreUpdationResponse() { }
        public Azure.Analytics.Synapse.Artifacts.Models.RequestStatus? Status { get { throw null; } }
    }
    public partial class MicrosoftAccessLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public MicrosoftAccessLinkedService(object connectionString) { }
        public object AuthenticationType { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Credential { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class MicrosoftAccessSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public MicrosoftAccessSink() { }
        public object PreCopyScript { get { throw null; } set { } }
    }
    public partial class MicrosoftAccessSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public MicrosoftAccessSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    public partial class MicrosoftAccessTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public MicrosoftAccessTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class MongoDbAtlasCollectionDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public MongoDbAtlasCollectionDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object collection) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Collection { get { throw null; } set { } }
    }
    public partial class MongoDbAtlasLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public MongoDbAtlasLinkedService(object connectionString, object database) { }
        public object ConnectionString { get { throw null; } set { } }
        public object Database { get { throw null; } set { } }
        public object DriverVersion { get { throw null; } set { } }
    }
    public partial class MongoDbAtlasSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public MongoDbAtlasSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object BatchSize { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.MongoDbCursorMethodsProperties CursorMethods { get { throw null; } set { } }
        public object Filter { get { throw null; } set { } }
        public object QueryTimeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoDbAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.MongoDbAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoDbAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.MongoDbAuthenticationType Anonymous { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.MongoDbAuthenticationType Basic { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.MongoDbAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.MongoDbAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.MongoDbAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.MongoDbAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.MongoDbAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.MongoDbAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoDbCollectionDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public MongoDbCollectionDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object collectionName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object CollectionName { get { throw null; } set { } }
    }
    public partial class MongoDbCursorMethodsProperties
    {
        public MongoDbCursorMethodsProperties() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object Limit { get { throw null; } set { } }
        public object Project { get { throw null; } set { } }
        public object Skip { get { throw null; } set { } }
        public object Sort { get { throw null; } set { } }
    }
    public partial class MongoDbLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public MongoDbLinkedService(object server, object databaseName) { }
        public object AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.MongoDbAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public object AuthSource { get { throw null; } set { } }
        public object DatabaseName { get { throw null; } set { } }
        public object EnableSsl { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Port { get { throw null; } set { } }
        public object Server { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class MongoDbSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public MongoDbSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    public partial class MongoDbV2CollectionDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public MongoDbV2CollectionDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object collection) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Collection { get { throw null; } set { } }
    }
    public partial class MongoDbV2LinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public MongoDbV2LinkedService(object connectionString, object database) { }
        public object ConnectionString { get { throw null; } set { } }
        public object Database { get { throw null; } set { } }
    }
    public partial class MongoDbV2Source : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public MongoDbV2Source() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object BatchSize { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.MongoDbCursorMethodsProperties CursorMethods { get { throw null; } set { } }
        public object Filter { get { throw null; } set { } }
        public object QueryTimeout { get { throw null; } set { } }
    }
    public partial class MultiplePipelineTrigger : Azure.Analytics.Synapse.Artifacts.Models.Trigger
    {
        public MultiplePipelineTrigger() { }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.TriggerPipelineReference> Pipelines { get { throw null; } }
    }
    public partial class MySqlLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public MySqlLinkedService(object connectionString) { }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class MySqlSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public MySqlSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class MySqlTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public MySqlTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class NetezzaLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public NetezzaLinkedService() { }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference Pwd { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetezzaPartitionOption : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.NetezzaPartitionOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetezzaPartitionOption(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.NetezzaPartitionOption DataSlice { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.NetezzaPartitionOption DynamicRange { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.NetezzaPartitionOption None { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.NetezzaPartitionOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.NetezzaPartitionOption left, Azure.Analytics.Synapse.Artifacts.Models.NetezzaPartitionOption right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.NetezzaPartitionOption (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.NetezzaPartitionOption left, Azure.Analytics.Synapse.Artifacts.Models.NetezzaPartitionOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetezzaPartitionSettings
    {
        public NetezzaPartitionSettings() { }
        public object PartitionColumnName { get { throw null; } set { } }
        public object PartitionLowerBound { get { throw null; } set { } }
        public object PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class NetezzaSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public NetezzaSource() { }
        public Azure.Analytics.Synapse.Artifacts.Models.NetezzaPartitionOption? PartitionOption { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.NetezzaPartitionSettings PartitionSettings { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    public partial class NetezzaTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public NetezzaTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeSize : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.NodeSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeSize(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.NodeSize Large { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.NodeSize Medium { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.NodeSize None { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.NodeSize Small { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.NodeSize XLarge { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.NodeSize XXLarge { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.NodeSize XXXLarge { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.NodeSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.NodeSize left, Azure.Analytics.Synapse.Artifacts.Models.NodeSize right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.NodeSize (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.NodeSize left, Azure.Analytics.Synapse.Artifacts.Models.NodeSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeSizeFamily : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.NodeSizeFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeSizeFamily(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.NodeSizeFamily MemoryOptimized { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.NodeSizeFamily None { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.NodeSizeFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.NodeSizeFamily left, Azure.Analytics.Synapse.Artifacts.Models.NodeSizeFamily right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.NodeSizeFamily (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.NodeSizeFamily left, Azure.Analytics.Synapse.Artifacts.Models.NodeSizeFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Notebook
    {
        public Notebook(Azure.Analytics.Synapse.Artifacts.Models.NotebookMetadata metadata, int notebookFormat, int notebookFormatMinor, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.NotebookCell> cells) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolReference BigDataPool { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.NotebookCell> Cells { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.NotebookFolder Folder { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.NotebookMetadata Metadata { get { throw null; } set { } }
        public int NotebookFormat { get { throw null; } set { } }
        public int NotebookFormatMinor { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.NotebookSessionProperties SessionProperties { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationReference TargetSparkConfiguration { get { throw null; } set { } }
    }
    public partial class NotebookCell
    {
        public NotebookCell(string cellType, object metadata, System.Collections.Generic.IEnumerable<string> source) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object Attachments { get { throw null; } set { } }
        public string CellType { get { throw null; } set { } }
        public object Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.NotebookCellOutputItem> Outputs { get { throw null; } }
        public System.Collections.Generic.IList<string> Source { get { throw null; } }
    }
    public partial class NotebookCellOutputItem
    {
        public NotebookCellOutputItem(Azure.Analytics.Synapse.Artifacts.Models.CellOutputType outputType) { }
        public object Data { get { throw null; } set { } }
        public int? ExecutionCount { get { throw null; } set { } }
        public object Metadata { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CellOutputType OutputType { get { throw null; } set { } }
        public object Text { get { throw null; } set { } }
    }
    public partial class NotebookFolder
    {
        public NotebookFolder() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class NotebookKernelSpec
    {
        public NotebookKernelSpec(string name, string displayName) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class NotebookLanguageInfo
    {
        public NotebookLanguageInfo(string name) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public string CodemirrorMode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class NotebookMetadata
    {
        public NotebookMetadata() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.NotebookKernelSpec Kernelspec { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.NotebookLanguageInfo LanguageInfo { get { throw null; } set { } }
    }
    public partial class NotebookParameter
    {
        public NotebookParameter() { }
        public Azure.Analytics.Synapse.Artifacts.Models.NotebookParameterType? Type { get { throw null; } set { } }
        public object Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotebookParameterType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.NotebookParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotebookParameterType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.NotebookParameterType Bool { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.NotebookParameterType Float { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.NotebookParameterType Int { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.NotebookParameterType String { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.NotebookParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.NotebookParameterType left, Azure.Analytics.Synapse.Artifacts.Models.NotebookParameterType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.NotebookParameterType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.NotebookParameterType left, Azure.Analytics.Synapse.Artifacts.Models.NotebookParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotebookReferenceType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.NotebookReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotebookReferenceType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.NotebookReferenceType NotebookReference { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.NotebookReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.NotebookReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.NotebookReferenceType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.NotebookReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.NotebookReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.NotebookReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NotebookResource
    {
        public NotebookResource(string name, Azure.Analytics.Synapse.Artifacts.Models.Notebook properties) { }
        public string Etag { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.Notebook Properties { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class NotebookSessionProperties
    {
        public NotebookSessionProperties(string driverMemory, int driverCores, string executorMemory, int executorCores, int numExecutors) { }
        public int DriverCores { get { throw null; } set { } }
        public string DriverMemory { get { throw null; } set { } }
        public int ExecutorCores { get { throw null; } set { } }
        public string ExecutorMemory { get { throw null; } set { } }
        public int NumExecutors { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ODataAadServicePrincipalCredentialType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ODataAadServicePrincipalCredentialType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ODataAadServicePrincipalCredentialType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ODataAadServicePrincipalCredentialType ServicePrincipalCert { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ODataAadServicePrincipalCredentialType ServicePrincipalKey { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ODataAadServicePrincipalCredentialType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ODataAadServicePrincipalCredentialType left, Azure.Analytics.Synapse.Artifacts.Models.ODataAadServicePrincipalCredentialType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ODataAadServicePrincipalCredentialType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ODataAadServicePrincipalCredentialType left, Azure.Analytics.Synapse.Artifacts.Models.ODataAadServicePrincipalCredentialType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ODataAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ODataAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ODataAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ODataAuthenticationType AadServicePrincipal { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ODataAuthenticationType Anonymous { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ODataAuthenticationType Basic { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ODataAuthenticationType ManagedServiceIdentity { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ODataAuthenticationType Windows { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ODataAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ODataAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.ODataAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ODataAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ODataAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.ODataAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ODataLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public ODataLinkedService(object url) { }
        public object AadResourceId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.ODataAadServicePrincipalCredentialType? AadServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.ODataAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public object AzureCloudType { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalEmbeddedCert { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalEmbeddedCertPassword { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object Tenant { get { throw null; } set { } }
        public object Url { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class ODataResourceDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public ODataResourceDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Path { get { throw null; } set { } }
    }
    public partial class ODataSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public ODataSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object HttpRequestTimeout { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    public partial class OdbcLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public OdbcLinkedService(object connectionString) { }
        public object AuthenticationType { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Credential { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class OdbcSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public OdbcSink() { }
        public object PreCopyScript { get { throw null; } set { } }
    }
    public partial class OdbcSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public OdbcSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class OdbcTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public OdbcTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class Office365Dataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public Office365Dataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object tableName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Predicate { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class Office365LinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public Office365LinkedService(object office365TenantId, object servicePrincipalTenantId, object servicePrincipalId, Azure.Analytics.Synapse.Artifacts.Models.SecretBase servicePrincipalKey) { }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Office365TenantId { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object ServicePrincipalTenantId { get { throw null; } set { } }
    }
    public partial class Office365Source : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public Office365Source() { }
        public object AllowedGroups { get { throw null; } set { } }
        public object DateFilterColumn { get { throw null; } set { } }
        public object EndTime { get { throw null; } set { } }
        public object OutputColumns { get { throw null; } set { } }
        public object StartTime { get { throw null; } set { } }
        public object UserScopeFilterUri { get { throw null; } set { } }
    }
    public partial class OperationResult
    {
        internal OperationResult() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Artifacts.Models.CloudError> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Status { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class OracleLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public OracleLinkedService(object connectionString) { }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OraclePartitionOption : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.OraclePartitionOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OraclePartitionOption(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.OraclePartitionOption DynamicRange { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.OraclePartitionOption None { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.OraclePartitionOption PhysicalPartitionsOfTable { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.OraclePartitionOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.OraclePartitionOption left, Azure.Analytics.Synapse.Artifacts.Models.OraclePartitionOption right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.OraclePartitionOption (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.OraclePartitionOption left, Azure.Analytics.Synapse.Artifacts.Models.OraclePartitionOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OraclePartitionSettings
    {
        public OraclePartitionSettings() { }
        public object PartitionColumnName { get { throw null; } set { } }
        public object PartitionLowerBound { get { throw null; } set { } }
        public object PartitionNames { get { throw null; } set { } }
        public object PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class OracleServiceCloudLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public OracleServiceCloudLinkedService(object host, object username, Azure.Analytics.Synapse.Artifacts.Models.SecretBase password) { }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class OracleServiceCloudObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public OracleServiceCloudObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class OracleServiceCloudSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public OracleServiceCloudSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class OracleSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public OracleSink() { }
        public object PreCopyScript { get { throw null; } set { } }
    }
    public partial class OracleSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public OracleSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object OracleReaderQuery { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.OraclePartitionOption? PartitionOption { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.OraclePartitionSettings PartitionSettings { get { throw null; } set { } }
        public object QueryTimeout { get { throw null; } set { } }
    }
    public partial class OracleTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public OracleTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class OrcDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public OrcDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation Location { get { throw null; } set { } }
        public object OrcCompressionCodec { get { throw null; } set { } }
    }
    public partial class OrcFormat : Azure.Analytics.Synapse.Artifacts.Models.DatasetStorageFormat
    {
        public OrcFormat() { }
    }
    public partial class OrcSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public OrcSink() { }
        public Azure.Analytics.Synapse.Artifacts.Models.OrcWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class OrcSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public OrcSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class OrcWriteSettings : Azure.Analytics.Synapse.Artifacts.Models.FormatWriteSettings
    {
        public OrcWriteSettings() { }
        public object FileNamePrefix { get { throw null; } set { } }
        public object MaxRowsPerFile { get { throw null; } set { } }
    }
    public partial class ParameterSpecification
    {
        public ParameterSpecification(Azure.Analytics.Synapse.Artifacts.Models.ParameterType type) { }
        public object DefaultValue { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.ParameterType Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ParameterType Array { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ParameterType Bool { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ParameterType Float { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ParameterType Int { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ParameterType Object { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ParameterType SecureString { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ParameterType String { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ParameterType left, Azure.Analytics.Synapse.Artifacts.Models.ParameterType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ParameterType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ParameterType left, Azure.Analytics.Synapse.Artifacts.Models.ParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ParquetDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public ParquetDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object CompressionCodec { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation Location { get { throw null; } set { } }
    }
    public partial class ParquetFormat : Azure.Analytics.Synapse.Artifacts.Models.DatasetStorageFormat
    {
        public ParquetFormat() { }
    }
    public partial class ParquetSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public ParquetSink() { }
        public Azure.Analytics.Synapse.Artifacts.Models.ParquetWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreWriteSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class ParquetSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public ParquetSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    public partial class ParquetWriteSettings : Azure.Analytics.Synapse.Artifacts.Models.FormatWriteSettings
    {
        public ParquetWriteSettings() { }
        public object FileNamePrefix { get { throw null; } set { } }
        public object MaxRowsPerFile { get { throw null; } set { } }
    }
    public partial class PaypalLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public PaypalLinkedService(object host, object clientId) { }
        public object ClientId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
    }
    public partial class PaypalObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public PaypalObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class PaypalSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public PaypalSource() { }
        public object Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhoenixAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.PhoenixAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhoenixAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.PhoenixAuthenticationType Anonymous { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.PhoenixAuthenticationType UsernameAndPassword { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.PhoenixAuthenticationType WindowsAzureHDInsightService { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.PhoenixAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.PhoenixAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.PhoenixAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.PhoenixAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.PhoenixAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.PhoenixAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoenixLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public PhoenixLinkedService(object host, Azure.Analytics.Synapse.Artifacts.Models.PhoenixAuthenticationType authenticationType) { }
        public object AllowHostNameCNMismatch { get { throw null; } set { } }
        public object AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.PhoenixAuthenticationType AuthenticationType { get { throw null; } set { } }
        public object EnableSsl { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public object HttpPath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Port { get { throw null; } set { } }
        public object TrustedCertPath { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
        public object UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class PhoenixObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public PhoenixObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class PhoenixSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public PhoenixSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class PipelineFolder
    {
        public PipelineFolder() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class PipelineReference
    {
        public PipelineReference(Azure.Analytics.Synapse.Artifacts.Models.PipelineReferenceType type, string referenceName) { }
        public string Name { get { throw null; } set { } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.PipelineReferenceType Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineReferenceType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.PipelineReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineReferenceType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.PipelineReferenceType PipelineReference { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.PipelineReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.PipelineReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.PipelineReferenceType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.PipelineReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.PipelineReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.PipelineReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PipelineResource : Azure.Analytics.Synapse.Artifacts.Models.SubResource
    {
        public PipelineResource() { }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.Activity> Activities { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<object> Annotations { get { throw null; } }
        public int? Concurrency { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.PipelineFolder Folder { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.ParameterSpecification> Parameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> RunDimensions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.VariableSpecification> Variables { get { throw null; } }
    }
    public partial class PipelineRun
    {
        internal PipelineRun() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> AdditionalProperties { get { throw null; } }
        public int? DurationInMs { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.PipelineRunInvokedBy InvokedBy { get { throw null; } }
        public bool? IsLatest { get { throw null; } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Parameters { get { throw null; } }
        public string PipelineName { get { throw null; } }
        public System.DateTimeOffset? RunEnd { get { throw null; } }
        public string RunGroupId { get { throw null; } }
        public string RunId { get { throw null; } }
        public System.DateTimeOffset? RunStart { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class PipelineRunInvokedBy
    {
        internal PipelineRunInvokedBy() { }
        public string Id { get { throw null; } }
        public string InvokedByType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class PipelineRunsQueryResponse
    {
        internal PipelineRunsQueryResponse() { }
        public string ContinuationToken { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Artifacts.Models.PipelineRun> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PluginCurrentState : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PluginCurrentState(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState Cleanup { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState Ended { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState Monitoring { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState Preparation { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState Queued { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState ResourceAcquisition { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState Submission { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState left, Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState left, Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolybaseSettings
    {
        public PolybaseSettings() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object RejectSampleValue { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.PolybaseSettingsRejectType? RejectType { get { throw null; } set { } }
        public object RejectValue { get { throw null; } set { } }
        public object UseTypeDefault { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolybaseSettingsRejectType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.PolybaseSettingsRejectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolybaseSettingsRejectType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.PolybaseSettingsRejectType Percentage { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.PolybaseSettingsRejectType Value { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.PolybaseSettingsRejectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.PolybaseSettingsRejectType left, Azure.Analytics.Synapse.Artifacts.Models.PolybaseSettingsRejectType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.PolybaseSettingsRejectType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.PolybaseSettingsRejectType left, Azure.Analytics.Synapse.Artifacts.Models.PolybaseSettingsRejectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public PostgreSqlLinkedService(object connectionString) { }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class PostgreSqlSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public PostgreSqlSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class PostgreSqlTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public PostgreSqlTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class PowerBIWorkspaceLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public PowerBIWorkspaceLinkedService(string workspaceId, string tenantId) { }
        public string TenantId { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrestoAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.PrestoAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrestoAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.PrestoAuthenticationType Anonymous { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.PrestoAuthenticationType Ldap { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.PrestoAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.PrestoAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.PrestoAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.PrestoAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.PrestoAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.PrestoAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrestoLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public PrestoLinkedService(object host, object serverVersion, object catalog, Azure.Analytics.Synapse.Artifacts.Models.PrestoAuthenticationType authenticationType) { }
        public object AllowHostNameCNMismatch { get { throw null; } set { } }
        public object AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.PrestoAuthenticationType AuthenticationType { get { throw null; } set { } }
        public object Catalog { get { throw null; } set { } }
        public object EnableSsl { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Port { get { throw null; } set { } }
        public object ServerVersion { get { throw null; } set { } }
        public object TimeZoneID { get { throw null; } set { } }
        public object TrustedCertPath { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
        public object UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class PrestoObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public PrestoObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class PrestoSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public PrestoSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class PrivateEndpoint
    {
        public PrivateEndpoint() { }
        public string Id { get { throw null; } }
    }
    public partial class PrivateEndpointConnection : Azure.Analytics.Synapse.Artifacts.Models.ProxyResource
    {
        public PrivateEndpointConnection() { }
        public Azure.Analytics.Synapse.Artifacts.Models.PrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.PrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class ProxyResource : Azure.Analytics.Synapse.Artifacts.Models.Resource
    {
        public ProxyResource() { }
    }
    public partial class PurviewConfiguration
    {
        public PurviewConfiguration() { }
        public string PurviewResourceId { get { throw null; } set { } }
    }
    public partial class QueryTableStatusRequest
    {
        public QueryTableStatusRequest() { }
        public object ContinuationToken { get { throw null; } set { } }
        public int? MaxSegmentCount { get { throw null; } set { } }
    }
    public partial class QuickbaseLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public QuickbaseLinkedService(object url, Azure.Analytics.Synapse.Artifacts.Models.SecretBase userToken) { }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Url { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase UserToken { get { throw null; } set { } }
    }
    public partial class QuickBooksLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public QuickBooksLinkedService(object endpoint, object companyId, object consumerKey, Azure.Analytics.Synapse.Artifacts.Models.SecretBase consumerSecret, Azure.Analytics.Synapse.Artifacts.Models.SecretBase accessToken, Azure.Analytics.Synapse.Artifacts.Models.SecretBase accessTokenSecret) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase AccessToken { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase AccessTokenSecret { get { throw null; } set { } }
        public object CompanyId { get { throw null; } set { } }
        public object ConnectionProperties { get { throw null; } set { } }
        public object ConsumerKey { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ConsumerSecret { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Endpoint { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
    }
    public partial class QuickBooksObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public QuickBooksObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class QuickBooksSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public QuickBooksSource() { }
        public object Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecurrenceFrequency : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.RecurrenceFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecurrenceFrequency(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RecurrenceFrequency Day { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RecurrenceFrequency Hour { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RecurrenceFrequency Minute { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RecurrenceFrequency Month { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RecurrenceFrequency NotSpecified { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RecurrenceFrequency Week { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RecurrenceFrequency Year { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.RecurrenceFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.RecurrenceFrequency left, Azure.Analytics.Synapse.Artifacts.Models.RecurrenceFrequency right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.RecurrenceFrequency (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.RecurrenceFrequency left, Azure.Analytics.Synapse.Artifacts.Models.RecurrenceFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecurrenceSchedule
    {
        public RecurrenceSchedule() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<int> MonthDays { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.RecurrenceScheduleOccurrence> MonthlyOccurrences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DayOfWeek> WeekDays { get { throw null; } }
    }
    public partial class RecurrenceScheduleOccurrence
    {
        public RecurrenceScheduleOccurrence() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.DayOfWeek? Day { get { throw null; } set { } }
        public int? Occurrence { get { throw null; } set { } }
    }
    public partial class RedirectIncompatibleRowSettings
    {
        public RedirectIncompatibleRowSettings(object linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object LinkedServiceName { get { throw null; } set { } }
        public object Path { get { throw null; } set { } }
    }
    public partial class RedshiftUnloadSettings
    {
        public RedshiftUnloadSettings(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference s3LinkedServiceName, object bucketName) { }
        public object BucketName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference S3LinkedServiceName { get { throw null; } set { } }
    }
    public partial class RelationalSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public RelationalSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    public partial class RelationalTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public RelationalTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestStatus : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.RequestStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestStatus(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RequestStatus Completed { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RequestStatus Failed { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RequestStatus Running { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.RequestStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.RequestStatus left, Azure.Analytics.Synapse.Artifacts.Models.RequestStatus right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.RequestStatus (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.RequestStatus left, Azure.Analytics.Synapse.Artifacts.Models.RequestStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RerunTriggerListResponse
    {
        public RerunTriggerListResponse(System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.RerunTriggerResource> value) { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.RerunTriggerResource> Value { get { throw null; } }
    }
    public partial class RerunTriggerResource : Azure.Analytics.Synapse.Artifacts.Models.SubResource
    {
        public RerunTriggerResource(Azure.Analytics.Synapse.Artifacts.Models.RerunTumblingWindowTrigger properties) { }
        public Azure.Analytics.Synapse.Artifacts.Models.RerunTumblingWindowTrigger Properties { get { throw null; } set { } }
    }
    public partial class RerunTumblingWindowTrigger : Azure.Analytics.Synapse.Artifacts.Models.Trigger
    {
        public RerunTumblingWindowTrigger(object parentTrigger, System.DateTimeOffset requestedStartTime, System.DateTimeOffset requestedEndTime, int rerunConcurrency) { }
        public object ParentTrigger { get { throw null; } set { } }
        public System.DateTimeOffset RequestedEndTime { get { throw null; } set { } }
        public System.DateTimeOffset RequestedStartTime { get { throw null; } set { } }
        public int RerunConcurrency { get { throw null; } set { } }
    }
    public partial class Resource
    {
        public Resource() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public enum ResourceIdentityType
    {
        None = 0,
        SystemAssigned = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceStatus : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceStatus(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ResourceStatus Created { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ResourceStatus Creating { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ResourceStatus Failed { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ResourceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ResourceStatus left, Azure.Analytics.Synapse.Artifacts.Models.ResourceStatus right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ResourceStatus (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ResourceStatus left, Azure.Analytics.Synapse.Artifacts.Models.ResourceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResponsysLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public ResponsysLinkedService(object endpoint, object clientId) { }
        public object ClientId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Endpoint { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
    }
    public partial class ResponsysObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public ResponsysObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class ResponsysSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public ResponsysSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class RestResourceDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public RestResourceDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object AdditionalHeaders { get { throw null; } set { } }
        public object PaginationRules { get { throw null; } set { } }
        public object RelativeUrl { get { throw null; } set { } }
        public object RequestBody { get { throw null; } set { } }
        public object RequestMethod { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestServiceAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.RestServiceAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestServiceAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RestServiceAuthenticationType AadServicePrincipal { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RestServiceAuthenticationType Anonymous { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RestServiceAuthenticationType Basic { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RestServiceAuthenticationType ManagedServiceIdentity { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RestServiceAuthenticationType OAuth2ClientCredential { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.RestServiceAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.RestServiceAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.RestServiceAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.RestServiceAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.RestServiceAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.RestServiceAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestServiceLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public RestServiceLinkedService(object url, Azure.Analytics.Synapse.Artifacts.Models.RestServiceAuthenticationType authenticationType) { }
        public object AadResourceId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.RestServiceAuthenticationType AuthenticationType { get { throw null; } set { } }
        public object AuthHeaders { get { throw null; } set { } }
        public object AzureCloudType { get { throw null; } set { } }
        public object ClientId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public object EnableServerCertificateValidation { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Resource { get { throw null; } set { } }
        public object Scope { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object Tenant { get { throw null; } set { } }
        public object TokenEndpoint { get { throw null; } set { } }
        public object Url { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class RestSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public RestSink() { }
        public object AdditionalHeaders { get { throw null; } set { } }
        public object HttpCompressionType { get { throw null; } set { } }
        public object HttpRequestTimeout { get { throw null; } set { } }
        public object RequestInterval { get { throw null; } set { } }
        public object RequestMethod { get { throw null; } set { } }
    }
    public partial class RestSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public RestSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object AdditionalHeaders { get { throw null; } set { } }
        public object HttpRequestTimeout { get { throw null; } set { } }
        public object PaginationRules { get { throw null; } set { } }
        public object RequestBody { get { throw null; } set { } }
        public object RequestInterval { get { throw null; } set { } }
        public object RequestMethod { get { throw null; } set { } }
    }
    public partial class RetryPolicy
    {
        public RetryPolicy() { }
        public object Count { get { throw null; } set { } }
        public int? IntervalInSeconds { get { throw null; } set { } }
    }
    public partial class RunFilterParameters
    {
        public RunFilterParameters(System.DateTimeOffset lastUpdatedAfter, System.DateTimeOffset lastUpdatedBefore) { }
        public string ContinuationToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilter> Filters { get { throw null; } }
        public System.DateTimeOffset LastUpdatedAfter { get { throw null; } }
        public System.DateTimeOffset LastUpdatedBefore { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderBy> OrderBy { get { throw null; } }
    }
    public partial class RunNotebookError
    {
        internal RunNotebookError() { }
        public string Ename { get { throw null; } }
        public string Evalue { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Traceback { get { throw null; } }
    }
    public partial class RunNotebookParameter
    {
        public RunNotebookParameter() { }
        public string Type { get { throw null; } set { } }
        public object Value { get { throw null; } set { } }
    }
    public partial class RunNotebookRequest
    {
        public RunNotebookRequest() { }
        public bool? HonorSessionTimeToLive { get { throw null; } set { } }
        public string Notebook { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.RunNotebookParameter> Parameters { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.RunNotebookSparkSessionOptions SessionOptions { get { throw null; } set { } }
        public string SparkPool { get { throw null; } set { } }
    }
    public partial class RunNotebookResponse
    {
        internal RunNotebookResponse() { }
        public string Message { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.RunNotebookResult Result { get { throw null; } }
    }
    public partial class RunNotebookResult
    {
        internal RunNotebookResult() { }
        public Azure.Analytics.Synapse.Artifacts.Models.RunNotebookError Error { get { throw null; } }
        public string ExitValue { get { throw null; } }
        public string LastCheckedOn { get { throw null; } }
        public string RunId { get { throw null; } }
        public string RunStatus { get { throw null; } }
        public object SessionDetail { get { throw null; } }
        public string SessionId { get { throw null; } }
        public string SparkPool { get { throw null; } }
    }
    public partial class RunNotebookSnapshot
    {
        internal RunNotebookSnapshot() { }
        public string ExitValue { get { throw null; } }
        public bool? HonorSessionTimeToLive { get { throw null; } }
        public string Id { get { throw null; } }
        public string Notebook { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.NotebookResource NotebookContent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.RunNotebookParameter> Parameters { get { throw null; } }
        public string SessionId { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.RunNotebookSparkSessionOptions SessionOptions { get { throw null; } }
        public string SparkPool { get { throw null; } }
    }
    public partial class RunNotebookSnapshotResponse
    {
        internal RunNotebookSnapshotResponse() { }
        public string Message { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.RunNotebookSnapshotResult Result { get { throw null; } }
    }
    public partial class RunNotebookSnapshotResult
    {
        internal RunNotebookSnapshotResult() { }
        public Azure.Analytics.Synapse.Artifacts.Models.RunNotebookError Error { get { throw null; } }
        public string LastCheckedOn { get { throw null; } }
        public string RunId { get { throw null; } }
        public string RunStatus { get { throw null; } }
        public string SessionId { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.RunNotebookSnapshot Snapshot { get { throw null; } }
        public string SparkPool { get { throw null; } }
    }
    public partial class RunNotebookSparkSessionOptions
    {
        public RunNotebookSparkSessionOptions() { }
        public System.Collections.Generic.IList<string> Archives { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Configuration { get { throw null; } }
        public int? DriverCores { get { throw null; } set { } }
        public string DriverMemory { get { throw null; } set { } }
        public int? ExecutorCores { get { throw null; } set { } }
        public int? ExecutorCount { get { throw null; } set { } }
        public string ExecutorMemory { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Files { get { throw null; } }
        public int? HeartbeatTimeoutInSecond { get { throw null; } set { } }
        public bool? IsQueueable { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Jars { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ProxyUser { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PythonFiles { get { throw null; } }
        public object Queue { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class RunQueryFilter
    {
        public RunQueryFilter(Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand operand, Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperator @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand Operand { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperator Operator { get { throw null; } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunQueryFilterOperand : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunQueryFilterOperand(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand ActivityName { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand ActivityRunEnd { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand ActivityRunStart { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand ActivityType { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand LatestOnly { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand PipelineName { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand RunEnd { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand RunGroupId { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand RunStart { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand Status { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand TriggerName { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand TriggerRunTimestamp { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand left, Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand left, Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperand right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunQueryFilterOperator : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunQueryFilterOperator(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperator EqualsValue { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperator In { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperator NotEquals { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperator NotIn { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperator left, Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperator right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperator (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperator left, Azure.Analytics.Synapse.Artifacts.Models.RunQueryFilterOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunQueryOrder : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunQueryOrder(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrder ASC { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrder Desc { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrder left, Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrder right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrder (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrder left, Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunQueryOrderBy
    {
        public RunQueryOrderBy(Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField orderBy, Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrder order) { }
        public Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrder Order { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField OrderBy { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunQueryOrderByField : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunQueryOrderByField(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField ActivityName { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField ActivityRunEnd { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField ActivityRunStart { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField PipelineName { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField RunEnd { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField RunStart { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField Status { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField TriggerName { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField TriggerRunTimestamp { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField left, Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField left, Azure.Analytics.Synapse.Artifacts.Models.RunQueryOrderByField right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SalesforceLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SalesforceLinkedService() { }
        public object ApiVersion { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object EnvironmentUrl { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase SecurityToken { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class SalesforceMarketingCloudLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SalesforceMarketingCloudLinkedService(object clientId) { }
        public object ClientId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public object ConnectionProperties { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
    }
    public partial class SalesforceMarketingCloudObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SalesforceMarketingCloudObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class SalesforceMarketingCloudSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SalesforceMarketingCloudSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class SalesforceObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SalesforceObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object ObjectApiName { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SalesforceServiceCloudLinkedService() { }
        public object ApiVersion { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object EnvironmentUrl { get { throw null; } set { } }
        public object ExtendedProperties { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase SecurityToken { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SalesforceServiceCloudObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object ObjectApiName { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public SalesforceServiceCloudSink() { }
        public object ExternalIdFieldName { get { throw null; } set { } }
        public object IgnoreNullValues { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SalesforceSinkWriteBehavior? WriteBehavior { get { throw null; } set { } }
    }
    public partial class SalesforceServiceCloudSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public SalesforceServiceCloudSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
        public object ReadBehavior { get { throw null; } set { } }
    }
    public partial class SalesforceSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public SalesforceSink() { }
        public object ExternalIdFieldName { get { throw null; } set { } }
        public object IgnoreNullValues { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SalesforceSinkWriteBehavior? WriteBehavior { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SalesforceSinkWriteBehavior : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SalesforceSinkWriteBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SalesforceSinkWriteBehavior(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SalesforceSinkWriteBehavior Insert { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SalesforceSinkWriteBehavior Upsert { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SalesforceSinkWriteBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SalesforceSinkWriteBehavior left, Azure.Analytics.Synapse.Artifacts.Models.SalesforceSinkWriteBehavior right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SalesforceSinkWriteBehavior (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SalesforceSinkWriteBehavior left, Azure.Analytics.Synapse.Artifacts.Models.SalesforceSinkWriteBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SalesforceSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SalesforceSource() { }
        public object Query { get { throw null; } set { } }
        public object ReadBehavior { get { throw null; } set { } }
    }
    public partial class SapBwCubeDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SapBwCubeDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
    }
    public partial class SapBWLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SapBWLinkedService(object server, object systemNumber, object clientId) { }
        public object ClientId { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Server { get { throw null; } set { } }
        public object SystemNumber { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class SapBwSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SapBwSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class SapCloudForCustomerLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SapCloudForCustomerLinkedService(object url) { }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Url { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class SapCloudForCustomerResourceDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SapCloudForCustomerResourceDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object path) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Path { get { throw null; } set { } }
    }
    public partial class SapCloudForCustomerSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public SapCloudForCustomerSink() { }
        public object HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SapCloudForCustomerSinkWriteBehavior? WriteBehavior { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapCloudForCustomerSinkWriteBehavior : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SapCloudForCustomerSinkWriteBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapCloudForCustomerSinkWriteBehavior(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SapCloudForCustomerSinkWriteBehavior Insert { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SapCloudForCustomerSinkWriteBehavior Update { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SapCloudForCustomerSinkWriteBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SapCloudForCustomerSinkWriteBehavior left, Azure.Analytics.Synapse.Artifacts.Models.SapCloudForCustomerSinkWriteBehavior right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SapCloudForCustomerSinkWriteBehavior (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SapCloudForCustomerSinkWriteBehavior left, Azure.Analytics.Synapse.Artifacts.Models.SapCloudForCustomerSinkWriteBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapCloudForCustomerSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SapCloudForCustomerSource() { }
        public object HttpRequestTimeout { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    public partial class SapEccLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SapEccLinkedService(string url) { }
        public string EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class SapEccResourceDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SapEccResourceDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object path) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Path { get { throw null; } set { } }
    }
    public partial class SapEccSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SapEccSource() { }
        public object HttpRequestTimeout { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapHanaAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SapHanaAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapHanaAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SapHanaAuthenticationType Basic { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SapHanaAuthenticationType Windows { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SapHanaAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SapHanaAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.SapHanaAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SapHanaAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SapHanaAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.SapHanaAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapHanaLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SapHanaLinkedService(object server) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SapHanaAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Server { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class SapHanaPartitionSettings
    {
        public SapHanaPartitionSettings() { }
        public object PartitionColumnName { get { throw null; } set { } }
    }
    public partial class SapHanaSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SapHanaSource() { }
        public object PacketSize { get { throw null; } set { } }
        public object PartitionOption { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SapHanaPartitionSettings PartitionSettings { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    public partial class SapHanaTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SapHanaTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
    }
    public partial class SapOdpLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SapOdpLinkedService() { }
        public object ClientId { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Language { get { throw null; } set { } }
        public object LogonGroup { get { throw null; } set { } }
        public object MessageServer { get { throw null; } set { } }
        public object MessageServerService { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Server { get { throw null; } set { } }
        public object SncLibraryPath { get { throw null; } set { } }
        public object SncMode { get { throw null; } set { } }
        public object SncMyName { get { throw null; } set { } }
        public object SncPartnerName { get { throw null; } set { } }
        public object SncQop { get { throw null; } set { } }
        public object SubscriberName { get { throw null; } set { } }
        public object SystemId { get { throw null; } set { } }
        public object SystemNumber { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
        public object X509CertificatePath { get { throw null; } set { } }
    }
    public partial class SapOdpResourceDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SapOdpResourceDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object context, object objectName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Context { get { throw null; } set { } }
        public object ObjectName { get { throw null; } set { } }
    }
    public partial class SapOdpSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SapOdpSource() { }
        public object ExtractionMode { get { throw null; } set { } }
        public object Projection { get { throw null; } set { } }
        public object Selection { get { throw null; } set { } }
        public object SubscriberProcess { get { throw null; } set { } }
    }
    public partial class SapOpenHubLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SapOpenHubLinkedService(object server, object systemNumber, object clientId) { }
        public object ClientId { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Language { get { throw null; } set { } }
        public object LogonGroup { get { throw null; } set { } }
        public object MessageServer { get { throw null; } set { } }
        public object MessageServerService { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Server { get { throw null; } set { } }
        public object SystemId { get { throw null; } set { } }
        public object SystemNumber { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class SapOpenHubSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SapOpenHubSource() { }
        public object BaseRequestId { get { throw null; } set { } }
        public object CustomRfcReadTableFunctionModule { get { throw null; } set { } }
        public object ExcludeLastRequest { get { throw null; } set { } }
        public object SapDataColumnDelimiter { get { throw null; } set { } }
    }
    public partial class SapOpenHubTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SapOpenHubTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object openHubDestinationName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object BaseRequestId { get { throw null; } set { } }
        public object ExcludeLastRequest { get { throw null; } set { } }
        public object OpenHubDestinationName { get { throw null; } set { } }
    }
    public partial class SapTableLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SapTableLinkedService() { }
        public object ClientId { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Language { get { throw null; } set { } }
        public object LogonGroup { get { throw null; } set { } }
        public object MessageServer { get { throw null; } set { } }
        public object MessageServerService { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Server { get { throw null; } set { } }
        public object SncLibraryPath { get { throw null; } set { } }
        public object SncMode { get { throw null; } set { } }
        public object SncMyName { get { throw null; } set { } }
        public object SncPartnerName { get { throw null; } set { } }
        public object SncQop { get { throw null; } set { } }
        public object SystemId { get { throw null; } set { } }
        public object SystemNumber { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class SapTablePartitionSettings
    {
        public SapTablePartitionSettings() { }
        public object MaxPartitionsNumber { get { throw null; } set { } }
        public object PartitionColumnName { get { throw null; } set { } }
        public object PartitionLowerBound { get { throw null; } set { } }
        public object PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class SapTableResourceDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SapTableResourceDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object tableName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class SapTableSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SapTableSource() { }
        public object BatchSize { get { throw null; } set { } }
        public object CustomRfcReadTableFunctionModule { get { throw null; } set { } }
        public object PartitionOption { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SapTablePartitionSettings PartitionSettings { get { throw null; } set { } }
        public object RfcTableFields { get { throw null; } set { } }
        public object RfcTableOptions { get { throw null; } set { } }
        public object RowCount { get { throw null; } set { } }
        public object RowSkips { get { throw null; } set { } }
        public object SapDataColumnDelimiter { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SchedulerCurrentState : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SchedulerCurrentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SchedulerCurrentState(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SchedulerCurrentState Ended { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SchedulerCurrentState Queued { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SchedulerCurrentState Scheduled { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SchedulerCurrentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SchedulerCurrentState left, Azure.Analytics.Synapse.Artifacts.Models.SchedulerCurrentState right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SchedulerCurrentState (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SchedulerCurrentState left, Azure.Analytics.Synapse.Artifacts.Models.SchedulerCurrentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduleTrigger : Azure.Analytics.Synapse.Artifacts.Models.MultiplePipelineTrigger
    {
        public ScheduleTrigger(Azure.Analytics.Synapse.Artifacts.Models.ScheduleTriggerRecurrence recurrence) { }
        public Azure.Analytics.Synapse.Artifacts.Models.ScheduleTriggerRecurrence Recurrence { get { throw null; } set { } }
    }
    public partial class ScheduleTriggerRecurrence
    {
        public ScheduleTriggerRecurrence() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.RecurrenceFrequency? Frequency { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.RecurrenceSchedule Schedule { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class ScriptAction
    {
        public ScriptAction(string name, string uri, object roles) { }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public object Roles { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
    }
    public partial class ScriptActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public ScriptActivity(string name) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityTypePropertiesLogSettings LogSettings { get { throw null; } set { } }
        public object ScriptBlockExecutionTimeout { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityScriptBlock> Scripts { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptActivityLogDestination : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityLogDestination>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptActivityLogDestination(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityLogDestination ActivityOutput { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityLogDestination ExternalStore { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityLogDestination other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityLogDestination left, Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityLogDestination right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityLogDestination (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityLogDestination left, Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityLogDestination right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptActivityParameter
    {
        public ScriptActivityParameter() { }
        public Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterDirection? Direction { get { throw null; } set { } }
        public object Name { get { throw null; } set { } }
        public int? Size { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType? Type { get { throw null; } set { } }
        public object Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptActivityParameterDirection : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptActivityParameterDirection(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterDirection Input { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterDirection InputOutput { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterDirection Output { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterDirection left, Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterDirection right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterDirection (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterDirection left, Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptActivityParameterType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptActivityParameterType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType Boolean { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType DateTime { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType DateTimeOffset { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType Decimal { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType Double { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType Guid { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType Int16 { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType Int32 { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType Int64 { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType Single { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType String { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType Timespan { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType left, Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType left, Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptActivityScriptBlock
    {
        public ScriptActivityScriptBlock(object text, Azure.Analytics.Synapse.Artifacts.Models.ScriptType type) { }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityParameter> Parameters { get { throw null; } }
        public object Text { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.ScriptType Type { get { throw null; } set { } }
    }
    public partial class ScriptActivityTypePropertiesLogSettings
    {
        public ScriptActivityTypePropertiesLogSettings(Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityLogDestination logDestination) { }
        public Azure.Analytics.Synapse.Artifacts.Models.ScriptActivityLogDestination LogDestination { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LogLocationSettings LogLocationSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ScriptType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptType NonQuery { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ScriptType Query { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ScriptType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ScriptType left, Azure.Analytics.Synapse.Artifacts.Models.ScriptType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ScriptType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ScriptType left, Azure.Analytics.Synapse.Artifacts.Models.ScriptType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecretBase
    {
        public SecretBase() { }
    }
    public partial class SecureInputOutputPolicy
    {
        public SecureInputOutputPolicy() { }
        public bool? SecureInput { get { throw null; } set { } }
        public bool? SecureOutput { get { throw null; } set { } }
    }
    public partial class SecureString : Azure.Analytics.Synapse.Artifacts.Models.SecretBase
    {
        public SecureString(string value) { }
        public string Value { get { throw null; } set { } }
    }
    public partial class SelfDependencyTumblingWindowTriggerReference : Azure.Analytics.Synapse.Artifacts.Models.DependencyReference
    {
        public SelfDependencyTumblingWindowTriggerReference(string offset) { }
        public string Offset { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
    }
    public partial class SelfHostedIntegrationRuntime : Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntime
    {
        public SelfHostedIntegrationRuntime() { }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedIntegrationRuntimeType LinkedInfo { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceNowAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ServiceNowAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceNowAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ServiceNowAuthenticationType Basic { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ServiceNowAuthenticationType OAuth2 { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ServiceNowAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ServiceNowAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.ServiceNowAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ServiceNowAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ServiceNowAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.ServiceNowAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceNowLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public ServiceNowLinkedService(object endpoint, Azure.Analytics.Synapse.Artifacts.Models.ServiceNowAuthenticationType authenticationType) { }
        public Azure.Analytics.Synapse.Artifacts.Models.ServiceNowAuthenticationType AuthenticationType { get { throw null; } set { } }
        public object ClientId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Endpoint { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class ServiceNowObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public ServiceNowObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class ServiceNowSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public ServiceNowSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class SetVariableActivity : Azure.Analytics.Synapse.Artifacts.Models.ControlActivity
    {
        public SetVariableActivity(string name) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecureInputOutputPolicy Policy { get { throw null; } set { } }
        public bool? SetSystemVariable { get { throw null; } set { } }
        public object Value { get { throw null; } set { } }
        public string VariableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SftpAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SftpAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SftpAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SftpAuthenticationType Basic { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SftpAuthenticationType SshPublicKey { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SftpAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SftpAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.SftpAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SftpAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SftpAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.SftpAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SftpLocation : Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation
    {
        public SftpLocation() { }
    }
    public partial class SftpReadSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings
    {
        public SftpReadSettings() { }
        public object DeleteFilesAfterCompletion { get { throw null; } set { } }
        public object DisableChunking { get { throw null; } set { } }
        public object EnablePartitionDiscovery { get { throw null; } set { } }
        public object FileListPath { get { throw null; } set { } }
        public object ModifiedDatetimeEnd { get { throw null; } set { } }
        public object ModifiedDatetimeStart { get { throw null; } set { } }
        public object PartitionRootPath { get { throw null; } set { } }
        public object Recursive { get { throw null; } set { } }
        public object WildcardFileName { get { throw null; } set { } }
        public object WildcardFolderPath { get { throw null; } set { } }
    }
    public partial class SftpServerLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SftpServerLinkedService(object host) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SftpAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public object HostKeyFingerprint { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase PassPhrase { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Port { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase PrivateKeyContent { get { throw null; } set { } }
        public object PrivateKeyPath { get { throw null; } set { } }
        public object SkipHostKeyValidation { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class SftpWriteSettings : Azure.Analytics.Synapse.Artifacts.Models.StoreWriteSettings
    {
        public SftpWriteSettings() { }
        public object OperationTimeout { get { throw null; } set { } }
        public object UseTempFileRename { get { throw null; } set { } }
    }
    public partial class SharePointOnlineListLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SharePointOnlineListLinkedService(object siteUrl, object tenantId, object servicePrincipalId, Azure.Analytics.Synapse.Artifacts.Models.SecretBase servicePrincipalKey) { }
        public object EncryptedCredential { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
        public object SiteUrl { get { throw null; } set { } }
        public object TenantId { get { throw null; } set { } }
    }
    public partial class SharePointOnlineListResourceDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SharePointOnlineListResourceDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object ListName { get { throw null; } set { } }
    }
    public partial class SharePointOnlineListSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public SharePointOnlineListSource() { }
        public object HttpRequestTimeout { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    public partial class ShopifyLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public ShopifyLinkedService(object host) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase AccessToken { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
    }
    public partial class ShopifyObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public ShopifyObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class ShopifySource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public ShopifySource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class SkipErrorFile
    {
        public SkipErrorFile() { }
        public object DataInconsistency { get { throw null; } set { } }
        public object FileMissing { get { throw null; } set { } }
    }
    public partial class Sku
    {
        public Sku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class SmartsheetLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SmartsheetLinkedService(Azure.Analytics.Synapse.Artifacts.Models.SecretBase apiToken) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ApiToken { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
    }
    public partial class SnowflakeDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SnowflakeDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
    }
    public partial class SnowflakeExportCopyCommand : Azure.Analytics.Synapse.Artifacts.Models.ExportSettings
    {
        public SnowflakeExportCopyCommand() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalCopyOptions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> AdditionalFormatOptions { get { throw null; } }
    }
    public partial class SnowflakeImportCopyCommand : Azure.Analytics.Synapse.Artifacts.Models.ImportSettings
    {
        public SnowflakeImportCopyCommand() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalCopyOptions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> AdditionalFormatOptions { get { throw null; } }
    }
    public partial class SnowflakeLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SnowflakeLinkedService(object connectionString) { }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference Password { get { throw null; } set { } }
    }
    public partial class SnowflakeSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public SnowflakeSink() { }
        public Azure.Analytics.Synapse.Artifacts.Models.SnowflakeImportCopyCommand ImportSettings { get { throw null; } set { } }
        public object PreCopyScript { get { throw null; } set { } }
    }
    public partial class SnowflakeSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public SnowflakeSource(Azure.Analytics.Synapse.Artifacts.Models.SnowflakeExportCopyCommand exportSettings) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SnowflakeExportCopyCommand ExportSettings { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SparkAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkAuthenticationType Anonymous { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkAuthenticationType Username { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkAuthenticationType UsernameAndPassword { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkAuthenticationType WindowsAzureHDInsightService { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SparkAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SparkAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.SparkAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SparkAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SparkAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.SparkAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkBatchJob
    {
        internal SparkBatchJob() { }
        public string AppId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AppInfo { get { throw null; } }
        public string ArtifactId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Artifacts.Models.SparkServiceError> Errors { get { throw null; } }
        public int Id { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkJobType? JobType { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobState LivyInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> LogLines { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkServicePlugin Plugin { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobResultType? Result { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkScheduler Scheduler { get { throw null; } }
        public string SparkPoolName { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.LivyStates? State { get { throw null; } }
        public string SubmitterId { get { throw null; } }
        public string SubmitterName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string WorkspaceName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkBatchJobResultType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobResultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkBatchJobResultType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobResultType Cancelled { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobResultType Failed { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobResultType Succeeded { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobResultType Uncertain { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobResultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobResultType left, Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobResultType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobResultType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobResultType left, Azure.Analytics.Synapse.Artifacts.Models.SparkBatchJobResultType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkBatchJobState
    {
        internal SparkBatchJobState() { }
        public string CurrentState { get { throw null; } }
        public System.DateTimeOffset? DeadAt { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkRequest JobCreationRequest { get { throw null; } }
        public System.DateTimeOffset? NotStartedAt { get { throw null; } }
        public System.DateTimeOffset? RecoveringAt { get { throw null; } }
        public System.DateTimeOffset? RunningAt { get { throw null; } }
        public System.DateTimeOffset? StartingAt { get { throw null; } }
        public System.DateTimeOffset? SuccessAt { get { throw null; } }
        public System.DateTimeOffset? TerminatedAt { get { throw null; } }
    }
    public partial class SparkConfiguration
    {
        public SparkConfiguration(System.Collections.Generic.IDictionary<string, string> configs) { }
        public System.Collections.Generic.IList<string> Annotations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ConfigMergeRule { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Configs { get { throw null; } }
        public System.DateTimeOffset? Created { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Notes { get { throw null; } set { } }
    }
    public partial class SparkConfigurationParametrizationReference
    {
        public SparkConfigurationParametrizationReference(Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationReferenceType type, object referenceName) { }
        public object ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationReferenceType Type { get { throw null; } set { } }
    }
    public partial class SparkConfigurationReference
    {
        public SparkConfigurationReference(Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationReferenceType type, string referenceName) { }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationReferenceType Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkConfigurationReferenceType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkConfigurationReferenceType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationReferenceType SparkConfigurationReference { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationReferenceType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkConfigurationResource : Azure.Analytics.Synapse.Artifacts.Models.SubResource
    {
        public SparkConfigurationResource(Azure.Analytics.Synapse.Artifacts.Models.SparkConfiguration properties) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkConfiguration Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkErrorSource : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SparkErrorSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkErrorSource(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkErrorSource Dependency { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkErrorSource System { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkErrorSource Unknown { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkErrorSource User { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SparkErrorSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SparkErrorSource left, Azure.Analytics.Synapse.Artifacts.Models.SparkErrorSource right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SparkErrorSource (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SparkErrorSource left, Azure.Analytics.Synapse.Artifacts.Models.SparkErrorSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkJobDefinition
    {
        public SparkJobDefinition(Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolReference targetBigDataPool, Azure.Analytics.Synapse.Artifacts.Models.SparkJobProperties jobProperties) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinitionFolder Folder { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkJobProperties JobProperties { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string RequiredSparkVersion { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolReference TargetBigDataPool { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationReference TargetSparkConfiguration { get { throw null; } set { } }
    }
    public partial class SparkJobDefinitionFolder
    {
        public SparkJobDefinitionFolder() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class SparkJobDefinitionResource : Azure.Analytics.Synapse.Artifacts.Models.SubResource
    {
        public SparkJobDefinitionResource(Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinition properties) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkJobDefinition Properties { get { throw null; } set { } }
    }
    public partial class SparkJobProperties
    {
        public SparkJobProperties(string file, string driverMemory, int driverCores, string executorMemory, int executorCores, int numExecutors) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<string> Archives { get { throw null; } }
        public System.Collections.Generic.IList<string> Args { get { throw null; } }
        public string ClassName { get { throw null; } set { } }
        public object Conf { get { throw null; } set { } }
        public int DriverCores { get { throw null; } set { } }
        public string DriverMemory { get { throw null; } set { } }
        public int ExecutorCores { get { throw null; } set { } }
        public string ExecutorMemory { get { throw null; } set { } }
        public string File { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Files { get { throw null; } }
        public System.Collections.Generic.IList<string> Jars { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public int NumExecutors { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkJobReferenceType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SparkJobReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkJobReferenceType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkJobReferenceType SparkJobDefinitionReference { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SparkJobReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SparkJobReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.SparkJobReferenceType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SparkJobReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SparkJobReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.SparkJobReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkJobType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SparkJobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkJobType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkJobType SparkBatch { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkJobType SparkSession { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SparkJobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SparkJobType left, Azure.Analytics.Synapse.Artifacts.Models.SparkJobType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SparkJobType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SparkJobType left, Azure.Analytics.Synapse.Artifacts.Models.SparkJobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SparkLinkedService(object host, object port, Azure.Analytics.Synapse.Artifacts.Models.SparkAuthenticationType authenticationType) { }
        public object AllowHostNameCNMismatch { get { throw null; } set { } }
        public object AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkAuthenticationType AuthenticationType { get { throw null; } set { } }
        public object EnableSsl { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public object HttpPath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Port { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkServerType? ServerType { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkThriftTransportProtocol? ThriftTransportProtocol { get { throw null; } set { } }
        public object TrustedCertPath { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
        public object UseSystemTrustStore { get { throw null; } set { } }
    }
    public partial class SparkObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SparkObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class SparkRequest
    {
        internal SparkRequest() { }
        public System.Collections.Generic.IReadOnlyList<string> Archives { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Arguments { get { throw null; } }
        public string ClassName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Configuration { get { throw null; } }
        public int? DriverCores { get { throw null; } }
        public string DriverMemory { get { throw null; } }
        public int? ExecutorCores { get { throw null; } }
        public int? ExecutorCount { get { throw null; } }
        public string ExecutorMemory { get { throw null; } }
        public string File { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Files { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Jars { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PythonFiles { get { throw null; } }
    }
    public partial class SparkScheduler
    {
        internal SparkScheduler() { }
        public System.DateTimeOffset? CancellationRequestedAt { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.SchedulerCurrentState? CurrentState { get { throw null; } }
        public System.DateTimeOffset? EndedAt { get { throw null; } }
        public System.DateTimeOffset? ScheduledAt { get { throw null; } }
        public System.DateTimeOffset? SubmittedAt { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkServerType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SparkServerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkServerType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkServerType SharkServer { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkServerType SharkServer2 { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkServerType SparkThriftServer { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SparkServerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SparkServerType left, Azure.Analytics.Synapse.Artifacts.Models.SparkServerType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SparkServerType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SparkServerType left, Azure.Analytics.Synapse.Artifacts.Models.SparkServerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkServiceError
    {
        internal SparkServiceError() { }
        public string ErrorCode { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkErrorSource? Source { get { throw null; } }
    }
    public partial class SparkServicePlugin
    {
        internal SparkServicePlugin() { }
        public System.DateTimeOffset? CleanupStartedAt { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.PluginCurrentState? CurrentState { get { throw null; } }
        public System.DateTimeOffset? MonitoringStartedAt { get { throw null; } }
        public System.DateTimeOffset? PreparationStartedAt { get { throw null; } }
        public System.DateTimeOffset? ResourceAcquisitionStartedAt { get { throw null; } }
        public System.DateTimeOffset? SubmissionStartedAt { get { throw null; } }
    }
    public partial class SparkSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SparkSource() { }
        public object Query { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkThriftTransportProtocol : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SparkThriftTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkThriftTransportProtocol(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkThriftTransportProtocol Binary { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkThriftTransportProtocol Http { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SparkThriftTransportProtocol Sasl { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SparkThriftTransportProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SparkThriftTransportProtocol left, Azure.Analytics.Synapse.Artifacts.Models.SparkThriftTransportProtocol right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SparkThriftTransportProtocol (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SparkThriftTransportProtocol left, Azure.Analytics.Synapse.Artifacts.Models.SparkThriftTransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlAlwaysEncryptedAkvAuthType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedAkvAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlAlwaysEncryptedAkvAuthType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedAkvAuthType ManagedIdentity { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedAkvAuthType ServicePrincipal { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedAkvAuthType UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedAkvAuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedAkvAuthType left, Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedAkvAuthType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedAkvAuthType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedAkvAuthType left, Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedAkvAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlAlwaysEncryptedProperties
    {
        public SqlAlwaysEncryptedProperties(Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedAkvAuthType alwaysEncryptedAkvAuthType) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedAkvAuthType AlwaysEncryptedAkvAuthType { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public object ServicePrincipalId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ServicePrincipalKey { get { throw null; } set { } }
    }
    public partial class SqlConnection
    {
        public SqlConnection() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public string DatabaseName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string PoolName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlConnectionType? Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlConnectionType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SqlConnectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlConnectionType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SqlConnectionType SqlOnDemand { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SqlConnectionType SqlPool { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SqlConnectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SqlConnectionType left, Azure.Analytics.Synapse.Artifacts.Models.SqlConnectionType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SqlConnectionType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SqlConnectionType left, Azure.Analytics.Synapse.Artifacts.Models.SqlConnectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlDWSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public SqlDWSink() { }
        public object AllowCopyCommand { get { throw null; } set { } }
        public object AllowPolyBase { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DWCopyCommandSettings CopyCommandSettings { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.PolybaseSettings PolyBaseSettings { get { throw null; } set { } }
        public object PreCopyScript { get { throw null; } set { } }
        public object TableOption { get { throw null; } set { } }
    }
    public partial class SqlDWSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SqlDWSource() { }
        public object IsolationLevel { get { throw null; } set { } }
        public object PartitionOption { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public object SqlReaderQuery { get { throw null; } set { } }
        public object SqlReaderStoredProcedureName { get { throw null; } set { } }
        public object StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class SqlMISink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public SqlMISink() { }
        public object PreCopyScript { get { throw null; } set { } }
        public object SqlWriterStoredProcedureName { get { throw null; } set { } }
        public object SqlWriterTableType { get { throw null; } set { } }
        public object StoredProcedureParameters { get { throw null; } set { } }
        public object StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public object TableOption { get { throw null; } set { } }
    }
    public partial class SqlMISource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SqlMISource() { }
        public object IsolationLevel { get { throw null; } set { } }
        public object PartitionOption { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public object ProduceAdditionalTypes { get { throw null; } set { } }
        public object SqlReaderQuery { get { throw null; } set { } }
        public object SqlReaderStoredProcedureName { get { throw null; } set { } }
        public object StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class SqlPartitionSettings
    {
        public SqlPartitionSettings() { }
        public object PartitionColumnName { get { throw null; } set { } }
        public object PartitionLowerBound { get { throw null; } set { } }
        public object PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class SqlPool : Azure.Analytics.Synapse.Artifacts.Models.TrackedResource
    {
        public SqlPool(string location) : base (default(string)) { }
        public string Collation { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? CreationDate { get { throw null; } set { } }
        public long? MaxSizeBytes { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public string RecoverableDatabaseId { get { throw null; } set { } }
        public string RestorePointInTime { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.Sku Sku { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class SqlPoolInfoListResult
    {
        internal SqlPoolInfoListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Artifacts.Models.SqlPool> Value { get { throw null; } }
    }
    public partial class SqlPoolReference
    {
        public SqlPoolReference(Azure.Analytics.Synapse.Artifacts.Models.SqlPoolReferenceType type, string referenceName) { }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlPoolReferenceType Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlPoolReferenceType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SqlPoolReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlPoolReferenceType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SqlPoolReferenceType SqlPoolReference { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SqlPoolReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SqlPoolReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.SqlPoolReferenceType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SqlPoolReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SqlPoolReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.SqlPoolReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlPoolStoredProcedureActivity : Azure.Analytics.Synapse.Artifacts.Models.Activity
    {
        public SqlPoolStoredProcedureActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.SqlPoolReference sqlPool, object storedProcedureName) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlPoolReference SqlPool { get { throw null; } set { } }
        public object StoredProcedureName { get { throw null; } set { } }
        public object StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class SqlScript
    {
        public SqlScript(Azure.Analytics.Synapse.Artifacts.Models.SqlScriptContent content) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlScriptContent Content { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlScriptFolder Folder { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlScriptType? Type { get { throw null; } set { } }
    }
    public partial class SqlScriptContent
    {
        public SqlScriptContent(string query) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlConnection CurrentConnection { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlScriptMetadata Metadata { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public int? ResultLimit { get { throw null; } set { } }
    }
    public partial class SqlScriptFolder
    {
        public SqlScriptFolder() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class SqlScriptMetadata
    {
        public SqlScriptMetadata() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public string Language { get { throw null; } set { } }
    }
    public partial class SqlScriptResource
    {
        public SqlScriptResource(string name, Azure.Analytics.Synapse.Artifacts.Models.SqlScript properties) { }
        public string Etag { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlScript Properties { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlScriptType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SqlScriptType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlScriptType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SqlScriptType SqlQuery { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SqlScriptType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SqlScriptType left, Azure.Analytics.Synapse.Artifacts.Models.SqlScriptType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SqlScriptType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SqlScriptType left, Azure.Analytics.Synapse.Artifacts.Models.SqlScriptType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlServerLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SqlServerLinkedService(object connectionString) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class SqlServerSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public SqlServerSink() { }
        public object PreCopyScript { get { throw null; } set { } }
        public object SqlWriterStoredProcedureName { get { throw null; } set { } }
        public object SqlWriterTableType { get { throw null; } set { } }
        public object StoredProcedureParameters { get { throw null; } set { } }
        public object StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public object TableOption { get { throw null; } set { } }
    }
    public partial class SqlServerSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SqlServerSource() { }
        public object IsolationLevel { get { throw null; } set { } }
        public object PartitionOption { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public object ProduceAdditionalTypes { get { throw null; } set { } }
        public object SqlReaderQuery { get { throw null; } set { } }
        public object SqlReaderStoredProcedureName { get { throw null; } set { } }
        public object StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class SqlServerStoredProcedureActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public SqlServerStoredProcedureActivity(string name, object storedProcedureName) : base (default(string)) { }
        public object StoredProcedureName { get { throw null; } set { } }
        public object StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class SqlServerTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SqlServerTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class SqlSink : Azure.Analytics.Synapse.Artifacts.Models.CopySink
    {
        public SqlSink() { }
        public object PreCopyScript { get { throw null; } set { } }
        public object SqlWriterStoredProcedureName { get { throw null; } set { } }
        public object SqlWriterTableType { get { throw null; } set { } }
        public object StoredProcedureParameters { get { throw null; } set { } }
        public object StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public object TableOption { get { throw null; } set { } }
    }
    public partial class SqlSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SqlSource() { }
        public object IsolationLevel { get { throw null; } set { } }
        public object PartitionOption { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public object SqlReaderQuery { get { throw null; } set { } }
        public object SqlReaderStoredProcedureName { get { throw null; } set { } }
        public object StoredProcedureParameters { get { throw null; } set { } }
    }
    public partial class SquareLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SquareLinkedService(object host, object clientId, object redirectUri) { }
        public object ClientId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ClientSecret { get { throw null; } set { } }
        public object ConnectionProperties { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public object RedirectUri { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
    }
    public partial class SquareObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SquareObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class SquareSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SquareSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class SsisAccessCredential
    {
        public SsisAccessCredential(object domain, object userName, Azure.Analytics.Synapse.Artifacts.Models.SecretBase password) { }
        public object Domain { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class SsisChildPackage
    {
        public SsisChildPackage(object packagePath, object packageContent) { }
        public object PackageContent { get { throw null; } set { } }
        public string PackageLastModifiedDate { get { throw null; } set { } }
        public string PackageName { get { throw null; } set { } }
        public object PackagePath { get { throw null; } set { } }
    }
    public partial class SsisExecutionCredential
    {
        public SsisExecutionCredential(object domain, object userName, Azure.Analytics.Synapse.Artifacts.Models.SecureString password) { }
        public object Domain { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecureString Password { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class SsisExecutionParameter
    {
        public SsisExecutionParameter(object value) { }
        public object Value { get { throw null; } set { } }
    }
    public partial class SsisLogLocation
    {
        public SsisLogLocation(object logPath, Azure.Analytics.Synapse.Artifacts.Models.SsisLogLocationType type) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SsisAccessCredential AccessCredential { get { throw null; } set { } }
        public object LogPath { get { throw null; } set { } }
        public object LogRefreshInterval { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SsisLogLocationType Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SsisLogLocationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SsisLogLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SsisLogLocationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SsisLogLocationType File { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SsisLogLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SsisLogLocationType left, Azure.Analytics.Synapse.Artifacts.Models.SsisLogLocationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SsisLogLocationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SsisLogLocationType left, Azure.Analytics.Synapse.Artifacts.Models.SsisLogLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SsisObjectMetadataStatusResponse
    {
        public SsisObjectMetadataStatusResponse() { }
        public string Error { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Properties { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class SsisPackageLocation
    {
        public SsisPackageLocation() { }
        public Azure.Analytics.Synapse.Artifacts.Models.SsisAccessCredential AccessCredential { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.SsisChildPackage> ChildPackages { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.SsisAccessCredential ConfigurationAccessCredential { get { throw null; } set { } }
        public object ConfigurationPath { get { throw null; } set { } }
        public object PackageContent { get { throw null; } set { } }
        public string PackageLastModifiedDate { get { throw null; } set { } }
        public string PackageName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase PackagePassword { get { throw null; } set { } }
        public object PackagePath { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SsisPackageLocationType? Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SsisPackageLocationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SsisPackageLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SsisPackageLocationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SsisPackageLocationType File { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SsisPackageLocationType InlinePackage { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SsisPackageLocationType PackageStore { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SsisPackageLocationType Ssisdb { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SsisPackageLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SsisPackageLocationType left, Azure.Analytics.Synapse.Artifacts.Models.SsisPackageLocationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SsisPackageLocationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SsisPackageLocationType left, Azure.Analytics.Synapse.Artifacts.Models.SsisPackageLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SsisPropertyOverride
    {
        public SsisPropertyOverride(object value) { }
        public bool? IsSensitive { get { throw null; } set { } }
        public object Value { get { throw null; } set { } }
    }
    public partial class StagingSettings
    {
        public StagingSettings(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object EnableCompression { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public object Path { get { throw null; } set { } }
    }
    public partial class StartDataFlowDebugSessionRequest
    {
        public StartDataFlowDebugSessionRequest() { }
        public Azure.Analytics.Synapse.Artifacts.Models.DataFlowResource DataFlow { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DataFlowResource> DataFlows { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DatasetResource> Datasets { get { throw null; } }
        public object DebugSettings { get { throw null; } set { } }
        public bool? IncrementalDebug { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceResource> LinkedServices { get { throw null; } }
        public string SessionId { get { throw null; } set { } }
        public object Staging { get { throw null; } set { } }
    }
    public partial class StartDataFlowDebugSessionResponse
    {
        public StartDataFlowDebugSessionResponse() { }
        public string JobVersion { get { throw null; } set { } }
    }
    public abstract partial class StoreReadSettings
    {
        protected StoreReadSettings() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object MaxConcurrentConnections { get { throw null; } set { } }
    }
    public abstract partial class StoreWriteSettings
    {
        protected StoreWriteSettings() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public object CopyBehavior { get { throw null; } set { } }
        public object MaxConcurrentConnections { get { throw null; } set { } }
    }
    public partial class SubResource : Azure.Analytics.Synapse.Artifacts.Models.AzureEntityResource
    {
        public SubResource() { }
    }
    public partial class SubResourceDebugResource
    {
        public SubResourceDebugResource() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class SwitchActivity : Azure.Analytics.Synapse.Artifacts.Models.ControlActivity
    {
        public SwitchActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.Expression on) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.SwitchCase> Cases { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.Activity> DefaultActivities { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.Expression On { get { throw null; } set { } }
    }
    public partial class SwitchCase
    {
        public SwitchCase() { }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.Activity> Activities { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SybaseAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.SybaseAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SybaseAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.SybaseAuthenticationType Basic { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.SybaseAuthenticationType Windows { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.SybaseAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.SybaseAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.SybaseAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.SybaseAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.SybaseAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.SybaseAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SybaseLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public SybaseLinkedService(object server, object database) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SybaseAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public object Database { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Schema { get { throw null; } set { } }
        public object Server { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class SybaseSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public SybaseSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class SybaseTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public SybaseTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class SynapseNotebookActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public SynapseNotebookActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.SynapseNotebookReference notebook) : base (default(string)) { }
        public object Conf { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.ConfigurationType? ConfigurationType { get { throw null; } set { } }
        public object DriverSize { get { throw null; } set { } }
        public object ExecutorSize { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SynapseNotebookReference Notebook { get { throw null; } set { } }
        public object NumExecutors { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Analytics.Synapse.Artifacts.Models.NotebookParameter> Parameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> SparkConfig { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolParametrizationReference SparkPool { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationParametrizationReference TargetSparkConfiguration { get { throw null; } set { } }
    }
    public partial class SynapseNotebookReference
    {
        public SynapseNotebookReference(Azure.Analytics.Synapse.Artifacts.Models.NotebookReferenceType type, object referenceName) { }
        public object ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.NotebookReferenceType Type { get { throw null; } set { } }
    }
    public partial class SynapseSparkJobDefinitionActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public SynapseSparkJobDefinitionActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.SynapseSparkJobReference sparkJob) : base (default(string)) { }
        public System.Collections.Generic.IList<object> Arguments { get { throw null; } }
        public object ClassName { get { throw null; } set { } }
        public object Conf { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.ConfigurationType? ConfigurationType { get { throw null; } set { } }
        public object DriverSize { get { throw null; } set { } }
        public object ExecutorSize { get { throw null; } set { } }
        public object File { get { throw null; } set { } }
        public System.Collections.Generic.IList<object> Files { get { throw null; } }
        public System.Collections.Generic.IList<object> FilesV2 { get { throw null; } }
        public object NumExecutors { get { throw null; } set { } }
        public System.Collections.Generic.IList<object> PythonCodeReference { get { throw null; } }
        public object ScanFolder { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> SparkConfig { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.SynapseSparkJobReference SparkJob { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.BigDataPoolParametrizationReference TargetBigDataPool { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkConfigurationParametrizationReference TargetSparkConfiguration { get { throw null; } set { } }
    }
    public partial class SynapseSparkJobReference
    {
        public SynapseSparkJobReference(Azure.Analytics.Synapse.Artifacts.Models.SparkJobReferenceType type, string referenceName) { }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SparkJobReferenceType Type { get { throw null; } set { } }
    }
    public partial class TabularSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public TabularSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public object QueryTimeout { get { throw null; } set { } }
    }
    public partial class TabularTranslator : Azure.Analytics.Synapse.Artifacts.Models.CopyTranslator
    {
        public TabularTranslator() { }
        public object CollectionReference { get { throw null; } set { } }
        public object ColumnMappings { get { throw null; } set { } }
        public object MapComplexValuesToString { get { throw null; } set { } }
        public object Mappings { get { throw null; } set { } }
        public object SchemaMapping { get { throw null; } set { } }
        public object TypeConversion { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.TypeConversionSettings TypeConversionSettings { get { throw null; } set { } }
    }
    public partial class TarGZipReadSettings : Azure.Analytics.Synapse.Artifacts.Models.CompressionReadSettings
    {
        public TarGZipReadSettings() { }
        public object PreserveCompressionFileNameAsFolder { get { throw null; } set { } }
    }
    public partial class TarReadSettings : Azure.Analytics.Synapse.Artifacts.Models.CompressionReadSettings
    {
        public TarReadSettings() { }
        public object PreserveCompressionFileNameAsFolder { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TeamDeskAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.TeamDeskAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TeamDeskAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.TeamDeskAuthenticationType Basic { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.TeamDeskAuthenticationType Token { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.TeamDeskAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.TeamDeskAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.TeamDeskAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.TeamDeskAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.TeamDeskAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.TeamDeskAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TeamDeskLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public TeamDeskLinkedService(Azure.Analytics.Synapse.Artifacts.Models.TeamDeskAuthenticationType authenticationType, object url) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ApiToken { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.TeamDeskAuthenticationType AuthenticationType { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Url { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TeradataAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.TeradataAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TeradataAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.TeradataAuthenticationType Basic { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.TeradataAuthenticationType Windows { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.TeradataAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.TeradataAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.TeradataAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.TeradataAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.TeradataAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.TeradataAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TeradataLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public TeradataLinkedService() { }
        public Azure.Analytics.Synapse.Artifacts.Models.TeradataAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Server { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TeradataPartitionOption : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.TeradataPartitionOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TeradataPartitionOption(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.TeradataPartitionOption DynamicRange { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.TeradataPartitionOption Hash { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.TeradataPartitionOption None { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.TeradataPartitionOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.TeradataPartitionOption left, Azure.Analytics.Synapse.Artifacts.Models.TeradataPartitionOption right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.TeradataPartitionOption (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.TeradataPartitionOption left, Azure.Analytics.Synapse.Artifacts.Models.TeradataPartitionOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TeradataPartitionSettings
    {
        public TeradataPartitionSettings() { }
        public object PartitionColumnName { get { throw null; } set { } }
        public object PartitionLowerBound { get { throw null; } set { } }
        public object PartitionUpperBound { get { throw null; } set { } }
    }
    public partial class TeradataSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public TeradataSource() { }
        public Azure.Analytics.Synapse.Artifacts.Models.TeradataPartitionOption? PartitionOption { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.TeradataPartitionSettings PartitionSettings { get { throw null; } set { } }
        public object Query { get { throw null; } set { } }
    }
    public partial class TeradataTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public TeradataTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Database { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
    }
    public partial class TextFormat : Azure.Analytics.Synapse.Artifacts.Models.DatasetStorageFormat
    {
        public TextFormat() { }
        public object ColumnDelimiter { get { throw null; } set { } }
        public object EncodingName { get { throw null; } set { } }
        public object EscapeChar { get { throw null; } set { } }
        public object FirstRowAsHeader { get { throw null; } set { } }
        public object NullValue { get { throw null; } set { } }
        public object QuoteChar { get { throw null; } set { } }
        public object RowDelimiter { get { throw null; } set { } }
        public object SkipLineCount { get { throw null; } set { } }
        public object TreatEmptyAsNull { get { throw null; } set { } }
    }
    public partial class TrackedResource : Azure.Analytics.Synapse.Artifacts.Models.Resource
    {
        public TrackedResource(string location) { }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class Transformation
    {
        public Transformation(string name) { }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetReference Dataset { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DataFlowReference Flowlet { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference LinkedService { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public abstract partial class Trigger
    {
        protected Trigger() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<object> Annotations { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState? RuntimeState { get { throw null; } }
    }
    public partial class TriggerDependencyProvisioningStatus
    {
        public TriggerDependencyProvisioningStatus(string triggerName, string provisioningStatus) { }
        public string ProvisioningStatus { get { throw null; } set { } }
        public string TriggerName { get { throw null; } set { } }
    }
    public partial class TriggerDependencyReference : Azure.Analytics.Synapse.Artifacts.Models.DependencyReference
    {
        public TriggerDependencyReference(Azure.Analytics.Synapse.Artifacts.Models.TriggerReference referenceTrigger) { }
        public Azure.Analytics.Synapse.Artifacts.Models.TriggerReference ReferenceTrigger { get { throw null; } set { } }
    }
    public partial class TriggerPipelineReference
    {
        public TriggerPipelineReference() { }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.PipelineReference PipelineReference { get { throw null; } set { } }
    }
    public partial class TriggerReference
    {
        public TriggerReference(Azure.Analytics.Synapse.Artifacts.Models.TriggerReferenceType type, string referenceName) { }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.TriggerReferenceType Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggerReferenceType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.TriggerReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggerReferenceType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.TriggerReferenceType TriggerReference { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.TriggerReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.TriggerReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.TriggerReferenceType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.TriggerReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.TriggerReferenceType left, Azure.Analytics.Synapse.Artifacts.Models.TriggerReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TriggerResource : Azure.Analytics.Synapse.Artifacts.Models.SubResource
    {
        public TriggerResource(Azure.Analytics.Synapse.Artifacts.Models.Trigger properties) { }
        public Azure.Analytics.Synapse.Artifacts.Models.Trigger Properties { get { throw null; } set { } }
    }
    public partial class TriggerRun
    {
        internal TriggerRun() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> AdditionalProperties { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.TriggerRunStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TriggeredPipelines { get { throw null; } }
        public string TriggerName { get { throw null; } }
        public string TriggerRunId { get { throw null; } }
        public System.DateTimeOffset? TriggerRunTimestamp { get { throw null; } }
        public string TriggerType { get { throw null; } }
    }
    public partial class TriggerRunsQueryResponse
    {
        internal TriggerRunsQueryResponse() { }
        public string ContinuationToken { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Artifacts.Models.TriggerRun> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggerRunStatus : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.TriggerRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggerRunStatus(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.TriggerRunStatus Failed { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.TriggerRunStatus InProgress { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.TriggerRunStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.TriggerRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.TriggerRunStatus left, Azure.Analytics.Synapse.Artifacts.Models.TriggerRunStatus right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.TriggerRunStatus (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.TriggerRunStatus left, Azure.Analytics.Synapse.Artifacts.Models.TriggerRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggerRuntimeState : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggerRuntimeState(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState Disabled { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState Started { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState Stopped { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState left, Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState left, Azure.Analytics.Synapse.Artifacts.Models.TriggerRuntimeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TriggerSubscriptionOperationStatus
    {
        internal TriggerSubscriptionOperationStatus() { }
        public Azure.Analytics.Synapse.Artifacts.Models.EventSubscriptionStatus? Status { get { throw null; } }
        public string TriggerName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TumblingWindowFrequency : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.TumblingWindowFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TumblingWindowFrequency(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.TumblingWindowFrequency Hour { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.TumblingWindowFrequency Minute { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.TumblingWindowFrequency Month { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.TumblingWindowFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.TumblingWindowFrequency left, Azure.Analytics.Synapse.Artifacts.Models.TumblingWindowFrequency right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.TumblingWindowFrequency (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.TumblingWindowFrequency left, Azure.Analytics.Synapse.Artifacts.Models.TumblingWindowFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TumblingWindowTrigger : Azure.Analytics.Synapse.Artifacts.Models.Trigger
    {
        public TumblingWindowTrigger(Azure.Analytics.Synapse.Artifacts.Models.TriggerPipelineReference pipeline, Azure.Analytics.Synapse.Artifacts.Models.TumblingWindowFrequency frequency, int interval, System.DateTimeOffset startTime, int maxConcurrency) { }
        public object Delay { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DependencyReference> DependsOn { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.TumblingWindowFrequency Frequency { get { throw null; } set { } }
        public int Interval { get { throw null; } set { } }
        public int MaxConcurrency { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.TriggerPipelineReference Pipeline { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.RetryPolicy RetryPolicy { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } set { } }
    }
    public partial class TumblingWindowTriggerDependencyReference : Azure.Analytics.Synapse.Artifacts.Models.TriggerDependencyReference
    {
        public TumblingWindowTriggerDependencyReference(Azure.Analytics.Synapse.Artifacts.Models.TriggerReference referenceTrigger) : base (default(Azure.Analytics.Synapse.Artifacts.Models.TriggerReference)) { }
        public string Offset { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
    }
    public partial class TwilioLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public TwilioLinkedService(object userName, Azure.Analytics.Synapse.Artifacts.Models.SecretBase password) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class TypeConversionSettings
    {
        public TypeConversionSettings() { }
        public object AllowDataTruncation { get { throw null; } set { } }
        public object Culture { get { throw null; } set { } }
        public object DateTimeFormat { get { throw null; } set { } }
        public object DateTimeOffsetFormat { get { throw null; } set { } }
        public object TimeSpanFormat { get { throw null; } set { } }
        public object TreatBooleanAsNumber { get { throw null; } set { } }
    }
    public partial class UntilActivity : Azure.Analytics.Synapse.Artifacts.Models.ControlActivity
    {
        public UntilActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.Expression expression, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Artifacts.Models.Activity> activities) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.Activity> Activities { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.Expression Expression { get { throw null; } set { } }
        public object Timeout { get { throw null; } set { } }
    }
    public partial class UpdateLandingZoneCredential
    {
        public UpdateLandingZoneCredential() { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecureString SasToken { get { throw null; } set { } }
    }
    public partial class UserProperty
    {
        public UserProperty(string name, object value) { }
        public string Name { get { throw null; } set { } }
        public object Value { get { throw null; } set { } }
    }
    public partial class ValidationActivity : Azure.Analytics.Synapse.Artifacts.Models.ControlActivity
    {
        public ValidationActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.DatasetReference dataset) : base (default(string)) { }
        public object ChildItems { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetReference Dataset { get { throw null; } set { } }
        public object MinimumSize { get { throw null; } set { } }
        public object Sleep { get { throw null; } set { } }
        public object Timeout { get { throw null; } set { } }
    }
    public partial class VariableSpecification
    {
        public VariableSpecification(Azure.Analytics.Synapse.Artifacts.Models.VariableType type) { }
        public object DefaultValue { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.VariableType Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VariableType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.VariableType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VariableType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.VariableType Array { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.VariableType Bool { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.VariableType Boolean { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.VariableType String { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.VariableType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.VariableType left, Azure.Analytics.Synapse.Artifacts.Models.VariableType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.VariableType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.VariableType left, Azure.Analytics.Synapse.Artifacts.Models.VariableType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VerticaLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public VerticaLinkedService() { }
        public object ConnectionString { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.AzureKeyVaultSecretReference Pwd { get { throw null; } set { } }
    }
    public partial class VerticaSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public VerticaSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class VerticaTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public VerticaTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object SchemaTypePropertiesSchema { get { throw null; } set { } }
        public object Table { get { throw null; } set { } }
        public object TableName { get { throw null; } set { } }
    }
    public partial class VirtualNetworkProfile
    {
        public VirtualNetworkProfile() { }
        public string ComputeSubnetId { get { throw null; } set { } }
    }
    public partial class WaitActivity : Azure.Analytics.Synapse.Artifacts.Models.ControlActivity
    {
        public WaitActivity(string name, object waitTimeInSeconds) : base (default(string)) { }
        public object WaitTimeInSeconds { get { throw null; } set { } }
    }
    public partial class WebActivity : Azure.Analytics.Synapse.Artifacts.Models.ExecutionActivity
    {
        public WebActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.WebActivityMethod method, object url) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.WebActivityAuthentication Authentication { get { throw null; } set { } }
        public object Body { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.IntegrationRuntimeReference ConnectVia { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.DatasetReference> Datasets { get { throw null; } }
        public object Headers { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference> LinkedServices { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.WebActivityMethod Method { get { throw null; } set { } }
        public object Url { get { throw null; } set { } }
    }
    public partial class WebActivityAuthentication
    {
        public WebActivityAuthentication(string type) { }
        public Azure.Analytics.Synapse.Artifacts.Models.CredentialReference Credential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Pfx { get { throw null; } set { } }
        public object Resource { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
        public object UserTenant { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebActivityMethod : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.WebActivityMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebActivityMethod(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.WebActivityMethod Delete { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.WebActivityMethod GET { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.WebActivityMethod Post { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.WebActivityMethod PUT { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.WebActivityMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.WebActivityMethod left, Azure.Analytics.Synapse.Artifacts.Models.WebActivityMethod right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.WebActivityMethod (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.WebActivityMethod left, Azure.Analytics.Synapse.Artifacts.Models.WebActivityMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebAnonymousAuthentication : Azure.Analytics.Synapse.Artifacts.Models.WebLinkedServiceTypeProperties
    {
        public WebAnonymousAuthentication(object url) : base (default(object)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.WebAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.WebAuthenticationType Anonymous { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.WebAuthenticationType Basic { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.WebAuthenticationType ClientCertificate { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.WebAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.WebAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.WebAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.WebAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.WebAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.WebAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebBasicAuthentication : Azure.Analytics.Synapse.Artifacts.Models.WebLinkedServiceTypeProperties
    {
        public WebBasicAuthentication(object url, object username, Azure.Analytics.Synapse.Artifacts.Models.SecretBase password) : base (default(object)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Username { get { throw null; } set { } }
    }
    public partial class WebClientCertificateAuthentication : Azure.Analytics.Synapse.Artifacts.Models.WebLinkedServiceTypeProperties
    {
        public WebClientCertificateAuthentication(object url, Azure.Analytics.Synapse.Artifacts.Models.SecretBase pfx, Azure.Analytics.Synapse.Artifacts.Models.SecretBase password) : base (default(object)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Pfx { get { throw null; } set { } }
    }
    public partial class WebHookActivity : Azure.Analytics.Synapse.Artifacts.Models.ControlActivity
    {
        public WebHookActivity(string name, Azure.Analytics.Synapse.Artifacts.Models.WebHookActivityMethod method, object url) : base (default(string)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.WebActivityAuthentication Authentication { get { throw null; } set { } }
        public object Body { get { throw null; } set { } }
        public object Headers { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.WebHookActivityMethod Method { get { throw null; } set { } }
        public object ReportStatusOnCallBack { get { throw null; } set { } }
        public string Timeout { get { throw null; } set { } }
        public object Url { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebHookActivityMethod : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.WebHookActivityMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebHookActivityMethod(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.WebHookActivityMethod Post { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.WebHookActivityMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.WebHookActivityMethod left, Azure.Analytics.Synapse.Artifacts.Models.WebHookActivityMethod right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.WebHookActivityMethod (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.WebHookActivityMethod left, Azure.Analytics.Synapse.Artifacts.Models.WebHookActivityMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public WebLinkedService(Azure.Analytics.Synapse.Artifacts.Models.WebLinkedServiceTypeProperties typeProperties) { }
        public Azure.Analytics.Synapse.Artifacts.Models.WebLinkedServiceTypeProperties TypeProperties { get { throw null; } set { } }
    }
    public partial class WebLinkedServiceTypeProperties
    {
        public WebLinkedServiceTypeProperties(object url) { }
        public object Url { get { throw null; } set { } }
    }
    public partial class WebSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public WebSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
    }
    public partial class WebTableDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public WebTableDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName, object index) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object Index { get { throw null; } set { } }
        public object Path { get { throw null; } set { } }
    }
    public partial class Workspace : Azure.Analytics.Synapse.Artifacts.Models.TrackedResource
    {
        public Workspace(string location) : base (default(string)) { }
        public string AdlaResourceId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ConnectivityEndpoints { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.DataLakeStorageAccountDetails DefaultDataLakeStorage { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.EncryptionDetails Encryption { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> ExtraProperties { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.ManagedIdentity Identity { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public string ManagedVirtualNetwork { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.ManagedVirtualNetworkSettings ManagedVirtualNetworkSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.Artifacts.Models.PrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.PurviewConfiguration PurviewConfiguration { get { throw null; } set { } }
        public string SqlAdministratorLogin { get { throw null; } set { } }
        public string SqlAdministratorLoginPassword { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.VirtualNetworkProfile VirtualNetworkProfile { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.WorkspaceRepositoryConfiguration WorkspaceRepositoryConfiguration { get { throw null; } set { } }
        public System.Guid? WorkspaceUID { get { throw null; } }
    }
    public partial class WorkspaceIdentity
    {
        public WorkspaceIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.Analytics.Synapse.Artifacts.Models.WorkspaceIdentityType Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkspaceIdentityType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.WorkspaceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkspaceIdentityType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.WorkspaceIdentityType SystemAssigned { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.WorkspaceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.WorkspaceIdentityType left, Azure.Analytics.Synapse.Artifacts.Models.WorkspaceIdentityType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.WorkspaceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.WorkspaceIdentityType left, Azure.Analytics.Synapse.Artifacts.Models.WorkspaceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceKeyDetails
    {
        public WorkspaceKeyDetails() { }
        public string KeyVaultUrl { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class WorkspaceRepositoryConfiguration
    {
        public WorkspaceRepositoryConfiguration() { }
        public string AccountName { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.GitHubClientSecret ClientSecret { get { throw null; } set { } }
        public string CollaborationBranch { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public string LastCommitId { get { throw null; } set { } }
        public string ProjectName { get { throw null; } set { } }
        public string RepositoryName { get { throw null; } set { } }
        public string RootFolder { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    public partial class WorkspaceUpdateParameters
    {
        public WorkspaceUpdateParameters() { }
        public Azure.Analytics.Synapse.Artifacts.Models.WorkspaceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class XeroLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public XeroLinkedService(object host) { }
        public object ConnectionProperties { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ConsumerKey { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Host { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase PrivateKey { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
    }
    public partial class XeroObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public XeroObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class XeroSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public XeroSource() { }
        public object Query { get { throw null; } set { } }
    }
    public partial class XmlDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public XmlDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetCompression Compression { get { throw null; } set { } }
        public object EncodingName { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.DatasetLocation Location { get { throw null; } set { } }
        public object NullValue { get { throw null; } set { } }
    }
    public partial class XmlReadSettings : Azure.Analytics.Synapse.Artifacts.Models.FormatReadSettings
    {
        public XmlReadSettings() { }
        public Azure.Analytics.Synapse.Artifacts.Models.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
        public object DetectDataType { get { throw null; } set { } }
        public object NamespacePrefixes { get { throw null; } set { } }
        public object Namespaces { get { throw null; } set { } }
        public object ValidationMode { get { throw null; } set { } }
    }
    public partial class XmlSource : Azure.Analytics.Synapse.Artifacts.Models.CopySource
    {
        public XmlSource() { }
        public object AdditionalColumns { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.XmlReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.StoreReadSettings StoreSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZendeskAuthenticationType : System.IEquatable<Azure.Analytics.Synapse.Artifacts.Models.ZendeskAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZendeskAuthenticationType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Artifacts.Models.ZendeskAuthenticationType Basic { get { throw null; } }
        public static Azure.Analytics.Synapse.Artifacts.Models.ZendeskAuthenticationType Token { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Artifacts.Models.ZendeskAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Artifacts.Models.ZendeskAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.ZendeskAuthenticationType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Artifacts.Models.ZendeskAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Artifacts.Models.ZendeskAuthenticationType left, Azure.Analytics.Synapse.Artifacts.Models.ZendeskAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ZendeskLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public ZendeskLinkedService(Azure.Analytics.Synapse.Artifacts.Models.ZendeskAuthenticationType authenticationType, object url) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase ApiToken { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.ZendeskAuthenticationType AuthenticationType { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase Password { get { throw null; } set { } }
        public object Url { get { throw null; } set { } }
        public object UserName { get { throw null; } set { } }
    }
    public partial class ZipDeflateReadSettings : Azure.Analytics.Synapse.Artifacts.Models.CompressionReadSettings
    {
        public ZipDeflateReadSettings() { }
        public object PreserveZipFileNameAsFolder { get { throw null; } set { } }
    }
    public partial class ZohoLinkedService : Azure.Analytics.Synapse.Artifacts.Models.LinkedService
    {
        public ZohoLinkedService(object endpoint) { }
        public Azure.Analytics.Synapse.Artifacts.Models.SecretBase AccessToken { get { throw null; } set { } }
        public object ConnectionProperties { get { throw null; } set { } }
        public object EncryptedCredential { get { throw null; } set { } }
        public object Endpoint { get { throw null; } set { } }
        public object UseEncryptedEndpoints { get { throw null; } set { } }
        public object UseHostVerification { get { throw null; } set { } }
        public object UsePeerVerification { get { throw null; } set { } }
    }
    public partial class ZohoObjectDataset : Azure.Analytics.Synapse.Artifacts.Models.Dataset
    {
        public ZohoObjectDataset(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference linkedServiceName) : base (default(Azure.Analytics.Synapse.Artifacts.Models.LinkedServiceReference)) { }
        public object TableName { get { throw null; } set { } }
    }
    public partial class ZohoSource : Azure.Analytics.Synapse.Artifacts.Models.TabularSource
    {
        public ZohoSource() { }
        public object Query { get { throw null; } set { } }
    }
}
