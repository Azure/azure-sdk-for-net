namespace Azure.DigitalTwins.Core
{
    public partial class BasicDigitalTwin
    {
        public BasicDigitalTwin() { }
        [System.Text.Json.Serialization.JsonExtensionDataAttribute]
        public System.Collections.Generic.IDictionary<string, object> Contents { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$etag")]
        public Azure.ETag? ETag { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$dtId")]
        public string Id { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("$metadata")]
        public Azure.DigitalTwins.Core.DigitalTwinMetadata Metadata { get { throw null; } set { } }
    }
    public partial class BasicDigitalTwinComponent
    {
        public BasicDigitalTwinComponent() { }
        [System.Text.Json.Serialization.JsonExtensionDataAttribute]
        public System.Collections.Generic.IDictionary<string, object> Contents { get { throw null; } set { } }
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
    }
    public partial class DigitalTwinsClient
    {
        protected DigitalTwinsClient() { }
        public DigitalTwinsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DigitalTwinsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.DigitalTwins.Core.DigitalTwinsClientOptions options) { }
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
        public virtual Azure.Response PublishComponentTelemetry(string digitalTwinId, string componentName, string messageId, string payload, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishComponentTelemetryAsync(string digitalTwinId, string componentName, string messageId, string payload, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PublishTelemetry(string digitalTwinId, string messageId, string payload, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishTelemetryAsync(string digitalTwinId, string messageId, string payload, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<T> QueryAsync<T>(Azure.DigitalTwins.Core.QueryBuilder.AdtQueryBuilder adtQueryBuilder, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<T> QueryAsync<T>(string query, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<T> Query<T>(Azure.DigitalTwins.Core.QueryBuilder.AdtQueryBuilder adtQueryBuilder, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public DigitalTwinsClientOptions(Azure.DigitalTwins.Core.DigitalTwinsClientOptions.ServiceVersion version = Azure.DigitalTwins.Core.DigitalTwinsClientOptions.ServiceVersion.V2020_10_31) { }
        public Azure.Core.Serialization.ObjectSerializer Serializer { get { throw null; } set { } }
        public Azure.DigitalTwins.Core.DigitalTwinsClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2020_10_31 = 1,
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
        public const string MetadataModel = "$model";
        public const string MetadataPropertyLastUpdateTime = "lastUpdateTime";
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
        public static Azure.DigitalTwins.Core.DigitalTwinsModelData DigitalTwinsModelData(System.Collections.Generic.IReadOnlyDictionary<string, string> languageDisplayNames, System.Collections.Generic.IReadOnlyDictionary<string, string> languageDescriptions, string id, System.DateTimeOffset? uploadedOn, bool? decommissioned, string dtdlModel) { throw null; }
        public static Azure.DigitalTwins.Core.IncomingRelationship IncomingRelationship(string relationshipId, string sourceId, string relationshipName, string relationshipLink) { throw null; }
    }
    public partial class GetModelsOptions
    {
        public GetModelsOptions() { }
        public System.Collections.Generic.IEnumerable<string> DependenciesFor { get { throw null; } set { } }
        public bool IncludeModelDefinition { get { throw null; } set { } }
    }
    public partial class IncomingRelationship
    {
        internal IncomingRelationship() { }
        public string RelationshipId { get { throw null; } }
        public string RelationshipLink { get { throw null; } }
        public string RelationshipName { get { throw null; } }
        public string SourceId { get { throw null; } }
    }
    public static partial class QueryChargeHelper
    {
        public static bool TryGetQueryCharge<T>(Azure.Page<T> page, out float queryCharge) { throw null; }
    }
}
namespace Azure.DigitalTwins.Core.Models
{
    public static partial class AzureDigitalTwinsAPIModelFactory
    {
        public static Azure.DigitalTwins.Core.DigitalTwinsEventRoute DigitalTwinsEventRoute(string id = null, string endpointName = null, string filter = null) { throw null; }
        public static Azure.DigitalTwins.Core.DigitalTwinsModelData DigitalTwinsModelData(System.Collections.Generic.IReadOnlyDictionary<string, string> languageDisplayNames = null, System.Collections.Generic.IReadOnlyDictionary<string, string> languageDescriptions = null, string id = null, System.DateTimeOffset? uploadedOn = default(System.DateTimeOffset?), bool? decommissioned = default(bool?), string dtdlModel = null) { throw null; }
        public static Azure.DigitalTwins.Core.IncomingRelationship IncomingRelationship(string relationshipId = null, string sourceId = null, string relationshipName = null, string relationshipLink = null) { throw null; }
    }
}
namespace Azure.DigitalTwins.Core.QueryBuilder
{
    public enum AdtCollection
    {
        DigitalTwins = 0,
        Relationships = 1,
    }
    public enum AdtDataType
    {
        AdtBool = 0,
        AdtNumber = 1,
        AdtString = 2,
        AdtPrimative = 3,
        AdtObject = 4,
    }
    public partial class AdtQueryBuilder
    {
        public AdtQueryBuilder() { }
        public string GetQueryText() { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.SelectAsQuery Select(params string[] args) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.SelectAsQuery SelectAll() { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.SelectAsQuery SelectAs(string field, string alias) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.SelectAsQuery SelectCount() { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.SelectAsQuery SelectCustom(string customQuery) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.SelectAsQuery SelectTop(int count, params string[] args) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.SelectAsQuery SelectTopAll(int count) { throw null; }
    }
    public sealed partial class FromQuery : Azure.DigitalTwins.Core.QueryBuilder.QueryBase
    {
        internal FromQuery() { }
        public override Azure.DigitalTwins.Core.QueryBuilder.AdtQueryBuilder Build() { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.WhereStatement From(Azure.DigitalTwins.Core.QueryBuilder.AdtCollection collection) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.WhereStatement From(Azure.DigitalTwins.Core.QueryBuilder.AdtCollection collection, string alias) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.WhereStatement FromCustom(string collection) { throw null; }
        public override string GetQueryText() { throw null; }
    }
    public partial class LogicalOperator : Azure.DigitalTwins.Core.QueryBuilder.QueryBase
    {
        internal LogicalOperator() { }
        public Azure.DigitalTwins.Core.QueryBuilder.WhereLogic And() { throw null; }
        public override Azure.DigitalTwins.Core.QueryBuilder.AdtQueryBuilder Build() { throw null; }
        public override string GetQueryText() { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.WhereLogic Or() { throw null; }
    }
    public abstract partial class QueryBase
    {
        protected QueryBase() { }
        public abstract Azure.DigitalTwins.Core.QueryBuilder.AdtQueryBuilder Build();
        public abstract string GetQueryText();
    }
    public enum QueryComparisonOperator
    {
        Equal = 0,
        NotEqual = 1,
        GreaterThan = 2,
        LessThan = 3,
        GreaterOrEqual = 4,
        LessOrEqual = 5,
    }
    public enum QueryContainsOperator
    {
        In = 0,
        NotIn = 1,
    }
    public sealed partial class SelectAsQuery : Azure.DigitalTwins.Core.QueryBuilder.QueryBase
    {
        internal SelectAsQuery() { }
        public override Azure.DigitalTwins.Core.QueryBuilder.AdtQueryBuilder Build() { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.WhereStatement From(Azure.DigitalTwins.Core.QueryBuilder.AdtCollection collection) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.WhereStatement From(Azure.DigitalTwins.Core.QueryBuilder.AdtCollection collection, string alias) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.WhereStatement FromCustom(string collection) { throw null; }
        public override string GetQueryText() { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.SelectAsQuery SelectAs(string field, string alias) { throw null; }
    }
    public sealed partial class SelectQuery : Azure.DigitalTwins.Core.QueryBuilder.QueryBase
    {
        internal SelectQuery() { }
        public override Azure.DigitalTwins.Core.QueryBuilder.AdtQueryBuilder Build() { throw null; }
        public override string GetQueryText() { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.SelectAsQuery Select(params string[] args) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.SelectAsQuery SelectAll() { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.SelectAsQuery SelectCount() { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.SelectAsQuery SelectCustom(string customQuery) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.SelectAsQuery SelectTop(int count, params string[] args) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.SelectAsQuery SelectTopAll(int count) { throw null; }
    }
    public sealed partial class WhereLogic
    {
        internal WhereLogic() { }
        public Azure.DigitalTwins.Core.QueryBuilder.LogicalOperator Compare<T>(string field, Azure.DigitalTwins.Core.QueryBuilder.QueryComparisonOperator comparisonOperator, T value) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.LogicalOperator Contains(string value, string[] searched) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.LogicalOperator CustomClause(string condition) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.LogicalOperator EndsWith(string stringToCheck, string endingString) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.LogicalOperator IsDefined(string property) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.LogicalOperator IsNull(string expression) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.LogicalOperator IsOfModel(string model, bool exact = false) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.LogicalOperator IsOfType(string expression, Azure.DigitalTwins.Core.QueryBuilder.AdtDataType type) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.LogicalOperator NotContains(string value, string[] searched) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.LogicalOperator Parenthetical(System.Func<Azure.DigitalTwins.Core.QueryBuilder.WhereLogic, Azure.DigitalTwins.Core.QueryBuilder.LogicalOperator> nested) { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.LogicalOperator StartsWith(string stringToCheck, string beginningString) { throw null; }
    }
    public partial class WhereStatement : Azure.DigitalTwins.Core.QueryBuilder.QueryBase
    {
        internal WhereStatement() { }
        public override Azure.DigitalTwins.Core.QueryBuilder.AdtQueryBuilder Build() { throw null; }
        public override string GetQueryText() { throw null; }
        public Azure.DigitalTwins.Core.QueryBuilder.WhereLogic Where() { throw null; }
    }
}
