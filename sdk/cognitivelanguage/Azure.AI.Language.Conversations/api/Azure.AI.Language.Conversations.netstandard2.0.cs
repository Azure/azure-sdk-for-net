namespace Azure.AI.Language.Conversations
{
    public partial class ConversationAnalysisClient
    {
        protected ConversationAnalysisClient() { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Conversations.ConversationsClientOptions options) { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.Conversations.ConversationsClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AnalyzeConversation(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> AnalyzeConversation(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeConversationAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> AnalyzeConversationAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation CancelAnalyzeConversationJob(Azure.WaitUntil waitUntil, System.Guid jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CancelAnalyzeConversationJobAsync(Azure.WaitUntil waitUntil, System.Guid jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAnalyzeConversationJobStatus(System.Guid jobId, bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAnalyzeConversationJobStatusAsync(System.Guid jobId, bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConversationsAudience : System.IEquatable<Azure.AI.Language.Conversations.ConversationsAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConversationsAudience(string value) { throw null; }
        public static Azure.AI.Language.Conversations.ConversationsAudience AzureChina { get { throw null; } }
        public static Azure.AI.Language.Conversations.ConversationsAudience AzureGovernment { get { throw null; } }
        public static Azure.AI.Language.Conversations.ConversationsAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.ConversationsAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.ConversationsAudience left, Azure.AI.Language.Conversations.ConversationsAudience right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.ConversationsAudience (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.ConversationsAudience left, Azure.AI.Language.Conversations.ConversationsAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConversationsClientOptions : Azure.Core.ClientOptions
    {
        public ConversationsClientOptions(Azure.AI.Language.Conversations.ConversationsClientOptions.ServiceVersion version = Azure.AI.Language.Conversations.ConversationsClientOptions.ServiceVersion.V2022_10_01_Preview) { }
        public Azure.AI.Language.Conversations.ConversationsAudience? Audience { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2022_05_01 = 1,
            V2022_05_15_Preview = 2,
            V2022_10_01_Preview = 3,
        }
    }
}
namespace Azure.AI.Language.Conversations.Authoring
{
    public partial class ConversationAuthoringClient
    {
        protected ConversationAuthoringClient() { }
        public ConversationAuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ConversationAuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Conversations.ConversationsClientOptions options) { }
        public ConversationAuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ConversationAuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.Conversations.ConversationsClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation AssignDeploymentResources(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AssignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CancelTrainingJob(Azure.WaitUntil waitUntil, string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CancelTrainingJobAsync(Azure.WaitUntil waitUntil, string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateProject(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateProjectAsync(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteDeployment(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteDeploymentAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteDeploymentFromResources(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentFromResourcesAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteProject(Azure.WaitUntil waitUntil, string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteProjectAsync(Azure.WaitUntil waitUntil, string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTrainedModel(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTrainedModelAsync(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeployProject(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeployProjectAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Operation<System.BinaryData> ExportProject(Azure.WaitUntil waitUntil, string projectName, string exportedProjectFormat, string assetKind, string stringIndexType, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation<System.BinaryData> ExportProject(Azure.WaitUntil waitUntil, string projectName, string exportedProjectFormat = null, string assetKind = null, string stringIndexType = "Utf16CodeUnit", string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ExportProjectAsync(Azure.WaitUntil waitUntil, string projectName, string exportedProjectFormat, string assetKind, string stringIndexType, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ExportProjectAsync(Azure.WaitUntil waitUntil, string projectName, string exportedProjectFormat = null, string assetKind = null, string stringIndexType = "Utf16CodeUnit", string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAssignDeploymentResourcesStatus(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssignDeploymentResourcesStatusAsync(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAssignedResourceDeployments(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAssignedResourceDeploymentsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeployment(string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentAsync(string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeploymentDeleteFromResourcesStatus(string projectName, string deploymentName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentDeleteFromResourcesStatusAsync(string projectName, string deploymentName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeploymentJobStatus(string projectName, string deploymentName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentJobStatusAsync(string projectName, string deploymentName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeploymentResources(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentResourcesAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeployments(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsAsync(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetExportProjectJobStatus(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportProjectJobStatusAsync(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetImportProjectJobStatus(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetImportProjectJobStatusAsync(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLoadSnapshotStatus(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLoadSnapshotStatusAsync(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetModelEvaluationResults(string projectName, string trainedModelLabel, string stringIndexType = "Utf16CodeUnit", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetModelEvaluationResultsAsync(string projectName, string trainedModelLabel, string stringIndexType = "Utf16CodeUnit", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetModelEvaluationSummary(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetModelEvaluationSummaryAsync(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetProject(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectAsync(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetProjectDeletionJobStatus(string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectDeletionJobStatusAsync(string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProjects(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedLanguages(string projectKind, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedLanguagesAsync(string projectKind, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedPrebuiltEntities(string language = null, bool? multilingual = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedPrebuiltEntitiesAsync(string language = null, bool? multilingual = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSwapDeploymentsJobStatus(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSwapDeploymentsJobStatusAsync(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTrainedModel(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainedModelAsync(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainedModels(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainedModelsAsync(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingConfigVersions(string projectKind, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingConfigVersionsAsync(string projectKind, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingJobs(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingJobsAsync(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTrainingJobStatus(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainingJobStatusAsync(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetUnassignDeploymentResourcesStatus(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUnassignDeploymentResourcesStatusAsync(string projectName, string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> ImportProject(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string exportedProjectFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ImportProjectAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string exportedProjectFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation LoadSnapshot(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> LoadSnapshotAsync(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> SwapDeployments(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> SwapDeploymentsAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Train(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> TrainAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation UnassignDeploymentResources(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UnassignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ConversationAnalysisClientExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.ConversationAnalysisClient, Azure.AI.Language.Conversations.ConversationsClientOptions> AddConversationAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.ConversationAnalysisClient, Azure.AI.Language.Conversations.ConversationsClientOptions> AddConversationAnalysisClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringClient, Azure.AI.Language.Conversations.ConversationsClientOptions> AddConversationAuthoringClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringClient, Azure.AI.Language.Conversations.ConversationsClientOptions> AddConversationAuthoringClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
