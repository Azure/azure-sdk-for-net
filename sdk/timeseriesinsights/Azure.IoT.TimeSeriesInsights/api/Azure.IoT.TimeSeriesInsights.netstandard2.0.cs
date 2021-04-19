namespace Azure.IoT.TimeSeriesInsights
{
    public partial class AggregateSeries
    {
        public AggregateSeries(System.Collections.Generic.IEnumerable<object> timeSeriesId, Azure.IoT.TimeSeriesInsights.DateTimeRange searchSpan, System.TimeSpan interval) { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesExpression Filter { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.IoT.TimeSeriesInsights.TimeSeriesVariable> InlineVariables { get { throw null; } }
        public System.TimeSpan Interval { get { throw null; } }
        public System.Collections.Generic.IList<string> ProjectedVariables { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.DateTimeRange SearchSpan { get { throw null; } }
        public System.Collections.Generic.IList<object> TimeSeriesId { get { throw null; } }
    }
    public partial class AggregateVariable : Azure.IoT.TimeSeriesInsights.TimeSeriesVariable
    {
        public AggregateVariable(Azure.IoT.TimeSeriesInsights.TimeSeriesExpression aggregation) { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesExpression Aggregation { get { throw null; } set { } }
    }
    public partial class AvailabilityResponse
    {
        internal AvailabilityResponse() { }
        public Azure.IoT.TimeSeriesInsights.EventAvailability Availability { get { throw null; } }
    }
    public partial class CategoricalVariable : Azure.IoT.TimeSeriesInsights.TimeSeriesVariable
    {
        public CategoricalVariable(Azure.IoT.TimeSeriesInsights.TimeSeriesExpression value, Azure.IoT.TimeSeriesInsights.TimeSeriesDefaultCategory defaultCategory) { }
        public System.Collections.Generic.IList<Azure.IoT.TimeSeriesInsights.TimeSeriesAggregateCategory> Categories { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesDefaultCategory DefaultCategory { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.InterpolationOperation Interpolation { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesExpression Value { get { throw null; } set { } }
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
        public Azure.IoT.TimeSeriesInsights.DateTimeRange Range { get { throw null; } }
    }
    public partial class EventProperty
    {
        public EventProperty() { }
        public string Name { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.PropertyTypes? Type { get { throw null; } set { } }
    }
    public partial class EventSchema
    {
        internal EventSchema() { }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.EventProperty> Properties { get { throw null; } }
    }
    public partial class GetEvents
    {
        public GetEvents(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, Azure.IoT.TimeSeriesInsights.DateTimeRange searchSpan) { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesExpression Filter { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.IoT.TimeSeriesInsights.EventProperty> ProjectedProperties { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.DateTimeRange SearchSpan { get { throw null; } }
        public int? Take { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesId TimeSeriesId { get { throw null; } }
    }
    public partial class GetEventSchemaRequest
    {
        public GetEventSchemaRequest(Azure.IoT.TimeSeriesInsights.DateTimeRange searchSpan) { }
        public Azure.IoT.TimeSeriesInsights.DateTimeRange SearchSpan { get { throw null; } }
    }
    public partial class GetHierarchiesPage : Azure.IoT.TimeSeriesInsights.PagedResponse
    {
        internal GetHierarchiesPage() { }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchy> Hierarchies { get { throw null; } }
    }
    public partial class GetInstancesPage : Azure.IoT.TimeSeriesInsights.PagedResponse
    {
        internal GetInstancesPage() { }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.TimeSeriesInstance> Instances { get { throw null; } }
    }
    public partial class GetSeries
    {
        public GetSeries(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, Azure.IoT.TimeSeriesInsights.DateTimeRange searchSpan) { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesExpression Filter { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.IoT.TimeSeriesInsights.TimeSeriesVariable> InlineVariables { get { throw null; } }
        public System.Collections.Generic.IList<string> ProjectedVariables { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.DateTimeRange SearchSpan { get { throw null; } }
        public int? Take { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesId TimeSeriesId { get { throw null; } }
    }
    public partial class GetTypesPage : Azure.IoT.TimeSeriesInsights.PagedResponse
    {
        internal GetTypesPage() { }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.TimeSeriesType> Types { get { throw null; } }
    }
    public partial class HierarchiesBatchRequest
    {
        public HierarchiesBatchRequest() { }
        public Azure.IoT.TimeSeriesInsights.HierarchiesRequestBatchGetDelete Delete { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.HierarchiesRequestBatchGetDelete Get { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchy> Put { get { throw null; } }
    }
    public partial class HierarchiesBatchResponse
    {
        internal HierarchiesBatchResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError> Delete { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchyOperationResult> Get { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchyOperationResult> Put { get { throw null; } }
    }
    public partial class HierarchiesClient
    {
        protected HierarchiesClient() { }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchyOperationResult[]> CreateOrReplace(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchy> timeSeriesHierarchies, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchyOperationResult[]>> CreateOrReplaceAsync(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchy> timeSeriesHierarchies, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]> DeleteById(System.Collections.Generic.IEnumerable<string> timeSeriesHierarchyIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]>> DeleteByIdAsync(System.Collections.Generic.IEnumerable<string> timeSeriesHierarchyIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]> DeleteByName(System.Collections.Generic.IEnumerable<string> timeSeriesHierarchyNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]>> DeleteByNameAsync(System.Collections.Generic.IEnumerable<string> timeSeriesHierarchyNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchy> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchyOperationResult[]> GetById(System.Collections.Generic.IEnumerable<string> timeSeriesHierarchyIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchyOperationResult[]>> GetByIdAsync(System.Collections.Generic.IEnumerable<string> timeSeriesHierarchyIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchyOperationResult[]> GetByName(System.Collections.Generic.IEnumerable<string> timeSeriesHierarchyNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchyOperationResult[]>> GetByNameAsync(System.Collections.Generic.IEnumerable<string> timeSeriesHierarchyNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HierarchiesExpandParameter
    {
        public HierarchiesExpandParameter() { }
        public Azure.IoT.TimeSeriesInsights.Models.HierarchiesExpandKind? Kind { get { throw null; } set { } }
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
        public Azure.IoT.TimeSeriesInsights.Models.HierarchiesSortBy? By { get { throw null; } set { } }
    }
    public partial class HierarchyHit
    {
        internal HierarchyHit() { }
        public int? CumulativeInstanceCount { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.SearchHierarchyNodesResponse HierarchyNodes { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class InstanceHit
    {
        internal InstanceHit() { }
        public System.Collections.Generic.IReadOnlyList<string> HierarchyIds { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.Models.InstanceHitHighlights Highlights { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<object> TimeSeriesId { get { throw null; } }
        public string TypeId { get { throw null; } }
    }
    public partial class InstancesBatchRequest
    {
        public InstancesBatchRequest() { }
        public Azure.IoT.TimeSeriesInsights.InstancesRequestBatchGetOrDelete Delete { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.InstancesRequestBatchGetOrDelete Get { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.IoT.TimeSeriesInsights.TimeSeriesInstance> Put { get { throw null; } }
        public System.Collections.Generic.IList<Azure.IoT.TimeSeriesInsights.TimeSeriesInstance> Update { get { throw null; } }
    }
    public partial class InstancesBatchResponse
    {
        internal InstancesBatchResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError> Delete { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.InstancesOperationResult> Get { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.InstancesOperationResult> Put { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.InstancesOperationResult> Update { get { throw null; } }
    }
    public partial class InstancesClient
    {
        protected InstancesClient() { }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]> CreateOrReplace(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesInstance> timeSeriesInstances, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]>> CreateOrReplaceAsync(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesInstance> timeSeriesInstances, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]> Delete(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesId> timeSeriesIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]> Delete(System.Collections.Generic.IEnumerable<string> timeSeriesNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]>> DeleteAsync(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesId> timeSeriesIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]>> DeleteAsync(System.Collections.Generic.IEnumerable<string> timeSeriesNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.InstancesOperationResult[]> Get(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesId> timeSeriesIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.InstancesOperationResult[]> Get(System.Collections.Generic.IEnumerable<string> timeSeriesNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.IoT.TimeSeriesInsights.TimeSeriesInstance> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.InstancesOperationResult[]>> GetAsync(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesId> timeSeriesIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.InstancesOperationResult[]>> GetAsync(System.Collections.Generic.IEnumerable<string> timeSeriesNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.IoT.TimeSeriesInsights.TimeSeriesInstance> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.SearchSuggestion[]> GetSearchSuggestions(string searchString, int? maxNumberOfSuggestions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.SearchSuggestion[]>> GetSearchSuggestionsAsync(string searchString, int? maxNumberOfSuggestions = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.InstancesOperationResult[]> Replace(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesInstance> timeSeriesInstances, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.InstancesOperationResult[]>> ReplaceAsync(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesInstance> timeSeriesInstances, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstancesOperationResult
    {
        internal InstancesOperationResult() { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError Error { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesInstance Instance { get { throw null; } }
    }
    public partial class InstancesRequestBatchGetOrDelete
    {
        public InstancesRequestBatchGetOrDelete() { }
        public System.Collections.Generic.IList<string> Names { get { throw null; } }
        public System.Collections.Generic.IList<Azure.IoT.TimeSeriesInsights.TimeSeriesId> TimeSeriesIds { get { throw null; } }
    }
    public partial class InstancesSortParameter
    {
        public InstancesSortParameter() { }
        public Azure.IoT.TimeSeriesInsights.Models.InstancesSortBy? By { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.SearchSuggestion> Suggestions { get { throw null; } }
    }
    public partial class InterpolationOperation
    {
        public InterpolationOperation() { }
        public Azure.IoT.TimeSeriesInsights.Models.InterpolationBoundary Boundary { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.Models.InterpolationKind? Kind { get { throw null; } set { } }
    }
    public partial class ModelSettingsClient
    {
        protected ModelSettingsClient() { }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesModelSettings> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesModelSettings>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesModelSettings> UpdateDefaultTypeId(string defaultTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesModelSettings>> UpdateDefaultTypeIdAsync(string defaultTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesModelSettings> UpdateName(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesModelSettings>> UpdateNameAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelSettingsResponse
    {
        internal ModelSettingsResponse() { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesModelSettings ModelSettings { get { throw null; } }
    }
    public partial class NumericVariable : Azure.IoT.TimeSeriesInsights.TimeSeriesVariable
    {
        public NumericVariable(Azure.IoT.TimeSeriesInsights.TimeSeriesExpression value, Azure.IoT.TimeSeriesInsights.TimeSeriesExpression aggregation) { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesExpression Aggregation { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.InterpolationOperation Interpolation { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesExpression Value { get { throw null; } set { } }
    }
    public partial class PagedResponse
    {
        internal PagedResponse() { }
        public string ContinuationToken { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PropertyTypes : System.IEquatable<Azure.IoT.TimeSeriesInsights.PropertyTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PropertyTypes(string value) { throw null; }
        public static Azure.IoT.TimeSeriesInsights.PropertyTypes Bool { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.PropertyTypes DateTime { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.PropertyTypes Double { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.PropertyTypes Long { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.PropertyTypes String { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.PropertyTypes TimeSpan { get { throw null; } }
        public bool Equals(Azure.IoT.TimeSeriesInsights.PropertyTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.TimeSeriesInsights.PropertyTypes left, Azure.IoT.TimeSeriesInsights.PropertyTypes right) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.PropertyTypes (string value) { throw null; }
        public static bool operator !=(Azure.IoT.TimeSeriesInsights.PropertyTypes left, Azure.IoT.TimeSeriesInsights.PropertyTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PropertyValues : Azure.IoT.TimeSeriesInsights.EventProperty
    {
        public PropertyValues() { }
        public System.Collections.Generic.IList<object> Values { get { throw null; } }
    }
    public partial class QueryClient
    {
        protected QueryClient() { }
        public virtual Azure.Pageable<Azure.IoT.TimeSeriesInsights.QueryResultPage> GetEvents(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, Azure.IoT.TimeSeriesInsights.QueryEventsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.IoT.TimeSeriesInsights.QueryResultPage> GetEvents(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, System.TimeSpan timeSpan, System.DateTimeOffset? endTime = default(System.DateTimeOffset?), Azure.IoT.TimeSeriesInsights.QueryEventsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.IoT.TimeSeriesInsights.QueryResultPage> GetEventsAsync(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, Azure.IoT.TimeSeriesInsights.QueryEventsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.IoT.TimeSeriesInsights.QueryResultPage> GetEventsAsync(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, System.TimeSpan timeSpan, System.DateTimeOffset? endTime = default(System.DateTimeOffset?), Azure.IoT.TimeSeriesInsights.QueryEventsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.IoT.TimeSeriesInsights.QueryResultPage> GetSeries(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, Azure.IoT.TimeSeriesInsights.QuerySeriesRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.IoT.TimeSeriesInsights.QueryResultPage> GetSeries(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, System.TimeSpan timeSpan, System.DateTimeOffset? endTime = default(System.DateTimeOffset?), Azure.IoT.TimeSeriesInsights.QuerySeriesRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.IoT.TimeSeriesInsights.QueryResultPage> GetSeriesAsync(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, Azure.IoT.TimeSeriesInsights.QuerySeriesRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.IoT.TimeSeriesInsights.QueryResultPage> GetSeriesAsync(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, System.TimeSpan timeSpan, System.DateTimeOffset? endTime = default(System.DateTimeOffset?), Azure.IoT.TimeSeriesInsights.QuerySeriesRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QueryEventsRequestOptions : Azure.IoT.TimeSeriesInsights.QueryRequestOptions
    {
        public QueryEventsRequestOptions() { }
        public System.Collections.Generic.List<Azure.IoT.TimeSeriesInsights.EventProperty> ProjectedProperties { get { throw null; } }
    }
    public partial class QueryRequest
    {
        public QueryRequest() { }
        public Azure.IoT.TimeSeriesInsights.AggregateSeries AggregateSeries { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.GetEvents GetEvents { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.GetSeries GetSeries { get { throw null; } set { } }
    }
    public abstract partial class QueryRequestOptions
    {
        protected QueryRequestOptions() { }
        public string Filter { get { throw null; } set { } }
        public int? MaximumNumberOfEvents { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.StoreType StoreType { get { throw null; } set { } }
    }
    public partial class QueryResultPage : Azure.IoT.TimeSeriesInsights.PagedResponse
    {
        internal QueryResultPage() { }
        public double? Progress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.PropertyValues> Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> Timestamps { get { throw null; } }
    }
    public partial class QuerySeriesRequestOptions : Azure.IoT.TimeSeriesInsights.QueryRequestOptions
    {
        public QuerySeriesRequestOptions() { }
        public System.Collections.Generic.IDictionary<string, Azure.IoT.TimeSeriesInsights.TimeSeriesVariable> InlineVariables { get { throw null; } }
        public System.Collections.Generic.List<string> ProjectedVariables { get { throw null; } }
    }
    public partial class SearchHierarchyNodesResponse
    {
        internal SearchHierarchyNodesResponse() { }
        public string ContinuationToken { get { throw null; } }
        public int? HitCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.HierarchyHit> Hits { get { throw null; } }
    }
    public partial class SearchInstancesHierarchiesParameters
    {
        public SearchInstancesHierarchiesParameters() { }
        public Azure.IoT.TimeSeriesInsights.HierarchiesExpandParameter Expand { get { throw null; } set { } }
        public int? PageSize { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.HierarchiesSortParameter Sort { get { throw null; } set { } }
    }
    public partial class SearchInstancesParameters
    {
        public SearchInstancesParameters() { }
        public bool? Highlights { get { throw null; } set { } }
        public int? PageSize { get { throw null; } set { } }
        public bool? Recursive { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.InstancesSortParameter Sort { get { throw null; } set { } }
    }
    public partial class SearchInstancesRequest
    {
        public SearchInstancesRequest(string searchString) { }
        public Azure.IoT.TimeSeriesInsights.SearchInstancesHierarchiesParameters Hierarchies { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.SearchInstancesParameters Instances { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Path { get { throw null; } }
        public string SearchString { get { throw null; } }
    }
    public partial class SearchInstancesResponse
    {
        internal SearchInstancesResponse() { }
        public string ContinuationToken { get { throw null; } }
        public int? HitCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.InstanceHit> Hits { get { throw null; } }
    }
    public partial class SearchInstancesResponsePage
    {
        internal SearchInstancesResponsePage() { }
        public Azure.IoT.TimeSeriesInsights.SearchHierarchyNodesResponse HierarchyNodes { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.SearchInstancesResponse Instances { get { throw null; } }
    }
    public partial class SearchSuggestion
    {
        internal SearchSuggestion() { }
        public string HighlightedSearchString { get { throw null; } }
        public string SearchString { get { throw null; } }
    }
    public partial class StoreType
    {
        internal StoreType() { }
        public static Azure.IoT.TimeSeriesInsights.StoreType ColdStore { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.StoreType WarmStore { get { throw null; } }
        public override string ToString() { throw null; }
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
        public TimeSeriesHierarchy(string name, Azure.IoT.TimeSeriesInsights.Models.TimeSeriesHierarchySource source) { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.Models.TimeSeriesHierarchySource Source { get { throw null; } set { } }
    }
    public partial class TimeSeriesHierarchyOperationResult
    {
        internal TimeSeriesHierarchyOperationResult() { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError Error { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchy Hierarchy { get { throw null; } }
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
        public Azure.IoT.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes? Type { get { throw null; } }
    }
    public partial class TimeSeriesInsightsClient
    {
        protected TimeSeriesInsightsClient() { }
        public TimeSeriesInsightsClient(string environmentFqdn, Azure.Core.TokenCredential credential) { }
        public TimeSeriesInsightsClient(string environmentFqdn, Azure.Core.TokenCredential credential, Azure.IoT.TimeSeriesInsights.TimeSeriesInsightsClientOptions options) { }
        public virtual Azure.IoT.TimeSeriesInsights.HierarchiesClient Hierarchies { get { throw null; } }
        public virtual Azure.IoT.TimeSeriesInsights.InstancesClient Instances { get { throw null; } }
        public virtual Azure.IoT.TimeSeriesInsights.ModelSettingsClient ModelSettings { get { throw null; } }
        public virtual Azure.IoT.TimeSeriesInsights.QueryClient Query { get { throw null; } }
        public virtual Azure.IoT.TimeSeriesInsights.TypesClient Types { get { throw null; } }
    }
    public partial class TimeSeriesInsightsClientOptions : Azure.Core.ClientOptions
    {
        public TimeSeriesInsightsClientOptions(Azure.IoT.TimeSeriesInsights.TimeSeriesInsightsClientOptions.ServiceVersion version = Azure.IoT.TimeSeriesInsights.TimeSeriesInsightsClientOptions.ServiceVersion.V2020_07_31) { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesInsightsClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2020_07_31 = 1,
        }
    }
    public partial class TimeSeriesInstance
    {
        public TimeSeriesInstance(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, string typeId) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> HierarchyIds { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> InstanceFields { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesId TimeSeriesId { get { throw null; } }
        public string TypeId { get { throw null; } set { } }
    }
    public partial class TimeSeriesModelSettings
    {
        internal TimeSeriesModelSettings() { }
        public string DefaultTypeId { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.TimeSeriesIdProperty> TimeSeriesIdProperties { get { throw null; } }
    }
    public partial class TimeSeriesOperationError : System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IReadOnlyDictionary<string, object>, System.Collections.IEnumerable
    {
        internal TimeSeriesOperationError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationErrorDetails> Details { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError InnerError { get { throw null; } }
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
        public TimeSeriesType(string name, System.Collections.Generic.IDictionary<string, Azure.IoT.TimeSeriesInsights.TimeSeriesVariable> variables) { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.IoT.TimeSeriesInsights.TimeSeriesVariable> Variables { get { throw null; } }
    }
    public partial class TimeSeriesTypeOperationResult
    {
        internal TimeSeriesTypeOperationResult() { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError Error { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesType TimeSeriesType { get { throw null; } }
    }
    public partial class TimeSeriesVariable
    {
        public TimeSeriesVariable() { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesExpression Filter { get { throw null; } set { } }
    }
    public partial class TypesBatchRequest
    {
        public TypesBatchRequest() { }
        public Azure.IoT.TimeSeriesInsights.TypesRequestBatchGetOrDelete Delete { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.TypesRequestBatchGetOrDelete Get { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.IoT.TimeSeriesInsights.TimeSeriesType> Put { get { throw null; } }
    }
    public partial class TypesBatchResponse
    {
        internal TypesBatchResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError> Delete { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.TimeSeriesTypeOperationResult> Get { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.TimeSeriesTypeOperationResult> Put { get { throw null; } }
    }
    public partial class TypesClient
    {
        protected TypesClient() { }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesTypeOperationResult[]> CreateOrReplace(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesType> timeSeriesTypes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesTypeOperationResult[]>> CreateOrReplaceAsync(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesType> timeSeriesTypes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]> DeleteById(System.Collections.Generic.IEnumerable<string> timeSeriesTypeIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]>> DeleteByIdAsync(System.Collections.Generic.IEnumerable<string> timeSeriesTypeIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]> DeleteByName(System.Collections.Generic.IEnumerable<string> timeSeriesTypeNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]>> DeleteByNameAsync(System.Collections.Generic.IEnumerable<string> timeSeriesTypeNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesTypeOperationResult[]> GetById(System.Collections.Generic.IEnumerable<string> timeSeriesTypeIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesTypeOperationResult[]>> GetByIdAsync(System.Collections.Generic.IEnumerable<string> timeSeriesTypeIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesTypeOperationResult[]> GetByName(System.Collections.Generic.IEnumerable<string> timeSeriesTypeNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesTypeOperationResult[]>> GetByNameAsync(System.Collections.Generic.IEnumerable<string> timeSeriesTypeNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.IoT.TimeSeriesInsights.TimeSeriesType> GetTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.IoT.TimeSeriesInsights.TimeSeriesType> GetTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TypesRequestBatchGetOrDelete
    {
        public TypesRequestBatchGetOrDelete() { }
        public System.Collections.Generic.IList<string> Names { get { throw null; } }
        public System.Collections.Generic.IList<string> TypeIds { get { throw null; } }
    }
}
namespace Azure.IoT.TimeSeriesInsights.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HierarchiesExpandKind : System.IEquatable<Azure.IoT.TimeSeriesInsights.Models.HierarchiesExpandKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HierarchiesExpandKind(string value) { throw null; }
        public static Azure.IoT.TimeSeriesInsights.Models.HierarchiesExpandKind OneLevel { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.Models.HierarchiesExpandKind UntilChildren { get { throw null; } }
        public bool Equals(Azure.IoT.TimeSeriesInsights.Models.HierarchiesExpandKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.TimeSeriesInsights.Models.HierarchiesExpandKind left, Azure.IoT.TimeSeriesInsights.Models.HierarchiesExpandKind right) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.Models.HierarchiesExpandKind (string value) { throw null; }
        public static bool operator !=(Azure.IoT.TimeSeriesInsights.Models.HierarchiesExpandKind left, Azure.IoT.TimeSeriesInsights.Models.HierarchiesExpandKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HierarchiesSortBy : System.IEquatable<Azure.IoT.TimeSeriesInsights.Models.HierarchiesSortBy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HierarchiesSortBy(string value) { throw null; }
        public static Azure.IoT.TimeSeriesInsights.Models.HierarchiesSortBy CumulativeInstanceCount { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.Models.HierarchiesSortBy Name { get { throw null; } }
        public bool Equals(Azure.IoT.TimeSeriesInsights.Models.HierarchiesSortBy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.TimeSeriesInsights.Models.HierarchiesSortBy left, Azure.IoT.TimeSeriesInsights.Models.HierarchiesSortBy right) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.Models.HierarchiesSortBy (string value) { throw null; }
        public static bool operator !=(Azure.IoT.TimeSeriesInsights.Models.HierarchiesSortBy left, Azure.IoT.TimeSeriesInsights.Models.HierarchiesSortBy right) { throw null; }
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
    public readonly partial struct InstancesSortBy : System.IEquatable<Azure.IoT.TimeSeriesInsights.Models.InstancesSortBy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstancesSortBy(string value) { throw null; }
        public static Azure.IoT.TimeSeriesInsights.Models.InstancesSortBy DisplayName { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.Models.InstancesSortBy Rank { get { throw null; } }
        public bool Equals(Azure.IoT.TimeSeriesInsights.Models.InstancesSortBy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.TimeSeriesInsights.Models.InstancesSortBy left, Azure.IoT.TimeSeriesInsights.Models.InstancesSortBy right) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.Models.InstancesSortBy (string value) { throw null; }
        public static bool operator !=(Azure.IoT.TimeSeriesInsights.Models.InstancesSortBy left, Azure.IoT.TimeSeriesInsights.Models.InstancesSortBy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InterpolationBoundary
    {
        public InterpolationBoundary() { }
        public System.TimeSpan? Span { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InterpolationKind : System.IEquatable<Azure.IoT.TimeSeriesInsights.Models.InterpolationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InterpolationKind(string value) { throw null; }
        public static Azure.IoT.TimeSeriesInsights.Models.InterpolationKind Linear { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.Models.InterpolationKind Step { get { throw null; } }
        public bool Equals(Azure.IoT.TimeSeriesInsights.Models.InterpolationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.TimeSeriesInsights.Models.InterpolationKind left, Azure.IoT.TimeSeriesInsights.Models.InterpolationKind right) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.Models.InterpolationKind (string value) { throw null; }
        public static bool operator !=(Azure.IoT.TimeSeriesInsights.Models.InterpolationKind left, Azure.IoT.TimeSeriesInsights.Models.InterpolationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimeSeriesHierarchySource
    {
        public TimeSeriesHierarchySource() { }
        public System.Collections.Generic.IList<string> InstanceFieldNames { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeSeriesIdPropertyTypes : System.IEquatable<Azure.IoT.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeSeriesIdPropertyTypes(string value) { throw null; }
        public static Azure.IoT.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes String { get { throw null; } }
        public bool Equals(Azure.IoT.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes left, Azure.IoT.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes right) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes (string value) { throw null; }
        public static bool operator !=(Azure.IoT.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes left, Azure.IoT.TimeSeriesInsights.Models.TimeSeriesIdPropertyTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
}
