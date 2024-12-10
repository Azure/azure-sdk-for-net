namespace Azure.AI.Language.Text.Authoring
{
    public partial class AuthoringClient
    {
        protected AuthoringClient() { }
        public AuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public AuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Text.Authoring.AuthoringClientOptions options) { }
        public AuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public AuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.Text.Authoring.AuthoringClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Language.Text.Authoring.TextAnalysisAuthoring GetTextAnalysisAuthoringClient(string apiVersion = "2024-11-15-preview") { throw null; }
    }
    public partial class AuthoringClientOptions : Azure.Core.ClientOptions
    {
        public AuthoringClientOptions(Azure.AI.Language.Text.Authoring.AuthoringClientOptions.ServiceVersion version = Azure.AI.Language.Text.Authoring.AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview) { }
        public enum ServiceVersion
        {
            V2023_04_01 = 1,
            V2023_04_15_Preview = 2,
            V2024_11_15_Preview = 3,
        }
    }
    public partial class TextAnalysisAuthoring
    {
        protected TextAnalysisAuthoring() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation AssignDeploymentResources(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation AssignDeploymentResources(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AssignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AssignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CancelTrainingJob(Azure.WaitUntil waitUntil, string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Text.Authoring.Models.TrainingJobResult> CancelTrainingJob(Azure.WaitUntil waitUntil, string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CancelTrainingJobAsync(Azure.WaitUntil waitUntil, string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Text.Authoring.Models.TrainingJobResult>> CancelTrainingJobAsync(Azure.WaitUntil waitUntil, string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CopyProject(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Text.Authoring.Models.CopyProjectDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CopyProject(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CopyProjectAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Text.Authoring.Models.CopyProjectDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CopyProjectAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.CopyProjectDetails> CopyProjectAuthorization(string projectName, Azure.AI.Language.Text.Authoring.Models.ProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CopyProjectAuthorization(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.CopyProjectDetails>> CopyProjectAuthorizationAsync(string projectName, Azure.AI.Language.Text.Authoring.Models.ProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CopyProjectAuthorizationAsync(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation CreateOrUpdateExportedModel(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.AI.Language.Text.Authoring.Models.ExportedModelDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CreateOrUpdateExportedModel(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateOrUpdateExportedModelAsync(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.AI.Language.Text.Authoring.Models.ExportedModelDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateOrUpdateExportedModelAsync(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateProject(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateProjectAsync(string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteDeployment(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteDeploymentFromResources(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.AI.Language.Text.Authoring.Models.DeleteDeploymentDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeleteDeploymentFromResources(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentFromResourcesAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.AI.Language.Text.Authoring.Models.DeleteDeploymentDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentFromResourcesAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteExportedModel(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteExportedModelAsync(Azure.WaitUntil waitUntil, string projectName, string exportedModelName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteProject(Azure.WaitUntil waitUntil, string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteProjectAsync(Azure.WaitUntil waitUntil, string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTrainedModel(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTrainedModelAsync(string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeployProject(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.AI.Language.Text.Authoring.Models.CreateDeploymentDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeployProject(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployProjectAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.AI.Language.Text.Authoring.Models.CreateDeploymentDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployProjectAsync(Azure.WaitUntil waitUntil, string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Text.Authoring.Models.EvaluationJobResult> EvaluateModel(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.AI.Language.Text.Authoring.Models.EvaluationDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> EvaluateModel(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Text.Authoring.Models.EvaluationJobResult>> EvaluateModelAsync(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.AI.Language.Text.Authoring.Models.EvaluationDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> EvaluateModelAsync(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Text.Authoring.Models.StringIndexType stringIndexType, string assetKind = null, string trainedModelLabel = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, string projectName, string stringIndexType, string assetKind = null, string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Text.Authoring.Models.StringIndexType stringIndexType, string assetKind = null, string trainedModelLabel = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, string projectName, string stringIndexType, string assetKind = null, string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAssignDeploymentResourcesStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesJobState> GetAssignDeploymentResourcesStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssignDeploymentResourcesStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesJobState>> GetAssignDeploymentResourcesStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAssignedResourceDeployments(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentsMetadata> GetAssignedResourceDeployments(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAssignedResourceDeploymentsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentsMetadata> GetAssignedResourceDeploymentsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCopyProjectStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.CopyProjectJobState> GetCopyProjectStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCopyProjectStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.CopyProjectJobState>> GetCopyProjectStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeployment(string projectName, string deploymentName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.ProjectDeployment> GetDeployment(string projectName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentAsync(string projectName, string deploymentName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.ProjectDeployment>> GetDeploymentAsync(string projectName, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeploymentDeleteFromResourcesStatus(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.DeploymentDeleteFromResourcesJobState> GetDeploymentDeleteFromResourcesStatus(string projectName, string deploymentName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentDeleteFromResourcesStatusAsync(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.DeploymentDeleteFromResourcesJobState>> GetDeploymentDeleteFromResourcesStatusAsync(string projectName, string deploymentName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeploymentResources(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.Models.AssignedDeploymentResource> GetDeploymentResources(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentResourcesAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.Models.AssignedDeploymentResource> GetDeploymentResourcesAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeployments(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.Models.ProjectDeployment> GetDeployments(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.Models.ProjectDeployment> GetDeploymentsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeploymentStatus(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.DeploymentJobState> GetDeploymentStatus(string projectName, string deploymentName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentStatusAsync(string projectName, string deploymentName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.DeploymentJobState>> GetDeploymentStatusAsync(string projectName, string deploymentName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEvaluationStatus(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.EvaluationJobState> GetEvaluationStatus(string projectName, string trainedModelLabel, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEvaluationStatusAsync(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.EvaluationJobState>> GetEvaluationStatusAsync(string projectName, string trainedModelLabel, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportedModel(string projectName, string exportedModelName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.ExportedTrainedModel> GetExportedModel(string projectName, string exportedModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportedModelAsync(string projectName, string exportedModelName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.ExportedTrainedModel>> GetExportedModelAsync(string projectName, string exportedModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportedModelJobStatus(string projectName, string exportedModelName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.ExportedModelJobState> GetExportedModelJobStatus(string projectName, string exportedModelName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportedModelJobStatusAsync(string projectName, string exportedModelName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.ExportedModelJobState>> GetExportedModelJobStatusAsync(string projectName, string exportedModelName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportedModelManifest(string projectName, string exportedModelName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.ExportedModelManifest> GetExportedModelManifest(string projectName, string exportedModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportedModelManifestAsync(string projectName, string exportedModelName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.ExportedModelManifest>> GetExportedModelManifestAsync(string projectName, string exportedModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetExportedModels(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.Models.ExportedTrainedModel> GetExportedModels(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetExportedModelsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.Models.ExportedTrainedModel> GetExportedModelsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.ExportProjectJobState> GetExportStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.ExportProjectJobState>> GetExportStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetImportStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.ImportProjectJobState> GetImportStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetImportStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.ImportProjectJobState>> GetImportStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLoadSnapshotStatus(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.LoadSnapshotJobState> GetLoadSnapshotStatus(string projectName, string trainedModelLabel, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLoadSnapshotStatusAsync(string projectName, string trainedModelLabel, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.LoadSnapshotJobState>> GetLoadSnapshotStatusAsync(string projectName, string trainedModelLabel, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult> GetModelEvaluationResults(string projectName, string trainedModelLabel, Azure.AI.Language.Text.Authoring.Models.StringIndexType stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetModelEvaluationResults(string projectName, string trainedModelLabel, string stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult> GetModelEvaluationResultsAsync(string projectName, string trainedModelLabel, Azure.AI.Language.Text.Authoring.Models.StringIndexType stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetModelEvaluationResultsAsync(string projectName, string trainedModelLabel, string stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetModelEvaluationSummary(string projectName, string trainedModelLabel, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.EvaluationSummary> GetModelEvaluationSummary(string projectName, string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetModelEvaluationSummaryAsync(string projectName, string trainedModelLabel, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.EvaluationSummary>> GetModelEvaluationSummaryAsync(string projectName, string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProject(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.ProjectMetadata> GetProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectAsync(string projectName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.ProjectMetadata>> GetProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProjectDeletionStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.ProjectDeletionJobState> GetProjectDeletionStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectDeletionStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.ProjectDeletionJobState>> GetProjectDeletionStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProjects(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.Models.ProjectMetadata> GetProjects(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.Models.ProjectMetadata> GetProjectsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.Models.SupportedLanguage> GetSupportedLanguages(Azure.AI.Language.Text.Authoring.Models.ProjectKind? projectKind = default(Azure.AI.Language.Text.Authoring.Models.ProjectKind?), int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedLanguages(string projectKind, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.Models.SupportedLanguage> GetSupportedLanguagesAsync(Azure.AI.Language.Text.Authoring.Models.ProjectKind? projectKind = default(Azure.AI.Language.Text.Authoring.Models.ProjectKind?), int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedLanguagesAsync(string projectKind, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedPrebuiltEntities(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.Models.PrebuiltEntity> GetSupportedPrebuiltEntities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedPrebuiltEntitiesAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.Models.PrebuiltEntity> GetSupportedPrebuiltEntitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSwapDeploymentsStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsJobState> GetSwapDeploymentsStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSwapDeploymentsStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsJobState>> GetSwapDeploymentsStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTrainedModel(string projectName, string trainedModelLabel, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.ProjectTrainedModel> GetTrainedModel(string projectName, string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainedModelAsync(string projectName, string trainedModelLabel, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.ProjectTrainedModel>> GetTrainedModelAsync(string projectName, string trainedModelLabel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainedModels(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.Models.ProjectTrainedModel> GetTrainedModels(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainedModelsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.Models.ProjectTrainedModel> GetTrainedModelsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.Models.TrainingConfigVersion> GetTrainingConfigVersions(Azure.AI.Language.Text.Authoring.Models.ProjectKind? projectKind = default(Azure.AI.Language.Text.Authoring.Models.ProjectKind?), int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingConfigVersions(string projectKind, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.Models.TrainingConfigVersion> GetTrainingConfigVersionsAsync(Azure.AI.Language.Text.Authoring.Models.ProjectKind? projectKind = default(Azure.AI.Language.Text.Authoring.Models.ProjectKind?), int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingConfigVersionsAsync(string projectKind, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingJobs(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.Models.TrainingJobState> GetTrainingJobs(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingJobsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.Models.TrainingJobState> GetTrainingJobsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTrainingStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.TrainingJobState> GetTrainingStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainingStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.TrainingJobState>> GetTrainingStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUnassignDeploymentResourcesStatus(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesJobState> GetUnassignDeploymentResourcesStatus(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUnassignDeploymentResourcesStatusAsync(string projectName, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesJobState>> GetUnassignDeploymentResourcesStatusAsync(string projectName, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Text.Authoring.Models.ExportedProject body, string format = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string format = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Text.Authoring.Models.ExportedProject body, string format = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, string format = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation LoadSnapshot(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> LoadSnapshotAsync(Azure.WaitUntil waitUntil, string projectName, string trainedModelLabel, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation SwapDeployments(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation SwapDeployments(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> SwapDeploymentsAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> SwapDeploymentsAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Text.Authoring.Models.TrainingJobResult> Train(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Text.Authoring.Models.TrainingJobDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Train(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Text.Authoring.Models.TrainingJobResult>> TrainAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Text.Authoring.Models.TrainingJobDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> TrainAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation UnassignDeploymentResources(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation UnassignDeploymentResources(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UnassignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesDetails body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UnassignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public static partial class TextAuthoringClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Text.Authoring.AuthoringClient, Azure.AI.Language.Text.Authoring.AuthoringClientOptions> AddAuthoringClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Text.Authoring.AuthoringClient, Azure.AI.Language.Text.Authoring.AuthoringClientOptions> AddAuthoringClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Text.Authoring.AuthoringClient, Azure.AI.Language.Text.Authoring.AuthoringClientOptions> AddAuthoringClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
    public static partial class TextAuthoringModelFactory
    {
        public static Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesJobState AssignDeploymentResourcesJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.Models.JobStatus status = default(Azure.AI.Language.Text.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.AssignedDeploymentResource AssignedDeploymentResource(string azureResourceId = null, string region = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentMetadata AssignedProjectDeploymentMetadata(string deploymentName = null, System.DateTimeOffset lastDeployedDateTime = default(System.DateTimeOffset), System.DateTimeOffset deploymentExpirationDate = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentsMetadata AssignedProjectDeploymentsMetadata(string projectName = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentMetadata> deploymentsMetadata = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix ConfusionMatrix(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixCell ConfusionMatrixCell(float normalizedValue = 0f, float rawValue = 0f) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixRow ConfusionMatrixRow(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.CopyProjectJobState CopyProjectJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.Models.JobStatus status = default(Azure.AI.Language.Text.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.CreateDeploymentDetails CreateDeploymentDetails(string trainedModelLabel = null, System.Collections.Generic.IEnumerable<string> assignedResourceIds = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.CreateProjectDetails CreateProjectDetails(Azure.AI.Language.Text.Authoring.Models.ProjectKind projectKind = default(Azure.AI.Language.Text.Authoring.Models.ProjectKind), string storageInputContainerName = null, Azure.AI.Language.Text.Authoring.Models.ProjectSettings settings = null, string projectName = null, bool? multilingual = default(bool?), string description = null, string language = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionDocumentEvaluationResult CustomEntityRecognitionDocumentEvaluationResult(string location = null, string language = null, Azure.AI.Language.Text.Authoring.Models.DocumentEntityRecognitionEvaluationResult customEntityRecognitionResult = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionEvaluationSummary CustomEntityRecognitionEvaluationSummary(Azure.AI.Language.Text.Authoring.Models.EvaluationDetails evaluationOptions = null, Azure.AI.Language.Text.Authoring.Models.EntityRecognitionEvaluationSummary customEntityRecognitionEvaluation = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.CustomHealthcareDocumentEvaluationResult CustomHealthcareDocumentEvaluationResult(string location = null, string language = null, Azure.AI.Language.Text.Authoring.Models.DocumentHealthcareEvaluationResult customHealthcareResult = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.CustomHealthcareEvaluationSummary CustomHealthcareEvaluationSummary(Azure.AI.Language.Text.Authoring.Models.EvaluationDetails evaluationOptions = null, Azure.AI.Language.Text.Authoring.Models.EntityRecognitionEvaluationSummary customHealthcareEvaluation = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationDocumentEvaluationResult CustomMultiLabelClassificationDocumentEvaluationResult(string location = null, string language = null, Azure.AI.Language.Text.Authoring.Models.DocumentMultiLabelClassificationEvaluationResult customMultiLabelClassificationResult = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationEvaluationSummary CustomMultiLabelClassificationEvaluationSummary(Azure.AI.Language.Text.Authoring.Models.EvaluationDetails evaluationOptions = null, Azure.AI.Language.Text.Authoring.Models.MultiLabelClassificationEvaluationSummary customMultiLabelClassificationEvaluation = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationDocumentEvaluationResult CustomSingleLabelClassificationDocumentEvaluationResult(string location = null, string language = null, Azure.AI.Language.Text.Authoring.Models.DocumentSingleLabelClassificationEvaluationResult customSingleLabelClassificationResult = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationEvaluationSummary CustomSingleLabelClassificationEvaluationSummary(Azure.AI.Language.Text.Authoring.Models.EvaluationDetails evaluationOptions = null, Azure.AI.Language.Text.Authoring.Models.SingleLabelClassificationEvaluationSummary customSingleLabelClassificationEvaluation = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentDocumentEvaluationResult CustomTextSentimentDocumentEvaluationResult(string location = null, string language = null, Azure.AI.Language.Text.Authoring.Models.DocumentTextSentimentEvaluationResult customTextSentimentResult = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentEvaluationSummary CustomTextSentimentEvaluationSummary(Azure.AI.Language.Text.Authoring.Models.EvaluationDetails evaluationOptions = null, Azure.AI.Language.Text.Authoring.Models.TextSentimentEvaluationSummary customTextSentimentEvaluation = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfo DataGenerationConnectionInfo(Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfoKind kind = default(Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfoKind), string resourceId = null, string deploymentName = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.DeploymentDeleteFromResourcesJobState DeploymentDeleteFromResourcesJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.Models.JobStatus status = default(Azure.AI.Language.Text.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.DeploymentJobState DeploymentJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.Models.JobStatus status = default(Azure.AI.Language.Text.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.DeploymentResource DeploymentResource(string resourceId = null, string region = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.DocumentEntityLabelEvaluationResult DocumentEntityLabelEvaluationResult(string category = null, int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.DocumentEntityRecognitionEvaluationResult DocumentEntityRecognitionEvaluationResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRegionEvaluationResult> entities = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.DocumentEntityRegionEvaluationResult DocumentEntityRegionEvaluationResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.DocumentEntityLabelEvaluationResult> expectedEntities = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.DocumentEntityLabelEvaluationResult> predictedEntities = null, int regionOffset = 0, int regionLength = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult DocumentEvaluationResult(string projectKind = null, string location = null, string language = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.DocumentHealthcareEvaluationResult DocumentHealthcareEvaluationResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRegionEvaluationResult> entities = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.DocumentMultiLabelClassificationEvaluationResult DocumentMultiLabelClassificationEvaluationResult(System.Collections.Generic.IEnumerable<string> expectedClasses = null, System.Collections.Generic.IEnumerable<string> predictedClasses = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.DocumentSentimentLabelEvaluationResult DocumentSentimentLabelEvaluationResult(Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringSentiment category = default(Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringSentiment), int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.DocumentSingleLabelClassificationEvaluationResult DocumentSingleLabelClassificationEvaluationResult(string expectedClass = null, string predictedClass = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.DocumentTextSentimentEvaluationResult DocumentTextSentimentEvaluationResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.DocumentSentimentLabelEvaluationResult> expectedSentimentSpans = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.DocumentSentimentLabelEvaluationResult> predictedSentimentSpans = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.EntityEvaluationSummary EntityEvaluationSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.EntityRecognitionEvaluationSummary EntityRecognitionEvaluationSummary(Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix confusionMatrix = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.Models.EntityEvaluationSummary> entities = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.EvaluationJobResult EvaluationJobResult(Azure.AI.Language.Text.Authoring.Models.EvaluationDetails evaluationOptions = null, string modelLabel = null, string trainingConfigVersion = null, int percentComplete = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.EvaluationJobState EvaluationJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.Models.JobStatus status = default(Azure.AI.Language.Text.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> errors = null, Azure.AI.Language.Text.Authoring.Models.EvaluationJobResult result = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.EvaluationSummary EvaluationSummary(string projectKind = null, Azure.AI.Language.Text.Authoring.Models.EvaluationDetails evaluationOptions = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationDocument ExportedCustomAbstractiveSummarizationDocument(string summaryLocation = null, string location = null, string language = null, string dataset = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ExportedModelJobState ExportedModelJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.Models.JobStatus status = default(Azure.AI.Language.Text.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ExportedModelManifest ExportedModelManifest(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.ModelFile> modelFiles = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ExportedProject ExportedProject(string projectFileVersion = null, Azure.AI.Language.Text.Authoring.Models.StringIndexType stringIndexType = default(Azure.AI.Language.Text.Authoring.Models.StringIndexType), Azure.AI.Language.Text.Authoring.Models.CreateProjectDetails metadata = null, Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets assets = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ExportedTrainedModel ExportedTrainedModel(string exportedModelName = null, string modelId = null, System.DateTimeOffset lastTrainedDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastExportedModelDateTime = default(System.DateTimeOffset), System.DateTimeOffset modelExpirationDate = default(System.DateTimeOffset), string modelTrainingConfigVersion = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ExportProjectJobState ExportProjectJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.Models.JobStatus status = default(Azure.AI.Language.Text.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> errors = null, string resultUrl = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ImportProjectJobState ImportProjectJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.Models.JobStatus status = default(Azure.AI.Language.Text.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.InnerErrorModel InnerErrorModel(Azure.AI.Language.Text.Authoring.Models.InnerErrorCode code = default(Azure.AI.Language.Text.Authoring.Models.InnerErrorCode), string message = null, System.Collections.Generic.IReadOnlyDictionary<string, string> details = null, string target = null, Azure.AI.Language.Text.Authoring.Models.InnerErrorModel innererror = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.LoadSnapshotJobState LoadSnapshotJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.Models.JobStatus status = default(Azure.AI.Language.Text.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ModelFile ModelFile(string name = null, System.Uri contentUri = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.MultiLabelClassEvaluationSummary MultiLabelClassEvaluationSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.MultiLabelClassificationEvaluationSummary MultiLabelClassificationEvaluationSummary(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.Models.MultiLabelClassEvaluationSummary> classes = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.PrebuiltEntity PrebuiltEntity(string category = null, string description = null, string examples = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ProjectDeletionJobState ProjectDeletionJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.Models.JobStatus status = default(Azure.AI.Language.Text.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ProjectDeployment ProjectDeployment(string deploymentName = null, string modelId = null, System.DateTimeOffset lastTrainedDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastDeployedDateTime = default(System.DateTimeOffset), System.DateTimeOffset deploymentExpirationDate = default(System.DateTimeOffset), string modelTrainingConfigVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.DeploymentResource> assignedResources = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ProjectMetadata ProjectMetadata(System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastModifiedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? lastTrainedDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastDeployedDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.Models.ProjectKind projectKind = default(Azure.AI.Language.Text.Authoring.Models.ProjectKind), string storageInputContainerName = null, Azure.AI.Language.Text.Authoring.Models.ProjectSettings settings = null, string projectName = null, bool? multilingual = default(bool?), string description = null, string language = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ProjectTrainedModel ProjectTrainedModel(string label = null, string modelId = null, System.DateTimeOffset lastTrainedDateTime = default(System.DateTimeOffset), int lastTrainingDurationInSeconds = 0, System.DateTimeOffset modelExpirationDate = default(System.DateTimeOffset), string modelTrainingConfigVersion = null, bool hasSnapshot = false) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.SentimentEvaluationSummary SentimentEvaluationSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.SingleLabelClassEvaluationSummary SingleLabelClassEvaluationSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.SingleLabelClassificationEvaluationSummary SingleLabelClassificationEvaluationSummary(Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix confusionMatrix = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.Models.SingleLabelClassEvaluationSummary> classes = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.SpanSentimentEvaluationSummary SpanSentimentEvaluationSummary(Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix confusionMatrix = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.Models.SentimentEvaluationSummary> sentiments = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.SubTrainingJobState SubTrainingJobState(int percentComplete = 0, System.DateTimeOffset? startDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? endDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.Models.JobStatus status = default(Azure.AI.Language.Text.Authoring.Models.JobStatus)) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.SupportedLanguage SupportedLanguage(string languageName = null, string languageCode = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsJobState SwapDeploymentsJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.Models.JobStatus status = default(Azure.AI.Language.Text.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError TextAnalysisAuthoringError(Azure.AI.Language.Text.Authoring.Models.ErrorCode code = default(Azure.AI.Language.Text.Authoring.Models.ErrorCode), string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> details = null, Azure.AI.Language.Text.Authoring.Models.InnerErrorModel innererror = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning TextAnalysisAuthoringWarning(string code = null, string message = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.TextSentimentEvaluationSummary TextSentimentEvaluationSummary(Azure.AI.Language.Text.Authoring.Models.SpanSentimentEvaluationSummary spanSentimentsEvaluation = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.TrainingConfigVersion TrainingConfigVersion(string trainingConfigVersionProperty = null, System.DateTimeOffset modelExpirationDate = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.TrainingJobDetails TrainingJobDetails(string modelLabel = null, string trainingConfigVersion = null, Azure.AI.Language.Text.Authoring.Models.EvaluationDetails evaluationOptions = null, Azure.AI.Language.Text.Authoring.Models.DataGenerationSettings dataGenerationSettings = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.TrainingJobResult TrainingJobResult(string modelLabel = null, string trainingConfigVersion = null, Azure.AI.Language.Text.Authoring.Models.SubTrainingJobState trainingStatus = null, Azure.AI.Language.Text.Authoring.Models.SubTrainingJobState evaluationStatus = null, System.DateTimeOffset? estimatedEndDateTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.TrainingJobState TrainingJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.Models.JobStatus status = default(Azure.AI.Language.Text.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> errors = null, Azure.AI.Language.Text.Authoring.Models.TrainingJobResult result = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesJobState UnassignDeploymentResourcesJobState(string jobId = null, System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedDateTime = default(System.DateTimeOffset), System.DateTimeOffset? expirationDateTime = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.Models.JobStatus status = default(Azure.AI.Language.Text.Authoring.Models.JobStatus), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> warnings = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> errors = null) { throw null; }
    }
}
namespace Azure.AI.Language.Text.Authoring.Models
{
    public partial class AssignDeploymentResourcesDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesDetails>
    {
        public AssignDeploymentResourcesDetails(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.Models.ResourceMetadata> resourcesMetadata) { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ResourceMetadata> ResourcesMetadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssignDeploymentResourcesJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesJobState>
    {
        internal AssignDeploymentResourcesJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignDeploymentResourcesJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssignedDeploymentResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.AssignedDeploymentResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignedDeploymentResource>
    {
        internal AssignedDeploymentResource() { }
        public string AzureResourceId { get { throw null; } }
        public string Region { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.AssignedDeploymentResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.AssignedDeploymentResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.AssignedDeploymentResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.AssignedDeploymentResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignedDeploymentResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignedDeploymentResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignedDeploymentResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssignedProjectDeploymentMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentMetadata>
    {
        internal AssignedProjectDeploymentMetadata() { }
        public System.DateTimeOffset DeploymentExpirationDate { get { throw null; } }
        public string DeploymentName { get { throw null; } }
        public System.DateTimeOffset LastDeployedDateTime { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssignedProjectDeploymentsMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentsMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentsMetadata>
    {
        internal AssignedProjectDeploymentsMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentMetadata> DeploymentsMetadata { get { throw null; } }
        public string ProjectName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentsMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentsMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentsMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentsMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentsMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentsMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.AssignedProjectDeploymentsMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CompositionSetting : System.IEquatable<Azure.AI.Language.Text.Authoring.Models.CompositionSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CompositionSetting(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.CompositionSetting CombineComponents { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.CompositionSetting SeparateComponents { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.Models.CompositionSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.Models.CompositionSetting left, Azure.AI.Language.Text.Authoring.Models.CompositionSetting right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.Models.CompositionSetting (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.Models.CompositionSetting left, Azure.AI.Language.Text.Authoring.Models.CompositionSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfusionMatrix : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix>
    {
        internal ConfusionMatrix() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfusionMatrixCell : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixCell>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixCell>
    {
        internal ConfusionMatrixCell() { }
        public float NormalizedValue { get { throw null; } }
        public float RawValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixCell System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixCell>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixCell>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixCell System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixCell>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixCell>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixCell>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfusionMatrixRow : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixRow>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixRow>
    {
        internal ConfusionMatrixRow() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixRow System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixRow>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixRow>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixRow System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixRow>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixRow>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ConfusionMatrixRow>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CopyProjectDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CopyProjectDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CopyProjectDetails>
    {
        public CopyProjectDetails(Azure.AI.Language.Text.Authoring.Models.ProjectKind projectKind, string targetProjectName, string accessToken, System.DateTimeOffset expiresAt, string targetResourceId, string targetResourceRegion) { }
        public string AccessToken { get { throw null; } set { } }
        public System.DateTimeOffset ExpiresAt { get { throw null; } set { } }
        public Azure.AI.Language.Text.Authoring.Models.ProjectKind ProjectKind { get { throw null; } set { } }
        public string TargetProjectName { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TargetResourceRegion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CopyProjectDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CopyProjectDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CopyProjectDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CopyProjectDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CopyProjectDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CopyProjectDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CopyProjectDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CopyProjectJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CopyProjectJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CopyProjectJobState>
    {
        internal CopyProjectJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CopyProjectJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CopyProjectJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CopyProjectJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CopyProjectJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CopyProjectJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CopyProjectJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CopyProjectJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateDeploymentDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CreateDeploymentDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CreateDeploymentDetails>
    {
        public CreateDeploymentDetails(string trainedModelLabel) { }
        public System.Collections.Generic.IList<string> AssignedResourceIds { get { throw null; } }
        public string TrainedModelLabel { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CreateDeploymentDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CreateDeploymentDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CreateDeploymentDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CreateDeploymentDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CreateDeploymentDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CreateDeploymentDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CreateDeploymentDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateProjectDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CreateProjectDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CreateProjectDetails>
    {
        public CreateProjectDetails(Azure.AI.Language.Text.Authoring.Models.ProjectKind projectKind, string storageInputContainerName, string projectName, string language) { }
        public string Description { get { throw null; } set { } }
        public string Language { get { throw null; } }
        public bool? Multilingual { get { throw null; } set { } }
        public Azure.AI.Language.Text.Authoring.Models.ProjectKind ProjectKind { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.ProjectSettings Settings { get { throw null; } set { } }
        public string StorageInputContainerName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CreateProjectDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CreateProjectDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CreateProjectDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CreateProjectDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CreateProjectDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CreateProjectDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CreateProjectDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomEntityRecognitionDocumentEvaluationResult : Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionDocumentEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionDocumentEvaluationResult>
    {
        internal CustomEntityRecognitionDocumentEvaluationResult() : base (default(string), default(string)) { }
        public Azure.AI.Language.Text.Authoring.Models.DocumentEntityRecognitionEvaluationResult CustomEntityRecognitionResult { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionDocumentEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionDocumentEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionDocumentEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionDocumentEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionDocumentEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionDocumentEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionDocumentEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomEntityRecognitionEvaluationSummary : Azure.AI.Language.Text.Authoring.Models.EvaluationSummary, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionEvaluationSummary>
    {
        internal CustomEntityRecognitionEvaluationSummary() : base (default(Azure.AI.Language.Text.Authoring.Models.EvaluationDetails)) { }
        public Azure.AI.Language.Text.Authoring.Models.EntityRecognitionEvaluationSummary CustomEntityRecognitionEvaluation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomEntityRecognitionEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomHealthcareDocumentEvaluationResult : Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomHealthcareDocumentEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomHealthcareDocumentEvaluationResult>
    {
        internal CustomHealthcareDocumentEvaluationResult() : base (default(string), default(string)) { }
        public Azure.AI.Language.Text.Authoring.Models.DocumentHealthcareEvaluationResult CustomHealthcareResult { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomHealthcareDocumentEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomHealthcareDocumentEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomHealthcareDocumentEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomHealthcareDocumentEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomHealthcareDocumentEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomHealthcareDocumentEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomHealthcareDocumentEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomHealthcareEvaluationSummary : Azure.AI.Language.Text.Authoring.Models.EvaluationSummary, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomHealthcareEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomHealthcareEvaluationSummary>
    {
        internal CustomHealthcareEvaluationSummary() : base (default(Azure.AI.Language.Text.Authoring.Models.EvaluationDetails)) { }
        public Azure.AI.Language.Text.Authoring.Models.EntityRecognitionEvaluationSummary CustomHealthcareEvaluation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomHealthcareEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomHealthcareEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomHealthcareEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomHealthcareEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomHealthcareEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomHealthcareEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomHealthcareEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomMultiLabelClassificationDocumentEvaluationResult : Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationDocumentEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationDocumentEvaluationResult>
    {
        internal CustomMultiLabelClassificationDocumentEvaluationResult() : base (default(string), default(string)) { }
        public Azure.AI.Language.Text.Authoring.Models.DocumentMultiLabelClassificationEvaluationResult CustomMultiLabelClassificationResult { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationDocumentEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationDocumentEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationDocumentEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationDocumentEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationDocumentEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationDocumentEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationDocumentEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomMultiLabelClassificationEvaluationSummary : Azure.AI.Language.Text.Authoring.Models.EvaluationSummary, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationEvaluationSummary>
    {
        internal CustomMultiLabelClassificationEvaluationSummary() : base (default(Azure.AI.Language.Text.Authoring.Models.EvaluationDetails)) { }
        public Azure.AI.Language.Text.Authoring.Models.MultiLabelClassificationEvaluationSummary CustomMultiLabelClassificationEvaluation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomMultiLabelClassificationEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSingleLabelClassificationDocumentEvaluationResult : Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationDocumentEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationDocumentEvaluationResult>
    {
        internal CustomSingleLabelClassificationDocumentEvaluationResult() : base (default(string), default(string)) { }
        public Azure.AI.Language.Text.Authoring.Models.DocumentSingleLabelClassificationEvaluationResult CustomSingleLabelClassificationResult { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationDocumentEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationDocumentEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationDocumentEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationDocumentEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationDocumentEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationDocumentEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationDocumentEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSingleLabelClassificationEvaluationSummary : Azure.AI.Language.Text.Authoring.Models.EvaluationSummary, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationEvaluationSummary>
    {
        internal CustomSingleLabelClassificationEvaluationSummary() : base (default(Azure.AI.Language.Text.Authoring.Models.EvaluationDetails)) { }
        public Azure.AI.Language.Text.Authoring.Models.SingleLabelClassificationEvaluationSummary CustomSingleLabelClassificationEvaluation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomSingleLabelClassificationEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomTextSentimentDocumentEvaluationResult : Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentDocumentEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentDocumentEvaluationResult>
    {
        internal CustomTextSentimentDocumentEvaluationResult() : base (default(string), default(string)) { }
        public Azure.AI.Language.Text.Authoring.Models.DocumentTextSentimentEvaluationResult CustomTextSentimentResult { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentDocumentEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentDocumentEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentDocumentEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentDocumentEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentDocumentEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentDocumentEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentDocumentEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomTextSentimentEvaluationSummary : Azure.AI.Language.Text.Authoring.Models.EvaluationSummary, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentEvaluationSummary>
    {
        internal CustomTextSentimentEvaluationSummary() : base (default(Azure.AI.Language.Text.Authoring.Models.EvaluationDetails)) { }
        public Azure.AI.Language.Text.Authoring.Models.TextSentimentEvaluationSummary CustomTextSentimentEvaluation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.CustomTextSentimentEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataGenerationConnectionInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfo>
    {
        public DataGenerationConnectionInfo(string resourceId, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfoKind Kind { get { throw null; } }
        public string ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataGenerationConnectionInfoKind : System.IEquatable<Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfoKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataGenerationConnectionInfoKind(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfoKind AzureOpenAI { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfoKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfoKind left, Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfoKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfoKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfoKind left, Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfoKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataGenerationSettings : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DataGenerationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DataGenerationSettings>
    {
        public DataGenerationSettings(bool enableDataGeneration, Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfo dataGenerationConnectionInfo) { }
        public Azure.AI.Language.Text.Authoring.Models.DataGenerationConnectionInfo DataGenerationConnectionInfo { get { throw null; } }
        public bool EnableDataGeneration { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DataGenerationSettings System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DataGenerationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DataGenerationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DataGenerationSettings System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DataGenerationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DataGenerationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DataGenerationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeleteDeploymentDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DeleteDeploymentDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeleteDeploymentDetails>
    {
        public DeleteDeploymentDetails() { }
        public System.Collections.Generic.IList<string> AssignedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DeleteDeploymentDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DeleteDeploymentDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DeleteDeploymentDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DeleteDeploymentDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeleteDeploymentDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeleteDeploymentDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeleteDeploymentDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentDeleteFromResourcesJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DeploymentDeleteFromResourcesJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeploymentDeleteFromResourcesJobState>
    {
        internal DeploymentDeleteFromResourcesJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DeploymentDeleteFromResourcesJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DeploymentDeleteFromResourcesJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DeploymentDeleteFromResourcesJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DeploymentDeleteFromResourcesJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeploymentDeleteFromResourcesJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeploymentDeleteFromResourcesJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeploymentDeleteFromResourcesJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DeploymentJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeploymentJobState>
    {
        internal DeploymentJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DeploymentJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DeploymentJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DeploymentJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DeploymentJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeploymentJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeploymentJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeploymentJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DeploymentResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeploymentResource>
    {
        internal DeploymentResource() { }
        public string Region { get { throw null; } }
        public string ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DeploymentResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DeploymentResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DeploymentResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DeploymentResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeploymentResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeploymentResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DeploymentResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentEntityLabelEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityLabelEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityLabelEvaluationResult>
    {
        internal DocumentEntityLabelEvaluationResult() { }
        public string Category { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentEntityLabelEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityLabelEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityLabelEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentEntityLabelEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityLabelEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityLabelEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityLabelEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentEntityRecognitionEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRecognitionEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRecognitionEvaluationResult>
    {
        internal DocumentEntityRecognitionEvaluationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRegionEvaluationResult> Entities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentEntityRecognitionEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRecognitionEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRecognitionEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentEntityRecognitionEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRecognitionEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRecognitionEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRecognitionEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentEntityRegionEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRegionEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRegionEvaluationResult>
    {
        internal DocumentEntityRegionEvaluationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.DocumentEntityLabelEvaluationResult> ExpectedEntities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.DocumentEntityLabelEvaluationResult> PredictedEntities { get { throw null; } }
        public int RegionLength { get { throw null; } }
        public int RegionOffset { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentEntityRegionEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRegionEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRegionEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentEntityRegionEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRegionEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRegionEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRegionEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DocumentEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult>
    {
        protected DocumentEvaluationResult(string location, string language) { }
        public string Language { get { throw null; } }
        public string Location { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentHealthcareEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentHealthcareEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentHealthcareEvaluationResult>
    {
        internal DocumentHealthcareEvaluationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.DocumentEntityRegionEvaluationResult> Entities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentHealthcareEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentHealthcareEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentHealthcareEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentHealthcareEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentHealthcareEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentHealthcareEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentHealthcareEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentMultiLabelClassificationEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentMultiLabelClassificationEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentMultiLabelClassificationEvaluationResult>
    {
        internal DocumentMultiLabelClassificationEvaluationResult() { }
        public System.Collections.Generic.IReadOnlyList<string> ExpectedClasses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PredictedClasses { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentMultiLabelClassificationEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentMultiLabelClassificationEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentMultiLabelClassificationEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentMultiLabelClassificationEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentMultiLabelClassificationEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentMultiLabelClassificationEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentMultiLabelClassificationEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentSentimentLabelEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentSentimentLabelEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentSentimentLabelEvaluationResult>
    {
        internal DocumentSentimentLabelEvaluationResult() { }
        public Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringSentiment Category { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentSentimentLabelEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentSentimentLabelEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentSentimentLabelEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentSentimentLabelEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentSentimentLabelEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentSentimentLabelEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentSentimentLabelEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentSingleLabelClassificationEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentSingleLabelClassificationEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentSingleLabelClassificationEvaluationResult>
    {
        internal DocumentSingleLabelClassificationEvaluationResult() { }
        public string ExpectedClass { get { throw null; } }
        public string PredictedClass { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentSingleLabelClassificationEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentSingleLabelClassificationEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentSingleLabelClassificationEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentSingleLabelClassificationEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentSingleLabelClassificationEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentSingleLabelClassificationEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentSingleLabelClassificationEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentTextSentimentEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentTextSentimentEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentTextSentimentEvaluationResult>
    {
        internal DocumentTextSentimentEvaluationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.DocumentSentimentLabelEvaluationResult> ExpectedSentimentSpans { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.DocumentSentimentLabelEvaluationResult> PredictedSentimentSpans { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentTextSentimentEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentTextSentimentEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.DocumentTextSentimentEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.DocumentTextSentimentEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentTextSentimentEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentTextSentimentEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.DocumentTextSentimentEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EntityEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EntityEvaluationSummary>
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
        Azure.AI.Language.Text.Authoring.Models.EntityEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EntityEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EntityEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.EntityEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EntityEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EntityEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EntityEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityRecognitionEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EntityRecognitionEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EntityRecognitionEvaluationSummary>
    {
        internal EntityRecognitionEvaluationSummary() { }
        public Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix ConfusionMatrix { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.Models.EntityEvaluationSummary> Entities { get { throw null; } }
        public float MacroF1 { get { throw null; } }
        public float MacroPrecision { get { throw null; } }
        public float MacroRecall { get { throw null; } }
        public float MicroF1 { get { throw null; } }
        public float MicroPrecision { get { throw null; } }
        public float MicroRecall { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.EntityRecognitionEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EntityRecognitionEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EntityRecognitionEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.EntityRecognitionEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EntityRecognitionEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EntityRecognitionEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EntityRecognitionEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ErrorCode : System.IEquatable<Azure.AI.Language.Text.Authoring.Models.ErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ErrorCode(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode AzureCognitiveSearchIndexLimitReached { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode AzureCognitiveSearchIndexNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode AzureCognitiveSearchNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode AzureCognitiveSearchThrottling { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode Conflict { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode Forbidden { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode InternalServerError { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode InvalidArgument { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode NotFound { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode OperationNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode ProjectNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode QuotaExceeded { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode ServiceUnavailable { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode Timeout { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode TooManyRequests { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode Unauthorized { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ErrorCode Warning { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.Models.ErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.Models.ErrorCode left, Azure.AI.Language.Text.Authoring.Models.ErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.Models.ErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.Models.ErrorCode left, Azure.AI.Language.Text.Authoring.Models.ErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvaluationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EvaluationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationDetails>
    {
        public EvaluationDetails() { }
        public Azure.AI.Language.Text.Authoring.Models.EvaluationKind? Kind { get { throw null; } set { } }
        public int? TestingSplitPercentage { get { throw null; } set { } }
        public int? TrainingSplitPercentage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.EvaluationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EvaluationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EvaluationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.EvaluationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationJobResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EvaluationJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationJobResult>
    {
        internal EvaluationJobResult() { }
        public Azure.AI.Language.Text.Authoring.Models.EvaluationDetails EvaluationOptions { get { throw null; } }
        public string ModelLabel { get { throw null; } }
        public int PercentComplete { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.EvaluationJobResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EvaluationJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EvaluationJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.EvaluationJobResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EvaluationJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationJobState>
    {
        internal EvaluationJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.EvaluationJobResult Result { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.EvaluationJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EvaluationJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EvaluationJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.EvaluationJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluationKind : System.IEquatable<Azure.AI.Language.Text.Authoring.Models.EvaluationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluationKind(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.EvaluationKind Manual { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.EvaluationKind Percentage { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.Models.EvaluationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.Models.EvaluationKind left, Azure.AI.Language.Text.Authoring.Models.EvaluationKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.Models.EvaluationKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.Models.EvaluationKind left, Azure.AI.Language.Text.Authoring.Models.EvaluationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class EvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationSummary>
    {
        protected EvaluationSummary(Azure.AI.Language.Text.Authoring.Models.EvaluationDetails evaluationOptions) { }
        public Azure.AI.Language.Text.Authoring.Models.EvaluationDetails EvaluationOptions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.EvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.EvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.EvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.EvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedClass : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedClass>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedClass>
    {
        public ExportedClass() { }
        public string Category { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedClass System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedClass>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedClass>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedClass System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedClass>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedClass>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedClass>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCompositeEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCompositeEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCompositeEntity>
    {
        public ExportedCompositeEntity() { }
        public string Category { get { throw null; } set { } }
        public Azure.AI.Language.Text.Authoring.Models.CompositionSetting? CompositionSetting { get { throw null; } set { } }
        public Azure.AI.Language.Text.Authoring.Models.ExportedEntityList List { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedPrebuiltEntity> Prebuilts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCompositeEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCompositeEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCompositeEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCompositeEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCompositeEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCompositeEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCompositeEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomAbstractiveSummarizationDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationDocument>
    {
        public ExportedCustomAbstractiveSummarizationDocument(string summaryLocation) { }
        public string Dataset { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public string SummaryLocation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomAbstractiveSummarizationProjectAssets : Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationProjectAssets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationProjectAssets>
    {
        public ExportedCustomAbstractiveSummarizationProjectAssets() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationDocument> Documents { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationProjectAssets System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationProjectAssets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationProjectAssets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationProjectAssets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationProjectAssets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationProjectAssets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomAbstractiveSummarizationProjectAssets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomEntityRecognitionDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionDocument>
    {
        public ExportedCustomEntityRecognitionDocument() { }
        public string Dataset { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityRegion> Entities { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomEntityRecognitionProjectAssets : Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionProjectAssets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionProjectAssets>
    {
        public ExportedCustomEntityRecognitionProjectAssets() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionDocument> Documents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedEntity> Entities { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionProjectAssets System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionProjectAssets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionProjectAssets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionProjectAssets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionProjectAssets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionProjectAssets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomEntityRecognitionProjectAssets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomHealthcareDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareDocument>
    {
        public ExportedCustomHealthcareDocument() { }
        public string Dataset { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityRegion> Entities { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomHealthcareProjectAssets : Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareProjectAssets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareProjectAssets>
    {
        public ExportedCustomHealthcareProjectAssets() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareDocument> Documents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedCompositeEntity> Entities { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareProjectAssets System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareProjectAssets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareProjectAssets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareProjectAssets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareProjectAssets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareProjectAssets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomHealthcareProjectAssets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomMultiLabelClassificationDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationDocument>
    {
        public ExportedCustomMultiLabelClassificationDocument() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentClass> Classes { get { throw null; } }
        public string Dataset { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomMultiLabelClassificationProjectAssets : Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationProjectAssets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationProjectAssets>
    {
        public ExportedCustomMultiLabelClassificationProjectAssets() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedClass> Classes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationDocument> Documents { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationProjectAssets System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationProjectAssets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationProjectAssets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationProjectAssets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationProjectAssets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationProjectAssets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomMultiLabelClassificationProjectAssets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomSingleLabelClassificationDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationDocument>
    {
        public ExportedCustomSingleLabelClassificationDocument() { }
        public Azure.AI.Language.Text.Authoring.Models.ExportedDocumentClass Class { get { throw null; } set { } }
        public string Dataset { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomSingleLabelClassificationProjectAssets : Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationProjectAssets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationProjectAssets>
    {
        public ExportedCustomSingleLabelClassificationProjectAssets() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedClass> Classes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationDocument> Documents { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationProjectAssets System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationProjectAssets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationProjectAssets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationProjectAssets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationProjectAssets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationProjectAssets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomSingleLabelClassificationProjectAssets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomTextSentimentDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentDocument>
    {
        public ExportedCustomTextSentimentDocument() { }
        public string Dataset { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentSentimentLabel> SentimentSpans { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomTextSentimentProjectAssets : Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentProjectAssets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentProjectAssets>
    {
        public ExportedCustomTextSentimentProjectAssets() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentDocument> Documents { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentProjectAssets System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentProjectAssets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentProjectAssets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentProjectAssets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentProjectAssets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentProjectAssets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedCustomTextSentimentProjectAssets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedDocumentClass : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentClass>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentClass>
    {
        public ExportedDocumentClass() { }
        public string Category { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedDocumentClass System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentClass>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentClass>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedDocumentClass System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentClass>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentClass>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentClass>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedDocumentEntityLabel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityLabel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityLabel>
    {
        public ExportedDocumentEntityLabel() { }
        public string Category { get { throw null; } set { } }
        public int? Length { get { throw null; } set { } }
        public int? Offset { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityLabel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityLabel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityLabel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityLabel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityLabel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityLabel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityLabel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedDocumentEntityRegion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityRegion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityRegion>
    {
        public ExportedDocumentEntityRegion() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityLabel> Labels { get { throw null; } }
        public int? RegionLength { get { throw null; } set { } }
        public int? RegionOffset { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityRegion System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityRegion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentEntityRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedDocumentSentimentLabel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentSentimentLabel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentSentimentLabel>
    {
        public ExportedDocumentSentimentLabel() { }
        public Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringSentiment? Category { get { throw null; } set { } }
        public int? Length { get { throw null; } set { } }
        public int? Offset { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedDocumentSentimentLabel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentSentimentLabel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentSentimentLabel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedDocumentSentimentLabel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentSentimentLabel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentSentimentLabel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedDocumentSentimentLabel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntity>
    {
        public ExportedEntity() { }
        public string Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedEntityList : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntityList>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntityList>
    {
        public ExportedEntityList() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedEntitySublist> Sublists { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedEntityList System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntityList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntityList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedEntityList System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntityList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntityList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntityList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedEntityListSynonym : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntityListSynonym>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntityListSynonym>
    {
        public ExportedEntityListSynonym() { }
        public string Language { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedEntityListSynonym System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntityListSynonym>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntityListSynonym>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedEntityListSynonym System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntityListSynonym>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntityListSynonym>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntityListSynonym>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedEntitySublist : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntitySublist>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntitySublist>
    {
        public ExportedEntitySublist() { }
        public string ListKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.Models.ExportedEntityListSynonym> Synonyms { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedEntitySublist System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntitySublist>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntitySublist>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedEntitySublist System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntitySublist>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntitySublist>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedEntitySublist>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedModelDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelDetails>
    {
        public ExportedModelDetails(string trainedModelLabel) { }
        public string TrainedModelLabel { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedModelDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedModelDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedModelJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelJobState>
    {
        internal ExportedModelJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedModelJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedModelJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedModelManifest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelManifest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelManifest>
    {
        internal ExportedModelManifest() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.ModelFile> ModelFiles { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedModelManifest System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelManifest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelManifest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedModelManifest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelManifest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelManifest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedModelManifest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedPrebuiltEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedPrebuiltEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedPrebuiltEntity>
    {
        public ExportedPrebuiltEntity(string category) { }
        public string Category { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedPrebuiltEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedPrebuiltEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedPrebuiltEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedPrebuiltEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedPrebuiltEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedPrebuiltEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedPrebuiltEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedProject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedProject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedProject>
    {
        public ExportedProject(string projectFileVersion, Azure.AI.Language.Text.Authoring.Models.StringIndexType stringIndexType, Azure.AI.Language.Text.Authoring.Models.CreateProjectDetails metadata) { }
        public Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets Assets { get { throw null; } set { } }
        public Azure.AI.Language.Text.Authoring.Models.CreateProjectDetails Metadata { get { throw null; } }
        public string ProjectFileVersion { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.StringIndexType StringIndexType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedProject System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedProject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedProject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedProject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedProject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedProject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedProject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ExportedProjectAssets : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets>
    {
        protected ExportedProjectAssets() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedProjectAssets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedTrainedModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedTrainedModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedTrainedModel>
    {
        internal ExportedTrainedModel() { }
        public string ExportedModelName { get { throw null; } }
        public System.DateTimeOffset LastExportedModelDateTime { get { throw null; } }
        public System.DateTimeOffset LastTrainedDateTime { get { throw null; } }
        public System.DateTimeOffset ModelExpirationDate { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ModelTrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedTrainedModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedTrainedModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportedTrainedModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportedTrainedModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedTrainedModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedTrainedModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportedTrainedModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportProjectJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportProjectJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportProjectJobState>
    {
        internal ExportProjectJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public string ResultUrl { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportProjectJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportProjectJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ExportProjectJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ExportProjectJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportProjectJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportProjectJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ExportProjectJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportProjectJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ImportProjectJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ImportProjectJobState>
    {
        internal ImportProjectJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ImportProjectJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ImportProjectJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ImportProjectJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ImportProjectJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ImportProjectJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ImportProjectJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ImportProjectJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InnerErrorCode : System.IEquatable<Azure.AI.Language.Text.Authoring.Models.InnerErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InnerErrorCode(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.InnerErrorCode AzureCognitiveSearchNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.InnerErrorCode AzureCognitiveSearchThrottling { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.InnerErrorCode EmptyRequest { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.InnerErrorCode ExtractionFailure { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.InnerErrorCode InvalidCountryHint { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.InnerErrorCode InvalidDocument { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.InnerErrorCode InvalidDocumentBatch { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.InnerErrorCode InvalidParameterValue { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.InnerErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.InnerErrorCode InvalidRequestBodyFormat { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.InnerErrorCode KnowledgeBaseNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.InnerErrorCode MissingInputDocuments { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.InnerErrorCode ModelVersionIncorrect { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.InnerErrorCode UnsupportedLanguageCode { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.Models.InnerErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.Models.InnerErrorCode left, Azure.AI.Language.Text.Authoring.Models.InnerErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.Models.InnerErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.Models.InnerErrorCode left, Azure.AI.Language.Text.Authoring.Models.InnerErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InnerErrorModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.InnerErrorModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.InnerErrorModel>
    {
        internal InnerErrorModel() { }
        public Azure.AI.Language.Text.Authoring.Models.InnerErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Details { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.InnerErrorModel Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.InnerErrorModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.InnerErrorModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.InnerErrorModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.InnerErrorModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.InnerErrorModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.InnerErrorModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.InnerErrorModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.AI.Language.Text.Authoring.Models.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.JobStatus Cancelled { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.JobStatus Cancelling { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.JobStatus Failed { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.JobStatus NotStarted { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.JobStatus PartiallyCompleted { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.JobStatus Running { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.JobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.Models.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.Models.JobStatus left, Azure.AI.Language.Text.Authoring.Models.JobStatus right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.Models.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.Models.JobStatus left, Azure.AI.Language.Text.Authoring.Models.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadSnapshotJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.LoadSnapshotJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.LoadSnapshotJobState>
    {
        internal LoadSnapshotJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.LoadSnapshotJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.LoadSnapshotJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.LoadSnapshotJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.LoadSnapshotJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.LoadSnapshotJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.LoadSnapshotJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.LoadSnapshotJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ModelFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ModelFile>
    {
        internal ModelFile() { }
        public System.Uri ContentUri { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ModelFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ModelFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ModelFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ModelFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ModelFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ModelFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ModelFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultiLabelClassEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.MultiLabelClassEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.MultiLabelClassEvaluationSummary>
    {
        internal MultiLabelClassEvaluationSummary() { }
        public double F1 { get { throw null; } }
        public int FalseNegativeCount { get { throw null; } }
        public int FalsePositiveCount { get { throw null; } }
        public double Precision { get { throw null; } }
        public double Recall { get { throw null; } }
        public int TrueNegativeCount { get { throw null; } }
        public int TruePositiveCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.MultiLabelClassEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.MultiLabelClassEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.MultiLabelClassEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.MultiLabelClassEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.MultiLabelClassEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.MultiLabelClassEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.MultiLabelClassEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultiLabelClassificationEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.MultiLabelClassificationEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.MultiLabelClassificationEvaluationSummary>
    {
        internal MultiLabelClassificationEvaluationSummary() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.Models.MultiLabelClassEvaluationSummary> Classes { get { throw null; } }
        public float MacroF1 { get { throw null; } }
        public float MacroPrecision { get { throw null; } }
        public float MacroRecall { get { throw null; } }
        public float MicroF1 { get { throw null; } }
        public float MicroPrecision { get { throw null; } }
        public float MicroRecall { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.MultiLabelClassificationEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.MultiLabelClassificationEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.MultiLabelClassificationEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.MultiLabelClassificationEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.MultiLabelClassificationEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.MultiLabelClassificationEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.MultiLabelClassificationEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrebuiltEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.PrebuiltEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.PrebuiltEntity>
    {
        internal PrebuiltEntity() { }
        public string Category { get { throw null; } }
        public string Description { get { throw null; } }
        public string Examples { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.PrebuiltEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.PrebuiltEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.PrebuiltEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.PrebuiltEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.PrebuiltEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.PrebuiltEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.PrebuiltEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectDeletionJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ProjectDeletionJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectDeletionJobState>
    {
        internal ProjectDeletionJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ProjectDeletionJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ProjectDeletionJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ProjectDeletionJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ProjectDeletionJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectDeletionJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectDeletionJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectDeletionJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectDeployment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ProjectDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectDeployment>
    {
        internal ProjectDeployment() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.DeploymentResource> AssignedResources { get { throw null; } }
        public System.DateTimeOffset DeploymentExpirationDate { get { throw null; } }
        public string DeploymentName { get { throw null; } }
        public System.DateTimeOffset LastDeployedDateTime { get { throw null; } }
        public System.DateTimeOffset LastTrainedDateTime { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ModelTrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ProjectDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ProjectDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ProjectDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ProjectDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProjectKind : System.IEquatable<Azure.AI.Language.Text.Authoring.Models.ProjectKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProjectKind(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.ProjectKind CustomAbstractiveSummarization { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ProjectKind CustomEntityRecognition { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ProjectKind CustomHealthcare { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ProjectKind CustomMultiLabelClassification { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ProjectKind CustomSingleLabelClassification { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.ProjectKind CustomTextSentiment { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.Models.ProjectKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.Models.ProjectKind left, Azure.AI.Language.Text.Authoring.Models.ProjectKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.Models.ProjectKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.Models.ProjectKind left, Azure.AI.Language.Text.Authoring.Models.ProjectKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProjectMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ProjectMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectMetadata>
    {
        internal ProjectMetadata() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public string Description { get { throw null; } }
        public string Language { get { throw null; } }
        public System.DateTimeOffset? LastDeployedDateTime { get { throw null; } }
        public System.DateTimeOffset LastModifiedDateTime { get { throw null; } }
        public System.DateTimeOffset? LastTrainedDateTime { get { throw null; } }
        public bool? Multilingual { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.ProjectKind ProjectKind { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.ProjectSettings Settings { get { throw null; } }
        public string StorageInputContainerName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ProjectMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ProjectMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ProjectMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ProjectMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectSettings : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ProjectSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectSettings>
    {
        public ProjectSettings() { }
        public string AmlProjectPath { get { throw null; } set { } }
        public float? ConfidenceThreshold { get { throw null; } set { } }
        public int? GptPredictiveLookahead { get { throw null; } set { } }
        public bool? IsLabelingLocked { get { throw null; } set { } }
        public bool? RunGptPredictions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ProjectSettings System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ProjectSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ProjectSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ProjectSettings System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectTrainedModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ProjectTrainedModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectTrainedModel>
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
        Azure.AI.Language.Text.Authoring.Models.ProjectTrainedModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ProjectTrainedModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ProjectTrainedModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ProjectTrainedModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectTrainedModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectTrainedModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ProjectTrainedModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ResourceMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ResourceMetadata>
    {
        public ResourceMetadata(string azureResourceId, string customDomain, string region) { }
        public string AzureResourceId { get { throw null; } }
        public string CustomDomain { get { throw null; } }
        public string Region { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ResourceMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ResourceMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.ResourceMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.ResourceMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ResourceMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ResourceMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.ResourceMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentimentEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SentimentEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SentimentEvaluationSummary>
    {
        internal SentimentEvaluationSummary() { }
        public double F1 { get { throw null; } }
        public int FalseNegativeCount { get { throw null; } }
        public int FalsePositiveCount { get { throw null; } }
        public double Precision { get { throw null; } }
        public double Recall { get { throw null; } }
        public int TrueNegativeCount { get { throw null; } }
        public int TruePositiveCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SentimentEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SentimentEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SentimentEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SentimentEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SentimentEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SentimentEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SentimentEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SingleLabelClassEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SingleLabelClassEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SingleLabelClassEvaluationSummary>
    {
        internal SingleLabelClassEvaluationSummary() { }
        public double F1 { get { throw null; } }
        public int FalseNegativeCount { get { throw null; } }
        public int FalsePositiveCount { get { throw null; } }
        public double Precision { get { throw null; } }
        public double Recall { get { throw null; } }
        public int TrueNegativeCount { get { throw null; } }
        public int TruePositiveCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SingleLabelClassEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SingleLabelClassEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SingleLabelClassEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SingleLabelClassEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SingleLabelClassEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SingleLabelClassEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SingleLabelClassEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SingleLabelClassificationEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SingleLabelClassificationEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SingleLabelClassificationEvaluationSummary>
    {
        internal SingleLabelClassificationEvaluationSummary() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.Models.SingleLabelClassEvaluationSummary> Classes { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix ConfusionMatrix { get { throw null; } }
        public float MacroF1 { get { throw null; } }
        public float MacroPrecision { get { throw null; } }
        public float MacroRecall { get { throw null; } }
        public float MicroF1 { get { throw null; } }
        public float MicroPrecision { get { throw null; } }
        public float MicroRecall { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SingleLabelClassificationEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SingleLabelClassificationEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SingleLabelClassificationEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SingleLabelClassificationEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SingleLabelClassificationEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SingleLabelClassificationEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SingleLabelClassificationEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpanSentimentEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SpanSentimentEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SpanSentimentEvaluationSummary>
    {
        internal SpanSentimentEvaluationSummary() { }
        public Azure.AI.Language.Text.Authoring.Models.ConfusionMatrix ConfusionMatrix { get { throw null; } }
        public float MacroF1 { get { throw null; } }
        public float MacroPrecision { get { throw null; } }
        public float MacroRecall { get { throw null; } }
        public float MicroF1 { get { throw null; } }
        public float MicroPrecision { get { throw null; } }
        public float MicroRecall { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.Models.SentimentEvaluationSummary> Sentiments { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SpanSentimentEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SpanSentimentEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SpanSentimentEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SpanSentimentEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SpanSentimentEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SpanSentimentEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SpanSentimentEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StringIndexType : System.IEquatable<Azure.AI.Language.Text.Authoring.Models.StringIndexType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StringIndexType(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.StringIndexType Utf16CodeUnit { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.Models.StringIndexType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.Models.StringIndexType left, Azure.AI.Language.Text.Authoring.Models.StringIndexType right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.Models.StringIndexType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.Models.StringIndexType left, Azure.AI.Language.Text.Authoring.Models.StringIndexType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubTrainingJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SubTrainingJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SubTrainingJobState>
    {
        internal SubTrainingJobState() { }
        public System.DateTimeOffset? EndDateTime { get { throw null; } }
        public int PercentComplete { get { throw null; } }
        public System.DateTimeOffset? StartDateTime { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.JobStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SubTrainingJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SubTrainingJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SubTrainingJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SubTrainingJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SubTrainingJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SubTrainingJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SubTrainingJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SupportedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SupportedLanguage>
    {
        internal SupportedLanguage() { }
        public string LanguageCode { get { throw null; } }
        public string LanguageName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SupportedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SupportedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SupportedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SupportedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SupportedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SupportedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SupportedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SwapDeploymentsDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsDetails>
    {
        public SwapDeploymentsDetails(string firstDeploymentName, string secondDeploymentName) { }
        public string FirstDeploymentName { get { throw null; } }
        public string SecondDeploymentName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SwapDeploymentsJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsJobState>
    {
        internal SwapDeploymentsJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.SwapDeploymentsJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAnalysisAuthoringError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError>
    {
        internal TextAnalysisAuthoringError() { }
        public Azure.AI.Language.Text.Authoring.Models.ErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> Details { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.InnerErrorModel Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextAnalysisAuthoringSentiment : System.IEquatable<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringSentiment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextAnalysisAuthoringSentiment(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringSentiment Negative { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringSentiment Neutral { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringSentiment Positive { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringSentiment other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringSentiment left, Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringSentiment right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringSentiment (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringSentiment left, Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringSentiment right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextAnalysisAuthoringWarning : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning>
    {
        internal TextAnalysisAuthoringWarning() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextSentimentEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TextSentimentEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TextSentimentEvaluationSummary>
    {
        internal TextSentimentEvaluationSummary() { }
        public float MacroF1 { get { throw null; } }
        public float MacroPrecision { get { throw null; } }
        public float MacroRecall { get { throw null; } }
        public float MicroF1 { get { throw null; } }
        public float MicroPrecision { get { throw null; } }
        public float MicroRecall { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.SpanSentimentEvaluationSummary SpanSentimentsEvaluation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.TextSentimentEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TextSentimentEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TextSentimentEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.TextSentimentEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TextSentimentEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TextSentimentEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TextSentimentEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrainingConfigVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TrainingConfigVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingConfigVersion>
    {
        internal TrainingConfigVersion() { }
        public System.DateTimeOffset ModelExpirationDate { get { throw null; } }
        public string TrainingConfigVersionProperty { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.TrainingConfigVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TrainingConfigVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TrainingConfigVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.TrainingConfigVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingConfigVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingConfigVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingConfigVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrainingJobDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobDetails>
    {
        public TrainingJobDetails(string modelLabel, string trainingConfigVersion) { }
        public Azure.AI.Language.Text.Authoring.Models.DataGenerationSettings DataGenerationSettings { get { throw null; } set { } }
        public Azure.AI.Language.Text.Authoring.Models.EvaluationDetails EvaluationOptions { get { throw null; } set { } }
        public string ModelLabel { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.TrainingJobDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.TrainingJobDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrainingJobResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobResult>
    {
        internal TrainingJobResult() { }
        public System.DateTimeOffset? EstimatedEndDateTime { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.SubTrainingJobState EvaluationStatus { get { throw null; } }
        public string ModelLabel { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.SubTrainingJobState TrainingStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.TrainingJobResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.TrainingJobResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrainingJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobState>
    {
        internal TrainingJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.TrainingJobResult Result { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.TrainingJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.TrainingJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.TrainingJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UnassignDeploymentResourcesDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesDetails>
    {
        public UnassignDeploymentResourcesDetails(System.Collections.Generic.IEnumerable<string> assignedResourceIds) { }
        public System.Collections.Generic.IList<string> AssignedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UnassignDeploymentResourcesJobState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesJobState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesJobState>
    {
        internal UnassignDeploymentResourcesJobState() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationDateTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedDateTime { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.Models.TextAnalysisAuthoringWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesJobState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesJobState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesJobState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesJobState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesJobState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesJobState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.Models.UnassignDeploymentResourcesJobState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
