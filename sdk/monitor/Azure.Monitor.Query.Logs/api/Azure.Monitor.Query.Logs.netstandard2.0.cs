namespace Azure.Monitor.Query.Logs
{
    public partial class AzureMonitorQueryLogsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureMonitorQueryLogsContext() { }
        public static Azure.Monitor.Query.Logs.AzureMonitorQueryLogsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogsQueryAudience : System.IEquatable<Azure.Monitor.Query.Logs.LogsQueryAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogsQueryAudience(string value) { throw null; }
        public static Azure.Monitor.Query.Logs.LogsQueryAudience AzureChina { get { throw null; } }
        public static Azure.Monitor.Query.Logs.LogsQueryAudience AzureGovernment { get { throw null; } }
        public static Azure.Monitor.Query.Logs.LogsQueryAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.Monitor.Query.Logs.LogsQueryAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Query.Logs.LogsQueryAudience left, Azure.Monitor.Query.Logs.LogsQueryAudience right) { throw null; }
        public static implicit operator Azure.Monitor.Query.Logs.LogsQueryAudience (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.Query.Logs.LogsQueryAudience left, Azure.Monitor.Query.Logs.LogsQueryAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogsQueryClient
    {
        protected LogsQueryClient() { }
        public LogsQueryClient(Azure.Core.TokenCredential credential) { }
        public LogsQueryClient(Azure.Core.TokenCredential credential, Azure.Monitor.Query.Logs.LogsQueryClientOptions options) { }
        public LogsQueryClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public LogsQueryClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Monitor.Query.Logs.LogsQueryClientOptions options) { }
        public System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public static string CreateQuery(System.FormattableString query) { throw null; }
        public virtual Azure.Response<Azure.Monitor.Query.Logs.Models.LogsBatchQueryResultCollection> QueryBatch(Azure.Monitor.Query.Logs.Models.LogsBatchQuery batch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitor.Query.Logs.Models.LogsBatchQueryResultCollection>> QueryBatchAsync(Azure.Monitor.Query.Logs.Models.LogsBatchQuery batch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Monitor.Query.Logs.Models.LogsQueryResult> QueryResource(Azure.Core.ResourceIdentifier resourceId, string query, Azure.Monitor.Query.Logs.QueryTimeRange timeRange, Azure.Monitor.Query.Logs.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitor.Query.Logs.Models.LogsQueryResult>> QueryResourceAsync(Azure.Core.ResourceIdentifier resourceId, string query, Azure.Monitor.Query.Logs.QueryTimeRange timeRange, Azure.Monitor.Query.Logs.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<T>>> QueryResourceAsync<T>(Azure.Core.ResourceIdentifier resourceId, string query, Azure.Monitor.Query.Logs.QueryTimeRange timeRange, Azure.Monitor.Query.Logs.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<T>> QueryResource<T>(Azure.Core.ResourceIdentifier resourceId, string query, Azure.Monitor.Query.Logs.QueryTimeRange timeRange, Azure.Monitor.Query.Logs.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Monitor.Query.Logs.Models.LogsQueryResult> QueryWorkspace(string workspaceId, string query, Azure.Monitor.Query.Logs.QueryTimeRange timeRange, Azure.Monitor.Query.Logs.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitor.Query.Logs.Models.LogsQueryResult>> QueryWorkspaceAsync(string workspaceId, string query, Azure.Monitor.Query.Logs.QueryTimeRange timeRange, Azure.Monitor.Query.Logs.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<T>>> QueryWorkspaceAsync<T>(string workspaceId, string query, Azure.Monitor.Query.Logs.QueryTimeRange timeRange, Azure.Monitor.Query.Logs.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<T>> QueryWorkspace<T>(string workspaceId, string query, Azure.Monitor.Query.Logs.QueryTimeRange timeRange, Azure.Monitor.Query.Logs.LogsQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogsQueryClientOptions : Azure.Core.ClientOptions
    {
        public LogsQueryClientOptions(Azure.Monitor.Query.Logs.LogsQueryClientOptions.ServiceVersion version = Azure.Monitor.Query.Logs.LogsQueryClientOptions.ServiceVersion.V1) { }
        public Azure.Monitor.Query.Logs.LogsQueryAudience? Audience { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V1 = 1,
        }
    }
    public partial class LogsQueryOptions
    {
        public LogsQueryOptions() { }
        public System.Collections.Generic.IList<string> AdditionalWorkspaces { get { throw null; } }
        public bool AllowPartialErrors { get { throw null; } set { } }
        public bool IncludeStatistics { get { throw null; } set { } }
        public bool IncludeVisualization { get { throw null; } set { } }
        public System.TimeSpan? ServerTimeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryTimeRange : System.IEquatable<Azure.Monitor.Query.Logs.QueryTimeRange>
    {
        public QueryTimeRange(System.DateTimeOffset start, System.DateTimeOffset end) { throw null; }
        public QueryTimeRange(System.DateTimeOffset start, System.TimeSpan duration) { throw null; }
        public QueryTimeRange(System.TimeSpan duration) { throw null; }
        public QueryTimeRange(System.TimeSpan duration, System.DateTimeOffset end) { throw null; }
        public static Azure.Monitor.Query.Logs.QueryTimeRange All { get { throw null; } }
        public System.TimeSpan Duration { get { throw null; } }
        public System.DateTimeOffset? End { get { throw null; } }
        public System.DateTimeOffset? Start { get { throw null; } }
        public bool Equals(Azure.Monitor.Query.Logs.QueryTimeRange other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Query.Logs.QueryTimeRange left, Azure.Monitor.Query.Logs.QueryTimeRange right) { throw null; }
        public static implicit operator Azure.Monitor.Query.Logs.QueryTimeRange (System.TimeSpan timeSpan) { throw null; }
        public static bool operator !=(Azure.Monitor.Query.Logs.QueryTimeRange left, Azure.Monitor.Query.Logs.QueryTimeRange right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.Monitor.Query.Logs.Models
{
    public partial class LogsBatchQuery
    {
        public LogsBatchQuery() { }
        public virtual string AddWorkspaceQuery(string workspaceId, string query, Azure.Monitor.Query.Logs.QueryTimeRange timeRange, Azure.Monitor.Query.Logs.LogsQueryOptions options = null) { throw null; }
    }
    public partial class LogsBatchQueryResult : Azure.Monitor.Query.Logs.Models.LogsQueryResult, System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult>
    {
        internal LogsBatchQueryResult() { }
        public string Id { get { throw null; } }
        protected new Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected new Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogsBatchQueryResultCollection : System.Collections.ObjectModel.ReadOnlyCollection<Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult>
    {
        internal LogsBatchQueryResultCollection() : base (default(System.Collections.Generic.IList<Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult>)) { }
        public Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult GetResult(string queryId) { throw null; }
        public System.Collections.Generic.IReadOnlyList<T> GetResult<T>(string queryId) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogsColumnType : System.IEquatable<Azure.Monitor.Query.Logs.Models.LogsColumnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogsColumnType(string value) { throw null; }
        public static Azure.Monitor.Query.Logs.Models.LogsColumnType Bool { get { throw null; } }
        public static Azure.Monitor.Query.Logs.Models.LogsColumnType Datetime { get { throw null; } }
        public static Azure.Monitor.Query.Logs.Models.LogsColumnType Decimal { get { throw null; } }
        public static Azure.Monitor.Query.Logs.Models.LogsColumnType Dynamic { get { throw null; } }
        public static Azure.Monitor.Query.Logs.Models.LogsColumnType Guid { get { throw null; } }
        public static Azure.Monitor.Query.Logs.Models.LogsColumnType Int { get { throw null; } }
        public static Azure.Monitor.Query.Logs.Models.LogsColumnType Long { get { throw null; } }
        public static Azure.Monitor.Query.Logs.Models.LogsColumnType Real { get { throw null; } }
        public static Azure.Monitor.Query.Logs.Models.LogsColumnType String { get { throw null; } }
        public static Azure.Monitor.Query.Logs.Models.LogsColumnType Timespan { get { throw null; } }
        public bool Equals(Azure.Monitor.Query.Logs.Models.LogsColumnType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Query.Logs.Models.LogsColumnType left, Azure.Monitor.Query.Logs.Models.LogsColumnType right) { throw null; }
        public static implicit operator Azure.Monitor.Query.Logs.Models.LogsColumnType (string value) { throw null; }
        public static implicit operator Azure.Monitor.Query.Logs.Models.LogsColumnType? (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.Query.Logs.Models.LogsColumnType left, Azure.Monitor.Query.Logs.Models.LogsColumnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogsQueryResult : System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Logs.Models.LogsQueryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsQueryResult>
    {
        internal LogsQueryResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Logs.Models.LogsTable> AllTables { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Monitor.Query.Logs.Models.LogsQueryResultStatus Status { get { throw null; } }
        public Azure.Monitor.Query.Logs.Models.LogsTable Table { get { throw null; } }
        public System.BinaryData GetStatistics() { throw null; }
        public System.BinaryData GetVisualization() { throw null; }
        protected virtual Azure.Monitor.Query.Logs.Models.LogsQueryResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Monitor.Query.Logs.Models.LogsQueryResult (Azure.Response result) { throw null; }
        protected virtual Azure.Monitor.Query.Logs.Models.LogsQueryResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Monitor.Query.Logs.Models.LogsQueryResult System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Logs.Models.LogsQueryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Logs.Models.LogsQueryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Monitor.Query.Logs.Models.LogsQueryResult System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsQueryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsQueryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsQueryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum LogsQueryResultStatus
    {
        Success = 0,
        PartialFailure = 1,
        Failure = 2,
    }
    public partial class LogsTable : System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Logs.Models.LogsTable>, System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsTable>
    {
        internal LogsTable() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Logs.Models.LogsTableColumn> Columns { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Logs.Models.LogsTableRow> Rows { get { throw null; } }
        protected virtual Azure.Monitor.Query.Logs.Models.LogsTable JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Monitor.Query.Logs.Models.LogsTable PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Monitor.Query.Logs.Models.LogsTable System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Logs.Models.LogsTable>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Logs.Models.LogsTable>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Monitor.Query.Logs.Models.LogsTable System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsTable>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsTable>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsTable>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogsTableColumn : System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Logs.Models.LogsTableColumn>, System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsTableColumn>
    {
        internal LogsTableColumn() { }
        public string Name { get { throw null; } }
        public Azure.Monitor.Query.Logs.Models.LogsColumnType Type { get { throw null; } }
        protected virtual Azure.Monitor.Query.Logs.Models.LogsTableColumn JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Monitor.Query.Logs.Models.LogsTableColumn PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Monitor.Query.Logs.Models.LogsTableColumn System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Logs.Models.LogsTableColumn>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Monitor.Query.Logs.Models.LogsTableColumn>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Monitor.Query.Logs.Models.LogsTableColumn System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsTableColumn>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsTableColumn>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Monitor.Query.Logs.Models.LogsTableColumn>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogsTableRow : System.Collections.Generic.IEnumerable<object>, System.Collections.Generic.IReadOnlyCollection<object>, System.Collections.Generic.IReadOnlyList<object>, System.Collections.IEnumerable
    {
        internal LogsTableRow() { }
        public int Count { get { throw null; } }
        public object this[int index] { get { throw null; } }
        public object this[string name] { get { throw null; } }
        public bool? GetBoolean(int index) { throw null; }
        public bool? GetBoolean(string name) { throw null; }
        public System.DateTimeOffset? GetDateTimeOffset(int index) { throw null; }
        public System.DateTimeOffset? GetDateTimeOffset(string name) { throw null; }
        public decimal? GetDecimal(int index) { throw null; }
        public decimal? GetDecimal(string name) { throw null; }
        public double? GetDouble(int index) { throw null; }
        public double? GetDouble(string name) { throw null; }
        public System.BinaryData GetDynamic(int index) { throw null; }
        public System.BinaryData GetDynamic(string name) { throw null; }
        public System.Guid? GetGuid(int index) { throw null; }
        public System.Guid? GetGuid(string name) { throw null; }
        public int? GetInt32(int index) { throw null; }
        public int? GetInt32(string name) { throw null; }
        public long? GetInt64(int index) { throw null; }
        public long? GetInt64(string name) { throw null; }
        public string GetString(int index) { throw null; }
        public string GetString(string name) { throw null; }
        public System.TimeSpan? GetTimeSpan(int index) { throw null; }
        public System.TimeSpan? GetTimeSpan(string name) { throw null; }
        System.Collections.Generic.IEnumerator<object> System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class MonitorQueryModelFactory
    {
        public static Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult LogsBatchQueryResult(System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Logs.Models.LogsTable> allTables, System.BinaryData error, System.BinaryData statistics, System.BinaryData visualization) { throw null; }
        public static Azure.Monitor.Query.Logs.Models.LogsBatchQueryResultCollection LogsBatchQueryResultCollection(System.Collections.Generic.IList<Azure.Monitor.Query.Logs.Models.LogsBatchQueryResult> batchQueryResults, Azure.Monitor.Query.Logs.Models.LogsBatchQuery query) { throw null; }
        public static Azure.Monitor.Query.Logs.Models.LogsQueryResult LogsQueryResult(System.Collections.Generic.IReadOnlyList<Azure.Monitor.Query.Logs.Models.LogsTable> allTables, System.BinaryData error, System.BinaryData statistics, System.BinaryData visualization) { throw null; }
        public static Azure.Monitor.Query.Logs.Models.LogsTable LogsTable(string name, System.Collections.Generic.IEnumerable<Azure.Monitor.Query.Logs.Models.LogsTableColumn> columns, System.Collections.Generic.IEnumerable<Azure.Monitor.Query.Logs.Models.LogsTableRow> rows) { throw null; }
        public static Azure.Monitor.Query.Logs.Models.LogsTableColumn LogsTableColumn(string name = null, Azure.Monitor.Query.Logs.Models.LogsColumnType type = default(Azure.Monitor.Query.Logs.Models.LogsColumnType)) { throw null; }
        public static Azure.Monitor.Query.Logs.Models.LogsTableRow LogsTableRow(System.Collections.Generic.IEnumerable<Azure.Monitor.Query.Logs.Models.LogsTableColumn> columns, System.Collections.Generic.IEnumerable<object> values) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class QueryLogsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Monitor.Query.Logs.LogsQueryClient, Azure.Monitor.Query.Logs.LogsQueryClientOptions> AddLogsQueryClient<TBuilder>(this TBuilder builder) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Monitor.Query.Logs.LogsQueryClient, Azure.Monitor.Query.Logs.LogsQueryClientOptions> AddLogsQueryClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Monitor.Query.Logs.LogsQueryClient, Azure.Monitor.Query.Logs.LogsQueryClientOptions> AddLogsQueryClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
