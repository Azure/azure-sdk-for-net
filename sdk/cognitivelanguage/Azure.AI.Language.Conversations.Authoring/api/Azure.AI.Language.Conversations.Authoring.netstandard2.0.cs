namespace Azure.AI.Language.Conversations.Authoring
{
    public partial class AnalyzeConversationAuthoringDataGenerationConnectionInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionInfo>
    {
        public AnalyzeConversationAuthoringDataGenerationConnectionInfo(Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionKind kind, string deploymentName) { }
        public string DeploymentName { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionKind Kind { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeConversationAuthoringDataGenerationConnectionKind : System.IEquatable<Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeConversationAuthoringDataGenerationConnectionKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionKind AzureOpenAI { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionKind left, Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionKind left, Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnalyzeConversationAuthoringDataGenerationSettings : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationSettings>
    {
        public AnalyzeConversationAuthoringDataGenerationSettings(bool enableDataGeneration, Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionInfo dataGenerationConnectionInfo) { }
        public Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionInfo DataGenerationConnectionInfo { get { throw null; } }
        public bool EnableDataGeneration { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationSettings System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationSettings System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAILanguageConversationsAuthoringContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAILanguageConversationsAuthoringContext() { }
        public static Azure.AI.Language.Conversations.Authoring.AzureAILanguageConversationsAuthoringContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ConversationAnalysisAuthoringClient
    {
        protected ConversationAnalysisAuthoringClient() { }
        public ConversationAnalysisAuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ConversationAnalysisAuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Conversations.Authoring.ConversationAnalysisAuthoringClientOptions options) { }
        public ConversationAnalysisAuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ConversationAnalysisAuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.Conversations.Authoring.ConversationAnalysisAuthoringClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetAssignedResourceDeployments(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentsMetadata> GetAssignedResourceDeployments(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAssignedResourceDeploymentsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentsMetadata> GetAssignedResourceDeploymentsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeployment GetDeployment(string projectName, string deploymentName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeploymentResources(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedDeploymentResource> GetDeploymentResources(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentResourcesAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedDeploymentResource> GetDeploymentResourcesAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeployments(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeployment> GetDeployments(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeployment> GetDeploymentsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModel GetExportedModel(string projectName, string exportedModelName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetExportedModels(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedTrainedModel> GetExportedModels(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetExportedModelsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedTrainedModel> GetExportedModelsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProject GetProject(string projectName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProjects(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectMetadata> GetProjects(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectMetadata> GetProjectsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSupportedLanguage> GetSupportedLanguages(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedLanguages(string projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSupportedLanguage> GetSupportedLanguagesAsync(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedLanguagesAsync(string projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedPrebuiltEntities(int? maxCount, int? skip, int? maxpagesize, string language, string multilingual, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringPrebuiltEntity> GetSupportedPrebuiltEntities(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), string language = null, string multilingual = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedPrebuiltEntitiesAsync(int? maxCount, int? skip, int? maxpagesize, string language, string multilingual, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringPrebuiltEntity> GetSupportedPrebuiltEntitiesAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), string language = null, string multilingual = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainedModel GetTrainedModel(string projectName, string trainedModelLabel) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainedModels(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectTrainedModel> GetTrainedModels(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainedModelsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectTrainedModel> GetTrainedModelsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingConfigVersion> GetTrainingConfigVersions(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingConfigVersions(string projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingConfigVersion> GetTrainingConfigVersionsAsync(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingConfigVersionsAsync(string projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingJobs(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingState> GetTrainingJobs(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingJobsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingState> GetTrainingJobsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConversationAnalysisAuthoringClientOptions : Azure.Core.ClientOptions
    {
        public ConversationAnalysisAuthoringClientOptions(Azure.AI.Language.Conversations.Authoring.ConversationAnalysisAuthoringClientOptions.ServiceVersion version = Azure.AI.Language.Conversations.Authoring.ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview) { }
        public enum ServiceVersion
        {
            V2023_04_01 = 1,
            V2023_04_15_Preview = 2,
            V2024_11_15_Preview = 3,
            V2025_05_15_Preview = 4,
        }
    }
    public static partial class ConversationAnalysisAuthoringModelFactory
    {
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedDeploymentResource ConversationAuthoringAssignedDeploymentResource(Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.AzureLocation region = default(Azure.Core.AzureLocation)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentMetadata ConversationAuthoringAssignedProjectDeploymentMetadata(string deploymentName = null, System.DateTimeOffset lastDeployedOn = default(System.DateTimeOffset), System.DateTimeOffset deploymentExpiresOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentsMetadata ConversationAuthoringAssignedProjectDeploymentsMetadata(string projectName = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentMetadata> deploymentsMetadata = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixCell ConversationAuthoringConfusionMatrixCell(float normalizedValue = 0f, float rawValue = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow ConversationAuthoringConfusionMatrixRow(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectState ConversationAuthoringCopyProjectState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateDeploymentDetails ConversationAuthoringCreateDeploymentDetails(string trainedModelLabel = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResource> assignedResources = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateProjectDetails ConversationAuthoringCreateProjectDetails(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectSettings settings = null, string storageInputContainerName = null, string projectName = null, bool? multilingual = default(bool?), string description = null, string language = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentDeleteFromResourcesState ConversationAuthoringDeploymentDeleteFromResourcesState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResourcesState ConversationAuthoringDeploymentResourcesState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentState ConversationAuthoringDeploymentState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEntityEvalSummary ConversationAuthoringEntityEvalSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvalSummary ConversationAuthoringEvalSummary(Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary entitiesEvaluation = null, Azure.AI.Language.Conversations.Authoring.IntentsEvaluationSummary intentsEvaluation = null, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails evaluationOptions = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationJobResult ConversationAuthoringEvaluationJobResult(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails evaluationDetails = null, string modelLabel = null, string trainingConfigVersion = null, int percentComplete = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationState ConversationAuthoringEvaluationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationJobResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelState ConversationAuthoringExportedModelState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProject ConversationAuthoringExportedProject(string projectFileVersion = null, Azure.AI.Language.Conversations.Authoring.StringIndexType stringIndexType = default(Azure.AI.Language.Conversations.Authoring.StringIndexType), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateProjectDetails metadata = null, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectAsset assets = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedTrainedModel ConversationAuthoringExportedTrainedModel(string exportedModelName = null, string modelId = null, System.DateTimeOffset lastTrainedOn = default(System.DateTimeOffset), System.DateTimeOffset lastExportedModelOn = default(System.DateTimeOffset), System.DateTimeOffset modelExpiredOn = default(System.DateTimeOffset), string modelTrainingConfigVersion = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportProjectState ConversationAuthoringExportProjectState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null, string resultUri = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringImportProjectState ConversationAuthoringImportProjectState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringLoadSnapshotState ConversationAuthoringLoadSnapshotState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringPrebuiltEntity ConversationAuthoringPrebuiltEntity(string category = null, string description = null, string examples = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeletionState ConversationAuthoringProjectDeletionState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeployment ConversationAuthoringProjectDeployment(string deploymentName = null, string modelId = null, System.DateTimeOffset lastTrainedOn = default(System.DateTimeOffset), System.DateTimeOffset lastDeployedOn = default(System.DateTimeOffset), System.DateTimeOffset deploymentExpiredOn = default(System.DateTimeOffset), string modelTrainingConfigVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResource> assignedResources = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectMetadata ConversationAuthoringProjectMetadata(System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastModifiedOn = default(System.DateTimeOffset), System.DateTimeOffset? lastTrainedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastDeployedOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectSettings settings = null, string storageInputContainerName = null, string projectName = null, bool? multilingual = default(bool?), string description = null, string language = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectTrainedModel ConversationAuthoringProjectTrainedModel(string label = null, string modelId = null, System.DateTimeOffset lastTrainedOn = default(System.DateTimeOffset), int lastTrainingDurationInSeconds = 0, System.DateTimeOffset modelExpiredOn = default(System.DateTimeOffset), string modelTrainingConfigVersion = null, bool hasSnapshot = false) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState ConversationAuthoringSubTrainingState(int percentComplete = 0, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSupportedLanguage ConversationAuthoringSupportedLanguage(string languageName = null, string languageCode = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsState ConversationAuthoringSwapDeploymentsState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingConfigVersion ConversationAuthoringTrainingConfigVersion(string trainingConfigVersion = null, System.DateTimeOffset modelExpirationDate = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobDetails ConversationAuthoringTrainingJobDetails(string modelLabel = null, string trainingConfigVersion = null, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode trainingMode = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails evaluationOptions = null, Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationSettings dataGenerationSettings = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult ConversationAuthoringTrainingJobResult(string modelLabel = null, string trainingConfigVersion = null, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode? trainingMode = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState trainingStatus = null, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState dataGenerationStatus = null, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState evaluationStatus = null, System.DateTimeOffset? estimatedEndOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingState ConversationAuthoringTrainingState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationExportedEntity ConversationExportedEntity(string category = null, string description = null, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode? compositionMode = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityList entities = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedPrebuiltEntity> prebuilts = null, Azure.AI.Language.Conversations.Authoring.ExportedEntityRegex regex = null, System.Collections.Generic.IEnumerable<string> requiredComponents = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent ConversationExportedIntent(string category = null, string description = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.ConversationExportedAssociatedEntityLabel> associatedEntities = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationExportedUtterance ConversationExportedUtterance(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.ExportedUtteranceEntityLabel> entities = null, string text = null, string language = null, string intent = null, Azure.AI.Language.Conversations.Authoring.DatasetType? dataset = default(Azure.AI.Language.Conversations.Authoring.DatasetType?)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary EntitiesEvaluationSummary(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow> confusionMatrix = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEntityEvalSummary> entities = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestrationDetails ExportedConversationOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestration conversationOrchestration = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestration ExportedLuisOrchestration(System.Guid appId = default(System.Guid), string appVersion = null, string slotName = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestrationDetails ExportedLuisOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestration luisOrchestration = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestrationDetails ExportedQuestionAnsweringOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestration questionAnsweringOrchestration = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.IntentEvaluationSummary IntentEvaluationSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.IntentsEvaluationSummary IntentsEvaluationSummary(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow> confusionMatrix = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.IntentEvaluationSummary> intents = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent OrchestrationExportedIntent(Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails orchestration = null, string category = null, string description = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.OrchestrationExportedUtterance OrchestrationExportedUtterance(string text = null, string language = null, string intent = null, string dataset = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.UtteranceEntitiesEvaluationResult UtteranceEntitiesEvaluationResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult> expectedEntities = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult> predictedEntities = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult UtteranceEntityEvaluationResult(string category = null, int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.UtteranceEvaluationResult UtteranceEvaluationResult(string text = null, string language = null, Azure.AI.Language.Conversations.Authoring.UtteranceEntitiesEvaluationResult entitiesResult = null, Azure.AI.Language.Conversations.Authoring.UtteranceIntentsEvaluationResult intentsResult = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.UtteranceIntentsEvaluationResult UtteranceIntentsEvaluationResult(string expectedIntent = null, string predictedIntent = null) { throw null; }
    }
    public partial class ConversationAuthoringAssignDeploymentResourcesDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignDeploymentResourcesDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignDeploymentResourcesDetails>
    {
        public ConversationAuthoringAssignDeploymentResourcesDetails(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringResourceMetadata> metadata) { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringResourceMetadata> Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignDeploymentResourcesDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignDeploymentResourcesDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignDeploymentResourcesDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignDeploymentResourcesDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignDeploymentResourcesDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignDeploymentResourcesDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignDeploymentResourcesDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringAssignedDeploymentResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedDeploymentResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedDeploymentResource>
    {
        internal ConversationAuthoringAssignedDeploymentResource() { }
        public Azure.Core.AzureLocation Region { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedDeploymentResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedDeploymentResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedDeploymentResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedDeploymentResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedDeploymentResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedDeploymentResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedDeploymentResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringAssignedProjectDeploymentMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentMetadata>
    {
        internal ConversationAuthoringAssignedProjectDeploymentMetadata() { }
        public System.DateTimeOffset DeploymentExpiresOn { get { throw null; } }
        public string DeploymentName { get { throw null; } }
        public System.DateTimeOffset LastDeployedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringAssignedProjectDeploymentsMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentsMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentsMetadata>
    {
        internal ConversationAuthoringAssignedProjectDeploymentsMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentMetadata> DeploymentsMetadata { get { throw null; } }
        public string ProjectName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentsMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentsMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentsMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentsMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentsMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentsMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignedProjectDeploymentsMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConversationAuthoringCompositionMode : System.IEquatable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConversationAuthoringCompositionMode(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode CombineComponents { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode RequireExactOverlap { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode ReturnLongestOverlap { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode SeparateComponents { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode left, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode left, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConversationAuthoringConfusionMatrixCell : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixCell>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixCell>
    {
        internal ConversationAuthoringConfusionMatrixCell() { }
        public float NormalizedValue { get { throw null; } }
        public float RawValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixCell System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixCell>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixCell>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixCell System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixCell>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixCell>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixCell>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringConfusionMatrixRow : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow>
    {
        internal ConversationAuthoringConfusionMatrixRow() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringCopyProjectDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectDetails>
    {
        public ConversationAuthoringCopyProjectDetails(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, string targetProjectName, string accessToken, System.DateTimeOffset expiresAt, string targetResourceId, string targetResourceRegion) { }
        public string AccessToken { get { throw null; } set { } }
        public System.DateTimeOffset ExpiresAt { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind ProjectKind { get { throw null; } set { } }
        public string TargetProjectName { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TargetResourceRegion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringCopyProjectState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectState>
    {
        internal ConversationAuthoringCopyProjectState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringCreateDeploymentDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateDeploymentDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateDeploymentDetails>
    {
        public ConversationAuthoringCreateDeploymentDetails(string trainedModelLabel) { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResource> AssignedResources { get { throw null; } }
        public string TrainedModelLabel { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateDeploymentDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateDeploymentDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateDeploymentDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateDeploymentDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateDeploymentDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateDeploymentDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateDeploymentDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringCreateProjectDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateProjectDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateProjectDetails>
    {
        public ConversationAuthoringCreateProjectDetails(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, string language) { }
        public ConversationAuthoringCreateProjectDetails(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, string projectName, string language) { }
        public string Description { get { throw null; } set { } }
        public string Language { get { throw null; } }
        public bool? Multilingual { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind ProjectKind { get { throw null; } }
        public string ProjectName { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectSettings Settings { get { throw null; } set { } }
        public string StorageInputContainerName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateProjectDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateProjectDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateProjectDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateProjectDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateProjectDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateProjectDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateProjectDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringDeleteDeploymentDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeleteDeploymentDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeleteDeploymentDetails>
    {
        public ConversationAuthoringDeleteDeploymentDetails() { }
        public System.Collections.Generic.IList<string> AssignedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeleteDeploymentDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeleteDeploymentDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeleteDeploymentDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeleteDeploymentDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeleteDeploymentDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeleteDeploymentDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeleteDeploymentDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringDeployment
    {
        public readonly string _deploymentName;
        public readonly string _projectName;
        protected ConversationAuthoringDeployment() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation DeleteDeployment(Azure.WaitUntil waitUntil, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation DeleteDeployment(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentAsync(Azure.WaitUntil waitUntil, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeleteDeploymentFromResources(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeleteDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeleteDeploymentFromResources(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentFromResourcesAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeleteDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentFromResourcesAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeployProject(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeployProject(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployProjectAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployProjectAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeployment(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeployment> GetDeployment(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeployment>> GetDeploymentAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeploymentDeleteFromResourcesStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentDeleteFromResourcesState> GetDeploymentDeleteFromResourcesStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentDeleteFromResourcesStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentDeleteFromResourcesState>> GetDeploymentDeleteFromResourcesStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeploymentStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentState> GetDeploymentStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentState>> GetDeploymentStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConversationAuthoringDeploymentDeleteFromResourcesState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentDeleteFromResourcesState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentDeleteFromResourcesState>
    {
        internal ConversationAuthoringDeploymentDeleteFromResourcesState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentDeleteFromResourcesState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentDeleteFromResourcesState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentDeleteFromResourcesState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentDeleteFromResourcesState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentDeleteFromResourcesState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentDeleteFromResourcesState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentDeleteFromResourcesState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringDeploymentResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResource>
    {
        public ConversationAuthoringDeploymentResource(string resourceId, string region) { }
        public Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationConnectionInfo AssignedAoaiResource { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringDeploymentResourcesState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResourcesState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResourcesState>
    {
        internal ConversationAuthoringDeploymentResourcesState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResourcesState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResourcesState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResourcesState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResourcesState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResourcesState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResourcesState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResourcesState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringDeploymentState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentState>
    {
        internal ConversationAuthoringDeploymentState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringEntityEvalSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEntityEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEntityEvalSummary>
    {
        internal ConversationAuthoringEntityEvalSummary() { }
        public double F1 { get { throw null; } }
        public int FalseNegativeCount { get { throw null; } }
        public int FalsePositiveCount { get { throw null; } }
        public double Precision { get { throw null; } }
        public double Recall { get { throw null; } }
        public int TrueNegativeCount { get { throw null; } }
        public int TruePositiveCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEntityEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEntityEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEntityEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEntityEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEntityEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEntityEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEntityEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringEvalSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvalSummary>
    {
        internal ConversationAuthoringEvalSummary() { }
        public Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary EntitiesEvaluation { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails EvaluationOptions { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.IntentsEvaluationSummary IntentsEvaluation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringEvaluationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails>
    {
        public ConversationAuthoringEvaluationDetails() { }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationKind? Kind { get { throw null; } set { } }
        public int? TestingSplitPercentage { get { throw null; } set { } }
        public int? TrainingSplitPercentage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringEvaluationJobResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationJobResult>
    {
        internal ConversationAuthoringEvaluationJobResult() { }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails EvaluationDetails { get { throw null; } }
        public string ModelLabel { get { throw null; } }
        public int PercentComplete { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationJobResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationJobResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConversationAuthoringEvaluationKind : System.IEquatable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConversationAuthoringEvaluationKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationKind Manual { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationKind Percentage { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationKind left, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationKind left, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConversationAuthoringEvaluationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationState>
    {
        internal ConversationAuthoringEvaluationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationJobResult Result { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringExportedEntityList : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityList>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityList>
    {
        public ConversationAuthoringExportedEntityList() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntitySublist> Sublists { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityList System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityList System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringExportedEntityListSynonym : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityListSynonym>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityListSynonym>
    {
        public ConversationAuthoringExportedEntityListSynonym() { }
        public string Language { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityListSynonym System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityListSynonym>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityListSynonym>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityListSynonym System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityListSynonym>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityListSynonym>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityListSynonym>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringExportedEntitySublist : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntitySublist>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntitySublist>
    {
        public ConversationAuthoringExportedEntitySublist() { }
        public string ListKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityListSynonym> Synonyms { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntitySublist System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntitySublist>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntitySublist>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntitySublist System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntitySublist>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntitySublist>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntitySublist>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringExportedModel
    {
        public readonly string _exportedModelName;
        public readonly string _projectName;
        protected ConversationAuthoringExportedModel() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation CreateOrUpdateExportedModel(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CreateOrUpdateExportedModel(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateOrUpdateExportedModelAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateOrUpdateExportedModelAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteExportedModel(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteExportedModel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteExportedModelAsync(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteExportedModelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportedModel(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedTrainedModel> GetExportedModel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportedModelAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedTrainedModel>> GetExportedModelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportedModelJobStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelState> GetExportedModelJobStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportedModelJobStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelState>> GetExportedModelJobStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConversationAuthoringExportedModelDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelDetails>
    {
        public ConversationAuthoringExportedModelDetails(string trainedModelLabel) { }
        public string TrainedModelLabel { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringExportedModelState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelState>
    {
        internal ConversationAuthoringExportedModelState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModelState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringExportedPrebuiltEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedPrebuiltEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedPrebuiltEntity>
    {
        public ConversationAuthoringExportedPrebuiltEntity(string category) { }
        public string Category { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedPrebuiltEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedPrebuiltEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedPrebuiltEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedPrebuiltEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedPrebuiltEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedPrebuiltEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedPrebuiltEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringExportedProject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProject>
    {
        public ConversationAuthoringExportedProject(string projectFileVersion, Azure.AI.Language.Conversations.Authoring.StringIndexType stringIndexType, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateProjectDetails metadata) { }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectAsset Assets { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateProjectDetails Metadata { get { throw null; } }
        public string ProjectFileVersion { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.StringIndexType StringIndexType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProject System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ConversationAuthoringExportedProjectAsset : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectAsset>
    {
        protected ConversationAuthoringExportedProjectAsset() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectAsset System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectAsset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConversationAuthoringExportedProjectFormat : System.IEquatable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConversationAuthoringExportedProjectFormat(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat Conversation { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat Luis { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat left, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat left, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConversationAuthoringExportedTrainedModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedTrainedModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedTrainedModel>
    {
        internal ConversationAuthoringExportedTrainedModel() { }
        public string ExportedModelName { get { throw null; } }
        public System.DateTimeOffset LastExportedModelOn { get { throw null; } }
        public System.DateTimeOffset LastTrainedOn { get { throw null; } }
        public System.DateTimeOffset ModelExpiredOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ModelTrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedTrainedModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedTrainedModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedTrainedModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedTrainedModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedTrainedModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedTrainedModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedTrainedModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringExportProjectState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportProjectState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportProjectState>
    {
        internal ConversationAuthoringExportProjectState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public string ResultUri { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportProjectState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportProjectState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportProjectState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportProjectState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportProjectState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportProjectState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportProjectState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringImportProjectState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringImportProjectState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringImportProjectState>
    {
        internal ConversationAuthoringImportProjectState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringImportProjectState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringImportProjectState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringImportProjectState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringImportProjectState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringImportProjectState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringImportProjectState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringImportProjectState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringLoadSnapshotState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringLoadSnapshotState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringLoadSnapshotState>
    {
        internal ConversationAuthoringLoadSnapshotState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringLoadSnapshotState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringLoadSnapshotState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringLoadSnapshotState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringLoadSnapshotState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringLoadSnapshotState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringLoadSnapshotState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringLoadSnapshotState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConversationAuthoringOperationStatus : System.IEquatable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConversationAuthoringOperationStatus(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Cancelled { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Cancelling { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Failed { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus NotStarted { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus PartiallyCompleted { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Running { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus left, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus left, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConversationAuthoringPrebuiltEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringPrebuiltEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringPrebuiltEntity>
    {
        internal ConversationAuthoringPrebuiltEntity() { }
        public string Category { get { throw null; } }
        public string Description { get { throw null; } }
        public string Examples { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringPrebuiltEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringPrebuiltEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringPrebuiltEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringPrebuiltEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringPrebuiltEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringPrebuiltEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringPrebuiltEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringProject
    {
        public readonly string _projectName;
        protected ConversationAuthoringProject() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation AssignDeploymentResources(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation AssignDeploymentResources(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AssignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringAssignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AssignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectDetails> AuthorizeProjectCopy(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AuthorizeProjectCopy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectDetails>> AuthorizeProjectCopyAsync(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AuthorizeProjectCopyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CancelTrainingJob(Azure.WaitUntil waitUntil, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult> CancelTrainingJob(Azure.WaitUntil waitUntil, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CancelTrainingJobAsync(Azure.WaitUntil waitUntil, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult>> CancelTrainingJobAsync(Azure.WaitUntil waitUntil, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CopyProject(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CopyProject(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CopyProjectAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CopyProjectAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateProject(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateProjectDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateProject(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateProjectAsync(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCreateProjectDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateProjectAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteProject(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteProjectAsync(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.StringIndexType stringIndexType, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat?), string assetKind = null, string trainedModelLabel = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, string stringIndexType, string exportedProjectFormat = null, string assetKind = null, string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.StringIndexType stringIndexType, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat?), string assetKind = null, string trainedModelLabel = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, string stringIndexType, string exportedProjectFormat = null, string assetKind = null, string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAssignDeploymentResourcesStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResourcesState> GetAssignDeploymentResourcesStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssignDeploymentResourcesStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResourcesState>> GetAssignDeploymentResourcesStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCopyProjectStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectState> GetCopyProjectStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCopyProjectStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCopyProjectState>> GetCopyProjectStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportProjectState> GetExportStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportProjectState>> GetExportStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetImportStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringImportProjectState> GetImportStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetImportStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringImportProjectState>> GetImportStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProject(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectMetadata> GetProject(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectMetadata>> GetProjectAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProjectDeletionStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeletionState> GetProjectDeletionStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectDeletionStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeletionState>> GetProjectDeletionStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSwapDeploymentsStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsState> GetSwapDeploymentsStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSwapDeploymentsStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsState>> GetSwapDeploymentsStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTrainingStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingState> GetTrainingStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainingStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingState>> GetTrainingStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUnassignDeploymentResourcesStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResourcesState> GetUnassignDeploymentResourcesStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUnassignDeploymentResourcesStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResourcesState>> GetUnassignDeploymentResourcesStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProject exportedProject, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat? projectFormat = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string projectFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, string projectJson, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat? projectFormat = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProject exportedProject, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat? projectFormat = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string projectFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, string projectJson, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat? projectFormat = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation SwapDeployments(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation SwapDeployments(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> SwapDeploymentsAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> SwapDeploymentsAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult> Train(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Train(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult>> TrainAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> TrainAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation UnassignDeploymentResources(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringUnassignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation UnassignDeploymentResources(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UnassignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringUnassignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UnassignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ConversationAuthoringProjectDeletionState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeletionState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeletionState>
    {
        internal ConversationAuthoringProjectDeletionState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeletionState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeletionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeletionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeletionState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeletionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeletionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeletionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringProjectDeployment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeployment>
    {
        internal ConversationAuthoringProjectDeployment() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeploymentResource> AssignedResources { get { throw null; } }
        public System.DateTimeOffset DeploymentExpiredOn { get { throw null; } }
        public string DeploymentName { get { throw null; } }
        public System.DateTimeOffset LastDeployedOn { get { throw null; } }
        public System.DateTimeOffset LastTrainedOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ModelTrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConversationAuthoringProjectKind : System.IEquatable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConversationAuthoringProjectKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind Conversation { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind CustomConversationSummarization { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind Orchestration { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind left, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind left, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConversationAuthoringProjectMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectMetadata>
    {
        internal ConversationAuthoringProjectMetadata() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string Language { get { throw null; } }
        public System.DateTimeOffset? LastDeployedOn { get { throw null; } }
        public System.DateTimeOffset LastModifiedOn { get { throw null; } }
        public System.DateTimeOffset? LastTrainedOn { get { throw null; } }
        public bool? Multilingual { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind ProjectKind { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectSettings Settings { get { throw null; } }
        public string StorageInputContainerName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringProjectSettings : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectSettings>
    {
        public ConversationAuthoringProjectSettings(float confidenceThreshold) { }
        public float ConfidenceThreshold { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectSettings System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectSettings System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringProjectTrainedModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectTrainedModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectTrainedModel>
    {
        internal ConversationAuthoringProjectTrainedModel() { }
        public bool HasSnapshot { get { throw null; } }
        public string Label { get { throw null; } }
        public System.DateTimeOffset LastTrainedOn { get { throw null; } }
        public int LastTrainingDurationInSeconds { get { throw null; } }
        public System.DateTimeOffset ModelExpiredOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ModelTrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectTrainedModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectTrainedModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectTrainedModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectTrainedModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectTrainedModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectTrainedModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectTrainedModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringResourceMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringResourceMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringResourceMetadata>
    {
        public ConversationAuthoringResourceMetadata(string azureResourceId, string customDomain, string region) { }
        public string AzureResourceId { get { throw null; } }
        public string CustomDomain { get { throw null; } }
        public string Region { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringResourceMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringResourceMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringResourceMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringResourceMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringResourceMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringResourceMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringResourceMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringSubTrainingState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState>
    {
        internal ConversationAuthoringSubTrainingState() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public int PercentComplete { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringSupportedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSupportedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSupportedLanguage>
    {
        internal ConversationAuthoringSupportedLanguage() { }
        public string LanguageCode { get { throw null; } }
        public string LanguageName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSupportedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSupportedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSupportedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSupportedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSupportedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSupportedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSupportedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringSwapDeploymentsDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsDetails>
    {
        public ConversationAuthoringSwapDeploymentsDetails(string firstDeploymentName, string secondDeploymentName) { }
        public string FirstDeploymentName { get { throw null; } }
        public string SecondDeploymentName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringSwapDeploymentsState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsState>
    {
        internal ConversationAuthoringSwapDeploymentsState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSwapDeploymentsState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringTrainedModel
    {
        public readonly string _projectName;
        public readonly string _trainedModelLabel;
        protected ConversationAuthoringTrainedModel() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteTrainedModel(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteTrainedModel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTrainedModelAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTrainedModelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationJobResult> EvaluateModel(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> EvaluateModel(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationJobResult>> EvaluateModelAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> EvaluateModelAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEvaluationStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationState> GetEvaluationStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEvaluationStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationState>> GetEvaluationStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLoadSnapshotStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringLoadSnapshotState> GetLoadSnapshotStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLoadSnapshotStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringLoadSnapshotState>> GetLoadSnapshotStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.UtteranceEvaluationResult> GetModelEvaluationResults(Azure.AI.Language.Conversations.Authoring.StringIndexType stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetModelEvaluationResults(string stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.UtteranceEvaluationResult> GetModelEvaluationResultsAsync(Azure.AI.Language.Conversations.Authoring.StringIndexType stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetModelEvaluationResultsAsync(string stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetModelEvaluationSummary(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvalSummary> GetModelEvaluationSummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetModelEvaluationSummaryAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvalSummary>> GetModelEvaluationSummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTrainedModel(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectTrainedModel> GetTrainedModel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainedModelAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectTrainedModel>> GetTrainedModelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation LoadSnapshot(Azure.WaitUntil waitUntil, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation LoadSnapshot(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> LoadSnapshotAsync(Azure.WaitUntil waitUntil, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> LoadSnapshotAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConversationAuthoringTrainingConfigVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingConfigVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingConfigVersion>
    {
        internal ConversationAuthoringTrainingConfigVersion() { }
        public System.DateTimeOffset ModelExpirationDate { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingConfigVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingConfigVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingConfigVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingConfigVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingConfigVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingConfigVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingConfigVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringTrainingJobDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobDetails>
    {
        public ConversationAuthoringTrainingJobDetails(string modelLabel, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode trainingMode) { }
        public Azure.AI.Language.Conversations.Authoring.AnalyzeConversationAuthoringDataGenerationSettings DataGenerationSettings { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationDetails EvaluationOptions { get { throw null; } set { } }
        public string ModelLabel { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode TrainingMode { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringTrainingJobResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult>
    {
        internal ConversationAuthoringTrainingJobResult() { }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState DataGenerationStatus { get { throw null; } }
        public System.DateTimeOffset? EstimatedEndOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState EvaluationStatus { get { throw null; } }
        public string ModelLabel { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode? TrainingMode { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringSubTrainingState TrainingStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConversationAuthoringTrainingMode : System.IEquatable<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConversationAuthoringTrainingMode(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode Advanced { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode Standard { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode left, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode left, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConversationAuthoringTrainingState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingState>
    {
        internal ConversationAuthoringTrainingState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingJobResult Result { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationAuthoringUnassignDeploymentResourcesDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringUnassignDeploymentResourcesDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringUnassignDeploymentResourcesDetails>
    {
        public ConversationAuthoringUnassignDeploymentResourcesDetails(System.Collections.Generic.IEnumerable<string> assignedResourceIds) { }
        public System.Collections.Generic.IList<string> AssignedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringUnassignDeploymentResourcesDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringUnassignDeploymentResourcesDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringUnassignDeploymentResourcesDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationAuthoringUnassignDeploymentResourcesDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringUnassignDeploymentResourcesDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringUnassignDeploymentResourcesDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringUnassignDeploymentResourcesDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationExportedAssociatedEntityLabel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedAssociatedEntityLabel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedAssociatedEntityLabel>
    {
        public ConversationExportedAssociatedEntityLabel(string category) { }
        public string Category { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationExportedAssociatedEntityLabel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedAssociatedEntityLabel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedAssociatedEntityLabel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationExportedAssociatedEntityLabel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedAssociatedEntityLabel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedAssociatedEntityLabel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedAssociatedEntityLabel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationExportedEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedEntity>
    {
        public ConversationExportedEntity(string category) { }
        public string Category { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode? CompositionMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedEntityList Entities { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedPrebuiltEntity> Prebuilts { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ExportedEntityRegex Regex { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredComponents { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationExportedEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationExportedEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationExportedIntent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent>
    {
        public ConversationExportedIntent(string category) { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.ConversationExportedAssociatedEntityLabel> AssociatedEntities { get { throw null; } }
        public string Category { get { throw null; } }
        public string Description { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationExportedProjectAsset : Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectAsset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedProjectAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedProjectAsset>
    {
        public ConversationExportedProjectAsset() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.ConversationExportedEntity> Entities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent> Intents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.ConversationExportedUtterance> Utterances { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationExportedProjectAsset System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedProjectAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedProjectAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationExportedProjectAsset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedProjectAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedProjectAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedProjectAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationExportedUtterance : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedUtterance>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedUtterance>
    {
        public ConversationExportedUtterance(string text, string intent) { }
        public Azure.AI.Language.Conversations.Authoring.DatasetType? Dataset { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.ExportedUtteranceEntityLabel> Entities { get { throw null; } }
        public string Intent { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationExportedUtterance System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedUtterance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedUtterance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationExportedUtterance System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedUtterance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedUtterance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedUtterance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatasetType : System.IEquatable<Azure.AI.Language.Conversations.Authoring.DatasetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatasetType(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.DatasetType Test { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.DatasetType Train { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.DatasetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.DatasetType left, Azure.AI.Language.Conversations.Authoring.DatasetType right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.DatasetType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.DatasetType left, Azure.AI.Language.Conversations.Authoring.DatasetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntitiesEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary>
    {
        internal EntitiesEvaluationSummary() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow> ConfusionMatrix { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEntityEvalSummary> Entities { get { throw null; } }
        public float MacroF1 { get { throw null; } }
        public float MacroPrecision { get { throw null; } }
        public float MacroRecall { get { throw null; } }
        public float MicroF1 { get { throw null; } }
        public float MicroPrecision { get { throw null; } }
        public float MicroRecall { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedConversationOrchestration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestration>
    {
        public ExportedConversationOrchestration(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public string ProjectName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestration System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedConversationOrchestrationDetails : Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestrationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestrationDetails>
    {
        public ExportedConversationOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestration conversationOrchestration) { }
        public Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestration ConversationOrchestration { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestrationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestrationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestrationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestrationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestrationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestrationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestrationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedEntityRegex : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityRegex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityRegex>
    {
        public ExportedEntityRegex() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.ExportedEntityRegexExpression> Expressions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedEntityRegex System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityRegex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityRegex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedEntityRegex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityRegex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityRegex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityRegex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedEntityRegexExpression : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityRegexExpression>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityRegexExpression>
    {
        public ExportedEntityRegexExpression() { }
        public string Language { get { throw null; } set { } }
        public string RegexKey { get { throw null; } set { } }
        public string RegexPattern { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedEntityRegexExpression System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityRegexExpression>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityRegexExpression>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedEntityRegexExpression System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityRegexExpression>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityRegexExpression>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityRegexExpression>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedLuisOrchestration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestration>
    {
        public ExportedLuisOrchestration(System.Guid appId) { }
        public System.Guid AppId { get { throw null; } }
        public string AppVersion { get { throw null; } set { } }
        public string SlotName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestration System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedLuisOrchestrationDetails : Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestrationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestrationDetails>
    {
        public ExportedLuisOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestration luisOrchestration) { }
        public Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestration LuisOrchestration { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestrationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestrationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestrationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestrationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestrationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestrationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestrationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ExportedOrchestrationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails>
    {
        protected ExportedOrchestrationDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedQuestionAnsweringOrchestration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestration>
    {
        public ExportedQuestionAnsweringOrchestration(string projectName) { }
        public string ProjectName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestration System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedQuestionAnsweringOrchestrationDetails : Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestrationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestrationDetails>
    {
        public ExportedQuestionAnsweringOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestration questionAnsweringOrchestration) { }
        public Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestration QuestionAnsweringOrchestration { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestrationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestrationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestrationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestrationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestrationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestrationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestrationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedUtteranceEntityLabel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedUtteranceEntityLabel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedUtteranceEntityLabel>
    {
        public ExportedUtteranceEntityLabel(string category, int offset, int length) { }
        public string Category { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedUtteranceEntityLabel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedUtteranceEntityLabel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedUtteranceEntityLabel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedUtteranceEntityLabel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedUtteranceEntityLabel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedUtteranceEntityLabel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedUtteranceEntityLabel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntentEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.IntentEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.IntentEvaluationSummary>
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
        Azure.AI.Language.Conversations.Authoring.IntentEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.IntentEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.IntentEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.IntentEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.IntentEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.IntentEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.IntentEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntentsEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.IntentsEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.IntentsEvaluationSummary>
    {
        internal IntentsEvaluationSummary() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow> ConfusionMatrix { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.IntentEvaluationSummary> Intents { get { throw null; } }
        public float MacroF1 { get { throw null; } }
        public float MacroPrecision { get { throw null; } }
        public float MacroRecall { get { throw null; } }
        public float MicroF1 { get { throw null; } }
        public float MicroPrecision { get { throw null; } }
        public float MicroRecall { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.IntentsEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.IntentsEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.IntentsEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.IntentsEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.IntentsEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.IntentsEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.IntentsEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrchestrationExportedIntent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent>
    {
        public OrchestrationExportedIntent(string category) { }
        public string Category { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails Orchestration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrchestrationExportedProjectAsset : Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectAsset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedProjectAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedProjectAsset>
    {
        public OrchestrationExportedProjectAsset() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent> Intents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedUtterance> Utterances { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.OrchestrationExportedProjectAsset System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedProjectAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedProjectAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.OrchestrationExportedProjectAsset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedProjectAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedProjectAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedProjectAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrchestrationExportedUtterance : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedUtterance>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedUtterance>
    {
        public OrchestrationExportedUtterance(string text, string intent) { }
        public string Dataset { get { throw null; } set { } }
        public string Intent { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.OrchestrationExportedUtterance System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedUtterance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedUtterance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.OrchestrationExportedUtterance System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedUtterance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedUtterance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedUtterance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StringIndexType : System.IEquatable<Azure.AI.Language.Conversations.Authoring.StringIndexType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StringIndexType(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.StringIndexType Utf16CodeUnit { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.StringIndexType Utf32CodeUnit { get { throw null; } }
        public static Azure.AI.Language.Conversations.Authoring.StringIndexType Utf8CodeUnit { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Authoring.StringIndexType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Authoring.StringIndexType left, Azure.AI.Language.Conversations.Authoring.StringIndexType right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Authoring.StringIndexType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Authoring.StringIndexType left, Azure.AI.Language.Conversations.Authoring.StringIndexType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UtteranceEntitiesEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.UtteranceEntitiesEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceEntitiesEvaluationResult>
    {
        internal UtteranceEntitiesEvaluationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult> ExpectedEntities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult> PredictedEntities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.UtteranceEntitiesEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.UtteranceEntitiesEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.UtteranceEntitiesEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.UtteranceEntitiesEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceEntitiesEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceEntitiesEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceEntitiesEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UtteranceEntityEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult>
    {
        internal UtteranceEntityEvaluationResult() { }
        public string Category { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UtteranceEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.UtteranceEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceEvaluationResult>
    {
        internal UtteranceEvaluationResult() { }
        public Azure.AI.Language.Conversations.Authoring.UtteranceEntitiesEvaluationResult EntitiesResult { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.UtteranceIntentsEvaluationResult IntentsResult { get { throw null; } }
        public string Language { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.UtteranceEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.UtteranceEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.UtteranceEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.UtteranceEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UtteranceIntentsEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.UtteranceIntentsEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceIntentsEvaluationResult>
    {
        internal UtteranceIntentsEvaluationResult() { }
        public string ExpectedIntent { get { throw null; } }
        public string PredictedIntent { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.UtteranceIntentsEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.UtteranceIntentsEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.UtteranceIntentsEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.UtteranceIntentsEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceIntentsEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceIntentsEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UtteranceIntentsEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
