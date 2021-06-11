namespace Azure.Analytics.Synapse.Artifacts
{
    public partial class ArtifactsClientOptions : Azure.Core.ClientOptions
    {
        public ArtifactsClientOptions(Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions.ServiceVersion version = Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions.ServiceVersion.V2019_06_01_preview) { }
        public enum ServiceVersion
        {
            V2019_06_01_preview = 1,
        }
    }
    public partial class BigDataPoolsClient
    {
        protected BigDataPoolsClient() { }
        public BigDataPoolsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Get(string bigDataPoolName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string bigDataPoolName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response List(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListAsync(Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class DataFlowClient
    {
        protected DataFlowClient() { }
        public DataFlowClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateDataFlow(string dataFlowName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateDataFlowAsync(string dataFlowName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response DeleteDataFlow(string dataFlowName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDataFlowAsync(string dataFlowName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetDataFlow(string dataFlowName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDataFlowAsync(string dataFlowName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetDataFlowsByWorkspace(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDataFlowsByWorkspaceAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response RenameDataFlow(string dataFlowName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenameDataFlowAsync(string dataFlowName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class DataFlowDebugSessionClient
    {
        protected DataFlowDebugSessionClient() { }
        public DataFlowDebugSessionClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AddDataFlow(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddDataFlowAsync(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response CreateDataFlowDebugSession(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateDataFlowDebugSessionAsync(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response DeleteDataFlowDebugSession(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDataFlowDebugSessionAsync(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response ExecuteCommand(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteCommandAsync(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response QueryDataFlowDebugSessionsByWorkspace(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> QueryDataFlowDebugSessionsByWorkspaceAsync(Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class DatasetClient
    {
        protected DatasetClient() { }
        public DatasetClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateDataset(string datasetName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateDatasetAsync(string datasetName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response DeleteDataset(string datasetName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDatasetAsync(string datasetName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetDataset(string datasetName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDatasetAsync(string datasetName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetDatasetsByWorkspace(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDatasetsByWorkspaceAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response RenameDataset(string datasetName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenameDatasetAsync(string datasetName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class IntegrationRuntimesClient
    {
        protected IntegrationRuntimesClient() { }
        public IntegrationRuntimesClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Get(string integrationRuntimeName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string integrationRuntimeName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response List(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListAsync(Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class LibraryClient
    {
        protected LibraryClient() { }
        public LibraryClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Append(string libraryName, Azure.Core.RequestContent requestBody, long? blobConditionAppendPosition = default(long?), Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AppendAsync(string libraryName, Azure.Core.RequestContent requestBody, long? blobConditionAppendPosition = default(long?), Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response Create(string libraryName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(string libraryName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response Delete(string libraryName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string libraryName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response Flush(string libraryName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> FlushAsync(string libraryName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response Get(string libraryName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string libraryName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetOperationResult(string operationId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationResultAsync(string operationId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response List(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListAsync(Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class LinkedServiceClient
    {
        protected LinkedServiceClient() { }
        public LinkedServiceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateLinkedService(string linkedServiceName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateLinkedServiceAsync(string linkedServiceName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response DeleteLinkedService(string linkedServiceName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteLinkedServiceAsync(string linkedServiceName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetLinkedService(string linkedServiceName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLinkedServiceAsync(string linkedServiceName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetLinkedServicesByWorkspace(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLinkedServicesByWorkspaceAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response RenameLinkedService(string linkedServiceName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenameLinkedServiceAsync(string linkedServiceName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, Size=1)]
    public partial struct LinkedServiceReferenceType
    {
    }
    public partial class NotebookClient
    {
        protected NotebookClient() { }
        public NotebookClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateNotebook(string notebookName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateNotebookAsync(string notebookName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response DeleteNotebook(string notebookName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteNotebookAsync(string notebookName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetNotebook(string notebookName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetNotebookAsync(string notebookName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetNotebooksByWorkspace(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetNotebooksByWorkspaceAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetNotebookSummaryByWorkSpace(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetNotebookSummaryByWorkSpaceAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response RenameNotebook(string notebookName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenameNotebookAsync(string notebookName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class PipelineClient
    {
        protected PipelineClient() { }
        public PipelineClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdatePipeline(string pipelineName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdatePipelineAsync(string pipelineName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response CreatePipelineRun(string pipelineName, Azure.Core.RequestContent requestBody, string referencePipelineRunId = null, bool? isRecovery = default(bool?), string startActivityName = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreatePipelineRunAsync(string pipelineName, Azure.Core.RequestContent requestBody, string referencePipelineRunId = null, bool? isRecovery = default(bool?), string startActivityName = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response DeletePipeline(string pipelineName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeletePipelineAsync(string pipelineName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetPipeline(string pipelineName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPipelineAsync(string pipelineName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetPipelinesByWorkspace(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPipelinesByWorkspaceAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response RenamePipeline(string pipelineName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenamePipelineAsync(string pipelineName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class PipelineRunClient
    {
        protected PipelineRunClient() { }
        public PipelineRunClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelPipelineRun(string runId, bool? isRecursive = default(bool?), Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelPipelineRunAsync(string runId, bool? isRecursive = default(bool?), Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetPipelineRun(string runId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPipelineRunAsync(string runId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response QueryActivityRuns(string pipelineName, string runId, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> QueryActivityRunsAsync(string pipelineName, string runId, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response QueryPipelineRunsByWorkspace(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> QueryPipelineRunsByWorkspaceAsync(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class SparkJobDefinitionClient
    {
        protected SparkJobDefinitionClient() { }
        public SparkJobDefinitionClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateSparkJobDefinition(string sparkJobDefinitionName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateSparkJobDefinitionAsync(string sparkJobDefinitionName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response DebugSparkJobDefinition(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DebugSparkJobDefinitionAsync(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response DeleteSparkJobDefinition(string sparkJobDefinitionName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSparkJobDefinitionAsync(string sparkJobDefinitionName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response ExecuteSparkJobDefinition(string sparkJobDefinitionName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteSparkJobDefinitionAsync(string sparkJobDefinitionName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetSparkJobDefinition(string sparkJobDefinitionName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSparkJobDefinitionAsync(string sparkJobDefinitionName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetSparkJobDefinitionsByWorkspace(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSparkJobDefinitionsByWorkspaceAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response RenameSparkJobDefinition(string sparkJobDefinitionName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenameSparkJobDefinitionAsync(string sparkJobDefinitionName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class SqlPoolsClient
    {
        protected SqlPoolsClient() { }
        public SqlPoolsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Get(string sqlPoolName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string sqlPoolName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response List(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListAsync(Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class SqlScriptClient
    {
        protected SqlScriptClient() { }
        public SqlScriptClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateSqlScript(string sqlScriptName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateSqlScriptAsync(string sqlScriptName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response DeleteSqlScript(string sqlScriptName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSqlScriptAsync(string sqlScriptName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetSqlScript(string sqlScriptName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSqlScriptAsync(string sqlScriptName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetSqlScriptsByWorkspace(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSqlScriptsByWorkspaceAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response RenameSqlScript(string sqlScriptName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenameSqlScriptAsync(string sqlScriptName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class TriggerClient
    {
        protected TriggerClient() { }
        public TriggerClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateTrigger(string triggerName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateTriggerAsync(string triggerName, Azure.Core.RequestContent requestBody, string ifMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response DeleteTrigger(string triggerName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTriggerAsync(string triggerName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetEventSubscriptionStatus(string triggerName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEventSubscriptionStatusAsync(string triggerName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetTrigger(string triggerName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTriggerAsync(string triggerName, string ifNoneMatch = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetTriggersByWorkspace(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTriggersByWorkspaceAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response StartTrigger(string triggerName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartTriggerAsync(string triggerName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response StopTrigger(string triggerName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopTriggerAsync(string triggerName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response SubscribeTriggerToEvents(string triggerName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SubscribeTriggerToEventsAsync(string triggerName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response UnsubscribeTriggerFromEvents(string triggerName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UnsubscribeTriggerFromEventsAsync(string triggerName, Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class TriggerRunClient
    {
        protected TriggerRunClient() { }
        public TriggerRunClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelTriggerInstance(string triggerName, string runId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelTriggerInstanceAsync(string triggerName, string runId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response QueryTriggerRunsByWorkspace(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> QueryTriggerRunsByWorkspaceAsync(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response RerunTriggerInstance(string triggerName, string runId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RerunTriggerInstanceAsync(string triggerName, string runId, Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class WorkspaceClient
    {
        protected WorkspaceClient() { }
        public WorkspaceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Get(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class WorkspaceGitRepoManagementClient
    {
        protected WorkspaceGitRepoManagementClient() { }
        public WorkspaceGitRepoManagementClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Artifacts.ArtifactsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetGitHubAccessToken(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGitHubAccessTokenAsync(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
    }
}
