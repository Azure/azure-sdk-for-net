namespace Azure.IoT.TimeSeriesInsights
{
    public partial class AggregateVariable : Azure.IoT.TimeSeriesInsights.TimeSeriesVariable
    {
        public AggregateVariable(Azure.IoT.TimeSeriesInsights.TimeSeriesExpression aggregation) { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesExpression Aggregation { get { throw null; } set { } }
    }
    public partial class CategoricalVariable : Azure.IoT.TimeSeriesInsights.TimeSeriesVariable
    {
        public CategoricalVariable(Azure.IoT.TimeSeriesInsights.TimeSeriesExpression value, Azure.IoT.TimeSeriesInsights.TimeSeriesDefaultCategory defaultCategory) { }
        public System.Collections.Generic.IList<Azure.IoT.TimeSeriesInsights.TimeSeriesAggregateCategory> Categories { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesDefaultCategory DefaultCategory { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesInterpolation Interpolation { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesExpression Value { get { throw null; } set { } }
    }
    public partial class InstancesOperationResult
    {
        internal InstancesOperationResult() { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError Error { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesInstance Instance { get { throw null; } }
    }
    public partial class InterpolationBoundary
    {
        public InterpolationBoundary() { }
        public System.TimeSpan? Span { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InterpolationKind : System.IEquatable<Azure.IoT.TimeSeriesInsights.InterpolationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InterpolationKind(string value) { throw null; }
        public static Azure.IoT.TimeSeriesInsights.InterpolationKind Linear { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.InterpolationKind Step { get { throw null; } }
        public bool Equals(Azure.IoT.TimeSeriesInsights.InterpolationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.TimeSeriesInsights.InterpolationKind left, Azure.IoT.TimeSeriesInsights.InterpolationKind right) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.InterpolationKind (string value) { throw null; }
        public static bool operator !=(Azure.IoT.TimeSeriesInsights.InterpolationKind left, Azure.IoT.TimeSeriesInsights.InterpolationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class IoTTimeSeriesInsightsModelFactory
    {
        public static Azure.IoT.TimeSeriesInsights.InstancesOperationResult InstancesOperationResult(Azure.IoT.TimeSeriesInsights.TimeSeriesInstance instance = null, Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError error = null) { throw null; }
        public static Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchyOperationResult TimeSeriesHierarchyOperationResult(Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchy hierarchy = null, Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError error = null) { throw null; }
        public static Azure.IoT.TimeSeriesInsights.TimeSeriesIdProperty TimeSeriesIdProperty(string name = null, Azure.IoT.TimeSeriesInsights.TimeSeriesIdPropertyType? type = default(Azure.IoT.TimeSeriesInsights.TimeSeriesIdPropertyType?)) { throw null; }
        public static Azure.IoT.TimeSeriesInsights.TimeSeriesModelSettings TimeSeriesModelSettings(string name = null, System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesIdProperty> timeSeriesIdProperties = null, string defaultTypeId = null) { throw null; }
        public static Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError TimeSeriesOperationError(string code = null, string message = null, string target = null, Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError innerError = null, System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationErrorDetails> details = null, System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.IoT.TimeSeriesInsights.TimeSeriesOperationErrorDetails TimeSeriesOperationErrorDetails(string code = null, string message = null, System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.IoT.TimeSeriesInsights.TimeSeriesTypeOperationResult TimeSeriesTypeOperationResult(Azure.IoT.TimeSeriesInsights.TimeSeriesType timeSeriesType = null, Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError error = null) { throw null; }
    }
    public partial class NumericVariable : Azure.IoT.TimeSeriesInsights.TimeSeriesVariable
    {
        public NumericVariable(Azure.IoT.TimeSeriesInsights.TimeSeriesExpression value, Azure.IoT.TimeSeriesInsights.TimeSeriesExpression aggregation) { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesExpression Aggregation { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesInterpolation Interpolation { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesExpression Value { get { throw null; } set { } }
    }
    public partial class PropertyValues : Azure.IoT.TimeSeriesInsights.TimeSeriesInsightsEventProperty
    {
        public PropertyValues() { }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.TimeSeriesInsights.TimeSeriesValue> Values { get { throw null; } }
    }
    public partial class QueryAggregateSeriesRequestOptions : Azure.IoT.TimeSeriesInsights.QueryRequestOptions
    {
        public QueryAggregateSeriesRequestOptions() { }
        public System.Collections.Generic.IDictionary<string, Azure.IoT.TimeSeriesInsights.TimeSeriesVariable> InlineVariables { get { throw null; } }
        public System.Collections.Generic.IList<string> ProjectedVariableNames { get { throw null; } }
    }
    public partial class QueryEventsRequestOptions : Azure.IoT.TimeSeriesInsights.QueryRequestOptions
    {
        public QueryEventsRequestOptions() { }
        public int? MaxNumberOfEvents { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.IoT.TimeSeriesInsights.TimeSeriesInsightsEventProperty> ProjectedProperties { get { throw null; } }
    }
    public abstract partial class QueryRequestOptions
    {
        protected QueryRequestOptions() { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesExpression Filter { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.StoreType Store { get { throw null; } set { } }
    }
    public partial class QuerySeriesRequestOptions : Azure.IoT.TimeSeriesInsights.QueryRequestOptions
    {
        public QuerySeriesRequestOptions() { }
        public System.Collections.Generic.IDictionary<string, Azure.IoT.TimeSeriesInsights.TimeSeriesVariable> InlineVariables { get { throw null; } }
        public int? MaxNumberOfEvents { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProjectedVariableNames { get { throw null; } }
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
        public TimeSeriesExpression(string expression) { }
        public string Expression { get { throw null; } set { } }
    }
    public partial class TimeSeriesHierarchy
    {
        public TimeSeriesHierarchy(string name, Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchySource source) { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchySource Source { get { throw null; } set { } }
    }
    public partial class TimeSeriesHierarchyOperationResult
    {
        internal TimeSeriesHierarchyOperationResult() { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError Error { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesHierarchy Hierarchy { get { throw null; } }
    }
    public partial class TimeSeriesHierarchySource
    {
        public TimeSeriesHierarchySource() { }
        public System.Collections.Generic.IList<string> InstanceFieldNames { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct TimeSeriesId : System.IEquatable<Azure.IoT.TimeSeriesInsights.TimeSeriesId>
    {
        private object _dummy;
        private int _dummyPrimitive;
        public TimeSeriesId(string key1) { throw null; }
        public TimeSeriesId(string key1, string key2) { throw null; }
        public TimeSeriesId(string key1, string key2, string key3) { throw null; }
        public bool Equals(Azure.IoT.TimeSeriesInsights.TimeSeriesId other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
        public string[] ToStringArray() { throw null; }
    }
    public partial class TimeSeriesIdProperty
    {
        internal TimeSeriesIdProperty() { }
        public string Name { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesIdPropertyType? PropertyType { get { throw null; } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesIdPropertyType? Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeSeriesIdPropertyType : System.IEquatable<Azure.IoT.TimeSeriesInsights.TimeSeriesIdPropertyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeSeriesIdPropertyType(string value) { throw null; }
        public static Azure.IoT.TimeSeriesInsights.TimeSeriesIdPropertyType String { get { throw null; } }
        public bool Equals(Azure.IoT.TimeSeriesInsights.TimeSeriesIdPropertyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.TimeSeriesInsights.TimeSeriesIdPropertyType left, Azure.IoT.TimeSeriesInsights.TimeSeriesIdPropertyType right) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.TimeSeriesIdPropertyType (string value) { throw null; }
        public static bool operator !=(Azure.IoT.TimeSeriesInsights.TimeSeriesIdPropertyType left, Azure.IoT.TimeSeriesInsights.TimeSeriesIdPropertyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimeSeriesInsightsClient
    {
        protected TimeSeriesInsightsClient() { }
        public TimeSeriesInsightsClient(string environmentFqdn, Azure.Core.TokenCredential credential) { }
        public TimeSeriesInsightsClient(string environmentFqdn, Azure.Core.TokenCredential credential, Azure.IoT.TimeSeriesInsights.TimeSeriesInsightsClientOptions options) { }
        public virtual Azure.IoT.TimeSeriesInsights.TimeSeriesInsightsHierarchies GetHierarchiesClient() { throw null; }
        public virtual Azure.IoT.TimeSeriesInsights.TimeSeriesInsightsInstances GetInstancesClient() { throw null; }
        public virtual Azure.IoT.TimeSeriesInsights.TimeSeriesInsightsModelSettings GetModelSettingsClient() { throw null; }
        public virtual Azure.IoT.TimeSeriesInsights.TimeSeriesInsightsQueries GetQueriesClient() { throw null; }
        public virtual Azure.IoT.TimeSeriesInsights.TimeSeriesInsightsTypes GetTypesClient() { throw null; }
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
    public partial class TimeSeriesInsightsEventProperty
    {
        public TimeSeriesInsightsEventProperty() { }
        public string Name { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesPropertyType? PropertyValueType { get { throw null; } set { } }
    }
    public partial class TimeSeriesInsightsHierarchies
    {
        protected TimeSeriesInsightsHierarchies() { }
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
    public partial class TimeSeriesInsightsInstances
    {
        protected TimeSeriesInsightsInstances() { }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]> CreateOrReplace(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesInstance> timeSeriesInstances, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]>> CreateOrReplaceAsync(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesInstance> timeSeriesInstances, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]> DeleteById(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesId> timeSeriesIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]>> DeleteByIdAsync(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesId> timeSeriesIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]> DeleteByName(System.Collections.Generic.IEnumerable<string> timeSeriesNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesOperationError[]>> DeleteByNameAsync(System.Collections.Generic.IEnumerable<string> timeSeriesNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.IoT.TimeSeriesInsights.TimeSeriesInstance> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.IoT.TimeSeriesInsights.TimeSeriesInstance> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.InstancesOperationResult[]> GetById(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesId> timeSeriesIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.InstancesOperationResult[]>> GetByIdAsync(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesId> timeSeriesIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.InstancesOperationResult[]> GetByName(System.Collections.Generic.IEnumerable<string> timeSeriesNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.InstancesOperationResult[]>> GetByNameAsync(System.Collections.Generic.IEnumerable<string> timeSeriesNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.InstancesOperationResult[]> Replace(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesInstance> timeSeriesInstances, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.InstancesOperationResult[]>> ReplaceAsync(System.Collections.Generic.IEnumerable<Azure.IoT.TimeSeriesInsights.TimeSeriesInstance> timeSeriesInstances, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TimeSeriesInsightsModelSettings
    {
        protected TimeSeriesInsightsModelSettings() { }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesModelSettings> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesModelSettings>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesModelSettings> UpdateDefaultTypeId(string defaultTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesModelSettings>> UpdateDefaultTypeIdAsync(string defaultTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesModelSettings> UpdateName(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.TimeSeriesInsights.TimeSeriesModelSettings>> UpdateNameAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TimeSeriesInsightsQueries
    {
        protected TimeSeriesInsightsQueries() { }
        public virtual Azure.IoT.TimeSeriesInsights.TimeSeriesQueryAnalyzer CreateAggregateSeriesQuery(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, System.TimeSpan interval, Azure.IoT.TimeSeriesInsights.QueryAggregateSeriesRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.IoT.TimeSeriesInsights.TimeSeriesQueryAnalyzer CreateAggregateSeriesQuery(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, System.TimeSpan interval, System.TimeSpan timeSpan, System.DateTimeOffset? endTime = default(System.DateTimeOffset?), Azure.IoT.TimeSeriesInsights.QueryAggregateSeriesRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.IoT.TimeSeriesInsights.TimeSeriesQueryAnalyzer CreateEventsQuery(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, Azure.IoT.TimeSeriesInsights.QueryEventsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.IoT.TimeSeriesInsights.TimeSeriesQueryAnalyzer CreateEventsQuery(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, System.TimeSpan timeSpan, System.DateTimeOffset? endTime = default(System.DateTimeOffset?), Azure.IoT.TimeSeriesInsights.QueryEventsRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.IoT.TimeSeriesInsights.TimeSeriesQueryAnalyzer CreateSeriesQuery(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, Azure.IoT.TimeSeriesInsights.QuerySeriesRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.IoT.TimeSeriesInsights.TimeSeriesQueryAnalyzer CreateSeriesQuery(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, System.TimeSpan timeSpan, System.DateTimeOffset? endTime = default(System.DateTimeOffset?), Azure.IoT.TimeSeriesInsights.QuerySeriesRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TimeSeriesInsightsTypes
    {
        protected TimeSeriesInsightsTypes() { }
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
    public partial class TimeSeriesInstance
    {
        public TimeSeriesInstance(Azure.IoT.TimeSeriesInsights.TimeSeriesId timeSeriesId, string typeId) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> HierarchyIds { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> InstanceFields { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesId TimeSeriesId { get { throw null; } }
        public string TimeSeriesTypeId { get { throw null; } set { } }
    }
    public partial class TimeSeriesInterpolation
    {
        public TimeSeriesInterpolation() { }
        public Azure.IoT.TimeSeriesInsights.InterpolationBoundary Boundary { get { throw null; } set { } }
        public Azure.IoT.TimeSeriesInsights.InterpolationKind? Kind { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct TimeSeriesPoint
    {
        private object _dummy;
        private int _dummyPrimitive;
        public TimeSeriesPoint(System.DateTimeOffset timestamp, System.Collections.Generic.IDictionary<string, Azure.IoT.TimeSeriesInsights.PropertyValues> propertyNameToPageValues, int index) { throw null; }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        public bool? GetNullableBoolean(string propertyName) { throw null; }
        public System.DateTimeOffset? GetNullableDateTimeOffset(string propertyName) { throw null; }
        public double? GetNullableDouble(string propertyName) { throw null; }
        public int? GetNullableInt(string propertyName) { throw null; }
        public string[] GetUniquePropertyNames() { throw null; }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesValue GetValue(string propertyName) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeSeriesPropertyType : System.IEquatable<Azure.IoT.TimeSeriesInsights.TimeSeriesPropertyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeSeriesPropertyType(string value) { throw null; }
        public static Azure.IoT.TimeSeriesInsights.TimeSeriesPropertyType Bool { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.TimeSeriesPropertyType DateTime { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.TimeSeriesPropertyType Double { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.TimeSeriesPropertyType Long { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.TimeSeriesPropertyType String { get { throw null; } }
        public static Azure.IoT.TimeSeriesInsights.TimeSeriesPropertyType TimeSpan { get { throw null; } }
        public bool Equals(Azure.IoT.TimeSeriesInsights.TimeSeriesPropertyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.TimeSeriesInsights.TimeSeriesPropertyType left, Azure.IoT.TimeSeriesInsights.TimeSeriesPropertyType right) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.TimeSeriesPropertyType (string value) { throw null; }
        public static bool operator !=(Azure.IoT.TimeSeriesInsights.TimeSeriesPropertyType left, Azure.IoT.TimeSeriesInsights.TimeSeriesPropertyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimeSeriesQueryAnalyzer
    {
        internal TimeSeriesQueryAnalyzer() { }
        public double? Progress { get { throw null; } }
        public Azure.Pageable<Azure.IoT.TimeSeriesInsights.TimeSeriesPoint> GetResults() { throw null; }
        public Azure.AsyncPageable<Azure.IoT.TimeSeriesInsights.TimeSeriesPoint> GetResultsAsync() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeSeriesValue
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeSeriesValue(bool value) { throw null; }
        public TimeSeriesValue(byte[] utf8, int index, int count) { throw null; }
        public TimeSeriesValue(System.DateTimeOffset value) { throw null; }
        public TimeSeriesValue(double value) { throw null; }
        public TimeSeriesValue(int value) { throw null; }
        public TimeSeriesValue(bool? value) { throw null; }
        public TimeSeriesValue(System.DateTimeOffset? value) { throw null; }
        public TimeSeriesValue(double? value) { throw null; }
        public TimeSeriesValue(int? value) { throw null; }
        public TimeSeriesValue(System.TimeSpan? value) { throw null; }
        public TimeSeriesValue(string value) { throw null; }
        public TimeSeriesValue(System.TimeSpan value) { throw null; }
        public System.Type Type { get { throw null; } }
        public static explicit operator bool (Azure.IoT.TimeSeriesInsights.TimeSeriesValue variant) { throw null; }
        public static explicit operator System.DateTimeOffset (Azure.IoT.TimeSeriesInsights.TimeSeriesValue variant) { throw null; }
        public static explicit operator double (Azure.IoT.TimeSeriesInsights.TimeSeriesValue variant) { throw null; }
        public static explicit operator int (Azure.IoT.TimeSeriesInsights.TimeSeriesValue variant) { throw null; }
        public static explicit operator bool? (Azure.IoT.TimeSeriesInsights.TimeSeriesValue variant) { throw null; }
        public static explicit operator System.DateTimeOffset? (Azure.IoT.TimeSeriesInsights.TimeSeriesValue variant) { throw null; }
        public static explicit operator double? (Azure.IoT.TimeSeriesInsights.TimeSeriesValue variant) { throw null; }
        public static explicit operator int? (Azure.IoT.TimeSeriesInsights.TimeSeriesValue variant) { throw null; }
        public static explicit operator System.TimeSpan? (Azure.IoT.TimeSeriesInsights.TimeSeriesValue variant) { throw null; }
        public static explicit operator string (Azure.IoT.TimeSeriesInsights.TimeSeriesValue variant) { throw null; }
        public static explicit operator System.TimeSpan (Azure.IoT.TimeSeriesInsights.TimeSeriesValue variant) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.TimeSeriesValue (bool value) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.TimeSeriesValue (System.DateTimeOffset value) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.TimeSeriesValue (double value) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.TimeSeriesValue (int value) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.TimeSeriesValue (bool? value) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.TimeSeriesValue (System.DateTimeOffset? value) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.TimeSeriesValue (double? value) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.TimeSeriesValue (int? value) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.TimeSeriesValue (System.TimeSpan? value) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.TimeSeriesValue (string value) { throw null; }
        public static implicit operator Azure.IoT.TimeSeriesInsights.TimeSeriesValue (System.TimeSpan value) { throw null; }
    }
    public abstract partial class TimeSeriesVariable
    {
        protected TimeSeriesVariable() { }
        public Azure.IoT.TimeSeriesInsights.TimeSeriesExpression Filter { get { throw null; } set { } }
    }
}
