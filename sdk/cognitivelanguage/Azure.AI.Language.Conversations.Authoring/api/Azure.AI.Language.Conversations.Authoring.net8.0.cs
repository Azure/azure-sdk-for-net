namespace Azure.AI.Language.Conversations.Authoring
{
    public partial class ConversationAnalysisAuthoringClient
    {
        protected ConversationAnalysisAuthoringClient() { }
        public ConversationAnalysisAuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ConversationAnalysisAuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Conversations.Authoring.ConversationAnalysisAuthoringClientOptions options) { }
        public ConversationAnalysisAuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ConversationAnalysisAuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.Conversations.Authoring.ConversationAnalysisAuthoringClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetAssignedResourceDeployments(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentsMetadata> GetAssignedResourceDeployments(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAssignedResourceDeploymentsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentsMetadata> GetAssignedResourceDeploymentsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeploymentResources(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.AssignedDeploymentResource> GetDeploymentResources(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentResourcesAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.AssignedDeploymentResource> GetDeploymentResourcesAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeployments(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment> GetDeployments(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeployments GetDeployments(string projectName, string deploymentName) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment> GetDeploymentsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetExportedModels(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel> GetExportedModels(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetExportedModelsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel> GetExportedModelsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Language.Conversations.Authoring.ConversationAuthoringModels GetModels(string projectName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProjects(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata> GetProjects(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjects GetProjects(string projectName) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata> GetProjectsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguage> GetSupportedLanguages(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedLanguages(string projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguage> GetSupportedLanguagesAsync(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedLanguagesAsync(string projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedPrebuiltEntities(int? maxCount, int? skip, int? maxpagesize, string language, string multilingual, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntity> GetSupportedPrebuiltEntities(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), string language = null, string multilingual = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedPrebuiltEntitiesAsync(int? maxCount, int? skip, int? maxpagesize, string language, string multilingual, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntity> GetSupportedPrebuiltEntitiesAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), string language = null, string multilingual = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainedModels(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel> GetTrainedModels(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainedModelsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel> GetTrainedModelsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersion> GetTrainingConfigVersions(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingConfigVersions(string projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersion> GetTrainingConfigVersionsAsync(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingConfigVersionsAsync(string projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingJobs(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.TrainingOperationState> GetTrainingJobs(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingJobsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.TrainingOperationState> GetTrainingJobsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConversationAnalysisAuthoringClientOptions : Azure.Core.ClientOptions
    {
        public ConversationAnalysisAuthoringClientOptions(Azure.AI.Language.Conversations.Authoring.ConversationAnalysisAuthoringClientOptions.ServiceVersion version = Azure.AI.Language.Conversations.Authoring.ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview) { }
        public enum ServiceVersion
        {
            V2023_04_01 = 1,
            V2023_04_15_Preview = 2,
            V2024_11_15_Preview = 3,
        }
    }
    public partial class ConversationAuthoringDeployments
    {
        public readonly string _deploymentName;
        public readonly string _projectName;
        protected ConversationAuthoringDeployments() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation AssignDeploymentResources(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.AssignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation AssignDeploymentResources(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AssignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.AssignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AssignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteDeployment(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteDeployment(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeleteDeploymentFromResources(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.DeleteDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeleteDeploymentFromResources(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentFromResourcesAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.DeleteDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentFromResourcesAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeployProject(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.CreateDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeployProject(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployProjectAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.CreateDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployProjectAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAssignDeploymentResourcesStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesOperationState> GetAssignDeploymentResourcesStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssignDeploymentResourcesStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesOperationState>> GetAssignDeploymentResourcesStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeployment(string projectName, string deploymentName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment> GetDeployment(string projectName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment> GetDeployment(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentAsync(string projectName, string deploymentName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>> GetDeploymentAsync(string projectName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>> GetDeploymentAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeploymentDeleteFromResourcesStatus(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesOperationState> GetDeploymentDeleteFromResourcesStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentDeleteFromResourcesStatusAsync(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesOperationState>> GetDeploymentDeleteFromResourcesStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeploymentStatus(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentOperationState> GetDeploymentStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentStatusAsync(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentOperationState>> GetDeploymentStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSwapDeploymentsStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsOperationState> GetSwapDeploymentsStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSwapDeploymentsStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsOperationState>> GetSwapDeploymentsStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUnassignDeploymentResourcesStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesOperationState> GetUnassignDeploymentResourcesStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUnassignDeploymentResourcesStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesOperationState>> GetUnassignDeploymentResourcesStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation SwapDeployments(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation SwapDeployments(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> SwapDeploymentsAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> SwapDeploymentsAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation UnassignDeploymentResources(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.UnassignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation UnassignDeploymentResources(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UnassignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.UnassignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UnassignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ConversationAuthoringModels
    {
        public readonly string _projectName;
        protected ConversationAuthoringModels() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation CreateOrUpdateExportedModel(Azure.WaitUntil waitUntil, string exportedModelName, Azure.AI.Language.Conversations.Authoring.Models.ExportedModelDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CreateOrUpdateExportedModel(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateOrUpdateExportedModelAsync(Azure.WaitUntil waitUntil, string exportedModelName, Azure.AI.Language.Conversations.Authoring.Models.ExportedModelDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateOrUpdateExportedModelAsync(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteExportedModel(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteExportedModel(Azure.WaitUntil waitUntil, string exportedModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteExportedModelAsync(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteExportedModelAsync(Azure.WaitUntil waitUntil, string exportedModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteTrainedModel(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTrainedModel(string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTrainedModelAsync(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTrainedModelAsync(string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult> EvaluateModel(Azure.WaitUntil waitUntil, string trainedModelLabel, Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> EvaluateModel(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult>> EvaluateModelAsync(Azure.WaitUntil waitUntil, string trainedModelLabel, Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> EvaluateModelAsync(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEvaluationStatus(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.EvaluationOperationState> GetEvaluationStatus(string trainedModelLabel, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEvaluationStatusAsync(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.EvaluationOperationState>> GetEvaluationStatusAsync(string trainedModelLabel, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportedModel(string projectName, string exportedModelName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel> GetExportedModel(string exportedModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportedModelAsync(string projectName, string exportedModelName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel>> GetExportedModelAsync(string exportedModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportedModelJobStatus(string projectName, string exportedModelName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelOperationState> GetExportedModelJobStatus(string exportedModelName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportedModelJobStatusAsync(string projectName, string exportedModelName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelOperationState>> GetExportedModelJobStatusAsync(string exportedModelName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLoadSnapshotStatus(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotOperationState> GetLoadSnapshotStatus(string trainedModelLabel, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLoadSnapshotStatusAsync(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotOperationState>> GetLoadSnapshotStatusAsync(string trainedModelLabel, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEvaluationResult> GetModelEvaluationResults(string trainedModelLabel, Azure.AI.Language.Conversations.Authoring.Models.StringIndexType stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetModelEvaluationResults(string projectName, string trainedModelLabel, string stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEvaluationResult> GetModelEvaluationResultsAsync(string trainedModelLabel, Azure.AI.Language.Conversations.Authoring.Models.StringIndexType stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetModelEvaluationResultsAsync(string projectName, string trainedModelLabel, string stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetModelEvaluationSummary(string projectName, string trainedModelLabel, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.EvaluationSummary> GetModelEvaluationSummary(string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetModelEvaluationSummaryAsync(string projectName, string trainedModelLabel, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.EvaluationSummary>> GetModelEvaluationSummaryAsync(string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTrainedModel(string projectName, string trainedModelLabel, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel> GetTrainedModel(string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainedModelAsync(string projectName, string trainedModelLabel, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel>> GetTrainedModelAsync(string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation LoadSnapshot(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation LoadSnapshot(Azure.WaitUntil waitUntil, string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> LoadSnapshotAsync(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> LoadSnapshotAsync(Azure.WaitUntil waitUntil, string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConversationAuthoringProjects
    {
        public readonly string _projectName;
        protected ConversationAuthoringProjects() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails> AuthorizeProjectCopy(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AuthorizeProjectCopy(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails>> AuthorizeProjectCopyAsync(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AuthorizeProjectCopyAsync(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CancelTrainingJob(Azure.WaitUntil waitUntil, string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult> CancelTrainingJob(Azure.WaitUntil waitUntil, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CancelTrainingJobAsync(Azure.WaitUntil waitUntil, string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>> CancelTrainingJobAsync(Azure.WaitUntil waitUntil, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CopyProject(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CopyProject(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CopyProjectAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CopyProjectAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateProject(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateProjectAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteProject(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteProjectAsync(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.StringIndexType stringIndexType, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat?), string assetKind = null, string trainedModelLabel = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.StringIndexType stringIndexType, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat?), string assetKind = null, string trainedModelLabel = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, string projectName, string stringIndexType, string exportedProjectFormat = null, string assetKind = null, string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.StringIndexType stringIndexType, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat?), string assetKind = null, string trainedModelLabel = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.StringIndexType stringIndexType, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat?), string assetKind = null, string trainedModelLabel = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, string projectName, string stringIndexType, string exportedProjectFormat = null, string assetKind = null, string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCopyProjectStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectOperationState> GetCopyProjectStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCopyProjectStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectOperationState>> GetCopyProjectStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectOperationState> GetExportStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectOperationState>> GetExportStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetImportStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectOperationState> GetImportStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetImportStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectOperationState>> GetImportStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProject(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata> GetProject(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectAsync(string projectName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata>> GetProjectAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProjectDeletionStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionOperationState> GetProjectDeletionStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectDeletionStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionOperationState>> GetProjectDeletionStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTrainingStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.TrainingOperationState> GetTrainingStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainingStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.TrainingOperationState>> GetTrainingStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.ExportedProject exportedProject, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.ExportedProject exportedProject, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string exportedProjectFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.ExportedProject exportedProject, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.ExportedProject exportedProject, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string exportedProjectFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult> Train(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Train(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>> TrainAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> TrainAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
}
namespace Azure.AI.Language.Conversations.Authoring.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeConversationAuthoringCompositionMode : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringCompositionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeConversationAuthoringCompositionMode(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringCompositionMode CombineComponents { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringCompositionMode RequireExactOverlap { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringCompositionMode ReturnLongestOverlap { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringCompositionMode SeparateComponents { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringCompositionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringCompositionMode left, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringCompositionMode right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringCompositionMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringCompositionMode left, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringCompositionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeConversationAuthoringEvaluationKind : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringEvaluationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeConversationAuthoringEvaluationKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringEvaluationKind Manual { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringEvaluationKind Percentage { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringEvaluationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringEvaluationKind left, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringEvaluationKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringEvaluationKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringEvaluationKind left, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringEvaluationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeConversationAuthoringExportedProjectFormat : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeConversationAuthoringExportedProjectFormat(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat Conversation { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat Luis { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat left, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat left, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringExportedProjectFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeConversationAuthoringProjectKind : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeConversationAuthoringProjectKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind Conversation { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind CustomConversationSummarization { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind Orchestration { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind left, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind left, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeConversationAuthoringTrainingMode : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeConversationAuthoringTrainingMode(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode Advanced { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode Standard { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode left, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode left, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnalyzeConversationConfusionMatrixCell : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixCell>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixCell>
    {
        internal AnalyzeConversationConfusionMatrixCell() { }
        public float NormalizedValue { get { throw null; } }
        public float RawValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixCell System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixCell>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixCell>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixCell System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixCell>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixCell>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixCell>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeConversationConfusionMatrixRow : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixRow>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixRow>
    {
        internal AnalyzeConversationConfusionMatrixRow() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixRow System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixRow>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixRow>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixRow System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixRow>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixRow>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixRow>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssignDeploymentResourcesDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignDeploymentResourcesDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignDeploymentResourcesDetails>
    {
        public AssignDeploymentResourcesDetails(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.ResourceMetadata> metadata) { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.ResourceMetadata> Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AssignDeploymentResourcesDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignDeploymentResourcesDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignDeploymentResourcesDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AssignDeploymentResourcesDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignDeploymentResourcesDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignDeploymentResourcesDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignDeploymentResourcesDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssignedDeploymentResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedDeploymentResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedDeploymentResource>
    {
        internal AssignedDeploymentResource() { }
        public Azure.Core.AzureLocation Region { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AssignedDeploymentResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedDeploymentResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedDeploymentResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AssignedDeploymentResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedDeploymentResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedDeploymentResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedDeploymentResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssignedProjectDeploymentMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentMetadata>
    {
        internal AssignedProjectDeploymentMetadata() { }
        public System.DateTimeOffset DeploymentExpiresOn { get { throw null; } }
        public string DeploymentName { get { throw null; } }
        public System.DateTimeOffset LastDeployedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssignedProjectDeploymentsMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentsMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentsMetadata>
    {
        internal AssignedProjectDeploymentsMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentMetadata> DeploymentsMetadata { get { throw null; } }
        public string ProjectName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentsMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentsMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentsMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentsMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentsMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentsMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentsMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ConversationAnalysisAuthoringModelFactory
    {
        public static Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixCell AnalyzeConversationConfusionMatrixCell(float normalizedValue = 0f, float rawValue = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixRow AnalyzeConversationConfusionMatrixRow(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.AssignedDeploymentResource AssignedDeploymentResource(Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.AzureLocation region = default(Azure.Core.AzureLocation)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentMetadata AssignedProjectDeploymentMetadata(string deploymentName = null, System.DateTimeOffset lastDeployedOn = default(System.DateTimeOffset), System.DateTimeOffset deploymentExpiresOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentsMetadata AssignedProjectDeploymentsMetadata(string projectName = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentMetadata> deploymentsMetadata = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedEntity ConversationExportedEntity(string category = null, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringCompositionMode? compositionMode = default(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringCompositionMode?), Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityList entities = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.ExportedPrebuiltEntity> prebuilts = null, Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegex regex = null, System.Collections.Generic.IEnumerable<string> requiredComponents = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedUtterance ConversationExportedUtterance(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.ExportedUtteranceEntityLabel> entities = null, string text = null, string language = null, string intent = null, Azure.AI.Language.Conversations.Authoring.Models.DatasetType? dataset = default(Azure.AI.Language.Conversations.Authoring.Models.DatasetType?)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.CopyProjectOperationState CopyProjectOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.CreateDeploymentDetails CreateDeploymentDetails(string trainedModelLabel = null, System.Collections.Generic.IEnumerable<string> assignedResourceIds = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.CreateProjectDetails CreateProjectDetails(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind projectKind = default(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind), Azure.AI.Language.Conversations.Authoring.Models.ProjectSettings settings = null, string storageInputContainerName = null, string projectName = null, bool? multilingual = default(bool?), string description = null, string language = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesOperationState DeploymentDeleteFromResourcesOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.DeploymentOperationState DeploymentOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.DeploymentResource DeploymentResource(string resourceId = null, string region = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesOperationState DeploymentResourcesOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary EntitiesEvaluationSummary(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixRow> confusionMatrix = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.Models.EntityEvaluationSummary> entities = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.EntityEvaluationSummary EntityEvaluationSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult EvaluationJobResult(Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails evaluationDetails = null, string modelLabel = null, string trainingConfigVersion = null, int percentComplete = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.EvaluationOperationState EvaluationOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null, Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.EvaluationSummary EvaluationSummary(Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary entitiesEvaluation = null, Azure.AI.Language.Conversations.Authoring.Models.IntentsEvaluationSummary intentsEvaluation = null, Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails evaluationOptions = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestrationDetails ExportedConversationOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestration conversationOrchestration = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestration ExportedLuisOrchestration(System.Guid appId = default(System.Guid), string appVersion = null, string slotName = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestrationDetails ExportedLuisOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestration luisOrchestration = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedModelOperationState ExportedModelOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedProject ExportedProject(string projectFileVersion = null, Azure.AI.Language.Conversations.Authoring.Models.StringIndexType stringIndexType = default(Azure.AI.Language.Conversations.Authoring.Models.StringIndexType), Azure.AI.Language.Conversations.Authoring.Models.CreateProjectDetails metadata = null, Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAsset assets = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestrationDetails ExportedQuestionAnsweringOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestration questionAnsweringOrchestration = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel ExportedTrainedModel(string exportedModelName = null, string modelId = null, System.DateTimeOffset lastTrainedOn = default(System.DateTimeOffset), System.DateTimeOffset lastExportedModelOn = default(System.DateTimeOffset), System.DateTimeOffset modelExpiredOn = default(System.DateTimeOffset), string modelTrainingConfigVersion = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportProjectOperationState ExportProjectOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null, string resultUri = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ImportProjectOperationState ImportProjectOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.IntentEvaluationSummary IntentEvaluationSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.IntentsEvaluationSummary IntentsEvaluationSummary(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixRow> confusionMatrix = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.Models.IntentEvaluationSummary> intents = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotOperationState LoadSnapshotOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedIntent OrchestrationExportedIntent(Azure.AI.Language.Conversations.Authoring.Models.ExportedOrchestrationDetails orchestration = null, string category = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedUtterance OrchestrationExportedUtterance(string text = null, string language = null, string intent = null, string dataset = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntity PrebuiltEntity(string category = null, string description = null, string examples = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionOperationState ProjectDeletionOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment ProjectDeployment(string deploymentName = null, string modelId = null, System.DateTimeOffset lastTrainedOn = default(System.DateTimeOffset), System.DateTimeOffset lastDeployedOn = default(System.DateTimeOffset), System.DateTimeOffset deploymentExpiredOn = default(System.DateTimeOffset), string modelTrainingConfigVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResource> assignedResources = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata ProjectMetadata(System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastModifiedOn = default(System.DateTimeOffset), System.DateTimeOffset? lastTrainedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastDeployedOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind projectKind = default(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind), Azure.AI.Language.Conversations.Authoring.Models.ProjectSettings settings = null, string storageInputContainerName = null, string projectName = null, bool? multilingual = default(bool?), string description = null, string language = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel ProjectTrainedModel(string label = null, string modelId = null, System.DateTimeOffset lastTrainedOn = default(System.DateTimeOffset), int lastTrainingDurationInSeconds = 0, System.DateTimeOffset modelExpiredOn = default(System.DateTimeOffset), string modelTrainingConfigVersion = null, bool hasSnapshot = false) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.SubTrainingOperationState SubTrainingOperationState(int percentComplete = 0, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguage SupportedLanguage(string languageName = null, string languageCode = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsOperationState SwapDeploymentsOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersion TrainingConfigVersion(string trainingConfigVersionProperty = null, System.DateTimeOffset modelExpirationDate = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails TrainingJobDetails(string modelLabel = null, string trainingConfigVersion = null, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode trainingMode = default(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode), Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails evaluationOptions = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult TrainingJobResult(string modelLabel = null, string trainingConfigVersion = null, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode? trainingMode = default(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode?), Azure.AI.Language.Conversations.Authoring.Models.SubTrainingOperationState trainingStatus = null, Azure.AI.Language.Conversations.Authoring.Models.SubTrainingOperationState evaluationStatus = null, System.DateTimeOffset? estimatedEndOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.TrainingOperationState TrainingOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null, Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntitiesEvaluationResult UtteranceEntitiesEvaluationResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult> expectedEntities = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult> predictedEntities = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult UtteranceEntityEvaluationResult(string category = null, int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.UtteranceEvaluationResult UtteranceEvaluationResult(string text = null, string language = null, Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntitiesEvaluationResult entitiesResult = null, Azure.AI.Language.Conversations.Authoring.Models.UtteranceIntentsEvaluationResult intentsResult = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.UtteranceIntentsEvaluationResult UtteranceIntentsEvaluationResult(string expectedIntent = null, string predictedIntent = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConversationAuthoringOperationStatus : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConversationAuthoringOperationStatus(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Cancelled { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Cancelling { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Failed { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus NotStarted { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus PartiallyCompleted { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Running { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus left, Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus left, Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConversationExportedEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedEntity>
    {
        public ConversationExportedEntity(string category) { }
        public string Category { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringCompositionMode? CompositionMode { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityList Entities { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.ExportedPrebuiltEntity> Prebuilts { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegex Regex { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredComponents { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationExportedIntent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedIntent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedIntent>
    {
        public ConversationExportedIntent(string category) { }
        public string Category { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedIntent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedIntent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationExportedProjectAsset : Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAsset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAsset>
    {
        public ConversationExportedProjectAsset() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedEntity> Entities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedIntent> Intents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedUtterance> Utterances { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAsset System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAsset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationExportedUtterance : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedUtterance>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedUtterance>
    {
        public ConversationExportedUtterance(string text, string intent) { }
        public Azure.AI.Language.Conversations.Authoring.Models.DatasetType? Dataset { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.ExportedUtteranceEntityLabel> Entities { get { throw null; } }
        public string Intent { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedUtterance System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedUtterance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedUtterance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedUtterance System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedUtterance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedUtterance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedUtterance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CopyProjectDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails>
    {
        public CopyProjectDetails(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind projectKind, string targetProjectName, string accessToken, System.DateTimeOffset expiresAt, string targetResourceId, string targetResourceRegion) { }
        public string AccessToken { get { throw null; } set { } }
        public System.DateTimeOffset ExpiresAt { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind ProjectKind { get { throw null; } set { } }
        public string TargetProjectName { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TargetResourceRegion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CopyProjectOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectOperationState>
    {
        internal CopyProjectOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.CopyProjectOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.CopyProjectOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateDeploymentDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.CreateDeploymentDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CreateDeploymentDetails>
    {
        public CreateDeploymentDetails(string trainedModelLabel) { }
        public System.Collections.Generic.IList<string> AssignedResourceIds { get { throw null; } }
        public string TrainedModelLabel { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.CreateDeploymentDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.CreateDeploymentDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.CreateDeploymentDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.CreateDeploymentDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CreateDeploymentDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CreateDeploymentDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CreateDeploymentDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateProjectDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.CreateProjectDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CreateProjectDetails>
    {
        public CreateProjectDetails(Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind projectKind, string projectName, string language) { }
        public string Description { get { throw null; } set { } }
        public string Language { get { throw null; } }
        public bool? Multilingual { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind ProjectKind { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ProjectSettings Settings { get { throw null; } set { } }
        public string StorageInputContainerName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.CreateProjectDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.CreateProjectDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.CreateProjectDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.CreateProjectDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CreateProjectDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CreateProjectDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CreateProjectDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatasetType : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.DatasetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatasetType(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.DatasetType Test { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.DatasetType Train { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.DatasetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.DatasetType left, Azure.AI.Language.Conversations.Authoring.Models.DatasetType right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.DatasetType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.DatasetType left, Azure.AI.Language.Conversations.Authoring.Models.DatasetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeleteDeploymentDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeleteDeploymentDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeleteDeploymentDetails>
    {
        public DeleteDeploymentDetails() { }
        public System.Collections.Generic.IList<string> AssignedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeleteDeploymentDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeleteDeploymentDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeleteDeploymentDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeleteDeploymentDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeleteDeploymentDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeleteDeploymentDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeleteDeploymentDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentDeleteFromResourcesOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesOperationState>
    {
        internal DeploymentDeleteFromResourcesOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentOperationState>
    {
        internal DeploymentOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeploymentOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeploymentOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResource>
    {
        internal DeploymentResource() { }
        public string Region { get { throw null; } }
        public string ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeploymentResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeploymentResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentResourcesOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesOperationState>
    {
        internal DeploymentResourcesOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitiesEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary>
    {
        internal EntitiesEvaluationSummary() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixRow> ConfusionMatrix { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.Models.EntityEvaluationSummary> Entities { get { throw null; } }
        public float MacroF1 { get { throw null; } }
        public float MacroPrecision { get { throw null; } }
        public float MacroRecall { get { throw null; } }
        public float MicroF1 { get { throw null; } }
        public float MicroPrecision { get { throw null; } }
        public float MicroRecall { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EntityEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EntityEvaluationSummary>
    {
        internal EntityEvaluationSummary() { }
        public double F1 { get { throw null; } }
        public int FalseNegativeCount { get { throw null; } }
        public int FalsePositiveCount { get { throw null; } }
        public double Precision { get { throw null; } }
        public double Recall { get { throw null; } }
        public int TrueNegativeCount { get { throw null; } }
        public int TruePositiveCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.EntityEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EntityEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EntityEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.EntityEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EntityEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EntityEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EntityEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails>
    {
        public EvaluationDetails() { }
        public Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringEvaluationKind? Kind { get { throw null; } set { } }
        public int? TestingSplitPercentage { get { throw null; } set { } }
        public int? TrainingSplitPercentage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationJobResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult>
    {
        internal EvaluationJobResult() { }
        public Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails EvaluationDetails { get { throw null; } }
        public string ModelLabel { get { throw null; } }
        public int PercentComplete { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationOperationState>
    {
        internal EvaluationOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult Result { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.EvaluationOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.EvaluationOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationSummary>
    {
        internal EvaluationSummary() { }
        public Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary EntitiesEvaluation { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails EvaluationOptions { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.IntentsEvaluationSummary IntentsEvaluation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.EvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.EvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedConversationOrchestration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestration>
    {
        public ExportedConversationOrchestration(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public string ProjectName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestration System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedConversationOrchestrationDetails : Azure.AI.Language.Conversations.Authoring.Models.ExportedOrchestrationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestrationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestrationDetails>
    {
        public ExportedConversationOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestration conversationOrchestration) { }
        public Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestration ConversationOrchestration { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestrationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestrationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestrationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestrationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestrationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestrationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestrationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedEntityList : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityList>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityList>
    {
        public ExportedEntityList() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntitySublist> Sublists { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityList System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityList System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedEntityListSynonym : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityListSynonym>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityListSynonym>
    {
        public ExportedEntityListSynonym() { }
        public string Language { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityListSynonym System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityListSynonym>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityListSynonym>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityListSynonym System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityListSynonym>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityListSynonym>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityListSynonym>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedEntityRegex : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegex>
    {
        public ExportedEntityRegex() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegexExpression> Expressions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegex System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedEntityRegexExpression : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegexExpression>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegexExpression>
    {
        public ExportedEntityRegexExpression() { }
        public string Language { get { throw null; } set { } }
        public string RegexKey { get { throw null; } set { } }
        public string RegexPattern { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegexExpression System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegexExpression>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegexExpression>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegexExpression System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegexExpression>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegexExpression>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegexExpression>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedEntitySublist : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntitySublist>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntitySublist>
    {
        public ExportedEntitySublist() { }
        public string ListKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityListSynonym> Synonyms { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedEntitySublist System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntitySublist>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntitySublist>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedEntitySublist System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntitySublist>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntitySublist>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedEntitySublist>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedLuisOrchestration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestration>
    {
        public ExportedLuisOrchestration(System.Guid appId) { }
        public System.Guid AppId { get { throw null; } }
        public string AppVersion { get { throw null; } set { } }
        public string SlotName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestration System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedLuisOrchestrationDetails : Azure.AI.Language.Conversations.Authoring.Models.ExportedOrchestrationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestrationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestrationDetails>
    {
        public ExportedLuisOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestration luisOrchestration) { }
        public Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestration LuisOrchestration { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestrationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestrationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestrationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestrationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestrationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestrationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestrationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedModelDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelDetails>
    {
        public ExportedModelDetails(string trainedModelLabel) { }
        public string TrainedModelLabel { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedModelDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedModelDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedModelOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelOperationState>
    {
        internal ExportedModelOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedModelOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedModelOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ExportedOrchestrationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedOrchestrationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedOrchestrationDetails>
    {
        protected ExportedOrchestrationDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedOrchestrationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedOrchestrationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedOrchestrationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedOrchestrationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedOrchestrationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedOrchestrationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedOrchestrationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedPrebuiltEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedPrebuiltEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedPrebuiltEntity>
    {
        public ExportedPrebuiltEntity(string category) { }
        public string Category { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedPrebuiltEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedPrebuiltEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedPrebuiltEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedPrebuiltEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedPrebuiltEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedPrebuiltEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedPrebuiltEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedProject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProject>
    {
        public ExportedProject(string projectFileVersion, Azure.AI.Language.Conversations.Authoring.Models.StringIndexType stringIndexType, Azure.AI.Language.Conversations.Authoring.Models.CreateProjectDetails metadata) { }
        public Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAsset Assets { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.Models.CreateProjectDetails Metadata { get { throw null; } }
        public string ProjectFileVersion { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.StringIndexType StringIndexType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedProject System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedProject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ExportedProjectAsset : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAsset>
    {
        protected ExportedProjectAsset() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAsset System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAsset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedQuestionAnsweringOrchestration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestration>
    {
        public ExportedQuestionAnsweringOrchestration(string projectName) { }
        public string ProjectName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestration System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedQuestionAnsweringOrchestrationDetails : Azure.AI.Language.Conversations.Authoring.Models.ExportedOrchestrationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestrationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestrationDetails>
    {
        public ExportedQuestionAnsweringOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestration questionAnsweringOrchestration) { }
        public Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestration QuestionAnsweringOrchestration { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestrationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestrationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestrationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestrationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestrationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestrationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestrationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedTrainedModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel>
    {
        internal ExportedTrainedModel() { }
        public string ExportedModelName { get { throw null; } }
        public System.DateTimeOffset LastExportedModelOn { get { throw null; } }
        public System.DateTimeOffset LastTrainedOn { get { throw null; } }
        public System.DateTimeOffset ModelExpiredOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ModelTrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedUtteranceEntityLabel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedUtteranceEntityLabel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedUtteranceEntityLabel>
    {
        public ExportedUtteranceEntityLabel(string category, int offset, int length) { }
        public string Category { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedUtteranceEntityLabel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedUtteranceEntityLabel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedUtteranceEntityLabel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedUtteranceEntityLabel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedUtteranceEntityLabel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedUtteranceEntityLabel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedUtteranceEntityLabel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportProjectOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectOperationState>
    {
        internal ExportProjectOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public string ResultUri { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportProjectOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportProjectOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportProjectOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectOperationState>
    {
        internal ImportProjectOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ImportProjectOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ImportProjectOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntentEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.IntentEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.IntentEvaluationSummary>
    {
        internal IntentEvaluationSummary() { }
        public double F1 { get { throw null; } }
        public int FalseNegativeCount { get { throw null; } }
        public int FalsePositiveCount { get { throw null; } }
        public double Precision { get { throw null; } }
        public double Recall { get { throw null; } }
        public int TrueNegativeCount { get { throw null; } }
        public int TruePositiveCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.IntentEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.IntentEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.IntentEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.IntentEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.IntentEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.IntentEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.IntentEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntentsEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.IntentsEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.IntentsEvaluationSummary>
    {
        internal IntentsEvaluationSummary() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationConfusionMatrixRow> ConfusionMatrix { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.Models.IntentEvaluationSummary> Intents { get { throw null; } }
        public float MacroF1 { get { throw null; } }
        public float MacroPrecision { get { throw null; } }
        public float MacroRecall { get { throw null; } }
        public float MicroF1 { get { throw null; } }
        public float MicroPrecision { get { throw null; } }
        public float MicroRecall { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.IntentsEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.IntentsEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.IntentsEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.IntentsEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.IntentsEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.IntentsEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.IntentsEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadSnapshotOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotOperationState>
    {
        internal LoadSnapshotOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrchestrationExportedIntent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedIntent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedIntent>
    {
        public OrchestrationExportedIntent(string category) { }
        public string Category { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ExportedOrchestrationDetails Orchestration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedIntent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedIntent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrchestrationExportedProjectAsset : Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAsset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAsset>
    {
        public OrchestrationExportedProjectAsset() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedIntent> Intents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedUtterance> Utterances { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAsset System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAsset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrchestrationExportedUtterance : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedUtterance>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedUtterance>
    {
        public OrchestrationExportedUtterance(string text, string intent) { }
        public string Dataset { get { throw null; } set { } }
        public string Intent { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedUtterance System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedUtterance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedUtterance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedUtterance System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedUtterance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedUtterance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedUtterance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrebuiltEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntity>
    {
        internal PrebuiltEntity() { }
        public string Category { get { throw null; } }
        public string Description { get { throw null; } }
        public string Examples { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectDeletionOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionOperationState>
    {
        internal ProjectDeletionOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectDeployment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>
    {
        internal ProjectDeployment() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResource> AssignedResources { get { throw null; } }
        public System.DateTimeOffset DeploymentExpiredOn { get { throw null; } }
        public string DeploymentName { get { throw null; } }
        public System.DateTimeOffset LastDeployedOn { get { throw null; } }
        public System.DateTimeOffset LastTrainedOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ModelTrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata>
    {
        internal ProjectMetadata() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string Language { get { throw null; } }
        public System.DateTimeOffset? LastDeployedOn { get { throw null; } }
        public System.DateTimeOffset LastModifiedOn { get { throw null; } }
        public System.DateTimeOffset? LastTrainedOn { get { throw null; } }
        public bool? Multilingual { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringProjectKind ProjectKind { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ProjectSettings Settings { get { throw null; } }
        public string StorageInputContainerName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectSettings : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectSettings>
    {
        public ProjectSettings(float confidenceThreshold) { }
        public float ConfidenceThreshold { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ProjectSettings System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ProjectSettings System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectTrainedModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel>
    {
        internal ProjectTrainedModel() { }
        public bool HasSnapshot { get { throw null; } }
        public string Label { get { throw null; } }
        public System.DateTimeOffset LastTrainedOn { get { throw null; } }
        public int LastTrainingDurationInSeconds { get { throw null; } }
        public System.DateTimeOffset ModelExpiredOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ModelTrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ResourceMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ResourceMetadata>
    {
        public ResourceMetadata(string azureResourceId, string customDomain, string region) { }
        public string AzureResourceId { get { throw null; } }
        public string CustomDomain { get { throw null; } }
        public string Region { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ResourceMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ResourceMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ResourceMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ResourceMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ResourceMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ResourceMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ResourceMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StringIndexType : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.StringIndexType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StringIndexType(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.StringIndexType Utf16CodeUnit { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.StringIndexType Utf32CodeUnit { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.StringIndexType Utf8CodeUnit { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.StringIndexType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.StringIndexType left, Azure.AI.Language.Conversations.Authoring.Models.StringIndexType right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.StringIndexType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.StringIndexType left, Azure.AI.Language.Conversations.Authoring.Models.StringIndexType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubTrainingOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SubTrainingOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SubTrainingOperationState>
    {
        internal SubTrainingOperationState() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public int PercentComplete { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.SubTrainingOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SubTrainingOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SubTrainingOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.SubTrainingOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SubTrainingOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SubTrainingOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SubTrainingOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguage>
    {
        internal SupportedLanguage() { }
        public string LanguageCode { get { throw null; } }
        public string LanguageName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SwapDeploymentsDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsDetails>
    {
        public SwapDeploymentsDetails(string firstDeploymentName, string secondDeploymentName) { }
        public string FirstDeploymentName { get { throw null; } }
        public string SecondDeploymentName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SwapDeploymentsOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsOperationState>
    {
        internal SwapDeploymentsOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrainingConfigVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersion>
    {
        internal TrainingConfigVersion() { }
        public System.DateTimeOffset ModelExpirationDate { get { throw null; } }
        public string TrainingConfigVersionProperty { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrainingJobDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails>
    {
        public TrainingJobDetails(string modelLabel, Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode trainingMode) { }
        public Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails EvaluationOptions { get { throw null; } set { } }
        public string ModelLabel { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode TrainingMode { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrainingJobResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>
    {
        internal TrainingJobResult() { }
        public System.DateTimeOffset? EstimatedEndOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.SubTrainingOperationState EvaluationStatus { get { throw null; } }
        public string ModelLabel { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.AnalyzeConversationAuthoringTrainingMode? TrainingMode { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.SubTrainingOperationState TrainingStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrainingOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingOperationState>
    {
        internal TrainingOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult Result { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.TrainingOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.TrainingOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UnassignDeploymentResourcesDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.UnassignDeploymentResourcesDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UnassignDeploymentResourcesDetails>
    {
        public UnassignDeploymentResourcesDetails(System.Collections.Generic.IEnumerable<string> assignedResourceIds) { }
        public System.Collections.Generic.IList<string> AssignedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.UnassignDeploymentResourcesDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.UnassignDeploymentResourcesDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.UnassignDeploymentResourcesDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.UnassignDeploymentResourcesDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UnassignDeploymentResourcesDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UnassignDeploymentResourcesDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UnassignDeploymentResourcesDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UtteranceEntitiesEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntitiesEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntitiesEvaluationResult>
    {
        internal UtteranceEntitiesEvaluationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult> ExpectedEntities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult> PredictedEntities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntitiesEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntitiesEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntitiesEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntitiesEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntitiesEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntitiesEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntitiesEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UtteranceEntityEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult>
    {
        internal UtteranceEntityEvaluationResult() { }
        public string Category { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UtteranceEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEvaluationResult>
    {
        internal UtteranceEvaluationResult() { }
        public Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntitiesEvaluationResult EntitiesResult { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.UtteranceIntentsEvaluationResult IntentsResult { get { throw null; } }
        public string Language { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.UtteranceEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.UtteranceEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UtteranceIntentsEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceIntentsEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceIntentsEvaluationResult>
    {
        internal UtteranceIntentsEvaluationResult() { }
        public string ExpectedIntent { get { throw null; } }
        public string PredictedIntent { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.UtteranceIntentsEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceIntentsEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceIntentsEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.UtteranceIntentsEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceIntentsEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceIntentsEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.UtteranceIntentsEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ConversationsAuthoringClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.Authoring.ConversationAnalysisAuthoringClient, Azure.AI.Language.Conversations.Authoring.ConversationAnalysisAuthoringClientOptions> AddConversationAnalysisAuthoringClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.Authoring.ConversationAnalysisAuthoringClient, Azure.AI.Language.Conversations.Authoring.ConversationAnalysisAuthoringClientOptions> AddConversationAnalysisAuthoringClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.Authoring.ConversationAnalysisAuthoringClient, Azure.AI.Language.Conversations.Authoring.ConversationAnalysisAuthoringClientOptions> AddConversationAnalysisAuthoringClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
