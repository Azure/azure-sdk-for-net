namespace Azure.Data.Tables
{
    public partial interface ITableEntity
    {
        Azure.ETag ETag { get; set; }
        string PartitionKey { get; set; }
        string RowKey { get; set; }
        System.DateTimeOffset? Timestamp { get; set; }
    }
    public partial class TableClient
    {
        protected TableClient() { }
        public TableClient(string connectionString, string tableName) { }
        public TableClient(string connectionString, string tableName, Azure.Data.Tables.TableClientOptions options = null) { }
        public TableClient(System.Uri endpoint, string tableName, Azure.Data.Tables.TableClientOptions options = null) { }
        public TableClient(System.Uri endpoint, string tableName, Azure.Data.Tables.TableSharedKeyCredential credential) { }
        public TableClient(System.Uri endpoint, string tableName, Azure.Data.Tables.TableSharedKeyCredential credential, Azure.Data.Tables.TableClientOptions options = null) { }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddEntityAsync<T>(T entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity, new() { throw null; }
        public virtual Azure.Response AddEntity<T>(T entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity, new() { throw null; }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableItem> Create(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableItem>> CreateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableItem> CreateIfNotExists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableItem>> CreateIfNotExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static string CreateQueryFilter<T>(System.Linq.Expressions.Expression<System.Func<T, bool>> filter) { throw null; }
        public virtual Azure.Data.Tables.TableTransactionalBatch CreateTransactionalBatch(string partitionKey) { throw null; }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteEntity(string partitionKey, string rowKey, Azure.ETag ifMatch = default(Azure.ETag), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteEntityAsync(string partitionKey, string rowKey, Azure.ETag ifMatch = default(Azure.ETag), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Data.Tables.Models.SignedIdentifier>> GetAccessPolicy(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Data.Tables.Models.SignedIdentifier>>> GetAccessPolicyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<T>> GetEntityAsync<T>(string partitionKey, string rowKey, System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity, new() { throw null; }
        public virtual Azure.Response<T> GetEntity<T>(string partitionKey, string rowKey, System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity, new() { throw null; }
        public virtual Azure.Data.Tables.Sas.TableSasBuilder GetSasBuilder(Azure.Data.Tables.Sas.TableSasPermissions permissions, System.DateTimeOffset expiresOn) { throw null; }
        public virtual Azure.Data.Tables.Sas.TableSasBuilder GetSasBuilder(string rawPermissions, System.DateTimeOffset expiresOn) { throw null; }
        public virtual Azure.AsyncPageable<T> QueryAsync<T>(System.Linq.Expressions.Expression<System.Func<T, bool>> filter, int? maxPerPage = default(int?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity, new() { throw null; }
        public virtual Azure.AsyncPageable<T> QueryAsync<T>(string filter = null, int? maxPerPage = default(int?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity, new() { throw null; }
        public virtual Azure.Pageable<T> Query<T>(System.Linq.Expressions.Expression<System.Func<T, bool>> filter, int? maxPerPage = default(int?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity, new() { throw null; }
        public virtual Azure.Pageable<T> Query<T>(string filter = null, int? maxPerPage = default(int?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity, new() { throw null; }
        public virtual Azure.Response SetAccessPolicy(System.Collections.Generic.IEnumerable<Azure.Data.Tables.Models.SignedIdentifier> tableAcl, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetAccessPolicyAsync(System.Collections.Generic.IEnumerable<Azure.Data.Tables.Models.SignedIdentifier> tableAcl, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateEntityAsync<T>(T entity, Azure.ETag ifMatch, Azure.Data.Tables.TableUpdateMode mode = Azure.Data.Tables.TableUpdateMode.Merge, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity, new() { throw null; }
        public virtual Azure.Response UpdateEntity<T>(T entity, Azure.ETag ifMatch, Azure.Data.Tables.TableUpdateMode mode = Azure.Data.Tables.TableUpdateMode.Merge, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity, new() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpsertEntityAsync<T>(T entity, Azure.Data.Tables.TableUpdateMode mode = Azure.Data.Tables.TableUpdateMode.Merge, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity, new() { throw null; }
        public virtual Azure.Response UpsertEntity<T>(T entity, Azure.Data.Tables.TableUpdateMode mode = Azure.Data.Tables.TableUpdateMode.Merge, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity, new() { throw null; }
    }
    public partial class TableClientOptions : Azure.Core.ClientOptions
    {
        public TableClientOptions(Azure.Data.Tables.TableClientOptions.ServiceVersion serviceVersion = Azure.Data.Tables.TableClientOptions.ServiceVersion.V2019_02_02) { }
        public enum ServiceVersion
        {
            V2019_02_02 = 1,
        }
    }
    public sealed partial class TableEntity : Azure.Data.Tables.ITableEntity, System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public TableEntity() { }
        public TableEntity(System.Collections.Generic.IDictionary<string, object> values) { }
        public TableEntity(string partitionKey, string rowKey) { }
        public int Count { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } set { } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public string PartitionKey { get { throw null; } set { } }
        public string RowKey { get { throw null; } set { } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        System.Collections.Generic.ICollection<object> System.Collections.Generic.IDictionary<System.String,System.Object>.Values { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } set { } }
        public void Add(string key, object value) { }
        public void Clear() { }
        public bool ContainsKey(string key) { throw null; }
        public byte[] GetBinary(string key) { throw null; }
        public bool? GetBoolean(string key) { throw null; }
        public System.DateTime? GetDateTime(string key) { throw null; }
        public System.DateTimeOffset? GetDateTimeOffset(string key) { throw null; }
        public double? GetDouble(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public System.Guid? GetGuid(string key) { throw null; }
        public int? GetInt32(string key) { throw null; }
        public long? GetInt64(string key) { throw null; }
        public string GetString(string key) { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> item) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> item) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] array, int arrayIndex) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> item) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class TableServiceClient
    {
        protected TableServiceClient() { }
        public TableServiceClient(string connectionString) { }
        public TableServiceClient(string connectionString, Azure.Data.Tables.TableClientOptions options = null) { }
        public TableServiceClient(System.Uri endpoint) { }
        public TableServiceClient(System.Uri endpoint, Azure.Data.Tables.TableClientOptions options = null) { }
        public TableServiceClient(System.Uri endpoint, Azure.Data.Tables.TableSharedKeyCredential credential) { }
        public TableServiceClient(System.Uri endpoint, Azure.Data.Tables.TableSharedKeyCredential credential, Azure.Data.Tables.TableClientOptions options = null) { }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableItem> CreateTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableItem>> CreateTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableItem> CreateTableIfNotExists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableItem>> CreateTableIfNotExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableServiceProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableServiceProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Data.Tables.Sas.TableAccountSasBuilder GetSasBuilder(Azure.Data.Tables.Sas.TableAccountSasPermissions permissions, Azure.Data.Tables.Sas.TableAccountSasResourceTypes resourceTypes, System.DateTimeOffset expiresOn) { throw null; }
        public virtual Azure.Data.Tables.Sas.TableAccountSasBuilder GetSasBuilder(string rawPermissions, Azure.Data.Tables.Sas.TableAccountSasResourceTypes resourceTypes, System.DateTimeOffset expiresOn) { throw null; }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableServiceStatistics> GetStatistics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableServiceStatistics>> GetStatisticsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Data.Tables.TableClient GetTableClient(string tableName) { throw null; }
        public virtual Azure.Pageable<Azure.Data.Tables.Models.TableItem> GetTables(string filter = null, int? maxPerPage = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.Tables.Models.TableItem> GetTablesAsync(string filter = null, int? maxPerPage = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetProperties(Azure.Data.Tables.Models.TableServiceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetPropertiesAsync(Azure.Data.Tables.Models.TableServiceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TableSharedKeyCredential
    {
        public TableSharedKeyCredential(string accountName, string accountKey) { }
        public string AccountName { get { throw null; } }
        public void SetAccountKey(string accountKey) { }
    }
    public static partial class TablesModelFactory
    {
        public static Azure.Data.Tables.Models.TableItem TableItem(string tableName, string odataType, string odataId, string odataEditLink) { throw null; }
    }
    public partial class TableTransactionalBatch
    {
        protected TableTransactionalBatch() { }
        public virtual void AddEntities<T>(System.Collections.Generic.IEnumerable<T> entities) where T : class, Azure.Data.Tables.ITableEntity, new() { }
        public virtual void AddEntity<T>(T entity) where T : class, Azure.Data.Tables.ITableEntity, new() { }
        public virtual void DeleteEntity(string partitionKey, string rowKey, Azure.ETag ifMatch = default(Azure.ETag)) { }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableBatchResponse> SubmitBatch(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableBatchResponse>> SubmitBatchAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual bool TryGetFailedEntityFromException(Azure.RequestFailedException exception, out Azure.Data.Tables.ITableEntity failedEntity) { throw null; }
        public virtual void UpdateEntity<T>(T entity, Azure.ETag ifMatch, Azure.Data.Tables.TableUpdateMode mode = Azure.Data.Tables.TableUpdateMode.Merge) where T : class, Azure.Data.Tables.ITableEntity, new() { }
        public virtual void UpsertEntity<T>(T entity, Azure.Data.Tables.TableUpdateMode mode = Azure.Data.Tables.TableUpdateMode.Merge) where T : class, Azure.Data.Tables.ITableEntity, new() { }
    }
    public enum TableUpdateMode
    {
        Merge = 0,
        Replace = 1,
    }
}
namespace Azure.Data.Tables.Models
{
    public partial class RetentionPolicy
    {
        public RetentionPolicy(bool enabled) { }
        public int? Days { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
    }
    public partial class SignedIdentifier
    {
        public SignedIdentifier(string id, Azure.Data.Tables.Models.TableAccessPolicy accessPolicy) { }
        public Azure.Data.Tables.Models.TableAccessPolicy AccessPolicy { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
    }
    public partial class TableAccessPolicy
    {
        public TableAccessPolicy(System.DateTimeOffset startsOn, System.DateTimeOffset expiresOn, string permission) { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public string Permission { get { throw null; } set { } }
        public System.DateTimeOffset StartsOn { get { throw null; } set { } }
    }
    public partial class TableAnalyticsLoggingSettings
    {
        public TableAnalyticsLoggingSettings(string version, bool delete, bool read, bool write, Azure.Data.Tables.Models.RetentionPolicy retentionPolicy) { }
        public bool Delete { get { throw null; } set { } }
        public bool Read { get { throw null; } set { } }
        public Azure.Data.Tables.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public bool Write { get { throw null; } set { } }
    }
    public partial class TableBatchResponse
    {
        internal TableBatchResponse() { }
        public int ResponseCount { get { throw null; } }
        public Azure.Response GetResponseForEntity(string rowKey) { throw null; }
    }
    public partial class TableCorsRule
    {
        public TableCorsRule(string allowedOrigins, string allowedMethods, string allowedHeaders, string exposedHeaders, int maxAgeInSeconds) { }
        public string AllowedHeaders { get { throw null; } set { } }
        public string AllowedMethods { get { throw null; } set { } }
        public string AllowedOrigins { get { throw null; } set { } }
        public string ExposedHeaders { get { throw null; } set { } }
        public int MaxAgeInSeconds { get { throw null; } set { } }
    }
    public partial class TableGeoReplicationInfo
    {
        internal TableGeoReplicationInfo() { }
        public System.DateTimeOffset LastSyncedOn { get { throw null; } }
        public Azure.Data.Tables.Models.TableGeoReplicationStatus Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TableGeoReplicationStatus : System.IEquatable<Azure.Data.Tables.Models.TableGeoReplicationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TableGeoReplicationStatus(string value) { throw null; }
        public static Azure.Data.Tables.Models.TableGeoReplicationStatus Bootstrap { get { throw null; } }
        public static Azure.Data.Tables.Models.TableGeoReplicationStatus Live { get { throw null; } }
        public static Azure.Data.Tables.Models.TableGeoReplicationStatus Unavailable { get { throw null; } }
        public bool Equals(Azure.Data.Tables.Models.TableGeoReplicationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.Tables.Models.TableGeoReplicationStatus left, Azure.Data.Tables.Models.TableGeoReplicationStatus right) { throw null; }
        public static implicit operator Azure.Data.Tables.Models.TableGeoReplicationStatus (string value) { throw null; }
        public static bool operator !=(Azure.Data.Tables.Models.TableGeoReplicationStatus left, Azure.Data.Tables.Models.TableGeoReplicationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TableItem
    {
        internal TableItem() { }
        public string TableName { get { throw null; } }
    }
    public partial class TableMetrics
    {
        public TableMetrics(bool enabled) { }
        public bool Enabled { get { throw null; } set { } }
        public bool? IncludeApis { get { throw null; } set { } }
        public Azure.Data.Tables.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class TableServiceProperties
    {
        public TableServiceProperties() { }
        public System.Collections.Generic.IList<Azure.Data.Tables.Models.TableCorsRule> Cors { get { throw null; } }
        public Azure.Data.Tables.Models.TableMetrics HourMetrics { get { throw null; } set { } }
        public Azure.Data.Tables.Models.TableAnalyticsLoggingSettings Logging { get { throw null; } set { } }
        public Azure.Data.Tables.Models.TableMetrics MinuteMetrics { get { throw null; } set { } }
    }
    public partial class TableServiceStatistics
    {
        internal TableServiceStatistics() { }
        public Azure.Data.Tables.Models.TableGeoReplicationInfo GeoReplication { get { throw null; } }
    }
}
namespace Azure.Data.Tables.Sas
{
    public partial class TableAccountSasBuilder
    {
        public TableAccountSasBuilder(Azure.Data.Tables.Sas.TableAccountSasPermissions permissions, Azure.Data.Tables.Sas.TableAccountSasResourceTypes resourceTypes, System.DateTimeOffset expiresOn) { }
        public TableAccountSasBuilder(string rawPermissions, Azure.Data.Tables.Sas.TableAccountSasResourceTypes resourceTypes, System.DateTimeOffset expiresOn) { }
        public TableAccountSasBuilder(System.Uri uri) { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public Azure.Data.Tables.Sas.TableSasIPRange IPRange { get { throw null; } set { } }
        public string Permissions { get { throw null; } }
        public Azure.Data.Tables.Sas.TableSasProtocol Protocol { get { throw null; } set { } }
        public Azure.Data.Tables.Sas.TableAccountSasResourceTypes ResourceTypes { get { throw null; } set { } }
        public System.DateTimeOffset StartsOn { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public void SetPermissions(Azure.Data.Tables.Sas.TableAccountSasPermissions permissions) { }
        public void SetPermissions(string rawPermissions) { }
        public string Sign(Azure.Data.Tables.TableSharedKeyCredential sharedKeyCredential) { throw null; }
        public Azure.Data.Tables.Sas.TableAccountSasQueryParameters ToSasQueryParameters(Azure.Data.Tables.TableSharedKeyCredential sharedKeyCredential) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.FlagsAttribute]
    public enum TableAccountSasPermissions
    {
        All = -1,
        Read = 1,
        Write = 2,
        Delete = 4,
        List = 8,
        Add = 16,
        Update = 64,
    }
    public partial class TableAccountSasQueryParameters
    {
        internal TableAccountSasQueryParameters() { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public string Identifier { get { throw null; } }
        public Azure.Data.Tables.Sas.TableSasIPRange IPRange { get { throw null; } }
        public string Permissions { get { throw null; } }
        public Azure.Data.Tables.Sas.TableSasProtocol Protocol { get { throw null; } }
        public string Resource { get { throw null; } }
        public Azure.Data.Tables.Sas.TableAccountSasResourceTypes? ResourceTypes { get { throw null; } }
        public string Signature { get { throw null; } }
        public System.DateTimeOffset StartsOn { get { throw null; } }
        public string Version { get { throw null; } }
        public override string ToString() { throw null; }
    }
    [System.FlagsAttribute]
    public enum TableAccountSasResourceTypes
    {
        All = -1,
        Service = 1,
        Container = 2,
        Object = 4,
    }
    public partial class TableSasBuilder
    {
        public TableSasBuilder(string tableName, Azure.Data.Tables.Sas.TableSasPermissions permissions, System.DateTimeOffset expiresOn) { }
        public TableSasBuilder(string tableName, string rawPermissions, System.DateTimeOffset expiresOn) { }
        public TableSasBuilder(System.Uri uri) { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public Azure.Data.Tables.Sas.TableSasIPRange IPRange { get { throw null; } set { } }
        public string PartitionKeyEnd { get { throw null; } set { } }
        public string PartitionKeyStart { get { throw null; } set { } }
        public string Permissions { get { throw null; } }
        public Azure.Data.Tables.Sas.TableSasProtocol Protocol { get { throw null; } set { } }
        public string RowKeyEnd { get { throw null; } set { } }
        public string RowKeyStart { get { throw null; } set { } }
        public System.DateTimeOffset StartsOn { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public void SetPermissions(Azure.Data.Tables.Sas.TableSasPermissions permissions) { }
        public void SetPermissions(string rawPermissions) { }
        public string Sign(Azure.Data.Tables.TableSharedKeyCredential sharedKeyCredential) { throw null; }
        public Azure.Data.Tables.Sas.TableSasQueryParameters ToSasQueryParameters(Azure.Data.Tables.TableSharedKeyCredential sharedKeyCredential) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TableSasIPRange : System.IEquatable<Azure.Data.Tables.Sas.TableSasIPRange>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TableSasIPRange(System.Net.IPAddress start, System.Net.IPAddress end = null) { throw null; }
        public System.Net.IPAddress End { get { throw null; } }
        public System.Net.IPAddress Start { get { throw null; } }
        public bool Equals(Azure.Data.Tables.Sas.TableSasIPRange other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.Tables.Sas.TableSasIPRange left, Azure.Data.Tables.Sas.TableSasIPRange right) { throw null; }
        public static bool operator !=(Azure.Data.Tables.Sas.TableSasIPRange left, Azure.Data.Tables.Sas.TableSasIPRange right) { throw null; }
        public static Azure.Data.Tables.Sas.TableSasIPRange Parse(string s) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.FlagsAttribute]
    public enum TableSasPermissions
    {
        All = -1,
        Read = 1,
        Add = 2,
        Update = 4,
        Delete = 8,
    }
    public enum TableSasProtocol
    {
        None = 0,
        HttpsAndHttp = 1,
        Https = 2,
    }
    public sealed partial class TableSasQueryParameters : Azure.Data.Tables.Sas.TableAccountSasQueryParameters
    {
        internal TableSasQueryParameters() { }
        public static Azure.Data.Tables.Sas.TableSasQueryParameters Empty { get { throw null; } }
        public string EndPartitionKey { get { throw null; } set { } }
        public string EndRowKey { get { throw null; } set { } }
        public string StartPartitionKey { get { throw null; } set { } }
        public string StartRowKey { get { throw null; } set { } }
        public override string ToString() { throw null; }
    }
    public partial class TableUriBuilder
    {
        public TableUriBuilder(System.Uri uri) { }
        public string AccountName { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Data.Tables.Sas.TableSasQueryParameters Sas { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
        public string Tablename { get { throw null; } set { } }
        public override string ToString() { throw null; }
        public System.Uri ToUri() { throw null; }
    }
}
