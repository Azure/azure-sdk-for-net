namespace Azure.Data.Tables
{
    public partial class DynamicTableEntity : Azure.Data.Tables.TableEntity, System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public DynamicTableEntity() { }
        public DynamicTableEntity(System.Collections.Generic.IDictionary<string, object> values) { }
        public DynamicTableEntity(string partitionKey, string rowKey) { }
        public int Count { get { throw null; } }
        public override string ETag { get { throw null; } set { } }
        public bool IsReadOnly { get { throw null; } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public override string PartitionKey { get { throw null; } set { } }
        public override string RowKey { get { throw null; } set { } }
        public override System.DateTimeOffset Timestamp { get { throw null; } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(System.Collections.Generic.KeyValuePair<string, object> item) { }
        public void Add(string key, object value) { }
        public void Clear() { }
        public bool Contains(System.Collections.Generic.KeyValuePair<string, object> item) { throw null; }
        public bool ContainsKey(string key) { throw null; }
        public void CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] array, int arrayIndex) { }
        public byte[] GetBinary(string key) { throw null; }
        public bool GetBoolean(string key) { throw null; }
        public System.DateTime GetDateTime(string key) { throw null; }
        public double GetDouble(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public System.Guid GetGuid(string key) { throw null; }
        public int GetInt32(string key) { throw null; }
        public long GetInt64(string key) { throw null; }
        public string GetString(string key) { throw null; }
        public bool Remove(System.Collections.Generic.KeyValuePair<string, object> item) { throw null; }
        public bool Remove(string key) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class TableClient
    {
        protected TableClient() { }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableItem> Create(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableItem>> CreateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.Tables.DynamicTableEntity> CreateEntity(Azure.Data.Tables.DynamicTableEntity entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.ObjectModel.ReadOnlyDictionary<string, object>> CreateEntity(System.Collections.Generic.IDictionary<string, object> entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.DynamicTableEntity>> CreateEntityAsync(Azure.Data.Tables.DynamicTableEntity entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.ObjectModel.ReadOnlyDictionary<string, object>>> CreateEntityAsync(System.Collections.Generic.IDictionary<string, object> entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<T>> CreateEntityAsync<T>(T entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.TableEntity, new() { throw null; }
        public virtual Azure.Response<T> CreateEntity<T>(T entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.TableEntity, new() { throw null; }
        public static string CreateFilter<T>(System.Linq.Expressions.Expression<System.Func<T, bool>> filter) { throw null; }
        public virtual Azure.Response Delete(string partitionKey, string rowKey, string eTag = "*", System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string partitionKey, string rowKey, string eTag = "*", System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Data.Tables.Models.SignedIdentifier>> GetAccessPolicy(int? timeout = default(int?), string requestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Data.Tables.Models.SignedIdentifier>>> GetAccessPolicyAsync(int? timeout = default(int?), string requestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IDictionary<string, object>> GetEntity(string partitionKey, string rowKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IDictionary<string, object>>> GetEntityAsync(string partitionKey, string rowKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<T>> GetEntityAsync<T>(string partitionKey, string rowKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.TableEntity, new() { throw null; }
        public virtual Azure.Response<T> GetEntity<T>(string partitionKey, string rowKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.TableEntity, new() { throw null; }
        public virtual Azure.Data.Tables.Sas.TableSasBuilder GetSasBuilder(Azure.Data.Tables.Sas.TableSasPermissions permissions, System.DateTimeOffset expiresOn) { throw null; }
        public virtual Azure.Data.Tables.Sas.TableSasBuilder GetSasBuilder(string rawPermissions, System.DateTimeOffset expiresOn) { throw null; }
        public virtual Azure.Pageable<System.Collections.Generic.IDictionary<string, object>> Query(System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.IDictionary<string, object>, bool>> filter, int? maxPerPage = default(int?), string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.Collections.Generic.IDictionary<string, object>> Query(string filter = null, int? maxPerPage = default(int?), string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.Collections.Generic.IDictionary<string, object>> QueryAsync(System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.IDictionary<string, object>, bool>> filter, int? maxPerPage = default(int?), string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.Collections.Generic.IDictionary<string, object>> QueryAsync(string filter = null, int? maxPerPage = default(int?), string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<T> QueryAsync<T>(System.Linq.Expressions.Expression<System.Func<T, bool>> filter, int? maxPerPage = default(int?), string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.TableEntity, new() { throw null; }
        public virtual Azure.AsyncPageable<T> QueryAsync<T>(string filter = null, int? maxPerPage = default(int?), string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.TableEntity, new() { throw null; }
        public virtual Azure.Pageable<T> Query<T>(System.Linq.Expressions.Expression<System.Func<T, bool>> filter, int? maxPerPage = default(int?), string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.TableEntity, new() { throw null; }
        public virtual Azure.Pageable<T> Query<T>(string filter = null, int? maxPerPage = default(int?), string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.TableEntity, new() { throw null; }
        public virtual Azure.Response SetAccessPolicy(System.Collections.Generic.IEnumerable<Azure.Data.Tables.Models.SignedIdentifier> tableAcl, int? timeout = default(int?), string requestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetAccessPolicyAsync(System.Collections.Generic.IEnumerable<Azure.Data.Tables.Models.SignedIdentifier> tableAcl = null, int? timeout = default(int?), string requestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateEntity(System.Collections.Generic.IDictionary<string, object> entity, string eTag, Azure.Data.Tables.UpdateMode mode = Azure.Data.Tables.UpdateMode.Merge, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateEntityAsync(System.Collections.Generic.IDictionary<string, object> entity, string eTag, Azure.Data.Tables.UpdateMode mode = Azure.Data.Tables.UpdateMode.Merge, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpsertEntity(System.Collections.Generic.IDictionary<string, object> entity, Azure.Data.Tables.UpdateMode mode = Azure.Data.Tables.UpdateMode.Merge, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpsertEntityAsync(System.Collections.Generic.IDictionary<string, object> entity, Azure.Data.Tables.UpdateMode mode = Azure.Data.Tables.UpdateMode.Merge, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpsertEntityAsync<T>(T entity, Azure.Data.Tables.UpdateMode mode = Azure.Data.Tables.UpdateMode.Merge, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.TableEntity, new() { throw null; }
        public virtual Azure.Response UpsertEntity<T>(T entity, Azure.Data.Tables.UpdateMode mode = Azure.Data.Tables.UpdateMode.Merge, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.TableEntity, new() { throw null; }
    }
    public partial class TableClientOptions : Azure.Core.ClientOptions
    {
        public TableClientOptions(Azure.Data.Tables.TableClientOptions.ServiceVersion serviceVersion = Azure.Data.Tables.TableClientOptions.ServiceVersion.V2019_02_02) { }
        public enum ServiceVersion
        {
            V2019_02_02 = 1,
        }
    }
    public partial class TableEntity
    {
        public TableEntity() { }
        public TableEntity(string partitionKey, string rowKey) { }
        public virtual string ETag { get { throw null; } set { } }
        public virtual string PartitionKey { get { throw null; } set { } }
        public virtual string RowKey { get { throw null; } set { } }
        public virtual System.DateTimeOffset Timestamp { get { throw null; } set { } }
    }
    public partial class TableServiceClient
    {
        protected TableServiceClient() { }
        public TableServiceClient(System.Uri endpoint) { }
        public TableServiceClient(System.Uri endpoint, Azure.Data.Tables.TableClientOptions options = null) { }
        public TableServiceClient(System.Uri endpoint, Azure.Data.Tables.TableSharedKeyCredential credential) { }
        public TableServiceClient(System.Uri endpoint, Azure.Data.Tables.TableSharedKeyCredential credential, Azure.Data.Tables.TableClientOptions options = null) { }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableItem> CreateTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableItem>> CreateTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableServiceProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableServiceProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Data.Tables.Sas.TableAccountSasBuilder GetSasBuilder(Azure.Data.Tables.Sas.TableAccountSasPermissions permissions, Azure.Data.Tables.Sas.TableAccountSasResourceTypes resourceTypes, System.DateTimeOffset expiresOn) { throw null; }
        public virtual Azure.Data.Tables.Sas.TableAccountSasBuilder GetSasBuilder(string rawPermissions, Azure.Data.Tables.Sas.TableAccountSasResourceTypes resourceTypes, System.DateTimeOffset expiresOn) { throw null; }
        public virtual Azure.Data.Tables.TableClient GetTableClient(string tableName) { throw null; }
        public virtual Azure.Pageable<Azure.Data.Tables.Models.TableItem> GetTables(string select = null, string filter = null, int? maxPerPage = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.Tables.Models.TableItem> GetTablesAsync(string select = null, string filter = null, int? maxPerPage = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableServiceStats> GetTableServiceStats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableServiceStats>> GetTableServiceStatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetProperties(Azure.Data.Tables.Models.TableServiceProperties tableServiceProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetPropertiesAsync(Azure.Data.Tables.Models.TableServiceProperties tableServiceProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TableSharedKeyCredential
    {
        public TableSharedKeyCredential(string accountName, string accountKey) { }
        public string AccountName { get { throw null; } }
        public void SetAccountKey(string accountKey) { }
    }
    public enum UpdateMode
    {
        Merge = 0,
        Replace = 1,
    }
}
namespace Azure.Data.Tables.Models
{
    public partial class AccessPolicy
    {
        public AccessPolicy(System.DateTimeOffset start, System.DateTimeOffset expiry, string permission) { }
        public System.DateTimeOffset Expiry { get { throw null; } set { } }
        public string Permission { get { throw null; } set { } }
        public System.DateTimeOffset Start { get { throw null; } set { } }
    }
    public partial class CorsRule
    {
        public CorsRule(string allowedOrigins, string allowedMethods, string allowedHeaders, string exposedHeaders, int maxAgeInSeconds) { }
        public string AllowedHeaders { get { throw null; } set { } }
        public string AllowedMethods { get { throw null; } set { } }
        public string AllowedOrigins { get { throw null; } set { } }
        public string ExposedHeaders { get { throw null; } set { } }
        public int MaxAgeInSeconds { get { throw null; } set { } }
    }
    public partial class GeoReplication
    {
        internal GeoReplication() { }
        public System.DateTimeOffset LastSyncTime { get { throw null; } }
        public Azure.Data.Tables.Models.GeoReplicationStatusType Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoReplicationStatusType : System.IEquatable<Azure.Data.Tables.Models.GeoReplicationStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeoReplicationStatusType(string value) { throw null; }
        public static Azure.Data.Tables.Models.GeoReplicationStatusType Bootstrap { get { throw null; } }
        public static Azure.Data.Tables.Models.GeoReplicationStatusType Live { get { throw null; } }
        public static Azure.Data.Tables.Models.GeoReplicationStatusType Unavailable { get { throw null; } }
        public bool Equals(Azure.Data.Tables.Models.GeoReplicationStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.Tables.Models.GeoReplicationStatusType left, Azure.Data.Tables.Models.GeoReplicationStatusType right) { throw null; }
        public static implicit operator Azure.Data.Tables.Models.GeoReplicationStatusType (string value) { throw null; }
        public static bool operator !=(Azure.Data.Tables.Models.GeoReplicationStatusType left, Azure.Data.Tables.Models.GeoReplicationStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoggingSettings
    {
        public LoggingSettings(string version, bool delete, bool read, bool write, Azure.Data.Tables.Models.RetentionPolicy retentionPolicy) { }
        public bool Delete { get { throw null; } set { } }
        public bool Read { get { throw null; } set { } }
        public Azure.Data.Tables.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public bool Write { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OdataMetadataFormat : System.IEquatable<Azure.Data.Tables.Models.OdataMetadataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OdataMetadataFormat(string value) { throw null; }
        public static Azure.Data.Tables.Models.OdataMetadataFormat ApplicationJsonOdataFullmetadata { get { throw null; } }
        public static Azure.Data.Tables.Models.OdataMetadataFormat ApplicationJsonOdataMinimalmetadata { get { throw null; } }
        public static Azure.Data.Tables.Models.OdataMetadataFormat ApplicationJsonOdataNometadata { get { throw null; } }
        public bool Equals(Azure.Data.Tables.Models.OdataMetadataFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.Tables.Models.OdataMetadataFormat left, Azure.Data.Tables.Models.OdataMetadataFormat right) { throw null; }
        public static implicit operator Azure.Data.Tables.Models.OdataMetadataFormat (string value) { throw null; }
        public static bool operator !=(Azure.Data.Tables.Models.OdataMetadataFormat left, Azure.Data.Tables.Models.OdataMetadataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseFormat : System.IEquatable<Azure.Data.Tables.Models.ResponseFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseFormat(string value) { throw null; }
        public static Azure.Data.Tables.Models.ResponseFormat ReturnContent { get { throw null; } }
        public static Azure.Data.Tables.Models.ResponseFormat ReturnNoContent { get { throw null; } }
        public bool Equals(Azure.Data.Tables.Models.ResponseFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.Tables.Models.ResponseFormat left, Azure.Data.Tables.Models.ResponseFormat right) { throw null; }
        public static implicit operator Azure.Data.Tables.Models.ResponseFormat (string value) { throw null; }
        public static bool operator !=(Azure.Data.Tables.Models.ResponseFormat left, Azure.Data.Tables.Models.ResponseFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RetentionPolicy
    {
        public RetentionPolicy(bool enabled) { }
        public int? Days { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
    }
    public partial class SignedIdentifier
    {
        public SignedIdentifier(string id, Azure.Data.Tables.Models.AccessPolicy accessPolicy) { }
        public Azure.Data.Tables.Models.AccessPolicy AccessPolicy { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
    }
    public partial class TableEntityQueryResponse
    {
        internal TableEntityQueryResponse() { }
        public string OdataMetadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, object>> Value { get { throw null; } }
    }
    public partial class TableItem
    {
        internal TableItem() { }
        public string OdataEditLink { get { throw null; } }
        public string OdataId { get { throw null; } }
        public string OdataType { get { throw null; } }
        public string TableName { get { throw null; } }
    }
    public partial class TableMetrics
    {
        public TableMetrics(bool enabled) { }
        public bool Enabled { get { throw null; } set { } }
        public bool? IncludeAPIs { get { throw null; } set { } }
        public Azure.Data.Tables.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class TableProperties
    {
        public TableProperties() { }
        public string TableName { get { throw null; } set { } }
    }
    public partial class TableQueryResponse
    {
        internal TableQueryResponse() { }
        public string OdataMetadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Data.Tables.Models.TableItem> Value { get { throw null; } }
    }
    public partial class TableServiceProperties
    {
        public TableServiceProperties() { }
        public System.Collections.Generic.IList<Azure.Data.Tables.Models.CorsRule> Cors { get { throw null; } }
        public Azure.Data.Tables.Models.TableMetrics HourMetrics { get { throw null; } set { } }
        public Azure.Data.Tables.Models.LoggingSettings Logging { get { throw null; } set { } }
        public Azure.Data.Tables.Models.TableMetrics MinuteMetrics { get { throw null; } set { } }
    }
    public partial class TableServiceStats
    {
        internal TableServiceStats() { }
        public Azure.Data.Tables.Models.GeoReplication GeoReplication { get { throw null; } }
    }
}
namespace Azure.Data.Tables.Sas
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SasIPRange : System.IEquatable<Azure.Data.Tables.Sas.SasIPRange>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SasIPRange(System.Net.IPAddress start, System.Net.IPAddress end = null) { throw null; }
        public System.Net.IPAddress End { get { throw null; } }
        public System.Net.IPAddress Start { get { throw null; } }
        public bool Equals(Azure.Data.Tables.Sas.SasIPRange other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.Tables.Sas.SasIPRange left, Azure.Data.Tables.Sas.SasIPRange right) { throw null; }
        public static bool operator !=(Azure.Data.Tables.Sas.SasIPRange left, Azure.Data.Tables.Sas.SasIPRange right) { throw null; }
        public static Azure.Data.Tables.Sas.SasIPRange Parse(string s) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SasProtocol
    {
        None = 0,
        HttpsAndHttp = 1,
        Https = 2,
    }
    public partial class TableAccountSasBuilder
    {
        public TableAccountSasBuilder(Azure.Data.Tables.Sas.TableAccountSasPermissions permissions, Azure.Data.Tables.Sas.TableAccountSasResourceTypes resourceTypes, System.DateTimeOffset expiresOn) { }
        public TableAccountSasBuilder(string rawPermissions, Azure.Data.Tables.Sas.TableAccountSasResourceTypes resourceTypes, System.DateTimeOffset expiresOn) { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public Azure.Data.Tables.Sas.SasIPRange IPRange { get { throw null; } set { } }
        public string Permissions { get { throw null; } }
        public Azure.Data.Tables.Sas.SasProtocol Protocol { get { throw null; } set { } }
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
        public Azure.Data.Tables.Sas.SasIPRange IPRange { get { throw null; } }
        public string Permissions { get { throw null; } }
        public Azure.Data.Tables.Sas.SasProtocol Protocol { get { throw null; } }
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
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public Azure.Data.Tables.Sas.SasIPRange IPRange { get { throw null; } set { } }
        public string PartitionKeyEnd { get { throw null; } set { } }
        public string PartitionKeyStart { get { throw null; } set { } }
        public string Permissions { get { throw null; } }
        public Azure.Data.Tables.Sas.SasProtocol Protocol { get { throw null; } set { } }
        public string RowKeyEnd { get { throw null; } set { } }
        public string RowKeyStart { get { throw null; } set { } }
        public System.DateTimeOffset StartsOn { get { throw null; } set { } }
        public string TableName { get { throw null; } }
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
    [System.FlagsAttribute]
    public enum TableSasPermissions
    {
        All = -1,
        Read = 1,
        Add = 2,
        Update = 4,
        Delete = 8,
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
}
