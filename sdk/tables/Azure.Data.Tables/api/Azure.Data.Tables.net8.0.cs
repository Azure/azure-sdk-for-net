namespace Azure.Data.Tables
{
    public partial interface ITableEntity
    {
        Azure.ETag ETag { get; set; }
        string PartitionKey { get; set; }
        string RowKey { get; set; }
        System.DateTimeOffset? Timestamp { get; set; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TableAudience : System.IEquatable<Azure.Data.Tables.TableAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TableAudience(string value) { throw null; }
        public static Azure.Data.Tables.TableAudience AzureChina { get { throw null; } }
        public static Azure.Data.Tables.TableAudience AzureGovernment { get { throw null; } }
        public static Azure.Data.Tables.TableAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.Data.Tables.TableAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.Tables.TableAudience left, Azure.Data.Tables.TableAudience right) { throw null; }
        public static implicit operator Azure.Data.Tables.TableAudience (string value) { throw null; }
        public static bool operator !=(Azure.Data.Tables.TableAudience left, Azure.Data.Tables.TableAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TableClient
    {
        protected TableClient() { }
        public TableClient(string connectionString, string tableName) { }
        public TableClient(string connectionString, string tableName, Azure.Data.Tables.TableClientOptions options = null) { }
        public TableClient(System.Uri endpoint, Azure.AzureSasCredential credential, Azure.Data.Tables.TableClientOptions options = null) { }
        public TableClient(System.Uri endpoint, Azure.Data.Tables.TableClientOptions options = null) { }
        public TableClient(System.Uri endpoint, string tableName, Azure.Core.TokenCredential tokenCredential, Azure.Data.Tables.TableClientOptions options = null) { }
        public TableClient(System.Uri endpoint, string tableName, Azure.Data.Tables.TableSharedKeyCredential credential) { }
        public TableClient(System.Uri endpoint, string tableName, Azure.Data.Tables.TableSharedKeyCredential credential, Azure.Data.Tables.TableClientOptions options = null) { }
        public virtual string AccountName { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddEntityAsync<T>(T entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.ITableEntity { throw null; }
        public virtual Azure.Response AddEntity<T>(T entity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.ITableEntity { throw null; }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableItem> Create(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableItem>> CreateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableItem> CreateIfNotExists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableItem>> CreateIfNotExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static string CreateQueryFilter(System.FormattableString filter) { throw null; }
        public static string CreateQueryFilter<T>(System.Linq.Expressions.Expression<System.Func<T, bool>> filter) { throw null; }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteEntity(Azure.Data.Tables.ITableEntity entity, Azure.ETag ifMatch = default(Azure.ETag), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteEntity(string partitionKey, string rowKey, Azure.ETag ifMatch = default(Azure.ETag), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteEntityAsync(Azure.Data.Tables.ITableEntity entity, Azure.ETag ifMatch = default(Azure.ETag), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteEntityAsync(string partitionKey, string rowKey, Azure.ETag ifMatch = default(Azure.ETag), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Uri GenerateSasUri(Azure.Data.Tables.Sas.TableSasBuilder builder) { throw null; }
        public virtual System.Uri GenerateSasUri(Azure.Data.Tables.Sas.TableSasPermissions permissions, System.DateTimeOffset expiresOn) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Data.Tables.Models.TableSignedIdentifier>> GetAccessPolicies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Data.Tables.Models.TableSignedIdentifier>>> GetAccessPoliciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<T>> GetEntityAsync<T>(string partitionKey, string rowKey, System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<T>> GetEntityIfExistsAsync<T>(string partitionKey, string rowKey, System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity { throw null; }
        public virtual Azure.NullableResponse<T> GetEntityIfExists<T>(string partitionKey, string rowKey, System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity { throw null; }
        public virtual Azure.Response<T> GetEntity<T>(string partitionKey, string rowKey, System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity { throw null; }
        public virtual Azure.Data.Tables.Sas.TableSasBuilder GetSasBuilder(Azure.Data.Tables.Sas.TableSasPermissions permissions, System.DateTimeOffset expiresOn) { throw null; }
        public virtual Azure.Data.Tables.Sas.TableSasBuilder GetSasBuilder(string rawPermissions, System.DateTimeOffset expiresOn) { throw null; }
        public virtual Azure.AsyncPageable<T> QueryAsync<T>(System.Linq.Expressions.Expression<System.Func<T, bool>> filter, int? maxPerPage = default(int?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity { throw null; }
        public virtual Azure.AsyncPageable<T> QueryAsync<T>(string filter = null, int? maxPerPage = default(int?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity { throw null; }
        public virtual Azure.Pageable<T> Query<T>(System.Linq.Expressions.Expression<System.Func<T, bool>> filter, int? maxPerPage = default(int?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity { throw null; }
        public virtual Azure.Pageable<T> Query<T>(string filter = null, int? maxPerPage = default(int?), System.Collections.Generic.IEnumerable<string> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, Azure.Data.Tables.ITableEntity { throw null; }
        public virtual Azure.Response SetAccessPolicy(System.Collections.Generic.IEnumerable<Azure.Data.Tables.Models.TableSignedIdentifier> tableAcl, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetAccessPolicyAsync(System.Collections.Generic.IEnumerable<Azure.Data.Tables.Models.TableSignedIdentifier> tableAcl, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Response>> SubmitTransaction(System.Collections.Generic.IEnumerable<Azure.Data.Tables.TableTransactionAction> transactionActions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Response>>> SubmitTransactionAsync(System.Collections.Generic.IEnumerable<Azure.Data.Tables.TableTransactionAction> transactionActions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateEntityAsync<T>(T entity, Azure.ETag ifMatch, Azure.Data.Tables.TableUpdateMode mode = Azure.Data.Tables.TableUpdateMode.Merge, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.ITableEntity { throw null; }
        public virtual Azure.Response UpdateEntity<T>(T entity, Azure.ETag ifMatch, Azure.Data.Tables.TableUpdateMode mode = Azure.Data.Tables.TableUpdateMode.Merge, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.ITableEntity { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpsertEntityAsync<T>(T entity, Azure.Data.Tables.TableUpdateMode mode = Azure.Data.Tables.TableUpdateMode.Merge, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.ITableEntity { throw null; }
        public virtual Azure.Response UpsertEntity<T>(T entity, Azure.Data.Tables.TableUpdateMode mode = Azure.Data.Tables.TableUpdateMode.Merge, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Data.Tables.ITableEntity { throw null; }
    }
    public partial class TableClientOptions : Azure.Core.ClientOptions
    {
        public TableClientOptions(Azure.Data.Tables.TableClientOptions.ServiceVersion serviceVersion = Azure.Data.Tables.TableClientOptions.ServiceVersion.V2020_12_06) { }
        public Azure.Data.Tables.TableAudience? Audience { get { throw null; } set { } }
        public bool EnableTenantDiscovery { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2019_02_02 = 1,
            V2020_12_06 = 2,
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
        public System.BinaryData GetBinaryData(string key) { throw null; }
        public bool? GetBoolean(string key) { throw null; }
        public System.DateTime? GetDateTime(string key) { throw null; }
        public System.DateTimeOffset? GetDateTimeOffset(string key) { throw null; }
        public double? GetDouble(string key) { throw null; }
        public System.Guid? GetGuid(string key) { throw null; }
        public int? GetInt32(string key) { throw null; }
        public long? GetInt64(string key) { throw null; }
        public string GetString(string key) { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> item) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> item) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] array, int arrayIndex) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> item) { throw null; }
        System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class TableRetentionPolicy
    {
        public TableRetentionPolicy(bool enabled) { }
        public int? Days { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
    }
    public partial class TableServiceClient
    {
        protected TableServiceClient() { }
        public TableServiceClient(string connectionString) { }
        public TableServiceClient(string connectionString, Azure.Data.Tables.TableClientOptions options = null) { }
        public TableServiceClient(System.Uri endpoint, Azure.AzureSasCredential credential) { }
        public TableServiceClient(System.Uri endpoint, Azure.AzureSasCredential credential, Azure.Data.Tables.TableClientOptions options = null) { }
        public TableServiceClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Data.Tables.TableClientOptions options = null) { }
        public TableServiceClient(System.Uri endpoint, Azure.Data.Tables.TableClientOptions options = null) { }
        public TableServiceClient(System.Uri endpoint, Azure.Data.Tables.TableSharedKeyCredential credential) { }
        public TableServiceClient(System.Uri endpoint, Azure.Data.Tables.TableSharedKeyCredential credential, Azure.Data.Tables.TableClientOptions options) { }
        public virtual string AccountName { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public static string CreateQueryFilter(System.FormattableString filter) { throw null; }
        public static string CreateQueryFilter(System.Linq.Expressions.Expression<System.Func<Azure.Data.Tables.Models.TableItem, bool>> filter) { throw null; }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableItem> CreateTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableItem>> CreateTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableItem> CreateTableIfNotExists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableItem>> CreateTableIfNotExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Uri GenerateSasUri(Azure.Data.Tables.Sas.TableAccountSasBuilder builder) { throw null; }
        public virtual System.Uri GenerateSasUri(Azure.Data.Tables.Sas.TableAccountSasPermissions permissions, Azure.Data.Tables.Sas.TableAccountSasResourceTypes resourceTypes, System.DateTimeOffset expiresOn) { throw null; }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableServiceProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableServiceProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Data.Tables.Sas.TableAccountSasBuilder GetSasBuilder(Azure.Data.Tables.Sas.TableAccountSasPermissions permissions, Azure.Data.Tables.Sas.TableAccountSasResourceTypes resourceTypes, System.DateTimeOffset expiresOn) { throw null; }
        public virtual Azure.Data.Tables.Sas.TableAccountSasBuilder GetSasBuilder(string rawPermissions, Azure.Data.Tables.Sas.TableAccountSasResourceTypes resourceTypes, System.DateTimeOffset expiresOn) { throw null; }
        public virtual Azure.Response<Azure.Data.Tables.Models.TableServiceStatistics> GetStatistics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.Tables.Models.TableServiceStatistics>> GetStatisticsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Data.Tables.TableClient GetTableClient(string tableName) { throw null; }
        public virtual Azure.Pageable<Azure.Data.Tables.Models.TableItem> Query(System.FormattableString filter, int? maxPerPage = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Data.Tables.Models.TableItem> Query(System.Linq.Expressions.Expression<System.Func<Azure.Data.Tables.Models.TableItem, bool>> filter, int? maxPerPage = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Data.Tables.Models.TableItem> Query(string filter = null, int? maxPerPage = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.Tables.Models.TableItem> QueryAsync(System.FormattableString filter, int? maxPerPage = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.Tables.Models.TableItem> QueryAsync(System.Linq.Expressions.Expression<System.Func<Azure.Data.Tables.Models.TableItem, bool>> filter, int? maxPerPage = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.Tables.Models.TableItem> QueryAsync(string filter = null, int? maxPerPage = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetProperties(Azure.Data.Tables.Models.TableServiceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetPropertiesAsync(Azure.Data.Tables.Models.TableServiceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TableSharedKeyCredential
    {
        public TableSharedKeyCredential(string accountName, string accountKey) { }
        public string AccountName { get { throw null; } }
        public void SetAccountKey(string accountKey) { }
    }
    public partial class TableTransactionAction
    {
        public TableTransactionAction(Azure.Data.Tables.TableTransactionActionType actionType, Azure.Data.Tables.ITableEntity entity) { }
        public TableTransactionAction(Azure.Data.Tables.TableTransactionActionType actionType, Azure.Data.Tables.ITableEntity entity, Azure.ETag etag = default(Azure.ETag)) { }
        public Azure.Data.Tables.TableTransactionActionType ActionType { get { throw null; } }
        public Azure.Data.Tables.ITableEntity Entity { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
    }
    public enum TableTransactionActionType
    {
        Add = 0,
        UpdateMerge = 1,
        UpdateReplace = 2,
        Delete = 3,
        UpsertMerge = 4,
        UpsertReplace = 5,
    }
    public partial class TableTransactionFailedException : Azure.RequestFailedException
    {
        public TableTransactionFailedException(Azure.RequestFailedException requestFailedException) : base (default(string)) { }
        [System.ObsoleteAttribute(DiagnosticId="SYSLIB0051")]
        protected TableTransactionFailedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base (default(string)) { }
        public int? FailedTransactionActionIndex { get { throw null; } }
    }
    public enum TableUpdateMode
    {
        Merge = 0,
        Replace = 1,
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
namespace Azure.Data.Tables.Models
{
    public partial class TableAccessPolicy
    {
        public TableAccessPolicy(System.DateTimeOffset? startsOn, System.DateTimeOffset? expiresOn, string permission) { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } set { } }
        public string Permission { get { throw null; } set { } }
        public System.DateTimeOffset? StartsOn { get { throw null; } set { } }
    }
    public partial class TableAnalyticsLoggingSettings
    {
        public TableAnalyticsLoggingSettings(string version, bool delete, bool read, bool write, Azure.Data.Tables.TableRetentionPolicy retentionPolicy) { }
        public bool Delete { get { throw null; } set { } }
        public bool Read { get { throw null; } set { } }
        public Azure.Data.Tables.TableRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public bool Write { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TableErrorCode : System.IEquatable<Azure.Data.Tables.Models.TableErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TableErrorCode(string value) { throw null; }
        public static Azure.Data.Tables.Models.TableErrorCode AccountIOPSLimitExceeded { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode AtomFormatNotSupported { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode AuthorizationPermissionMismatch { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode AuthorizationResourceTypeMismatch { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode CannotCreateTableWithIOPSGreaterThanMaxAllowedPerTable { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode CommandsInBatchActOnDifferentPartitions { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode ContentLengthExceeded { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode DuplicateKeyPropertySpecified { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode DuplicatePropertiesSpecified { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode EntityAlreadyExists { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode EntityNotFound { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode EntityTooLarge { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode Forbidden { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode InvalidDuplicateRow { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode InvalidInput { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode InvalidValueType { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode JsonFormatNotSupported { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode JsonVerboseFormatNotSupported { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode KeyValueTooLarge { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode MediaTypeNotSupported { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode MethodNotAllowed { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode NotImplemented { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode OperationTimedOut { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode OperatorInvalid { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode OutOfRangeInput { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode PartitionKeyEqualityComparisonExpected { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode PartitionKeyNotSpecified { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode PartitionKeyPropertyCannotBeUpdated { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode PartitionKeySpecifiedMoreThanOnce { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode PerTableIOPSDecrementLimitReached { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode PerTableIOPSIncrementLimitReached { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode PrimaryKeyPropertyIsInvalidType { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode PropertiesNeedValue { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode PropertyNameInvalid { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode PropertyNameTooLong { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode PropertyValueTooLarge { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode ResourceNotFound { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode SettingIOPSForATableInProvisioningNotAllowed { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode TableAlreadyExists { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode TableBeingDeleted { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode TableHasNoProperties { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode TableHasNoSuchProperty { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode TableNotFound { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode TooManyProperties { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode UpdateConditionNotSatisfied { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode XMethodIncorrectCount { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode XMethodIncorrectValue { get { throw null; } }
        public static Azure.Data.Tables.Models.TableErrorCode XMethodNotUsingPost { get { throw null; } }
        public bool Equals(Azure.Data.Tables.Models.TableErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.Tables.Models.TableErrorCode left, Azure.Data.Tables.Models.TableErrorCode right) { throw null; }
        public static bool operator ==(Azure.Data.Tables.Models.TableErrorCode code, string value) { throw null; }
        public static bool operator ==(string value, Azure.Data.Tables.Models.TableErrorCode code) { throw null; }
        public static implicit operator Azure.Data.Tables.Models.TableErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.Data.Tables.Models.TableErrorCode left, Azure.Data.Tables.Models.TableErrorCode right) { throw null; }
        public static bool operator !=(Azure.Data.Tables.Models.TableErrorCode code, string value) { throw null; }
        public static bool operator !=(string value, Azure.Data.Tables.Models.TableErrorCode code) { throw null; }
        public override string ToString() { throw null; }
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
        public TableItem(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class TableMetrics
    {
        public TableMetrics(bool enabled) { }
        public bool Enabled { get { throw null; } set { } }
        public bool? IncludeApis { get { throw null; } set { } }
        public Azure.Data.Tables.TableRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public static partial class TableModelFactory
    {
        public static Azure.Data.Tables.Models.TableGeoReplicationInfo TableGeoReplicationInfo(Azure.Data.Tables.Models.TableGeoReplicationStatus status = default(Azure.Data.Tables.Models.TableGeoReplicationStatus), System.DateTimeOffset lastSyncedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Data.Tables.Models.TableItem TableItem(string name = null, string odataType = null, string odataId = null, string odataEditLink = null) { throw null; }
        public static Azure.Data.Tables.Models.TableServiceProperties TableServiceProperties(Azure.Data.Tables.Models.TableAnalyticsLoggingSettings logging = null, Azure.Data.Tables.Models.TableMetrics hourMetrics = null, Azure.Data.Tables.Models.TableMetrics minuteMetrics = null, System.Collections.Generic.IList<Azure.Data.Tables.Models.TableCorsRule> cors = null) { throw null; }
        public static Azure.Data.Tables.Models.TableServiceStatistics TableServiceStatistics(Azure.Data.Tables.Models.TableGeoReplicationInfo geoReplication = null) { throw null; }
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
    public partial class TableSignedIdentifier
    {
        public TableSignedIdentifier(string id, Azure.Data.Tables.Models.TableAccessPolicy accessPolicy) { }
        public Azure.Data.Tables.Models.TableAccessPolicy AccessPolicy { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
    }
    public partial class TableTransactionResult
    {
        internal TableTransactionResult() { }
        public int ResponseCount { get { throw null; } }
        public Azure.Response GetResponseForEntity(string rowKey) { throw null; }
    }
}
namespace Azure.Data.Tables.Sas
{
    public partial class TableAccountSasBuilder
    {
        public TableAccountSasBuilder(Azure.Data.Tables.Sas.TableAccountSasPermissions permissions, Azure.Data.Tables.Sas.TableAccountSasResourceTypes resourceTypes, System.DateTimeOffset expiresOn) { }
        public TableAccountSasBuilder(string rawPermissions, Azure.Data.Tables.Sas.TableAccountSasResourceTypes resourceTypes, System.DateTimeOffset expiresOn) { }
        public TableAccountSasBuilder(System.Uri sasUri) { }
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
        public TableSasBuilder() { }
        public TableSasBuilder(string tableName, Azure.Data.Tables.Sas.TableSasPermissions permissions, System.DateTimeOffset expiresOn) { }
        public TableSasBuilder(string tableName, string rawPermissions, System.DateTimeOffset expiresOn) { }
        public TableSasBuilder(System.Uri sasUri) { }
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
}
namespace Microsoft.Extensions.Azure
{
    public static partial class TableClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Data.Tables.TableServiceClient, Azure.Data.Tables.TableClientOptions> AddTableServiceClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Data.Tables.TableServiceClient, Azure.Data.Tables.TableClientOptions> AddTableServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Data.Tables.TableServiceClient, Azure.Data.Tables.TableClientOptions> AddTableServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri, Azure.Data.Tables.TableSharedKeyCredential sharedKeyCredential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Data.Tables.TableServiceClient, Azure.Data.Tables.TableClientOptions> AddTableServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
