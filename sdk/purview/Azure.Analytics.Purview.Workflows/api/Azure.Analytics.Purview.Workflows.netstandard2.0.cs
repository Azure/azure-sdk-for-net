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
        public virtual Azure.Response ClaimDsarTaskRequest(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ClaimDsarTaskRequestAsync(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrReplaceWorkflow(System.Guid workflowId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceWorkflowAsync(System.Guid workflowId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteWorkflow(System.Guid workflowId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteWorkflowAsync(System.Guid workflowId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetWorkflow(System.Guid workflowId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWorkflowAsync(System.Guid workflowId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetWorkflowRun(System.Guid workflowRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWorkflowRunAsync(System.Guid workflowRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetWorkflowRuns(string timeWindow = null, string orderby = null, System.Collections.Generic.IEnumerable<string> runStatuses = null, System.Collections.Generic.IEnumerable<string> userRequestIds = null, System.Collections.Generic.IEnumerable<string> workflowIds = null, int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWorkflowRunsAsync(string timeWindow = null, string orderby = null, System.Collections.Generic.IEnumerable<string> runStatuses = null, System.Collections.Generic.IEnumerable<string> userRequestIds = null, System.Collections.Generic.IEnumerable<string> workflowIds = null, int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetWorkflows(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWorkflowsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetWorkflowTask(System.Guid taskId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWorkflowTaskAsync(System.Guid taskId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetWorkflowTasks(string viewMode = null, System.Collections.Generic.IEnumerable<string> workflowIds = null, string timeWindow = null, int? maxpagesize = default(int?), string orderby = null, System.Collections.Generic.IEnumerable<string> taskTypes = null, System.Collections.Generic.IEnumerable<string> taskStatuses = null, string workflowNameKeyword = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWorkflowTasksAsync(string viewMode = null, System.Collections.Generic.IEnumerable<string> workflowIds = null, string timeWindow = null, int? maxpagesize = default(int?), string orderby = null, System.Collections.Generic.IEnumerable<string> taskTypes = null, System.Collections.Generic.IEnumerable<string> taskStatuses = null, string workflowNameKeyword = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ReassignWorkflowTask(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReassignWorkflowTaskAsync(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RejectApprovalTask(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectApprovalTaskAsync(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ReleaseDsarTaskRequest(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReleaseDsarTaskRequestAsync(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SubmitUserRequests(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SubmitUserRequestsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateTaskRequest(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateTaskRequestAsync(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
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
