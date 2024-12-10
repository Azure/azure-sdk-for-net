namespace Azure.AI.Language.Conversations.Authoring
{
    public partial class AnalyzeConversationAuthoring
    {
        protected AnalyzeConversationAuthoring() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation AssignDeploymentResources(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.AssignDeploymentResourcesDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation AssignDeploymentResources(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AssignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.AssignDeploymentResourcesDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AssignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CancelTrainingJob(Azure.WaitUntil waitUntil, string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult> CancelTrainingJob(Azure.WaitUntil waitUntil, string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CancelTrainingJobAsync(Azure.WaitUntil waitUntil, string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>> CancelTrainingJobAsync(Azure.WaitUntil waitUntil, string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CopyProject(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CopyProject(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CopyProjectAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CopyProjectAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails> CopyProjectAuthorization(string projectName, Azure.AI.Language.Conversations.Authoring.Models.ProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CopyProjectAuthorization(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectDetails>> CopyProjectAuthorizationAsync(string projectName, Azure.AI.Language.Conversations.Authoring.Models.ProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CopyProjectAuthorizationAsync(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation CreateOrUpdateExportedModel(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.AI.Language.Conversations.Authoring.Models.ExportedModelDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CreateOrUpdateExportedModel(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateOrUpdateExportedModelAsync(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.AI.Language.Conversations.Authoring.Models.ExportedModelDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateOrUpdateExportedModelAsync(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateProject(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateProjectAsync(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteDeployment(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteDeploymentFromResources(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.AI.Language.Conversations.Authoring.Models.DeleteDeploymentDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeleteDeploymentFromResources(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentFromResourcesAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.AI.Language.Conversations.Authoring.Models.DeleteDeploymentDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentFromResourcesAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteExportedModel(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteExportedModelAsync(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteProject(Azure.WaitUntil waitUntil, string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteProjectAsync(Azure.WaitUntil waitUntil, string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTrainedModel(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTrainedModelAsync(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeployProject(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.AI.Language.Conversations.Authoring.Models.CreateDeploymentDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeployProject(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployProjectAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.AI.Language.Conversations.Authoring.Models.CreateDeploymentDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployProjectAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult> EvaluateModel(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> EvaluateModel(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult>> EvaluateModelAsync(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> EvaluateModelAsync(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.StringIndexType stringIndexType, Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat?), string assetKind = null, string trainedModelLabel = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, string projectName, string stringIndexType, string exportedProjectFormat = null, string assetKind = null, string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.StringIndexType stringIndexType, Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat?), string assetKind = null, string trainedModelLabel = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, string projectName, string stringIndexType, string exportedProjectFormat = null, string assetKind = null, string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAssignDeploymentResourcesStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesJobState> GetAssignDeploymentResourcesStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssignDeploymentResourcesStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesJobState>> GetAssignDeploymentResourcesStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAssignedResourceDeployments(int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.AssignedResourceDeploymentsMetadata> GetAssignedResourceDeployments(int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssignedResourceDeploymentsAsync(int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.AssignedResourceDeploymentsMetadata>> GetAssignedResourceDeploymentsAsync(int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCopyProjectStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectJobState> GetCopyProjectStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCopyProjectStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectJobState>> GetCopyProjectStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeployment(string projectName, string deploymentName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment> GetDeployment(string projectName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentAsync(string projectName, string deploymentName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>> GetDeploymentAsync(string projectName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeploymentDeleteFromResourcesStatus(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesJobState> GetDeploymentDeleteFromResourcesStatus(string projectName, string deploymentName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentDeleteFromResourcesStatusAsync(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesJobState>> GetDeploymentDeleteFromResourcesStatusAsync(string projectName, string deploymentName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeploymentResources(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.AssignedDeploymentResource> GetDeploymentResources(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentResourcesAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.AssignedDeploymentResource> GetDeploymentResourcesAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeployments(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment> GetDeployments(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment> GetDeploymentsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeploymentStatus(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentJobState> GetDeploymentStatus(string projectName, string deploymentName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentStatusAsync(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentJobState>> GetDeploymentStatusAsync(string projectName, string deploymentName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEvaluationStatus(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobState> GetEvaluationStatus(string projectName, string trainedModelLabel, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEvaluationStatusAsync(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobState>> GetEvaluationStatusAsync(string projectName, string trainedModelLabel, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportedModel(string projectName, string exportedModelName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel> GetExportedModel(string projectName, string exportedModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportedModelAsync(string projectName, string exportedModelName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel>> GetExportedModelAsync(string projectName, string exportedModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportedModelJobStatus(string projectName, string exportedModelName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelJobState> GetExportedModelJobStatus(string projectName, string exportedModelName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportedModelJobStatusAsync(string projectName, string exportedModelName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelJobState>> GetExportedModelJobStatusAsync(string projectName, string exportedModelName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetExportedModels(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel> GetExportedModels(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetExportedModelsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel> GetExportedModelsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectJobState> GetExportStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectJobState>> GetExportStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetImportStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectJobState> GetImportStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetImportStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectJobState>> GetImportStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLoadSnapshotStatus(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotJobState> GetLoadSnapshotStatus(string projectName, string trainedModelLabel, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLoadSnapshotStatusAsync(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotJobState>> GetLoadSnapshotStatusAsync(string projectName, string trainedModelLabel, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEvaluationResult> GetModelEvaluationResults(string projectName, string trainedModelLabel, Azure.AI.Language.Conversations.Authoring.Models.StringIndexType stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetModelEvaluationResults(string projectName, string trainedModelLabel, string stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEvaluationResult> GetModelEvaluationResultsAsync(string projectName, string trainedModelLabel, Azure.AI.Language.Conversations.Authoring.Models.StringIndexType stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetModelEvaluationResultsAsync(string projectName, string trainedModelLabel, string stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetModelEvaluationSummary(string projectName, string trainedModelLabel, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.EvaluationSummary> GetModelEvaluationSummary(string projectName, string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetModelEvaluationSummaryAsync(string projectName, string trainedModelLabel, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.EvaluationSummary>> GetModelEvaluationSummaryAsync(string projectName, string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProject(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata> GetProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectAsync(string projectName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata>> GetProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProjectDeletionStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionJobState> GetProjectDeletionStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectDeletionStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionJobState>> GetProjectDeletionStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProjects(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata> GetProjects(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata> GetProjectsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguages> GetSupportedLanguages(Azure.AI.Language.Conversations.Authoring.Models.ProjectKind projectKind, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSupportedLanguages(string projectKind, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguages>> GetSupportedLanguagesAsync(Azure.AI.Language.Conversations.Authoring.Models.ProjectKind projectKind, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSupportedLanguagesAsync(string projectKind, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSupportedPrebuiltEntities(string language, string multilingual, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntities> GetSupportedPrebuiltEntities(string language = null, string multilingual = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSupportedPrebuiltEntitiesAsync(string language, string multilingual, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntities>> GetSupportedPrebuiltEntitiesAsync(string language = null, string multilingual = null, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSwapDeploymentsStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsJobState> GetSwapDeploymentsStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSwapDeploymentsStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsJobState>> GetSwapDeploymentsStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTrainedModel(string projectName, string trainedModelLabel, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel> GetTrainedModel(string projectName, string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainedModelAsync(string projectName, string trainedModelLabel, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel>> GetTrainedModelAsync(string projectName, string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainedModels(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel> GetTrainedModels(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainedModelsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel> GetTrainedModelsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersions> GetTrainingConfigVersions(Azure.AI.Language.Conversations.Authoring.Models.ProjectKind projectKind, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTrainingConfigVersions(string projectKind, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersions>> GetTrainingConfigVersionsAsync(Azure.AI.Language.Conversations.Authoring.Models.ProjectKind projectKind, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainingConfigVersionsAsync(string projectKind, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingJobs(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobState> GetTrainingJobs(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingJobsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobState> GetTrainingJobsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTrainingStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobState> GetTrainingStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainingStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobState>> GetTrainingStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUnassignDeploymentResourcesStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesJobState> GetUnassignDeploymentResourcesStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUnassignDeploymentResourcesStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesJobState>> GetUnassignDeploymentResourcesStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.ExportedProject body, Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string exportedProjectFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.ExportedProject body, Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string exportedProjectFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation LoadSnapshot(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> LoadSnapshotAsync(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation SwapDeployments(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation SwapDeployments(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> SwapDeploymentsAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> SwapDeploymentsAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult> Train(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Train(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>> TrainAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> TrainAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation UnassignDeploymentResources(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.UnassignDeploymentResourcesDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation UnassignDeploymentResources(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UnassignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Conversations.Authoring.Models.UnassignDeploymentResourcesDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UnassignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class AuthoringClient
    {
        protected AuthoringClient() { }
        public AuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public AuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Conversations.Authoring.AuthoringClientOptions options) { }
        public AuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public AuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.Conversations.Authoring.AuthoringClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoring GetAnalyzeConversationAuthoringClient(string apiVersion = "2024-11-15-preview") { throw null; }
    }
    public partial class AuthoringClientOptions : Azure.Core.ClientOptions
    {
        public AuthoringClientOptions(Azure.AI.Language.Conversations.Authoring.AuthoringClientOptions.ServiceVersion version = Azure.AI.Language.Conversations.Authoring.AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview) { }
        public enum ServiceVersion
        {
            V2023_04_01 = 1,
            V2023_04_15_Preview = 2,
            V2024_11_15_Preview = 3,
        }
    }
    public static partial class ConversationsAuthoringClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.Authoring.AuthoringClient, Azure.AI.Language.Conversations.Authoring.AuthoringClientOptions> AddAuthoringClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.Authoring.AuthoringClient, Azure.AI.Language.Conversations.Authoring.AuthoringClientOptions> AddAuthoringClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.Authoring.AuthoringClient, Azure.AI.Language.Conversations.Authoring.AuthoringClientOptions> AddAuthoringClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
    public static partial class ConversationsAuthoringModelFactory
    {
        public static Azure.AI.Language.Conversations.Authoring.Models.AssignedDeploymentResource AssignedDeploymentResource(string azureResourceId = null, string region = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentMetadata AssignedProjectDeploymentMetadata(string deploymentName = null, System.DateTimeOffset lastDeployedDateTime = default(System.DateTimeOffset), System.DateTimeOffset deploymentExpirationDate = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentsMetadata AssignedProjectDeploymentsMetadata(string projectName = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentMetadata> deploymentsMetadata = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.AssignedResourceDeploymentsMetadata AssignedResourceDeploymentsMetadata(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentsMetadata> value = null, string nextLink = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError AuthoringConversationsError(Azure.AI.Language.Conversations.Authoring.Models.ErrorCode code = default(Azure.AI.Language.Conversations.Authoring.Models.ErrorCode), string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> details = null, Azure.AI.Language.Conversations.Authoring.Models.InnerErrorModel innererror = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning AuthoringConversationsWarning(string code = null, string message = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrix ConfusionMatrix(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixCell ConfusionMatrixCell(float normalizedValue = 0f, float rawValue = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixRow ConfusionMatrixRow(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedEntity ConversationExportedEntity(string category = null, Azure.AI.Language.Conversations.Authoring.Models.CompositionSetting? compositionSetting = default(Azure.AI.Language.Conversations.Authoring.Models.CompositionSetting?), Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityList list = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.ExportedPrebuiltEntity> prebuilts = null, Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityRegex regex = null, System.Collections.Generic.IEnumerable<string> requiredComponents = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedUtterance ConversationExportedUtterance(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.ExportedUtteranceEntityLabel> entities = null, string text = null, string language = null, string intent = null, string dataset = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.CopyProjectJobState CopyProjectJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.JobStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.CreateDeploymentDetails CreateDeploymentDetails(string trainedModelLabel = null, System.Collections.Generic.IEnumerable<string> assignedResourceIds = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.CreateProjectDetails CreateProjectDetails(Azure.AI.Language.Conversations.Authoring.Models.ProjectKind projectKind = default(Azure.AI.Language.Conversations.Authoring.Models.ProjectKind), Azure.AI.Language.Conversations.Authoring.Models.ProjectSettings settings = null, string storageInputContainerName = null, string projectName = null, bool? multilingual = default(bool?), string description = null, string language = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesJobState DeploymentDeleteFromResourcesJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.JobStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.DeploymentJobState DeploymentJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.JobStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.DeploymentResource DeploymentResource(string resourceId = null, string region = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesJobState DeploymentResourcesJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.JobStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary EntitiesEvaluationSummary(Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrix confusionMatrix = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.Models.EntityEvaluationSummary> entities = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.EntityEvaluationSummary EntityEvaluationSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult EvaluationJobResult(Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails evaluationOptions = null, string modelLabel = null, string trainingConfigVersion = null, int percentComplete = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobState EvaluationJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.JobStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> errors = null, Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.EvaluationSummary EvaluationSummary(Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary entitiesEvaluation = null, Azure.AI.Language.Conversations.Authoring.Models.IntentsEvaluationSummary intentsEvaluation = null, Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails evaluationOptions = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestrationDetails ExportedConversationOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.Models.ExportedConversationOrchestration conversationOrchestration = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestration ExportedLuisOrchestration(System.Guid appId = default(System.Guid), string appVersion = null, string slotName = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestrationDetails ExportedLuisOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.Models.ExportedLuisOrchestration luisOrchestration = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedModelJobState ExportedModelJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.JobStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedProject ExportedProject(string projectFileVersion = null, Azure.AI.Language.Conversations.Authoring.Models.StringIndexType stringIndexType = default(Azure.AI.Language.Conversations.Authoring.Models.StringIndexType), Azure.AI.Language.Conversations.Authoring.Models.CreateProjectDetails metadata = null, Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAssets assets = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestrationDetails ExportedQuestionAnsweringOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.Models.ExportedQuestionAnsweringOrchestration questionAnsweringOrchestration = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedTrainedModel ExportedTrainedModel(string exportedModelName = null, string modelId = null, System.DateTimeOffset lastTrainedDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastExportedModelDateTime = default(System.DateTimeOffset), System.DateTimeOffset modelExpirationDate = default(System.DateTimeOffset), string modelTrainingConfigVersion = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportProjectJobState ExportProjectJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.JobStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> errors = null, string resultUrl = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ImportProjectJobState ImportProjectJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.JobStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.InnerErrorModel InnerErrorModel(Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode code = default(Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode), string message = null, System.Collections.Generic.IReadOnlyDictionary<string, string> details = null, string target = null, Azure.AI.Language.Conversations.Authoring.Models.InnerErrorModel innererror = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.IntentEvaluationSummary IntentEvaluationSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.IntentsEvaluationSummary IntentsEvaluationSummary(Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrix confusionMatrix = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.Models.IntentEvaluationSummary> intents = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotJobState LoadSnapshotJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.JobStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedIntent OrchestrationExportedIntent(Azure.AI.Language.Conversations.Authoring.Models.ExportedOrchestrationDetails orchestration = null, string category = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedUtterance OrchestrationExportedUtterance(string text = null, string language = null, string intent = null, string dataset = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntities PrebuiltEntities(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntity> value = null, string nextLink = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntity PrebuiltEntity(string category = null, string description = null, string examples = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionJobState ProjectDeletionJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.JobStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment ProjectDeployment(string deploymentName = null, string modelId = null, System.DateTimeOffset lastTrainedDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastDeployedDateTime = default(System.DateTimeOffset), System.DateTimeOffset deploymentExpirationDate = default(System.DateTimeOffset), string modelTrainingConfigVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResource> assignedResources = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata ProjectMetadata(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastModifiedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? lastTrainedDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastDeployedDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.ProjectKind projectKind = default(Azure.AI.Language.Conversations.Authoring.Models.ProjectKind), Azure.AI.Language.Conversations.Authoring.Models.ProjectSettings settings = null, string storageInputContainerName = null, string projectName = null, bool? multilingual = default(bool?), string description = null, string language = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ProjectTrainedModel ProjectTrainedModel(string label = null, string modelId = null, System.DateTimeOffset lastTrainedDateTime = default(System.DateTimeOffset), int lastTrainingDurationInSeconds = 0, System.DateTimeOffset modelExpirationDate = default(System.DateTimeOffset), string modelTrainingConfigVersion = null, bool hasSnapshot = false) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.SubTrainingJobState SubTrainingJobState(int percentComplete = 0, System.DateTimeOffset? startDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? endDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.JobStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.JobStatus)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguage SupportedLanguage(string languageName = null, string languageCode = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguages SupportedLanguages(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguage> value = null, string nextLink = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsJobState SwapDeploymentsJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.JobStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersion TrainingConfigVersion(string trainingConfigVersionProperty = null, System.DateTimeOffset modelExpirationDate = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersions TrainingConfigVersions(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersion> value = null, string nextLink = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails TrainingJobDetails(string modelLabel = null, string trainingConfigVersion = null, Azure.AI.Language.Conversations.Authoring.Models.TrainingMode trainingMode = default(Azure.AI.Language.Conversations.Authoring.Models.TrainingMode), Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails evaluationOptions = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult TrainingJobResult(string modelLabel = null, string trainingConfigVersion = null, Azure.AI.Language.Conversations.Authoring.Models.TrainingMode? trainingMode = default(Azure.AI.Language.Conversations.Authoring.Models.TrainingMode?), Azure.AI.Language.Conversations.Authoring.Models.SubTrainingJobState trainingStatus = null, Azure.AI.Language.Conversations.Authoring.Models.SubTrainingJobState evaluationStatus = null, System.DateTimeOffset? estimatedEndDateTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.TrainingJobState TrainingJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.Models.JobStatus status = default(Azure.AI.Language.Conversations.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> errors = null, Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntitiesEvaluationResult UtteranceEntitiesEvaluationResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult> expectedEntities = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult> predictedEntities = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntityEvaluationResult UtteranceEntityEvaluationResult(string category = null, int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.UtteranceEvaluationResult UtteranceEvaluationResult(string text = null, string language = null, Azure.AI.Language.Conversations.Authoring.Models.UtteranceEntitiesEvaluationResult entitiesResult = null, Azure.AI.Language.Conversations.Authoring.Models.UtteranceIntentsEvaluationResult intentsResult = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.UtteranceIntentsEvaluationResult UtteranceIntentsEvaluationResult(string expectedIntent = null, string predictedIntent = null) { throw null; }
    }
}
namespace Azure.AI.Language.Conversations.Authoring.Models
{
    public partial class AssignDeploymentResourcesDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignDeploymentResourcesDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignDeploymentResourcesDetails>
    {
        public AssignDeploymentResourcesDetails(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.Models.ResourceMetadata> resourcesMetadata) { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.ResourceMetadata> ResourcesMetadata { get { throw null; } }
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
        public string AzureResourceId { get { throw null; } }
        public string Region { get { throw null; } }
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
        public System.DateTimeOffset DeploymentExpirationDate { get { throw null; } }
        public string DeploymentName { get { throw null; } }
        public System.DateTimeOffset LastDeployedDateTime { get { throw null; } }
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
    public partial class AssignedResourceDeploymentsMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedResourceDeploymentsMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedResourceDeploymentsMetadata>
    {
        internal AssignedResourceDeploymentsMetadata() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AssignedProjectDeploymentsMetadata> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AssignedResourceDeploymentsMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedResourceDeploymentsMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedResourceDeploymentsMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AssignedResourceDeploymentsMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedResourceDeploymentsMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedResourceDeploymentsMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AssignedResourceDeploymentsMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthoringConversationsError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError>
    {
        internal AuthoringConversationsError() { }
        public Azure.AI.Language.Conversations.Authoring.Models.ErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> Details { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.InnerErrorModel Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthoringConversationsWarning : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning>
    {
        internal AuthoringConversationsWarning() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CompositionSetting : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.CompositionSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CompositionSetting(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.CompositionSetting CombineComponents { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.CompositionSetting RequireExactOverlap { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.CompositionSetting ReturnLongestOverlap { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.CompositionSetting SeparateComponents { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.CompositionSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.CompositionSetting left, Azure.AI.Language.Conversations.Authoring.Models.CompositionSetting right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.CompositionSetting (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.CompositionSetting left, Azure.AI.Language.Conversations.Authoring.Models.CompositionSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfusionMatrix : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrix>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrix>
    {
        internal ConfusionMatrix() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrix System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrix>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrix>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrix System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrix>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrix>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrix>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfusionMatrixCell : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixCell>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixCell>
    {
        internal ConfusionMatrixCell() { }
        public float NormalizedValue { get { throw null; } }
        public float RawValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixCell System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixCell>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixCell>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixCell System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixCell>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixCell>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixCell>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfusionMatrixRow : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixRow>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixRow>
    {
        internal ConfusionMatrixRow() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixRow System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixRow>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixRow>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixRow System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixRow>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixRow>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrixRow>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationExportedEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedEntity>
    {
        public ConversationExportedEntity(string category) { }
        public string Category { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.CompositionSetting? CompositionSetting { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.Models.ExportedEntityList List { get { throw null; } set { } }
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
    public partial class ConversationExportedProjectAssets : Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAssets, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAssets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAssets>
    {
        public ConversationExportedProjectAssets() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedEntity> Entities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedIntent> Intents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedUtterance> Utterances { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAssets System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAssets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAssets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAssets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAssets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAssets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedProjectAssets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationExportedUtterance : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedUtterance>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ConversationExportedUtterance>
    {
        public ConversationExportedUtterance(string text, string intent) { }
        public string Dataset { get { throw null; } set { } }
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
        public CopyProjectDetails(Azure.AI.Language.Conversations.Authoring.Models.ProjectKind projectKind, string targetProjectName, string accessToken, System.DateTimeOffset expiresAt, string targetResourceId, string targetResourceRegion) { }
        public string AccessToken { get { throw null; } set { } }
        public System.DateTimeOffset ExpiresAt { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.Models.ProjectKind ProjectKind { get { throw null; } set { } }
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
    public partial class CopyProjectJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectJobState>
    {
        internal CopyProjectJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.CopyProjectJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.CopyProjectJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.CopyProjectJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public CreateProjectDetails(Azure.AI.Language.Conversations.Authoring.Models.ProjectKind projectKind, string projectName, string language) { }
        public string Description { get { throw null; } set { } }
        public string Language { get { throw null; } }
        public bool? Multilingual { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.Models.ProjectKind ProjectKind { get { throw null; } }
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
    public partial class DeploymentDeleteFromResourcesJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesJobState>
    {
        internal DeploymentDeleteFromResourcesJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentDeleteFromResourcesJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentJobState>
    {
        internal DeploymentJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeploymentJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeploymentJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DeploymentResourcesJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesJobState>
    {
        internal DeploymentResourcesJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResourcesJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitiesEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EntitiesEvaluationSummary>
    {
        internal EntitiesEvaluationSummary() { }
        public Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrix ConfusionMatrix { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ErrorCode : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.ErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ErrorCode(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode AzureCognitiveSearchIndexLimitReached { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode AzureCognitiveSearchIndexNotFound { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode AzureCognitiveSearchNotFound { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode AzureCognitiveSearchThrottling { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode Conflict { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode Forbidden { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode InternalServerError { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode InvalidArgument { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode NotFound { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode OperationNotFound { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode ProjectNotFound { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode QuotaExceeded { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode ServiceUnavailable { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode Timeout { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode TooManyRequests { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode Unauthorized { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ErrorCode Warning { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.ErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.ErrorCode left, Azure.AI.Language.Conversations.Authoring.Models.ErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.ErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.ErrorCode left, Azure.AI.Language.Conversations.Authoring.Models.ErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvaluationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails>
    {
        public EvaluationDetails() { }
        public Azure.AI.Language.Conversations.Authoring.Models.EvaluationKind? Kind { get { throw null; } set { } }
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
        public Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails EvaluationOptions { get { throw null; } }
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
    public partial class EvaluationJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobState>
    {
        internal EvaluationJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobResult Result { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.EvaluationJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluationKind : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.EvaluationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluationKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.EvaluationKind Manual { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.EvaluationKind Percentage { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.EvaluationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.EvaluationKind left, Azure.AI.Language.Conversations.Authoring.Models.EvaluationKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.EvaluationKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.EvaluationKind left, Azure.AI.Language.Conversations.Authoring.Models.EvaluationKind right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ExportedModelJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelJobState>
    {
        internal ExportedModelJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedModelJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedModelJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedModelJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAssets Assets { get { throw null; } set { } }
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
    public abstract partial class ExportedProjectAssets : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAssets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAssets>
    {
        protected ExportedProjectAssets() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAssets System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAssets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAssets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAssets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAssets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAssets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAssets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportedProjectFormat : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportedProjectFormat(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat Conversation { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat Luis { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat left, Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat left, Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectFormat right) { throw null; }
        public override string ToString() { throw null; }
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
        public System.DateTimeOffset LastExportedModelDateTime { get { throw null; } }
        public System.DateTimeOffset LastTrainedDateTime { get { throw null; } }
        public System.DateTimeOffset ModelExpirationDate { get { throw null; } }
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
    public partial class ExportProjectJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectJobState>
    {
        internal ExportProjectJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public string ResultUrl { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportProjectJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ExportProjectJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ExportProjectJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportProjectJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectJobState>
    {
        internal ImportProjectJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ImportProjectJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ImportProjectJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ImportProjectJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InnerErrorCode : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InnerErrorCode(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode AzureCognitiveSearchNotFound { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode AzureCognitiveSearchThrottling { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode EmptyRequest { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode ExtractionFailure { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode InvalidCountryHint { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode InvalidDocument { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode InvalidDocumentBatch { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode InvalidParameterValue { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode InvalidRequestBodyFormat { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode KnowledgeBaseNotFound { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode MissingInputDocuments { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode ModelVersionIncorrect { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode UnsupportedLanguageCode { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode left, Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode left, Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InnerErrorModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.InnerErrorModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.InnerErrorModel>
    {
        internal InnerErrorModel() { }
        public Azure.AI.Language.Conversations.Authoring.Models.InnerErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Details { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.InnerErrorModel Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.InnerErrorModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.InnerErrorModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.InnerErrorModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.InnerErrorModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.InnerErrorModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.InnerErrorModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.InnerErrorModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.AI.Language.Conversations.Authoring.Models.ConfusionMatrix ConfusionMatrix { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.JobStatus Cancelled { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.JobStatus Cancelling { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.JobStatus Failed { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.JobStatus NotStarted { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.JobStatus PartiallyCompleted { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.JobStatus Running { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.JobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.JobStatus left, Azure.AI.Language.Conversations.Authoring.Models.JobStatus right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.JobStatus left, Azure.AI.Language.Conversations.Authoring.Models.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadSnapshotJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotJobState>
    {
        internal LoadSnapshotJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.LoadSnapshotJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class OrchestrationExportedProjectAssets : Azure.AI.Language.Conversations.Authoring.Models.ExportedProjectAssets, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAssets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAssets>
    {
        public OrchestrationExportedProjectAssets() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedIntent> Intents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedUtterance> Utterances { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAssets System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAssets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAssets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAssets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAssets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAssets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.OrchestrationExportedProjectAssets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PrebuiltEntities : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntities>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntities>
    {
        internal PrebuiltEntities() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntity> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntities System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntities System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.PrebuiltEntities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ProjectDeletionJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionJobState>
    {
        internal ProjectDeletionJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeletionJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectDeployment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>
    {
        internal ProjectDeployment() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.DeploymentResource> AssignedResources { get { throw null; } }
        public System.DateTimeOffset DeploymentExpirationDate { get { throw null; } }
        public string DeploymentName { get { throw null; } }
        public System.DateTimeOffset LastDeployedDateTime { get { throw null; } }
        public System.DateTimeOffset LastTrainedDateTime { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ModelTrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProjectKind : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.ProjectKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProjectKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.ProjectKind Conversation { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ProjectKind CustomConversationSummarization { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.ProjectKind Orchestration { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.ProjectKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.ProjectKind left, Azure.AI.Language.Conversations.Authoring.Models.ProjectKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.ProjectKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.ProjectKind left, Azure.AI.Language.Conversations.Authoring.Models.ProjectKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProjectMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.ProjectMetadata>
    {
        internal ProjectMetadata() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public string Description { get { throw null; } }
        public string Language { get { throw null; } }
        public System.DateTimeOffset? LastDeployedDateTime { get { throw null; } }
        public System.DateTimeOffset LastModifiedDateTime { get { throw null; } }
        public System.DateTimeOffset? LastTrainedDateTime { get { throw null; } }
        public bool? Multilingual { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.ProjectKind ProjectKind { get { throw null; } }
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
        public System.DateTimeOffset LastTrainedDateTime { get { throw null; } }
        public int LastTrainingDurationInSeconds { get { throw null; } }
        public System.DateTimeOffset ModelExpirationDate { get { throw null; } }
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
    public partial class SubTrainingJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SubTrainingJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SubTrainingJobState>
    {
        internal SubTrainingJobState() { }
        public System.DateTimeOffset? EndDateTime { get { throw null; } }
        public int PercentComplete { get { throw null; } }
        public System.DateTimeOffset? StartDateTime { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.JobStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.SubTrainingJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SubTrainingJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SubTrainingJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.SubTrainingJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SubTrainingJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SubTrainingJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SubTrainingJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SupportedLanguages : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguages>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguages>
    {
        internal SupportedLanguages() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguage> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguages System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguages>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguages>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguages System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguages>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguages>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SupportedLanguages>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SwapDeploymentsJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsJobState>
    {
        internal SwapDeploymentsJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.SwapDeploymentsJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class TrainingConfigVersions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersions>
    {
        internal TrainingConfigVersions() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersion> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersions System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingConfigVersions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrainingJobDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobDetails>
    {
        public TrainingJobDetails(string modelLabel, Azure.AI.Language.Conversations.Authoring.Models.TrainingMode trainingMode) { }
        public Azure.AI.Language.Conversations.Authoring.Models.EvaluationDetails EvaluationOptions { get { throw null; } set { } }
        public string ModelLabel { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.Models.TrainingMode TrainingMode { get { throw null; } }
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
        public System.DateTimeOffset? EstimatedEndDateTime { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.SubTrainingJobState EvaluationStatus { get { throw null; } }
        public string ModelLabel { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.TrainingMode? TrainingMode { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.SubTrainingJobState TrainingStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrainingJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobState>
    {
        internal TrainingJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.TrainingJobResult Result { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.Models.AuthoringConversationsWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.TrainingJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.Models.TrainingJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.Models.TrainingJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrainingMode : System.IEquatable<Azure.AI.Language.Conversations.Authoring.Models.TrainingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrainingMode(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.Models.TrainingMode Advanced { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.Models.TrainingMode Standard { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.Models.TrainingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.Models.TrainingMode left, Azure.AI.Language.Conversations.Authoring.Models.TrainingMode right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.Models.TrainingMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.Models.TrainingMode left, Azure.AI.Language.Conversations.Authoring.Models.TrainingMode right) { throw null; }
        public override string ToString() { throw null; }
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
