namespace Azure.Analytics.Purview.Workflows
{
    public partial class PurviewWorkflowServiceClient
    {
        protected PurviewWorkflowServiceClient() { }
        public PurviewWorkflowServiceClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public PurviewWorkflowServiceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response ApproveApprovalTask(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ApproveApprovalTaskAsync(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CancelWorkflowRun(System.Guid workflowRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelWorkflowRunAsync(System.Guid workflowRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrReplaceWorkflow(System.Guid workflowId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceWorkflowAsync(System.Guid workflowId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteWorkflow(System.Guid workflowId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteWorkflowAsync(System.Guid workflowId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetWorkflow(System.Guid workflowId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWorkflowAsync(System.Guid workflowId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetWorkflowRun(System.Guid workflowRunId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWorkflowRunAsync(System.Guid workflowRunId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetWorkflowRuns(string timeWindow, string orderby, System.Collections.Generic.IEnumerable<string> runStatuses, System.Collections.Generic.IEnumerable<string> workflowIds, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWorkflowRunsAsync(string timeWindow, string orderby, System.Collections.Generic.IEnumerable<string> runStatuses, System.Collections.Generic.IEnumerable<string> workflowIds, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetWorkflows(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWorkflowsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetWorkflowTask(System.Guid taskId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWorkflowTaskAsync(System.Guid taskId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetWorkflowTasks(string viewMode, System.Collections.Generic.IEnumerable<string> workflowIds, string timeWindow, int? maxpagesize, string orderby, System.Collections.Generic.IEnumerable<string> taskTypes, System.Collections.Generic.IEnumerable<string> taskStatuses, string workflowNameKeyword, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWorkflowTasksAsync(string viewMode, System.Collections.Generic.IEnumerable<string> workflowIds, string timeWindow, int? maxpagesize, string orderby, System.Collections.Generic.IEnumerable<string> taskTypes, System.Collections.Generic.IEnumerable<string> taskStatuses, string workflowNameKeyword, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response ReassignWorkflowTask(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReassignWorkflowTaskAsync(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RejectApprovalTask(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectApprovalTaskAsync(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SubmitUserRequests(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SubmitUserRequestsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateTaskStatus(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateTaskStatusAsync(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class PurviewWorkflowServiceClientOptions : Azure.Core.ClientOptions
    {
        public PurviewWorkflowServiceClientOptions(Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions.ServiceVersion version = Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions.ServiceVersion.V2022_05_01_Preview) { }
        public enum ServiceVersion
        {
            V2022_05_01_Preview = 1,
        }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AnalyticsPurviewWorkflowsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddPurviewWorkflowServiceClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddPurviewWorkflowServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
