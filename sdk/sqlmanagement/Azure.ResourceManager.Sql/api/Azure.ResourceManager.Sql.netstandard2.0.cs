namespace Azure.ResourceManager.Sql
{
    public partial class BackupLongTermRetentionPoliciesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.BackupLongTermRetentionPolicy>
    {
        protected BackupLongTermRetentionPoliciesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.BackupLongTermRetentionPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.BackupLongTermRetentionPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.BackupLongTermRetentionPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupLongTermRetentionPoliciesOperations
    {
        protected BackupLongTermRetentionPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.BackupLongTermRetentionPolicy> Get(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.BackupLongTermRetentionPolicy>> GetAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.BackupLongTermRetentionPolicy> ListByDatabase(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.BackupLongTermRetentionPolicy>> ListByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.BackupLongTermRetentionPoliciesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.BackupLongTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.BackupLongTermRetentionPoliciesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.BackupLongTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupShortTermRetentionPoliciesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy>
    {
        protected BackupShortTermRetentionPoliciesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupShortTermRetentionPoliciesOperations
    {
        protected BackupShortTermRetentionPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy> Get(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy>> GetAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy> ListByDatabase(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy> ListByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.BackupShortTermRetentionPoliciesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.BackupShortTermRetentionPoliciesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.BackupShortTermRetentionPoliciesUpdateOperation StartUpdate(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.BackupShortTermRetentionPoliciesUpdateOperation> StartUpdateAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupShortTermRetentionPoliciesUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy>
    {
        protected BackupShortTermRetentionPoliciesUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.BackupShortTermRetentionPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapabilitiesOperations
    {
        protected CapabilitiesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.LocationCapabilities> ListByLocation(string locationName, Azure.ResourceManager.Sql.Models.CapabilityGroup? include = default(Azure.ResourceManager.Sql.Models.CapabilityGroup?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.LocationCapabilities>> ListByLocationAsync(string locationName, Azure.ResourceManager.Sql.Models.CapabilityGroup? include = default(Azure.ResourceManager.Sql.Models.CapabilityGroup?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAutomaticTuningOperations
    {
        protected DatabaseAutomaticTuningOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseAutomaticTuning> Get(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseAutomaticTuning>> GetAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseAutomaticTuning> Update(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.DatabaseAutomaticTuning parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseAutomaticTuning>> UpdateAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.DatabaseAutomaticTuning parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseBlobAuditingPoliciesOperations
    {
        protected DatabaseBlobAuditingPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseBlobAuditingPolicy> CreateOrUpdate(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.DatabaseBlobAuditingPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseBlobAuditingPolicy>> CreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.DatabaseBlobAuditingPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseBlobAuditingPolicy> Get(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseBlobAuditingPolicy>> GetAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.DatabaseBlobAuditingPolicy> ListByDatabase(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.DatabaseBlobAuditingPolicy> ListByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseOperations
    {
        protected DatabaseOperations() { }
        public virtual Azure.Response Cancel(string resourceGroupName, string serverName, string databaseName, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(string resourceGroupName, string serverName, string databaseName, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.DatabaseOperation> ListByDatabase(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.DatabaseOperation> ListByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabasesCreateImportOperationOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ImportExportResponse>
    {
        protected DatabasesCreateImportOperationOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ImportExportResponse Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ImportExportResponse>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ImportExportResponse>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabasesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.Database>
    {
        protected DatabasesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.Database Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.Database>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.Database>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabasesDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected DatabasesDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabasesExportOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ImportExportResponse>
    {
        protected DatabasesExportOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ImportExportResponse Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ImportExportResponse>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ImportExportResponse>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabasesFailoverOperation : Azure.Operation<Azure.Response>
    {
        protected DatabasesFailoverOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabasesImportOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ImportExportResponse>
    {
        protected DatabasesImportOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ImportExportResponse Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ImportExportResponse>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ImportExportResponse>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabasesOperations
    {
        protected DatabasesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.Database> Get(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.Database>> GetAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.Database> ListByElasticPool(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.Database> ListByElasticPoolAsync(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.Database> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.Database> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.MetricDefinition> ListMetricDefinitions(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.MetricDefinition> ListMetricDefinitionsAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.Metric> ListMetrics(string resourceGroupName, string serverName, string databaseName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.Metric> ListMetricsAsync(string resourceGroupName, string serverName, string databaseName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Rename(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ResourceMoveDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenameAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ResourceMoveDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabasesCreateImportOperationOperation StartCreateImportOperation(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ExtensionName extensionName, Azure.ResourceManager.Sql.Models.ImportExtensionRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.DatabasesCreateImportOperationOperation> StartCreateImportOperationAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ExtensionName extensionName, Azure.ResourceManager.Sql.Models.ImportExtensionRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabasesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.Database parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.DatabasesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.Database parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabasesDeleteOperation StartDelete(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.DatabasesDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabasesExportOperation StartExport(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ExportRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.DatabasesExportOperation> StartExportAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ExportRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabasesFailoverOperation StartFailover(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ReplicaType? replicaType = default(Azure.ResourceManager.Sql.Models.ReplicaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.DatabasesFailoverOperation> StartFailoverAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ReplicaType? replicaType = default(Azure.ResourceManager.Sql.Models.ReplicaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabasesImportOperation StartImport(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.ImportRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.DatabasesImportOperation> StartImportAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.ImportRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabasesPauseOperation StartPause(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.DatabasesPauseOperation> StartPauseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabasesResumeOperation StartResume(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.DatabasesResumeOperation> StartResumeAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabasesUpdateOperation StartUpdate(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.DatabaseUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.DatabasesUpdateOperation> StartUpdateAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.DatabaseUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabasesUpgradeDataWarehouseOperation StartUpgradeDataWarehouse(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.DatabasesUpgradeDataWarehouseOperation> StartUpgradeDataWarehouseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabasesPauseOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.Database>
    {
        protected DatabasesPauseOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.Database Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.Database>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.Database>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabasesResumeOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.Database>
    {
        protected DatabasesResumeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.Database Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.Database>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.Database>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabasesUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.Database>
    {
        protected DatabasesUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.Database Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.Database>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.Database>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabasesUpgradeDataWarehouseOperation : Azure.Operation<Azure.Response>
    {
        protected DatabasesUpgradeDataWarehouseOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseThreatDetectionPoliciesOperations
    {
        protected DatabaseThreatDetectionPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseSecurityAlertPolicy> CreateOrUpdate(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.Models.DatabaseSecurityAlertPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseSecurityAlertPolicy>> CreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.Models.DatabaseSecurityAlertPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseSecurityAlertPolicy> Get(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseSecurityAlertPolicy>> GetAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseUsagesOperations
    {
        protected DatabaseUsagesOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.DatabaseUsage> ListByDatabase(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.DatabaseUsage> ListByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseVulnerabilityAssessmentRuleBaselinesOperations
    {
        protected DatabaseVulnerabilityAssessmentRuleBaselinesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentRuleBaseline> CreateOrUpdate(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentRuleBaseline parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentRuleBaseline>> CreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentRuleBaseline parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentRuleBaseline> Get(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentRuleBaseline>> GetAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseVulnerabilityAssessmentScansInitiateScanOperation : Azure.Operation<Azure.Response>
    {
        protected DatabaseVulnerabilityAssessmentScansInitiateScanOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseVulnerabilityAssessmentScansOperations
    {
        protected DatabaseVulnerabilityAssessmentScansOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentScansExport> Export(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentScansExport>> ExportAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanRecord> Get(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanRecord>> GetAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanRecord> ListByDatabase(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanRecord> ListByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentScansInitiateScanOperation StartInitiateScan(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentScansInitiateScanOperation> StartInitiateScanAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseVulnerabilityAssessmentsOperations
    {
        protected DatabaseVulnerabilityAssessmentsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment> CreateOrUpdate(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment>> CreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment> Get(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment>> GetAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment> ListByDatabase(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment> ListByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataMaskingPoliciesOperations
    {
        protected DataMaskingPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DataMaskingPolicy> CreateOrUpdate(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.DataMaskingPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DataMaskingPolicy>> CreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.DataMaskingPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DataMaskingPolicy> Get(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DataMaskingPolicy>> GetAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataMaskingRulesOperations
    {
        protected DataMaskingRulesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DataMaskingRule> CreateOrUpdate(string resourceGroupName, string serverName, string databaseName, string dataMaskingRuleName, Azure.ResourceManager.Sql.Models.DataMaskingRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DataMaskingRule>> CreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, string dataMaskingRuleName, Azure.ResourceManager.Sql.Models.DataMaskingRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.DataMaskingRule> ListByDatabase(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.DataMaskingRule> ListByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticPoolActivitiesOperations
    {
        protected ElasticPoolActivitiesOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ElasticPoolActivity> ListByElasticPool(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ElasticPoolActivity> ListByElasticPoolAsync(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticPoolDatabaseActivitiesOperations
    {
        protected ElasticPoolDatabaseActivitiesOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ElasticPoolDatabaseActivity> ListByElasticPool(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ElasticPoolDatabaseActivity> ListByElasticPoolAsync(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticPoolOperations
    {
        protected ElasticPoolOperations() { }
        public virtual Azure.Response Cancel(string resourceGroupName, string serverName, string elasticPoolName, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(string resourceGroupName, string serverName, string elasticPoolName, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ElasticPoolOperation> ListByElasticPool(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ElasticPoolOperation> ListByElasticPoolAsync(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticPoolsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ElasticPool>
    {
        protected ElasticPoolsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ElasticPool Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ElasticPool>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ElasticPool>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticPoolsDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected ElasticPoolsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticPoolsFailoverOperation : Azure.Operation<Azure.Response>
    {
        protected ElasticPoolsFailoverOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticPoolsOperations
    {
        protected ElasticPoolsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ElasticPool> Get(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ElasticPool>> GetAsync(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ElasticPool> ListByServer(string resourceGroupName, string serverName, int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ElasticPool> ListByServerAsync(string resourceGroupName, string serverName, int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.MetricDefinition> ListMetricDefinitions(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.MetricDefinition> ListMetricDefinitionsAsync(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.Metric> ListMetrics(string resourceGroupName, string serverName, string elasticPoolName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.Metric> ListMetricsAsync(string resourceGroupName, string serverName, string elasticPoolName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ElasticPoolsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string elasticPoolName, Azure.ResourceManager.Sql.Models.ElasticPool parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ElasticPoolsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string elasticPoolName, Azure.ResourceManager.Sql.Models.ElasticPool parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ElasticPoolsDeleteOperation StartDelete(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ElasticPoolsDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ElasticPoolsFailoverOperation StartFailover(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ElasticPoolsFailoverOperation> StartFailoverAsync(string resourceGroupName, string serverName, string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ElasticPoolsUpdateOperation StartUpdate(string resourceGroupName, string serverName, string elasticPoolName, Azure.ResourceManager.Sql.Models.ElasticPoolUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ElasticPoolsUpdateOperation> StartUpdateAsync(string resourceGroupName, string serverName, string elasticPoolName, Azure.ResourceManager.Sql.Models.ElasticPoolUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticPoolsUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ElasticPool>
    {
        protected ElasticPoolsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ElasticPool Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ElasticPool>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ElasticPool>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EncryptionProtectorsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.EncryptionProtector>
    {
        protected EncryptionProtectorsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.EncryptionProtector Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.EncryptionProtector>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.EncryptionProtector>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EncryptionProtectorsOperations
    {
        protected EncryptionProtectorsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.EncryptionProtector> Get(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.EncryptionProtector>> GetAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.EncryptionProtector> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.EncryptionProtector> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.EncryptionProtectorsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Sql.Models.EncryptionProtector parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.EncryptionProtectorsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Sql.Models.EncryptionProtector parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.EncryptionProtectorsRevalidateOperation StartRevalidate(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.EncryptionProtectorsRevalidateOperation> StartRevalidateAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EncryptionProtectorsRevalidateOperation : Azure.Operation<Azure.Response>
    {
        protected EncryptionProtectorsRevalidateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExtendedDatabaseBlobAuditingPoliciesOperations
    {
        protected ExtendedDatabaseBlobAuditingPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ExtendedDatabaseBlobAuditingPolicy> CreateOrUpdate(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ExtendedDatabaseBlobAuditingPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ExtendedDatabaseBlobAuditingPolicy>> CreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.ExtendedDatabaseBlobAuditingPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ExtendedDatabaseBlobAuditingPolicy> Get(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ExtendedDatabaseBlobAuditingPolicy>> GetAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ExtendedDatabaseBlobAuditingPolicy> ListByDatabase(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ExtendedDatabaseBlobAuditingPolicy> ListByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExtendedServerBlobAuditingPoliciesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ExtendedServerBlobAuditingPolicy>
    {
        protected ExtendedServerBlobAuditingPoliciesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ExtendedServerBlobAuditingPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ExtendedServerBlobAuditingPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ExtendedServerBlobAuditingPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExtendedServerBlobAuditingPoliciesOperations
    {
        protected ExtendedServerBlobAuditingPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ExtendedServerBlobAuditingPolicy> Get(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ExtendedServerBlobAuditingPolicy>> GetAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ExtendedServerBlobAuditingPolicy> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ExtendedServerBlobAuditingPolicy> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPoliciesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.ExtendedServerBlobAuditingPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPoliciesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.ExtendedServerBlobAuditingPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FailoverGroupsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.FailoverGroup>
    {
        protected FailoverGroupsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.FailoverGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.FailoverGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.FailoverGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FailoverGroupsDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected FailoverGroupsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FailoverGroupsFailoverOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.FailoverGroup>
    {
        protected FailoverGroupsFailoverOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.FailoverGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.FailoverGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.FailoverGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FailoverGroupsForceFailoverAllowDataLossOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.FailoverGroup>
    {
        protected FailoverGroupsForceFailoverAllowDataLossOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.FailoverGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.FailoverGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.FailoverGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FailoverGroupsOperations
    {
        protected FailoverGroupsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.FailoverGroup> Get(string resourceGroupName, string serverName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.FailoverGroup>> GetAsync(string resourceGroupName, string serverName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.FailoverGroup> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.FailoverGroup> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.FailoverGroupsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string failoverGroupName, Azure.ResourceManager.Sql.Models.FailoverGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.FailoverGroupsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string failoverGroupName, Azure.ResourceManager.Sql.Models.FailoverGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.FailoverGroupsDeleteOperation StartDelete(string resourceGroupName, string serverName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.FailoverGroupsDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.FailoverGroupsFailoverOperation StartFailover(string resourceGroupName, string serverName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.FailoverGroupsFailoverOperation> StartFailoverAsync(string resourceGroupName, string serverName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.FailoverGroupsForceFailoverAllowDataLossOperation StartForceFailoverAllowDataLoss(string resourceGroupName, string serverName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.FailoverGroupsForceFailoverAllowDataLossOperation> StartForceFailoverAllowDataLossAsync(string resourceGroupName, string serverName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.FailoverGroupsUpdateOperation StartUpdate(string resourceGroupName, string serverName, string failoverGroupName, Azure.ResourceManager.Sql.Models.FailoverGroupUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.FailoverGroupsUpdateOperation> StartUpdateAsync(string resourceGroupName, string serverName, string failoverGroupName, Azure.ResourceManager.Sql.Models.FailoverGroupUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FailoverGroupsUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.FailoverGroup>
    {
        protected FailoverGroupsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.FailoverGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.FailoverGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.FailoverGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FirewallRulesOperations
    {
        protected FirewallRulesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.FirewallRule> CreateOrUpdate(string resourceGroupName, string serverName, string firewallRuleName, Azure.ResourceManager.Sql.Models.FirewallRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.FirewallRule>> CreateOrUpdateAsync(string resourceGroupName, string serverName, string firewallRuleName, Azure.ResourceManager.Sql.Models.FirewallRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string serverName, string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string serverName, string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.FirewallRule> Get(string resourceGroupName, string serverName, string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.FirewallRule>> GetAsync(string resourceGroupName, string serverName, string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.FirewallRule> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.FirewallRule> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GeoBackupPoliciesOperations
    {
        protected GeoBackupPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.GeoBackupPolicy> CreateOrUpdate(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, Azure.ResourceManager.Sql.Models.GeoBackupPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.GeoBackupPolicy>> CreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, Azure.ResourceManager.Sql.Models.GeoBackupPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.GeoBackupPolicy> Get(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.GeoBackupPolicy>> GetAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.GeoBackupPolicy> ListByDatabase(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.GeoBackupPolicy> ListByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstanceFailoverGroupsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.InstanceFailoverGroup>
    {
        protected InstanceFailoverGroupsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.InstanceFailoverGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.InstanceFailoverGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.InstanceFailoverGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstanceFailoverGroupsDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected InstanceFailoverGroupsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstanceFailoverGroupsFailoverOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.InstanceFailoverGroup>
    {
        protected InstanceFailoverGroupsFailoverOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.InstanceFailoverGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.InstanceFailoverGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.InstanceFailoverGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstanceFailoverGroupsForceFailoverAllowDataLossOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.InstanceFailoverGroup>
    {
        protected InstanceFailoverGroupsForceFailoverAllowDataLossOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.InstanceFailoverGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.InstanceFailoverGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.InstanceFailoverGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstanceFailoverGroupsOperations
    {
        protected InstanceFailoverGroupsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.InstanceFailoverGroup> Get(string resourceGroupName, string locationName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.InstanceFailoverGroup>> GetAsync(string resourceGroupName, string locationName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.InstanceFailoverGroup> ListByLocation(string resourceGroupName, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.InstanceFailoverGroup> ListByLocationAsync(string resourceGroupName, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.InstanceFailoverGroupsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string locationName, string failoverGroupName, Azure.ResourceManager.Sql.Models.InstanceFailoverGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.InstanceFailoverGroupsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string locationName, string failoverGroupName, Azure.ResourceManager.Sql.Models.InstanceFailoverGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.InstanceFailoverGroupsDeleteOperation StartDelete(string resourceGroupName, string locationName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.InstanceFailoverGroupsDeleteOperation> StartDeleteAsync(string resourceGroupName, string locationName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.InstanceFailoverGroupsFailoverOperation StartFailover(string resourceGroupName, string locationName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.InstanceFailoverGroupsFailoverOperation> StartFailoverAsync(string resourceGroupName, string locationName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.InstanceFailoverGroupsForceFailoverAllowDataLossOperation StartForceFailoverAllowDataLoss(string resourceGroupName, string locationName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.InstanceFailoverGroupsForceFailoverAllowDataLossOperation> StartForceFailoverAllowDataLossAsync(string resourceGroupName, string locationName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstancePoolsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.InstancePool>
    {
        protected InstancePoolsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.InstancePool Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.InstancePool>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.InstancePool>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstancePoolsDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected InstancePoolsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstancePoolsOperations
    {
        protected InstancePoolsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.InstancePool> Get(string resourceGroupName, string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.InstancePool>> GetAsync(string resourceGroupName, string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.InstancePool> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.InstancePool> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.InstancePool> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.InstancePool> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.InstancePoolsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string instancePoolName, Azure.ResourceManager.Sql.Models.InstancePool parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.InstancePoolsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string instancePoolName, Azure.ResourceManager.Sql.Models.InstancePool parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.InstancePoolsDeleteOperation StartDelete(string resourceGroupName, string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.InstancePoolsDeleteOperation> StartDeleteAsync(string resourceGroupName, string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.InstancePoolsUpdateOperation StartUpdate(string resourceGroupName, string instancePoolName, Azure.ResourceManager.Sql.Models.InstancePoolUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.InstancePoolsUpdateOperation> StartUpdateAsync(string resourceGroupName, string instancePoolName, Azure.ResourceManager.Sql.Models.InstancePoolUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstancePoolsUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.InstancePool>
    {
        protected InstancePoolsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.InstancePool Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.InstancePool>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.InstancePool>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobAgentsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.JobAgent>
    {
        protected JobAgentsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.JobAgent Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.JobAgent>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.JobAgent>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobAgentsDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected JobAgentsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobAgentsOperations
    {
        protected JobAgentsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.JobAgent> Get(string resourceGroupName, string serverName, string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.JobAgent>> GetAsync(string resourceGroupName, string serverName, string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.JobAgent> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.JobAgent> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.JobAgentsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string jobAgentName, Azure.ResourceManager.Sql.Models.JobAgent parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.JobAgentsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string jobAgentName, Azure.ResourceManager.Sql.Models.JobAgent parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.JobAgentsDeleteOperation StartDelete(string resourceGroupName, string serverName, string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.JobAgentsDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.JobAgentsUpdateOperation StartUpdate(string resourceGroupName, string serverName, string jobAgentName, Azure.ResourceManager.Sql.Models.JobAgentUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.JobAgentsUpdateOperation> StartUpdateAsync(string resourceGroupName, string serverName, string jobAgentName, Azure.ResourceManager.Sql.Models.JobAgentUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobAgentsUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.JobAgent>
    {
        protected JobAgentsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.JobAgent Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.JobAgent>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.JobAgent>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobCredentialsOperations
    {
        protected JobCredentialsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.JobCredential> CreateOrUpdate(string resourceGroupName, string serverName, string jobAgentName, string credentialName, Azure.ResourceManager.Sql.Models.JobCredential parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.JobCredential>> CreateOrUpdateAsync(string resourceGroupName, string serverName, string jobAgentName, string credentialName, Azure.ResourceManager.Sql.Models.JobCredential parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string serverName, string jobAgentName, string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string serverName, string jobAgentName, string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.JobCredential> Get(string resourceGroupName, string serverName, string jobAgentName, string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.JobCredential>> GetAsync(string resourceGroupName, string serverName, string jobAgentName, string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.JobCredential> ListByAgent(string resourceGroupName, string serverName, string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.JobCredential> ListByAgentAsync(string resourceGroupName, string serverName, string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobExecutionsCreateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.JobExecution>
    {
        protected JobExecutionsCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.JobExecution Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.JobExecution>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.JobExecution>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobExecutionsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.JobExecution>
    {
        protected JobExecutionsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.JobExecution Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.JobExecution>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.JobExecution>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobExecutionsOperations
    {
        protected JobExecutionsOperations() { }
        public virtual Azure.Response Cancel(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.JobExecution> Get(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.JobExecution>> GetAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.JobExecution> ListByAgent(string resourceGroupName, string serverName, string jobAgentName, System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.JobExecution> ListByAgentAsync(string resourceGroupName, string serverName, string jobAgentName, System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.JobExecution> ListByJob(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.JobExecution> ListByJobAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.JobExecutionsCreateOperation StartCreate(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.JobExecutionsCreateOperation> StartCreateAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.JobExecutionsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.JobExecutionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobsOperations
    {
        protected JobsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.Job> CreateOrUpdate(string resourceGroupName, string serverName, string jobAgentName, string jobName, Azure.ResourceManager.Sql.Models.Job parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.Job>> CreateOrUpdateAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, Azure.ResourceManager.Sql.Models.Job parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.Job> Get(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.Job>> GetAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.Job> ListByAgent(string resourceGroupName, string serverName, string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.Job> ListByAgentAsync(string resourceGroupName, string serverName, string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobStepExecutionsOperations
    {
        protected JobStepExecutionsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.JobExecution> Get(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.JobExecution>> GetAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.JobExecution> ListByJobExecution(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.JobExecution> ListByJobExecutionAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobStepsOperations
    {
        protected JobStepsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.JobStep> CreateOrUpdate(string resourceGroupName, string serverName, string jobAgentName, string jobName, string stepName, Azure.ResourceManager.Sql.Models.JobStep parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.JobStep>> CreateOrUpdateAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, string stepName, Azure.ResourceManager.Sql.Models.JobStep parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string serverName, string jobAgentName, string jobName, string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.JobStep> Get(string resourceGroupName, string serverName, string jobAgentName, string jobName, string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.JobStep>> GetAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.JobStep> GetByVersion(string resourceGroupName, string serverName, string jobAgentName, string jobName, int jobVersion, string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.JobStep>> GetByVersionAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, int jobVersion, string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.JobStep> ListByJob(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.JobStep> ListByJobAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.JobStep> ListByVersion(string resourceGroupName, string serverName, string jobAgentName, string jobName, int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.JobStep> ListByVersionAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobTargetExecutionsOperations
    {
        protected JobTargetExecutionsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.JobExecution> Get(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, string stepName, System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.JobExecution>> GetAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, string stepName, System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.JobExecution> ListByJobExecution(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.JobExecution> ListByJobExecutionAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.JobExecution> ListByStep(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, string stepName, System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.JobExecution> ListByStepAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Guid jobExecutionId, string stepName, System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobTargetGroupsOperations
    {
        protected JobTargetGroupsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.JobTargetGroup> CreateOrUpdate(string resourceGroupName, string serverName, string jobAgentName, string targetGroupName, Azure.ResourceManager.Sql.Models.JobTargetGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.JobTargetGroup>> CreateOrUpdateAsync(string resourceGroupName, string serverName, string jobAgentName, string targetGroupName, Azure.ResourceManager.Sql.Models.JobTargetGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string serverName, string jobAgentName, string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string serverName, string jobAgentName, string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.JobTargetGroup> Get(string resourceGroupName, string serverName, string jobAgentName, string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.JobTargetGroup>> GetAsync(string resourceGroupName, string serverName, string jobAgentName, string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.JobTargetGroup> ListByAgent(string resourceGroupName, string serverName, string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.JobTargetGroup> ListByAgentAsync(string resourceGroupName, string serverName, string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobVersionsOperations
    {
        protected JobVersionsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.JobVersion> Get(string resourceGroupName, string serverName, string jobAgentName, string jobName, int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.JobVersion>> GetAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.JobVersion> ListByJob(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.JobVersion> ListByJobAsync(string resourceGroupName, string serverName, string jobAgentName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LongTermRetentionBackupsDeleteByResourceGroupOperation : Azure.Operation<Azure.Response>
    {
        protected LongTermRetentionBackupsDeleteByResourceGroupOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LongTermRetentionBackupsDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected LongTermRetentionBackupsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LongTermRetentionBackupsOperations
    {
        protected LongTermRetentionBackupsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup> Get(string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup>> GetAsync(string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup> GetByResourceGroup(string resourceGroupName, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup>> GetByResourceGroupAsync(string resourceGroupName, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup> ListByDatabase(string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup> ListByDatabaseAsync(string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup> ListByLocation(string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup> ListByLocationAsync(string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup> ListByResourceGroupDatabase(string resourceGroupName, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup> ListByResourceGroupDatabaseAsync(string resourceGroupName, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup> ListByResourceGroupLocation(string resourceGroupName, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup> ListByResourceGroupLocationAsync(string resourceGroupName, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup> ListByResourceGroupServer(string resourceGroupName, string locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup> ListByResourceGroupServerAsync(string resourceGroupName, string locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup> ListByServer(string locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.LongTermRetentionBackup> ListByServerAsync(string locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.LongTermRetentionBackupsDeleteOperation StartDelete(string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.LongTermRetentionBackupsDeleteOperation> StartDeleteAsync(string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.LongTermRetentionBackupsDeleteByResourceGroupOperation StartDeleteByResourceGroup(string resourceGroupName, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.LongTermRetentionBackupsDeleteByResourceGroupOperation> StartDeleteByResourceGroupAsync(string resourceGroupName, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LongTermRetentionManagedInstanceBackupsDeleteByResourceGroupOperation : Azure.Operation<Azure.Response>
    {
        protected LongTermRetentionManagedInstanceBackupsDeleteByResourceGroupOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LongTermRetentionManagedInstanceBackupsDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected LongTermRetentionManagedInstanceBackupsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LongTermRetentionManagedInstanceBackupsOperations
    {
        protected LongTermRetentionManagedInstanceBackupsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup> Get(string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup>> GetAsync(string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup> GetByResourceGroup(string resourceGroupName, string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup>> GetByResourceGroupAsync(string resourceGroupName, string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup> ListByDatabase(string locationName, string managedInstanceName, string databaseName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup> ListByDatabaseAsync(string locationName, string managedInstanceName, string databaseName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup> ListByInstance(string locationName, string managedInstanceName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup> ListByInstanceAsync(string locationName, string managedInstanceName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup> ListByLocation(string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup> ListByLocationAsync(string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup> ListByResourceGroupDatabase(string resourceGroupName, string locationName, string managedInstanceName, string databaseName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup> ListByResourceGroupDatabaseAsync(string resourceGroupName, string locationName, string managedInstanceName, string databaseName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup> ListByResourceGroupInstance(string resourceGroupName, string locationName, string managedInstanceName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup> ListByResourceGroupInstanceAsync(string resourceGroupName, string locationName, string managedInstanceName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup> ListByResourceGroupLocation(string resourceGroupName, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionBackup> ListByResourceGroupLocationAsync(string resourceGroupName, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.LongTermRetentionManagedInstanceBackupsDeleteOperation StartDelete(string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.LongTermRetentionManagedInstanceBackupsDeleteOperation> StartDeleteAsync(string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.LongTermRetentionManagedInstanceBackupsDeleteByResourceGroupOperation StartDeleteByResourceGroup(string resourceGroupName, string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.LongTermRetentionManagedInstanceBackupsDeleteByResourceGroupOperation> StartDeleteByResourceGroupAsync(string resourceGroupName, string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedBackupShortTermRetentionPoliciesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy>
    {
        protected ManagedBackupShortTermRetentionPoliciesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedBackupShortTermRetentionPoliciesOperations
    {
        protected ManagedBackupShortTermRetentionPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy> Get(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy>> GetAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy> ListByDatabase(string resourceGroupName, string managedInstanceName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy> ListByDatabaseAsync(string resourceGroupName, string managedInstanceName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPoliciesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPoliciesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPoliciesUpdateOperation StartUpdate(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPoliciesUpdateOperation> StartUpdateAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedBackupShortTermRetentionPoliciesUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy>
    {
        protected ManagedBackupShortTermRetentionPoliciesUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabaseRestoreDetailsOperations
    {
        protected ManagedDatabaseRestoreDetailsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedDatabaseRestoreDetailsResult> Get(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedDatabaseRestoreDetailsResult>> GetAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabasesCompleteRestoreOperation : Azure.Operation<Azure.Response>
    {
        protected ManagedDatabasesCompleteRestoreOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabasesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ManagedDatabase>
    {
        protected ManagedDatabasesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ManagedDatabase Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedDatabase>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedDatabase>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabasesDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected ManagedDatabasesDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabaseSecurityAlertPoliciesOperations
    {
        protected ManagedDatabaseSecurityAlertPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedDatabaseSecurityAlertPolicy> CreateOrUpdate(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.Models.ManagedDatabaseSecurityAlertPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedDatabaseSecurityAlertPolicy>> CreateOrUpdateAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.Models.ManagedDatabaseSecurityAlertPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedDatabaseSecurityAlertPolicy> Get(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedDatabaseSecurityAlertPolicy>> GetAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedDatabaseSecurityAlertPolicy> ListByDatabase(string resourceGroupName, string managedInstanceName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedDatabaseSecurityAlertPolicy> ListByDatabaseAsync(string resourceGroupName, string managedInstanceName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabaseSensitivityLabelsOperations
    {
        protected ManagedDatabaseSensitivityLabelsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.SensitivityLabel> CreateOrUpdate(string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName, string columnName, Azure.ResourceManager.Sql.Models.SensitivityLabel parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.SensitivityLabel>> CreateOrUpdateAsync(string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName, string columnName, Azure.ResourceManager.Sql.Models.SensitivityLabel parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName, string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName, string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DisableRecommendation(string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName, string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableRecommendationAsync(string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName, string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableRecommendation(string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName, string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableRecommendationAsync(string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName, string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.SensitivityLabel> Get(string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName, string columnName, Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.SensitivityLabel>> GetAsync(string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName, string columnName, Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SensitivityLabel> ListCurrentByDatabase(string resourceGroupName, string managedInstanceName, string databaseName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SensitivityLabel> ListCurrentByDatabaseAsync(string resourceGroupName, string managedInstanceName, string databaseName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SensitivityLabel> ListRecommendedByDatabase(string resourceGroupName, string managedInstanceName, string databaseName, bool? includeDisabledRecommendations = default(bool?), string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SensitivityLabel> ListRecommendedByDatabaseAsync(string resourceGroupName, string managedInstanceName, string databaseName, bool? includeDisabledRecommendations = default(bool?), string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabasesOperations
    {
        protected ManagedDatabasesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedDatabase> Get(string resourceGroupName, string managedInstanceName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedDatabase>> GetAsync(string resourceGroupName, string managedInstanceName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedDatabase> ListByInstance(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedDatabase> ListByInstanceAsync(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedDatabase> ListInaccessibleByInstance(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedDatabase> ListInaccessibleByInstanceAsync(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedDatabasesCompleteRestoreOperation StartCompleteRestore(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.CompleteDatabaseRestoreDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedDatabasesCompleteRestoreOperation> StartCompleteRestoreAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.CompleteDatabaseRestoreDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedDatabasesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.ManagedDatabase parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedDatabasesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.ManagedDatabase parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedDatabasesDeleteOperation StartDelete(string resourceGroupName, string managedInstanceName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedDatabasesDeleteOperation> StartDeleteAsync(string resourceGroupName, string managedInstanceName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedDatabasesUpdateOperation StartUpdate(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.ManagedDatabaseUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedDatabasesUpdateOperation> StartUpdateAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.ManagedDatabaseUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabasesUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ManagedDatabase>
    {
        protected ManagedDatabasesUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ManagedDatabase Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedDatabase>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedDatabase>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabaseVulnerabilityAssessmentRuleBaselinesOperations
    {
        protected ManagedDatabaseVulnerabilityAssessmentRuleBaselinesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentRuleBaseline> CreateOrUpdate(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentRuleBaseline parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentRuleBaseline>> CreateOrUpdateAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentRuleBaseline parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentRuleBaseline> Get(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentRuleBaseline>> GetAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabaseVulnerabilityAssessmentScansInitiateScanOperation : Azure.Operation<Azure.Response>
    {
        protected ManagedDatabaseVulnerabilityAssessmentScansInitiateScanOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabaseVulnerabilityAssessmentScansOperations
    {
        protected ManagedDatabaseVulnerabilityAssessmentScansOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentScansExport> Export(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentScansExport>> ExportAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanRecord> Get(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanRecord>> GetAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanRecord> ListByDatabase(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanRecord> ListByDatabaseAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseVulnerabilityAssessmentScansInitiateScanOperation StartInitiateScan(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedDatabaseVulnerabilityAssessmentScansInitiateScanOperation> StartInitiateScanAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabaseVulnerabilityAssessmentsOperations
    {
        protected ManagedDatabaseVulnerabilityAssessmentsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment> CreateOrUpdate(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment>> CreateOrUpdateAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment> Get(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment>> GetAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment> ListByDatabase(string resourceGroupName, string managedInstanceName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessment> ListByDatabaseAsync(string resourceGroupName, string managedInstanceName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceAdministratorsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ManagedInstanceAdministrator>
    {
        protected ManagedInstanceAdministratorsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ManagedInstanceAdministrator Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceAdministrator>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceAdministrator>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceAdministratorsDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected ManagedInstanceAdministratorsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceAdministratorsOperations
    {
        protected ManagedInstanceAdministratorsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceAdministrator> Get(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceAdministrator>> GetAsync(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedInstanceAdministrator> ListByInstance(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedInstanceAdministrator> ListByInstanceAsync(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceAdministratorsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.ManagedInstanceAdministrator parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedInstanceAdministratorsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.ManagedInstanceAdministrator parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceAdministratorsDeleteOperation StartDelete(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedInstanceAdministratorsDeleteOperation> StartDeleteAsync(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceEncryptionProtectorsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ManagedInstanceEncryptionProtector>
    {
        protected ManagedInstanceEncryptionProtectorsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ManagedInstanceEncryptionProtector Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceEncryptionProtector>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceEncryptionProtector>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceEncryptionProtectorsOperations
    {
        protected ManagedInstanceEncryptionProtectorsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceEncryptionProtector> Get(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceEncryptionProtector>> GetAsync(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedInstanceEncryptionProtector> ListByInstance(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedInstanceEncryptionProtector> ListByInstanceAsync(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Sql.Models.ManagedInstanceEncryptionProtector parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Sql.Models.ManagedInstanceEncryptionProtector parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorsRevalidateOperation StartRevalidate(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorsRevalidateOperation> StartRevalidateAsync(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceEncryptionProtectorsRevalidateOperation : Azure.Operation<Azure.Response>
    {
        protected ManagedInstanceEncryptionProtectorsRevalidateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceKeysCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ManagedInstanceKey>
    {
        protected ManagedInstanceKeysCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ManagedInstanceKey Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceKey>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceKey>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceKeysDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected ManagedInstanceKeysDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceKeysOperations
    {
        protected ManagedInstanceKeysOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceKey> Get(string resourceGroupName, string managedInstanceName, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceKey>> GetAsync(string resourceGroupName, string managedInstanceName, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedInstanceKey> ListByInstance(string resourceGroupName, string managedInstanceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedInstanceKey> ListByInstanceAsync(string resourceGroupName, string managedInstanceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceKeysCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string managedInstanceName, string keyName, Azure.ResourceManager.Sql.Models.ManagedInstanceKey parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedInstanceKeysCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string managedInstanceName, string keyName, Azure.ResourceManager.Sql.Models.ManagedInstanceKey parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceKeysDeleteOperation StartDelete(string resourceGroupName, string managedInstanceName, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedInstanceKeysDeleteOperation> StartDeleteAsync(string resourceGroupName, string managedInstanceName, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceLongTermRetentionPoliciesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicy>
    {
        protected ManagedInstanceLongTermRetentionPoliciesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceLongTermRetentionPoliciesOperations
    {
        protected ManagedInstanceLongTermRetentionPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicy> Get(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicy>> GetAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicy> ListByDatabase(string resourceGroupName, string managedInstanceName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicy> ListByDatabaseAsync(string resourceGroupName, string managedInstanceName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPoliciesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPoliciesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string managedInstanceName, string databaseName, Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceOperations
    {
        protected ManagedInstanceOperations() { }
        public virtual Azure.Response Cancel(string resourceGroupName, string managedInstanceName, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(string resourceGroupName, string managedInstanceName, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceOperation> Get(string resourceGroupName, string managedInstanceName, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceOperation>> GetAsync(string resourceGroupName, string managedInstanceName, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedInstanceOperation> ListByManagedInstance(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedInstanceOperation> ListByManagedInstanceAsync(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstancesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ManagedInstance>
    {
        protected ManagedInstancesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ManagedInstance Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstance>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstance>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstancesDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected ManagedInstancesDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstancesFailoverOperation : Azure.Operation<Azure.Response>
    {
        protected ManagedInstancesFailoverOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstancesOperations
    {
        protected ManagedInstancesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstance> Get(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstance>> GetAsync(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedInstance> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedInstance> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedInstance> ListByInstancePool(string resourceGroupName, string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedInstance> ListByInstancePoolAsync(string resourceGroupName, string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedInstance> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedInstance> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstancesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.ManagedInstance parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedInstancesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.ManagedInstance parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstancesDeleteOperation StartDelete(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedInstancesDeleteOperation> StartDeleteAsync(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstancesFailoverOperation StartFailover(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.ReplicaType? replicaType = default(Azure.ResourceManager.Sql.Models.ReplicaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedInstancesFailoverOperation> StartFailoverAsync(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.ReplicaType? replicaType = default(Azure.ResourceManager.Sql.Models.ReplicaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstancesUpdateOperation StartUpdate(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.ManagedInstanceUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedInstancesUpdateOperation> StartUpdateAsync(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.ManagedInstanceUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstancesUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ManagedInstance>
    {
        protected ManagedInstancesUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ManagedInstance Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstance>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstance>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceTdeCertificatesCreateOperation : Azure.Operation<Azure.Response>
    {
        protected ManagedInstanceTdeCertificatesCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceTdeCertificatesOperations
    {
        protected ManagedInstanceTdeCertificatesOperations() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceTdeCertificatesCreateOperation StartCreate(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.TdeCertificate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedInstanceTdeCertificatesCreateOperation> StartCreateAsync(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.TdeCertificate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceVulnerabilityAssessmentsOperations
    {
        protected ManagedInstanceVulnerabilityAssessmentsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceVulnerabilityAssessment> CreateOrUpdate(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.Models.ManagedInstanceVulnerabilityAssessment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceVulnerabilityAssessment>> CreateOrUpdateAsync(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.Models.ManagedInstanceVulnerabilityAssessment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceVulnerabilityAssessment> Get(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceVulnerabilityAssessment>> GetAsync(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedInstanceVulnerabilityAssessment> ListByInstance(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedInstanceVulnerabilityAssessment> ListByInstanceAsync(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedRestorableDroppedDatabaseBackupShortTermRetentionPoliciesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy>
    {
        protected ManagedRestorableDroppedDatabaseBackupShortTermRetentionPoliciesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedRestorableDroppedDatabaseBackupShortTermRetentionPoliciesOperations
    {
        protected ManagedRestorableDroppedDatabaseBackupShortTermRetentionPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy> Get(string resourceGroupName, string managedInstanceName, string restorableDroppedDatabaseId, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy>> GetAsync(string resourceGroupName, string managedInstanceName, string restorableDroppedDatabaseId, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy> ListByRestorableDroppedDatabase(string resourceGroupName, string managedInstanceName, string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy> ListByRestorableDroppedDatabaseAsync(string resourceGroupName, string managedInstanceName, string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedRestorableDroppedDatabaseBackupShortTermRetentionPoliciesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string managedInstanceName, string restorableDroppedDatabaseId, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedRestorableDroppedDatabaseBackupShortTermRetentionPoliciesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string managedInstanceName, string restorableDroppedDatabaseId, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedRestorableDroppedDatabaseBackupShortTermRetentionPoliciesUpdateOperation StartUpdate(string resourceGroupName, string managedInstanceName, string restorableDroppedDatabaseId, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedRestorableDroppedDatabaseBackupShortTermRetentionPoliciesUpdateOperation> StartUpdateAsync(string resourceGroupName, string managedInstanceName, string restorableDroppedDatabaseId, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedRestorableDroppedDatabaseBackupShortTermRetentionPoliciesUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy>
    {
        protected ManagedRestorableDroppedDatabaseBackupShortTermRetentionPoliciesUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedBackupShortTermRetentionPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedServerSecurityAlertPoliciesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ManagedServerSecurityAlertPolicy>
    {
        protected ManagedServerSecurityAlertPoliciesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ManagedServerSecurityAlertPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedServerSecurityAlertPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedServerSecurityAlertPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedServerSecurityAlertPoliciesOperations
    {
        protected ManagedServerSecurityAlertPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedServerSecurityAlertPolicy> Get(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedServerSecurityAlertPolicy>> GetAsync(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ManagedServerSecurityAlertPolicy> ListByInstance(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ManagedServerSecurityAlertPolicy> ListByInstanceAsync(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedServerSecurityAlertPoliciesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated securityAlertPolicyName, Azure.ResourceManager.Sql.Models.ManagedServerSecurityAlertPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPoliciesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string managedInstanceName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated securityAlertPolicyName, Azure.ResourceManager.Sql.Models.ManagedServerSecurityAlertPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Operations
    {
        protected Operations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.Operation> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.Operation> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.PrivateEndpointConnection>
    {
        protected PrivateEndpointConnectionsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.PrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.PrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.PrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionsDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected PrivateEndpointConnectionsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionsOperations
    {
        protected PrivateEndpointConnectionsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.PrivateEndpointConnection> Get(string resourceGroupName, string serverName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.PrivateEndpointConnection>> GetAsync(string resourceGroupName, string serverName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.PrivateEndpointConnection> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.PrivateEndpointConnection> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.PrivateEndpointConnectionsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string privateEndpointConnectionName, Azure.ResourceManager.Sql.Models.PrivateEndpointConnection parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.PrivateEndpointConnectionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string privateEndpointConnectionName, Azure.ResourceManager.Sql.Models.PrivateEndpointConnection parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.PrivateEndpointConnectionsDeleteOperation StartDelete(string resourceGroupName, string serverName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.PrivateEndpointConnectionsDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkResourcesOperations
    {
        protected PrivateLinkResourcesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.PrivateLinkResource> Get(string resourceGroupName, string serverName, string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.PrivateLinkResource>> GetAsync(string resourceGroupName, string serverName, string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.PrivateLinkResource> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.PrivateLinkResource> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecommendedElasticPoolsOperations
    {
        protected RecommendedElasticPoolsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.RecommendedElasticPool> Get(string resourceGroupName, string serverName, string recommendedElasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.RecommendedElasticPool>> GetAsync(string resourceGroupName, string serverName, string recommendedElasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.RecommendedElasticPool> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.RecommendedElasticPool> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.RecommendedElasticPoolMetric> ListMetrics(string resourceGroupName, string serverName, string recommendedElasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.RecommendedElasticPoolMetric> ListMetricsAsync(string resourceGroupName, string serverName, string recommendedElasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoverableDatabasesOperations
    {
        protected RecoverableDatabasesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.RecoverableDatabase> Get(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.RecoverableDatabase>> GetAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.RecoverableDatabase> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.RecoverableDatabase> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoverableManagedDatabasesOperations
    {
        protected RecoverableManagedDatabasesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.RecoverableManagedDatabase> Get(string resourceGroupName, string managedInstanceName, string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.RecoverableManagedDatabase>> GetAsync(string resourceGroupName, string managedInstanceName, string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.RecoverableManagedDatabase> ListByInstance(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.RecoverableManagedDatabase> ListByInstanceAsync(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReplicationLinksFailoverAllowDataLossOperation : Azure.Operation<Azure.Response>
    {
        protected ReplicationLinksFailoverAllowDataLossOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReplicationLinksFailoverOperation : Azure.Operation<Azure.Response>
    {
        protected ReplicationLinksFailoverOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReplicationLinksOperations
    {
        protected ReplicationLinksOperations() { }
        public virtual Azure.Response Delete(string resourceGroupName, string serverName, string databaseName, string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string serverName, string databaseName, string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ReplicationLink> Get(string resourceGroupName, string serverName, string databaseName, string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ReplicationLink>> GetAsync(string resourceGroupName, string serverName, string databaseName, string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ReplicationLink> ListByDatabase(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ReplicationLink> ListByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ReplicationLinksFailoverOperation StartFailover(string resourceGroupName, string serverName, string databaseName, string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ReplicationLinksFailoverAllowDataLossOperation StartFailoverAllowDataLoss(string resourceGroupName, string serverName, string databaseName, string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ReplicationLinksFailoverAllowDataLossOperation> StartFailoverAllowDataLossAsync(string resourceGroupName, string serverName, string databaseName, string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ReplicationLinksFailoverOperation> StartFailoverAsync(string resourceGroupName, string serverName, string databaseName, string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ReplicationLinksUnlinkOperation StartUnlink(string resourceGroupName, string serverName, string databaseName, string linkId, Azure.ResourceManager.Sql.Models.UnlinkParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ReplicationLinksUnlinkOperation> StartUnlinkAsync(string resourceGroupName, string serverName, string databaseName, string linkId, Azure.ResourceManager.Sql.Models.UnlinkParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReplicationLinksUnlinkOperation : Azure.Operation<Azure.Response>
    {
        protected ReplicationLinksUnlinkOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorableDroppedDatabasesOperations
    {
        protected RestorableDroppedDatabasesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.RestorableDroppedDatabase> Get(string resourceGroupName, string serverName, string restorableDroppededDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.RestorableDroppedDatabase>> GetAsync(string resourceGroupName, string serverName, string restorableDroppededDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.RestorableDroppedDatabase> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.RestorableDroppedDatabase> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorableDroppedManagedDatabasesOperations
    {
        protected RestorableDroppedManagedDatabasesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.RestorableDroppedManagedDatabase> Get(string resourceGroupName, string managedInstanceName, string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.RestorableDroppedManagedDatabase>> GetAsync(string resourceGroupName, string managedInstanceName, string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.RestorableDroppedManagedDatabase> ListByInstance(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.RestorableDroppedManagedDatabase> ListByInstanceAsync(string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointsCreateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.RestorePoint>
    {
        protected RestorePointsCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.RestorePoint Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.RestorePoint>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.RestorePoint>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointsOperations
    {
        protected RestorePointsOperations() { }
        public virtual Azure.Response Delete(string resourceGroupName, string serverName, string databaseName, string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string serverName, string databaseName, string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.RestorePoint> Get(string resourceGroupName, string serverName, string databaseName, string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.RestorePoint>> GetAsync(string resourceGroupName, string serverName, string databaseName, string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.RestorePoint> ListByDatabase(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.RestorePoint> ListByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.RestorePointsCreateOperation StartCreate(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.CreateDatabaseRestorePointDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.RestorePointsCreateOperation> StartCreateAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.CreateDatabaseRestorePointDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SensitivityLabelsOperations
    {
        protected SensitivityLabelsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.SensitivityLabel> CreateOrUpdate(string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName, string columnName, Azure.ResourceManager.Sql.Models.SensitivityLabel parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.SensitivityLabel>> CreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName, string columnName, Azure.ResourceManager.Sql.Models.SensitivityLabel parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName, string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName, string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DisableRecommendation(string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName, string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableRecommendationAsync(string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName, string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableRecommendation(string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName, string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableRecommendationAsync(string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName, string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.SensitivityLabel> Get(string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName, string columnName, Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.SensitivityLabel>> GetAsync(string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName, string columnName, Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SensitivityLabel> ListCurrentByDatabase(string resourceGroupName, string serverName, string databaseName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SensitivityLabel> ListCurrentByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SensitivityLabel> ListRecommendedByDatabase(string resourceGroupName, string serverName, string databaseName, bool? includeDisabledRecommendations = default(bool?), string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SensitivityLabel> ListRecommendedByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, bool? includeDisabledRecommendations = default(bool?), string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAutomaticTuningOperations
    {
        protected ServerAutomaticTuningOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ServerAutomaticTuning> Get(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ServerAutomaticTuning>> GetAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ServerAutomaticTuning> Update(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.ServerAutomaticTuning parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ServerAutomaticTuning>> UpdateAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.ServerAutomaticTuning parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAzureADAdministratorsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ServerAzureADAdministrator>
    {
        protected ServerAzureADAdministratorsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ServerAzureADAdministrator Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ServerAzureADAdministrator>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ServerAzureADAdministrator>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAzureADAdministratorsDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected ServerAzureADAdministratorsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAzureADAdministratorsOperations
    {
        protected ServerAzureADAdministratorsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ServerAzureADAdministrator> Get(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ServerAzureADAdministrator>> GetAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServerAzureADAdministrator> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServerAzureADAdministrator> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerAzureADAdministratorsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.AdministratorName administratorName, Azure.ResourceManager.Sql.Models.ServerAzureADAdministrator parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ServerAzureADAdministratorsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.AdministratorName administratorName, Azure.ResourceManager.Sql.Models.ServerAzureADAdministrator parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerAzureADAdministratorsDeleteOperation StartDelete(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ServerAzureADAdministratorsDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAzureADOnlyAuthenticationsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ServerAzureADOnlyAuthentication>
    {
        protected ServerAzureADOnlyAuthenticationsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ServerAzureADOnlyAuthentication Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ServerAzureADOnlyAuthentication>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ServerAzureADOnlyAuthentication>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAzureADOnlyAuthenticationsDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected ServerAzureADOnlyAuthenticationsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAzureADOnlyAuthenticationsOperations
    {
        protected ServerAzureADOnlyAuthenticationsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ServerAzureADOnlyAuthentication> Get(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ServerAzureADOnlyAuthentication>> GetAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServerAzureADOnlyAuthentication> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServerAzureADOnlyAuthentication> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, Azure.ResourceManager.Sql.Models.ServerAzureADOnlyAuthentication parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, Azure.ResourceManager.Sql.Models.ServerAzureADOnlyAuthentication parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationsDeleteOperation StartDelete(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationsDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerBlobAuditingPoliciesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ServerBlobAuditingPolicy>
    {
        protected ServerBlobAuditingPoliciesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ServerBlobAuditingPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ServerBlobAuditingPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ServerBlobAuditingPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerBlobAuditingPoliciesOperations
    {
        protected ServerBlobAuditingPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ServerBlobAuditingPolicy> Get(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ServerBlobAuditingPolicy>> GetAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServerBlobAuditingPolicy> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServerBlobAuditingPolicy> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerBlobAuditingPoliciesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.ServerBlobAuditingPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ServerBlobAuditingPoliciesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.ServerBlobAuditingPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerCommunicationLinksCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ServerCommunicationLink>
    {
        protected ServerCommunicationLinksCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ServerCommunicationLink Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ServerCommunicationLink>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ServerCommunicationLink>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerCommunicationLinksOperations
    {
        protected ServerCommunicationLinksOperations() { }
        public virtual Azure.Response Delete(string resourceGroupName, string serverName, string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string serverName, string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ServerCommunicationLink> Get(string resourceGroupName, string serverName, string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ServerCommunicationLink>> GetAsync(string resourceGroupName, string serverName, string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServerCommunicationLink> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServerCommunicationLink> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerCommunicationLinksCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string communicationLinkName, Azure.ResourceManager.Sql.Models.ServerCommunicationLink parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ServerCommunicationLinksCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string communicationLinkName, Azure.ResourceManager.Sql.Models.ServerCommunicationLink parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerConnectionPoliciesOperations
    {
        protected ServerConnectionPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ServerConnectionPolicy> CreateOrUpdate(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, Azure.ResourceManager.Sql.Models.ServerConnectionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ServerConnectionPolicy>> CreateOrUpdateAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, Azure.ResourceManager.Sql.Models.ServerConnectionPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ServerConnectionPolicy> Get(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ServerConnectionPolicy>> GetAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDnsAliasesAcquireOperation : Azure.Operation<Azure.Response>
    {
        protected ServerDnsAliasesAcquireOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDnsAliasesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ServerDnsAlias>
    {
        protected ServerDnsAliasesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ServerDnsAlias Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ServerDnsAlias>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ServerDnsAlias>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDnsAliasesDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected ServerDnsAliasesDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDnsAliasesOperations
    {
        protected ServerDnsAliasesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ServerDnsAlias> Get(string resourceGroupName, string serverName, string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ServerDnsAlias>> GetAsync(string resourceGroupName, string serverName, string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServerDnsAlias> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServerDnsAlias> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDnsAliasesAcquireOperation StartAcquire(string resourceGroupName, string serverName, string dnsAliasName, Azure.ResourceManager.Sql.Models.ServerDnsAliasAcquisition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ServerDnsAliasesAcquireOperation> StartAcquireAsync(string resourceGroupName, string serverName, string dnsAliasName, Azure.ResourceManager.Sql.Models.ServerDnsAliasAcquisition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDnsAliasesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ServerDnsAliasesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDnsAliasesDeleteOperation StartDelete(string resourceGroupName, string serverName, string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ServerDnsAliasesDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerKeysCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ServerKey>
    {
        protected ServerKeysCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ServerKey Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ServerKey>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ServerKey>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerKeysDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected ServerKeysDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerKeysOperations
    {
        protected ServerKeysOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ServerKey> Get(string resourceGroupName, string serverName, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ServerKey>> GetAsync(string resourceGroupName, string serverName, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServerKey> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServerKey> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerKeysCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string keyName, Azure.ResourceManager.Sql.Models.ServerKey parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ServerKeysCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string keyName, Azure.ResourceManager.Sql.Models.ServerKey parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerKeysDeleteOperation StartDelete(string resourceGroupName, string serverName, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ServerKeysDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServersCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.Server>
    {
        protected ServersCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.Server Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.Server>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.Server>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServersDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected ServersDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerSecurityAlertPoliciesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.ServerSecurityAlertPolicy>
    {
        protected ServerSecurityAlertPoliciesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.ServerSecurityAlertPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ServerSecurityAlertPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.ServerSecurityAlertPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerSecurityAlertPoliciesOperations
    {
        protected ServerSecurityAlertPoliciesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ServerSecurityAlertPolicy> Get(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ServerSecurityAlertPolicy>> GetAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServerSecurityAlertPolicy> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServerSecurityAlertPolicy> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerSecurityAlertPoliciesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated securityAlertPolicyName, Azure.ResourceManager.Sql.Models.ServerSecurityAlertPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ServerSecurityAlertPoliciesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated securityAlertPolicyName, Azure.ResourceManager.Sql.Models.ServerSecurityAlertPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServersOperations
    {
        protected ServersOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.CheckNameAvailabilityResponse> CheckNameAvailability(Azure.ResourceManager.Sql.Models.CheckNameAvailabilityRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.CheckNameAvailabilityResponse>> CheckNameAvailabilityAsync(Azure.ResourceManager.Sql.Models.CheckNameAvailabilityRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.Server> Get(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.Server>> GetAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.Server> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.Server> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.Server> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.Server> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServersCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.Server parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ServersCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.Server parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServersDeleteOperation StartDelete(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ServersDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServersUpdateOperation StartUpdate(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.ServerUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.ServersUpdateOperation> StartUpdateAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.ServerUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServersUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.Server>
    {
        protected ServersUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.Server Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.Server>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.Server>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerUsagesOperations
    {
        protected ServerUsagesOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServerUsage> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServerUsage> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerVulnerabilityAssessmentsOperations
    {
        protected ServerVulnerabilityAssessmentsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ServerVulnerabilityAssessment> CreateOrUpdate(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.Models.ServerVulnerabilityAssessment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ServerVulnerabilityAssessment>> CreateOrUpdateAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.Models.ServerVulnerabilityAssessment parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ServerVulnerabilityAssessment> Get(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ServerVulnerabilityAssessment>> GetAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServerVulnerabilityAssessment> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServerVulnerabilityAssessment> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceObjectivesOperations
    {
        protected ServiceObjectivesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ServiceObjective> Get(string resourceGroupName, string serverName, string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ServiceObjective>> GetAsync(string resourceGroupName, string serverName, string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServiceObjective> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServiceObjective> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceTierAdvisorsOperations
    {
        protected ServiceTierAdvisorsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ServiceTierAdvisor> Get(string resourceGroupName, string serverName, string databaseName, string serviceTierAdvisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ServiceTierAdvisor>> GetAsync(string resourceGroupName, string serverName, string databaseName, string serviceTierAdvisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServiceTierAdvisor> ListByDatabase(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServiceTierAdvisor> ListByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlManagementClient
    {
        protected SqlManagementClient() { }
        public SqlManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.Sql.SqlManagementClientOptions options = null) { }
        public SqlManagementClient(string subscriptionId, System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.Sql.SqlManagementClientOptions options = null) { }
        public virtual Azure.ResourceManager.Sql.BackupLongTermRetentionPoliciesOperations BackupLongTermRetentionPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.BackupShortTermRetentionPoliciesOperations BackupShortTermRetentionPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.CapabilitiesOperations Capabilities { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.DatabaseOperations Database { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.DatabaseAutomaticTuningOperations DatabaseAutomaticTuning { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.DatabaseBlobAuditingPoliciesOperations DatabaseBlobAuditingPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.DatabasesOperations Databases { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.DatabaseThreatDetectionPoliciesOperations DatabaseThreatDetectionPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.DatabaseUsagesOperations DatabaseUsages { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentRuleBaselinesOperations DatabaseVulnerabilityAssessmentRuleBaselines { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentsOperations DatabaseVulnerabilityAssessments { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentScansOperations DatabaseVulnerabilityAssessmentScans { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.DataMaskingPoliciesOperations DataMaskingPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.DataMaskingRulesOperations DataMaskingRules { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ElasticPoolOperations ElasticPool { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ElasticPoolActivitiesOperations ElasticPoolActivities { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ElasticPoolDatabaseActivitiesOperations ElasticPoolDatabaseActivities { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ElasticPoolsOperations ElasticPools { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.EncryptionProtectorsOperations EncryptionProtectors { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPoliciesOperations ExtendedDatabaseBlobAuditingPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPoliciesOperations ExtendedServerBlobAuditingPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.FailoverGroupsOperations FailoverGroups { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.FirewallRulesOperations FirewallRules { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.GeoBackupPoliciesOperations GeoBackupPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.InstanceFailoverGroupsOperations InstanceFailoverGroups { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.InstancePoolsOperations InstancePools { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.JobAgentsOperations JobAgents { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.JobCredentialsOperations JobCredentials { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.JobExecutionsOperations JobExecutions { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.JobsOperations Jobs { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.JobStepExecutionsOperations JobStepExecutions { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.JobStepsOperations JobSteps { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.JobTargetExecutionsOperations JobTargetExecutions { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.JobTargetGroupsOperations JobTargetGroups { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.JobVersionsOperations JobVersions { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.LongTermRetentionBackupsOperations LongTermRetentionBackups { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.LongTermRetentionManagedInstanceBackupsOperations LongTermRetentionManagedInstanceBackups { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPoliciesOperations ManagedBackupShortTermRetentionPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsOperations ManagedDatabaseRestoreDetails { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedDatabasesOperations ManagedDatabases { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPoliciesOperations ManagedDatabaseSecurityAlertPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseSensitivityLabelsOperations ManagedDatabaseSensitivityLabels { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseVulnerabilityAssessmentRuleBaselinesOperations ManagedDatabaseVulnerabilityAssessmentRuleBaselines { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseVulnerabilityAssessmentsOperations ManagedDatabaseVulnerabilityAssessments { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseVulnerabilityAssessmentScansOperations ManagedDatabaseVulnerabilityAssessmentScans { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceOperations ManagedInstance { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceAdministratorsOperations ManagedInstanceAdministrators { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorsOperations ManagedInstanceEncryptionProtectors { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceKeysOperations ManagedInstanceKeys { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPoliciesOperations ManagedInstanceLongTermRetentionPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedInstancesOperations ManagedInstances { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceTdeCertificatesOperations ManagedInstanceTdeCertificates { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentsOperations ManagedInstanceVulnerabilityAssessments { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedRestorableDroppedDatabaseBackupShortTermRetentionPoliciesOperations ManagedRestorableDroppedDatabaseBackupShortTermRetentionPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ManagedServerSecurityAlertPoliciesOperations ManagedServerSecurityAlertPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.Operations Operations { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.PrivateEndpointConnectionsOperations PrivateEndpointConnections { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.PrivateLinkResourcesOperations PrivateLinkResources { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.RecommendedElasticPoolsOperations RecommendedElasticPools { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.RecoverableDatabasesOperations RecoverableDatabases { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.RecoverableManagedDatabasesOperations RecoverableManagedDatabases { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ReplicationLinksOperations ReplicationLinks { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.RestorableDroppedDatabasesOperations RestorableDroppedDatabases { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.RestorableDroppedManagedDatabasesOperations RestorableDroppedManagedDatabases { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.RestorePointsOperations RestorePoints { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.SensitivityLabelsOperations SensitivityLabels { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ServerAutomaticTuningOperations ServerAutomaticTuning { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ServerAzureADAdministratorsOperations ServerAzureADAdministrators { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationsOperations ServerAzureADOnlyAuthentications { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ServerBlobAuditingPoliciesOperations ServerBlobAuditingPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ServerCommunicationLinksOperations ServerCommunicationLinks { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ServerConnectionPoliciesOperations ServerConnectionPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ServerDnsAliasesOperations ServerDnsAliases { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ServerKeysOperations ServerKeys { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ServersOperations Servers { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ServerSecurityAlertPoliciesOperations ServerSecurityAlertPolicies { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ServerUsagesOperations ServerUsages { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentsOperations ServerVulnerabilityAssessments { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ServiceObjectivesOperations ServiceObjectives { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.ServiceTierAdvisorsOperations ServiceTierAdvisors { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.SubscriptionUsagesOperations SubscriptionUsages { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.SyncAgentsOperations SyncAgents { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.SyncGroupsOperations SyncGroups { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.SyncMembersOperations SyncMembers { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.TdeCertificatesOperations TdeCertificates { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.TransparentDataEncryptionActivitiesOperations TransparentDataEncryptionActivities { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.TransparentDataEncryptionsOperations TransparentDataEncryptions { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.UsagesOperations Usages { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.VirtualClustersOperations VirtualClusters { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.VirtualNetworkRulesOperations VirtualNetworkRules { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.WorkloadClassifiersOperations WorkloadClassifiers { get { throw null; } }
        public virtual Azure.ResourceManager.Sql.WorkloadGroupsOperations WorkloadGroups { get { throw null; } }
    }
    public partial class SqlManagementClientOptions : Azure.Core.ClientOptions
    {
        public SqlManagementClientOptions() { }
    }
    public partial class SubscriptionUsagesOperations
    {
        protected SubscriptionUsagesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.SubscriptionUsage> Get(string locationName, string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.SubscriptionUsage>> GetAsync(string locationName, string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SubscriptionUsage> ListByLocation(string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SubscriptionUsage> ListByLocationAsync(string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncAgentsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.SyncAgent>
    {
        protected SyncAgentsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.SyncAgent Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.SyncAgent>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.SyncAgent>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncAgentsDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected SyncAgentsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncAgentsOperations
    {
        protected SyncAgentsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.SyncAgentKeyProperties> GenerateKey(string resourceGroupName, string serverName, string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.SyncAgentKeyProperties>> GenerateKeyAsync(string resourceGroupName, string serverName, string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.SyncAgent> Get(string resourceGroupName, string serverName, string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.SyncAgent>> GetAsync(string resourceGroupName, string serverName, string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncAgent> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncAgent> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncAgentLinkedDatabase> ListLinkedDatabases(string resourceGroupName, string serverName, string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncAgentLinkedDatabase> ListLinkedDatabasesAsync(string resourceGroupName, string serverName, string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncAgentsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string syncAgentName, Azure.ResourceManager.Sql.Models.SyncAgent parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.SyncAgentsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string syncAgentName, Azure.ResourceManager.Sql.Models.SyncAgent parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncAgentsDeleteOperation StartDelete(string resourceGroupName, string serverName, string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.SyncAgentsDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncGroupsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.SyncGroup>
    {
        protected SyncGroupsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.SyncGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.SyncGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.SyncGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncGroupsDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected SyncGroupsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncGroupsOperations
    {
        protected SyncGroupsOperations() { }
        public virtual Azure.Response CancelSync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelSyncAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.SyncGroup> Get(string resourceGroupName, string serverName, string databaseName, string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.SyncGroup>> GetAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncGroup> ListByDatabase(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncGroup> ListByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncFullSchemaProperties> ListHubSchemas(string resourceGroupName, string serverName, string databaseName, string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncFullSchemaProperties> ListHubSchemasAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncGroupLogProperties> ListLogs(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string startTime, string endTime, Azure.ResourceManager.Sql.Models.Enum65 type, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncGroupLogProperties> ListLogsAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string startTime, string endTime, Azure.ResourceManager.Sql.Models.Enum65 type, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncDatabaseIdProperties> ListSyncDatabaseIds(string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncDatabaseIdProperties> ListSyncDatabaseIdsAsync(string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncGroupsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string databaseName, string syncGroupName, Azure.ResourceManager.Sql.Models.SyncGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.SyncGroupsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, Azure.ResourceManager.Sql.Models.SyncGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncGroupsDeleteOperation StartDelete(string resourceGroupName, string serverName, string databaseName, string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.SyncGroupsDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncGroupsRefreshHubSchemaOperation StartRefreshHubSchema(string resourceGroupName, string serverName, string databaseName, string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.SyncGroupsRefreshHubSchemaOperation> StartRefreshHubSchemaAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncGroupsUpdateOperation StartUpdate(string resourceGroupName, string serverName, string databaseName, string syncGroupName, Azure.ResourceManager.Sql.Models.SyncGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.SyncGroupsUpdateOperation> StartUpdateAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, Azure.ResourceManager.Sql.Models.SyncGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response TriggerSync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TriggerSyncAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncGroupsRefreshHubSchemaOperation : Azure.Operation<Azure.Response>
    {
        protected SyncGroupsRefreshHubSchemaOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncGroupsUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.SyncGroup>
    {
        protected SyncGroupsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.SyncGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.SyncGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.SyncGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncMembersCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.SyncMember>
    {
        protected SyncMembersCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.SyncMember Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.SyncMember>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.SyncMember>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncMembersDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected SyncMembersDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncMembersOperations
    {
        protected SyncMembersOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.SyncMember> Get(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.SyncMember>> GetAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncMember> ListBySyncGroup(string resourceGroupName, string serverName, string databaseName, string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncMember> ListBySyncGroupAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncFullSchemaProperties> ListMemberSchemas(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncFullSchemaProperties> ListMemberSchemasAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncMembersCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, Azure.ResourceManager.Sql.Models.SyncMember parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.SyncMembersCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, Azure.ResourceManager.Sql.Models.SyncMember parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncMembersDeleteOperation StartDelete(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.SyncMembersDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncMembersRefreshMemberSchemaOperation StartRefreshMemberSchema(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.SyncMembersRefreshMemberSchemaOperation> StartRefreshMemberSchemaAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncMembersUpdateOperation StartUpdate(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, Azure.ResourceManager.Sql.Models.SyncMember parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.SyncMembersUpdateOperation> StartUpdateAsync(string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName, Azure.ResourceManager.Sql.Models.SyncMember parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncMembersRefreshMemberSchemaOperation : Azure.Operation<Azure.Response>
    {
        protected SyncMembersRefreshMemberSchemaOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncMembersUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.SyncMember>
    {
        protected SyncMembersUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.SyncMember Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.SyncMember>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.SyncMember>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TdeCertificatesCreateOperation : Azure.Operation<Azure.Response>
    {
        protected TdeCertificatesCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TdeCertificatesOperations
    {
        protected TdeCertificatesOperations() { }
        public virtual Azure.ResourceManager.Sql.TdeCertificatesCreateOperation StartCreate(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.TdeCertificate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.TdeCertificatesCreateOperation> StartCreateAsync(string resourceGroupName, string serverName, Azure.ResourceManager.Sql.Models.TdeCertificate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TransparentDataEncryptionActivitiesOperations
    {
        protected TransparentDataEncryptionActivitiesOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.TransparentDataEncryptionActivity> ListByConfiguration(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.TransparentDataEncryptionActivity> ListByConfigurationAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TransparentDataEncryptionsOperations
    {
        protected TransparentDataEncryptionsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.TransparentDataEncryption> CreateOrUpdate(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName transparentDataEncryptionName, Azure.ResourceManager.Sql.Models.TransparentDataEncryption parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.TransparentDataEncryption>> CreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName transparentDataEncryptionName, Azure.ResourceManager.Sql.Models.TransparentDataEncryption parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.TransparentDataEncryption> Get(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.TransparentDataEncryption>> GetAsync(string resourceGroupName, string serverName, string databaseName, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UsagesOperations
    {
        protected UsagesOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.Usage> ListByInstancePool(string resourceGroupName, string instancePoolName, bool? expandChildren = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.Usage> ListByInstancePoolAsync(string resourceGroupName, string instancePoolName, bool? expandChildren = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualClustersDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected VirtualClustersDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualClustersOperations
    {
        protected VirtualClustersOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.VirtualCluster> Get(string resourceGroupName, string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.VirtualCluster>> GetAsync(string resourceGroupName, string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.VirtualCluster> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.VirtualCluster> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.VirtualCluster> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.VirtualCluster> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.VirtualClustersDeleteOperation StartDelete(string resourceGroupName, string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.VirtualClustersDeleteOperation> StartDeleteAsync(string resourceGroupName, string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.VirtualClustersUpdateOperation StartUpdate(string resourceGroupName, string virtualClusterName, Azure.ResourceManager.Sql.Models.VirtualClusterUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.VirtualClustersUpdateOperation> StartUpdateAsync(string resourceGroupName, string virtualClusterName, Azure.ResourceManager.Sql.Models.VirtualClusterUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualClustersUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.VirtualCluster>
    {
        protected VirtualClustersUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.VirtualCluster Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.VirtualCluster>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.VirtualCluster>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkRulesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.VirtualNetworkRule>
    {
        protected VirtualNetworkRulesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.VirtualNetworkRule Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.VirtualNetworkRule>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.VirtualNetworkRule>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkRulesDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected VirtualNetworkRulesDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkRulesOperations
    {
        protected VirtualNetworkRulesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.VirtualNetworkRule> Get(string resourceGroupName, string serverName, string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.VirtualNetworkRule>> GetAsync(string resourceGroupName, string serverName, string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.VirtualNetworkRule> ListByServer(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.VirtualNetworkRule> ListByServerAsync(string resourceGroupName, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.VirtualNetworkRulesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string virtualNetworkRuleName, Azure.ResourceManager.Sql.Models.VirtualNetworkRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.VirtualNetworkRulesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string virtualNetworkRuleName, Azure.ResourceManager.Sql.Models.VirtualNetworkRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.VirtualNetworkRulesDeleteOperation StartDelete(string resourceGroupName, string serverName, string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.VirtualNetworkRulesDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadClassifiersCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.WorkloadClassifier>
    {
        protected WorkloadClassifiersCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.WorkloadClassifier Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.WorkloadClassifier>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.WorkloadClassifier>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadClassifiersDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected WorkloadClassifiersDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadClassifiersOperations
    {
        protected WorkloadClassifiersOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.WorkloadClassifier> Get(string resourceGroupName, string serverName, string databaseName, string workloadGroupName, string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.WorkloadClassifier>> GetAsync(string resourceGroupName, string serverName, string databaseName, string workloadGroupName, string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.WorkloadClassifier> ListByWorkloadGroup(string resourceGroupName, string serverName, string databaseName, string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.WorkloadClassifier> ListByWorkloadGroupAsync(string resourceGroupName, string serverName, string databaseName, string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.WorkloadClassifiersCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string databaseName, string workloadGroupName, string workloadClassifierName, Azure.ResourceManager.Sql.Models.WorkloadClassifier parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.WorkloadClassifiersCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, string workloadGroupName, string workloadClassifierName, Azure.ResourceManager.Sql.Models.WorkloadClassifier parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.WorkloadClassifiersDeleteOperation StartDelete(string resourceGroupName, string serverName, string databaseName, string workloadGroupName, string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.WorkloadClassifiersDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, string databaseName, string workloadGroupName, string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadGroupsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Sql.Models.WorkloadGroup>
    {
        protected WorkloadGroupsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Sql.Models.WorkloadGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.WorkloadGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Sql.Models.WorkloadGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadGroupsDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected WorkloadGroupsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadGroupsOperations
    {
        protected WorkloadGroupsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.WorkloadGroup> Get(string resourceGroupName, string serverName, string databaseName, string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.WorkloadGroup>> GetAsync(string resourceGroupName, string serverName, string databaseName, string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.WorkloadGroup> ListByDatabase(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.WorkloadGroup> ListByDatabaseAsync(string resourceGroupName, string serverName, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.WorkloadGroupsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string serverName, string databaseName, string workloadGroupName, Azure.ResourceManager.Sql.Models.WorkloadGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.WorkloadGroupsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string serverName, string databaseName, string workloadGroupName, Azure.ResourceManager.Sql.Models.WorkloadGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.WorkloadGroupsDeleteOperation StartDelete(string resourceGroupName, string serverName, string databaseName, string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Sql.WorkloadGroupsDeleteOperation> StartDeleteAsync(string resourceGroupName, string serverName, string databaseName, string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Sql.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdministratorName : System.IEquatable<Azure.ResourceManager.Sql.Models.AdministratorName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdministratorName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.AdministratorName ActiveDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.AdministratorName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.AdministratorName left, Azure.ResourceManager.Sql.Models.AdministratorName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.AdministratorName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.AdministratorName left, Azure.ResourceManager.Sql.Models.AdministratorName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdministratorType : System.IEquatable<Azure.ResourceManager.Sql.Models.AdministratorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdministratorType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.AdministratorType ActiveDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.AdministratorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.AdministratorType left, Azure.ResourceManager.Sql.Models.AdministratorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.AdministratorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.AdministratorType left, Azure.ResourceManager.Sql.Models.AdministratorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthenticationName : System.IEquatable<Azure.ResourceManager.Sql.Models.AuthenticationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.AuthenticationName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.AuthenticationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.AuthenticationName left, Azure.ResourceManager.Sql.Models.AuthenticationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.AuthenticationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.AuthenticationName left, Azure.ResourceManager.Sql.Models.AuthenticationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum AuthenticationType
    {
        SQL = 0,
        ADPassword = 1,
    }
    public enum AutomaticTuningDisabledReason
    {
        Default = 0,
        Disabled = 1,
        AutoConfigured = 2,
        InheritedFromServer = 3,
        QueryStoreOff = 4,
        QueryStoreReadOnly = 5,
        NotSupported = 6,
    }
    public enum AutomaticTuningMode
    {
        Inherit = 0,
        Custom = 1,
        Auto = 2,
        Unspecified = 3,
    }
    public enum AutomaticTuningOptionModeActual
    {
        Off = 0,
        On = 1,
    }
    public enum AutomaticTuningOptionModeDesired
    {
        Off = 0,
        On = 1,
        Default = 2,
    }
    public partial class AutomaticTuningOptions
    {
        public AutomaticTuningOptions() { }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningOptionModeActual? ActualState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningOptionModeDesired? DesiredState { get { throw null; } set { } }
        public int? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningDisabledReason? ReasonDesc { get { throw null; } }
    }
    public enum AutomaticTuningServerMode
    {
        Custom = 0,
        Auto = 1,
        Unspecified = 2,
    }
    public partial class AutomaticTuningServerOptions
    {
        public AutomaticTuningServerOptions() { }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningOptionModeActual? ActualState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningOptionModeDesired? DesiredState { get { throw null; } set { } }
        public int? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningServerReason? ReasonDesc { get { throw null; } }
    }
    public enum AutomaticTuningServerReason
    {
        Default = 0,
        Disabled = 1,
        AutoConfigured = 2,
    }
    public partial class AutoPauseDelayTimeRange
    {
        internal AutoPauseDelayTimeRange() { }
        public int? Default { get { throw null; } }
        public int? DoNotPauseValue { get { throw null; } }
        public int? MaxValue { get { throw null; } }
        public int? MinValue { get { throw null; } }
        public int? StepSize { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.PauseDelayTimeUnit? Unit { get { throw null; } }
    }
    public partial class BackupLongTermRetentionPolicy : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public BackupLongTermRetentionPolicy() { }
        public string MonthlyRetention { get { throw null; } set { } }
        public string WeeklyRetention { get { throw null; } set { } }
        public int? WeekOfYear { get { throw null; } set { } }
        public string YearlyRetention { get { throw null; } set { } }
    }
    public partial class BackupShortTermRetentionPolicy : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public BackupShortTermRetentionPolicy() { }
        public Azure.ResourceManager.Sql.Models.DiffBackupIntervalInHours? DiffBackupIntervalInHours { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
    }
    public enum BlobAuditingPolicyState
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapabilityGroup : System.IEquatable<Azure.ResourceManager.Sql.Models.CapabilityGroup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapabilityGroup(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.CapabilityGroup SupportedEditions { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CapabilityGroup SupportedElasticPoolEditions { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CapabilityGroup SupportedInstancePoolEditions { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CapabilityGroup SupportedManagedInstanceEditions { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CapabilityGroup SupportedManagedInstanceVersions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.CapabilityGroup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.CapabilityGroup left, Azure.ResourceManager.Sql.Models.CapabilityGroup right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.CapabilityGroup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.CapabilityGroup left, Azure.ResourceManager.Sql.Models.CapabilityGroup right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum CapabilityStatus
    {
        Visible = 0,
        Available = 1,
        Default = 2,
        Disabled = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CatalogCollationType : System.IEquatable<Azure.ResourceManager.Sql.Models.CatalogCollationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CatalogCollationType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.CatalogCollationType DatabaseDefault { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CatalogCollationType SQLLatin1GeneralCP1CIAS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.CatalogCollationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.CatalogCollationType left, Azure.ResourceManager.Sql.Models.CatalogCollationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.CatalogCollationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.CatalogCollationType left, Azure.ResourceManager.Sql.Models.CatalogCollationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum CheckNameAvailabilityReason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
    public partial class CheckNameAvailabilityRequest
    {
        public CheckNameAvailabilityRequest(string name) { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class CheckNameAvailabilityResponse
    {
        internal CheckNameAvailabilityResponse() { }
        public bool? Available { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CheckNameAvailabilityReason? Reason { get { throw null; } }
    }
    public partial class CompleteDatabaseRestoreDefinition
    {
        public CompleteDatabaseRestoreDefinition(string lastBackupName) { }
        public string LastBackupName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionPolicyName : System.IEquatable<Azure.ResourceManager.Sql.Models.ConnectionPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ConnectionPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ConnectionPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ConnectionPolicyName left, Azure.ResourceManager.Sql.Models.ConnectionPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ConnectionPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ConnectionPolicyName left, Azure.ResourceManager.Sql.Models.ConnectionPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreateDatabaseRestorePointDefinition
    {
        public CreateDatabaseRestorePointDefinition(string restorePointLabel) { }
        public string RestorePointLabel { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateMode : System.IEquatable<Azure.ResourceManager.Sql.Models.CreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateMode(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.CreateMode Copy { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CreateMode OnlineSecondary { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CreateMode PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CreateMode Recovery { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CreateMode Restore { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CreateMode RestoreExternalBackup { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CreateMode RestoreExternalBackupSecondary { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CreateMode RestoreLongTermRetentionBackup { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CreateMode Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.CreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.CreateMode left, Azure.ResourceManager.Sql.Models.CreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.CreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.CreateMode left, Azure.ResourceManager.Sql.Models.CreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Database : Azure.ResourceManager.Sql.Models.TrackedResource
    {
        public Database(string location) : base (default(string)) { }
        public int? AutoPauseDelay { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CatalogCollationType? CatalogCollation { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public string CurrentServiceObjectiveName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.Sku CurrentSku { get { throw null; } }
        public System.Guid? DatabaseId { get { throw null; } }
        public string DefaultSecondaryLocation { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreDate { get { throw null; } }
        public string ElasticPoolId { get { throw null; } set { } }
        public string FailoverGroupId { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.DatabaseLicenseType? LicenseType { get { throw null; } set { } }
        public string LongTermRetentionBackupResourceId { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } }
        public long? MaxLogSizeBytes { get { throw null; } }
        public long? MaxSizeBytes { get { throw null; } set { } }
        public double? MinCapacity { get { throw null; } set { } }
        public System.DateTimeOffset? PausedDate { get { throw null; } }
        public int? ReadReplicaCount { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.DatabaseReadScale? ReadScale { get { throw null; } set { } }
        public string RecoverableDatabaseId { get { throw null; } set { } }
        public string RecoveryServicesRecoveryPointId { get { throw null; } set { } }
        public string RequestedServiceObjectiveName { get { throw null; } }
        public string RestorableDroppedDatabaseId { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
        public System.DateTimeOffset? ResumedDate { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SampleName? SampleName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.Sku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? SourceDatabaseDeletionDate { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.DatabaseStatus? Status { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class DatabaseAutomaticTuning : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public DatabaseAutomaticTuning() { }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningMode? ActualState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningMode? DesiredState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Sql.Models.AutomaticTuningOptions> Options { get { throw null; } }
    }
    public partial class DatabaseBlobAuditingPolicy : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public DatabaseBlobAuditingPolicy() { }
        public System.Collections.Generic.IList<string> AuditActionsAndGroups { get { throw null; } }
        public bool? IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public bool? IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public int? QueueDelayMs { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.BlobAuditingPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public System.Guid? StorageAccountSubscriptionId { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseEdition : System.IEquatable<Azure.ResourceManager.Sql.Models.DatabaseEdition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseEdition(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.DatabaseEdition Basic { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseEdition Business { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseEdition BusinessCritical { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseEdition DataWarehouse { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseEdition Free { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseEdition GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseEdition Hyperscale { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseEdition Premium { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseEdition PremiumRS { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseEdition Standard { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseEdition Stretch { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseEdition System { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseEdition System2 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseEdition Web { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.DatabaseEdition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.DatabaseEdition left, Azure.ResourceManager.Sql.Models.DatabaseEdition right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.DatabaseEdition (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.DatabaseEdition left, Azure.ResourceManager.Sql.Models.DatabaseEdition right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseLicenseType : System.IEquatable<Azure.ResourceManager.Sql.Models.DatabaseLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.DatabaseLicenseType BasePrice { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseLicenseType LicenseIncluded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.DatabaseLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.DatabaseLicenseType left, Azure.ResourceManager.Sql.Models.DatabaseLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.DatabaseLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.DatabaseLicenseType left, Azure.ResourceManager.Sql.Models.DatabaseLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseOperation : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public DatabaseOperation() { }
        public string DatabaseName { get { throw null; } }
        public string Description { get { throw null; } }
        public int? ErrorCode { get { throw null; } }
        public string ErrorDescription { get { throw null; } }
        public int? ErrorSeverity { get { throw null; } }
        public System.DateTimeOffset? EstimatedCompletionTime { get { throw null; } }
        public bool? IsCancellable { get { throw null; } }
        public bool? IsUserError { get { throw null; } }
        public string Operation { get { throw null; } }
        public string OperationFriendlyName { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public string ServerName { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ManagementOperationState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseReadScale : System.IEquatable<Azure.ResourceManager.Sql.Models.DatabaseReadScale>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseReadScale(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.DatabaseReadScale Disabled { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseReadScale Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.DatabaseReadScale other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.DatabaseReadScale left, Azure.ResourceManager.Sql.Models.DatabaseReadScale right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.DatabaseReadScale (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.DatabaseReadScale left, Azure.ResourceManager.Sql.Models.DatabaseReadScale right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseSecurityAlertPolicy : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public DatabaseSecurityAlertPolicy() { }
        public string DisabledAlerts { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecurityAlertPolicyEmailAccountAdmins? EmailAccountAdmins { get { throw null; } set { } }
        public string EmailAddresses { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecurityAlertPolicyUseServerDefault? UseServerDefault { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseState : System.IEquatable<Azure.ResourceManager.Sql.Models.DatabaseState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.DatabaseState All { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseState Live { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.DatabaseState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.DatabaseState left, Azure.ResourceManager.Sql.Models.DatabaseState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.DatabaseState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.DatabaseState left, Azure.ResourceManager.Sql.Models.DatabaseState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseStatus : System.IEquatable<Azure.ResourceManager.Sql.Models.DatabaseStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseStatus(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus AutoClosed { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus Copying { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus EmergencyMode { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus Inaccessible { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus OfflineChangingDwPerformanceTiers { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus OfflineSecondary { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus Online { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus OnlineChangingDwPerformanceTiers { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus Pausing { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus Recovering { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus RecoveryPending { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus Restoring { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus Resuming { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus Scaling { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus Shutdown { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus Standby { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DatabaseStatus Suspect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.DatabaseStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.DatabaseStatus left, Azure.ResourceManager.Sql.Models.DatabaseStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.DatabaseStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.DatabaseStatus left, Azure.ResourceManager.Sql.Models.DatabaseStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseUpdate
    {
        public DatabaseUpdate() { }
        public int? AutoPauseDelay { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CatalogCollationType? CatalogCollation { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public string CurrentServiceObjectiveName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.Sku CurrentSku { get { throw null; } }
        public System.Guid? DatabaseId { get { throw null; } }
        public string DefaultSecondaryLocation { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreDate { get { throw null; } }
        public string ElasticPoolId { get { throw null; } set { } }
        public string FailoverGroupId { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.DatabaseLicenseType? LicenseType { get { throw null; } set { } }
        public string LongTermRetentionBackupResourceId { get { throw null; } set { } }
        public long? MaxLogSizeBytes { get { throw null; } }
        public long? MaxSizeBytes { get { throw null; } set { } }
        public double? MinCapacity { get { throw null; } set { } }
        public System.DateTimeOffset? PausedDate { get { throw null; } }
        public int? ReadReplicaCount { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.DatabaseReadScale? ReadScale { get { throw null; } set { } }
        public string RecoverableDatabaseId { get { throw null; } set { } }
        public string RecoveryServicesRecoveryPointId { get { throw null; } set { } }
        public string RequestedServiceObjectiveName { get { throw null; } }
        public string RestorableDroppedDatabaseId { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
        public System.DateTimeOffset? ResumedDate { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SampleName? SampleName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.Sku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? SourceDatabaseDeletionDate { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.DatabaseStatus? Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class DatabaseUsage
    {
        internal DatabaseUsage() { }
        public double? CurrentValue { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public double? Limit { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? NextResetTime { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class DatabaseVulnerabilityAssessment : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public DatabaseVulnerabilityAssessment() { }
        public Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageContainerPath { get { throw null; } set { } }
        public string StorageContainerSasKey { get { throw null; } set { } }
    }
    public partial class DatabaseVulnerabilityAssessmentRuleBaseline : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public DatabaseVulnerabilityAssessmentRuleBaseline() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentRuleBaselineItem> BaselineResults { get { throw null; } }
    }
    public partial class DatabaseVulnerabilityAssessmentRuleBaselineItem
    {
        public DatabaseVulnerabilityAssessmentRuleBaselineItem(System.Collections.Generic.IEnumerable<string> result) { }
        public System.Collections.Generic.IList<string> Result { get { throw null; } }
    }
    public partial class DatabaseVulnerabilityAssessmentScansExport : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public DatabaseVulnerabilityAssessmentScansExport() { }
        public string ExportedReportLocation { get { throw null; } }
    }
    public enum DataMaskingFunction
    {
        Default = 0,
        CCN = 1,
        Email = 2,
        Number = 3,
        SSN = 4,
        Text = 5,
    }
    public partial class DataMaskingPolicy : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public DataMaskingPolicy() { }
        public string ApplicationPrincipals { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.DataMaskingState? DataMaskingState { get { throw null; } set { } }
        public string ExemptPrincipals { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } }
        public string MaskingLevel { get { throw null; } }
    }
    public partial class DataMaskingRule : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public DataMaskingRule() { }
        public string AliasName { get { throw null; } set { } }
        public string ColumnName { get { throw null; } set { } }
        public string IdPropertiesId { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.DataMaskingFunction? MaskingFunction { get { throw null; } set { } }
        public string NumberFrom { get { throw null; } set { } }
        public string NumberTo { get { throw null; } set { } }
        public string PrefixSize { get { throw null; } set { } }
        public string ReplacementString { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.DataMaskingRuleState? RuleState { get { throw null; } set { } }
        public string SchemaName { get { throw null; } set { } }
        public string SuffixSize { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    public enum DataMaskingRuleState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum DataMaskingState
    {
        Disabled = 0,
        Enabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffBackupIntervalInHours : System.IEquatable<Azure.ResourceManager.Sql.Models.DiffBackupIntervalInHours>
    {
        private readonly int _dummyPrimitive;
        public DiffBackupIntervalInHours(int value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.DiffBackupIntervalInHours Twelve { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DiffBackupIntervalInHours TwentyFour { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.DiffBackupIntervalInHours other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.DiffBackupIntervalInHours left, Azure.ResourceManager.Sql.Models.DiffBackupIntervalInHours right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.DiffBackupIntervalInHours (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.DiffBackupIntervalInHours left, Azure.ResourceManager.Sql.Models.DiffBackupIntervalInHours right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EditionCapability
    {
        internal EditionCapability() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ReadScaleCapability ReadScale { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ServiceObjectiveCapability> SupportedServiceLevelObjectives { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.StorageCapability> SupportedStorageCapabilities { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } }
    }
    public partial class ElasticPool : Azure.ResourceManager.Sql.Models.TrackedResource
    {
        public ElasticPool(string location) : base (default(string)) { }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ElasticPoolLicenseType? LicenseType { get { throw null; } set { } }
        public long? MaxSizeBytes { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ElasticPoolPerDatabaseSettings PerDatabaseSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ElasticPoolState? State { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class ElasticPoolActivity : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ElasticPoolActivity() { }
        public string ElasticPoolName { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public int? ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public int? ErrorSeverity { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public string Operation { get { throw null; } }
        public System.Guid? OperationId { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public int? RequestedDatabaseDtuCap { get { throw null; } }
        public int? RequestedDatabaseDtuGuarantee { get { throw null; } }
        public int? RequestedDatabaseDtuMax { get { throw null; } }
        public int? RequestedDatabaseDtuMin { get { throw null; } }
        public int? RequestedDtu { get { throw null; } }
        public int? RequestedDtuGuarantee { get { throw null; } }
        public string RequestedElasticPoolName { get { throw null; } }
        public long? RequestedStorageLimitInGB { get { throw null; } }
        public int? RequestedStorageLimitInMB { get { throw null; } }
        public string ServerName { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public string State { get { throw null; } }
    }
    public partial class ElasticPoolDatabaseActivity : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ElasticPoolDatabaseActivity() { }
        public string CurrentElasticPoolName { get { throw null; } }
        public string CurrentServiceObjective { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public int? ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public int? ErrorSeverity { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public string Operation { get { throw null; } }
        public System.Guid? OperationId { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public string RequestedElasticPoolName { get { throw null; } }
        public string RequestedServiceObjective { get { throw null; } }
        public string ServerName { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public string State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticPoolEdition : System.IEquatable<Azure.ResourceManager.Sql.Models.ElasticPoolEdition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticPoolEdition(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ElasticPoolEdition Basic { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ElasticPoolEdition BusinessCritical { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ElasticPoolEdition GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ElasticPoolEdition Premium { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ElasticPoolEdition Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ElasticPoolEdition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ElasticPoolEdition left, Azure.ResourceManager.Sql.Models.ElasticPoolEdition right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ElasticPoolEdition (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ElasticPoolEdition left, Azure.ResourceManager.Sql.Models.ElasticPoolEdition right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ElasticPoolEditionCapability
    {
        internal ElasticPoolEditionCapability() { }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ElasticPoolPerformanceLevelCapability> SupportedElasticPoolPerformanceLevels { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticPoolLicenseType : System.IEquatable<Azure.ResourceManager.Sql.Models.ElasticPoolLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticPoolLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ElasticPoolLicenseType BasePrice { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ElasticPoolLicenseType LicenseIncluded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ElasticPoolLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ElasticPoolLicenseType left, Azure.ResourceManager.Sql.Models.ElasticPoolLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ElasticPoolLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ElasticPoolLicenseType left, Azure.ResourceManager.Sql.Models.ElasticPoolLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ElasticPoolOperation : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ElasticPoolOperation() { }
        public string Description { get { throw null; } }
        public string ElasticPoolName { get { throw null; } }
        public int? ErrorCode { get { throw null; } }
        public string ErrorDescription { get { throw null; } }
        public int? ErrorSeverity { get { throw null; } }
        public System.DateTimeOffset? EstimatedCompletionTime { get { throw null; } }
        public bool? IsCancellable { get { throw null; } }
        public bool? IsUserError { get { throw null; } }
        public string Operation { get { throw null; } }
        public string OperationFriendlyName { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public string ServerName { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public string State { get { throw null; } }
    }
    public partial class ElasticPoolPerDatabaseMaxPerformanceLevelCapability
    {
        internal ElasticPoolPerDatabaseMaxPerformanceLevelCapability() { }
        public double? Limit { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ElasticPoolPerDatabaseMinPerformanceLevelCapability> SupportedPerDatabaseMinPerformanceLevels { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.PerformanceLevelUnit? Unit { get { throw null; } }
    }
    public partial class ElasticPoolPerDatabaseMinPerformanceLevelCapability
    {
        internal ElasticPoolPerDatabaseMinPerformanceLevelCapability() { }
        public double? Limit { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.PerformanceLevelUnit? Unit { get { throw null; } }
    }
    public partial class ElasticPoolPerDatabaseSettings
    {
        public ElasticPoolPerDatabaseSettings() { }
        public double? MaxCapacity { get { throw null; } set { } }
        public double? MinCapacity { get { throw null; } set { } }
    }
    public partial class ElasticPoolPerformanceLevelCapability
    {
        internal ElasticPoolPerformanceLevelCapability() { }
        public Azure.ResourceManager.Sql.Models.MaxSizeCapability IncludedMaxSize { get { throw null; } }
        public int? MaxDatabaseCount { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.PerformanceLevelCapability PerformanceLevel { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.Sku Sku { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.LicenseTypeCapability> SupportedLicenseTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.MaxSizeRangeCapability> SupportedMaxSizes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ElasticPoolPerDatabaseMaxPerformanceLevelCapability> SupportedPerDatabaseMaxPerformanceLevels { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.MaxSizeRangeCapability> SupportedPerDatabaseMaxSizes { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticPoolState : System.IEquatable<Azure.ResourceManager.Sql.Models.ElasticPoolState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticPoolState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ElasticPoolState Creating { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ElasticPoolState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ElasticPoolState Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ElasticPoolState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ElasticPoolState left, Azure.ResourceManager.Sql.Models.ElasticPoolState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ElasticPoolState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ElasticPoolState left, Azure.ResourceManager.Sql.Models.ElasticPoolState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ElasticPoolUpdate
    {
        public ElasticPoolUpdate() { }
        public Azure.ResourceManager.Sql.Models.ElasticPoolLicenseType? LicenseType { get { throw null; } set { } }
        public long? MaxSizeBytes { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ElasticPoolPerDatabaseSettings PerDatabaseSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class EncryptionProtector : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public EncryptionProtector() { }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } }
        public string ServerKeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ServerKeyType? ServerKeyType { get { throw null; } set { } }
        public string Subregion { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public string Uri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionProtectorName : System.IEquatable<Azure.ResourceManager.Sql.Models.EncryptionProtectorName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionProtectorName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.EncryptionProtectorName Current { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.EncryptionProtectorName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.EncryptionProtectorName left, Azure.ResourceManager.Sql.Models.EncryptionProtectorName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.EncryptionProtectorName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.EncryptionProtectorName left, Azure.ResourceManager.Sql.Models.EncryptionProtectorName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Enum65 : System.IEquatable<Azure.ResourceManager.Sql.Models.Enum65>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Enum65(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.Enum65 All { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.Enum65 Error { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.Enum65 Success { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.Enum65 Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.Enum65 other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.Enum65 left, Azure.ResourceManager.Sql.Models.Enum65 right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.Enum65 (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.Enum65 left, Azure.ResourceManager.Sql.Models.Enum65 right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportRequest
    {
        public ExportRequest(Azure.ResourceManager.Sql.Models.StorageKeyType storageKeyType, string storageKey, string storageUri, string administratorLogin, string administratorLoginPassword) { }
        public string AdministratorLogin { get { throw null; } }
        public string AdministratorLoginPassword { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.AuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string StorageKey { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.StorageKeyType StorageKeyType { get { throw null; } }
        public string StorageUri { get { throw null; } }
    }
    public partial class ExtendedDatabaseBlobAuditingPolicy : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ExtendedDatabaseBlobAuditingPolicy() { }
        public System.Collections.Generic.IList<string> AuditActionsAndGroups { get { throw null; } }
        public bool? IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public bool? IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public string PredicateExpression { get { throw null; } set { } }
        public int? QueueDelayMs { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.BlobAuditingPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public System.Guid? StorageAccountSubscriptionId { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ExtendedServerBlobAuditingPolicy : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ExtendedServerBlobAuditingPolicy() { }
        public System.Collections.Generic.IList<string> AuditActionsAndGroups { get { throw null; } }
        public bool? IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public bool? IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public string PredicateExpression { get { throw null; } set { } }
        public int? QueueDelayMs { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.BlobAuditingPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public System.Guid? StorageAccountSubscriptionId { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtensionName : System.IEquatable<Azure.ResourceManager.Sql.Models.ExtensionName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtensionName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ExtensionName Import { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ExtensionName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ExtensionName left, Azure.ResourceManager.Sql.Models.ExtensionName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ExtensionName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ExtensionName left, Azure.ResourceManager.Sql.Models.ExtensionName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FailoverGroup : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public FailoverGroup() { }
        public System.Collections.Generic.IList<string> Databases { get { throw null; } }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.PartnerInfo> PartnerServers { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.FailoverGroupReadOnlyEndpoint ReadOnlyEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.FailoverGroupReadWriteEndpoint ReadWriteEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.FailoverGroupReplicationRole? ReplicationRole { get { throw null; } }
        public string ReplicationState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class FailoverGroupReadOnlyEndpoint
    {
        public FailoverGroupReadOnlyEndpoint() { }
        public Azure.ResourceManager.Sql.Models.ReadOnlyEndpointFailoverPolicy? FailoverPolicy { get { throw null; } set { } }
    }
    public partial class FailoverGroupReadWriteEndpoint
    {
        public FailoverGroupReadWriteEndpoint(Azure.ResourceManager.Sql.Models.ReadWriteEndpointFailoverPolicy failoverPolicy) { }
        public Azure.ResourceManager.Sql.Models.ReadWriteEndpointFailoverPolicy FailoverPolicy { get { throw null; } set { } }
        public int? FailoverWithDataLossGracePeriodMinutes { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FailoverGroupReplicationRole : System.IEquatable<Azure.ResourceManager.Sql.Models.FailoverGroupReplicationRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FailoverGroupReplicationRole(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.FailoverGroupReplicationRole Primary { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.FailoverGroupReplicationRole Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.FailoverGroupReplicationRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.FailoverGroupReplicationRole left, Azure.ResourceManager.Sql.Models.FailoverGroupReplicationRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.FailoverGroupReplicationRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.FailoverGroupReplicationRole left, Azure.ResourceManager.Sql.Models.FailoverGroupReplicationRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FailoverGroupUpdate
    {
        public FailoverGroupUpdate() { }
        public System.Collections.Generic.IList<string> Databases { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.FailoverGroupReadOnlyEndpoint ReadOnlyEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.FailoverGroupReadWriteEndpoint ReadWriteEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class FirewallRule : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public FirewallRule() { }
        public string EndIpAddress { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } }
        public string StartIpAddress { get { throw null; } set { } }
    }
    public partial class GeoBackupPolicy : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public GeoBackupPolicy(Azure.ResourceManager.Sql.Models.GeoBackupPolicyState state) { }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.GeoBackupPolicyState State { get { throw null; } set { } }
        public string StorageType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoBackupPolicyName : System.IEquatable<Azure.ResourceManager.Sql.Models.GeoBackupPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeoBackupPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.GeoBackupPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName left, Azure.ResourceManager.Sql.Models.GeoBackupPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.GeoBackupPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName left, Azure.ResourceManager.Sql.Models.GeoBackupPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum GeoBackupPolicyState
    {
        Disabled = 0,
        Enabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityType : System.IEquatable<Azure.ResourceManager.Sql.Models.IdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.IdentityType SystemAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.IdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.IdentityType left, Azure.ResourceManager.Sql.Models.IdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.IdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.IdentityType left, Azure.ResourceManager.Sql.Models.IdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImportExportResponse : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ImportExportResponse() { }
        public string BlobUri { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string LastModifiedTime { get { throw null; } }
        public string QueuedTime { get { throw null; } }
        public System.Guid? RequestId { get { throw null; } }
        public string RequestType { get { throw null; } }
        public string ServerName { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ImportExtensionProperties : Azure.ResourceManager.Sql.Models.ExportRequest
    {
        public ImportExtensionProperties(Azure.ResourceManager.Sql.Models.StorageKeyType storageKeyType, string storageKey, string storageUri, string administratorLogin, string administratorLoginPassword) : base (default(Azure.ResourceManager.Sql.Models.StorageKeyType), default(string), default(string), default(string), default(string)) { }
        public string OperationMode { get { throw null; } }
    }
    public partial class ImportExtensionRequest
    {
        public ImportExtensionRequest() { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.AuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string OperationMode { get { throw null; } set { } }
        public string StorageKey { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.StorageKeyType? StorageKeyType { get { throw null; } set { } }
        public string StorageUri { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    public partial class ImportRequest : Azure.ResourceManager.Sql.Models.ExportRequest
    {
        public ImportRequest(Azure.ResourceManager.Sql.Models.StorageKeyType storageKeyType, string storageKey, string storageUri, string administratorLogin, string administratorLoginPassword, string databaseName, Azure.ResourceManager.Sql.Models.DatabaseEdition edition, Azure.ResourceManager.Sql.Models.ServiceObjectiveName serviceObjectiveName, string maxSizeBytes) : base (default(Azure.ResourceManager.Sql.Models.StorageKeyType), default(string), default(string), default(string), default(string)) { }
        public string DatabaseName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.DatabaseEdition Edition { get { throw null; } }
        public string MaxSizeBytes { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ServiceObjectiveName ServiceObjectiveName { get { throw null; } }
    }
    public partial class InstanceFailoverGroup : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public InstanceFailoverGroup() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.ManagedInstancePairInfo> ManagedInstancePairs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.PartnerRegionInfo> PartnerRegions { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.InstanceFailoverGroupReadOnlyEndpoint ReadOnlyEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.InstanceFailoverGroupReadWriteEndpoint ReadWriteEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.InstanceFailoverGroupReplicationRole? ReplicationRole { get { throw null; } }
        public string ReplicationState { get { throw null; } }
    }
    public partial class InstanceFailoverGroupReadOnlyEndpoint
    {
        public InstanceFailoverGroupReadOnlyEndpoint() { }
        public Azure.ResourceManager.Sql.Models.ReadOnlyEndpointFailoverPolicy? FailoverPolicy { get { throw null; } set { } }
    }
    public partial class InstanceFailoverGroupReadWriteEndpoint
    {
        public InstanceFailoverGroupReadWriteEndpoint(Azure.ResourceManager.Sql.Models.ReadWriteEndpointFailoverPolicy failoverPolicy) { }
        public Azure.ResourceManager.Sql.Models.ReadWriteEndpointFailoverPolicy FailoverPolicy { get { throw null; } set { } }
        public int? FailoverWithDataLossGracePeriodMinutes { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstanceFailoverGroupReplicationRole : System.IEquatable<Azure.ResourceManager.Sql.Models.InstanceFailoverGroupReplicationRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstanceFailoverGroupReplicationRole(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.InstanceFailoverGroupReplicationRole Primary { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.InstanceFailoverGroupReplicationRole Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.InstanceFailoverGroupReplicationRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.InstanceFailoverGroupReplicationRole left, Azure.ResourceManager.Sql.Models.InstanceFailoverGroupReplicationRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.InstanceFailoverGroupReplicationRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.InstanceFailoverGroupReplicationRole left, Azure.ResourceManager.Sql.Models.InstanceFailoverGroupReplicationRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InstancePool : Azure.ResourceManager.Sql.Models.TrackedResource
    {
        public InstancePool(string location) : base (default(string)) { }
        public Azure.ResourceManager.Sql.Models.InstancePoolLicenseType? LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.Sku Sku { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public int? VCores { get { throw null; } set { } }
    }
    public partial class InstancePoolEditionCapability
    {
        internal InstancePoolEditionCapability() { }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.InstancePoolFamilyCapability> SupportedFamilies { get { throw null; } }
    }
    public partial class InstancePoolFamilyCapability
    {
        internal InstancePoolFamilyCapability() { }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.LicenseTypeCapability> SupportedLicenseTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.InstancePoolVcoresCapability> SupportedVcoresValues { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstancePoolLicenseType : System.IEquatable<Azure.ResourceManager.Sql.Models.InstancePoolLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstancePoolLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.InstancePoolLicenseType BasePrice { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.InstancePoolLicenseType LicenseIncluded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.InstancePoolLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.InstancePoolLicenseType left, Azure.ResourceManager.Sql.Models.InstancePoolLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.InstancePoolLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.InstancePoolLicenseType left, Azure.ResourceManager.Sql.Models.InstancePoolLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InstancePoolUpdate
    {
        public InstancePoolUpdate() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class InstancePoolVcoresCapability
    {
        internal InstancePoolVcoresCapability() { }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.MaxSizeCapability StorageLimit { get { throw null; } }
        public int? Value { get { throw null; } }
    }
    public partial class Job : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public Job() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobSchedule Schedule { get { throw null; } set { } }
        public int? Version { get { throw null; } }
    }
    public partial class JobAgent : Azure.ResourceManager.Sql.Models.TrackedResource
    {
        public JobAgent(string location) : base (default(string)) { }
        public string DatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobAgentState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobAgentState : System.IEquatable<Azure.ResourceManager.Sql.Models.JobAgentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobAgentState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.JobAgentState Creating { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobAgentState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobAgentState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobAgentState Ready { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobAgentState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.JobAgentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.JobAgentState left, Azure.ResourceManager.Sql.Models.JobAgentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.JobAgentState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.JobAgentState left, Azure.ResourceManager.Sql.Models.JobAgentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobAgentUpdate
    {
        public JobAgentUpdate() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class JobCredential : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public JobCredential() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class JobExecution : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public JobExecution() { }
        public System.DateTimeOffset? CreateTime { get { throw null; } }
        public int? CurrentAttempts { get { throw null; } set { } }
        public System.DateTimeOffset? CurrentAttemptStartTime { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public System.Guid? JobExecutionId { get { throw null; } }
        public int? JobVersion { get { throw null; } }
        public string LastMessage { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.JobExecutionLifecycle? Lifecycle { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public int? StepId { get { throw null; } }
        public string StepName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.JobExecutionTarget Target { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobExecutionLifecycle : System.IEquatable<Azure.ResourceManager.Sql.Models.JobExecutionLifecycle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobExecutionLifecycle(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.JobExecutionLifecycle Canceled { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobExecutionLifecycle Created { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobExecutionLifecycle Failed { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobExecutionLifecycle InProgress { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobExecutionLifecycle Skipped { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobExecutionLifecycle Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobExecutionLifecycle SucceededWithSkipped { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobExecutionLifecycle TimedOut { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobExecutionLifecycle WaitingForChildJobExecutions { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobExecutionLifecycle WaitingForRetry { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.JobExecutionLifecycle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.JobExecutionLifecycle left, Azure.ResourceManager.Sql.Models.JobExecutionLifecycle right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.JobExecutionLifecycle (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.JobExecutionLifecycle left, Azure.ResourceManager.Sql.Models.JobExecutionLifecycle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobExecutionTarget
    {
        internal JobExecutionTarget() { }
        public string DatabaseName { get { throw null; } }
        public string ServerName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.JobTargetType? Type { get { throw null; } }
    }
    public partial class JobSchedule
    {
        public JobSchedule() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? EndTime { get { throw null; } set { } }
        public string Interval { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobScheduleType? Type { get { throw null; } set { } }
    }
    public enum JobScheduleType
    {
        Once = 0,
        Recurring = 1,
    }
    public partial class JobStep : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public JobStep() { }
        public Azure.ResourceManager.Sql.Models.JobStepAction Action { get { throw null; } set { } }
        public string Credential { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobStepExecutionOptions ExecutionOptions { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobStepOutput Output { get { throw null; } set { } }
        public int? StepId { get { throw null; } set { } }
        public string TargetGroup { get { throw null; } set { } }
    }
    public partial class JobStepAction
    {
        public JobStepAction(string value) { }
        public Azure.ResourceManager.Sql.Models.JobStepActionSource? Source { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobStepActionType? Type { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStepActionSource : System.IEquatable<Azure.ResourceManager.Sql.Models.JobStepActionSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStepActionSource(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.JobStepActionSource Inline { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.JobStepActionSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.JobStepActionSource left, Azure.ResourceManager.Sql.Models.JobStepActionSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.JobStepActionSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.JobStepActionSource left, Azure.ResourceManager.Sql.Models.JobStepActionSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStepActionType : System.IEquatable<Azure.ResourceManager.Sql.Models.JobStepActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStepActionType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.JobStepActionType TSql { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.JobStepActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.JobStepActionType left, Azure.ResourceManager.Sql.Models.JobStepActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.JobStepActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.JobStepActionType left, Azure.ResourceManager.Sql.Models.JobStepActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobStepExecutionOptions
    {
        public JobStepExecutionOptions() { }
        public int? InitialRetryIntervalSeconds { get { throw null; } set { } }
        public int? MaximumRetryIntervalSeconds { get { throw null; } set { } }
        public int? RetryAttempts { get { throw null; } set { } }
        public float? RetryIntervalBackoffMultiplier { get { throw null; } set { } }
        public int? TimeoutSeconds { get { throw null; } set { } }
    }
    public partial class JobStepOutput
    {
        public JobStepOutput(string serverName, string databaseName, string tableName, string credential) { }
        public string Credential { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string SchemaName { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public System.Guid? SubscriptionId { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobStepOutputType? Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStepOutputType : System.IEquatable<Azure.ResourceManager.Sql.Models.JobStepOutputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStepOutputType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.JobStepOutputType SqlDatabase { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.JobStepOutputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.JobStepOutputType left, Azure.ResourceManager.Sql.Models.JobStepOutputType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.JobStepOutputType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.JobStepOutputType left, Azure.ResourceManager.Sql.Models.JobStepOutputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobTarget
    {
        public JobTarget(Azure.ResourceManager.Sql.Models.JobTargetType type) { }
        public string DatabaseName { get { throw null; } set { } }
        public string ElasticPoolName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobTargetGroupMembershipType? MembershipType { get { throw null; } set { } }
        public string RefreshCredential { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public string ShardMapName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobTargetType Type { get { throw null; } set { } }
    }
    public partial class JobTargetGroup : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public JobTargetGroup() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.JobTarget> Members { get { throw null; } }
    }
    public enum JobTargetGroupMembershipType
    {
        Include = 0,
        Exclude = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobTargetType : System.IEquatable<Azure.ResourceManager.Sql.Models.JobTargetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobTargetType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.JobTargetType SqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobTargetType SqlElasticPool { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobTargetType SqlServer { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobTargetType SqlShardMap { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.JobTargetType TargetGroup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.JobTargetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.JobTargetType left, Azure.ResourceManager.Sql.Models.JobTargetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.JobTargetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.JobTargetType left, Azure.ResourceManager.Sql.Models.JobTargetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobVersion : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public JobVersion() { }
    }
    public partial class LicenseTypeCapability
    {
        internal LicenseTypeCapability() { }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
    }
    public partial class LocationCapabilities
    {
        internal LocationCapabilities() { }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ManagedInstanceVersionCapability> SupportedManagedInstanceVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ServerVersionCapability> SupportedServerVersions { get { throw null; } }
    }
    public partial class LogSizeCapability
    {
        internal LogSizeCapability() { }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.LogSizeUnit? Unit { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogSizeUnit : System.IEquatable<Azure.ResourceManager.Sql.Models.LogSizeUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogSizeUnit(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.LogSizeUnit Gigabytes { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.LogSizeUnit Megabytes { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.LogSizeUnit Percent { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.LogSizeUnit Petabytes { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.LogSizeUnit Terabytes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.LogSizeUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.LogSizeUnit left, Azure.ResourceManager.Sql.Models.LogSizeUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.LogSizeUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.LogSizeUnit left, Azure.ResourceManager.Sql.Models.LogSizeUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LongTermRetentionBackup : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public LongTermRetentionBackup() { }
        public System.DateTimeOffset? BackupExpirationTime { get { throw null; } }
        public System.DateTimeOffset? BackupTime { get { throw null; } }
        public System.DateTimeOffset? DatabaseDeletionTime { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? ServerCreateTime { get { throw null; } }
        public string ServerName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LongTermRetentionDatabaseState : System.IEquatable<Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LongTermRetentionDatabaseState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState All { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState Live { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState left, Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState left, Azure.ResourceManager.Sql.Models.LongTermRetentionDatabaseState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LongTermRetentionPolicyName : System.IEquatable<Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LongTermRetentionPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName left, Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName left, Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedBackupShortTermRetentionPolicy : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ManagedBackupShortTermRetentionPolicy() { }
        public int? RetentionDays { get { throw null; } set { } }
    }
    public partial class ManagedDatabase : Azure.ResourceManager.Sql.Models.TrackedResource
    {
        public ManagedDatabase(string location) : base (default(string)) { }
        public bool? AutoCompleteRestore { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CatalogCollationType? CatalogCollation { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public string DefaultSecondaryLocation { get { throw null; } }
        public System.DateTimeOffset? EarliestRestorePoint { get { throw null; } }
        public string FailoverGroupId { get { throw null; } }
        public string LastBackupName { get { throw null; } set { } }
        public string LongTermRetentionBackupResourceId { get { throw null; } set { } }
        public string RecoverableDatabaseId { get { throw null; } set { } }
        public string RestorableDroppedDatabaseId { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus? Status { get { throw null; } }
        public string StorageContainerSasToken { get { throw null; } set { } }
        public string StorageContainerUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedDatabaseCreateMode : System.IEquatable<Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedDatabaseCreateMode(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode Recovery { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode RestoreExternalBackup { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode RestoreLongTermRetentionBackup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode left, Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode left, Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedDatabaseRestoreDetailsResult : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ManagedDatabaseRestoreDetailsResult() { }
        public string BlockReason { get { throw null; } }
        public string CurrentRestoringFileName { get { throw null; } }
        public string LastRestoredFileName { get { throw null; } }
        public System.DateTimeOffset? LastRestoredFileTime { get { throw null; } }
        public string LastUploadedFileName { get { throw null; } }
        public System.DateTimeOffset? LastUploadedFileTime { get { throw null; } }
        public long? NumberOfFilesDetected { get { throw null; } }
        public double? PercentCompleted { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> UnrestorableFiles { get { throw null; } }
    }
    public partial class ManagedDatabaseSecurityAlertPolicy : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ManagedDatabaseSecurityAlertPolicy() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public bool? EmailAccountAdmins { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedDatabaseStatus : System.IEquatable<Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedDatabaseStatus(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus Inaccessible { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus Online { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus Restoring { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus Shutdown { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus left, Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus left, Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedDatabaseUpdate
    {
        public ManagedDatabaseUpdate() { }
        public bool? AutoCompleteRestore { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CatalogCollationType? CatalogCollation { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public string DefaultSecondaryLocation { get { throw null; } }
        public System.DateTimeOffset? EarliestRestorePoint { get { throw null; } }
        public string FailoverGroupId { get { throw null; } }
        public string LastBackupName { get { throw null; } set { } }
        public string LongTermRetentionBackupResourceId { get { throw null; } set { } }
        public string RecoverableDatabaseId { get { throw null; } set { } }
        public string RestorableDroppedDatabaseId { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus? Status { get { throw null; } }
        public string StorageContainerSasToken { get { throw null; } set { } }
        public string StorageContainerUri { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ManagedInstance : Azure.ResourceManager.Sql.Models.TrackedResource
    {
        public ManagedInstance(string location) : base (default(string)) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        public string DnsZone { get { throw null; } }
        public string DnsZonePartner { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ResourceIdentity Identity { get { throw null; } set { } }
        public string InstancePoolId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceLicenseType? LicenseType { get { throw null; } set { } }
        public string MaintenanceConfigurationId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedServerCreateMode? ManagedInstanceCreateMode { get { throw null; } set { } }
        public string MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceProxyOverride? ProxyOverride { get { throw null; } set { } }
        public bool? PublicDataEndpointEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.Sku Sku { get { throw null; } set { } }
        public string SourceManagedInstanceId { get { throw null; } set { } }
        public string State { get { throw null; } }
        public int? StorageSizeInGB { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public string TimezoneId { get { throw null; } set { } }
        public int? VCores { get { throw null; } set { } }
    }
    public partial class ManagedInstanceAdministrator : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ManagedInstanceAdministrator() { }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceAdministratorType? AdministratorType { get { throw null; } set { } }
        public string Login { get { throw null; } set { } }
        public System.Guid? Sid { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedInstanceAdministratorType : System.IEquatable<Azure.ResourceManager.Sql.Models.ManagedInstanceAdministratorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedInstanceAdministratorType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ManagedInstanceAdministratorType ActiveDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ManagedInstanceAdministratorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ManagedInstanceAdministratorType left, Azure.ResourceManager.Sql.Models.ManagedInstanceAdministratorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ManagedInstanceAdministratorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ManagedInstanceAdministratorType left, Azure.ResourceManager.Sql.Models.ManagedInstanceAdministratorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedInstanceEditionCapability
    {
        internal ManagedInstanceEditionCapability() { }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ManagedInstanceFamilyCapability> SupportedFamilies { get { throw null; } }
    }
    public partial class ManagedInstanceEncryptionProtector : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ManagedInstanceEncryptionProtector() { }
        public string Kind { get { throw null; } }
        public string ServerKeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ServerKeyType? ServerKeyType { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } }
        public string Uri { get { throw null; } }
    }
    public partial class ManagedInstanceFamilyCapability
    {
        internal ManagedInstanceFamilyCapability() { }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        public string Sku { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.LicenseTypeCapability> SupportedLicenseTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ManagedInstanceVcoresCapability> SupportedVcoresValues { get { throw null; } }
    }
    public partial class ManagedInstanceKey : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ManagedInstanceKey() { }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ServerKeyType? ServerKeyType { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } }
        public string Uri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedInstanceLicenseType : System.IEquatable<Azure.ResourceManager.Sql.Models.ManagedInstanceLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedInstanceLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ManagedInstanceLicenseType BasePrice { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedInstanceLicenseType LicenseIncluded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ManagedInstanceLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ManagedInstanceLicenseType left, Azure.ResourceManager.Sql.Models.ManagedInstanceLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ManagedInstanceLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ManagedInstanceLicenseType left, Azure.ResourceManager.Sql.Models.ManagedInstanceLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedInstanceLongTermRetentionBackup : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ManagedInstanceLongTermRetentionBackup() { }
        public System.DateTimeOffset? BackupExpirationTime { get { throw null; } }
        public System.DateTimeOffset? BackupTime { get { throw null; } }
        public System.DateTimeOffset? DatabaseDeletionTime { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? ManagedInstanceCreateTime { get { throw null; } }
        public string ManagedInstanceName { get { throw null; } }
    }
    public partial class ManagedInstanceLongTermRetentionPolicy : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ManagedInstanceLongTermRetentionPolicy() { }
        public string MonthlyRetention { get { throw null; } set { } }
        public string WeeklyRetention { get { throw null; } set { } }
        public int? WeekOfYear { get { throw null; } set { } }
        public string YearlyRetention { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedInstanceLongTermRetentionPolicyName : System.IEquatable<Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedInstanceLongTermRetentionPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName left, Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName left, Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedInstanceOperation : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ManagedInstanceOperation() { }
        public string Description { get { throw null; } }
        public int? ErrorCode { get { throw null; } }
        public string ErrorDescription { get { throw null; } }
        public int? ErrorSeverity { get { throw null; } }
        public System.DateTimeOffset? EstimatedCompletionTime { get { throw null; } }
        public bool? IsCancellable { get { throw null; } }
        public bool? IsUserError { get { throw null; } }
        public string ManagedInstanceName { get { throw null; } }
        public string Operation { get { throw null; } }
        public string OperationFriendlyName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceOperationParametersPair OperationParameters { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceOperationSteps OperationSteps { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ManagementOperationState? State { get { throw null; } }
    }
    public partial class ManagedInstanceOperationParametersPair
    {
        internal ManagedInstanceOperationParametersPair() { }
        public Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationParameters CurrentParameters { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationParameters RequestedParameters { get { throw null; } }
    }
    public partial class ManagedInstanceOperationSteps
    {
        internal ManagedInstanceOperationSteps() { }
        public int? CurrentStep { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationStep> StepsList { get { throw null; } }
        public string TotalSteps { get { throw null; } }
    }
    public partial class ManagedInstancePairInfo
    {
        public ManagedInstancePairInfo() { }
        public string PartnerManagedInstanceId { get { throw null; } set { } }
        public string PrimaryManagedInstanceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedInstancePropertiesProvisioningState : System.IEquatable<Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedInstancePropertiesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState left, Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState left, Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedInstanceProxyOverride : System.IEquatable<Azure.ResourceManager.Sql.Models.ManagedInstanceProxyOverride>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedInstanceProxyOverride(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ManagedInstanceProxyOverride Default { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedInstanceProxyOverride Proxy { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedInstanceProxyOverride Redirect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ManagedInstanceProxyOverride other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ManagedInstanceProxyOverride left, Azure.ResourceManager.Sql.Models.ManagedInstanceProxyOverride right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ManagedInstanceProxyOverride (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ManagedInstanceProxyOverride left, Azure.ResourceManager.Sql.Models.ManagedInstanceProxyOverride right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedInstanceUpdate
    {
        public ManagedInstanceUpdate() { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        public string DnsZone { get { throw null; } }
        public string DnsZonePartner { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public string InstancePoolId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceLicenseType? LicenseType { get { throw null; } set { } }
        public string MaintenanceConfigurationId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedServerCreateMode? ManagedInstanceCreateMode { get { throw null; } set { } }
        public string MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceProxyOverride? ProxyOverride { get { throw null; } set { } }
        public bool? PublicDataEndpointEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.Sku Sku { get { throw null; } set { } }
        public string SourceManagedInstanceId { get { throw null; } set { } }
        public string State { get { throw null; } }
        public int? StorageSizeInGB { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TimezoneId { get { throw null; } set { } }
        public int? VCores { get { throw null; } set { } }
    }
    public partial class ManagedInstanceVcoresCapability
    {
        internal ManagedInstanceVcoresCapability() { }
        public Azure.ResourceManager.Sql.Models.MaxSizeCapability IncludedMaxSize { get { throw null; } }
        public bool? InstancePoolSupported { get { throw null; } }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        public bool? StandaloneSupported { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.MaxSizeRangeCapability> SupportedStorageSizes { get { throw null; } }
        public int? Value { get { throw null; } }
    }
    public partial class ManagedInstanceVersionCapability
    {
        internal ManagedInstanceVersionCapability() { }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ManagedInstanceEditionCapability> SupportedEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.InstancePoolEditionCapability> SupportedInstancePoolEditions { get { throw null; } }
    }
    public partial class ManagedInstanceVulnerabilityAssessment : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ManagedInstanceVulnerabilityAssessment() { }
        public Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageContainerPath { get { throw null; } set { } }
        public string StorageContainerSasKey { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServerCreateMode : System.IEquatable<Azure.ResourceManager.Sql.Models.ManagedServerCreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServerCreateMode(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ManagedServerCreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagedServerCreateMode PointInTimeRestore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ManagedServerCreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ManagedServerCreateMode left, Azure.ResourceManager.Sql.Models.ManagedServerCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ManagedServerCreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ManagedServerCreateMode left, Azure.ResourceManager.Sql.Models.ManagedServerCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedServerSecurityAlertPolicy : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ManagedServerSecurityAlertPolicy() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public bool? EmailAccountAdmins { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedShortTermRetentionPolicyName : System.IEquatable<Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedShortTermRetentionPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName left, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName left, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagementOperationState : System.IEquatable<Azure.ResourceManager.Sql.Models.ManagementOperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagementOperationState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ManagementOperationState CancelInProgress { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagementOperationState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagementOperationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagementOperationState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagementOperationState Pending { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ManagementOperationState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ManagementOperationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ManagementOperationState left, Azure.ResourceManager.Sql.Models.ManagementOperationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ManagementOperationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ManagementOperationState left, Azure.ResourceManager.Sql.Models.ManagementOperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaxSizeCapability
    {
        internal MaxSizeCapability() { }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.MaxSizeUnit? Unit { get { throw null; } }
    }
    public partial class MaxSizeRangeCapability
    {
        internal MaxSizeRangeCapability() { }
        public Azure.ResourceManager.Sql.Models.LogSizeCapability LogSize { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.MaxSizeCapability MaxValue { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.MaxSizeCapability MinValue { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.MaxSizeCapability ScaleSize { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaxSizeUnit : System.IEquatable<Azure.ResourceManager.Sql.Models.MaxSizeUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaxSizeUnit(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.MaxSizeUnit Gigabytes { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.MaxSizeUnit Megabytes { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.MaxSizeUnit Petabytes { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.MaxSizeUnit Terabytes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.MaxSizeUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.MaxSizeUnit left, Azure.ResourceManager.Sql.Models.MaxSizeUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.MaxSizeUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.MaxSizeUnit left, Azure.ResourceManager.Sql.Models.MaxSizeUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Metric
    {
        internal Metric() { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.MetricValue> MetricValues { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.MetricName Name { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public string TimeGrain { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.UnitType? Unit { get { throw null; } }
    }
    public partial class MetricAvailability
    {
        internal MetricAvailability() { }
        public string Retention { get { throw null; } }
        public string TimeGrain { get { throw null; } }
    }
    public partial class MetricDefinition
    {
        internal MetricDefinition() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.MetricAvailability> MetricAvailabilities { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.MetricName Name { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.PrimaryAggregationType? PrimaryAggregationType { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.UnitDefinitionType? Unit { get { throw null; } }
    }
    public partial class MetricName
    {
        internal MetricName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class MetricValue
    {
        internal MetricValue() { }
        public double? Average { get { throw null; } }
        public int? Count { get { throw null; } }
        public double? Maximum { get { throw null; } }
        public double? Minimum { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public double? Total { get { throw null; } }
    }
    public partial class MinCapacityCapability
    {
        internal MinCapacityCapability() { }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public double? Value { get { throw null; } }
    }
    public partial class Name
    {
        internal Name() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class Operation
    {
        internal Operation() { }
        public Azure.ResourceManager.Sql.Models.OperationDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.OperationOrigin? Origin { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Properties { get { throw null; } }
    }
    public partial class OperationDisplay
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class OperationImpact
    {
        internal OperationImpact() { }
        public double? ChangeValueAbsolute { get { throw null; } }
        public double? ChangeValueRelative { get { throw null; } }
        public string Name { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationOrigin : System.IEquatable<Azure.ResourceManager.Sql.Models.OperationOrigin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationOrigin(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.OperationOrigin System { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.OperationOrigin User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.OperationOrigin other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.OperationOrigin left, Azure.ResourceManager.Sql.Models.OperationOrigin right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.OperationOrigin (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.OperationOrigin left, Azure.ResourceManager.Sql.Models.OperationOrigin right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartnerInfo
    {
        public PartnerInfo(string id) { }
        public string Id { get { throw null; } set { } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.FailoverGroupReplicationRole? ReplicationRole { get { throw null; } }
    }
    public partial class PartnerRegionInfo
    {
        public PartnerRegionInfo() { }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.InstanceFailoverGroupReplicationRole? ReplicationRole { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PauseDelayTimeUnit : System.IEquatable<Azure.ResourceManager.Sql.Models.PauseDelayTimeUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PauseDelayTimeUnit(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.PauseDelayTimeUnit Minutes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.PauseDelayTimeUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.PauseDelayTimeUnit left, Azure.ResourceManager.Sql.Models.PauseDelayTimeUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.PauseDelayTimeUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.PauseDelayTimeUnit left, Azure.ResourceManager.Sql.Models.PauseDelayTimeUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PerformanceLevelCapability
    {
        internal PerformanceLevelCapability() { }
        public Azure.ResourceManager.Sql.Models.PerformanceLevelUnit? Unit { get { throw null; } }
        public double? Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PerformanceLevelUnit : System.IEquatable<Azure.ResourceManager.Sql.Models.PerformanceLevelUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PerformanceLevelUnit(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.PerformanceLevelUnit DTU { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.PerformanceLevelUnit VCores { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.PerformanceLevelUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.PerformanceLevelUnit left, Azure.ResourceManager.Sql.Models.PerformanceLevelUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.PerformanceLevelUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.PerformanceLevelUnit left, Azure.ResourceManager.Sql.Models.PerformanceLevelUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrimaryAggregationType : System.IEquatable<Azure.ResourceManager.Sql.Models.PrimaryAggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrimaryAggregationType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.PrimaryAggregationType Average { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.PrimaryAggregationType Count { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.PrimaryAggregationType Maximum { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.PrimaryAggregationType Minimum { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.PrimaryAggregationType None { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.PrimaryAggregationType Total { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.PrimaryAggregationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.PrimaryAggregationType left, Azure.ResourceManager.Sql.Models.PrimaryAggregationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.PrimaryAggregationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.PrimaryAggregationType left, Azure.ResourceManager.Sql.Models.PrimaryAggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public PrivateEndpointConnection() { }
        public Azure.ResourceManager.Sql.Models.PrivateEndpointProperty PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionProperties
    {
        internal PrivateEndpointConnectionProperties() { }
        public Azure.ResourceManager.Sql.Models.PrivateEndpointProperty PrivateEndpoint { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStatePropertyAutoGenerated PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateEndpointProperty
    {
        public PrivateEndpointProperty() { }
        public string Id { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointProvisioningState : System.IEquatable<Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState Approving { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState Dropping { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState Rejecting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState left, Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState left, Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public PrivateLinkResource() { }
        public Azure.ResourceManager.Sql.Models.PrivateLinkResourceProperties Properties { get { throw null; } }
    }
    public partial class PrivateLinkResourceProperties
    {
        internal PrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceConnectionStateActionsRequire : System.IEquatable<Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateActionsRequire>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceConnectionStateActionsRequire(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateActionsRequire None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateActionsRequire other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateActionsRequire left, Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateActionsRequire right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateActionsRequire (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateActionsRequire left, Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateActionsRequire right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkServiceConnectionStateProperty
    {
        public PrivateLinkServiceConnectionStateProperty(string status, string description) { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class PrivateLinkServiceConnectionStatePropertyAutoGenerated
    {
        internal PrivateLinkServiceConnectionStatePropertyAutoGenerated() { }
        public Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateActionsRequire? ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateStatus Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceConnectionStateStatus : System.IEquatable<Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceConnectionStateStatus(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateStatus left, Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateStatus left, Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Sql.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ProvisioningState left, Azure.ResourceManager.Sql.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ProvisioningState left, Azure.ResourceManager.Sql.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProxyResource : Azure.ResourceManager.Sql.Models.Resource
    {
        public ProxyResource() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReadOnlyEndpointFailoverPolicy : System.IEquatable<Azure.ResourceManager.Sql.Models.ReadOnlyEndpointFailoverPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReadOnlyEndpointFailoverPolicy(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ReadOnlyEndpointFailoverPolicy Disabled { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ReadOnlyEndpointFailoverPolicy Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ReadOnlyEndpointFailoverPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ReadOnlyEndpointFailoverPolicy left, Azure.ResourceManager.Sql.Models.ReadOnlyEndpointFailoverPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ReadOnlyEndpointFailoverPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ReadOnlyEndpointFailoverPolicy left, Azure.ResourceManager.Sql.Models.ReadOnlyEndpointFailoverPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReadScaleCapability
    {
        internal ReadScaleCapability() { }
        public int? MaxNumberOfReplicas { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReadWriteEndpointFailoverPolicy : System.IEquatable<Azure.ResourceManager.Sql.Models.ReadWriteEndpointFailoverPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReadWriteEndpointFailoverPolicy(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ReadWriteEndpointFailoverPolicy Automatic { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ReadWriteEndpointFailoverPolicy Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ReadWriteEndpointFailoverPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ReadWriteEndpointFailoverPolicy left, Azure.ResourceManager.Sql.Models.ReadWriteEndpointFailoverPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ReadWriteEndpointFailoverPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ReadWriteEndpointFailoverPolicy left, Azure.ResourceManager.Sql.Models.ReadWriteEndpointFailoverPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendedElasticPool : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public RecommendedElasticPool() { }
        public double? DatabaseDtuMax { get { throw null; } set { } }
        public double? DatabaseDtuMin { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ElasticPoolEdition? DatabaseEdition { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.TrackedResource> Databases { get { throw null; } }
        public double? Dtu { get { throw null; } set { } }
        public double? MaxObservedDtu { get { throw null; } }
        public double? MaxObservedStorageMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.RecommendedElasticPoolMetric> Metrics { get { throw null; } }
        public System.DateTimeOffset? ObservationPeriodEnd { get { throw null; } }
        public System.DateTimeOffset? ObservationPeriodStart { get { throw null; } }
        public double? StorageMB { get { throw null; } set { } }
    }
    public partial class RecommendedElasticPoolMetric
    {
        internal RecommendedElasticPoolMetric() { }
        public System.DateTimeOffset? DateTime { get { throw null; } }
        public double? Dtu { get { throw null; } }
        public double? SizeGB { get { throw null; } }
    }
    public partial class RecommendedIndex : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public RecommendedIndex() { }
        public Azure.ResourceManager.Sql.Models.RecommendedIndexAction? Action { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Columns { get { throw null; } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.OperationImpact> EstimatedImpact { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IncludedColumns { get { throw null; } }
        public string IndexScript { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.RecommendedIndexType? IndexType { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.OperationImpact> ReportedImpact { get { throw null; } }
        public string Schema { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.RecommendedIndexState? State { get { throw null; } }
        public string Table { get { throw null; } }
    }
    public enum RecommendedIndexAction
    {
        Create = 0,
        Drop = 1,
        Rebuild = 2,
    }
    public enum RecommendedIndexState
    {
        Active = 0,
        Pending = 1,
        Executing = 2,
        Verifying = 3,
        PendingRevert = 4,
        Reverting = 5,
        Reverted = 6,
        Ignored = 7,
        Expired = 8,
        Blocked = 9,
        Success = 10,
    }
    public enum RecommendedIndexType
    {
        Clustered = 0,
        Nonclustered = 1,
        Columnstore = 2,
        ClusteredColumnstore = 3,
    }
    public partial class RecoverableDatabase : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public RecoverableDatabase() { }
        public string Edition { get { throw null; } }
        public string ElasticPoolName { get { throw null; } }
        public System.DateTimeOffset? LastAvailableBackupDate { get { throw null; } }
        public string ServiceLevelObjective { get { throw null; } }
    }
    public partial class RecoverableManagedDatabase : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public RecoverableManagedDatabase() { }
        public string LastAvailableBackupDate { get { throw null; } }
    }
    public partial class ReplicationLink : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ReplicationLink() { }
        public bool? IsTerminationAllowed { get { throw null; } }
        public string Location { get { throw null; } }
        public string PartnerDatabase { get { throw null; } }
        public string PartnerLocation { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ReplicationRole? PartnerRole { get { throw null; } }
        public string PartnerServer { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public string ReplicationMode { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ReplicationState? ReplicationState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ReplicationRole? Role { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
    }
    public enum ReplicationRole
    {
        Primary = 0,
        Secondary = 1,
        NonReadableSecondary = 2,
        Source = 3,
        Copy = 4,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicationState : System.IEquatable<Azure.ResourceManager.Sql.Models.ReplicationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicationState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ReplicationState CatchUP { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ReplicationState Pending { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ReplicationState Seeding { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ReplicationState Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ReplicationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ReplicationState left, Azure.ResourceManager.Sql.Models.ReplicationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ReplicationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ReplicationState left, Azure.ResourceManager.Sql.Models.ReplicationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicaType : System.IEquatable<Azure.ResourceManager.Sql.Models.ReplicaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicaType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ReplicaType Primary { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ReplicaType ReadableSecondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ReplicaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ReplicaType left, Azure.ResourceManager.Sql.Models.ReplicaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ReplicaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ReplicaType left, Azure.ResourceManager.Sql.Models.ReplicaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Resource
    {
        public Resource() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ResourceIdentity
    {
        public ResourceIdentity() { }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.IdentityType? Type { get { throw null; } set { } }
    }
    public partial class ResourceMoveDefinition
    {
        public ResourceMoveDefinition(string id) { }
        public string Id { get { throw null; } }
    }
    public partial class RestorableDroppedDatabase : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public RestorableDroppedDatabase() { }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? DeletionDate { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreDate { get { throw null; } }
        public string Edition { get { throw null; } }
        public string ElasticPoolName { get { throw null; } }
        public string Location { get { throw null; } }
        public string MaxSizeBytes { get { throw null; } }
        public string ServiceLevelObjective { get { throw null; } }
    }
    public partial class RestorableDroppedManagedDatabase : Azure.ResourceManager.Sql.Models.TrackedResource
    {
        public RestorableDroppedManagedDatabase(string location) : base (default(string)) { }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? DeletionDate { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreDate { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestoreDetailsName : System.IEquatable<Azure.ResourceManager.Sql.Models.RestoreDetailsName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestoreDetailsName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.RestoreDetailsName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.RestoreDetailsName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.RestoreDetailsName left, Azure.ResourceManager.Sql.Models.RestoreDetailsName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.RestoreDetailsName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.RestoreDetailsName left, Azure.ResourceManager.Sql.Models.RestoreDetailsName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestorePoint : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public RestorePoint() { }
        public System.DateTimeOffset? EarliestRestoreDate { get { throw null; } }
        public string Location { get { throw null; } }
        public System.DateTimeOffset? RestorePointCreationDate { get { throw null; } }
        public string RestorePointLabel { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.RestorePointType? RestorePointType { get { throw null; } }
    }
    public enum RestorePointType
    {
        Continuous = 0,
        Discrete = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SampleName : System.IEquatable<Azure.ResourceManager.Sql.Models.SampleName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SampleName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.SampleName AdventureWorksLT { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SampleName WideWorldImportersFull { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SampleName WideWorldImportersStd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.SampleName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.SampleName left, Azure.ResourceManager.Sql.Models.SampleName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.SampleName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.SampleName left, Azure.ResourceManager.Sql.Models.SampleName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SecurityAlertPolicyEmailAccountAdmins
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAlertPolicyName : System.IEquatable<Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAlertPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName left, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName left, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAlertPolicyNameAutoGenerated : System.IEquatable<Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAlertPolicyNameAutoGenerated(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated left, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated left, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyNameAutoGenerated right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SecurityAlertPolicyState
    {
        New = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public enum SecurityAlertPolicyUseServerDefault
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class SensitivityLabel : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public SensitivityLabel() { }
        public string InformationType { get { throw null; } set { } }
        public string InformationTypeId { get { throw null; } set { } }
        public bool? IsDisabled { get { throw null; } }
        public string LabelId { get { throw null; } set { } }
        public string LabelName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SensitivityLabelRank? Rank { get { throw null; } set { } }
    }
    public enum SensitivityLabelRank
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4,
    }
    public enum SensitivityLabelSource
    {
        Current = 0,
        Recommended = 1,
    }
    public partial class Server : Azure.ResourceManager.Sql.Models.TrackedResource
    {
        public Server(string location) : base (default(string)) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public string MinimalTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ServerPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ServerPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string State { get { throw null; } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ServerAutomaticTuning : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ServerAutomaticTuning() { }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningServerMode? ActualState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningServerMode? DesiredState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Sql.Models.AutomaticTuningServerOptions> Options { get { throw null; } }
    }
    public partial class ServerAzureADAdministrator : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ServerAzureADAdministrator() { }
        public Azure.ResourceManager.Sql.Models.AdministratorType? AdministratorType { get { throw null; } set { } }
        public bool? AzureADOnlyAuthentication { get { throw null; } }
        public string Login { get { throw null; } set { } }
        public System.Guid? Sid { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class ServerAzureADOnlyAuthentication : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ServerAzureADOnlyAuthentication() { }
        public bool? AzureADOnlyAuthentication { get { throw null; } set { } }
    }
    public partial class ServerBlobAuditingPolicy : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ServerBlobAuditingPolicy() { }
        public System.Collections.Generic.IList<string> AuditActionsAndGroups { get { throw null; } }
        public bool? IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public bool? IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public int? QueueDelayMs { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.BlobAuditingPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public System.Guid? StorageAccountSubscriptionId { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ServerCommunicationLink : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ServerCommunicationLink() { }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } }
        public string PartnerServer { get { throw null; } set { } }
        public string State { get { throw null; } }
    }
    public partial class ServerConnectionPolicy : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ServerConnectionPolicy() { }
        public Azure.ResourceManager.Sql.Models.ServerConnectionType? ConnectionType { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } }
    }
    public enum ServerConnectionType
    {
        Default = 0,
        Proxy = 1,
        Redirect = 2,
    }
    public partial class ServerDnsAlias : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ServerDnsAlias() { }
        public string AzureDnsRecord { get { throw null; } }
    }
    public partial class ServerDnsAliasAcquisition
    {
        public ServerDnsAliasAcquisition() { }
        public string OldServerDnsAliasId { get { throw null; } set { } }
    }
    public partial class ServerKey : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ServerKey() { }
        public System.DateTimeOffset? CreationDate { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ServerKeyType? ServerKeyType { get { throw null; } set { } }
        public string Subregion { get { throw null; } }
        public string Thumbprint { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerKeyType : System.IEquatable<Azure.ResourceManager.Sql.Models.ServerKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ServerKeyType AzureKeyVault { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServerKeyType ServiceManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ServerKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ServerKeyType left, Azure.ResourceManager.Sql.Models.ServerKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ServerKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ServerKeyType left, Azure.ResourceManager.Sql.Models.ServerKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerPrivateEndpointConnection
    {
        internal ServerPrivateEndpointConnection() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Sql.Models.ServerPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ServerPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServerPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ServerPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ServerPublicNetworkAccess left, Azure.ResourceManager.Sql.Models.ServerPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ServerPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ServerPublicNetworkAccess left, Azure.ResourceManager.Sql.Models.ServerPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerSecurityAlertPolicy : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ServerSecurityAlertPolicy() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public bool? EmailAccountAdmins { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ServerUpdate
    {
        public ServerUpdate() { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public string MinimalTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ServerPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ServerPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string State { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ServerUsage
    {
        internal ServerUsage() { }
        public double? CurrentValue { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public double? Limit { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? NextResetTime { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class ServerVersionCapability
    {
        internal ServerVersionCapability() { }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.EditionCapability> SupportedEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ElasticPoolEditionCapability> SupportedElasticPoolEditions { get { throw null; } }
    }
    public partial class ServerVulnerabilityAssessment : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ServerVulnerabilityAssessment() { }
        public Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageContainerPath { get { throw null; } set { } }
        public string StorageContainerSasKey { get { throw null; } set { } }
    }
    public partial class ServiceObjective : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ServiceObjective() { }
        public string Description { get { throw null; } }
        public bool? Enabled { get { throw null; } }
        public bool? IsDefault { get { throw null; } }
        public bool? IsSystem { get { throw null; } }
        public string ServiceObjectiveName { get { throw null; } }
    }
    public partial class ServiceObjectiveCapability
    {
        internal ServiceObjectiveCapability() { }
        public string ComputeModel { get { throw null; } }
        public System.Guid? Id { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.MaxSizeCapability IncludedMaxSize { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.PerformanceLevelCapability PerformanceLevel { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.Sku Sku { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.AutoPauseDelayTimeRange SupportedAutoPauseDelay { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.LicenseTypeCapability> SupportedLicenseTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.MaxSizeRangeCapability> SupportedMaxSizes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.MinCapacityCapability> SupportedMinCapacities { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceObjectiveName : System.IEquatable<Azure.ResourceManager.Sql.Models.ServiceObjectiveName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceObjectiveName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName Basic { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DS100 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DS1000 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DS1200 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DS1500 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DS200 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DS2000 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DS300 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DS400 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DS500 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DS600 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW100 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW1000 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW10000C { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW1000C { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW1200 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW1500 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW15000C { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW1500C { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW200 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW2000 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW2000C { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW2500C { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW300 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW3000 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW30000C { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW3000C { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW400 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW500 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW5000C { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW600 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW6000 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW6000C { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName DW7500C { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName ElasticPool { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName Free { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName P1 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName P11 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName P15 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName P2 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName P3 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName P4 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName P6 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName PRS1 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName PRS2 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName PRS4 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName PRS6 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName S0 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName S1 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName S12 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName S2 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName S3 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName S4 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName S6 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName S7 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName S9 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName System { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName System0 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName System1 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName System2 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName System2L { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName System3 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName System3L { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName System4 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServiceObjectiveName System4L { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ServiceObjectiveName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ServiceObjectiveName left, Azure.ResourceManager.Sql.Models.ServiceObjectiveName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ServiceObjectiveName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ServiceObjectiveName left, Azure.ResourceManager.Sql.Models.ServiceObjectiveName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceTierAdvisor : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public ServiceTierAdvisor() { }
        public double? ActiveTimeRatio { get { throw null; } }
        public double? AvgDtu { get { throw null; } }
        public double? Confidence { get { throw null; } }
        public string CurrentServiceLevelObjective { get { throw null; } }
        public System.Guid? CurrentServiceLevelObjectiveId { get { throw null; } }
        public string DatabaseSizeBasedRecommendationServiceLevelObjective { get { throw null; } }
        public System.Guid? DatabaseSizeBasedRecommendationServiceLevelObjectiveId { get { throw null; } }
        public string DisasterPlanBasedRecommendationServiceLevelObjective { get { throw null; } }
        public System.Guid? DisasterPlanBasedRecommendationServiceLevelObjectiveId { get { throw null; } }
        public double? MaxDtu { get { throw null; } }
        public double? MaxSizeInGB { get { throw null; } }
        public double? MinDtu { get { throw null; } }
        public System.DateTimeOffset? ObservationPeriodEnd { get { throw null; } }
        public System.DateTimeOffset? ObservationPeriodStart { get { throw null; } }
        public string OverallRecommendationServiceLevelObjective { get { throw null; } }
        public System.Guid? OverallRecommendationServiceLevelObjectiveId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.SloUsageMetric> ServiceLevelObjectiveUsageMetrics { get { throw null; } }
        public string UsageBasedRecommendationServiceLevelObjective { get { throw null; } }
        public System.Guid? UsageBasedRecommendationServiceLevelObjectiveId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShortTermRetentionPolicyName : System.IEquatable<Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShortTermRetentionPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName left, Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName left, Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Sku
    {
        public Sku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class SloUsageMetric
    {
        internal SloUsageMetric() { }
        public double? InRangeTimeRatio { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ServiceObjectiveName? ServiceLevelObjective { get { throw null; } }
        public System.Guid? ServiceLevelObjectiveId { get { throw null; } }
    }
    public partial class StorageCapability
    {
        internal StorageCapability() { }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.StorageCapabilityStorageAccountType? StorageAccountType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageCapabilityStorageAccountType : System.IEquatable<Azure.ResourceManager.Sql.Models.StorageCapabilityStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageCapabilityStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.StorageCapabilityStorageAccountType GRS { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.StorageCapabilityStorageAccountType LRS { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.StorageCapabilityStorageAccountType ZRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.StorageCapabilityStorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.StorageCapabilityStorageAccountType left, Azure.ResourceManager.Sql.Models.StorageCapabilityStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.StorageCapabilityStorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.StorageCapabilityStorageAccountType left, Azure.ResourceManager.Sql.Models.StorageCapabilityStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum StorageKeyType
    {
        StorageAccessKey = 0,
        SharedAccessKey = 1,
    }
    public partial class SubscriptionUsage : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public SubscriptionUsage() { }
        public double? CurrentValue { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public double? Limit { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class SyncAgent : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public SyncAgent() { }
        public System.DateTimeOffset? ExpiryTime { get { throw null; } }
        public bool? IsUpToDate { get { throw null; } }
        public System.DateTimeOffset? LastAliveTime { get { throw null; } }
        public string NamePropertiesName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SyncAgentState? State { get { throw null; } }
        public string SyncDatabaseId { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public partial class SyncAgentKeyProperties
    {
        internal SyncAgentKeyProperties() { }
        public string SyncAgentKey { get { throw null; } }
    }
    public partial class SyncAgentLinkedDatabase : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public SyncAgentLinkedDatabase() { }
        public string DatabaseId { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SyncMemberDbType? DatabaseType { get { throw null; } }
        public string Description { get { throw null; } }
        public string ServerName { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncAgentState : System.IEquatable<Azure.ResourceManager.Sql.Models.SyncAgentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncAgentState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.SyncAgentState NeverConnected { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncAgentState Offline { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncAgentState Online { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.SyncAgentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.SyncAgentState left, Azure.ResourceManager.Sql.Models.SyncAgentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.SyncAgentState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.SyncAgentState left, Azure.ResourceManager.Sql.Models.SyncAgentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncConflictResolutionPolicy : System.IEquatable<Azure.ResourceManager.Sql.Models.SyncConflictResolutionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncConflictResolutionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.SyncConflictResolutionPolicy HubWin { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncConflictResolutionPolicy MemberWin { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.SyncConflictResolutionPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.SyncConflictResolutionPolicy left, Azure.ResourceManager.Sql.Models.SyncConflictResolutionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.SyncConflictResolutionPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.SyncConflictResolutionPolicy left, Azure.ResourceManager.Sql.Models.SyncConflictResolutionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SyncDatabaseIdProperties
    {
        internal SyncDatabaseIdProperties() { }
        public string Id { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncDirection : System.IEquatable<Azure.ResourceManager.Sql.Models.SyncDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncDirection(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.SyncDirection Bidirectional { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncDirection OneWayHubToMember { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncDirection OneWayMemberToHub { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.SyncDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.SyncDirection left, Azure.ResourceManager.Sql.Models.SyncDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.SyncDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.SyncDirection left, Azure.ResourceManager.Sql.Models.SyncDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SyncFullSchemaProperties
    {
        internal SyncFullSchemaProperties() { }
        public System.DateTimeOffset? LastUpdateTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.SyncFullSchemaTable> Tables { get { throw null; } }
    }
    public partial class SyncFullSchemaTable
    {
        internal SyncFullSchemaTable() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.SyncFullSchemaTableColumn> Columns { get { throw null; } }
        public string ErrorId { get { throw null; } }
        public bool? HasError { get { throw null; } }
        public string Name { get { throw null; } }
        public string QuotedName { get { throw null; } }
    }
    public partial class SyncFullSchemaTableColumn
    {
        internal SyncFullSchemaTableColumn() { }
        public string DataSize { get { throw null; } }
        public string DataType { get { throw null; } }
        public string ErrorId { get { throw null; } }
        public bool? HasError { get { throw null; } }
        public bool? IsPrimaryKey { get { throw null; } }
        public string Name { get { throw null; } }
        public string QuotedName { get { throw null; } }
    }
    public partial class SyncGroup : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public SyncGroup() { }
        public Azure.ResourceManager.Sql.Models.SyncConflictResolutionPolicy? ConflictResolutionPolicy { get { throw null; } set { } }
        public string HubDatabasePassword { get { throw null; } set { } }
        public string HubDatabaseUserName { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public System.DateTimeOffset? LastSyncTime { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SyncGroupSchema Schema { get { throw null; } set { } }
        public string SyncDatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SyncGroupState? SyncState { get { throw null; } }
        public bool? UsePrivateLinkConnection { get { throw null; } set { } }
    }
    public partial class SyncGroupLogProperties
    {
        internal SyncGroupLogProperties() { }
        public string Details { get { throw null; } }
        public string OperationStatus { get { throw null; } }
        public string Source { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public System.Guid? TracingId { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SyncGroupLogType? Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncGroupLogType : System.IEquatable<Azure.ResourceManager.Sql.Models.SyncGroupLogType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncGroupLogType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.SyncGroupLogType All { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncGroupLogType Error { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncGroupLogType Success { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncGroupLogType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.SyncGroupLogType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.SyncGroupLogType left, Azure.ResourceManager.Sql.Models.SyncGroupLogType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.SyncGroupLogType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.SyncGroupLogType left, Azure.ResourceManager.Sql.Models.SyncGroupLogType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SyncGroupSchema
    {
        public SyncGroupSchema() { }
        public string MasterSyncMemberName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.SyncGroupSchemaTable> Tables { get { throw null; } }
    }
    public partial class SyncGroupSchemaTable
    {
        public SyncGroupSchemaTable() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.SyncGroupSchemaTableColumn> Columns { get { throw null; } }
        public string QuotedName { get { throw null; } set { } }
    }
    public partial class SyncGroupSchemaTableColumn
    {
        public SyncGroupSchemaTableColumn() { }
        public string DataSize { get { throw null; } set { } }
        public string DataType { get { throw null; } set { } }
        public string QuotedName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncGroupState : System.IEquatable<Azure.ResourceManager.Sql.Models.SyncGroupState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncGroupState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.SyncGroupState Error { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncGroupState Good { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncGroupState NotReady { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncGroupState Progressing { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncGroupState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.SyncGroupState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.SyncGroupState left, Azure.ResourceManager.Sql.Models.SyncGroupState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.SyncGroupState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.SyncGroupState left, Azure.ResourceManager.Sql.Models.SyncGroupState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SyncMember : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public SyncMember() { }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SyncMemberDbType? DatabaseType { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public System.Guid? SqlServerDatabaseId { get { throw null; } set { } }
        public string SyncAgentId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SyncDirection? SyncDirection { get { throw null; } set { } }
        public string SyncMemberAzureDatabaseResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SyncMemberState? SyncState { get { throw null; } }
        public bool? UsePrivateLinkConnection { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncMemberDbType : System.IEquatable<Azure.ResourceManager.Sql.Models.SyncMemberDbType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncMemberDbType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.SyncMemberDbType AzureSqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberDbType SqlServerDatabase { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.SyncMemberDbType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.SyncMemberDbType left, Azure.ResourceManager.Sql.Models.SyncMemberDbType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.SyncMemberDbType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.SyncMemberDbType left, Azure.ResourceManager.Sql.Models.SyncMemberDbType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncMemberState : System.IEquatable<Azure.ResourceManager.Sql.Models.SyncMemberState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncMemberState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState DeProvisioned { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState DeProvisionFailed { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState DeProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState DisabledBackupRestore { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState DisabledTombstoneCleanup { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState Provisioned { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState ProvisionFailed { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState ReprovisionFailed { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState Reprovisioning { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState SyncCancelled { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState SyncCancelling { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState SyncFailed { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState SyncInProgress { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState SyncSucceeded { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState SyncSucceededWithWarnings { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState UnProvisioned { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SyncMemberState UnReprovisioned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.SyncMemberState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.SyncMemberState left, Azure.ResourceManager.Sql.Models.SyncMemberState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.SyncMemberState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.SyncMemberState left, Azure.ResourceManager.Sql.Models.SyncMemberState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TdeCertificate : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public TdeCertificate() { }
        public string CertPassword { get { throw null; } set { } }
        public string PrivateBlob { get { throw null; } set { } }
    }
    public partial class TrackedResource : Azure.ResourceManager.Sql.Models.Resource
    {
        public TrackedResource(string location) { }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class TransparentDataEncryption : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public TransparentDataEncryption() { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.TransparentDataEncryptionStatus? Status { get { throw null; } set { } }
    }
    public partial class TransparentDataEncryptionActivity : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public TransparentDataEncryptionActivity() { }
        public string Location { get { throw null; } }
        public float? PercentComplete { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.TransparentDataEncryptionActivityStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransparentDataEncryptionActivityStatus : System.IEquatable<Azure.ResourceManager.Sql.Models.TransparentDataEncryptionActivityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransparentDataEncryptionActivityStatus(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.TransparentDataEncryptionActivityStatus Decrypting { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.TransparentDataEncryptionActivityStatus Encrypting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionActivityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionActivityStatus left, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionActivityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.TransparentDataEncryptionActivityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionActivityStatus left, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionActivityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransparentDataEncryptionName : System.IEquatable<Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransparentDataEncryptionName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName Current { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName left, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName left, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum TransparentDataEncryptionStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnitDefinitionType : System.IEquatable<Azure.ResourceManager.Sql.Models.UnitDefinitionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnitDefinitionType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.UnitDefinitionType Bytes { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.UnitDefinitionType BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.UnitDefinitionType Count { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.UnitDefinitionType CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.UnitDefinitionType Percent { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.UnitDefinitionType Seconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.UnitDefinitionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.UnitDefinitionType left, Azure.ResourceManager.Sql.Models.UnitDefinitionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.UnitDefinitionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.UnitDefinitionType left, Azure.ResourceManager.Sql.Models.UnitDefinitionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnitType : System.IEquatable<Azure.ResourceManager.Sql.Models.UnitType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnitType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.UnitType Bytes { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.UnitType BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.UnitType Count { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.UnitType CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.UnitType Percent { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.UnitType Seconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.UnitType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.UnitType left, Azure.ResourceManager.Sql.Models.UnitType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.UnitType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.UnitType left, Azure.ResourceManager.Sql.Models.UnitType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UnlinkParameters
    {
        public UnlinkParameters() { }
        public bool? ForcedTermination { get { throw null; } set { } }
    }
    public partial class UpsertManagedServerOperationParameters
    {
        internal UpsertManagedServerOperationParameters() { }
        public string Family { get { throw null; } }
        public int? StorageSizeInGB { get { throw null; } }
        public string Tier { get { throw null; } }
        public int? VCores { get { throw null; } }
    }
    public partial class UpsertManagedServerOperationStep
    {
        internal UpsertManagedServerOperationStep() { }
        public string Name { get { throw null; } }
        public int? Order { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationStepStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpsertManagedServerOperationStepStatus : System.IEquatable<Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationStepStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpsertManagedServerOperationStepStatus(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationStepStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationStepStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationStepStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationStepStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationStepStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationStepStatus SlowedDown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationStepStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationStepStatus left, Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationStepStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationStepStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationStepStatus left, Azure.ResourceManager.Sql.Models.UpsertManagedServerOperationStepStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Usage
    {
        internal Usage() { }
        public int? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.Name Name { get { throw null; } }
        public int? RequestedLimit { get { throw null; } }
        public string Type { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class VirtualCluster : Azure.ResourceManager.Sql.Models.TrackedResource
    {
        public VirtualCluster(string location) : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyList<string> ChildResources { get { throw null; } }
        public string Family { get { throw null; } set { } }
        public string SubnetId { get { throw null; } }
    }
    public partial class VirtualClusterUpdate
    {
        public VirtualClusterUpdate() { }
        public System.Collections.Generic.IReadOnlyList<string> ChildResources { get { throw null; } }
        public string Family { get { throw null; } set { } }
        public string SubnetId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VirtualNetworkRule : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public VirtualNetworkRule() { }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState? State { get { throw null; } }
        public string VirtualNetworkSubnetId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualNetworkRuleState : System.IEquatable<Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualNetworkRuleState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState Initializing { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState Ready { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState left, Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState left, Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VulnerabilityAssessmentName : System.IEquatable<Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VulnerabilityAssessmentName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName left, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName left, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum VulnerabilityAssessmentPolicyBaselineName
    {
        Master = 0,
        Default = 1,
    }
    public partial class VulnerabilityAssessmentRecurringScansProperties
    {
        public VulnerabilityAssessmentRecurringScansProperties() { }
        public System.Collections.Generic.IList<string> Emails { get { throw null; } }
        public bool? EmailSubscriptionAdmins { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class VulnerabilityAssessmentScanError
    {
        internal VulnerabilityAssessmentScanError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class VulnerabilityAssessmentScanRecord : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public VulnerabilityAssessmentScanRecord() { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanError> Errors { get { throw null; } }
        public int? NumberOfFailedSecurityChecks { get { throw null; } }
        public string ScanId { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanState? State { get { throw null; } }
        public string StorageContainerPath { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanTriggerType? TriggerType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VulnerabilityAssessmentScanState : System.IEquatable<Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VulnerabilityAssessmentScanState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanState Failed { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanState FailedToRun { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanState Passed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanState left, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanState left, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VulnerabilityAssessmentScanTriggerType : System.IEquatable<Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VulnerabilityAssessmentScanTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanTriggerType OnDemand { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanTriggerType Recurring { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanTriggerType left, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanTriggerType left, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadClassifier : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public WorkloadClassifier() { }
        public string Context { get { throw null; } set { } }
        public string EndTime { get { throw null; } set { } }
        public string Importance { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public string MemberName { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
    }
    public partial class WorkloadGroup : Azure.ResourceManager.Sql.Models.ProxyResource
    {
        public WorkloadGroup() { }
        public string Importance { get { throw null; } set { } }
        public int? MaxResourcePercent { get { throw null; } set { } }
        public double? MaxResourcePercentPerRequest { get { throw null; } set { } }
        public int? MinResourcePercent { get { throw null; } set { } }
        public double? MinResourcePercentPerRequest { get { throw null; } set { } }
        public int? QueryExecutionTimeout { get { throw null; } set { } }
    }
}
