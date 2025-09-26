namespace Azure.Analytics.Purview.Workflows
{
    public partial class ApprovalClient
    {
        protected ApprovalClient() { }
        public ApprovalClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ApprovalClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Approve(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ApproveAsync(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Reject(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectAsync(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class AzureAnalyticsPurviewWorkflowsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAnalyticsPurviewWorkflowsContext() { }
        public static Azure.Analytics.Purview.Workflows.AzureAnalyticsPurviewWorkflowsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class PurviewWorkflowServiceClientOptions : Azure.Core.ClientOptions
    {
        public PurviewWorkflowServiceClientOptions(Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions.ServiceVersion version = Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions.ServiceVersion.V2023_10_01_Preview) { }
        public enum ServiceVersion
        {
            V2023_10_01_Preview = 1,
        }
    }
    public partial class TaskStatusClient
    {
        protected TaskStatusClient() { }
        public TaskStatusClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public TaskStatusClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Update(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class UserRequestsClient
    {
        protected UserRequestsClient() { }
        public UserRequestsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public UserRequestsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Submit(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SubmitAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class WorkflowClient
    {
        protected WorkflowClient() { }
        public WorkflowClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public WorkflowClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrReplace(System.Guid workflowId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceAsync(System.Guid workflowId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(System.Guid workflowId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Guid workflowId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetWorkflow(System.Guid workflowId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWorkflowAsync(System.Guid workflowId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response Validate(System.Guid workflowId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidateAsync(System.Guid workflowId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class WorkflowRunClient
    {
        protected WorkflowRunClient() { }
        public WorkflowRunClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public WorkflowRunClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Cancel(System.Guid workflowRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Guid workflowRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetWorkflowRun(System.Guid workflowRunId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWorkflowRunAsync(System.Guid workflowRunId, Azure.RequestContext context) { throw null; }
    }
    public partial class WorkflowRunsClient
    {
        protected WorkflowRunsClient() { }
        public WorkflowRunsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public WorkflowRunsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetWorkflowRuns(string viewMode, string timeWindow, string orderby, System.Collections.Generic.IEnumerable<string> runStatuses, System.Collections.Generic.IEnumerable<string> workflowIds, System.Collections.Generic.IEnumerable<string> requestors, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWorkflowRunsAsync(string viewMode, string timeWindow, string orderby, System.Collections.Generic.IEnumerable<string> runStatuses, System.Collections.Generic.IEnumerable<string> workflowIds, System.Collections.Generic.IEnumerable<string> requestors, int? maxpagesize, Azure.RequestContext context) { throw null; }
    }
    public partial class WorkflowsClient
    {
        protected WorkflowsClient() { }
        public WorkflowsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public WorkflowsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetWorkflows(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWorkflowsAsync(Azure.RequestContext context) { throw null; }
    }
    public partial class WorkflowTaskClient
    {
        protected WorkflowTaskClient() { }
        public WorkflowTaskClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public WorkflowTaskClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetWorkflowTask(System.Guid taskId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWorkflowTaskAsync(System.Guid taskId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response Reassign(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReassignAsync(System.Guid taskId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class WorkflowTasksClient
    {
        protected WorkflowTasksClient() { }
        public WorkflowTasksClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public WorkflowTasksClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetWorkflowTasks(string viewMode, System.Collections.Generic.IEnumerable<string> workflowIds, string timeWindow, int? maxpagesize, string orderby, System.Collections.Generic.IEnumerable<string> taskTypes, System.Collections.Generic.IEnumerable<string> taskStatuses, System.Collections.Generic.IEnumerable<string> requestors, System.Collections.Generic.IEnumerable<string> assignees, string workflowNameKeyword, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWorkflowTasksAsync(string viewMode, System.Collections.Generic.IEnumerable<string> workflowIds, string timeWindow, int? maxpagesize, string orderby, System.Collections.Generic.IEnumerable<string> taskTypes, System.Collections.Generic.IEnumerable<string> taskStatuses, System.Collections.Generic.IEnumerable<string> requestors, System.Collections.Generic.IEnumerable<string> assignees, string workflowNameKeyword, Azure.RequestContext context) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AnalyticsPurviewWorkflowsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.ApprovalClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddApprovalClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.ApprovalClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddApprovalClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.TaskStatusClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddTaskStatusClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.TaskStatusClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddTaskStatusClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.UserRequestsClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddUserRequestsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.UserRequestsClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddUserRequestsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.WorkflowClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddWorkflowClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.WorkflowClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddWorkflowClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.WorkflowRunClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddWorkflowRunClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.WorkflowRunClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddWorkflowRunClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.WorkflowRunsClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddWorkflowRunsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.WorkflowRunsClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddWorkflowRunsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.WorkflowsClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddWorkflowsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.WorkflowsClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddWorkflowsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.WorkflowTaskClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddWorkflowTaskClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.WorkflowTaskClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddWorkflowTaskClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.WorkflowTasksClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddWorkflowTasksClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Workflows.WorkflowTasksClient, Azure.Analytics.Purview.Workflows.PurviewWorkflowServiceClientOptions> AddWorkflowTasksClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
