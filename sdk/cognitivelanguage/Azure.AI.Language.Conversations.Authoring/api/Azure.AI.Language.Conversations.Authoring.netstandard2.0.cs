namespace Azure.AI.Language.Conversations.Authoring
{
    public partial class AssignDeploymentResourcesDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AssignDeploymentResourcesDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignDeploymentResourcesDetails>
    {
        public AssignDeploymentResourcesDetails(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.ResourceMetadata> metadata) { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.ResourceMetadata> Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.AssignDeploymentResourcesDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AssignDeploymentResourcesDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AssignDeploymentResourcesDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.AssignDeploymentResourcesDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignDeploymentResourcesDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignDeploymentResourcesDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignDeploymentResourcesDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssignedDeploymentResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AssignedDeploymentResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignedDeploymentResource>
    {
        internal AssignedDeploymentResource() { }
        public Azure.Core.AzureLocation Region { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.AssignedDeploymentResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AssignedDeploymentResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AssignedDeploymentResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.AssignedDeploymentResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignedDeploymentResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignedDeploymentResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignedDeploymentResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssignedProjectDeploymentMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentMetadata>
    {
        internal AssignedProjectDeploymentMetadata() { }
        public System.DateTimeOffset DeploymentExpiresOn { get { throw null; } }
        public string DeploymentName { get { throw null; } }
        public System.DateTimeOffset LastDeployedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssignedProjectDeploymentsMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentsMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentsMetadata>
    {
        internal AssignedProjectDeploymentsMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentMetadata> DeploymentsMetadata { get { throw null; } }
        public string ProjectName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentsMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentsMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentsMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentsMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentsMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentsMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentsMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentsMetadata> GetAssignedResourceDeployments(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAssignedResourceDeploymentsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentsMetadata> GetAssignedResourceDeploymentsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Language.Conversations.Authoring.ConversationAuthoringDeployment GetDeployment(string projectName, string deploymentName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeploymentResources(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.AssignedDeploymentResource> GetDeploymentResources(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentResourcesAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.AssignedDeploymentResource> GetDeploymentResourcesAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeployments(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.ProjectDeployment> GetDeployments(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.ProjectDeployment> GetDeploymentsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedModel GetExportedModel(string projectName, string exportedModelName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetExportedModels(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.ExportedTrainedModel> GetExportedModels(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetExportedModelsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.ExportedTrainedModel> GetExportedModelsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProject GetProject(string projectName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProjects(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.ProjectMetadata> GetProjects(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.ProjectMetadata> GetProjectsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.SupportedLanguage> GetSupportedLanguages(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedLanguages(string projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.SupportedLanguage> GetSupportedLanguagesAsync(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedLanguagesAsync(string projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedPrebuiltEntities(int? maxCount, int? skip, int? maxpagesize, string language, string multilingual, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.PrebuiltEntity> GetSupportedPrebuiltEntities(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), string language = null, string multilingual = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedPrebuiltEntitiesAsync(int? maxCount, int? skip, int? maxpagesize, string language, string multilingual, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.PrebuiltEntity> GetSupportedPrebuiltEntitiesAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), string language = null, string multilingual = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainedModel GetTrainedModel(string projectName, string trainedModelLabel) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainedModels(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.ProjectTrainedModel> GetTrainedModels(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainedModelsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.ProjectTrainedModel> GetTrainedModelsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.TrainingConfigVersion> GetTrainingConfigVersions(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingConfigVersions(string projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.TrainingConfigVersion> GetTrainingConfigVersionsAsync(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingConfigVersionsAsync(string projectKind, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingJobs(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.TrainingOperationState> GetTrainingJobs(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingJobsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.TrainingOperationState> GetTrainingJobsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Operation DeleteDeploymentFromResources(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.DeleteDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeleteDeploymentFromResources(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentFromResourcesAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.DeleteDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentFromResourcesAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeployProject(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.CreateDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeployProject(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployProjectAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.CreateDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployProjectAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeployment(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ProjectDeployment> GetDeployment(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ProjectDeployment>> GetDeploymentAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeploymentDeleteFromResourcesStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.DeploymentDeleteFromResourcesOperationState> GetDeploymentDeleteFromResourcesStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentDeleteFromResourcesStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.DeploymentDeleteFromResourcesOperationState>> GetDeploymentDeleteFromResourcesStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeploymentStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.DeploymentOperationState> GetDeploymentStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.DeploymentOperationState>> GetDeploymentStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ConversationAuthoringExportedModel
    {
        public readonly string _exportedModelName;
        public readonly string _projectName;
        protected ConversationAuthoringExportedModel() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation CreateOrUpdateExportedModel(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ExportedModelDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CreateOrUpdateExportedModel(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateOrUpdateExportedModelAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ExportedModelDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateOrUpdateExportedModelAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteExportedModel(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteExportedModel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteExportedModelAsync(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteExportedModelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportedModel(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ExportedTrainedModel> GetExportedModel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportedModelAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ExportedTrainedModel>> GetExportedModelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportedModelJobStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ExportedModelOperationState> GetExportedModelJobStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportedModelJobStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ExportedModelOperationState>> GetExportedModelJobStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ConversationAuthoringProject
    {
        public readonly string _projectName;
        protected ConversationAuthoringProject() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation AssignDeploymentResources(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.AssignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation AssignDeploymentResources(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AssignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.AssignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AssignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.CopyProjectDetails> AuthorizeProjectCopy(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AuthorizeProjectCopy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.CopyProjectDetails>> AuthorizeProjectCopyAsync(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AuthorizeProjectCopyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CancelTrainingJob(Azure.WaitUntil waitUntil, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Conversations.Authoring.TrainingJobResult> CancelTrainingJob(Azure.WaitUntil waitUntil, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CancelTrainingJobAsync(Azure.WaitUntil waitUntil, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Conversations.Authoring.TrainingJobResult>> CancelTrainingJobAsync(Azure.WaitUntil waitUntil, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CopyProject(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.CopyProjectDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CopyProject(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CopyProjectAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.CopyProjectDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CopyProjectAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateProject(Azure.AI.Language.Conversations.Authoring.CreateProjectDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateProject(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateProjectAsync(Azure.AI.Language.Conversations.Authoring.CreateProjectDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateProjectAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteProject(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteProjectAsync(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.StringIndexType stringIndexType, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat?), string assetKind = null, string trainedModelLabel = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, string stringIndexType, string exportedProjectFormat = null, string assetKind = null, string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.StringIndexType stringIndexType, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat?), string assetKind = null, string trainedModelLabel = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, string stringIndexType, string exportedProjectFormat = null, string assetKind = null, string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAssignDeploymentResourcesStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.DeploymentResourcesOperationState> GetAssignDeploymentResourcesStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssignDeploymentResourcesStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.DeploymentResourcesOperationState>> GetAssignDeploymentResourcesStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCopyProjectStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.CopyProjectOperationState> GetCopyProjectStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCopyProjectStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.CopyProjectOperationState>> GetCopyProjectStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ExportProjectOperationState> GetExportStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ExportProjectOperationState>> GetExportStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetImportStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ImportProjectOperationState> GetImportStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetImportStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ImportProjectOperationState>> GetImportStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProject(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ProjectMetadata> GetProject(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ProjectMetadata>> GetProjectAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProjectDeletionStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ProjectDeletionOperationState> GetProjectDeletionStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectDeletionStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ProjectDeletionOperationState>> GetProjectDeletionStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSwapDeploymentsStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsOperationState> GetSwapDeploymentsStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSwapDeploymentsStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsOperationState>> GetSwapDeploymentsStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTrainingStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.TrainingOperationState> GetTrainingStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainingStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.TrainingOperationState>> GetTrainingStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUnassignDeploymentResourcesStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.DeploymentResourcesOperationState> GetUnassignDeploymentResourcesStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUnassignDeploymentResourcesStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.DeploymentResourcesOperationState>> GetUnassignDeploymentResourcesStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ExportedProject exportedProject, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string exportedProjectFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.ExportedProject exportedProject, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat? exportedProjectFormat = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringExportedProjectFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string exportedProjectFormat = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation SwapDeployments(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.SwapDeploymentsDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation SwapDeployments(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> SwapDeploymentsAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.SwapDeploymentsDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> SwapDeploymentsAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Conversations.Authoring.TrainingJobResult> Train(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.TrainingJobDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Train(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Conversations.Authoring.TrainingJobResult>> TrainAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.TrainingJobDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> TrainAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation UnassignDeploymentResources(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.UnassignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation UnassignDeploymentResources(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UnassignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.UnassignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UnassignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
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
        public virtual Azure.Operation<Azure.AI.Language.Conversations.Authoring.EvaluationJobResult> EvaluateModel(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.EvaluationDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> EvaluateModel(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Conversations.Authoring.EvaluationJobResult>> EvaluateModelAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Conversations.Authoring.EvaluationDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> EvaluateModelAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEvaluationStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.EvaluationOperationState> GetEvaluationStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEvaluationStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.EvaluationOperationState>> GetEvaluationStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLoadSnapshotStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.LoadSnapshotOperationState> GetLoadSnapshotStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLoadSnapshotStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.LoadSnapshotOperationState>> GetLoadSnapshotStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Conversations.Authoring.UtteranceEvaluationResult> GetModelEvaluationResults(Azure.AI.Language.Conversations.Authoring.StringIndexType stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetModelEvaluationResults(string stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Conversations.Authoring.UtteranceEvaluationResult> GetModelEvaluationResultsAsync(Azure.AI.Language.Conversations.Authoring.StringIndexType stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetModelEvaluationResultsAsync(string stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetModelEvaluationSummary(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.EvaluationSummary> GetModelEvaluationSummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetModelEvaluationSummaryAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.EvaluationSummary>> GetModelEvaluationSummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTrainedModel(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Authoring.ProjectTrainedModel> GetTrainedModel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainedModelAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Authoring.ProjectTrainedModel>> GetTrainedModelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation LoadSnapshot(Azure.WaitUntil waitUntil, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation LoadSnapshot(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> LoadSnapshotAsync(Azure.WaitUntil waitUntil, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> LoadSnapshotAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ConversationExportedEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedEntity>
    {
        public ConversationExportedEntity(string category) { }
        public string Category { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode? CompositionMode { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.ExportedEntityList Entities { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.ExportedPrebuiltEntity> Prebuilts { get { throw null; } }
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
        public string Category { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationExportedProjectAsset : Azure.AI.Language.Conversations.Authoring.ExportedProjectAsset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedProjectAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ConversationExportedProjectAsset>
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
    public partial class CopyProjectDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.CopyProjectDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CopyProjectDetails>
    {
        public CopyProjectDetails(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, string targetProjectName, string accessToken, System.DateTimeOffset expiresAt, string targetResourceId, string targetResourceRegion) { }
        public string AccessToken { get { throw null; } set { } }
        public System.DateTimeOffset ExpiresAt { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind ProjectKind { get { throw null; } set { } }
        public string TargetProjectName { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TargetResourceRegion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.CopyProjectDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.CopyProjectDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.CopyProjectDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.CopyProjectDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CopyProjectDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CopyProjectDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CopyProjectDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CopyProjectOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.CopyProjectOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CopyProjectOperationState>
    {
        internal CopyProjectOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.CopyProjectOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.CopyProjectOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.CopyProjectOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.CopyProjectOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CopyProjectOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CopyProjectOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CopyProjectOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateDeploymentDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.CreateDeploymentDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CreateDeploymentDetails>
    {
        public CreateDeploymentDetails(string trainedModelLabel) { }
        public System.Collections.Generic.IList<string> AssignedResourceIds { get { throw null; } }
        public string TrainedModelLabel { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.CreateDeploymentDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.CreateDeploymentDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.CreateDeploymentDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.CreateDeploymentDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CreateDeploymentDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CreateDeploymentDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CreateDeploymentDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateProjectDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.CreateProjectDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CreateProjectDetails>
    {
        public CreateProjectDetails(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind, string language) { }
        public string Description { get { throw null; } set { } }
        public string Language { get { throw null; } }
        public bool? Multilingual { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind ProjectKind { get { throw null; } }
        public string ProjectName { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.ProjectSettings Settings { get { throw null; } set { } }
        public string StorageInputContainerName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.CreateProjectDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.CreateProjectDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.CreateProjectDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.CreateProjectDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CreateProjectDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CreateProjectDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.CreateProjectDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DeleteDeploymentDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.DeleteDeploymentDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeleteDeploymentDetails>
    {
        public DeleteDeploymentDetails() { }
        public System.Collections.Generic.IList<string> AssignedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.DeleteDeploymentDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.DeleteDeploymentDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.DeleteDeploymentDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.DeleteDeploymentDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeleteDeploymentDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeleteDeploymentDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeleteDeploymentDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentDeleteFromResourcesOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.DeploymentDeleteFromResourcesOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentDeleteFromResourcesOperationState>
    {
        internal DeploymentDeleteFromResourcesOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.DeploymentDeleteFromResourcesOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.DeploymentDeleteFromResourcesOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.DeploymentDeleteFromResourcesOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.DeploymentDeleteFromResourcesOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentDeleteFromResourcesOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentDeleteFromResourcesOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentDeleteFromResourcesOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.DeploymentOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentOperationState>
    {
        internal DeploymentOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.DeploymentOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.DeploymentOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.DeploymentOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.DeploymentOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.DeploymentResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentResource>
    {
        internal DeploymentResource() { }
        public string Region { get { throw null; } }
        public string ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.DeploymentResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.DeploymentResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.DeploymentResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.DeploymentResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentResourcesOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.DeploymentResourcesOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentResourcesOperationState>
    {
        internal DeploymentResourcesOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.DeploymentResourcesOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.DeploymentResourcesOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.DeploymentResourcesOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.DeploymentResourcesOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentResourcesOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentResourcesOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.DeploymentResourcesOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitiesEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary>
    {
        internal EntitiesEvaluationSummary() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow> ConfusionMatrix { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.EntityEvaluationSummary> Entities { get { throw null; } }
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
    public partial class EntityEvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EntityEvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EntityEvaluationSummary>
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
        Azure.AI.Language.Conversations.Authoring.EntityEvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EntityEvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EntityEvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.EntityEvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EntityEvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EntityEvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EntityEvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EvaluationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationDetails>
    {
        public EvaluationDetails() { }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringEvaluationKind? Kind { get { throw null; } set { } }
        public int? TestingSplitPercentage { get { throw null; } set { } }
        public int? TrainingSplitPercentage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.EvaluationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EvaluationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EvaluationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.EvaluationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationJobResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EvaluationJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationJobResult>
    {
        internal EvaluationJobResult() { }
        public Azure.AI.Language.Conversations.Authoring.EvaluationDetails EvaluationDetails { get { throw null; } }
        public string ModelLabel { get { throw null; } }
        public int PercentComplete { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.EvaluationJobResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EvaluationJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EvaluationJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.EvaluationJobResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EvaluationOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationOperationState>
    {
        internal EvaluationOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.EvaluationJobResult Result { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.EvaluationOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EvaluationOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EvaluationOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.EvaluationOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EvaluationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationSummary>
    {
        internal EvaluationSummary() { }
        public Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary EntitiesEvaluation { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.EvaluationDetails EvaluationOptions { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.IntentsEvaluationSummary IntentsEvaluation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.EvaluationSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EvaluationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.EvaluationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.EvaluationSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.EvaluationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ExportedEntityList : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityList>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityList>
    {
        public ExportedEntityList() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.ExportedEntitySublist> Sublists { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedEntityList System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedEntityList System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedEntityListSynonym : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityListSynonym>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityListSynonym>
    {
        public ExportedEntityListSynonym() { }
        public string Language { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedEntityListSynonym System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityListSynonym>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityListSynonym>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedEntityListSynonym System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityListSynonym>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityListSynonym>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntityListSynonym>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ExportedEntitySublist : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedEntitySublist>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntitySublist>
    {
        public ExportedEntitySublist() { }
        public string ListKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Conversations.Authoring.ExportedEntityListSynonym> Synonyms { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedEntitySublist System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedEntitySublist>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedEntitySublist>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedEntitySublist System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntitySublist>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntitySublist>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedEntitySublist>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ExportedModelDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedModelDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedModelDetails>
    {
        public ExportedModelDetails(string trainedModelLabel) { }
        public string TrainedModelLabel { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedModelDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedModelDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedModelDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedModelDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedModelDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedModelDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedModelDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedModelOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedModelOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedModelOperationState>
    {
        internal ExportedModelOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedModelOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedModelOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedModelOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedModelOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedModelOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedModelOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedModelOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ExportedPrebuiltEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedPrebuiltEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedPrebuiltEntity>
    {
        public ExportedPrebuiltEntity(string category) { }
        public string Category { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedPrebuiltEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedPrebuiltEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedPrebuiltEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedPrebuiltEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedPrebuiltEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedPrebuiltEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedPrebuiltEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedProject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedProject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedProject>
    {
        public ExportedProject(string projectFileVersion, Azure.AI.Language.Conversations.Authoring.StringIndexType stringIndexType, Azure.AI.Language.Conversations.Authoring.CreateProjectDetails metadata) { }
        public Azure.AI.Language.Conversations.Authoring.ExportedProjectAsset Assets { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.CreateProjectDetails Metadata { get { throw null; } }
        public string ProjectFileVersion { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.StringIndexType StringIndexType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedProject System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedProject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedProject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedProject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedProject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedProject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedProject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ExportedProjectAsset : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedProjectAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedProjectAsset>
    {
        protected ExportedProjectAsset() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedProjectAsset System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedProjectAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedProjectAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedProjectAsset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedProjectAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedProjectAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedProjectAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ExportedTrainedModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedTrainedModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedTrainedModel>
    {
        internal ExportedTrainedModel() { }
        public string ExportedModelName { get { throw null; } }
        public System.DateTimeOffset LastExportedModelOn { get { throw null; } }
        public System.DateTimeOffset LastTrainedOn { get { throw null; } }
        public System.DateTimeOffset ModelExpiredOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ModelTrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedTrainedModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedTrainedModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportedTrainedModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportedTrainedModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedTrainedModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedTrainedModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportedTrainedModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ExportProjectOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportProjectOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportProjectOperationState>
    {
        internal ExportProjectOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public string ResultUri { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportProjectOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportProjectOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ExportProjectOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ExportProjectOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportProjectOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportProjectOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ExportProjectOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportProjectOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ImportProjectOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ImportProjectOperationState>
    {
        internal ImportProjectOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ImportProjectOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ImportProjectOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ImportProjectOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ImportProjectOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ImportProjectOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ImportProjectOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ImportProjectOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class LoadSnapshotOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.LoadSnapshotOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.LoadSnapshotOperationState>
    {
        internal LoadSnapshotOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.LoadSnapshotOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.LoadSnapshotOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.LoadSnapshotOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.LoadSnapshotOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.LoadSnapshotOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.LoadSnapshotOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.LoadSnapshotOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrchestrationExportedIntent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent>
    {
        public OrchestrationExportedIntent(string category) { }
        public string Category { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails Orchestration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrchestrationExportedProjectAsset : Azure.AI.Language.Conversations.Authoring.ExportedProjectAsset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedProjectAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.OrchestrationExportedProjectAsset>
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
    public partial class PrebuiltEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.PrebuiltEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.PrebuiltEntity>
    {
        internal PrebuiltEntity() { }
        public string Category { get { throw null; } }
        public string Description { get { throw null; } }
        public string Examples { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.PrebuiltEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.PrebuiltEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.PrebuiltEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.PrebuiltEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.PrebuiltEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.PrebuiltEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.PrebuiltEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectDeletionOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ProjectDeletionOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectDeletionOperationState>
    {
        internal ProjectDeletionOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ProjectDeletionOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ProjectDeletionOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ProjectDeletionOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ProjectDeletionOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectDeletionOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectDeletionOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectDeletionOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectDeployment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ProjectDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectDeployment>
    {
        internal ProjectDeployment() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Authoring.DeploymentResource> AssignedResources { get { throw null; } }
        public System.DateTimeOffset DeploymentExpiredOn { get { throw null; } }
        public string DeploymentName { get { throw null; } }
        public System.DateTimeOffset LastDeployedOn { get { throw null; } }
        public System.DateTimeOffset LastTrainedOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ModelTrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ProjectDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ProjectDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ProjectDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ProjectDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ProjectMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectMetadata>
    {
        internal ProjectMetadata() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string Language { get { throw null; } }
        public System.DateTimeOffset? LastDeployedOn { get { throw null; } }
        public System.DateTimeOffset LastModifiedOn { get { throw null; } }
        public System.DateTimeOffset? LastTrainedOn { get { throw null; } }
        public bool? Multilingual { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind ProjectKind { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ProjectSettings Settings { get { throw null; } }
        public string StorageInputContainerName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ProjectMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ProjectMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ProjectMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ProjectMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectSettings : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ProjectSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectSettings>
    {
        public ProjectSettings(float confidenceThreshold) { }
        public float ConfidenceThreshold { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ProjectSettings System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ProjectSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ProjectSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ProjectSettings System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectTrainedModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ProjectTrainedModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectTrainedModel>
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
        Azure.AI.Language.Conversations.Authoring.ProjectTrainedModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ProjectTrainedModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ProjectTrainedModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ProjectTrainedModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectTrainedModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectTrainedModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ProjectTrainedModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ResourceMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ResourceMetadata>
    {
        public ResourceMetadata(string azureResourceId, string customDomain, string region) { }
        public string AzureResourceId { get { throw null; } }
        public string CustomDomain { get { throw null; } }
        public string Region { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ResourceMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ResourceMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.ResourceMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.ResourceMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ResourceMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ResourceMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.ResourceMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SubTrainingOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.SubTrainingOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SubTrainingOperationState>
    {
        internal SubTrainingOperationState() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public int PercentComplete { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.SubTrainingOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.SubTrainingOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.SubTrainingOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.SubTrainingOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SubTrainingOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SubTrainingOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SubTrainingOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.SupportedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SupportedLanguage>
    {
        internal SupportedLanguage() { }
        public string LanguageCode { get { throw null; } }
        public string LanguageName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.SupportedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.SupportedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.SupportedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.SupportedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SupportedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SupportedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SupportedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SwapDeploymentsDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsDetails>
    {
        public SwapDeploymentsDetails(string firstDeploymentName, string secondDeploymentName) { }
        public string FirstDeploymentName { get { throw null; } }
        public string SecondDeploymentName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.SwapDeploymentsDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.SwapDeploymentsDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SwapDeploymentsOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsOperationState>
    {
        internal SwapDeploymentsOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.SwapDeploymentsOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.SwapDeploymentsOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.SwapDeploymentsOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrainingConfigVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.TrainingConfigVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingConfigVersion>
    {
        internal TrainingConfigVersion() { }
        public System.DateTimeOffset ModelExpirationDate { get { throw null; } }
        public string TrainingConfigVersionProperty { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.TrainingConfigVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.TrainingConfigVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.TrainingConfigVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.TrainingConfigVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingConfigVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingConfigVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingConfigVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrainingJobDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.TrainingJobDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingJobDetails>
    {
        public TrainingJobDetails(string modelLabel, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode trainingMode) { }
        public Azure.AI.Language.Conversations.Authoring.EvaluationDetails EvaluationOptions { get { throw null; } set { } }
        public string ModelLabel { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } set { } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode TrainingMode { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.TrainingJobDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.TrainingJobDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.TrainingJobDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.TrainingJobDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingJobDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingJobDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingJobDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrainingJobResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.TrainingJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingJobResult>
    {
        internal TrainingJobResult() { }
        public System.DateTimeOffset? EstimatedEndOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.SubTrainingOperationState EvaluationStatus { get { throw null; } }
        public string ModelLabel { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode? TrainingMode { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.SubTrainingOperationState TrainingStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.TrainingJobResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.TrainingJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.TrainingJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.TrainingJobResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrainingOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.TrainingOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingOperationState>
    {
        internal TrainingOperationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.TrainingJobResult Result { get { throw null; } }
        public Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.TrainingOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.TrainingOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.TrainingOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.TrainingOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.TrainingOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UnassignDeploymentResourcesDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.UnassignDeploymentResourcesDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UnassignDeploymentResourcesDetails>
    {
        public UnassignDeploymentResourcesDetails(System.Collections.Generic.IEnumerable<string> assignedResourceIds) { }
        public System.Collections.Generic.IList<string> AssignedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.UnassignDeploymentResourcesDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.UnassignDeploymentResourcesDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Conversations.Authoring.UnassignDeploymentResourcesDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Conversations.Authoring.UnassignDeploymentResourcesDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UnassignDeploymentResourcesDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UnassignDeploymentResourcesDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Conversations.Authoring.UnassignDeploymentResourcesDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
namespace Azure.AI.Language.Conversations.Authoring.Models
{
    public static partial class ConversationAnalysisAuthoringModelFactory
    {
        public static Azure.AI.Language.Conversations.Authoring.AssignedDeploymentResource AssignedDeploymentResource(Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.AzureLocation region = default(Azure.Core.AzureLocation)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentMetadata AssignedProjectDeploymentMetadata(string deploymentName = null, System.DateTimeOffset lastDeployedOn = default(System.DateTimeOffset), System.DateTimeOffset deploymentExpiresOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentsMetadata AssignedProjectDeploymentsMetadata(string projectName = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.AssignedProjectDeploymentMetadata> deploymentsMetadata = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixCell ConversationAuthoringConfusionMatrixCell(float normalizedValue = 0f, float rawValue = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow ConversationAuthoringConfusionMatrixRow(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationExportedEntity ConversationExportedEntity(string category = null, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode? compositionMode = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringCompositionMode?), Azure.AI.Language.Conversations.Authoring.ExportedEntityList entities = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.ExportedPrebuiltEntity> prebuilts = null, Azure.AI.Language.Conversations.Authoring.ExportedEntityRegex regex = null, System.Collections.Generic.IEnumerable<string> requiredComponents = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ConversationExportedUtterance ConversationExportedUtterance(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.ExportedUtteranceEntityLabel> entities = null, string text = null, string language = null, string intent = null, Azure.AI.Language.Conversations.Authoring.DatasetType? dataset = default(Azure.AI.Language.Conversations.Authoring.DatasetType?)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.CopyProjectOperationState CopyProjectOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.CreateDeploymentDetails CreateDeploymentDetails(string trainedModelLabel = null, System.Collections.Generic.IEnumerable<string> assignedResourceIds = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.CreateProjectDetails CreateProjectDetails(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind), Azure.AI.Language.Conversations.Authoring.ProjectSettings settings = null, string storageInputContainerName = null, string projectName = null, bool? multilingual = default(bool?), string description = null, string language = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.DeploymentDeleteFromResourcesOperationState DeploymentDeleteFromResourcesOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.DeploymentOperationState DeploymentOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.DeploymentResource DeploymentResource(string resourceId = null, string region = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.DeploymentResourcesOperationState DeploymentResourcesOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary EntitiesEvaluationSummary(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow> confusionMatrix = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.EntityEvaluationSummary> entities = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.EntityEvaluationSummary EntityEvaluationSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.EvaluationJobResult EvaluationJobResult(Azure.AI.Language.Conversations.Authoring.EvaluationDetails evaluationDetails = null, string modelLabel = null, string trainingConfigVersion = null, int percentComplete = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.EvaluationOperationState EvaluationOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null, Azure.AI.Language.Conversations.Authoring.EvaluationJobResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.EvaluationSummary EvaluationSummary(Azure.AI.Language.Conversations.Authoring.EntitiesEvaluationSummary entitiesEvaluation = null, Azure.AI.Language.Conversations.Authoring.IntentsEvaluationSummary intentsEvaluation = null, Azure.AI.Language.Conversations.Authoring.EvaluationDetails evaluationOptions = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestrationDetails ExportedConversationOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.ExportedConversationOrchestration conversationOrchestration = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestration ExportedLuisOrchestration(System.Guid appId = default(System.Guid), string appVersion = null, string slotName = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestrationDetails ExportedLuisOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.ExportedLuisOrchestration luisOrchestration = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ExportedModelOperationState ExportedModelOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ExportedProject ExportedProject(string projectFileVersion = null, Azure.AI.Language.Conversations.Authoring.StringIndexType stringIndexType = default(Azure.AI.Language.Conversations.Authoring.StringIndexType), Azure.AI.Language.Conversations.Authoring.CreateProjectDetails metadata = null, Azure.AI.Language.Conversations.Authoring.ExportedProjectAsset assets = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestrationDetails ExportedQuestionAnsweringOrchestrationDetails(Azure.AI.Language.Conversations.Authoring.ExportedQuestionAnsweringOrchestration questionAnsweringOrchestration = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ExportedTrainedModel ExportedTrainedModel(string exportedModelName = null, string modelId = null, System.DateTimeOffset lastTrainedOn = default(System.DateTimeOffset), System.DateTimeOffset lastExportedModelOn = default(System.DateTimeOffset), System.DateTimeOffset modelExpiredOn = default(System.DateTimeOffset), string modelTrainingConfigVersion = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ExportProjectOperationState ExportProjectOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null, string resultUri = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ImportProjectOperationState ImportProjectOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.IntentEvaluationSummary IntentEvaluationSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.IntentsEvaluationSummary IntentsEvaluationSummary(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringConfusionMatrixRow> confusionMatrix = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Authoring.IntentEvaluationSummary> intents = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.LoadSnapshotOperationState LoadSnapshotOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.OrchestrationExportedIntent OrchestrationExportedIntent(Azure.AI.Language.Conversations.Authoring.ExportedOrchestrationDetails orchestration = null, string category = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.OrchestrationExportedUtterance OrchestrationExportedUtterance(string text = null, string language = null, string intent = null, string dataset = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.PrebuiltEntity PrebuiltEntity(string category = null, string description = null, string examples = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ProjectDeletionOperationState ProjectDeletionOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ProjectDeployment ProjectDeployment(string deploymentName = null, string modelId = null, System.DateTimeOffset lastTrainedOn = default(System.DateTimeOffset), System.DateTimeOffset lastDeployedOn = default(System.DateTimeOffset), System.DateTimeOffset deploymentExpiredOn = default(System.DateTimeOffset), string modelTrainingConfigVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.DeploymentResource> assignedResources = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ProjectMetadata ProjectMetadata(System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastModifiedOn = default(System.DateTimeOffset), System.DateTimeOffset? lastTrainedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastDeployedOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind projectKind = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringProjectKind), Azure.AI.Language.Conversations.Authoring.ProjectSettings settings = null, string storageInputContainerName = null, string projectName = null, bool? multilingual = default(bool?), string description = null, string language = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.ProjectTrainedModel ProjectTrainedModel(string label = null, string modelId = null, System.DateTimeOffset lastTrainedOn = default(System.DateTimeOffset), int lastTrainingDurationInSeconds = 0, System.DateTimeOffset modelExpiredOn = default(System.DateTimeOffset), string modelTrainingConfigVersion = null, bool hasSnapshot = false) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.SubTrainingOperationState SubTrainingOperationState(int percentComplete = 0, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.SupportedLanguage SupportedLanguage(string languageName = null, string languageCode = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.SwapDeploymentsOperationState SwapDeploymentsOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.TrainingConfigVersion TrainingConfigVersion(string trainingConfigVersionProperty = null, System.DateTimeOffset modelExpirationDate = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.TrainingJobDetails TrainingJobDetails(string modelLabel = null, string trainingConfigVersion = null, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode trainingMode = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode), Azure.AI.Language.Conversations.Authoring.EvaluationDetails evaluationOptions = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.TrainingJobResult TrainingJobResult(string modelLabel = null, string trainingConfigVersion = null, Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode? trainingMode = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringTrainingMode?), Azure.AI.Language.Conversations.Authoring.SubTrainingOperationState trainingStatus = null, Azure.AI.Language.Conversations.Authoring.SubTrainingOperationState evaluationStatus = null, System.DateTimeOffset? estimatedEndOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.TrainingOperationState TrainingOperationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus status = default(Azure.AI.Language.Conversations.Authoring.ConversationAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null, Azure.AI.Language.Conversations.Authoring.TrainingJobResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.UtteranceEntitiesEvaluationResult UtteranceEntitiesEvaluationResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult> expectedEntities = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult> predictedEntities = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.UtteranceEntityEvaluationResult UtteranceEntityEvaluationResult(string category = null, int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.UtteranceEvaluationResult UtteranceEvaluationResult(string text = null, string language = null, Azure.AI.Language.Conversations.Authoring.UtteranceEntitiesEvaluationResult entitiesResult = null, Azure.AI.Language.Conversations.Authoring.UtteranceIntentsEvaluationResult intentsResult = null) { throw null; }
        public static Azure.AI.Language.Conversations.Authoring.UtteranceIntentsEvaluationResult UtteranceIntentsEvaluationResult(string expectedIntent = null, string predictedIntent = null) { throw null; }
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
