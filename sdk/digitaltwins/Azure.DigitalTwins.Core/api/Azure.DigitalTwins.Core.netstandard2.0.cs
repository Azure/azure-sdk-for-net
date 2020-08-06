namespace Azure.DigitalTwins.Core
{
    public partial class DigitalTwinsClient
    {
        protected DigitalTwinsClient() { }
        public DigitalTwinsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DigitalTwinsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.DigitalTwins.Core.DigitalTwinsClientOptions options) { }
        public virtual Azure.Response<string> CreateDigitalTwin(string digitalTwinId, string digitalTwin, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> CreateDigitalTwinAsync(string digitalTwinId, string digitalTwin, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateEventRoute(string eventRouteId, Azure.DigitalTwins.Core.EventRoute eventRoute, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateEventRouteAsync(string eventRouteId, Azure.DigitalTwins.Core.EventRoute eventRoute, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.DigitalTwins.Core.ModelData[]> CreateModels(System.Collections.Generic.IEnumerable<string> models, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.DigitalTwins.Core.ModelData[]>> CreateModelsAsync(System.Collections.Generic.IEnumerable<string> models, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> CreateRelationship(string digitalTwinId, string relationshipId, string relationship, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> CreateRelationshipAsync(string digitalTwinId, string relationshipId, string relationship, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DecommissionModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DecommissionModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDigitalTwin(string digitalTwinId, Azure.DigitalTwins.Core.RequestOptions requestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDigitalTwinAsync(string digitalTwinId, Azure.DigitalTwins.Core.RequestOptions requestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteEventRoute(string eventRouteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteEventRouteAsync(string eventRouteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRelationship(string digitalTwinId, string relationshipId, Azure.DigitalTwins.Core.RequestOptions requestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRelationshipAsync(string digitalTwinId, string relationshipId, Azure.DigitalTwins.Core.RequestOptions requestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> GetComponent(string digitalTwinId, string componentPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetComponentAsync(string digitalTwinId, string componentPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> GetDigitalTwin(string digitalTwinId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetDigitalTwinAsync(string digitalTwinId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.DigitalTwins.Core.EventRoute> GetEventRoute(string eventRouteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.DigitalTwins.Core.EventRoute>> GetEventRouteAsync(string eventRouteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.DigitalTwins.Core.EventRoute> GetEventRoutes(Azure.DigitalTwins.Core.EventRoutesListOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.DigitalTwins.Core.EventRoute> GetEventRoutesAsync(Azure.DigitalTwins.Core.EventRoutesListOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.DigitalTwins.Core.IncomingRelationship> GetIncomingRelationships(string digitalTwinId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.DigitalTwins.Core.IncomingRelationship> GetIncomingRelationshipsAsync(string digitalTwinId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.DigitalTwins.Core.ModelData> GetModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.DigitalTwins.Core.ModelData>> GetModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.DigitalTwins.Core.ModelData> GetModels(System.Collections.Generic.IEnumerable<string> dependenciesFor = null, bool includeModelDefinition = false, Azure.DigitalTwins.Core.GetModelsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.DigitalTwins.Core.ModelData> GetModelsAsync(System.Collections.Generic.IEnumerable<string> dependenciesFor = null, bool includeModelDefinition = false, Azure.DigitalTwins.Core.GetModelsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> GetRelationship(string digitalTwinId, string relationshipId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetRelationshipAsync(string digitalTwinId, string relationshipId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetRelationships(string digitalTwinId, string relationshipName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetRelationshipsAsync(string digitalTwinId, string relationshipName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PublishComponentTelemetry(string digitalTwinId, string componentName, string payload, Azure.DigitalTwins.Core.TelemetryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishComponentTelemetryAsync(string digitalTwinId, string componentName, string payload, Azure.DigitalTwins.Core.TelemetryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PublishTelemetry(string digitalTwinId, string payload, Azure.DigitalTwins.Core.TelemetryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishTelemetryAsync(string digitalTwinId, string payload, Azure.DigitalTwins.Core.TelemetryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> Query(string query, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> QueryAsync(string query, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> UpdateComponent(string digitalTwinId, string componentPath, string componentUpdateOperations, Azure.DigitalTwins.Core.RequestOptions requestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> UpdateComponentAsync(string digitalTwinId, string componentPath, string componentUpdateOperations, Azure.DigitalTwins.Core.RequestOptions requestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> UpdateDigitalTwin(string digitalTwinId, string digitalTwinUpdateOperations, Azure.DigitalTwins.Core.RequestOptions requestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> UpdateDigitalTwinAsync(string digitalTwinId, string digitalTwinUpdateOperations, Azure.DigitalTwins.Core.RequestOptions requestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateRelationship(string digitalTwinId, string relationshipId, string relationshipUpdateOperations, Azure.DigitalTwins.Core.RequestOptions requestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateRelationshipAsync(string digitalTwinId, string relationshipId, string relationshipUpdateOperations, Azure.DigitalTwins.Core.RequestOptions requestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DigitalTwinsClientOptions : Azure.Core.ClientOptions
    {
        public DigitalTwinsClientOptions(Azure.DigitalTwins.Core.DigitalTwinsClientOptions.ServiceVersion version = Azure.DigitalTwins.Core.DigitalTwinsClientOptions.ServiceVersion.V2020_05_31_preview) { }
        public Azure.DigitalTwins.Core.DigitalTwinsClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2020_05_31_preview = 1,
        }
    }
    public partial class EventRoute
    {
        public EventRoute(string endpointName) { }
        public string EndpointName { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string Id { get { throw null; } }
    }
    public partial class EventRoutesListOptions
    {
        public EventRoutesListOptions() { }
        public int? MaxItemCount { get { throw null; } set { } }
    }
    public partial class GetModelsOptions
    {
        public GetModelsOptions() { }
        public int? MaxItemCount { get { throw null; } set { } }
    }
    public partial class IncomingRelationship
    {
        internal IncomingRelationship() { }
        public string RelationshipId { get { throw null; } }
        public string RelationshipLink { get { throw null; } }
        public string RelationshipName { get { throw null; } }
        public string SourceId { get { throw null; } }
    }
    public partial class ModelData
    {
        internal ModelData() { }
        public bool? Decommissioned { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Description { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Model { get { throw null; } }
        public System.DateTimeOffset? UploadTime { get { throw null; } }
    }
    public static partial class QueryChargeHelper
    {
        public static bool TryGetQueryCharge(Azure.Page<string> page, out float queryCharge) { throw null; }
    }
    public partial class RequestOptions
    {
        public RequestOptions() { }
        public string IfMatch { get { throw null; } set { } }
    }
    public partial class TelemetryOptions
    {
        public TelemetryOptions() { }
        public string MessageId { get { throw null; } set { } }
        public System.DateTimeOffset TimeStamp { get { throw null; } set { } }
    }
}
namespace Azure.DigitalTwins.Core.Serialization
{
    public partial class BasicDigitalTwin
    {
        public BasicDigitalTwin() { }
        [System.Text.Json.Serialization.JsonExtensionDataAttribute]
        public System.Collections.Generic.IDictionary<string, object> CustomProperties { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$etag")]
        public string ETag { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$dtId")]
        public string Id { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$metadata")]
        public Azure.DigitalTwins.Core.Serialization.DigitalTwinMetadata Metadata { get { throw null; } set { } }
    }
    public partial class BasicRelationship
    {
        public BasicRelationship() { }
        [System.Text.Json.Serialization.JsonExtensionDataAttribute]
        public System.Collections.Generic.IDictionary<string, object> CustomProperties { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$relationshipId")]
        public string Id { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$relationshipName")]
        public string Name { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$sourceId")]
        public string SourceId { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$targetId")]
        public string TargetId { get { throw null; } set { } }
    }
    public partial class ComponentMetadata
    {
        public ComponentMetadata() { }
        [System.Text.Json.Serialization.JsonExtensionDataAttribute]
        public System.Collections.Generic.IDictionary<string, object> WriteableProperties { get { throw null; } }
    }
    public partial class DigitalTwinMetadata
    {
        public DigitalTwinMetadata() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$model")]
        public string ModelId { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonExtensionDataAttribute]
        public System.Collections.Generic.IDictionary<string, object> WriteableProperties { get { throw null; } }
    }
    public partial class ModelProperties
    {
        public ModelProperties() { }
        [System.Text.Json.Serialization.JsonExtensionDataAttribute]
        public System.Collections.Generic.IDictionary<string, object> CustomProperties { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$metadata")]
        public Azure.DigitalTwins.Core.Serialization.ComponentMetadata Metadata { get { throw null; } }
    }
    public partial class UpdateOperationsUtility
    {
        public UpdateOperationsUtility() { }
        public void AppendAddOp(string path, object value) { }
        public void AppendRemoveOp(string path) { }
        public void AppendReplaceOp(string path, object value) { }
        public string Serialize() { throw null; }
    }
    public partial class WritableProperty
    {
        public WritableProperty() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("ackCode")]
        public int AckCode { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("ackDescription")]
        public string AckDescription { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("ackVersion")]
        public int AckVersion { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("desiredValue")]
        public object DesiredValue { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("desiredVersion")]
        public int DesiredVersion { get { throw null; } set { } }
    }
}
