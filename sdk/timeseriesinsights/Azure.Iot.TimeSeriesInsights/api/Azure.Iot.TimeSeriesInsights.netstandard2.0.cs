namespace Azure.Iot.TimeSeriesInsights
{
    public partial class AggregateSeries
    {
        public AggregateSeries(System.Collections.Generic.IEnumerable<object> timeSeriesId, Azure.Iot.TimeSeriesInsights.DateTimeRange searchSpan, System.TimeSpan interval) { }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesExpression Filter { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Iot.TimeSeriesInsights.TimeSeriesVariable> InlineVariables { get { throw null; } }
        public System.TimeSpan Interval { get { throw null; } }
        public System.Collections.Generic.IList<string> ProjectedVariables { get { throw null; } }
        public Azure.Iot.TimeSeriesInsights.DateTimeRange SearchSpan { get { throw null; } }
        public System.Collections.Generic.IList<object> TimeSeriesId { get { throw null; } }
    }
    public partial class AggregateVariable : Azure.Iot.TimeSeriesInsights.TimeSeriesVariable
    {
        public AggregateVariable(Azure.Iot.TimeSeriesInsights.TimeSeriesExpression aggregation) { }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesExpression Aggregation { get { throw null; } set { } }
    }
    public partial class AvailabilityResponse
    {
        internal AvailabilityResponse() { }
        public Azure.Iot.TimeSeriesInsights.EventAvailability Availability { get { throw null; } }
    }
    public partial class CategoricalVariable : Azure.Iot.TimeSeriesInsights.TimeSeriesVariable
    {
        public CategoricalVariable(Azure.Iot.TimeSeriesInsights.TimeSeriesExpression value, Azure.Iot.TimeSeriesInsights.TimeSeriesDefaultCategory defaultCategory) { }
        public System.Collections.Generic.IList<Azure.Iot.TimeSeriesInsights.TimeSeriesAggregateCategory> Categories { get { throw null; } }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesDefaultCategory DefaultCategory { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.InterpolationOperation Interpolation { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesExpression Value { get { throw null; } set { } }
    }
    public partial class DateTimeRange
    {
        public DateTimeRange(System.DateTimeOffset from, System.DateTimeOffset to) { }
        public System.DateTimeOffset From { get { throw null; } set { } }
        public System.DateTimeOffset To { get { throw null; } set { } }
    }
    public partial class EventAvailability
    {
        internal EventAvailability() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> Distribution { get { throw null; } }
        public System.TimeSpan? IntervalSize { get { throw null; } }
        public Azure.Iot.TimeSeriesInsights.DateTimeRange Range { get { throw null; } }
    }
    public partial class EventProperty
    {
        public EventProperty() { }
        public string Name { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.PropertyTypes? Type { get { throw null; } set { } }
    }
    public partial class EventSchema
    {
        internal EventSchema() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.EventProperty> Properties { get { throw null; } }
    }
    public partial class GetEvents
    {
        public GetEvents(System.Collections.Generic.IEnumerable<object> timeSeriesId, Azure.Iot.TimeSeriesInsights.DateTimeRange searchSpan) { }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesExpression Filter { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Iot.TimeSeriesInsights.EventProperty> ProjectedProperties { get { throw null; } }
        public Azure.Iot.TimeSeriesInsights.DateTimeRange SearchSpan { get { throw null; } }
        public int? Take { get { throw null; } set { } }
        public System.Collections.Generic.IList<object> TimeSeriesId { get { throw null; } }
    }
    public partial class GetEventSchemaRequest
    {
        public GetEventSchemaRequest(Azure.Iot.TimeSeriesInsights.DateTimeRange searchSpan) { }
        public Azure.Iot.TimeSeriesInsights.DateTimeRange SearchSpan { get { throw null; } }
    }
    public partial class GetHierarchiesPage : Azure.Iot.TimeSeriesInsights.PagedResponse
    {
        internal GetHierarchiesPage() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.TimeSeriesHierarchy> Hierarchies { get { throw null; } }
    }
    public partial class GetInstancesPage : Azure.Iot.TimeSeriesInsights.PagedResponse
    {
        internal GetInstancesPage() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.TimeSeriesInstance> Instances { get { throw null; } }
    }
    public partial class GetSeries
    {
        public GetSeries(System.Collections.Generic.IEnumerable<object> timeSeriesId, Azure.Iot.TimeSeriesInsights.DateTimeRange searchSpan) { }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesExpression Filter { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Iot.TimeSeriesInsights.TimeSeriesVariable> InlineVariables { get { throw null; } }
        public System.Collections.Generic.IList<string> ProjectedVariables { get { throw null; } }
        public Azure.Iot.TimeSeriesInsights.DateTimeRange SearchSpan { get { throw null; } }
        public int? Take { get { throw null; } set { } }
        public System.Collections.Generic.IList<object> TimeSeriesId { get { throw null; } }
    }
    public partial class GetTypesPage : Azure.Iot.TimeSeriesInsights.PagedResponse
    {
        internal GetTypesPage() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.TimeSeriesType> Types { get { throw null; } }
    }
    public partial class HierarchiesBatchRequest
    {
        public HierarchiesBatchRequest() { }
        public Azure.Iot.TimeSeriesInsights.HierarchiesRequestBatchGetDelete Delete { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.HierarchiesRequestBatchGetDelete Get { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Iot.TimeSeriesInsights.TimeSeriesHierarchy> Put { get { throw null; } }
    }
    public partial class HierarchiesBatchResponse
    {
        internal HierarchiesBatchResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.TimeSeriesOperationError> Delete { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.TimeSeriesHierarchyOrError> Get { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.TimeSeriesHierarchyOrError> Put { get { throw null; } }
    }
    public partial class HierarchiesExpandParameter
    {
        public HierarchiesExpandParameter() { }
        public Azure.Iot.TimeSeriesInsights.Models.HierarchiesExpandKind? Kind { get { throw null; } set { } }
    }
    public partial class HierarchiesRequestBatchGetDelete
    {
        public HierarchiesRequestBatchGetDelete() { }
        public System.Collections.Generic.IList<string> HierarchyIds { get { throw null; } }
        public System.Collections.Generic.IList<string> Names { get { throw null; } }
    }
    public partial class HierarchiesSortParameter
    {
        public HierarchiesSortParameter() { }
        public Azure.Iot.TimeSeriesInsights.Models.HierarchiesSortBy? By { get { throw null; } set { } }
    }
    public partial class HierarchyHit
    {
        internal HierarchyHit() { }
        public int? CumulativeInstanceCount { get { throw null; } }
        public Azure.Iot.TimeSeriesInsights.SearchHierarchyNodesResponse HierarchyNodes { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class InstanceHit
    {
        internal InstanceHit() { }
        public System.Collections.Generic.IReadOnlyList<string> HierarchyIds { get { throw null; } }
        public Azure.Iot.TimeSeriesInsights.Models.InstanceHitHighlights Highlights { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<object> TimeSeriesId { get { throw null; } }
        public string TypeId { get { throw null; } }
    }
    public partial class InstancesBatchRequest
    {
        public InstancesBatchRequest() { }
        public Azure.Iot.TimeSeriesInsights.InstancesRequestBatchGetOrDelete Delete { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.InstancesRequestBatchGetOrDelete Get { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Iot.TimeSeriesInsights.TimeSeriesInstance> Put { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Iot.TimeSeriesInsights.TimeSeriesInstance> Update { get { throw null; } }
    }
    public partial class InstancesBatchResponse
    {
        internal InstancesBatchResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.TimeSeriesOperationError> Delete { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.InstancesOperationResult> Get { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.InstancesOperationResult> Put { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.InstancesOperationResult> Update { get { throw null; } }
    }
    public partial class InstancesOperationResult
    {
        internal InstancesOperationResult() { }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesOperationError Error { get { throw null; } }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesInstance Instance { get { throw null; } }
    }
    public partial class InstancesRequestBatchGetOrDelete
    {
        public InstancesRequestBatchGetOrDelete() { }
        public System.Collections.Generic.IList<string> Names { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Iot.TimeSeriesInsights.TimeSeriesId> TimeSeriesIds { get { throw null; } }
    }
    public partial class InstancesSortParameter
    {
        public InstancesSortParameter() { }
        public Azure.Iot.TimeSeriesInsights.Models.InstancesSortBy? By { get { throw null; } set { } }
    }
    public partial class InstancesSuggestRequest
    {
        public InstancesSuggestRequest(string searchString) { }
        public string SearchString { get { throw null; } }
        public int? Take { get { throw null; } set { } }
    }
    public partial class InstancesSuggestResponse
    {
        internal InstancesSuggestResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.SearchSuggestion> Suggestions { get { throw null; } }
    }
    public partial class InterpolationOperation
    {
        public InterpolationOperation() { }
        public Azure.Iot.TimeSeriesInsights.Models.InterpolationBoundary Boundary { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.Models.InterpolationKind? Kind { get { throw null; } set { } }
    }
    public partial class ModelSettingsResponse
    {
        internal ModelSettingsResponse() { }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesModelSettings ModelSettings { get { throw null; } }
    }
    public partial class NumericVariable : Azure.Iot.TimeSeriesInsights.TimeSeriesVariable
    {
        public NumericVariable(Azure.Iot.TimeSeriesInsights.TimeSeriesExpression value, Azure.Iot.TimeSeriesInsights.TimeSeriesExpression aggregation) { }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesExpression Aggregation { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.InterpolationOperation Interpolation { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesExpression Value { get { throw null; } set { } }
    }
    public partial class PagedResponse
    {
        internal PagedResponse() { }
        public string ContinuationToken { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PropertyTypes : System.IEquatable<Azure.Iot.TimeSeriesInsights.PropertyTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PropertyTypes(string value) { throw null; }
        public static Azure.Iot.TimeSeriesInsights.PropertyTypes Bool { get { throw null; } }
        public static Azure.Iot.TimeSeriesInsights.PropertyTypes DateTime { get { throw null; } }
        public static Azure.Iot.TimeSeriesInsights.PropertyTypes Double { get { throw null; } }
        public static Azure.Iot.TimeSeriesInsights.PropertyTypes Long { get { throw null; } }
        public static Azure.Iot.TimeSeriesInsights.PropertyTypes String { get { throw null; } }
        public static Azure.Iot.TimeSeriesInsights.PropertyTypes TimeSpan { get { throw null; } }
        public bool Equals(Azure.Iot.TimeSeriesInsights.PropertyTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Iot.TimeSeriesInsights.PropertyTypes left, Azure.Iot.TimeSeriesInsights.PropertyTypes right) { throw null; }
        public static implicit operator Azure.Iot.TimeSeriesInsights.PropertyTypes (string value) { throw null; }
        public static bool operator !=(Azure.Iot.TimeSeriesInsights.PropertyTypes left, Azure.Iot.TimeSeriesInsights.PropertyTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PropertyValues : Azure.Iot.TimeSeriesInsights.EventProperty
    {
        public PropertyValues() { }
        public System.Collections.Generic.IList<object> Values { get { throw null; } }
    }
    public partial class QueryRequest
    {
        public QueryRequest() { }
        public Azure.Iot.TimeSeriesInsights.AggregateSeries AggregateSeries { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.GetEvents GetEvents { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.GetSeries GetSeries { get { throw null; } set { } }
    }
    public partial class QueryResultPage : Azure.Iot.TimeSeriesInsights.PagedResponse
    {
        internal QueryResultPage() { }
        public double? Progress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.PropertyValues> Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> Timestamps { get { throw null; } }
    }
    public partial class SearchHierarchyNodesResponse
    {
        internal SearchHierarchyNodesResponse() { }
        public string ContinuationToken { get { throw null; } }
        public int? HitCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.HierarchyHit> Hits { get { throw null; } }
    }
    public partial class SearchInstancesHierarchiesParameters
    {
        public SearchInstancesHierarchiesParameters() { }
        public Azure.Iot.TimeSeriesInsights.HierarchiesExpandParameter Expand { get { throw null; } set { } }
        public int? PageSize { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.HierarchiesSortParameter Sort { get { throw null; } set { } }
    }
    public partial class SearchInstancesParameters
    {
        public SearchInstancesParameters() { }
        public bool? Highlights { get { throw null; } set { } }
        public int? PageSize { get { throw null; } set { } }
        public bool? Recursive { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.InstancesSortParameter Sort { get { throw null; } set { } }
    }
    public partial class SearchInstancesRequest
    {
        public SearchInstancesRequest(string searchString) { }
        public Azure.Iot.TimeSeriesInsights.SearchInstancesHierarchiesParameters Hierarchies { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.SearchInstancesParameters Instances { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Path { get { throw null; } }
        public string SearchString { get { throw null; } }
    }
    public partial class SearchInstancesResponse
    {
        internal SearchInstancesResponse() { }
        public string ContinuationToken { get { throw null; } }
        public int? HitCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.InstanceHit> Hits { get { throw null; } }
    }
    public partial class SearchInstancesResponsePage
    {
        internal SearchInstancesResponsePage() { }
        public Azure.Iot.TimeSeriesInsights.SearchHierarchyNodesResponse HierarchyNodes { get { throw null; } }
        public Azure.Iot.TimeSeriesInsights.SearchInstancesResponse Instances { get { throw null; } }
    }
    public partial class SearchSuggestion
    {
        internal SearchSuggestion() { }
        public string HighlightedSearchString { get { throw null; } }
        public string SearchString { get { throw null; } }
    }
    public partial class TimeSeriesAggregateCategory
    {
        public TimeSeriesAggregateCategory(string label, System.Collections.Generic.IEnumerable<object> values) { }
        public string Label { get { throw null; } set { } }
        public System.Collections.Generic.IList<object> Values { get { throw null; } }
    }
    public partial class TimeSeriesDefaultCategory
    {
        public TimeSeriesDefaultCategory(string label) { }
        public string Label { get { throw null; } set { } }
    }
    public partial class TimeSeriesExpression
    {
        public TimeSeriesExpression(string tsx) { }
        public string Tsx { get { throw null; } set { } }
    }
    public partial class TimeSeriesHierarchy
    {
        public TimeSeriesHierarchy(string name, Azure.Iot.TimeSeriesInsights.Models.TimeSeriesHierarchySource source) { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.Models.TimeSeriesHierarchySource Source { get { throw null; } set { } }
    }
    public partial class TimeSeriesHierarchyOrError
    {
        internal TimeSeriesHierarchyOrError() { }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesOperationError Error { get { throw null; } }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesHierarchy Hierarchy { get { throw null; } }
    }
    public partial class TimeSeriesId
    {
        public TimeSeriesId(string key1) { }
        public TimeSeriesId(string key1, string key2) { }
        public TimeSeriesId(string key1, string key2, string key3) { }
        public string[] ToArray() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimeSeriesIdProperty
    {
        internal TimeSeriesIdProperty() { }
        public string Name { get { throw null; } }
        public Azure.Iot.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes? Type { get { throw null; } }
    }
    public partial class TimeSeriesInsightsClient
    {
        protected TimeSeriesInsightsClient() { }
        public TimeSeriesInsightsClient(string environmentFqdn, Azure.Core.TokenCredential credential) { }
        public TimeSeriesInsightsClient(string environmentFqdn, Azure.Core.TokenCredential credential, Azure.Iot.TimeSeriesInsights.TimeSeriesInsightsClientOptions options) { }
        public virtual Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesOperationError[]> CreateOrReplaceTimeSeriesInstances(System.Collections.Generic.IEnumerable<Azure.Iot.TimeSeriesInsights.TimeSeriesInstance> timeSeriesInstances, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesOperationError[]>> CreateOrReplaceTimeSeriesInstancesAsync(System.Collections.Generic.IEnumerable<Azure.Iot.TimeSeriesInsights.TimeSeriesInstance> timeSeriesInstances, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesOperationError[]> DeleteInstances(System.Collections.Generic.IEnumerable<Azure.Iot.TimeSeriesInsights.TimeSeriesId> timeSeriesIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesOperationError[]> DeleteInstances(System.Collections.Generic.IEnumerable<string> timeSeriesNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesOperationError[]>> DeleteInstancesAsync(System.Collections.Generic.IEnumerable<Azure.Iot.TimeSeriesInsights.TimeSeriesId> timeSeriesIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesOperationError[]>> DeleteInstancesAsync(System.Collections.Generic.IEnumerable<string> timeSeriesNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.TimeSeriesInsights.InstancesOperationResult[]> GetInstances(System.Collections.Generic.IEnumerable<Azure.Iot.TimeSeriesInsights.TimeSeriesId> timeSeriesIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.TimeSeriesInsights.InstancesOperationResult[]> GetInstances(System.Collections.Generic.IEnumerable<string> timeSeriesNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Iot.TimeSeriesInsights.TimeSeriesInstance> GetInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.TimeSeriesInsights.InstancesOperationResult[]>> GetInstancesAsync(System.Collections.Generic.IEnumerable<Azure.Iot.TimeSeriesInsights.TimeSeriesId> timeSeriesIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.TimeSeriesInsights.InstancesOperationResult[]>> GetInstancesAsync(System.Collections.Generic.IEnumerable<string> timeSeriesNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Iot.TimeSeriesInsights.TimeSeriesInstance> GetInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesModelSettings> GetModelSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesModelSettings>> GetModelSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.TimeSeriesInsights.SearchSuggestion[]> GetSearchSuggestions(string searchString, int? maxNumberOfSuggestions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.TimeSeriesInsights.SearchSuggestion[]>> GetSearchSuggestionsAsync(string searchString, int? maxNumberOfSuggestions = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Iot.TimeSeriesInsights.TimeSeriesType> GetTimeSeriesTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Iot.TimeSeriesInsights.TimeSeriesType> GetTimeSeriesTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesTypeOperationResult[]> GetTimeSeriesTypesById(System.Collections.Generic.IEnumerable<string> timeSeriesTypeIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesTypeOperationResult[]>> GetTimeSeriesTypesByIdAsync(System.Collections.Generic.IEnumerable<string> timeSeriesTypeIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesTypeOperationResult[]> GetTimeSeriesTypesByNames(System.Collections.Generic.IEnumerable<string> timeSeriesTypeNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesTypeOperationResult[]>> GetTimeSeriesTypesByNamesAsync(System.Collections.Generic.IEnumerable<string> timeSeriesTypeNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.TimeSeriesInsights.InstancesOperationResult[]> ReplaceTimeSeriesInstances(System.Collections.Generic.IEnumerable<Azure.Iot.TimeSeriesInsights.TimeSeriesInstance> timeSeriesInstances, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.TimeSeriesInsights.InstancesOperationResult[]>> ReplaceTimeSeriesInstancesAsync(System.Collections.Generic.IEnumerable<Azure.Iot.TimeSeriesInsights.TimeSeriesInstance> timeSeriesInstances, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesModelSettings> UpdateModelSettingsDefaultTypeId(string defaultTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesModelSettings>> UpdateModelSettingsDefaultTypeIdAsync(string defaultTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesModelSettings> UpdateModelSettingsName(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.TimeSeriesInsights.TimeSeriesModelSettings>> UpdateModelSettingsNameAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TimeSeriesInsightsClientOptions : Azure.Core.ClientOptions
    {
        public TimeSeriesInsightsClientOptions(Azure.Iot.TimeSeriesInsights.TimeSeriesInsightsClientOptions.ServiceVersion version = Azure.Iot.TimeSeriesInsights.TimeSeriesInsightsClientOptions.ServiceVersion.V2020_07_31) { }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesInsightsClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2020_07_31 = 1,
        }
    }
    public partial class TimeSeriesInstance
    {
        public TimeSeriesInstance(Azure.Iot.TimeSeriesInsights.TimeSeriesId timeSeriesId, string typeId) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> HierarchyIds { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> InstanceFields { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesId TimeSeriesId { get { throw null; } }
        public string TypeId { get { throw null; } set { } }
    }
    public partial class TimeSeriesModelSettings
    {
        internal TimeSeriesModelSettings() { }
        public string DefaultTypeId { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.TimeSeriesIdProperty> TimeSeriesIdProperties { get { throw null; } }
    }
    public partial class TimeSeriesOperationError : System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyDictionary<string, object>, System.Collections.IEnumerable
    {
        internal TimeSeriesOperationError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.TimeSeriesOperationErrorDetails> Details { get { throw null; } }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesOperationError InnerError { get { throw null; } }
        public object this[string key] { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Keys { get { throw null; } }
        public string Message { get { throw null; } }
        int System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        public string Target { get { throw null; } }
        public System.Collections.Generic.IEnumerable<object> Values { get { throw null; } }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class TimeSeriesOperationErrorDetails : System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyDictionary<string, object>, System.Collections.IEnumerable
    {
        internal TimeSeriesOperationErrorDetails() { }
        public string Code { get { throw null; } }
        public object this[string key] { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Keys { get { throw null; } }
        public string Message { get { throw null; } }
        int System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        public System.Collections.Generic.IEnumerable<object> Values { get { throw null; } }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class TimeSeriesType
    {
        public TimeSeriesType(string name, System.Collections.Generic.IDictionary<string, Azure.Iot.TimeSeriesInsights.TimeSeriesVariable> variables) { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Iot.TimeSeriesInsights.TimeSeriesVariable> Variables { get { throw null; } }
    }
    public partial class TimeSeriesTypeOperationResult
    {
        internal TimeSeriesTypeOperationResult() { }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesOperationError Error { get { throw null; } }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesType TimeSeriesType { get { throw null; } }
    }
    public partial class TimeSeriesVariable
    {
        public TimeSeriesVariable() { }
        public Azure.Iot.TimeSeriesInsights.TimeSeriesExpression Filter { get { throw null; } set { } }
    }
    public partial class TypesBatchRequest
    {
        public TypesBatchRequest() { }
        public Azure.Iot.TimeSeriesInsights.TypesRequestBatchGetOrDelete Delete { get { throw null; } set { } }
        public Azure.Iot.TimeSeriesInsights.TypesRequestBatchGetOrDelete Get { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Iot.TimeSeriesInsights.TimeSeriesType> Put { get { throw null; } }
    }
    public partial class TypesBatchResponse
    {
        internal TypesBatchResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.TimeSeriesOperationError> Delete { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.TimeSeriesTypeOperationResult> Get { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.TimeSeriesInsights.TimeSeriesTypeOperationResult> Put { get { throw null; } }
    }
    public partial class TypesRequestBatchGetOrDelete
    {
        public TypesRequestBatchGetOrDelete() { }
        public System.Collections.Generic.IList<string> Names { get { throw null; } }
        public System.Collections.Generic.IList<string> TypeIds { get { throw null; } }
    }
}
namespace Azure.Iot.TimeSeriesInsights.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HierarchiesExpandKind : System.IEquatable<Azure.Iot.TimeSeriesInsights.Models.HierarchiesExpandKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HierarchiesExpandKind(string value) { throw null; }
        public static Azure.Iot.TimeSeriesInsights.Models.HierarchiesExpandKind OneLevel { get { throw null; } }
        public static Azure.Iot.TimeSeriesInsights.Models.HierarchiesExpandKind UntilChildren { get { throw null; } }
        public bool Equals(Azure.Iot.TimeSeriesInsights.Models.HierarchiesExpandKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Iot.TimeSeriesInsights.Models.HierarchiesExpandKind left, Azure.Iot.TimeSeriesInsights.Models.HierarchiesExpandKind right) { throw null; }
        public static implicit operator Azure.Iot.TimeSeriesInsights.Models.HierarchiesExpandKind (string value) { throw null; }
        public static bool operator !=(Azure.Iot.TimeSeriesInsights.Models.HierarchiesExpandKind left, Azure.Iot.TimeSeriesInsights.Models.HierarchiesExpandKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HierarchiesSortBy : System.IEquatable<Azure.Iot.TimeSeriesInsights.Models.HierarchiesSortBy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HierarchiesSortBy(string value) { throw null; }
        public static Azure.Iot.TimeSeriesInsights.Models.HierarchiesSortBy CumulativeInstanceCount { get { throw null; } }
        public static Azure.Iot.TimeSeriesInsights.Models.HierarchiesSortBy Name { get { throw null; } }
        public bool Equals(Azure.Iot.TimeSeriesInsights.Models.HierarchiesSortBy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Iot.TimeSeriesInsights.Models.HierarchiesSortBy left, Azure.Iot.TimeSeriesInsights.Models.HierarchiesSortBy right) { throw null; }
        public static implicit operator Azure.Iot.TimeSeriesInsights.Models.HierarchiesSortBy (string value) { throw null; }
        public static bool operator !=(Azure.Iot.TimeSeriesInsights.Models.HierarchiesSortBy left, Azure.Iot.TimeSeriesInsights.Models.HierarchiesSortBy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InstanceHitHighlights
    {
        internal InstanceHitHighlights() { }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> HierarchyIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> HierarchyNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> InstanceFieldNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> InstanceFieldValues { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TimeSeriesId { get { throw null; } }
        public string TypeName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstancesSortBy : System.IEquatable<Azure.Iot.TimeSeriesInsights.Models.InstancesSortBy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstancesSortBy(string value) { throw null; }
        public static Azure.Iot.TimeSeriesInsights.Models.InstancesSortBy DisplayName { get { throw null; } }
        public static Azure.Iot.TimeSeriesInsights.Models.InstancesSortBy Rank { get { throw null; } }
        public bool Equals(Azure.Iot.TimeSeriesInsights.Models.InstancesSortBy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Iot.TimeSeriesInsights.Models.InstancesSortBy left, Azure.Iot.TimeSeriesInsights.Models.InstancesSortBy right) { throw null; }
        public static implicit operator Azure.Iot.TimeSeriesInsights.Models.InstancesSortBy (string value) { throw null; }
        public static bool operator !=(Azure.Iot.TimeSeriesInsights.Models.InstancesSortBy left, Azure.Iot.TimeSeriesInsights.Models.InstancesSortBy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InterpolationBoundary
    {
        public InterpolationBoundary() { }
        public System.TimeSpan? Span { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InterpolationKind : System.IEquatable<Azure.Iot.TimeSeriesInsights.Models.InterpolationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InterpolationKind(string value) { throw null; }
        public static Azure.Iot.TimeSeriesInsights.Models.InterpolationKind Linear { get { throw null; } }
        public static Azure.Iot.TimeSeriesInsights.Models.InterpolationKind Step { get { throw null; } }
        public bool Equals(Azure.Iot.TimeSeriesInsights.Models.InterpolationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Iot.TimeSeriesInsights.Models.InterpolationKind left, Azure.Iot.TimeSeriesInsights.Models.InterpolationKind right) { throw null; }
        public static implicit operator Azure.Iot.TimeSeriesInsights.Models.InterpolationKind (string value) { throw null; }
        public static bool operator !=(Azure.Iot.TimeSeriesInsights.Models.InterpolationKind left, Azure.Iot.TimeSeriesInsights.Models.InterpolationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimeSeriesHierarchySource
    {
        public TimeSeriesHierarchySource() { }
        public System.Collections.Generic.IList<string> InstanceFieldNames { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeSeriesIdPropertyTypes : System.IEquatable<Azure.Iot.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeSeriesIdPropertyTypes(string value) { throw null; }
        public static Azure.Iot.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes String { get { throw null; } }
        public bool Equals(Azure.Iot.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Iot.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes left, Azure.Iot.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes right) { throw null; }
        public static implicit operator Azure.Iot.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes (string value) { throw null; }
        public static bool operator !=(Azure.Iot.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes left, Azure.Iot.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
}
