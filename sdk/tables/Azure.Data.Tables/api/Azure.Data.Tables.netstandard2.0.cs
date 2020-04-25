namespace Azure.Data.Tables
{
    public partial class TableClient
    {
        protected TableClient() { }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, object>> Insert(System.Collections.Generic.IDictionary<string, object> entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, object>>> InsertAsync(System.Collections.Generic.IDictionary<string, object> entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.Collections.Generic.IDictionary<string, object>> Query(string select = null, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.Collections.Generic.IDictionary<string, object>> QueryAsync(string select = null, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(string partitionKey, string rowKey, System.Collections.Generic.IDictionary<string, object> entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string partitionKey, string rowKey, System.Collections.Generic.IDictionary<string, object> entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TableClientOptions : Azure.Core.ClientOptions
    {
        public TableClientOptions(Azure.Data.Tables.TableClientOptions.ServiceVersion serviceVersion = Azure.Data.Tables.TableClientOptions.ServiceVersion.V2019_02_02) { }
        public enum ServiceVersion
        {
            V2019_02_02 = 1,
        }
    }
    public partial class TableServiceClient
    {
        protected TableServiceClient() { }
        public TableServiceClient(System.Uri endpoint, Azure.Data.Tables.TablesSharedKeyCredential credential, Azure.Data.Tables.TableClientOptions options = null) { }
        public virtual Azure.Data.Tables.Models.TableResponse CreateTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Data.Tables.Models.TableResponse> CreateTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Data.Tables.TableClient GetTableClient(string tableName) { throw null; }
        public virtual Azure.Pageable<Azure.Data.Tables.Models.TableResponseProperties> GetTables(string select = null, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.Tables.Models.TableResponseProperties> GetTablesAsync(string select = null, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TablesSharedKeyCredential
    {
        public TablesSharedKeyCredential(string accountName, string accountKey) { }
        public string AccountName { get { throw null; } }
        protected static string ComputeSasSignature(Azure.Data.Tables.TablesSharedKeyCredential credential, string message) { throw null; }
        public void SetAccountKey(string accountKey) { }
    }
}
namespace Azure.Data.Tables.Models
{
    public partial class AccessPolicy
    {
        public AccessPolicy(System.DateTimeOffset start, System.DateTimeOffset expiry, string permission) { }
        public System.DateTimeOffset Expiry { get { throw null; } }
        public string Permission { get { throw null; } }
        public System.DateTimeOffset Start { get { throw null; } }
    }
    public partial class CorsRule
    {
        public CorsRule(string allowedOrigins, string allowedMethods, string allowedHeaders, string exposedHeaders, int maxAgeInSeconds) { }
        public string AllowedHeaders { get { throw null; } }
        public string AllowedMethods { get { throw null; } }
        public string AllowedOrigins { get { throw null; } }
        public string ExposedHeaders { get { throw null; } }
        public int MaxAgeInSeconds { get { throw null; } }
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
        public bool Delete { get { throw null; } }
        public bool Read { get { throw null; } }
        public Azure.Data.Tables.Models.RetentionPolicy RetentionPolicy { get { throw null; } }
        public string Version { get { throw null; } }
        public bool Write { get { throw null; } }
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
    public partial class QueryOptions
    {
        public QueryOptions() { }
        public string Filter { get { throw null; } set { } }
        public Azure.Data.Tables.Models.OdataMetadataFormat? Format { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class RequestMetrics
    {
        public RequestMetrics(bool enabled) { }
        public bool Enabled { get { throw null; } }
        public bool? IncludeAPIs { get { throw null; } set { } }
        public Azure.Data.Tables.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class RetentionPolicy
    {
        public RetentionPolicy(bool enabled) { }
        public int? Days { get { throw null; } set { } }
        public bool Enabled { get { throw null; } }
    }
    public partial class SignedIdentifier
    {
        public SignedIdentifier(string id, Azure.Data.Tables.Models.AccessPolicy accessPolicy) { }
        public Azure.Data.Tables.Models.AccessPolicy AccessPolicy { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class StorageError
    {
        internal StorageError() { }
        public string Message { get { throw null; } }
    }
    public partial class StorageServiceProperties
    {
        public StorageServiceProperties() { }
        public System.Collections.Generic.IList<Azure.Data.Tables.Models.CorsRule> Cors { get { throw null; } set { } }
        public Azure.Data.Tables.Models.RequestMetrics HourMetrics { get { throw null; } set { } }
        public Azure.Data.Tables.Models.LoggingSettings Logging { get { throw null; } set { } }
        public Azure.Data.Tables.Models.RequestMetrics MinuteMetrics { get { throw null; } set { } }
    }
    public partial class StorageServiceStats
    {
        internal StorageServiceStats() { }
        public Azure.Data.Tables.Models.GeoReplication GeoReplication { get { throw null; } }
    }
    public partial class TableEntityQueryResponse
    {
        internal TableEntityQueryResponse() { }
        public string OdataMetadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, object>> Value { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.Data.Tables.Models.TableResponseProperties> Value { get { throw null; } }
    }
    public partial class TableResponse : Azure.Data.Tables.Models.TableResponseProperties
    {
        internal TableResponse() { }
        public string OdataMetadata { get { throw null; } }
    }
    public partial class TableResponseProperties
    {
        internal TableResponseProperties() { }
        public string OdataEditLink { get { throw null; } }
        public string OdataId { get { throw null; } }
        public string OdataType { get { throw null; } }
        public string TableName { get { throw null; } }
    }
}
