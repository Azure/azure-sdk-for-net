namespace Azure.AI.Language.Conversations
{
    public partial class ConversationAnalysisClient
    {
        protected ConversationAnalysisClient() { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AnalyzeConversation(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeConversationAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CancelJob(Azure.WaitUntil waitUntil, System.Guid jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CancelJobAsync(Azure.WaitUntil waitUntil, System.Guid jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response JobStatus(System.Guid jobId, bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> JobStatusAsync(System.Guid jobId, bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> SubmitJob(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> SubmitJobAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ConversationAnalysisClientOptions : Azure.Core.ClientOptions
    {
        public ConversationAnalysisClientOptions(Azure.AI.Language.Conversations.ConversationAnalysisClientOptions.ServiceVersion version = Azure.AI.Language.Conversations.ConversationAnalysisClientOptions.ServiceVersion.V2022_05_15_Preview) { }
        public enum ServiceVersion
        {
            V2022_05_15_Preview = 1,
        }
    }
    public partial class ConversationAnalysisProjectsClient
    {
        protected ConversationAnalysisProjectsClient() { }
        public ConversationAnalysisProjectsClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ConversationAnalysisProjectsClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> CancelTrainingJob(Azure.WaitUntil waitUntil, string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CancelTrainingJobAsync(Azure.WaitUntil waitUntil, string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateProject(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateProjectAsync(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteDeployment(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteDeploymentAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteProject(Azure.WaitUntil waitUntil, string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteProjectAsync(Azure.WaitUntil waitUntil, string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTrainedModel(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTrainedModelAsync(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeployProject(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeployProjectAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Export(Azure.WaitUntil waitUntil, string projectName, string exportedProjectFormat = null, string stringIndexType = "Utf16CodeUnit", string assetKind = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ExportAsync(Azure.WaitUntil waitUntil, string projectName, string exportedProjectFormat = null, string stringIndexType = "Utf16CodeUnit", string assetKind = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeployment(string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentAsync(string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeployments(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsAsync(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeploymentStatus(string projectName, string deploymentName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentStatusAsync(string projectName, string deploymentName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetExportStatus(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportStatusAsync(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetImportStatus(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetImportStatusAsync(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetModelEvaluationResults(string projectName, string trainedModelLabel, string stringIndexType = "Utf16CodeUnit", int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetModelEvaluationResultsAsync(string projectName, string trainedModelLabel, string stringIndexType = "Utf16CodeUnit", int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetModelEvaluationSummary(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetModelEvaluationSummaryAsync(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetProject(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectAsync(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetProjectDeletionStatus(string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectDeletionStatusAsync(string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProjects(int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedLanguages(string projectKind, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedLanguagesAsync(string projectKind, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedPrebuiltEntities(string language = null, string multilingual = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedPrebuiltEntitiesAsync(string language = null, string multilingual = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSwapDeploymentsStatus(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSwapDeploymentsStatusAsync(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTrainedModel(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainedModelAsync(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainedModels(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainedModelsAsync(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingConfigVersions(string projectKind, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingConfigVersionsAsync(string projectKind, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingJobs(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingJobsAsync(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTrainingStatus(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainingStatusAsync(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Import(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string exportedProjectFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ImportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string exportedProjectFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> SwapDeployments(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> SwapDeploymentsAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Train(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> TrainAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ConversationAnalysisClientExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.ConversationAnalysisClient, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions> AddConversationAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.ConversationAnalysisClient, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions> AddConversationAnalysisClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
