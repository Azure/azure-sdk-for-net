namespace Azure.DigitalTwins.Core
{
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AzureDigitalTwinsCoreContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        public AzureDigitalTwinsCoreContext() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.DigitalTwins.Core.AzureDigitalTwinsCoreContext Default { get { throw null; } }
    }
    public partial class BasicDigitalTwin
    {
        public BasicDigitalTwin() { }
        [System.Text.Json.Serialization.JsonExtensionDataAttribute]
        public System.Collections.Generic.IDictionary<string, object> Contents { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$etag")]
        public Azure.ETag? ETag { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$dtId")]
        public string Id { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$lastUpdateTime")]
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$metadata")]
        public Azure.DigitalTwins.Core.DigitalTwinMetadata Metadata { get { throw null; } set { } }
    }
    public partial class BasicDigitalTwinComponent
    {
        public BasicDigitalTwinComponent() { }
        [System.Text.Json.Serialization.JsonExtensionDataAttribute]
        public System.Collections.Generic.IDictionary<string, object> Contents { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$lastUpdateTime")]
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$metadata")]
        public System.Collections.Generic.IDictionary<string, Azure.DigitalTwins.Core.DigitalTwinPropertyMetadata> Metadata { get { throw null; } set { } }
    }
    public partial class BasicRelationship
    {
        public BasicRelationship() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$etag")]
        public Azure.ETag? ETag { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$relationshipId")]
        public string Id { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$relationshipName")]
        public string Name { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonExtensionDataAttribute]
        public System.Collections.Generic.IDictionary<string, object> Properties { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$sourceId")]
        public string SourceId { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$targetId")]
        public string TargetId { get { throw null; } set { } }
    }
    public partial class DigitalTwinMetadata
    {
        public DigitalTwinMetadata() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$model")]
        public string ModelId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.DigitalTwins.Core.DigitalTwinPropertyMetadata> PropertyMetadata { get { throw null; } set { } }
    }
    public partial class DigitalTwinPropertyMetadata
    {
        public DigitalTwinPropertyMetadata() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("lastUpdateTime")]
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("sourceTime")]
        public System.DateTimeOffset? SourceTime { get { throw null; } set { } }
    }
    public partial class DigitalTwinsClient
    {
        protected DigitalTwinsClient() { }
        public DigitalTwinsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DigitalTwinsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.DigitalTwins.Core.DigitalTwinsClientOptions options) { }
        public virtual Azure.Response<Azure.DigitalTwins.Core.ImportJob> CancelImportJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.DigitalTwins.Core.ImportJob>> CancelImportJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.DigitalTwins.Core.DigitalTwinsModelData[]> CreateModels(System.Collections.Generic.IEnumerable<string> dtdlModels, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.DigitalTwins.Core.DigitalTwinsModelData[]>> CreateModelsAsync(System.Collections.Generic.IEnumerable<string> dtdlModels, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<T>> CreateOrReplaceDigitalTwinAsync<T>(string digitalTwinId, T digitalTwin, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<T> CreateOrReplaceDigitalTwin<T>(string digitalTwinId, T digitalTwin, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceEventRoute(string eventRouteId, Azure.DigitalTwins.Core.DigitalTwinsEventRoute eventRoute, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceEventRouteAsync(string eventRouteId, Azure.DigitalTwins.Core.DigitalTwinsEventRoute eventRoute, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<T>> CreateOrReplaceRelationshipAsync<T>(string digitalTwinId, string relationshipId, T relationship, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<T> CreateOrReplaceRelationship<T>(string digitalTwinId, string relationshipId, T relationship, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DecommissionModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DecommissionModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDigitalTwin(string digitalTwinId, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDigitalTwinAsync(string digitalTwinId, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteEventRoute(string eventRouteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteEventRouteAsync(string eventRouteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteImportJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteImportJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRelationship(string digitalTwinId, string relationshipId, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRelationshipAsync(string digitalTwinId, string relationshipId, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<T>> GetComponentAsync<T>(string digitalTwinId, string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<T> GetComponent<T>(string digitalTwinId, string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<T>> GetDigitalTwinAsync<T>(string digitalTwinId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<T> GetDigitalTwin<T>(string digitalTwinId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.DigitalTwins.Core.DigitalTwinsEventRoute> GetEventRoute(string eventRouteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.DigitalTwins.Core.DigitalTwinsEventRoute>> GetEventRouteAsync(string eventRouteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.DigitalTwins.Core.DigitalTwinsEventRoute> GetEventRoutes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.DigitalTwins.Core.DigitalTwinsEventRoute> GetEventRoutesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.DigitalTwins.Core.ImportJob> GetImportJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.DigitalTwins.Core.ImportJob>> GetImportJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.DigitalTwins.Core.ImportJob> GetImportJobs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.DigitalTwins.Core.ImportJob> GetImportJobsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.DigitalTwins.Core.IncomingRelationship> GetIncomingRelationships(string digitalTwinId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.DigitalTwins.Core.IncomingRelationship> GetIncomingRelationshipsAsync(string digitalTwinId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.DigitalTwins.Core.DigitalTwinsModelData> GetModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.DigitalTwins.Core.DigitalTwinsModelData>> GetModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.DigitalTwins.Core.DigitalTwinsModelData> GetModels(Azure.DigitalTwins.Core.GetModelsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.DigitalTwins.Core.DigitalTwinsModelData> GetModelsAsync(Azure.DigitalTwins.Core.GetModelsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<T>> GetRelationshipAsync<T>(string digitalTwinId, string relationshipId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<T> GetRelationshipsAsync<T>(string digitalTwinId, string relationshipName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<T> GetRelationships<T>(string digitalTwinId, string relationshipName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<T> GetRelationship<T>(string digitalTwinId, string relationshipId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.DigitalTwins.Core.ImportJob> ImportGraph(string jobId, Azure.DigitalTwins.Core.ImportJob importJob, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.DigitalTwins.Core.ImportJob>> ImportGraphAsync(string jobId, Azure.DigitalTwins.Core.ImportJob importJob, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PublishComponentTelemetry(string digitalTwinId, string componentName, string messageId, string payload, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishComponentTelemetryAsync(string digitalTwinId, string componentName, string messageId, string payload, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PublishTelemetry(string digitalTwinId, string messageId, string payload, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishTelemetryAsync(string digitalTwinId, string messageId, string payload, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<T> QueryAsync<T>(string query, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<T> Query<T>(string query, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateComponent(string digitalTwinId, string componentName, Azure.JsonPatchDocument jsonPatchDocument, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateComponentAsync(string digitalTwinId, string componentName, Azure.JsonPatchDocument jsonPatchDocument, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateDigitalTwin(string digitalTwinId, Azure.JsonPatchDocument jsonPatchDocument, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateDigitalTwinAsync(string digitalTwinId, Azure.JsonPatchDocument jsonPatchDocument, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateRelationship(string digitalTwinId, string relationshipId, Azure.JsonPatchDocument jsonPatchDocument, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateRelationshipAsync(string digitalTwinId, string relationshipId, Azure.JsonPatchDocument jsonPatchDocument, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DigitalTwinsClientOptions : Azure.Core.ClientOptions
    {
        public DigitalTwinsClientOptions(Azure.DigitalTwins.Core.DigitalTwinsClientOptions.ServiceVersion version = Azure.DigitalTwins.Core.DigitalTwinsClientOptions.ServiceVersion.V2023_10_31) { }
        public Azure.Core.Serialization.ObjectSerializer Serializer { get { throw null; } set { } }
        public Azure.DigitalTwins.Core.DigitalTwinsClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2020_10_31 = 1,
            V2022_05_31 = 2,
            V2023_06_30 = 3,
            V2023_10_31 = 4,
        }
    }
    public partial class DigitalTwinsEventRoute
    {
        public DigitalTwinsEventRoute(string endpointName, string filter) { }
        public string EndpointName { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string Id { get { throw null; } }
    }
    public static partial class DigitalTwinsJsonPropertyNames
    {
        public const string DigitalTwinETag = "$etag";
        public const string DigitalTwinId = "$dtId";
        public const string DigitalTwinMetadata = "$metadata";
        public const string MetadataLastUpdateTime = "$lastUpdateTime";
        public const string MetadataModel = "$model";
        public const string MetadataPropertyLastUpdateTime = "lastUpdateTime";
        public const string MetadataPropertySourceTime = "sourceTime";
        public const string RelationshipId = "$relationshipId";
        public const string RelationshipName = "$relationshipName";
        public const string RelationshipSourceId = "$sourceId";
        public const string RelationshipTargetId = "$targetId";
    }
    public partial class DigitalTwinsModelData
    {
        internal DigitalTwinsModelData() { }
        public bool? Decommissioned { get { throw null; } }
        public string DtdlModel { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> LanguageDescriptions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> LanguageDisplayNames { get { throw null; } }
        public System.DateTimeOffset? UploadedOn { get { throw null; } }
    }
    public static partial class DigitalTwinsModelFactory
    {
        public static Azure.DigitalTwins.Core.Models.DeleteJob DeleteJob(string id = null, Azure.DigitalTwins.Core.Models.DeleteJobStatus? status = default(Azure.DigitalTwins.Core.Models.DeleteJobStatus?), System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? finishedDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? purgeDateTime = default(System.DateTimeOffset?), Azure.DigitalTwins.Core.ErrorInformation error = null) { throw null; }
        public static Azure.DigitalTwins.Core.DigitalTwinsEventRoute DigitalTwinsEventRoute(string id = null, string endpointName = null, string filter = null) { throw null; }
        public static Azure.DigitalTwins.Core.DigitalTwinsModelData DigitalTwinsModelData(System.Collections.Generic.IReadOnlyDictionary<string, string> languageDisplayNames = null, System.Collections.Generic.IReadOnlyDictionary<string, string> languageDescriptions = null, string id = null, System.DateTimeOffset? uploadedOn = default(System.DateTimeOffset?), bool? decommissioned = default(bool?), string dtdlModel = null) { throw null; }
        public static Azure.DigitalTwins.Core.ErrorInformation ErrorInformation(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.DigitalTwins.Core.ErrorInformation> details = null, Azure.DigitalTwins.Core.InnerError innererror = null) { throw null; }
        public static Azure.DigitalTwins.Core.ImportJob ImportJob(string id = null, System.Uri inputBlobUri = null, System.Uri outputBlobUri = null, Azure.DigitalTwins.Core.ImportJobStatus? status = default(Azure.DigitalTwins.Core.ImportJobStatus?), System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastActionDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? finishedDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? purgeDateTime = default(System.DateTimeOffset?), Azure.ResponseError error = null) { throw null; }
        public static Azure.DigitalTwins.Core.IncomingRelationship IncomingRelationship(string relationshipId = null, string sourceId = null, string relationshipName = null, string relationshipLink = null) { throw null; }
    }
    public partial class ErrorInformation
    {
        public ErrorInformation() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.DigitalTwins.Core.ErrorInformation> Details { get { throw null; } }
        public Azure.DigitalTwins.Core.InnerError Innererror { get { throw null; } set { } }
        public string Message { get { throw null; } }
    }
    public partial class GetModelsOptions
    {
        public GetModelsOptions() { }
        public System.Collections.Generic.IEnumerable<string> DependenciesFor { get { throw null; } set { } }
        public bool IncludeModelDefinition { get { throw null; } set { } }
    }
    public partial class ImportJob
    {
        public ImportJob(System.Uri inputBlobUri, System.Uri outputBlobUri) { }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset? FinishedDateTime { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Uri InputBlobUri { get { throw null; } set { } }
        public System.DateTimeOffset? LastActionDateTime { get { throw null; } }
        public System.Uri OutputBlobUri { get { throw null; } set { } }
        public System.DateTimeOffset? PurgeDateTime { get { throw null; } }
        public Azure.DigitalTwins.Core.ImportJobStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImportJobStatus : System.IEquatable<Azure.DigitalTwins.Core.ImportJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImportJobStatus(string value) { throw null; }
        public static Azure.DigitalTwins.Core.ImportJobStatus Cancelled { get { throw null; } }
        public static Azure.DigitalTwins.Core.ImportJobStatus Cancelling { get { throw null; } }
        public static Azure.DigitalTwins.Core.ImportJobStatus Failed { get { throw null; } }
        public static Azure.DigitalTwins.Core.ImportJobStatus Notstarted { get { throw null; } }
        public static Azure.DigitalTwins.Core.ImportJobStatus Running { get { throw null; } }
        public static Azure.DigitalTwins.Core.ImportJobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.DigitalTwins.Core.ImportJobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.DigitalTwins.Core.ImportJobStatus left, Azure.DigitalTwins.Core.ImportJobStatus right) { throw null; }
        public static implicit operator Azure.DigitalTwins.Core.ImportJobStatus (string value) { throw null; }
        public static bool operator !=(Azure.DigitalTwins.Core.ImportJobStatus left, Azure.DigitalTwins.Core.ImportJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IncomingRelationship
    {
        internal IncomingRelationship() { }
        public string RelationshipId { get { throw null; } }
        public string RelationshipLink { get { throw null; } }
        public string RelationshipName { get { throw null; } }
        public string SourceId { get { throw null; } }
    }
    public partial class InnerError
    {
        public InnerError() { }
        public string Code { get { throw null; } set { } }
        public Azure.DigitalTwins.Core.InnerError Innererror { get { throw null; } set { } }
    }
    public static partial class QueryChargeHelper
    {
        public static bool TryGetQueryCharge<T>(Azure.Page<T> page, out float queryCharge) { throw null; }
    }
}
namespace Azure.DigitalTwins.Core.Models
{
    public partial class DeleteJob
    {
        internal DeleteJob() { }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public Azure.DigitalTwins.Core.ErrorInformation Error { get { throw null; } }
        public System.DateTimeOffset? FinishedDateTime { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? PurgeDateTime { get { throw null; } }
        public Azure.DigitalTwins.Core.Models.DeleteJobStatus? Status { get { throw null; } }
    }
    public partial class DeleteJobsAddOptions
    {
        public DeleteJobsAddOptions() { }
        public string Traceparent { get { throw null; } set { } }
        public string Tracestate { get { throw null; } set { } }
    }
    public partial class DeleteJobsGetByIdOptions
    {
        public DeleteJobsGetByIdOptions() { }
        public string Traceparent { get { throw null; } set { } }
        public string Tracestate { get { throw null; } set { } }
    }
    public partial class DeleteJobsListOptions
    {
        public DeleteJobsListOptions() { }
        public int? MaxItemsPerPage { get { throw null; } set { } }
        public string Traceparent { get { throw null; } set { } }
        public string Tracestate { get { throw null; } set { } }
    }
    public enum DeleteJobStatus
    {
        Notstarted = 0,
        Running = 1,
        Failed = 2,
        Succeeded = 3,
    }
}
