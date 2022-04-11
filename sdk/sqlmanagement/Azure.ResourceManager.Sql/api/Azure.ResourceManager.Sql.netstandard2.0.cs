namespace Azure.ResourceManager.Sql
{
    public partial class AdvisorData : Azure.ResourceManager.Models.ResourceData
    {
        public AdvisorData() { }
        public Azure.ResourceManager.Sql.Models.AdvisorStatus? AdvisorStatus { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.AutoExecuteStatus? AutoExecuteStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.AutoExecuteStatusInheritedFrom? AutoExecuteStatusInheritedFrom { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.DateTimeOffset? LastChecked { get { throw null; } }
        public string Location { get { throw null; } }
        public string RecommendationsStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.RecommendedActionData> RecommendedActions { get { throw null; } }
    }
    public partial class BackupShortTermRetentionPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource>, System.Collections.IEnumerable
    {
        protected BackupShortTermRetentionPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource> Get(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource>> GetAsync(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupShortTermRetentionPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public BackupShortTermRetentionPolicyData() { }
        public Azure.ResourceManager.Sql.Models.DiffBackupIntervalInHours? DiffBackupIntervalInHours { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
    }
    public partial class BackupShortTermRetentionPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupShortTermRetentionPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string policyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAutomaticTuningData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseAutomaticTuningData() { }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningMode? ActualState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningMode? DesiredState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Sql.Models.AutomaticTuningOptions> Options { get { throw null; } }
    }
    public partial class DatabaseAutomaticTuningResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAutomaticTuningResource() { }
        public virtual Azure.ResourceManager.Sql.DatabaseAutomaticTuningData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseAutomaticTuningResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseAutomaticTuningResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseAutomaticTuningResource> Update(Azure.ResourceManager.Sql.DatabaseAutomaticTuningData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseAutomaticTuningResource>> UpdateAsync(Azure.ResourceManager.Sql.DatabaseAutomaticTuningData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseBlobAuditingPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource>, System.Collections.IEnumerable
    {
        protected DatabaseBlobAuditingPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource> Get(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource>> GetAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseBlobAuditingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseBlobAuditingPolicyData() { }
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
    public partial class DatabaseBlobAuditingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseBlobAuditingPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string blobAuditingPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseColumnData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseColumnData() { }
        public Azure.ResourceManager.Sql.Models.ColumnDataType? ColumnType { get { throw null; } set { } }
        public bool? IsComputed { get { throw null; } set { } }
        public bool? MemoryOptimized { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.TableTemporalType? TemporalType { get { throw null; } set { } }
    }
    public partial class DatabaseSchemaData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseSchemaData() { }
    }
    public partial class DatabaseSecurityAlertPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource>, System.Collections.IEnumerable
    {
        protected DatabaseSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource> Get(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource>> GetAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseSecurityAlertPolicyData() { }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public bool? EmailAccountAdmins { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecurityAlertsPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class DatabaseSecurityAlertPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseSecurityAlertPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseTableData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseTableData() { }
        public bool? MemoryOptimized { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.TableTemporalType? TemporalType { get { throw null; } set { } }
    }
    public partial class DatabaseVulnerabilityAssessmentData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseVulnerabilityAssessmentData() { }
        public Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageContainerPath { get { throw null; } set { } }
        public string StorageContainerSasKey { get { throw null; } set { } }
    }
    public partial class DatabaseVulnerabilityAssessmentRuleBaselineData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseVulnerabilityAssessmentRuleBaselineData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentRuleBaselineItem> BaselineResults { get { throw null; } }
    }
    public partial class DataMaskingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public DataMaskingPolicyData() { }
        public string ApplicationPrincipals { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.DataMaskingState? DataMaskingState { get { throw null; } set { } }
        public string ExemptPrincipals { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } }
        public string MaskingLevel { get { throw null; } }
    }
    public partial class DataMaskingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataMaskingPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.DataMaskingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DataMaskingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.DataMaskingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DataMaskingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.DataMaskingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DataMaskingRule> CreateOrUpdateDataMaskingRule(string dataMaskingRuleName, Azure.ResourceManager.Sql.Models.DataMaskingRule dataMaskingRule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DataMaskingRule>> CreateOrUpdateDataMaskingRuleAsync(string dataMaskingRuleName, Azure.ResourceManager.Sql.Models.DataMaskingRule dataMaskingRule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DataMaskingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DataMaskingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.DataMaskingRule> GetDataMaskingRules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.DataMaskingRule> GetDataMaskingRulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataWarehouseUserActivitiesCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DataWarehouseUserActivitiesResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DataWarehouseUserActivitiesResource>, System.Collections.IEnumerable
    {
        protected DataWarehouseUserActivitiesCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DataWarehouseUserActivitiesResource> Get(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.DataWarehouseUserActivitiesResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.DataWarehouseUserActivitiesResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DataWarehouseUserActivitiesResource>> GetAsync(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.DataWarehouseUserActivitiesResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DataWarehouseUserActivitiesResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.DataWarehouseUserActivitiesResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DataWarehouseUserActivitiesResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataWarehouseUserActivitiesData : Azure.ResourceManager.Models.ResourceData
    {
        public DataWarehouseUserActivitiesData() { }
        public int? ActiveQueriesCount { get { throw null; } }
    }
    public partial class DataWarehouseUserActivitiesResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataWarehouseUserActivitiesResource() { }
        public virtual Azure.ResourceManager.Sql.DataWarehouseUserActivitiesData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string dataWarehouseUserActivityName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DataWarehouseUserActivitiesResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DataWarehouseUserActivitiesResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DeletedServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DeletedServerResource>, System.Collections.IEnumerable
    {
        protected DeletedServerCollection() { }
        public virtual Azure.Response<bool> Exists(string deletedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deletedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DeletedServerResource> Get(string deletedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.DeletedServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.DeletedServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DeletedServerResource>> GetAsync(string deletedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.DeletedServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DeletedServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.DeletedServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DeletedServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeletedServerData : Azure.ResourceManager.Models.ResourceData
    {
        public DeletedServerData() { }
        public System.DateTimeOffset? DeletionOn { get { throw null; } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public string OriginalId { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class DeletedServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedServerResource() { }
        public virtual Azure.ResourceManager.Sql.DeletedServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string deletedServerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DeletedServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DeletedServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DeletedServerResource> Recover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DeletedServerResource>> RecoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ElasticPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ElasticPoolResource>, System.Collections.IEnumerable
    {
        protected ElasticPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ElasticPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string elasticPoolName, Azure.ResourceManager.Sql.ElasticPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ElasticPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string elasticPoolName, Azure.ResourceManager.Sql.ElasticPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ElasticPoolResource> Get(string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ElasticPoolResource> GetAll(int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ElasticPoolResource> GetAllAsync(int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ElasticPoolResource>> GetAsync(string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ElasticPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ElasticPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ElasticPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ElasticPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ElasticPoolData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ElasticPoolData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ElasticPoolLicenseType? LicenseType { get { throw null; } set { } }
        public string MaintenanceConfigurationId { get { throw null; } set { } }
        public long? MaxSizeBytes { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ElasticPoolPerDatabaseSettings PerDatabaseSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ElasticPoolState? State { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class ElasticPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ElasticPoolResource() { }
        public virtual Azure.ResourceManager.Sql.ElasticPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ElasticPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ElasticPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelElasticPoolOperation(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelElasticPoolOperationAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string elasticPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Failover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ElasticPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ElasticPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlDatabaseResource> GetDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlDatabaseResource> GetDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ElasticPoolActivity> GetElasticPoolActivities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ElasticPoolActivity> GetElasticPoolActivitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ElasticPoolDatabaseActivity> GetElasticPoolDatabaseActivities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ElasticPoolDatabaseActivity> GetElasticPoolDatabaseActivitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ElasticPoolOperation> GetElasticPoolOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ElasticPoolOperation> GetElasticPoolOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.MetricDefinition> GetMetricDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.MetricDefinition> GetMetricDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SqlMetric> GetMetrics(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SqlMetric> GetMetricsAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ElasticPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ElasticPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ElasticPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ElasticPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ElasticPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ElasticPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ElasticPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ElasticPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EncryptionProtectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.EncryptionProtectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.EncryptionProtectorResource>, System.Collections.IEnumerable
    {
        protected EncryptionProtectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.EncryptionProtectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Sql.EncryptionProtectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.EncryptionProtectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Sql.EncryptionProtectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.EncryptionProtectorResource> Get(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.EncryptionProtectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.EncryptionProtectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.EncryptionProtectorResource>> GetAsync(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.EncryptionProtectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.EncryptionProtectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.EncryptionProtectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.EncryptionProtectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EncryptionProtectorData : Azure.ResourceManager.Models.ResourceData
    {
        public EncryptionProtectorData() { }
        public bool? AutoRotationEnabled { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } }
        public string ServerKeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ServerKeyType? ServerKeyType { get { throw null; } set { } }
        public string Subregion { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class EncryptionProtectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EncryptionProtectorResource() { }
        public virtual Azure.ResourceManager.Sql.EncryptionProtectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string encryptionProtectorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.EncryptionProtectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.EncryptionProtectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Revalidate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevalidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExtendedDatabaseBlobAuditingPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource>, System.Collections.IEnumerable
    {
        protected ExtendedDatabaseBlobAuditingPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource> Get(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource>> GetAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExtendedDatabaseBlobAuditingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ExtendedDatabaseBlobAuditingPolicyData() { }
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
    public partial class ExtendedDatabaseBlobAuditingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExtendedDatabaseBlobAuditingPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string blobAuditingPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExtendedServerBlobAuditingPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource>, System.Collections.IEnumerable
    {
        protected ExtendedServerBlobAuditingPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource> Get(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource>> GetAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExtendedServerBlobAuditingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ExtendedServerBlobAuditingPolicyData() { }
        public System.Collections.Generic.IList<string> AuditActionsAndGroups { get { throw null; } }
        public bool? IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public bool? IsDevopsAuditEnabled { get { throw null; } set { } }
        public bool? IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public string PredicateExpression { get { throw null; } set { } }
        public int? QueueDelayMs { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.BlobAuditingPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public System.Guid? StorageAccountSubscriptionId { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ExtendedServerBlobAuditingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExtendedServerBlobAuditingPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string blobAuditingPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FailoverGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.FailoverGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.FailoverGroupResource>, System.Collections.IEnumerable
    {
        protected FailoverGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string failoverGroupName, Azure.ResourceManager.Sql.FailoverGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string failoverGroupName, Azure.ResourceManager.Sql.FailoverGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FailoverGroupResource> Get(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.FailoverGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.FailoverGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FailoverGroupResource>> GetAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.FailoverGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.FailoverGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.FailoverGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.FailoverGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FailoverGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public FailoverGroupData() { }
        public System.Collections.Generic.IList<string> Databases { get { throw null; } }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.PartnerInfo> PartnerServers { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ReadOnlyEndpointFailoverPolicy? ReadOnlyEndpointFailoverPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.FailoverGroupReadWriteEndpoint ReadWriteEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.FailoverGroupReplicationRole? ReplicationRole { get { throw null; } }
        public string ReplicationState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class FailoverGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FailoverGroupResource() { }
        public virtual Azure.ResourceManager.Sql.FailoverGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FailoverGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FailoverGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string failoverGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroupResource> Failover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroupResource>> FailoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroupResource> ForceFailoverAllowDataLoss(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroupResource>> ForceFailoverAllowDataLossAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FailoverGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FailoverGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FailoverGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FailoverGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FailoverGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FailoverGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.FailoverGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.FailoverGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.FirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.FirewallRuleResource>, System.Collections.IEnumerable
    {
        protected FirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.Sql.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.Sql.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.FirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.FirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.FirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.FirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.FirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.FirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirewallRuleData : Azure.ResourceManager.Sql.Models.ProxyResourceWithWritableName
    {
        public FirewallRuleData() { }
        public string EndIPAddress { get { throw null; } set { } }
        public string StartIPAddress { get { throw null; } set { } }
    }
    public partial class FirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirewallRuleResource() { }
        public virtual Azure.ResourceManager.Sql.FirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GeoBackupPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.GeoBackupPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.GeoBackupPolicyResource>, System.Collections.IEnumerable
    {
        protected GeoBackupPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.GeoBackupPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, Azure.ResourceManager.Sql.GeoBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.GeoBackupPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, Azure.ResourceManager.Sql.GeoBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.GeoBackupPolicyResource> Get(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.GeoBackupPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.GeoBackupPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.GeoBackupPolicyResource>> GetAsync(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.GeoBackupPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.GeoBackupPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.GeoBackupPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.GeoBackupPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GeoBackupPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public GeoBackupPolicyData(Azure.ResourceManager.Sql.Models.GeoBackupPolicyState state) { }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.GeoBackupPolicyState State { get { throw null; } set { } }
        public string StorageType { get { throw null; } }
    }
    public partial class GeoBackupPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GeoBackupPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.GeoBackupPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string geoBackupPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.GeoBackupPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.GeoBackupPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstanceFailoverGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.InstanceFailoverGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.InstanceFailoverGroupResource>, System.Collections.IEnumerable
    {
        protected InstanceFailoverGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstanceFailoverGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string failoverGroupName, Azure.ResourceManager.Sql.InstanceFailoverGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstanceFailoverGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string failoverGroupName, Azure.ResourceManager.Sql.InstanceFailoverGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroupResource> Get(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.InstanceFailoverGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.InstanceFailoverGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroupResource>> GetAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.InstanceFailoverGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.InstanceFailoverGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.InstanceFailoverGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.InstanceFailoverGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InstanceFailoverGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public InstanceFailoverGroupData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.ManagedInstancePairInfo> ManagedInstancePairs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.PartnerRegionInfo> PartnerRegions { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ReadOnlyEndpointFailoverPolicy? ReadOnlyEndpointFailoverPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.InstanceFailoverGroupReadWriteEndpoint ReadWriteEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.InstanceFailoverGroupReplicationRole? ReplicationRole { get { throw null; } }
        public string ReplicationState { get { throw null; } }
    }
    public partial class InstanceFailoverGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InstanceFailoverGroupResource() { }
        public virtual Azure.ResourceManager.Sql.InstanceFailoverGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string locationName, string failoverGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstanceFailoverGroupResource> Failover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstanceFailoverGroupResource>> FailoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstanceFailoverGroupResource> ForceFailoverAllowDataLoss(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstanceFailoverGroupResource>> ForceFailoverAllowDataLossAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstancePoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.InstancePoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.InstancePoolResource>, System.Collections.IEnumerable
    {
        protected InstancePoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstancePoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string instancePoolName, Azure.ResourceManager.Sql.InstancePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstancePoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string instancePoolName, Azure.ResourceManager.Sql.InstancePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstancePoolResource> Get(string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.InstancePoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.InstancePoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstancePoolResource>> GetAsync(string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.InstancePoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.InstancePoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.InstancePoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.InstancePoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InstancePoolData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public InstancePoolData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Sql.Models.InstancePoolLicenseType? LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public int? VCores { get { throw null; } set { } }
    }
    public partial class InstancePoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InstancePoolResource() { }
        public virtual Azure.ResourceManager.Sql.InstancePoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstancePoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstancePoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instancePoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstancePoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstancePoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceResource> GetManagedInstances(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceResource> GetManagedInstancesAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.InstancePoolUsage> GetUsages(bool? expandChildren = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.InstancePoolUsage> GetUsagesAsync(bool? expandChildren = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstancePoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstancePoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstancePoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstancePoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobAgentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobAgentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobAgentResource>, System.Collections.IEnumerable
    {
        protected JobAgentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.JobAgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobAgentName, Azure.ResourceManager.Sql.JobAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.JobAgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobAgentName, Azure.ResourceManager.Sql.JobAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobAgentResource> Get(string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.JobAgentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.JobAgentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobAgentResource>> GetAsync(string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.JobAgentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobAgentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.JobAgentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobAgentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobAgentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public JobAgentData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string DatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobAgentState? State { get { throw null; } }
    }
    public partial class JobAgentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobAgentResource() { }
        public virtual Azure.ResourceManager.Sql.JobAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobAgentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobAgentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobAgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobAgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobCredentialResource> GetJobCredential(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobCredentialResource>> GetJobCredentialAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.JobCredentialCollection GetJobCredentials() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource> GetJobExecutionsByAgent(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource> GetJobExecutionsByAgentAsync(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobTargetGroupResource> GetJobTargetGroup(string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobTargetGroupResource>> GetJobTargetGroupAsync(string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.JobTargetGroupCollection GetJobTargetGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlJobResource> GetSqlJob(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlJobResource>> GetSqlJobAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SqlJobCollection GetSqlJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobAgentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobAgentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobAgentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobAgentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobCredentialCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobCredentialResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobCredentialResource>, System.Collections.IEnumerable
    {
        protected JobCredentialCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.JobCredentialResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string credentialName, Azure.ResourceManager.Sql.JobCredentialData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.JobCredentialResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string credentialName, Azure.ResourceManager.Sql.JobCredentialData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobCredentialResource> Get(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.JobCredentialResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.JobCredentialResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobCredentialResource>> GetAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.JobCredentialResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobCredentialResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.JobCredentialResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobCredentialResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobCredentialData : Azure.ResourceManager.Models.ResourceData
    {
        public JobCredentialData() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class JobCredentialResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobCredentialResource() { }
        public virtual Azure.ResourceManager.Sql.JobCredentialData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string credentialName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobCredentialResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobCredentialResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobExecutionData : Azure.ResourceManager.Models.ResourceData
    {
        public JobExecutionData() { }
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public int? CurrentAttempts { get { throw null; } set { } }
        public System.DateTimeOffset? CurrentAttemptStartOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Guid? JobExecutionId { get { throw null; } }
        public int? JobVersion { get { throw null; } }
        public string LastMessage { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.JobExecutionLifecycle? Lifecycle { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public int? StepId { get { throw null; } }
        public string StepName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.JobExecutionTarget Target { get { throw null; } }
    }
    public partial class JobStepData : Azure.ResourceManager.Models.ResourceData
    {
        public JobStepData() { }
        public Azure.ResourceManager.Sql.Models.JobStepAction Action { get { throw null; } set { } }
        public string Credential { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobStepExecutionOptions ExecutionOptions { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobStepOutput Output { get { throw null; } set { } }
        public int? StepId { get { throw null; } set { } }
        public string TargetGroup { get { throw null; } set { } }
    }
    public partial class JobTargetGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobTargetGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobTargetGroupResource>, System.Collections.IEnumerable
    {
        protected JobTargetGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.JobTargetGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string targetGroupName, Azure.ResourceManager.Sql.JobTargetGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.JobTargetGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string targetGroupName, Azure.ResourceManager.Sql.JobTargetGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobTargetGroupResource> Get(string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.JobTargetGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.JobTargetGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobTargetGroupResource>> GetAsync(string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.JobTargetGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobTargetGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.JobTargetGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobTargetGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobTargetGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public JobTargetGroupData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.JobTarget> Members { get { throw null; } }
    }
    public partial class JobTargetGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobTargetGroupResource() { }
        public virtual Azure.ResourceManager.Sql.JobTargetGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string targetGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobTargetGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobTargetGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobVersionResource>, System.Collections.IEnumerable
    {
        protected JobVersionCollection() { }
        public virtual Azure.Response<bool> Exists(int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobVersionResource> Get(int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.JobVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.JobVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobVersionResource>> GetAsync(int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.JobVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.JobVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public JobVersionData() { }
    }
    public partial class JobVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobVersionResource() { }
        public virtual Azure.ResourceManager.Sql.JobVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, string jobVersion) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepResource> GetServerJobAgentJobVersionStep(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepResource>> GetServerJobAgentJobVersionStepAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepCollection GetServerJobAgentJobVersionSteps() { throw null; }
    }
    public partial class LedgerDigestUploadsCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.LedgerDigestUploadsResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.LedgerDigestUploadsResource>, System.Collections.IEnumerable
    {
        protected LedgerDigestUploadsCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LedgerDigestUploadsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, Azure.ResourceManager.Sql.LedgerDigestUploadsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LedgerDigestUploadsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, Azure.ResourceManager.Sql.LedgerDigestUploadsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LedgerDigestUploadsResource> Get(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.LedgerDigestUploadsResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.LedgerDigestUploadsResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LedgerDigestUploadsResource>> GetAsync(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.LedgerDigestUploadsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.LedgerDigestUploadsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.LedgerDigestUploadsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.LedgerDigestUploadsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LedgerDigestUploadsData : Azure.ResourceManager.Models.ResourceData
    {
        public LedgerDigestUploadsData() { }
        public string DigestStorageEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.LedgerDigestUploadsState? State { get { throw null; } }
    }
    public partial class LedgerDigestUploadsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LedgerDigestUploadsResource() { }
        public virtual Azure.ResourceManager.Sql.LedgerDigestUploadsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string ledgerDigestUploads) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LedgerDigestUploadsResource> Disable(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LedgerDigestUploadsResource>> DisableAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LedgerDigestUploadsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LedgerDigestUploadsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicalDatabaseTransparentDataEncryptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource>, System.Collections.IEnumerable
    {
        protected LogicalDatabaseTransparentDataEncryptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource> Get(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource>> GetAsync(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicalDatabaseTransparentDataEncryptionData : Azure.ResourceManager.Models.ResourceData
    {
        public LogicalDatabaseTransparentDataEncryptionData() { }
        public Azure.ResourceManager.Sql.Models.TransparentDataEncryptionState? State { get { throw null; } set { } }
    }
    public partial class LogicalDatabaseTransparentDataEncryptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicalDatabaseTransparentDataEncryptionResource() { }
        public virtual Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string tdeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LongTermRetentionBackupData : Azure.ResourceManager.Models.ResourceData
    {
        public LongTermRetentionBackupData() { }
        public System.DateTimeOffset? BackupExpirationOn { get { throw null; } }
        public System.DateTimeOffset? BackupOn { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.BackupStorageRedundancy? BackupStorageRedundancy { get { throw null; } }
        public System.DateTimeOffset? DatabaseDeletionOn { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.BackupStorageRedundancy? RequestedBackupStorageRedundancy { get { throw null; } set { } }
        public System.DateTimeOffset? ServerCreateOn { get { throw null; } }
        public string ServerName { get { throw null; } }
    }
    public partial class LongTermRetentionPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource>, System.Collections.IEnumerable
    {
        protected LongTermRetentionPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.LongTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.LongTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource> Get(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource>> GetAsync(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LongTermRetentionPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public LongTermRetentionPolicyData() { }
        public string MonthlyRetention { get { throw null; } set { } }
        public string WeeklyRetention { get { throw null; } set { } }
        public int? WeekOfYear { get { throw null; } set { } }
        public string YearlyRetention { get { throw null; } set { } }
    }
    public partial class LongTermRetentionPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LongTermRetentionPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.LongTermRetentionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string policyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaintenanceWindowOptionsData : Azure.ResourceManager.Models.ResourceData
    {
        public MaintenanceWindowOptionsData() { }
        public bool? AllowMultipleMaintenanceWindowsPerCycle { get { throw null; } set { } }
        public int? DefaultDurationInMinutes { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.MaintenanceWindowTimeRange> MaintenanceWindowCycles { get { throw null; } }
        public int? MinCycles { get { throw null; } set { } }
        public int? MinDurationInMinutes { get { throw null; } set { } }
        public int? TimeGranularityInMinutes { get { throw null; } set { } }
    }
    public partial class MaintenanceWindowOptionsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenanceWindowOptionsResource() { }
        public virtual Azure.ResourceManager.Sql.MaintenanceWindowOptionsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.MaintenanceWindowOptionsResource> Get(string maintenanceWindowOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.MaintenanceWindowOptionsResource>> GetAsync(string maintenanceWindowOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaintenanceWindowsData : Azure.ResourceManager.Models.ResourceData
    {
        public MaintenanceWindowsData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.MaintenanceWindowTimeRange> TimeRanges { get { throw null; } }
    }
    public partial class MaintenanceWindowsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenanceWindowsResource() { }
        public virtual Azure.ResourceManager.Sql.MaintenanceWindowsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdate(Azure.WaitUntil waitUntil, string maintenanceWindowName, Azure.ResourceManager.Sql.MaintenanceWindowsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string maintenanceWindowName, Azure.ResourceManager.Sql.MaintenanceWindowsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.MaintenanceWindowsResource> Get(string maintenanceWindowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.MaintenanceWindowsResource>> GetAsync(string maintenanceWindowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedBackupShortTermRetentionPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedBackupShortTermRetentionPolicyData() { }
        public int? RetentionDays { get { throw null; } set { } }
    }
    public partial class ManagedDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedDatabaseResource>, System.Collections.IEnumerable
    {
        protected ManagedDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Sql.ManagedDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Sql.ManagedDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedDatabaseData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedDatabaseData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AutoCompleteRestore { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CatalogCollationType? CatalogCollation { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public string DefaultSecondaryLocation { get { throw null; } }
        public System.DateTimeOffset? EarliestRestorePoint { get { throw null; } }
        public string FailoverGroupId { get { throw null; } }
        public string LastBackupName { get { throw null; } set { } }
        public string LongTermRetentionBackupResourceId { get { throw null; } set { } }
        public string RecoverableDatabaseId { get { throw null; } set { } }
        public string RestorableDroppedDatabaseId { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInOn { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus? Status { get { throw null; } }
        public string StorageContainerSasToken { get { throw null; } set { } }
        public System.Uri StorageContainerUri { get { throw null; } set { } }
    }
    public partial class ManagedDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedDatabaseResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CompleteRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CompleteDatabaseRestoreDefinition completeDatabaseRestoreDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CompleteRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CompleteDatabaseRestoreDefinition completeDatabaseRestoreDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource> GetCurrentManagedDatabaseSensitivityLabels(string skipToken = null, bool? count = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource> GetCurrentManagedDatabaseSensitivityLabelsAsync(string skipToken = null, bool? count = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource> GetManagedDatabaseColumnsByDatabase(System.Collections.Generic.IEnumerable<string> schema = null, System.Collections.Generic.IEnumerable<string> table = null, System.Collections.Generic.IEnumerable<string> column = null, System.Collections.Generic.IEnumerable<string> orderBy = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource> GetManagedDatabaseColumnsByDatabaseAsync(System.Collections.Generic.IEnumerable<string> schema = null, System.Collections.Generic.IEnumerable<string> table = null, System.Collections.Generic.IEnumerable<string> column = null, System.Collections.Generic.IEnumerable<string> orderBy = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceQuery> GetManagedDatabaseQuery(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceQuery>> GetManagedDatabaseQueryAsync(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResultResource> GetManagedDatabaseRestoreDetailsResult(Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResultResource>> GetManagedDatabaseRestoreDetailsResultAsync(Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResultCollection GetManagedDatabaseRestoreDetailsResults() { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyCollection GetManagedDatabaseSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource> GetManagedDatabaseSecurityAlertPolicy(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource>> GetManagedDatabaseSecurityAlertPolicyAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SecurityEvent> GetManagedDatabaseSecurityEventsByDatabase(string filter = null, int? skip = default(int?), int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SecurityEvent> GetManagedDatabaseSecurityEventsByDatabaseAsync(string filter = null, int? skip = default(int?), int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyCollection GetManagedInstanceDatabaseBackupShortTermRetentionPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource> GetManagedInstanceDatabaseBackupShortTermRetentionPolicy(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource>> GetManagedInstanceDatabaseBackupShortTermRetentionPolicyAsync(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaResource> GetManagedInstanceDatabaseSchema(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaResource>> GetManagedInstanceDatabaseSchemaAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaCollection GetManagedInstanceDatabaseSchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource> GetManagedInstanceDatabaseVulnerabilityAssessment(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource>> GetManagedInstanceDatabaseVulnerabilityAssessmentAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentCollection GetManagedInstanceDatabaseVulnerabilityAssessments() { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyCollection GetManagedInstanceLongTermRetentionPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource> GetManagedInstanceLongTermRetentionPolicy(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource>> GetManagedInstanceLongTermRetentionPolicyAsync(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource> GetManagedTransparentDataEncryption(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource>> GetManagedTransparentDataEncryptionAsync(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionCollection GetManagedTransparentDataEncryptions() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.QueryStatistics> GetQueryStatistics(string queryId, string startTime = null, string endTime = null, Azure.ResourceManager.Sql.Models.QueryTimeGrainType? interval = default(Azure.ResourceManager.Sql.Models.QueryTimeGrainType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.QueryStatistics> GetQueryStatisticsAsync(string queryId, string startTime = null, string endTime = null, Azure.ResourceManager.Sql.Models.QueryTimeGrainType? interval = default(Azure.ResourceManager.Sql.Models.QueryTimeGrainType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource> GetRecommendedManagedDatabaseSensitivityLabels(string skipToken = null, bool? includeDisabledRecommendations = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource> GetRecommendedManagedDatabaseSensitivityLabelsAsync(string skipToken = null, bool? includeDisabledRecommendations = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedDatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedDatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateManagedDatabaseSensitivityLabel(Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateList sensitivityLabelUpdateList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateManagedDatabaseSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateList sensitivityLabelUpdateList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateRecommendedManagedDatabaseSensitivityLabel(Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdateList recommendedSensitivityLabelUpdateList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateRecommendedManagedDatabaseSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdateList recommendedSensitivityLabelUpdateList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabaseRestoreDetailsResultCollection : Azure.ResourceManager.ArmCollection
    {
        protected ManagedDatabaseRestoreDetailsResultCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResultResource> Get(Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResultResource>> GetAsync(Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabaseRestoreDetailsResultData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedDatabaseRestoreDetailsResultData() { }
        public string BlockReason { get { throw null; } }
        public string CurrentRestoringFileName { get { throw null; } }
        public string LastRestoredFileName { get { throw null; } }
        public System.DateTimeOffset? LastRestoredFileOn { get { throw null; } }
        public string LastUploadedFileName { get { throw null; } }
        public System.DateTimeOffset? LastUploadedFileOn { get { throw null; } }
        public long? NumberOfFilesDetected { get { throw null; } }
        public double? PercentCompleted { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> UnrestorableFiles { get { throw null; } }
    }
    public partial class ManagedDatabaseRestoreDetailsResultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedDatabaseRestoreDetailsResultResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string restoreDetailsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabaseSecurityAlertPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource>, System.Collections.IEnumerable
    {
        protected ManagedDatabaseSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource> Get(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource>> GetAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedDatabaseSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedDatabaseSecurityAlertPolicyData() { }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public bool? EmailAccountAdmins { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ManagedDatabaseSecurityAlertPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedDatabaseSecurityAlertPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceAdministratorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource>, System.Collections.IEnumerable
    {
        protected ManagedInstanceAdministratorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AdministratorName administratorName, Azure.ResourceManager.Sql.ManagedInstanceAdministratorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AdministratorName administratorName, Azure.ResourceManager.Sql.ManagedInstanceAdministratorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource> Get(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource>> GetAsync(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceAdministratorData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstanceAdministratorData() { }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceAdministratorType? AdministratorType { get { throw null; } set { } }
        public string Login { get { throw null; } set { } }
        public System.Guid? Sid { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class ManagedInstanceAdministratorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceAdministratorResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceAdministratorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string administratorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceAzureADOnlyAuthenticationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource>, System.Collections.IEnumerable
    {
        protected ManagedInstanceAzureADOnlyAuthenticationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource> Get(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource>> GetAsync(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceAzureADOnlyAuthenticationData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstanceAzureADOnlyAuthenticationData() { }
        public bool? AzureADOnlyAuthentication { get { throw null; } set { } }
    }
    public partial class ManagedInstanceAzureADOnlyAuthenticationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceAzureADOnlyAuthenticationResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string authenticationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceResource>, System.Collections.IEnumerable
    {
        protected ManagedInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedInstanceName, Azure.ResourceManager.Sql.ManagedInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedInstanceName, Azure.ResourceManager.Sql.ManagedInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedInstanceName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedInstanceName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceResource> Get(string managedInstanceName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceResource>> GetAsync(string managedInstanceName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedInstanceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceExternalAdministrator Administrators { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        public string DnsZone { get { throw null; } }
        public string DnsZonePartner { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string InstancePoolId { get { throw null; } set { } }
        public string KeyId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceLicenseType? LicenseType { get { throw null; } set { } }
        public string MaintenanceConfigurationId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedServerCreateMode? ManagedInstanceCreateMode { get { throw null; } set { } }
        public string MinimalTlsVersion { get { throw null; } set { } }
        public string PrimaryUserAssignedIdentityId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ManagedInstancePecProperty> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceProxyOverride? ProxyOverride { get { throw null; } set { } }
        public bool? PublicDataEndpointEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInOn { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public string SourceManagedInstanceId { get { throw null; } set { } }
        public string State { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        public int? StorageSizeInGB { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public string TimezoneId { get { throw null; } set { } }
        public int? VCores { get { throw null; } set { } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class ManagedInstanceDatabaseBackupShortTermRetentionPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource>, System.Collections.IEnumerable
    {
        protected ManagedInstanceDatabaseBackupShortTermRetentionPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource> Get(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource>> GetAsync(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string policyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaResource>, System.Collections.IEnumerable
    {
        protected ManagedInstanceDatabaseSchemaCollection() { }
        public virtual Azure.Response<bool> Exists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaResource> Get(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaResource>> GetAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchemaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseSchemaResource() { }
        public virtual Azure.ResourceManager.Sql.DatabaseSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string schemaName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableResource> GetManagedInstanceDatabaseSchemaTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableResource>> GetManagedInstanceDatabaseSchemaTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableCollection GetManagedInstanceDatabaseSchemaTables() { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchemaTableCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableResource>, System.Collections.IEnumerable
    {
        protected ManagedInstanceDatabaseSchemaTableCollection() { }
        public virtual Azure.Response<bool> Exists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableResource> Get(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableResource>> GetAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchemaTableColumnCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource>, System.Collections.IEnumerable
    {
        protected ManagedInstanceDatabaseSchemaTableColumnCollection() { }
        public virtual Azure.Response<bool> Exists(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource> Get(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource>> GetAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchemaTableColumnResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseSchemaTableColumnResource() { }
        public virtual Azure.ResourceManager.Sql.DatabaseColumnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName, string columnName) { throw null; }
        public virtual Azure.Response DisableRecommendationManagedDatabaseSensitivityLabel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableRecommendationManagedDatabaseSensitivityLabelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableRecommendationManagedDatabaseSensitivityLabel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableRecommendationManagedDatabaseSensitivityLabelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource> GetManagedInstanceDatabaseSchemaTableColumnSensitivityLabel(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource>> GetManagedInstanceDatabaseSchemaTableColumnSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelCollection GetManagedInstanceDatabaseSchemaTableColumnSensitivityLabels() { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelCollection : Azure.ResourceManager.ArmCollection
    {
        protected ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SensitivityLabelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SensitivityLabelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource> Get(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource>> GetAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource() { }
        public virtual Azure.ResourceManager.Sql.SensitivityLabelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName, string columnName, string sensitivityLabelSource) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchemaTableResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseSchemaTableResource() { }
        public virtual Azure.ResourceManager.Sql.DatabaseTableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource> GetManagedInstanceDatabaseSchemaTableColumn(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource>> GetManagedInstanceDatabaseSchemaTableColumnAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnCollection GetManagedInstanceDatabaseSchemaTableColumns() { throw null; }
    }
    public partial class ManagedInstanceDatabaseVulnerabilityAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource>, System.Collections.IEnumerable
    {
        protected ManagedInstanceDatabaseVulnerabilityAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource> Get(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource>> GetAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceDatabaseVulnerabilityAssessmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseVulnerabilityAssessmentResource() { }
        public virtual Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string vulnerabilityAssessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineResource> GetManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineResource>> GetManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineAsync(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineCollection GetManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanResource> GetManagedInstanceDatabaseVulnerabilityAssessmentScan(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanResource>> GetManagedInstanceDatabaseVulnerabilityAssessmentScanAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanCollection GetManagedInstanceDatabaseVulnerabilityAssessmentScans() { throw null; }
    }
    public partial class ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineCollection : Azure.ResourceManager.ArmCollection
    {
        protected ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentRuleBaselineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentRuleBaselineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineResource> Get(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineResource>> GetAsync(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineResource() { }
        public virtual Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentRuleBaselineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string vulnerabilityAssessmentName, string ruleId, string baselineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceDatabaseVulnerabilityAssessmentScanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanResource>, System.Collections.IEnumerable
    {
        protected ManagedInstanceDatabaseVulnerabilityAssessmentScanCollection() { }
        public virtual Azure.Response<bool> Exists(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanResource> Get(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanResource>> GetAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceDatabaseVulnerabilityAssessmentScanResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseVulnerabilityAssessmentScanResource() { }
        public virtual Azure.ResourceManager.Sql.VulnerabilityAssessmentScanRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string vulnerabilityAssessmentName, string scanId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentScansExport> Export(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentScansExport>> ExportAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation InitiateScan(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InitiateScanAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceEncryptionProtectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource>, System.Collections.IEnumerable
    {
        protected ManagedInstanceEncryptionProtectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource> Get(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource>> GetAsync(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceEncryptionProtectorData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstanceEncryptionProtectorData() { }
        public bool? AutoRotationEnabled { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public string ServerKeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ServerKeyType? ServerKeyType { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class ManagedInstanceEncryptionProtectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceEncryptionProtectorResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string encryptionProtectorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Revalidate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevalidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceKeyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceKeyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceKeyResource>, System.Collections.IEnumerable
    {
        protected ManagedInstanceKeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceKeyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.Sql.ManagedInstanceKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceKeyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.Sql.ManagedInstanceKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceKeyResource> Get(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceKeyResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceKeyResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceKeyResource>> GetAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceKeyData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstanceKeyData() { }
        public bool? AutoRotationEnabled { get { throw null; } }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ServerKeyType? ServerKeyType { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ManagedInstanceKeyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceKeyResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string keyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceKeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceKeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceLongTermRetentionBackupData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstanceLongTermRetentionBackupData() { }
        public System.DateTimeOffset? BackupExpirationOn { get { throw null; } }
        public System.DateTimeOffset? BackupOn { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.BackupStorageRedundancy? BackupStorageRedundancy { get { throw null; } }
        public System.DateTimeOffset? DatabaseDeletionOn { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? ManagedInstanceCreateOn { get { throw null; } }
        public string ManagedInstanceName { get { throw null; } }
    }
    public partial class ManagedInstanceLongTermRetentionPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource>, System.Collections.IEnumerable
    {
        protected ManagedInstanceLongTermRetentionPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource> Get(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource>> GetAsync(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceLongTermRetentionPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstanceLongTermRetentionPolicyData() { }
        public string MonthlyRetention { get { throw null; } set { } }
        public string WeeklyRetention { get { throw null; } set { } }
        public int? WeekOfYear { get { throw null; } set { } }
        public string YearlyRetention { get { throw null; } set { } }
    }
    public partial class ManagedInstanceLongTermRetentionPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceLongTermRetentionPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string policyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceOperationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceOperationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceOperationResource>, System.Collections.IEnumerable
    {
        protected ManagedInstanceOperationCollection() { }
        public virtual Azure.Response<bool> Exists(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperationResource> Get(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceOperationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceOperationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperationResource>> GetAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceOperationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceOperationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceOperationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceOperationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceOperationData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstanceOperationData() { }
        public string Description { get { throw null; } }
        public int? ErrorCode { get { throw null; } }
        public string ErrorDescription { get { throw null; } }
        public int? ErrorSeverity { get { throw null; } }
        public System.DateTimeOffset? EstimatedCompletionOn { get { throw null; } }
        public bool? IsCancellable { get { throw null; } }
        public bool? IsUserError { get { throw null; } }
        public string ManagedInstanceName { get { throw null; } }
        public string Operation { get { throw null; } }
        public string OperationFriendlyName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceOperationParametersPair OperationParameters { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceOperationSteps OperationSteps { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ManagementOperationState? State { get { throw null; } }
    }
    public partial class ManagedInstanceOperationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceOperationResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceOperationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string operationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstancePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected ManagedInstancePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstancePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstancePrivateEndpointConnectionData() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedInstancePrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ManagedInstancePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstancePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstancePrivateLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected ManagedInstancePrivateLinkCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstancePrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstancePrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstancePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstancePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstancePrivateLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstancePrivateLinkData() { }
        public Azure.ResourceManager.Sql.Models.ManagedInstancePrivateLinkProperties Properties { get { throw null; } }
    }
    public partial class ManagedInstancePrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstancePrivateLinkResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstancePrivateLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateManagedInstanceTdeCertificate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TdeCertificate tdeCertificate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateManagedInstanceTdeCertificateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TdeCertificate tdeCertificate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Failover(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ReplicaType? replicaType = default(Azure.ResourceManager.Sql.Models.ReplicaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ReplicaType? replicaType = default(Azure.ResourceManager.Sql.Models.ReplicaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedDatabaseResource> GetInaccessibleManagedDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedDatabaseResource> GetInaccessibleManagedDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseResource> GetManagedDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseResource>> GetManagedDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseCollection GetManagedDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource> GetManagedInstanceAdministrator(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource>> GetManagedInstanceAdministratorAsync(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceAdministratorCollection GetManagedInstanceAdministrators() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource> GetManagedInstanceAzureADOnlyAuthentication(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource>> GetManagedInstanceAzureADOnlyAuthenticationAsync(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationCollection GetManagedInstanceAzureADOnlyAuthentications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource> GetManagedInstanceEncryptionProtector(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource>> GetManagedInstanceEncryptionProtectorAsync(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorCollection GetManagedInstanceEncryptionProtectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceKeyResource> GetManagedInstanceKey(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceKeyResource>> GetManagedInstanceKeyAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceKeyCollection GetManagedInstanceKeys() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperationResource> GetManagedInstanceOperation(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperationResource>> GetManagedInstanceOperationAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceOperationCollection GetManagedInstanceOperations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource> GetManagedInstancePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource>> GetManagedInstancePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionCollection GetManagedInstancePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateLinkResource> GetManagedInstancePrivateLink(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateLinkResource>> GetManagedInstancePrivateLinkAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstancePrivateLinkCollection GetManagedInstancePrivateLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource> GetManagedInstanceVulnerabilityAssessment(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource>> GetManagedInstanceVulnerabilityAssessmentAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentCollection GetManagedInstanceVulnerabilityAssessments() { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyCollection GetManagedServerSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource> GetManagedServerSecurityAlertPolicy(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource>> GetManagedServerSecurityAlertPolicyAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecoverableManagedDatabaseResource> GetRecoverableManagedDatabase(string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecoverableManagedDatabaseResource>> GetRecoverableManagedDatabaseAsync(string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.RecoverableManagedDatabaseCollection GetRecoverableManagedDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource> GetRestorableDroppedManagedDatabase(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource>> GetRestorableDroppedManagedDatabaseAsync(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseCollection GetRestorableDroppedManagedDatabases() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerTrustGroupResource> GetServerTrustGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerTrustGroupResource> GetServerTrustGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SqlAgentConfigurationResource GetSqlAgentConfiguration() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.TopQueries> GetTopQueries(int? numberOfQueries = default(int?), string databases = null, string startTime = null, string endTime = null, Azure.ResourceManager.Sql.Models.QueryTimeGrainType? interval = default(Azure.ResourceManager.Sql.Models.QueryTimeGrainType?), Azure.ResourceManager.Sql.Models.AggregationFunctionType? aggregationFunction = default(Azure.ResourceManager.Sql.Models.AggregationFunctionType?), Azure.ResourceManager.Sql.Models.MetricType? observationMetric = default(Azure.ResourceManager.Sql.Models.MetricType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.TopQueries> GetTopQueriesAsync(int? numberOfQueries = default(int?), string databases = null, string startTime = null, string endTime = null, Azure.ResourceManager.Sql.Models.QueryTimeGrainType? interval = default(Azure.ResourceManager.Sql.Models.QueryTimeGrainType?), Azure.ResourceManager.Sql.Models.AggregationFunctionType? aggregationFunction = default(Azure.ResourceManager.Sql.Models.AggregationFunctionType?), Azure.ResourceManager.Sql.Models.MetricType? observationMetric = default(Azure.ResourceManager.Sql.Models.MetricType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceVulnerabilityAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource>, System.Collections.IEnumerable
    {
        protected ManagedInstanceVulnerabilityAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource> Get(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource>> GetAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceVulnerabilityAssessmentData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstanceVulnerabilityAssessmentData() { }
        public Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageContainerPath { get { throw null; } set { } }
        public string StorageContainerSasKey { get { throw null; } set { } }
    }
    public partial class ManagedInstanceVulnerabilityAssessmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceVulnerabilityAssessmentResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string vulnerabilityAssessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedRestorableDroppedDbBackupShortTermRetentionPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource>, System.Collections.IEnumerable
    {
        protected ManagedRestorableDroppedDbBackupShortTermRetentionPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource> Get(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource>> GetAsync(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string restorableDroppedDatabaseId, string policyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedServerSecurityAlertPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource>, System.Collections.IEnumerable
    {
        protected ManagedServerSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource> Get(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource>> GetAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedServerSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedServerSecurityAlertPolicyData() { }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public bool? EmailAccountAdmins { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecurityAlertsPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ManagedServerSecurityAlertPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedServerSecurityAlertPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedTransparentDataEncryptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource>, System.Collections.IEnumerable
    {
        protected ManagedTransparentDataEncryptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource> Get(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource>> GetAsync(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedTransparentDataEncryptionData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedTransparentDataEncryptionData() { }
        public Azure.ResourceManager.Sql.Models.TransparentDataEncryptionState? State { get { throw null; } set { } }
    }
    public partial class ManagedTransparentDataEncryptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedTransparentDataEncryptionResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string tdeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OutboundFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.OutboundFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.OutboundFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected OutboundFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.OutboundFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string outboundRuleFqdn, Azure.ResourceManager.Sql.OutboundFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.OutboundFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string outboundRuleFqdn, Azure.ResourceManager.Sql.OutboundFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string outboundRuleFqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string outboundRuleFqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.OutboundFirewallRuleResource> Get(string outboundRuleFqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.OutboundFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.OutboundFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.OutboundFirewallRuleResource>> GetAsync(string outboundRuleFqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.OutboundFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.OutboundFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.OutboundFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.OutboundFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OutboundFirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public OutboundFirewallRuleData() { }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class OutboundFirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OutboundFirewallRuleResource() { }
        public virtual Azure.ResourceManager.Sql.OutboundFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string outboundRuleFqdn) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.OutboundFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.OutboundFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Sql.PrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Sql.PrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateEndpointConnectionData() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Sql.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateLinkResource() { }
        public virtual Azure.ResourceManager.Sql.PrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.PrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.PrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.PrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.PrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.PrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.PrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.PrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.PrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.PrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.PrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.PrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.PrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateLinkResourceData() { }
        public Azure.ResourceManager.Sql.Models.PrivateLinkResourceProperties Properties { get { throw null; } }
    }
    public partial class RecommendedActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RecommendedActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RecommendedActionResource>, System.Collections.IEnumerable
    {
        protected RecommendedActionCollection() { }
        public virtual Azure.Response<bool> Exists(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecommendedActionResource> Get(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.RecommendedActionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.RecommendedActionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecommendedActionResource>> GetAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.RecommendedActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RecommendedActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.RecommendedActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RecommendedActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecommendedActionData : Azure.ResourceManager.Models.ResourceData
    {
        public RecommendedActionData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Details { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.RecommendedActionErrorInfo ErrorDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.RecommendedActionImpactRecord> EstimatedImpact { get { throw null; } }
        public System.TimeSpan? ExecuteActionDuration { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.RecommendedActionInitiatedBy? ExecuteActionInitiatedBy { get { throw null; } }
        public System.DateTimeOffset? ExecuteActionInitiatedOn { get { throw null; } }
        public System.DateTimeOffset? ExecuteActionStartOn { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.RecommendedActionImplementationInfo ImplementationDetails { get { throw null; } }
        public bool? IsArchivedAction { get { throw null; } }
        public bool? IsExecutableAction { get { throw null; } }
        public bool? IsRevertableAction { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.DateTimeOffset? LastRefresh { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> LinkedObjects { get { throw null; } }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.RecommendedActionImpactRecord> ObservedImpact { get { throw null; } }
        public string RecommendationReason { get { throw null; } }
        public System.TimeSpan? RevertActionDuration { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.RecommendedActionInitiatedBy? RevertActionInitiatedBy { get { throw null; } }
        public System.DateTimeOffset? RevertActionInitiatedOn { get { throw null; } }
        public System.DateTimeOffset? RevertActionStartOn { get { throw null; } }
        public int? Score { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.RecommendedActionStateInfo State { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.RecommendedActionMetricInfo> TimeSeries { get { throw null; } }
        public System.DateTimeOffset? ValidSince { get { throw null; } }
    }
    public partial class RecommendedActionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecommendedActionResource() { }
        public virtual Azure.ResourceManager.Sql.RecommendedActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string advisorName, string recommendedActionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecommendedActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecommendedActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecommendedActionResource> Update(Azure.ResourceManager.Sql.RecommendedActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecommendedActionResource>> UpdateAsync(Azure.ResourceManager.Sql.RecommendedActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoverableDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RecoverableDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RecoverableDatabaseResource>, System.Collections.IEnumerable
    {
        protected RecoverableDatabaseCollection() { }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecoverableDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.RecoverableDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.RecoverableDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecoverableDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.RecoverableDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RecoverableDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.RecoverableDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RecoverableDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoverableDatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public RecoverableDatabaseData() { }
        public string Edition { get { throw null; } }
        public string ElasticPoolName { get { throw null; } }
        public System.DateTimeOffset? LastAvailableBackupOn { get { throw null; } }
        public string ServiceLevelObjective { get { throw null; } }
    }
    public partial class RecoverableDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoverableDatabaseResource() { }
        public virtual Azure.ResourceManager.Sql.RecoverableDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecoverableDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecoverableDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoverableManagedDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RecoverableManagedDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RecoverableManagedDatabaseResource>, System.Collections.IEnumerable
    {
        protected RecoverableManagedDatabaseCollection() { }
        public virtual Azure.Response<bool> Exists(string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecoverableManagedDatabaseResource> Get(string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.RecoverableManagedDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.RecoverableManagedDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecoverableManagedDatabaseResource>> GetAsync(string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.RecoverableManagedDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RecoverableManagedDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.RecoverableManagedDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RecoverableManagedDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoverableManagedDatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public RecoverableManagedDatabaseData() { }
        public string LastAvailableBackupDate { get { throw null; } }
    }
    public partial class RecoverableManagedDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoverableManagedDatabaseResource() { }
        public virtual Azure.ResourceManager.Sql.RecoverableManagedDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string recoverableDatabaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecoverableManagedDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecoverableManagedDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReplicationLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ReplicationLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ReplicationLinkResource>, System.Collections.IEnumerable
    {
        protected ReplicationLinkCollection() { }
        public virtual Azure.Response<bool> Exists(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ReplicationLinkResource> Get(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ReplicationLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ReplicationLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ReplicationLinkResource>> GetAsync(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ReplicationLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ReplicationLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ReplicationLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ReplicationLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReplicationLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public ReplicationLinkData() { }
        public bool? IsTerminationAllowed { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ReplicationLinkType? LinkType { get { throw null; } }
        public string PartnerDatabase { get { throw null; } }
        public string PartnerLocation { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ReplicationRole? PartnerRole { get { throw null; } }
        public string PartnerServer { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public string ReplicationMode { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ReplicationState? ReplicationState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ReplicationRole? Role { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class ReplicationLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReplicationLinkResource() { }
        public virtual Azure.ResourceManager.Sql.ReplicationLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string linkId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Failover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation FailoverAllowDataLoss(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAllowDataLossAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ReplicationLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ReplicationLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Unlink(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.UnlinkContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UnlinkAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.UnlinkContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupLongTermRetentionBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>, System.Collections.IEnumerable
    {
        protected ResourceGroupLongTermRetentionBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> GetAll(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> GetAllAsync(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGroupLongTermRetentionBackupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGroupLongTermRetentionBackupResource() { }
        public virtual Azure.ResourceManager.Sql.LongTermRetentionBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult> CopyByResourceGroup(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CopyLongTermRetentionBackupOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult>> CopyByResourceGroupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CopyLongTermRetentionBackupOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult> UpdateByResourceGroup(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.UpdateLongTermRetentionBackupOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult>> UpdateByResourceGroupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.UpdateLongTermRetentionBackupOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupLongTermRetentionManagedInstanceBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource>, System.Collections.IEnumerable
    {
        protected ResourceGroupLongTermRetentionManagedInstanceBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource> GetAll(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource> GetAllAsync(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGroupLongTermRetentionManagedInstanceBackupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGroupLongTermRetentionManagedInstanceBackupResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string locationName, string managedInstanceName, string databaseName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorableDroppedDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource>, System.Collections.IEnumerable
    {
        protected RestorableDroppedDatabaseCollection() { }
        public virtual Azure.Response<bool> Exists(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource> Get(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource>> GetAsync(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorableDroppedDatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public RestorableDroppedDatabaseData() { }
        public Azure.ResourceManager.Sql.Models.RestorableDroppedDatabasePropertiesBackupStorageRedundancy? BackupStorageRedundancy { get { throw null; } }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? DeletionOn { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public string ElasticPoolId { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public long? MaxSizeBytes { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class RestorableDroppedDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorableDroppedDatabaseResource() { }
        public virtual Azure.ResourceManager.Sql.RestorableDroppedDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string restorableDroppedDatabaseId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorableDroppedManagedDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource>, System.Collections.IEnumerable
    {
        protected RestorableDroppedManagedDatabaseCollection() { }
        public virtual Azure.Response<bool> Exists(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource> Get(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource>> GetAsync(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorableDroppedManagedDatabaseData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RestorableDroppedManagedDatabaseData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? DeletionOn { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
    }
    public partial class RestorableDroppedManagedDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorableDroppedManagedDatabaseResource() { }
        public virtual Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string restorableDroppedDatabaseId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyCollection GetManagedRestorableDroppedDbBackupShortTermRetentionPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource> GetManagedRestorableDroppedDbBackupShortTermRetentionPolicy(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource>> GetManagedRestorableDroppedDbBackupShortTermRetentionPolicyAsync(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RestorePointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RestorePointResource>, System.Collections.IEnumerable
    {
        protected RestorePointCollection() { }
        public virtual Azure.Response<bool> Exists(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorePointResource> Get(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.RestorePointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.RestorePointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorePointResource>> GetAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.RestorePointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RestorePointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.RestorePointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RestorePointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorePointData : Azure.ResourceManager.Models.ResourceData
    {
        public RestorePointData() { }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public string Location { get { throw null; } }
        public System.DateTimeOffset? RestorePointCreationOn { get { throw null; } }
        public string RestorePointLabel { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.RestorePointType? RestorePointType { get { throw null; } }
    }
    public partial class RestorePointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorePointResource() { }
        public virtual Azure.ResourceManager.Sql.RestorePointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string restorePointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorePointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorePointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SensitivityLabelData : Azure.ResourceManager.Models.ResourceData
    {
        public SensitivityLabelData() { }
        public string ColumnName { get { throw null; } }
        public string InformationType { get { throw null; } set { } }
        public string InformationTypeId { get { throw null; } set { } }
        public bool? IsDisabled { get { throw null; } }
        public string LabelId { get { throw null; } set { } }
        public string LabelName { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SensitivityLabelRank? Rank { get { throw null; } set { } }
        public string SchemaName { get { throw null; } }
        public string TableName { get { throw null; } }
    }
    public partial class ServerAdvisorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerAdvisorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerAdvisorResource>, System.Collections.IEnumerable
    {
        protected ServerAdvisorCollection() { }
        public virtual Azure.Response<bool> Exists(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAdvisorResource> Get(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerAdvisorResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerAdvisorResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAdvisorResource>> GetAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerAdvisorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerAdvisorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerAdvisorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerAdvisorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerAdvisorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerAdvisorResource() { }
        public virtual Azure.ResourceManager.Sql.AdvisorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string advisorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAdvisorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAdvisorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAdvisorResource> Update(Azure.ResourceManager.Sql.AdvisorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAdvisorResource>> UpdateAsync(Azure.ResourceManager.Sql.AdvisorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAutomaticTuningData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerAutomaticTuningData() { }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningServerMode? ActualState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningServerMode? DesiredState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Sql.Models.AutomaticTuningServerOptions> Options { get { throw null; } }
    }
    public partial class ServerAutomaticTuningResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerAutomaticTuningResource() { }
        public virtual Azure.ResourceManager.Sql.ServerAutomaticTuningData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAutomaticTuningResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAutomaticTuningResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAutomaticTuningResource> Update(Azure.ResourceManager.Sql.ServerAutomaticTuningData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAutomaticTuningResource>> UpdateAsync(Azure.ResourceManager.Sql.ServerAutomaticTuningData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAzureADAdministratorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource>, System.Collections.IEnumerable
    {
        protected ServerAzureADAdministratorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AdministratorName administratorName, Azure.ResourceManager.Sql.ServerAzureADAdministratorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AdministratorName administratorName, Azure.ResourceManager.Sql.ServerAzureADAdministratorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource> Get(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource>> GetAsync(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerAzureADAdministratorData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerAzureADAdministratorData() { }
        public Azure.ResourceManager.Sql.Models.AdministratorType? AdministratorType { get { throw null; } set { } }
        public bool? AzureADOnlyAuthentication { get { throw null; } }
        public string Login { get { throw null; } set { } }
        public System.Guid? Sid { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class ServerAzureADAdministratorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerAzureADAdministratorResource() { }
        public virtual Azure.ResourceManager.Sql.ServerAzureADAdministratorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string administratorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAzureADOnlyAuthenticationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource>, System.Collections.IEnumerable
    {
        protected ServerAzureADOnlyAuthenticationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource> Get(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource>> GetAsync(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerAzureADOnlyAuthenticationData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerAzureADOnlyAuthenticationData() { }
        public bool? AzureADOnlyAuthentication { get { throw null; } set { } }
    }
    public partial class ServerAzureADOnlyAuthenticationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerAzureADOnlyAuthenticationResource() { }
        public virtual Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string authenticationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerBlobAuditingPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource>, System.Collections.IEnumerable
    {
        protected ServerBlobAuditingPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.ServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.ServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource> Get(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource>> GetAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerBlobAuditingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerBlobAuditingPolicyData() { }
        public System.Collections.Generic.IList<string> AuditActionsAndGroups { get { throw null; } }
        public bool? IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public bool? IsDevopsAuditEnabled { get { throw null; } set { } }
        public bool? IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public int? QueueDelayMs { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.BlobAuditingPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public System.Guid? StorageAccountSubscriptionId { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ServerBlobAuditingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerBlobAuditingPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.ServerBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string blobAuditingPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerCommunicationLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerCommunicationLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerCommunicationLinkResource>, System.Collections.IEnumerable
    {
        protected ServerCommunicationLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerCommunicationLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string communicationLinkName, Azure.ResourceManager.Sql.ServerCommunicationLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerCommunicationLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string communicationLinkName, Azure.ResourceManager.Sql.ServerCommunicationLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerCommunicationLinkResource> Get(string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerCommunicationLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerCommunicationLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerCommunicationLinkResource>> GetAsync(string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerCommunicationLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerCommunicationLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerCommunicationLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerCommunicationLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerCommunicationLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerCommunicationLinkData() { }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } }
        public string PartnerServer { get { throw null; } set { } }
        public string State { get { throw null; } }
    }
    public partial class ServerCommunicationLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerCommunicationLinkResource() { }
        public virtual Azure.ResourceManager.Sql.ServerCommunicationLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string communicationLinkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerCommunicationLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerCommunicationLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerConnectionPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerConnectionPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerConnectionPolicyResource>, System.Collections.IEnumerable
    {
        protected ServerConnectionPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerConnectionPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, Azure.ResourceManager.Sql.ServerConnectionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerConnectionPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, Azure.ResourceManager.Sql.ServerConnectionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerConnectionPolicyResource> Get(Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerConnectionPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerConnectionPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerConnectionPolicyResource>> GetAsync(Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerConnectionPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerConnectionPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerConnectionPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerConnectionPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerConnectionPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerConnectionPolicyData() { }
        public Azure.ResourceManager.Sql.Models.ServerConnectionType? ConnectionType { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } }
    }
    public partial class ServerConnectionPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerConnectionPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.ServerConnectionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string connectionPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerConnectionPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerConnectionPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDatabaseAdvisorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource>, System.Collections.IEnumerable
    {
        protected ServerDatabaseAdvisorCollection() { }
        public virtual Azure.Response<bool> Exists(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource> Get(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource>> GetAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerDatabaseAdvisorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseAdvisorResource() { }
        public virtual Azure.ResourceManager.Sql.AdvisorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string advisorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecommendedActionResource> GetRecommendedAction(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecommendedActionResource>> GetRecommendedActionAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.RecommendedActionCollection GetRecommendedActions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource> Update(Azure.ResourceManager.Sql.AdvisorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource>> UpdateAsync(Azure.ResourceManager.Sql.AdvisorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDatabaseSchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaResource>, System.Collections.IEnumerable
    {
        protected ServerDatabaseSchemaCollection() { }
        public virtual Azure.Response<bool> Exists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaResource> Get(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaResource>> GetAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDatabaseSchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDatabaseSchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerDatabaseSchemaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseSchemaResource() { }
        public virtual Azure.ResourceManager.Sql.DatabaseSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string schemaName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableResource> GetServerDatabaseSchemaTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableResource>> GetServerDatabaseSchemaTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseSchemaTableCollection GetServerDatabaseSchemaTables() { throw null; }
    }
    public partial class ServerDatabaseSchemaTableCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableResource>, System.Collections.IEnumerable
    {
        protected ServerDatabaseSchemaTableCollection() { }
        public virtual Azure.Response<bool> Exists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableResource> Get(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableResource>> GetAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerDatabaseSchemaTableColumnCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource>, System.Collections.IEnumerable
    {
        protected ServerDatabaseSchemaTableColumnCollection() { }
        public virtual Azure.Response<bool> Exists(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource> Get(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource>> GetAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerDatabaseSchemaTableColumnResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseSchemaTableColumnResource() { }
        public virtual Azure.ResourceManager.Sql.DatabaseColumnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName, string columnName) { throw null; }
        public virtual Azure.Response DisableRecommendationSensitivityLabel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableRecommendationSensitivityLabelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableRecommendationSensitivityLabel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableRecommendationSensitivityLabelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabelResource> GetServerDatabaseSchemaTableColumnSensitivityLabel(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabelResource>> GetServerDatabaseSchemaTableColumnSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabelCollection GetServerDatabaseSchemaTableColumnSensitivityLabels() { throw null; }
    }
    public partial class ServerDatabaseSchemaTableColumnSensitivityLabelCollection : Azure.ResourceManager.ArmCollection
    {
        protected ServerDatabaseSchemaTableColumnSensitivityLabelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SensitivityLabelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SensitivityLabelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabelResource> Get(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabelResource>> GetAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDatabaseSchemaTableColumnSensitivityLabelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseSchemaTableColumnSensitivityLabelResource() { }
        public virtual Azure.ResourceManager.Sql.SensitivityLabelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName, string columnName, string sensitivityLabelSource) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDatabaseSchemaTableResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseSchemaTableResource() { }
        public virtual Azure.ResourceManager.Sql.DatabaseTableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource> GetServerDatabaseSchemaTableColumn(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource>> GetServerDatabaseSchemaTableColumnAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnCollection GetServerDatabaseSchemaTableColumns() { throw null; }
    }
    public partial class ServerDatabaseVulnerabilityAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource>, System.Collections.IEnumerable
    {
        protected ServerDatabaseVulnerabilityAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource> Get(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource>> GetAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerDatabaseVulnerabilityAssessmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseVulnerabilityAssessmentResource() { }
        public virtual Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string vulnerabilityAssessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaselineResource> GetServerDatabaseVulnerabilityAssessmentRuleBaseline(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaselineResource>> GetServerDatabaseVulnerabilityAssessmentRuleBaselineAsync(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaselineCollection GetServerDatabaseVulnerabilityAssessmentRuleBaselines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanResource> GetServerDatabaseVulnerabilityAssessmentScan(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanResource>> GetServerDatabaseVulnerabilityAssessmentScanAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanCollection GetServerDatabaseVulnerabilityAssessmentScans() { throw null; }
    }
    public partial class ServerDatabaseVulnerabilityAssessmentRuleBaselineCollection : Azure.ResourceManager.ArmCollection
    {
        protected ServerDatabaseVulnerabilityAssessmentRuleBaselineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaselineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentRuleBaselineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaselineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentRuleBaselineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaselineResource> Get(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaselineResource>> GetAsync(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDatabaseVulnerabilityAssessmentRuleBaselineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseVulnerabilityAssessmentRuleBaselineResource() { }
        public virtual Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentRuleBaselineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string vulnerabilityAssessmentName, string ruleId, string baselineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaselineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaselineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDatabaseVulnerabilityAssessmentScanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanResource>, System.Collections.IEnumerable
    {
        protected ServerDatabaseVulnerabilityAssessmentScanCollection() { }
        public virtual Azure.Response<bool> Exists(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanResource> Get(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanResource>> GetAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerDatabaseVulnerabilityAssessmentScanResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseVulnerabilityAssessmentScanResource() { }
        public virtual Azure.ResourceManager.Sql.VulnerabilityAssessmentScanRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string vulnerabilityAssessmentName, string scanId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentScansExport> Export(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentScansExport>> ExportAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation InitiateScan(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InitiateScanAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDevOpsAuditingSettingsCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource>, System.Collections.IEnumerable
    {
        protected ServerDevOpsAuditingSettingsCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string devOpsAuditingSettingsName, Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string devOpsAuditingSettingsName, Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string devOpsAuditingSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string devOpsAuditingSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource> Get(string devOpsAuditingSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource>> GetAsync(string devOpsAuditingSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerDevOpsAuditingSettingsData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerDevOpsAuditingSettingsData() { }
        public bool? IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.BlobAuditingPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public System.Guid? StorageAccountSubscriptionId { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ServerDevOpsAuditingSettingsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDevOpsAuditingSettingsResource() { }
        public virtual Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string devOpsAuditingSettingsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDnsAliasCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDnsAliasResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDnsAliasResource>, System.Collections.IEnumerable
    {
        protected ServerDnsAliasCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDnsAliasResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDnsAliasResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDnsAliasResource> Get(string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDnsAliasResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDnsAliasResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDnsAliasResource>> GetAsync(string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDnsAliasResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDnsAliasResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDnsAliasResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDnsAliasResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerDnsAliasData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerDnsAliasData() { }
        public string AzureDnsRecord { get { throw null; } }
    }
    public partial class ServerDnsAliasResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDnsAliasResource() { }
        public virtual Azure.ResourceManager.Sql.ServerDnsAliasData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDnsAliasResource> Acquire(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ServerDnsAliasAcquisition serverDnsAliasAcquisition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDnsAliasResource>> AcquireAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ServerDnsAliasAcquisition serverDnsAliasAcquisition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string dnsAliasName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDnsAliasResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDnsAliasResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerJobAgentJobExecutionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource>, System.Collections.IEnumerable
    {
        protected ServerJobAgentJobExecutionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource> Get(System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource> GetAll(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource> GetAllAsync(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource>> GetAsync(System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource> GetJobTargetExecutions(System.Guid jobExecutionId, System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource> GetJobTargetExecutionsAsync(System.Guid jobExecutionId, System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerJobAgentJobExecutionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerJobAgentJobExecutionResource() { }
        public virtual Azure.ResourceManager.Sql.JobExecutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, string jobExecutionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepResource> GetServerJobAgentJobExecutionStep(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepResource>> GetServerJobAgentJobExecutionStepAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepCollection GetServerJobAgentJobExecutionSteps() { throw null; }
    }
    public partial class ServerJobAgentJobExecutionStepCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepResource>, System.Collections.IEnumerable
    {
        protected ServerJobAgentJobExecutionStepCollection() { }
        public virtual Azure.Response<bool> Exists(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepResource> Get(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepResource> GetAll(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepResource> GetAllAsync(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepResource>> GetAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerJobAgentJobExecutionStepResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerJobAgentJobExecutionStepResource() { }
        public virtual Azure.ResourceManager.Sql.JobExecutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, string jobExecutionId, string stepName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource> GetServerJobAgentJobExecutionStepTarget(System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource>> GetServerJobAgentJobExecutionStepTargetAsync(System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetCollection GetServerJobAgentJobExecutionStepTargets() { throw null; }
    }
    public partial class ServerJobAgentJobExecutionStepTargetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource>, System.Collections.IEnumerable
    {
        protected ServerJobAgentJobExecutionStepTargetCollection() { }
        public virtual Azure.Response<bool> Exists(System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource> Get(System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource> GetAll(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource> GetAllAsync(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource>> GetAsync(System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerJobAgentJobExecutionStepTargetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerJobAgentJobExecutionStepTargetResource() { }
        public virtual Azure.ResourceManager.Sql.JobExecutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, string jobExecutionId, string stepName, string targetId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerJobAgentJobStepCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource>, System.Collections.IEnumerable
    {
        protected ServerJobAgentJobStepCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string stepName, Azure.ResourceManager.Sql.JobStepData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string stepName, Azure.ResourceManager.Sql.JobStepData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource> Get(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource>> GetAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerJobAgentJobStepResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerJobAgentJobStepResource() { }
        public virtual Azure.ResourceManager.Sql.JobStepData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, string stepName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerJobAgentJobVersionStepCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepResource>, System.Collections.IEnumerable
    {
        protected ServerJobAgentJobVersionStepCollection() { }
        public virtual Azure.Response<bool> Exists(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepResource> Get(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepResource>> GetAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerJobAgentJobVersionStepResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerJobAgentJobVersionStepResource() { }
        public virtual Azure.ResourceManager.Sql.JobStepData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, string jobVersion, string stepName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerKeyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerKeyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerKeyResource>, System.Collections.IEnumerable
    {
        protected ServerKeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerKeyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.Sql.ServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerKeyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.Sql.ServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerKeyResource> Get(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerKeyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerKeyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerKeyResource>> GetAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerKeyData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerKeyData() { }
        public bool? AutoRotationEnabled { get { throw null; } }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ServerKeyType? ServerKeyType { get { throw null; } set { } }
        public string Subregion { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ServerKeyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerKeyResource() { }
        public virtual Azure.ResourceManager.Sql.ServerKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string keyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerKeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerKeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerSecurityAlertPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource>, System.Collections.IEnumerable
    {
        protected ServerSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.ServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.ServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource> Get(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource>> GetAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerSecurityAlertPolicyData() { }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public bool? EmailAccountAdmins { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecurityAlertsPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ServerSecurityAlertPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerSecurityAlertPolicyResource() { }
        public virtual Azure.ResourceManager.Sql.ServerSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerTrustGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerTrustGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerTrustGroupResource>, System.Collections.IEnumerable
    {
        protected ServerTrustGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerTrustGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverTrustGroupName, Azure.ResourceManager.Sql.ServerTrustGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerTrustGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverTrustGroupName, Azure.ResourceManager.Sql.ServerTrustGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverTrustGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverTrustGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerTrustGroupResource> Get(string serverTrustGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerTrustGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerTrustGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerTrustGroupResource>> GetAsync(string serverTrustGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerTrustGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerTrustGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerTrustGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerTrustGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerTrustGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerTrustGroupData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.ServerInfo> GroupMembers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.ServerTrustGroupPropertiesTrustScopesItem> TrustScopes { get { throw null; } }
    }
    public partial class ServerTrustGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerTrustGroupResource() { }
        public virtual Azure.ResourceManager.Sql.ServerTrustGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string locationName, string serverTrustGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerTrustGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerTrustGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerVulnerabilityAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource>, System.Collections.IEnumerable
    {
        protected ServerVulnerabilityAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource> Get(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource>> GetAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerVulnerabilityAssessmentData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerVulnerabilityAssessmentData() { }
        public Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageContainerPath { get { throw null; } set { } }
        public string StorageContainerSasKey { get { throw null; } set { } }
    }
    public partial class ServerVulnerabilityAssessmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerVulnerabilityAssessmentResource() { }
        public virtual Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string vulnerabilityAssessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceObjectiveCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServiceObjectiveResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServiceObjectiveResource>, System.Collections.IEnumerable
    {
        protected ServiceObjectiveCollection() { }
        public virtual Azure.Response<bool> Exists(string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServiceObjectiveResource> Get(string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServiceObjectiveResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServiceObjectiveResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServiceObjectiveResource>> GetAsync(string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServiceObjectiveResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServiceObjectiveResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServiceObjectiveResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServiceObjectiveResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceObjectiveData : Azure.ResourceManager.Models.ResourceData
    {
        public ServiceObjectiveData() { }
        public string Description { get { throw null; } }
        public bool? Enabled { get { throw null; } }
        public bool? IsDefault { get { throw null; } }
        public bool? IsSystem { get { throw null; } }
        public string ServiceObjectiveName { get { throw null; } }
    }
    public partial class ServiceObjectiveResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceObjectiveResource() { }
        public virtual Azure.ResourceManager.Sql.ServiceObjectiveData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string serviceObjectiveName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServiceObjectiveResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServiceObjectiveResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlAgentConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlAgentConfigurationData() { }
        public Azure.ResourceManager.Sql.Models.SqlAgentConfigurationPropertiesState? State { get { throw null; } set { } }
    }
    public partial class SqlAgentConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlAgentConfigurationResource() { }
        public virtual Azure.ResourceManager.Sql.SqlAgentConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlAgentConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SqlAgentConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlAgentConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SqlAgentConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlAgentConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlAgentConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlDatabaseResource>, System.Collections.IEnumerable
    {
        protected SqlDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Sql.SqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Sql.SqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlDatabaseResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlDatabaseResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SqlDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SqlDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlDatabaseData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SqlDatabaseData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public int? AutoPauseDelay { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CatalogCollationType? CatalogCollation { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CurrentBackupStorageRedundancy? CurrentBackupStorageRedundancy { get { throw null; } }
        public string CurrentServiceObjectiveName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SqlSku CurrentSku { get { throw null; } }
        public System.Guid? DatabaseId { get { throw null; } }
        public string DefaultSecondaryLocation { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public string ElasticPoolId { get { throw null; } set { } }
        public string FailoverGroupId { get { throw null; } }
        public int? HighAvailabilityReplicaCount { get { throw null; } set { } }
        public bool? IsInfraEncryptionEnabled { get { throw null; } }
        public bool? IsLedgerOn { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.DatabaseLicenseType? LicenseType { get { throw null; } set { } }
        public string LongTermRetentionBackupResourceId { get { throw null; } set { } }
        public string MaintenanceConfigurationId { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } }
        public long? MaxLogSizeBytes { get { throw null; } }
        public long? MaxSizeBytes { get { throw null; } set { } }
        public double? MinCapacity { get { throw null; } set { } }
        public System.DateTimeOffset? PausedOn { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.DatabaseReadScale? ReadScale { get { throw null; } set { } }
        public string RecoverableDatabaseId { get { throw null; } set { } }
        public string RecoveryServicesRecoveryPointId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.RequestedBackupStorageRedundancy? RequestedBackupStorageRedundancy { get { throw null; } set { } }
        public string RequestedServiceObjectiveName { get { throw null; } }
        public string RestorableDroppedDatabaseId { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInOn { get { throw null; } set { } }
        public System.DateTimeOffset? ResumedOn { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SampleSchemaName? SampleName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecondaryType? SecondaryType { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? SourceDatabaseDeletionOn { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.DatabaseStatus? Status { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class SqlDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlDatabaseResource() { }
        public virtual Azure.ResourceManager.Sql.SqlDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelDatabaseOperation(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelDatabaseOperationAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportExtensionsOperationResult> CreateOrUpdateDatabaseExtension(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Sql.Models.DatabaseExtensions databaseExtensions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportExtensionsOperationResult>> CreateOrUpdateDatabaseExtensionAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Sql.Models.DatabaseExtensions databaseExtensions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.RestorePointResource> CreateRestorePoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CreateDatabaseRestorePointDefinition createDatabaseRestorePointDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.RestorePointResource>> CreateRestorePointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CreateDatabaseRestorePointDefinition createDatabaseRestorePointDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportOperationResult> Export(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ExportDatabaseDefinition exportDatabaseDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportOperationResult>> ExportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ExportDatabaseDefinition exportDatabaseDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Failover(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ReplicaType? replicaType = default(Azure.ResourceManager.Sql.Models.ReplicaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ReplicaType? replicaType = default(Azure.ResourceManager.Sql.Models.ReplicaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyCollection GetBackupShortTermRetentionPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource> GetBackupShortTermRetentionPolicy(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource>> GetBackupShortTermRetentionPolicyAsync(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabelResource> GetCurrentSensitivityLabels(string skipToken = null, bool? count = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabelResource> GetCurrentSensitivityLabelsAsync(string skipToken = null, bool? count = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabaseAutomaticTuningResource GetDatabaseAutomaticTuning() { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyCollection GetDatabaseBlobAuditingPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource> GetDatabaseBlobAuditingPolicy(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource>> GetDatabaseBlobAuditingPolicyAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource> GetDatabaseColumns(System.Collections.Generic.IEnumerable<string> schema = null, System.Collections.Generic.IEnumerable<string> table = null, System.Collections.Generic.IEnumerable<string> column = null, System.Collections.Generic.IEnumerable<string> orderBy = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource> GetDatabaseColumnsAsync(System.Collections.Generic.IEnumerable<string> schema = null, System.Collections.Generic.IEnumerable<string> table = null, System.Collections.Generic.IEnumerable<string> column = null, System.Collections.Generic.IEnumerable<string> orderBy = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ImportExportExtensionsOperationResult> GetDatabaseExtensions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ImportExportExtensionsOperationResult> GetDatabaseExtensionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.DatabaseOperation> GetDatabaseOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.DatabaseOperation> GetDatabaseOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyCollection GetDatabaseSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource> GetDatabaseSecurityAlertPolicy(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource>> GetDatabaseSecurityAlertPolicyAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.DatabaseUsage> GetDatabaseUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.DatabaseUsage> GetDatabaseUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DataMaskingPolicyResource GetDataMaskingPolicy() { throw null; }
        public virtual Azure.ResourceManager.Sql.DataWarehouseUserActivitiesCollection GetDataWarehouseUserActivities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DataWarehouseUserActivitiesResource> GetDataWarehouseUserActivities(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DataWarehouseUserActivitiesResource>> GetDataWarehouseUserActivitiesAsync(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyCollection GetExtendedDatabaseBlobAuditingPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource> GetExtendedDatabaseBlobAuditingPolicy(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource>> GetExtendedDatabaseBlobAuditingPolicyAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.GeoBackupPolicyCollection GetGeoBackupPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.GeoBackupPolicyResource> GetGeoBackupPolicy(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.GeoBackupPolicyResource>> GetGeoBackupPolicyAsync(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.LedgerDigestUploadsCollection GetLedgerDigestUploads() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LedgerDigestUploadsResource> GetLedgerDigestUploads(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LedgerDigestUploadsResource>> GetLedgerDigestUploadsAsync(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource> GetLogicalDatabaseTransparentDataEncryption(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource>> GetLogicalDatabaseTransparentDataEncryptionAsync(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionCollection GetLogicalDatabaseTransparentDataEncryptions() { throw null; }
        public virtual Azure.ResourceManager.Sql.LongTermRetentionPolicyCollection GetLongTermRetentionPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource> GetLongTermRetentionPolicy(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LongTermRetentionPolicyResource>> GetLongTermRetentionPolicyAsync(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.MaintenanceWindowOptionsResource GetMaintenanceWindowOptions() { throw null; }
        public virtual Azure.ResourceManager.Sql.MaintenanceWindowsResource GetMaintenanceWindows() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.MetricDefinition> GetMetricDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.MetricDefinition> GetMetricDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SqlMetric> GetMetrics(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SqlMetric> GetMetricsAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabelResource> GetRecommendedSensitivityLabels(string skipToken = null, bool? includeDisabledRecommendations = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabelResource> GetRecommendedSensitivityLabelsAsync(string skipToken = null, bool? includeDisabledRecommendations = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ReplicationLinkResource> GetReplicationLink(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ReplicationLinkResource>> GetReplicationLinkAsync(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ReplicationLinkCollection GetReplicationLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorePointResource> GetRestorePoint(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorePointResource>> GetRestorePointAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.RestorePointCollection GetRestorePoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource> GetServerDatabaseAdvisor(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource>> GetServerDatabaseAdvisorAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseAdvisorCollection GetServerDatabaseAdvisors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaResource> GetServerDatabaseSchema(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaResource>> GetServerDatabaseSchemaAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseSchemaCollection GetServerDatabaseSchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource> GetServerDatabaseVulnerabilityAssessment(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource>> GetServerDatabaseVulnerabilityAssessmentAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentCollection GetServerDatabaseVulnerabilityAssessments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncGroupResource> GetSyncGroup(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncGroupResource>> GetSyncGroupAsync(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncGroupCollection GetSyncGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.WorkloadGroupResource> GetWorkloadGroup(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.WorkloadGroupResource>> GetWorkloadGroupAsync(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.WorkloadGroupCollection GetWorkloadGroups() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportOperationResult> Import(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ImportExistingDatabaseDefinition importExistingDatabaseDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportOperationResult>> ImportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ImportExistingDatabaseDefinition importExistingDatabaseDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseResource> Pause(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseResource>> PauseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Rename(Azure.ResourceManager.Sql.Models.ResourceMoveDefinition resourceMoveDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenameAsync(Azure.ResourceManager.Sql.Models.ResourceMoveDefinition resourceMoveDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseResource> Resume(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseResource>> ResumeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SqlDatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SqlDatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateRecommendedSensitivityLabel(Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdateList recommendedSensitivityLabelUpdateList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateRecommendedSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdateList recommendedSensitivityLabelUpdateList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateSensitivityLabel(Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateList sensitivityLabelUpdateList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateList sensitivityLabelUpdateList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpgradeDataWarehouse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeDataWarehouseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SqlExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Sql.Models.CheckNameAvailabilityResponse> CheckNameAvailabilityServer(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Sql.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.CheckNameAvailabilityResponse>> CheckNameAvailabilityServerAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Sql.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyResource GetBackupShortTermRetentionPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.Models.LocationCapabilities> GetByLocationCapability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.Sql.Models.CapabilityGroup? include = default(Azure.ResourceManager.Sql.Models.CapabilityGroup?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.LocationCapabilities>> GetByLocationCapabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.Sql.Models.CapabilityGroup? include = default(Azure.ResourceManager.Sql.Models.CapabilityGroup?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.DatabaseAutomaticTuningResource GetDatabaseAutomaticTuningResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyResource GetDatabaseBlobAuditingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyResource GetDatabaseSecurityAlertPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.DataMaskingPolicyResource GetDataMaskingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.DataWarehouseUserActivitiesResource GetDataWarehouseUserActivitiesResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.DeletedServerResource> GetDeletedServer(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string deletedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DeletedServerResource>> GetDeletedServerAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string deletedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.DeletedServerResource GetDeletedServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.DeletedServerCollection GetDeletedServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.DeletedServerResource> GetDeletedServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.DeletedServerResource> GetDeletedServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.ElasticPoolResource GetElasticPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.EncryptionProtectorResource GetEncryptionProtectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyResource GetExtendedDatabaseBlobAuditingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource GetExtendedServerBlobAuditingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.FailoverGroupResource GetFailoverGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.FirewallRuleResource GetFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.GeoBackupPolicyResource GetGeoBackupPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroupResource> GetInstanceFailoverGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroupResource>> GetInstanceFailoverGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.InstanceFailoverGroupResource GetInstanceFailoverGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.InstanceFailoverGroupCollection GetInstanceFailoverGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.InstancePoolResource> GetInstancePool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstancePoolResource>> GetInstancePoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.InstancePoolResource GetInstancePoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.InstancePoolCollection GetInstancePools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.InstancePoolResource> GetInstancePools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.InstancePoolResource> GetInstancePoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.JobAgentResource GetJobAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.JobCredentialResource GetJobCredentialResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.JobTargetGroupResource GetJobTargetGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.JobVersionResource GetJobVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.LedgerDigestUploadsResource GetLedgerDigestUploadsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionResource GetLogicalDatabaseTransparentDataEncryptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupLocation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupLocationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByResourceGroupServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByServer(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetLongTermRetentionBackupsByServerAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByInstance(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string managedInstanceName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByInstanceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string managedInstanceName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, string managedInstanceName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, string managedInstanceName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.LongTermRetentionPolicyResource GetLongTermRetentionPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.MaintenanceWindowOptionsResource GetMaintenanceWindowOptionsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.MaintenanceWindowsResource GetMaintenanceWindowsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedDatabaseResource GetManagedDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResultResource GetManagedDatabaseRestoreDetailsResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyResource GetManagedDatabaseSecurityAlertPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceResource> GetManagedInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string managedInstanceName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceAdministratorResource GetManagedInstanceAdministratorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceResource>> GetManagedInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string managedInstanceName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationResource GetManagedInstanceAzureADOnlyAuthenticationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyResource GetManagedInstanceDatabaseBackupShortTermRetentionPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaResource GetManagedInstanceDatabaseSchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnResource GetManagedInstanceDatabaseSchemaTableColumnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource GetManagedInstanceDatabaseSchemaTableColumnSensitivityLabelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableResource GetManagedInstanceDatabaseSchemaTableResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentResource GetManagedInstanceDatabaseVulnerabilityAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineResource GetManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanResource GetManagedInstanceDatabaseVulnerabilityAssessmentScanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorResource GetManagedInstanceEncryptionProtectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceKeyResource GetManagedInstanceKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyResource GetManagedInstanceLongTermRetentionPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceOperationResource GetManagedInstanceOperationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionResource GetManagedInstancePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstancePrivateLinkResource GetManagedInstancePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceResource GetManagedInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceCollection GetManagedInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceResource> GetManagedInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceResource> GetManagedInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentResource GetManagedInstanceVulnerabilityAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource GetManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyResource GetManagedServerSecurityAlertPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionResource GetManagedTransparentDataEncryptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.Models.OperationsHealth> GetOperationsHealthsByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.OperationsHealth> GetOperationsHealthsByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.OutboundFirewallRuleResource GetOutboundFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.PrivateLinkResource GetPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.RecommendedActionResource GetRecommendedActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.RecoverableDatabaseResource GetRecoverableDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.RecoverableManagedDatabaseResource GetRecoverableManagedDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ReplicationLinkResource GetReplicationLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource> GetResourceGroupLongTermRetentionBackup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource>> GetResourceGroupLongTermRetentionBackupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupResource GetResourceGroupLongTermRetentionBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupCollection GetResourceGroupLongTermRetentionBackups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource> GetResourceGroupLongTermRetentionManagedInstanceBackup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource>> GetResourceGroupLongTermRetentionManagedInstanceBackupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupResource GetResourceGroupLongTermRetentionManagedInstanceBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupCollection GetResourceGroupLongTermRetentionManagedInstanceBackups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, string managedInstanceName, string databaseName) { throw null; }
        public static Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource GetRestorableDroppedDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseResource GetRestorableDroppedManagedDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.RestorePointResource GetRestorePointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerAdvisorResource GetServerAdvisorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerAutomaticTuningResource GetServerAutomaticTuningResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerAzureADAdministratorResource GetServerAzureADAdministratorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource GetServerAzureADOnlyAuthenticationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource GetServerBlobAuditingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerCommunicationLinkResource GetServerCommunicationLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerConnectionPolicyResource GetServerConnectionPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseAdvisorResource GetServerDatabaseAdvisorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseSchemaResource GetServerDatabaseSchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnResource GetServerDatabaseSchemaTableColumnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabelResource GetServerDatabaseSchemaTableColumnSensitivityLabelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseSchemaTableResource GetServerDatabaseSchemaTableResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentResource GetServerDatabaseVulnerabilityAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaselineResource GetServerDatabaseVulnerabilityAssessmentRuleBaselineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanResource GetServerDatabaseVulnerabilityAssessmentScanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource GetServerDevOpsAuditingSettingsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDnsAliasResource GetServerDnsAliasResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource GetServerJobAgentJobExecutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepResource GetServerJobAgentJobExecutionStepResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetResource GetServerJobAgentJobExecutionStepTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerJobAgentJobStepResource GetServerJobAgentJobStepResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepResource GetServerJobAgentJobVersionStepResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerKeyResource GetServerKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource GetServerSecurityAlertPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.ServerTrustGroupResource> GetServerTrustGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, string serverTrustGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerTrustGroupResource>> GetServerTrustGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName, string serverTrustGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.ServerTrustGroupResource GetServerTrustGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerTrustGroupCollection GetServerTrustGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string locationName) { throw null; }
        public static Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource GetServerVulnerabilityAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServiceObjectiveResource GetServiceObjectiveResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SqlAgentConfigurationResource GetSqlAgentConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SqlDatabaseResource GetSqlDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SqlJobResource GetSqlJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.SqlServerResource> GetSqlServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerResource>> GetSqlServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.SqlServerResource GetSqlServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SqlServerCollection GetSqlServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SqlServerResource> GetSqlServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServerResource> GetSqlServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.SqlTimeZoneResource> GetSqlTimeZone(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string timeZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlTimeZoneResource>> GetSqlTimeZoneAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string timeZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.SqlTimeZoneResource GetSqlTimeZoneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SqlTimeZoneCollection GetSqlTimeZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetSubscriptionLongTermRetentionBackup(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>> GetSubscriptionLongTermRetentionBackupAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource GetSubscriptionLongTermRetentionBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupCollection GetSubscriptionLongTermRetentionBackups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetSubscriptionLongTermRetentionManagedInstanceBackup(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource>> GetSubscriptionLongTermRetentionManagedInstanceBackupAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource GetSubscriptionLongTermRetentionManagedInstanceBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupCollection GetSubscriptionLongTermRetentionManagedInstanceBackups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string managedInstanceName, string databaseName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsageResource> GetSubscriptionUsage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsageResource>> GetSubscriptionUsageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.SubscriptionUsageResource GetSubscriptionUsageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SubscriptionUsageCollection GetSubscriptionUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName) { throw null; }
        public static Azure.ResourceManager.Sql.SyncAgentResource GetSyncAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.Models.SubResource> GetSyncDatabaseIdsSyncGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.SubResource> GetSyncDatabaseIdsSyncGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.SyncGroupResource GetSyncGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SyncMemberResource GetSyncMemberResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.VirtualClusterResource> GetVirtualCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualClusterResource>> GetVirtualClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.VirtualClusterResource GetVirtualClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.VirtualClusterCollection GetVirtualClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.VirtualClusterResource> GetVirtualClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.VirtualClusterResource> GetVirtualClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.VirtualNetworkRuleResource GetVirtualNetworkRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.WorkloadClassifierResource GetWorkloadClassifierResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.WorkloadGroupResource GetWorkloadGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class SqlJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlJobResource>, System.Collections.IEnumerable
    {
        protected SqlJobCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlJobResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.Sql.SqlJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlJobResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.Sql.SqlJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlJobResource> Get(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlJobResource>> GetAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SqlJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SqlJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlJobData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlJobData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobSchedule Schedule { get { throw null; } set { } }
        public int? Version { get { throw null; } }
    }
    public partial class SqlJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlJobResource() { }
        public virtual Azure.ResourceManager.Sql.SqlJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource> CreateJobExecution(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource>> CreateJobExecutionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobVersionResource> GetJobVersion(int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobVersionResource>> GetJobVersionAsync(int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.JobVersionCollection GetJobVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource> GetServerJobAgentJobExecution(System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionResource>> GetServerJobAgentJobExecutionAsync(System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerJobAgentJobExecutionCollection GetServerJobAgentJobExecutions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource> GetServerJobAgentJobStep(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobStepResource>> GetServerJobAgentJobStepAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerJobAgentJobStepCollection GetServerJobAgentJobSteps() { throw null; }
    }
    public partial class SqlServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlServerResource>, System.Collections.IEnumerable
    {
        protected SqlServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.Sql.SqlServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.Sql.SqlServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerResource> Get(string serverName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlServerResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServerResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerResource>> GetAsync(string serverName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SqlServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SqlServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlServerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SqlServerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ServerExternalAdministrator Administrators { get { throw null; } set { } }
        public System.Guid? FederatedClientId { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string KeyId { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public string MinimalTlsVersion { get { throw null; } set { } }
        public string PrimaryUserAssignedIdentityId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ServerPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag? RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public string State { get { throw null; } }
        public string Version { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ServerWorkspaceFeature? WorkspaceFeature { get { throw null; } }
    }
    public partial class SqlServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlServerResource() { }
        public virtual Azure.ResourceManager.Sql.SqlServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateTdeCertificate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TdeCertificate tdeCertificate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateTdeCertificateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TdeCertificate tdeCertificate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ElasticPoolResource> GetElasticPool(string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ElasticPoolResource>> GetElasticPoolAsync(string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ElasticPoolCollection GetElasticPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.EncryptionProtectorResource> GetEncryptionProtector(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.EncryptionProtectorResource>> GetEncryptionProtectorAsync(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.EncryptionProtectorCollection GetEncryptionProtectors() { throw null; }
        public virtual Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyCollection GetExtendedServerBlobAuditingPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource> GetExtendedServerBlobAuditingPolicy(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyResource>> GetExtendedServerBlobAuditingPolicyAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FailoverGroupResource> GetFailoverGroup(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FailoverGroupResource>> GetFailoverGroupAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.FailoverGroupCollection GetFailoverGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FirewallRuleResource> GetFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FirewallRuleResource>> GetFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.FirewallRuleCollection GetFirewallRules() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlDatabaseResource> GetInaccessibleDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlDatabaseResource> GetInaccessibleDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobAgentResource> GetJobAgent(string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobAgentResource>> GetJobAgentAsync(string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.JobAgentCollection GetJobAgents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.OutboundFirewallRuleResource> GetOutboundFirewallRule(string outboundRuleFqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.OutboundFirewallRuleResource>> GetOutboundFirewallRuleAsync(string outboundRuleFqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.OutboundFirewallRuleCollection GetOutboundFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource> GetPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.PrivateEndpointConnectionResource>> GetPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.PrivateLinkResource> GetPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.PrivateLinkResource>> GetPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.PrivateLinkResourceCollection GetPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecoverableDatabaseResource> GetRecoverableDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecoverableDatabaseResource>> GetRecoverableDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.RecoverableDatabaseCollection GetRecoverableDatabases() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ReplicationLinkResource> GetReplicationLinks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ReplicationLinkResource> GetReplicationLinksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource> GetRestorableDroppedDatabase(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabaseResource>> GetRestorableDroppedDatabaseAsync(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.RestorableDroppedDatabaseCollection GetRestorableDroppedDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAdvisorResource> GetServerAdvisor(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAdvisorResource>> GetServerAdvisorAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerAdvisorCollection GetServerAdvisors() { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerAutomaticTuningResource GetServerAutomaticTuning() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource> GetServerAzureADAdministrator(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAzureADAdministratorResource>> GetServerAzureADAdministratorAsync(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerAzureADAdministratorCollection GetServerAzureADAdministrators() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource> GetServerAzureADOnlyAuthentication(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationResource>> GetServerAzureADOnlyAuthenticationAsync(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationCollection GetServerAzureADOnlyAuthentications() { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerBlobAuditingPolicyCollection GetServerBlobAuditingPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource> GetServerBlobAuditingPolicy(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerBlobAuditingPolicyResource>> GetServerBlobAuditingPolicyAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerCommunicationLinkResource> GetServerCommunicationLink(string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerCommunicationLinkResource>> GetServerCommunicationLinkAsync(string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerCommunicationLinkCollection GetServerCommunicationLinks() { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerConnectionPolicyCollection GetServerConnectionPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerConnectionPolicyResource> GetServerConnectionPolicy(Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerConnectionPolicyResource>> GetServerConnectionPolicyAsync(Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsCollection GetServerDevOpsAuditingSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource> GetServerDevOpsAuditingSettings(string devOpsAuditingSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsResource>> GetServerDevOpsAuditingSettingsAsync(string devOpsAuditingSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDnsAliasResource> GetServerDnsAlias(string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDnsAliasResource>> GetServerDnsAliasAsync(string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDnsAliasCollection GetServerDnsAliases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerKeyResource> GetServerKey(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerKeyResource>> GetServerKeyAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerKeyCollection GetServerKeys() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServerOperation> GetServerOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServerOperation> GetServerOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerSecurityAlertPolicyCollection GetServerSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource> GetServerSecurityAlertPolicy(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerSecurityAlertPolicyResource>> GetServerSecurityAlertPolicyAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServerUsage> GetServerUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServerUsage> GetServerUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource> GetServerVulnerabilityAssessment(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentResource>> GetServerVulnerabilityAssessmentAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentCollection GetServerVulnerabilityAssessments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServiceObjectiveResource> GetServiceObjective(string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServiceObjectiveResource>> GetServiceObjectiveAsync(string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServiceObjectiveCollection GetServiceObjectives() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseResource> GetSqlDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabaseResource>> GetSqlDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SqlDatabaseCollection GetSqlDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncAgentResource> GetSyncAgent(string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncAgentResource>> GetSyncAgentAsync(string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncAgentCollection GetSyncAgents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualNetworkRuleResource> GetVirtualNetworkRule(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualNetworkRuleResource>> GetVirtualNetworkRuleAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.VirtualNetworkRuleCollection GetVirtualNetworkRules() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportOperationResult> ImportDatabase(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ImportNewDatabaseDefinition importNewDatabaseDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportOperationResult>> ImportDatabaseAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ImportNewDatabaseDefinition importNewDatabaseDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FirewallRuleResource> ReplaceFirewallRule(Azure.ResourceManager.Sql.Models.FirewallRuleList firewallRuleList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FirewallRuleResource>> ReplaceFirewallRuleAsync(Azure.ResourceManager.Sql.Models.FirewallRuleList firewallRuleList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SqlServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SqlServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlTimeZoneCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlTimeZoneResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlTimeZoneResource>, System.Collections.IEnumerable
    {
        protected SqlTimeZoneCollection() { }
        public virtual Azure.Response<bool> Exists(string timeZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string timeZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlTimeZoneResource> Get(string timeZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlTimeZoneResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlTimeZoneResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlTimeZoneResource>> GetAsync(string timeZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SqlTimeZoneResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlTimeZoneResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SqlTimeZoneResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlTimeZoneResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlTimeZoneData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlTimeZoneData() { }
        public string DisplayName { get { throw null; } }
        public string TimeZoneId { get { throw null; } }
    }
    public partial class SqlTimeZoneResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlTimeZoneResource() { }
        public virtual Azure.ResourceManager.Sql.SqlTimeZoneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string timeZoneId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlTimeZoneResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlTimeZoneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionLongTermRetentionBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>, System.Collections.IEnumerable
    {
        protected SubscriptionLongTermRetentionBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetAll(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> GetAllAsync(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionLongTermRetentionBackupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionLongTermRetentionBackupResource() { }
        public virtual Azure.ResourceManager.Sql.LongTermRetentionBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult> Copy(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CopyLongTermRetentionBackupOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult>> CopyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CopyLongTermRetentionBackupOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.UpdateLongTermRetentionBackupOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.UpdateLongTermRetentionBackupOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionLongTermRetentionManagedInstanceBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource>, System.Collections.IEnumerable
    {
        protected SubscriptionLongTermRetentionManagedInstanceBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetAll(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> GetAllAsync(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionLongTermRetentionManagedInstanceBackupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionLongTermRetentionManagedInstanceBackupResource() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string managedInstanceName, string databaseName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionUsageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SubscriptionUsageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SubscriptionUsageResource>, System.Collections.IEnumerable
    {
        protected SubscriptionUsageCollection() { }
        public virtual Azure.Response<bool> Exists(string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsageResource> Get(string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionUsageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionUsageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsageResource>> GetAsync(string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SubscriptionUsageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SubscriptionUsageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SubscriptionUsageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SubscriptionUsageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionUsageData : Azure.ResourceManager.Models.ResourceData
    {
        public SubscriptionUsageData() { }
        public double? CurrentValue { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public double? Limit { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class SubscriptionUsageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionUsageResource() { }
        public virtual Azure.ResourceManager.Sql.SubscriptionUsageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string usageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncAgentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SyncAgentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SyncAgentResource>, System.Collections.IEnumerable
    {
        protected SyncAgentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncAgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string syncAgentName, Azure.ResourceManager.Sql.SyncAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncAgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string syncAgentName, Azure.ResourceManager.Sql.SyncAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncAgentResource> Get(string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SyncAgentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SyncAgentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncAgentResource>> GetAsync(string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SyncAgentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SyncAgentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SyncAgentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SyncAgentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SyncAgentData : Azure.ResourceManager.Models.ResourceData
    {
        public SyncAgentData() { }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public bool? IsUpToDate { get { throw null; } }
        public System.DateTimeOffset? LastAliveOn { get { throw null; } }
        public string NamePropertiesName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SyncAgentState? State { get { throw null; } }
        public string SyncDatabaseId { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public partial class SyncAgentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SyncAgentResource() { }
        public virtual Azure.ResourceManager.Sql.SyncAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string syncAgentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.SyncAgentKeyProperties> GenerateKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.SyncAgentKeyProperties>> GenerateKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncAgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncAgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncAgentLinkedDatabase> GetLinkedDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncAgentLinkedDatabase> GetLinkedDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SyncGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SyncGroupResource>, System.Collections.IEnumerable
    {
        protected SyncGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string syncGroupName, Azure.ResourceManager.Sql.SyncGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string syncGroupName, Azure.ResourceManager.Sql.SyncGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncGroupResource> Get(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SyncGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SyncGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncGroupResource>> GetAsync(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SyncGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SyncGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SyncGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SyncGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SyncGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public SyncGroupData() { }
        public int? ConflictLoggingRetentionInDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SyncConflictResolutionPolicy? ConflictResolutionPolicy { get { throw null; } set { } }
        public bool? EnableConflictLogging { get { throw null; } set { } }
        public string HubDatabasePassword { get { throw null; } set { } }
        public string HubDatabaseUserName { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public System.DateTimeOffset? LastSyncOn { get { throw null; } }
        public string PrivateEndpointName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SyncGroupSchema Schema { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public string SyncDatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SyncGroupState? SyncState { get { throw null; } }
        public bool? UsePrivateLinkConnection { get { throw null; } set { } }
    }
    public partial class SyncGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SyncGroupResource() { }
        public virtual Azure.ResourceManager.Sql.SyncGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response CancelSync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelSyncAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string syncGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncFullSchemaProperties> GetHubSchemas(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncFullSchemaProperties> GetHubSchemasAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncGroupLogProperties> GetLogs(string startTime, string endTime, Azure.ResourceManager.Sql.Models.SyncGroupLogType type, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncGroupLogProperties> GetLogsAsync(string startTime, string endTime, Azure.ResourceManager.Sql.Models.SyncGroupLogType type, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncMemberResource> GetSyncMember(string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncMemberResource>> GetSyncMemberAsync(string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncMemberCollection GetSyncMembers() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RefreshHubSchema(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshHubSchemaAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response TriggerSync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TriggerSyncAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SyncGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SyncGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncMemberCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SyncMemberResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SyncMemberResource>, System.Collections.IEnumerable
    {
        protected SyncMemberCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncMemberResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string syncMemberName, Azure.ResourceManager.Sql.SyncMemberData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncMemberResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string syncMemberName, Azure.ResourceManager.Sql.SyncMemberData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncMemberResource> Get(string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SyncMemberResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SyncMemberResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncMemberResource>> GetAsync(string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SyncMemberResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SyncMemberResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SyncMemberResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SyncMemberResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SyncMemberData : Azure.ResourceManager.Models.ResourceData
    {
        public SyncMemberData() { }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SyncMemberDbType? DatabaseType { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string PrivateEndpointName { get { throw null; } }
        public string ServerName { get { throw null; } set { } }
        public System.Guid? SqlServerDatabaseId { get { throw null; } set { } }
        public string SyncAgentId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SyncDirection? SyncDirection { get { throw null; } set { } }
        public string SyncMemberAzureDatabaseResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SyncMemberState? SyncState { get { throw null; } }
        public bool? UsePrivateLinkConnection { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class SyncMemberResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SyncMemberResource() { }
        public virtual Azure.ResourceManager.Sql.SyncMemberData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncMemberResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncMemberResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncFullSchemaProperties> GetMemberSchemas(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncFullSchemaProperties> GetMemberSchemasAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RefreshMemberSchema(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshMemberSchemaAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncMemberResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SyncMemberData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncMemberResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SyncMemberData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.VirtualClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.VirtualClusterResource>, System.Collections.IEnumerable
    {
        protected VirtualClusterCollection() { }
        public virtual Azure.Response<bool> Exists(string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualClusterResource> Get(string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.VirtualClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.VirtualClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualClusterResource>> GetAsync(string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.VirtualClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.VirtualClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.VirtualClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.VirtualClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<string> ChildResources { get { throw null; } }
        public string Family { get { throw null; } set { } }
        public string MaintenanceConfigurationId { get { throw null; } set { } }
        public string SubnetId { get { throw null; } }
    }
    public partial class VirtualClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualClusterResource() { }
        public virtual Azure.ResourceManager.Sql.VirtualClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualClusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.VirtualClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VirtualClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.VirtualClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VirtualClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.UpdateManagedInstanceDnsServersOperation> UpdateDnsServers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.UpdateManagedInstanceDnsServersOperation>> UpdateDnsServersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.VirtualNetworkRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.VirtualNetworkRuleResource>, System.Collections.IEnumerable
    {
        protected VirtualNetworkRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.VirtualNetworkRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.Sql.VirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.VirtualNetworkRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.Sql.VirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualNetworkRuleResource> Get(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.VirtualNetworkRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.VirtualNetworkRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualNetworkRuleResource>> GetAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.VirtualNetworkRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.VirtualNetworkRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.VirtualNetworkRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.VirtualNetworkRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualNetworkRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public VirtualNetworkRuleData() { }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState? State { get { throw null; } }
        public string VirtualNetworkSubnetId { get { throw null; } set { } }
    }
    public partial class VirtualNetworkRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkRuleResource() { }
        public virtual Azure.ResourceManager.Sql.VirtualNetworkRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string virtualNetworkRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualNetworkRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualNetworkRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VulnerabilityAssessmentScanRecordData : Azure.ResourceManager.Models.ResourceData
    {
        public VulnerabilityAssessmentScanRecordData() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanError> Errors { get { throw null; } }
        public int? NumberOfFailedSecurityChecks { get { throw null; } }
        public string ScanId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanState? State { get { throw null; } }
        public string StorageContainerPath { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanTriggerType? TriggerType { get { throw null; } }
    }
    public partial class WorkloadClassifierCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.WorkloadClassifierResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.WorkloadClassifierResource>, System.Collections.IEnumerable
    {
        protected WorkloadClassifierCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.WorkloadClassifierResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workloadClassifierName, Azure.ResourceManager.Sql.WorkloadClassifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.WorkloadClassifierResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workloadClassifierName, Azure.ResourceManager.Sql.WorkloadClassifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.WorkloadClassifierResource> Get(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.WorkloadClassifierResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.WorkloadClassifierResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.WorkloadClassifierResource>> GetAsync(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.WorkloadClassifierResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.WorkloadClassifierResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.WorkloadClassifierResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.WorkloadClassifierResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadClassifierData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkloadClassifierData() { }
        public string Context { get { throw null; } set { } }
        public string EndTime { get { throw null; } set { } }
        public string Importance { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public string MemberName { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
    }
    public partial class WorkloadClassifierResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadClassifierResource() { }
        public virtual Azure.ResourceManager.Sql.WorkloadClassifierData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string workloadGroupName, string workloadClassifierName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.WorkloadClassifierResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.WorkloadClassifierResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.WorkloadGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.WorkloadGroupResource>, System.Collections.IEnumerable
    {
        protected WorkloadGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.WorkloadGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workloadGroupName, Azure.ResourceManager.Sql.WorkloadGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.WorkloadGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workloadGroupName, Azure.ResourceManager.Sql.WorkloadGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.WorkloadGroupResource> Get(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.WorkloadGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.WorkloadGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.WorkloadGroupResource>> GetAsync(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.WorkloadGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.WorkloadGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.WorkloadGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.WorkloadGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkloadGroupData() { }
        public string Importance { get { throw null; } set { } }
        public int? MaxResourcePercent { get { throw null; } set { } }
        public double? MaxResourcePercentPerRequest { get { throw null; } set { } }
        public int? MinResourcePercent { get { throw null; } set { } }
        public double? MinResourcePercentPerRequest { get { throw null; } set { } }
        public int? QueryExecutionTimeout { get { throw null; } set { } }
    }
    public partial class WorkloadGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadGroupResource() { }
        public virtual Azure.ResourceManager.Sql.WorkloadGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string workloadGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.WorkloadGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.WorkloadGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.WorkloadClassifierResource> GetWorkloadClassifier(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.WorkloadClassifierResource>> GetWorkloadClassifierAsync(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.WorkloadClassifierCollection GetWorkloadClassifiers() { throw null; }
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
    public enum AdvisorStatus
    {
        GA = 0,
        PublicPreview = 1,
        LimitedPublicPreview = 2,
        PrivatePreview = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AggregationFunctionType : System.IEquatable<Azure.ResourceManager.Sql.Models.AggregationFunctionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AggregationFunctionType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.AggregationFunctionType Avg { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.AggregationFunctionType Max { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.AggregationFunctionType Min { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.AggregationFunctionType Stdev { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.AggregationFunctionType Sum { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.AggregationFunctionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.AggregationFunctionType left, Azure.ResourceManager.Sql.Models.AggregationFunctionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.AggregationFunctionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.AggregationFunctionType left, Azure.ResourceManager.Sql.Models.AggregationFunctionType right) { throw null; }
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
    public enum AutoExecuteStatus
    {
        Enabled = 0,
        Disabled = 1,
        Default = 2,
    }
    public enum AutoExecuteStatusInheritedFrom
    {
        Default = 0,
        Subscription = 1,
        Server = 2,
        ElasticPool = 3,
        Database = 4,
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
        Unspecified = 0,
        Inherit = 1,
        Custom = 2,
        Auto = 3,
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
        Unspecified = 0,
        Custom = 1,
        Auto = 2,
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupStorageRedundancy : System.IEquatable<Azure.ResourceManager.Sql.Models.BackupStorageRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupStorageRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.BackupStorageRedundancy Geo { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.BackupStorageRedundancy Local { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.BackupStorageRedundancy Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.BackupStorageRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.BackupStorageRedundancy left, Azure.ResourceManager.Sql.Models.BackupStorageRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.BackupStorageRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.BackupStorageRedundancy left, Azure.ResourceManager.Sql.Models.BackupStorageRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobAuditingPolicyName : System.IEquatable<Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobAuditingPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName left, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName left, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class CheckNameAvailabilityContent
    {
        public CheckNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public enum CheckNameAvailabilityReason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
    public partial class CheckNameAvailabilityResponse
    {
        internal CheckNameAvailabilityResponse() { }
        public bool? Available { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CheckNameAvailabilityReason? Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ColumnDataType : System.IEquatable<Azure.ResourceManager.Sql.Models.ColumnDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ColumnDataType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Bigint { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Binary { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Bit { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Char { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Date { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Datetime { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Datetime2 { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Datetimeoffset { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Decimal { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Float { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Geography { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Geometry { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Hierarchyid { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Image { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Int { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Money { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Nchar { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Ntext { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Numeric { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Nvarchar { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Real { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Smalldatetime { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Smallint { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Smallmoney { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType SqlVariant { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Sysname { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Text { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Time { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Timestamp { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Tinyint { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Uniqueidentifier { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Varbinary { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Varchar { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ColumnDataType Xml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ColumnDataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ColumnDataType left, Azure.ResourceManager.Sql.Models.ColumnDataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ColumnDataType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ColumnDataType left, Azure.ResourceManager.Sql.Models.ColumnDataType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class CopyLongTermRetentionBackupOptions
    {
        public CopyLongTermRetentionBackupOptions() { }
        public Azure.ResourceManager.Sql.Models.TargetBackupStorageRedundancy? TargetBackupStorageRedundancy { get { throw null; } set { } }
        public string TargetDatabaseName { get { throw null; } set { } }
        public string TargetResourceGroup { get { throw null; } set { } }
        public string TargetServerFullyQualifiedDomainName { get { throw null; } set { } }
        public string TargetServerResourceId { get { throw null; } set { } }
        public string TargetSubscriptionId { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CurrentBackupStorageRedundancy : System.IEquatable<Azure.ResourceManager.Sql.Models.CurrentBackupStorageRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CurrentBackupStorageRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.CurrentBackupStorageRedundancy Geo { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CurrentBackupStorageRedundancy Local { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.CurrentBackupStorageRedundancy Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.CurrentBackupStorageRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.CurrentBackupStorageRedundancy left, Azure.ResourceManager.Sql.Models.CurrentBackupStorageRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.CurrentBackupStorageRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.CurrentBackupStorageRedundancy left, Azure.ResourceManager.Sql.Models.CurrentBackupStorageRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseExtensions : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseExtensions() { }
        public Azure.ResourceManager.Sql.Models.OperationMode? OperationMode { get { throw null; } set { } }
        public string StorageKey { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.StorageKeyType? StorageKeyType { get { throw null; } set { } }
        public System.Uri StorageUri { get { throw null; } set { } }
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
    public partial class DatabaseOperation : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseOperation() { }
        public string DatabaseName { get { throw null; } }
        public string Description { get { throw null; } }
        public int? ErrorCode { get { throw null; } }
        public string ErrorDescription { get { throw null; } }
        public int? ErrorSeverity { get { throw null; } }
        public System.DateTimeOffset? EstimatedCompletionOn { get { throw null; } }
        public bool? IsCancellable { get { throw null; } }
        public bool? IsUserError { get { throw null; } }
        public string Operation { get { throw null; } }
        public string OperationFriendlyName { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public string ServerName { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
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
    public partial class DatabaseUsage : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseUsage() { }
        public double? CurrentValue { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public double? Limit { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class DatabaseVulnerabilityAssessmentRuleBaselineItem
    {
        public DatabaseVulnerabilityAssessmentRuleBaselineItem(System.Collections.Generic.IEnumerable<string> result) { }
        public System.Collections.Generic.IList<string> Result { get { throw null; } }
    }
    public partial class DatabaseVulnerabilityAssessmentScansExport : Azure.ResourceManager.Models.ResourceData
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
    public partial class DataMaskingRule : Azure.ResourceManager.Models.ResourceData
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
    public readonly partial struct DataWarehouseUserActivityName : System.IEquatable<Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataWarehouseUserActivityName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName Current { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName left, Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName left, Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsRefreshConfigurationPropertiesStatus : System.IEquatable<Azure.ResourceManager.Sql.Models.DnsRefreshConfigurationPropertiesStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsRefreshConfigurationPropertiesStatus(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.DnsRefreshConfigurationPropertiesStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.DnsRefreshConfigurationPropertiesStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.DnsRefreshConfigurationPropertiesStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.DnsRefreshConfigurationPropertiesStatus left, Azure.ResourceManager.Sql.Models.DnsRefreshConfigurationPropertiesStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.DnsRefreshConfigurationPropertiesStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.DnsRefreshConfigurationPropertiesStatus left, Azure.ResourceManager.Sql.Models.DnsRefreshConfigurationPropertiesStatus right) { throw null; }
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
    public partial class ElasticPoolActivity : Azure.ResourceManager.Models.ResourceData
    {
        public ElasticPoolActivity() { }
        public string ElasticPoolName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
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
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string State { get { throw null; } }
    }
    public partial class ElasticPoolDatabaseActivity : Azure.ResourceManager.Models.ResourceData
    {
        public ElasticPoolDatabaseActivity() { }
        public string CurrentElasticPoolName { get { throw null; } }
        public string CurrentServiceObjective { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
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
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string State { get { throw null; } }
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
    public partial class ElasticPoolOperation : Azure.ResourceManager.Models.ResourceData
    {
        public ElasticPoolOperation() { }
        public string Description { get { throw null; } }
        public string ElasticPoolName { get { throw null; } }
        public int? ErrorCode { get { throw null; } }
        public string ErrorDescription { get { throw null; } }
        public int? ErrorSeverity { get { throw null; } }
        public System.DateTimeOffset? EstimatedCompletionOn { get { throw null; } }
        public bool? IsCancellable { get { throw null; } }
        public bool? IsUserError { get { throw null; } }
        public string Operation { get { throw null; } }
        public string OperationFriendlyName { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public string ServerName { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string State { get { throw null; } }
    }
    public partial class ElasticPoolPatch
    {
        public ElasticPoolPatch() { }
        public Azure.ResourceManager.Sql.Models.ElasticPoolLicenseType? LicenseType { get { throw null; } set { } }
        public string MaintenanceConfigurationId { get { throw null; } set { } }
        public long? MaxSizeBytes { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ElasticPoolPerDatabaseSettings PerDatabaseSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
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
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.LicenseTypeCapability> SupportedLicenseTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.MaintenanceConfigurationCapability> SupportedMaintenanceConfigurations { get { throw null; } }
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
    public partial class ExportDatabaseDefinition
    {
        public ExportDatabaseDefinition(Azure.ResourceManager.Sql.Models.StorageKeyType storageKeyType, string storageKey, System.Uri storageUri, string administratorLogin, string administratorLoginPassword) { }
        public string AdministratorLogin { get { throw null; } }
        public string AdministratorLoginPassword { get { throw null; } }
        public string AuthenticationType { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.NetworkIsolationSettings NetworkIsolation { get { throw null; } set { } }
        public string StorageKey { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.StorageKeyType StorageKeyType { get { throw null; } }
        public System.Uri StorageUri { get { throw null; } }
    }
    public partial class FailoverGroupPatch
    {
        public FailoverGroupPatch() { }
        public System.Collections.Generic.IList<string> Databases { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ReadOnlyEndpointFailoverPolicy? ReadOnlyEndpointFailoverPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.FailoverGroupReadWriteEndpoint ReadWriteEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class FirewallRuleList
    {
        public FirewallRuleList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.FirewallRuleData> Values { get { throw null; } }
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
    public enum ImplementationMethod
    {
        TSql = 0,
        AzurePowerShell = 1,
    }
    public partial class ImportExistingDatabaseDefinition
    {
        public ImportExistingDatabaseDefinition(Azure.ResourceManager.Sql.Models.StorageKeyType storageKeyType, string storageKey, System.Uri storageUri, string administratorLogin, string administratorLoginPassword) { }
        public string AdministratorLogin { get { throw null; } }
        public string AdministratorLoginPassword { get { throw null; } }
        public string AuthenticationType { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.NetworkIsolationSettings NetworkIsolation { get { throw null; } set { } }
        public string StorageKey { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.StorageKeyType StorageKeyType { get { throw null; } }
        public System.Uri StorageUri { get { throw null; } }
    }
    public partial class ImportExportExtensionsOperationResult : Azure.ResourceManager.Models.ResourceData
    {
        public ImportExportExtensionsOperationResult() { }
        public string DatabaseName { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string LastModifiedTime { get { throw null; } }
        public System.Guid? RequestId { get { throw null; } }
        public string RequestType { get { throw null; } }
        public string ServerName { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ImportExportOperationResult : Azure.ResourceManager.Models.ResourceData
    {
        public ImportExportOperationResult() { }
        public System.Uri BlobUri { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string LastModifiedTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.PrivateEndpointConnectionRequestStatus> PrivateEndpointConnections { get { throw null; } }
        public string QueuedTime { get { throw null; } }
        public System.Guid? RequestId { get { throw null; } }
        public string RequestType { get { throw null; } }
        public string ServerName { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ImportNewDatabaseDefinition
    {
        public ImportNewDatabaseDefinition(Azure.ResourceManager.Sql.Models.StorageKeyType storageKeyType, string storageKey, System.Uri storageUri, string administratorLogin, string administratorLoginPassword) { }
        public string AdministratorLogin { get { throw null; } }
        public string AdministratorLoginPassword { get { throw null; } }
        public string AuthenticationType { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public string Edition { get { throw null; } set { } }
        public string MaxSizeBytes { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.NetworkIsolationSettings NetworkIsolation { get { throw null; } set { } }
        public string ServiceObjectiveName { get { throw null; } set { } }
        public string StorageKey { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.StorageKeyType StorageKeyType { get { throw null; } }
        public System.Uri StorageUri { get { throw null; } }
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
    public partial class InstancePoolUsage
    {
        internal InstancePoolUsage() { }
        public int? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public string InstancePoolUsageType { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.UsageName Name { get { throw null; } }
        public int? RequestedLimit { get { throw null; } }
        public string Unit { get { throw null; } }
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
    public enum IsRetryable
    {
        Yes = 0,
        No = 1,
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
        public Azure.ResourceManager.Sql.Models.JobTargetType? TargetType { get { throw null; } }
    }
    public partial class JobSchedule
    {
        public JobSchedule() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string Interval { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobScheduleType? ScheduleType { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public enum JobScheduleType
    {
        Once = 0,
        Recurring = 1,
    }
    public partial class JobStepAction
    {
        public JobStepAction(string value) { }
        public Azure.ResourceManager.Sql.Models.JobStepActionType? ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobStepActionSource? Source { get { throw null; } set { } }
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
        public Azure.ResourceManager.Sql.Models.JobStepOutputType? OutputType { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string SchemaName { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public System.Guid? SubscriptionId { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
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
        public JobTarget(Azure.ResourceManager.Sql.Models.JobTargetType targetType) { }
        public string DatabaseName { get { throw null; } set { } }
        public string ElasticPoolName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobTargetGroupMembershipType? MembershipType { get { throw null; } set { } }
        public string RefreshCredential { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public string ShardMapName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobTargetType TargetType { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LedgerDigestUploadsName : System.IEquatable<Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LedgerDigestUploadsName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName Current { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName left, Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName left, Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum LedgerDigestUploadsState
    {
        Enabled = 0,
        Disabled = 1,
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
    public partial class LongTermRetentionBackupOperationResult : Azure.ResourceManager.Models.ResourceData
    {
        public LongTermRetentionBackupOperationResult() { }
        public string FromBackupResourceId { get { throw null; } }
        public string Message { get { throw null; } }
        public string OperationType { get { throw null; } }
        public System.Guid? RequestId { get { throw null; } }
        public string Status { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.BackupStorageRedundancy? TargetBackupStorageRedundancy { get { throw null; } }
        public string ToBackupResourceId { get { throw null; } }
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
    public partial class MaintenanceConfigurationCapability
    {
        internal MaintenanceConfigurationCapability() { }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } }
    }
    public partial class MaintenanceWindowTimeRange
    {
        public MaintenanceWindowTimeRange() { }
        public Azure.ResourceManager.Sql.Models.SqlDayOfWeek? DayOfWeek { get { throw null; } set { } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
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
    public partial class ManagedDatabasePatch
    {
        public ManagedDatabasePatch() { }
        public bool? AutoCompleteRestore { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CatalogCollationType? CatalogCollation { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedDatabaseCreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public string DefaultSecondaryLocation { get { throw null; } }
        public System.DateTimeOffset? EarliestRestorePoint { get { throw null; } }
        public string FailoverGroupId { get { throw null; } }
        public string LastBackupName { get { throw null; } set { } }
        public string LongTermRetentionBackupResourceId { get { throw null; } set { } }
        public string RecoverableDatabaseId { get { throw null; } set { } }
        public string RestorableDroppedDatabaseId { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInOn { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedDatabaseStatus? Status { get { throw null; } }
        public string StorageContainerSasToken { get { throw null; } set { } }
        public System.Uri StorageContainerUri { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.StorageCapability> SupportedStorageCapabilities { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } }
    }
    public partial class ManagedInstanceExternalAdministrator
    {
        public ManagedInstanceExternalAdministrator() { }
        public Azure.ResourceManager.Sql.Models.AdministratorType? AdministratorType { get { throw null; } set { } }
        public bool? AzureADOnlyAuthentication { get { throw null; } set { } }
        public string Login { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.PrincipalType? PrincipalType { get { throw null; } set { } }
        public System.Guid? Sid { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
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
    public partial class ManagedInstanceMaintenanceConfigurationCapability
    {
        internal ManagedInstanceMaintenanceConfigurationCapability() { }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
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
    public partial class ManagedInstancePatch
    {
        public ManagedInstancePatch() { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceExternalAdministrator Administrators { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        public string DnsZone { get { throw null; } }
        public string DnsZonePartner { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string InstancePoolId { get { throw null; } set { } }
        public string KeyId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceLicenseType? LicenseType { get { throw null; } set { } }
        public string MaintenanceConfigurationId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedServerCreateMode? ManagedInstanceCreateMode { get { throw null; } set { } }
        public string MinimalTlsVersion { get { throw null; } set { } }
        public string PrimaryUserAssignedIdentityId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ManagedInstancePecProperty> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ManagedInstanceProxyOverride? ProxyOverride { get { throw null; } set { } }
        public bool? PublicDataEndpointEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInOn { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public string SourceManagedInstanceId { get { throw null; } set { } }
        public string State { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        public int? StorageSizeInGB { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TimezoneId { get { throw null; } set { } }
        public int? VCores { get { throw null; } set { } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class ManagedInstancePecProperty
    {
        internal ManagedInstancePecProperty() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ManagedInstancePrivateEndpointConnectionProperties Properties { get { throw null; } }
    }
    public partial class ManagedInstancePrivateEndpointConnectionProperties
    {
        internal ManagedInstancePrivateEndpointConnectionProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedInstancePrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ManagedInstancePrivateLinkProperties
    {
        internal ManagedInstancePrivateLinkProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
    }
    public partial class ManagedInstancePrivateLinkServiceConnectionStateProperty
    {
        public ManagedInstancePrivateLinkServiceConnectionStateProperty(string status, string description) { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
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
    public partial class ManagedInstanceQuery : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstanceQuery() { }
        public string QueryText { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ManagedInstanceMaintenanceConfigurationCapability> SupportedMaintenanceConfigurations { get { throw null; } }
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
        public System.Uri ResourceUri { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.UnitDefinitionType? Unit { get { throw null; } }
    }
    public partial class MetricName
    {
        internal MetricName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricType : System.IEquatable<Azure.ResourceManager.Sql.Models.MetricType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.MetricType Cpu { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.MetricType Dtu { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.MetricType Duration { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.MetricType Io { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.MetricType LogIo { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.MetricType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.MetricType left, Azure.ResourceManager.Sql.Models.MetricType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.MetricType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.MetricType left, Azure.ResourceManager.Sql.Models.MetricType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class NetworkIsolationSettings
    {
        public NetworkIsolationSettings() { }
        public string SqlServerResourceId { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationMode : System.IEquatable<Azure.ResourceManager.Sql.Models.OperationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationMode(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.OperationMode PolybaseImport { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.OperationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.OperationMode left, Azure.ResourceManager.Sql.Models.OperationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.OperationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.OperationMode left, Azure.ResourceManager.Sql.Models.OperationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationsHealth : Azure.ResourceManager.Models.ResourceData
    {
        public OperationsHealth() { }
        public string Description { get { throw null; } }
        public string Health { get { throw null; } }
        public string NamePropertiesName { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrincipalType : System.IEquatable<Azure.ResourceManager.Sql.Models.PrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.PrincipalType Application { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.PrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.PrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.PrincipalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.PrincipalType left, Azure.ResourceManager.Sql.Models.PrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.PrincipalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.PrincipalType left, Azure.ResourceManager.Sql.Models.PrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionProperties
    {
        internal PrivateEndpointConnectionProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionRequestStatus
    {
        internal PrivateEndpointConnectionRequestStatus() { }
        public string PrivateEndpointConnectionName { get { throw null; } }
        public string PrivateLinkServiceId { get { throw null; } }
        public string Status { get { throw null; } }
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
    public partial class PrivateLinkResourceProperties
    {
        internal PrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
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
        public PrivateLinkServiceConnectionStateProperty(Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateStatus status, string description) { }
        public Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateActionsRequire? ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateStatus Status { get { throw null; } set { } }
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
    public partial class ProxyResourceWithWritableName : Azure.ResourceManager.Sql.Models.ResourceWithWritableName
    {
        public ProxyResourceWithWritableName() { }
    }
    public partial class QueryMetricInterval
    {
        public QueryMetricInterval() { }
        public long? ExecutionCount { get { throw null; } }
        public string IntervalStartTime { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.QueryTimeGrainType? IntervalType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.QueryMetricProperties> Metrics { get { throw null; } }
    }
    public partial class QueryMetricProperties
    {
        public QueryMetricProperties() { }
        public double? Avg { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public double? Max { get { throw null; } }
        public double? Min { get { throw null; } }
        public string Name { get { throw null; } }
        public double? Stdev { get { throw null; } }
        public double? Sum { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.QueryMetricUnitType? Unit { get { throw null; } }
        public double? Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryMetricUnitType : System.IEquatable<Azure.ResourceManager.Sql.Models.QueryMetricUnitType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryMetricUnitType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.QueryMetricUnitType Count { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.QueryMetricUnitType KB { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.QueryMetricUnitType Microseconds { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.QueryMetricUnitType Percentage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.QueryMetricUnitType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.QueryMetricUnitType left, Azure.ResourceManager.Sql.Models.QueryMetricUnitType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.QueryMetricUnitType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.QueryMetricUnitType left, Azure.ResourceManager.Sql.Models.QueryMetricUnitType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueryStatistics : Azure.ResourceManager.Models.ResourceData
    {
        public QueryStatistics() { }
        public string DatabaseName { get { throw null; } }
        public string EndTime { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.QueryMetricInterval> Intervals { get { throw null; } }
        public string QueryId { get { throw null; } }
        public string StartTime { get { throw null; } }
    }
    public partial class QueryStatisticsProperties
    {
        internal QueryStatisticsProperties() { }
        public string DatabaseName { get { throw null; } }
        public string EndTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.QueryMetricInterval> Intervals { get { throw null; } }
        public string QueryId { get { throw null; } }
        public string StartTime { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryTimeGrainType : System.IEquatable<Azure.ResourceManager.Sql.Models.QueryTimeGrainType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryTimeGrainType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.QueryTimeGrainType P1D { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.QueryTimeGrainType PT1H { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.QueryTimeGrainType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.QueryTimeGrainType left, Azure.ResourceManager.Sql.Models.QueryTimeGrainType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.QueryTimeGrainType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.QueryTimeGrainType left, Azure.ResourceManager.Sql.Models.QueryTimeGrainType right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendedActionCurrentState : System.IEquatable<Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendedActionCurrentState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState Active { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState Error { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState Executing { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState Expired { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState Ignored { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState Monitoring { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState Pending { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState PendingRevert { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState Resolved { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState RevertCancelled { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState Reverted { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState Reverting { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState Success { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState Verifying { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState left, Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState left, Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendedActionErrorInfo
    {
        internal RecommendedActionErrorInfo() { }
        public string ErrorCode { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.IsRetryable? IsRetryable { get { throw null; } }
    }
    public partial class RecommendedActionImpactRecord
    {
        internal RecommendedActionImpactRecord() { }
        public double? AbsoluteValue { get { throw null; } }
        public double? ChangeValueAbsolute { get { throw null; } }
        public double? ChangeValueRelative { get { throw null; } }
        public string DimensionName { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class RecommendedActionImplementationInfo
    {
        internal RecommendedActionImplementationInfo() { }
        public Azure.ResourceManager.Sql.Models.ImplementationMethod? Method { get { throw null; } }
        public string Script { get { throw null; } }
    }
    public enum RecommendedActionInitiatedBy
    {
        User = 0,
        System = 1,
    }
    public partial class RecommendedActionMetricInfo
    {
        internal RecommendedActionMetricInfo() { }
        public string MetricName { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string TimeGrain { get { throw null; } }
        public string Unit { get { throw null; } }
        public double? Value { get { throw null; } }
    }
    public partial class RecommendedActionStateInfo
    {
        public RecommendedActionStateInfo(Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState currentValue) { }
        public Azure.ResourceManager.Sql.Models.RecommendedActionInitiatedBy? ActionInitiatedBy { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.RecommendedActionCurrentState CurrentValue { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
    }
    public partial class RecommendedSensitivityLabelUpdate : Azure.ResourceManager.Models.ResourceData
    {
        public RecommendedSensitivityLabelUpdate() { }
        public string Column { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdateKind? Op { get { throw null; } set { } }
        public string Schema { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
    }
    public enum RecommendedSensitivityLabelUpdateKind
    {
        Enable = 0,
        Disable = 1,
    }
    public partial class RecommendedSensitivityLabelUpdateList
    {
        public RecommendedSensitivityLabelUpdateList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdate> Operations { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicationLinkType : System.IEquatable<Azure.ResourceManager.Sql.Models.ReplicationLinkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicationLinkType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ReplicationLinkType GEO { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ReplicationLinkType Named { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ReplicationLinkType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ReplicationLinkType left, Azure.ResourceManager.Sql.Models.ReplicationLinkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ReplicationLinkType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ReplicationLinkType left, Azure.ResourceManager.Sql.Models.ReplicationLinkType right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestedBackupStorageRedundancy : System.IEquatable<Azure.ResourceManager.Sql.Models.RequestedBackupStorageRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestedBackupStorageRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.RequestedBackupStorageRedundancy Geo { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RequestedBackupStorageRedundancy Local { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RequestedBackupStorageRedundancy Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.RequestedBackupStorageRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.RequestedBackupStorageRedundancy left, Azure.ResourceManager.Sql.Models.RequestedBackupStorageRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.RequestedBackupStorageRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.RequestedBackupStorageRedundancy left, Azure.ResourceManager.Sql.Models.RequestedBackupStorageRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceMoveDefinition
    {
        public ResourceMoveDefinition(string id) { }
        public string Id { get { throw null; } }
    }
    public partial class ResourceWithWritableName
    {
        public ResourceWithWritableName() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestorableDroppedDatabasePropertiesBackupStorageRedundancy : System.IEquatable<Azure.ResourceManager.Sql.Models.RestorableDroppedDatabasePropertiesBackupStorageRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestorableDroppedDatabasePropertiesBackupStorageRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.RestorableDroppedDatabasePropertiesBackupStorageRedundancy Geo { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RestorableDroppedDatabasePropertiesBackupStorageRedundancy Local { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.RestorableDroppedDatabasePropertiesBackupStorageRedundancy Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.RestorableDroppedDatabasePropertiesBackupStorageRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.RestorableDroppedDatabasePropertiesBackupStorageRedundancy left, Azure.ResourceManager.Sql.Models.RestorableDroppedDatabasePropertiesBackupStorageRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.RestorableDroppedDatabasePropertiesBackupStorageRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.RestorableDroppedDatabasePropertiesBackupStorageRedundancy left, Azure.ResourceManager.Sql.Models.RestorableDroppedDatabasePropertiesBackupStorageRedundancy right) { throw null; }
        public override string ToString() { throw null; }
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
    public enum RestorePointType
    {
        Continuous = 0,
        Discrete = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SampleSchemaName : System.IEquatable<Azure.ResourceManager.Sql.Models.SampleSchemaName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SampleSchemaName(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.SampleSchemaName AdventureWorksLT { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SampleSchemaName WideWorldImportersFull { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SampleSchemaName WideWorldImportersStd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.SampleSchemaName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.SampleSchemaName left, Azure.ResourceManager.Sql.Models.SampleSchemaName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.SampleSchemaName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.SampleSchemaName left, Azure.ResourceManager.Sql.Models.SampleSchemaName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecondaryType : System.IEquatable<Azure.ResourceManager.Sql.Models.SecondaryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecondaryType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.SecondaryType Geo { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SecondaryType Named { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.SecondaryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.SecondaryType left, Azure.ResourceManager.Sql.Models.SecondaryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.SecondaryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.SecondaryType left, Azure.ResourceManager.Sql.Models.SecondaryType right) { throw null; }
        public override string ToString() { throw null; }
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
    public enum SecurityAlertPolicyState
    {
        New = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public enum SecurityAlertsPolicyState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class SecurityEvent : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityEvent() { }
        public string ApplicationName { get { throw null; } }
        public string ClientIP { get { throw null; } }
        public string Database { get { throw null; } }
        public System.DateTimeOffset? EventOn { get { throw null; } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SecurityEventSqlInjectionAdditionalProperties SecurityEventSqlInjectionAdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SecurityEventType? SecurityEventType { get { throw null; } }
        public string Server { get { throw null; } }
        public string Subscription { get { throw null; } }
    }
    public partial class SecurityEventSqlInjectionAdditionalProperties
    {
        internal SecurityEventSqlInjectionAdditionalProperties() { }
        public int? ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public int? ErrorSeverity { get { throw null; } }
        public string Statement { get { throw null; } }
        public int? StatementHighlightLength { get { throw null; } }
        public int? StatementHighlightOffset { get { throw null; } }
        public string ThreatId { get { throw null; } }
    }
    public enum SecurityEventType
    {
        Undefined = 0,
        SqlInjectionVulnerability = 1,
        SqlInjectionExploit = 2,
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
    public partial class SensitivityLabelUpdate : Azure.ResourceManager.Models.ResourceData
    {
        public SensitivityLabelUpdate() { }
        public string Column { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateKind? Op { get { throw null; } set { } }
        public string Schema { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.SensitivityLabelData SensitivityLabel { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
    }
    public enum SensitivityLabelUpdateKind
    {
        Set = 0,
        Remove = 1,
    }
    public partial class SensitivityLabelUpdateList
    {
        public SensitivityLabelUpdateList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.SensitivityLabelUpdate> Operations { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerConnectionType : System.IEquatable<Azure.ResourceManager.Sql.Models.ServerConnectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerConnectionType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ServerConnectionType Default { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServerConnectionType Proxy { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServerConnectionType Redirect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ServerConnectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ServerConnectionType left, Azure.ResourceManager.Sql.Models.ServerConnectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ServerConnectionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ServerConnectionType left, Azure.ResourceManager.Sql.Models.ServerConnectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerDnsAliasAcquisition
    {
        public ServerDnsAliasAcquisition(string oldServerDnsAliasId) { }
        public string OldServerDnsAliasId { get { throw null; } }
    }
    public partial class ServerExternalAdministrator
    {
        public ServerExternalAdministrator() { }
        public Azure.ResourceManager.Sql.Models.AdministratorType? AdministratorType { get { throw null; } set { } }
        public bool? AzureADOnlyAuthentication { get { throw null; } set { } }
        public string Login { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.PrincipalType? PrincipalType { get { throw null; } set { } }
        public System.Guid? Sid { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class ServerInfo
    {
        public ServerInfo(string serverId) { }
        public string ServerId { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerNetworkAccessFlag : System.IEquatable<Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerNetworkAccessFlag(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag Disabled { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag left, Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag left, Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerOperation : Azure.ResourceManager.Models.ResourceData
    {
        public ServerOperation() { }
        public string Description { get { throw null; } }
        public int? ErrorCode { get { throw null; } }
        public string ErrorDescription { get { throw null; } }
        public int? ErrorSeverity { get { throw null; } }
        public System.DateTimeOffset? EstimatedCompletionOn { get { throw null; } }
        public bool? IsCancellable { get { throw null; } }
        public bool? IsUserError { get { throw null; } }
        public string Operation { get { throw null; } }
        public string OperationFriendlyName { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public string ServerName { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ManagementOperationState? State { get { throw null; } }
    }
    public partial class ServerPrivateEndpointConnection
    {
        internal ServerPrivateEndpointConnection() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerTrustGroupPropertiesTrustScopesItem : System.IEquatable<Azure.ResourceManager.Sql.Models.ServerTrustGroupPropertiesTrustScopesItem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerTrustGroupPropertiesTrustScopesItem(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ServerTrustGroupPropertiesTrustScopesItem GlobalTransactions { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServerTrustGroupPropertiesTrustScopesItem ServiceBroker { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ServerTrustGroupPropertiesTrustScopesItem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ServerTrustGroupPropertiesTrustScopesItem left, Azure.ResourceManager.Sql.Models.ServerTrustGroupPropertiesTrustScopesItem right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ServerTrustGroupPropertiesTrustScopesItem (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ServerTrustGroupPropertiesTrustScopesItem left, Azure.ResourceManager.Sql.Models.ServerTrustGroupPropertiesTrustScopesItem right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerUsage
    {
        internal ServerUsage() { }
        public double? CurrentValue { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public double? Limit { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerWorkspaceFeature : System.IEquatable<Azure.ResourceManager.Sql.Models.ServerWorkspaceFeature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerWorkspaceFeature(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.ServerWorkspaceFeature Connected { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.ServerWorkspaceFeature Disconnected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.ServerWorkspaceFeature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.ServerWorkspaceFeature left, Azure.ResourceManager.Sql.Models.ServerWorkspaceFeature right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.ServerWorkspaceFeature (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.ServerWorkspaceFeature left, Azure.ResourceManager.Sql.Models.ServerWorkspaceFeature right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CapabilityStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.AutoPauseDelayTimeRange SupportedAutoPauseDelay { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.LicenseTypeCapability> SupportedLicenseTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.MaintenanceConfigurationCapability> SupportedMaintenanceConfigurations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.MaxSizeRangeCapability> SupportedMaxSizes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.MinCapacityCapability> SupportedMinCapacities { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlAgentConfigurationPropertiesState : System.IEquatable<Azure.ResourceManager.Sql.Models.SqlAgentConfigurationPropertiesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlAgentConfigurationPropertiesState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.SqlAgentConfigurationPropertiesState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SqlAgentConfigurationPropertiesState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.SqlAgentConfigurationPropertiesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.SqlAgentConfigurationPropertiesState left, Azure.ResourceManager.Sql.Models.SqlAgentConfigurationPropertiesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.SqlAgentConfigurationPropertiesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.SqlAgentConfigurationPropertiesState left, Azure.ResourceManager.Sql.Models.SqlAgentConfigurationPropertiesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlDatabasePatch
    {
        public SqlDatabasePatch() { }
        public int? AutoPauseDelay { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CatalogCollationType? CatalogCollation { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CurrentBackupStorageRedundancy? CurrentBackupStorageRedundancy { get { throw null; } }
        public string CurrentServiceObjectiveName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SqlSku CurrentSku { get { throw null; } }
        public System.Guid? DatabaseId { get { throw null; } }
        public string DefaultSecondaryLocation { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public string ElasticPoolId { get { throw null; } set { } }
        public string FailoverGroupId { get { throw null; } }
        public int? HighAvailabilityReplicaCount { get { throw null; } set { } }
        public bool? IsInfraEncryptionEnabled { get { throw null; } }
        public bool? IsLedgerOn { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.DatabaseLicenseType? LicenseType { get { throw null; } set { } }
        public string LongTermRetentionBackupResourceId { get { throw null; } set { } }
        public string MaintenanceConfigurationId { get { throw null; } set { } }
        public long? MaxLogSizeBytes { get { throw null; } }
        public long? MaxSizeBytes { get { throw null; } set { } }
        public double? MinCapacity { get { throw null; } set { } }
        public System.DateTimeOffset? PausedOn { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.DatabaseReadScale? ReadScale { get { throw null; } set { } }
        public string RecoverableDatabaseId { get { throw null; } set { } }
        public string RecoveryServicesRecoveryPointId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.RequestedBackupStorageRedundancy? RequestedBackupStorageRedundancy { get { throw null; } set { } }
        public string RequestedServiceObjectiveName { get { throw null; } }
        public string RestorableDroppedDatabaseId { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInOn { get { throw null; } set { } }
        public System.DateTimeOffset? ResumedOn { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SampleSchemaName? SampleName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecondaryType? SecondaryType { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? SourceDatabaseDeletionOn { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.DatabaseStatus? Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlDayOfWeek : System.IEquatable<Azure.ResourceManager.Sql.Models.SqlDayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlDayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.SqlDayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SqlDayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SqlDayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SqlDayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SqlDayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SqlDayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.SqlDayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.SqlDayOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.SqlDayOfWeek left, Azure.ResourceManager.Sql.Models.SqlDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.SqlDayOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.SqlDayOfWeek left, Azure.ResourceManager.Sql.Models.SqlDayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlMetric
    {
        internal SqlMetric() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.MetricValue> MetricValues { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.MetricName Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string TimeGrain { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.UnitType? Unit { get { throw null; } }
    }
    public partial class SqlServerPatch
    {
        public SqlServerPatch() { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ServerExternalAdministrator Administrators { get { throw null; } set { } }
        public System.Guid? FederatedClientId { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string KeyId { get { throw null; } set { } }
        public string MinimalTlsVersion { get { throw null; } set { } }
        public string PrimaryUserAssignedIdentityId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ServerPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag? RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public string State { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ServerWorkspaceFeature? WorkspaceFeature { get { throw null; } }
    }
    public partial class SqlSku
    {
        public SqlSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountType : System.IEquatable<Azure.ResourceManager.Sql.Models.StorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.StorageAccountType GRS { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.StorageAccountType LRS { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.StorageAccountType ZRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.StorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.StorageAccountType left, Azure.ResourceManager.Sql.Models.StorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.StorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.StorageAccountType left, Azure.ResourceManager.Sql.Models.StorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageKeyType : System.IEquatable<Azure.ResourceManager.Sql.Models.StorageKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.StorageKeyType SharedAccessKey { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.StorageKeyType StorageAccessKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.StorageKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.StorageKeyType left, Azure.ResourceManager.Sql.Models.StorageKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.StorageKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.StorageKeyType left, Azure.ResourceManager.Sql.Models.StorageKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SyncAgentKeyProperties
    {
        internal SyncAgentKeyProperties() { }
        public string SyncAgentKey { get { throw null; } }
    }
    public partial class SyncAgentLinkedDatabase : Azure.ResourceManager.Models.ResourceData
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
        public System.DateTimeOffset? LastUpdateOn { get { throw null; } }
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
    public partial class SyncGroupLogProperties
    {
        internal SyncGroupLogProperties() { }
        public string Details { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SyncGroupLogType? LogType { get { throw null; } }
        public string OperationStatus { get { throw null; } }
        public string Source { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public System.Guid? TracingId { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TableTemporalType : System.IEquatable<Azure.ResourceManager.Sql.Models.TableTemporalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TableTemporalType(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.TableTemporalType HistoryTable { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.TableTemporalType NonTemporalTable { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.TableTemporalType SystemVersionedTemporalTable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.TableTemporalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.TableTemporalType left, Azure.ResourceManager.Sql.Models.TableTemporalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.TableTemporalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.TableTemporalType left, Azure.ResourceManager.Sql.Models.TableTemporalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetBackupStorageRedundancy : System.IEquatable<Azure.ResourceManager.Sql.Models.TargetBackupStorageRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetBackupStorageRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.TargetBackupStorageRedundancy Geo { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.TargetBackupStorageRedundancy Local { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.TargetBackupStorageRedundancy Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sql.Models.TargetBackupStorageRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sql.Models.TargetBackupStorageRedundancy left, Azure.ResourceManager.Sql.Models.TargetBackupStorageRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sql.Models.TargetBackupStorageRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sql.Models.TargetBackupStorageRedundancy left, Azure.ResourceManager.Sql.Models.TargetBackupStorageRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TdeCertificate : Azure.ResourceManager.Models.ResourceData
    {
        public TdeCertificate() { }
        public string CertPassword { get { throw null; } set { } }
        public string PrivateBlob { get { throw null; } set { } }
    }
    public partial class TopQueries
    {
        internal TopQueries() { }
        public string AggregationFunction { get { throw null; } }
        public string EndTime { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.QueryTimeGrainType? IntervalType { get { throw null; } }
        public int? NumberOfQueries { get { throw null; } }
        public string ObservationMetric { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.QueryStatisticsProperties> Queries { get { throw null; } }
        public string StartTime { get { throw null; } }
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
    public enum TransparentDataEncryptionState
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
    public partial class UnlinkContent
    {
        public UnlinkContent() { }
        public bool? ForcedTermination { get { throw null; } set { } }
    }
    public partial class UpdateLongTermRetentionBackupOptions
    {
        public UpdateLongTermRetentionBackupOptions() { }
        public Azure.ResourceManager.Sql.Models.RequestedBackupStorageRedundancy? RequestedBackupStorageRedundancy { get { throw null; } set { } }
    }
    public partial class UpdateManagedInstanceDnsServersOperation : Azure.ResourceManager.Models.ResourceData
    {
        public UpdateManagedInstanceDnsServersOperation() { }
        public Azure.ResourceManager.Sql.Models.DnsRefreshConfigurationPropertiesStatus? Status { get { throw null; } }
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
    public partial class UsageName
    {
        internal UsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class VirtualClusterPatch
    {
        public VirtualClusterPatch() { }
        public System.Collections.Generic.IReadOnlyList<string> ChildResources { get { throw null; } }
        public string Family { get { throw null; } set { } }
        public string MaintenanceConfigurationId { get { throw null; } set { } }
        public string SubnetId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualNetworkRuleState : System.IEquatable<Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualNetworkRuleState(string value) { throw null; }
        public static Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState Failed { get { throw null; } }
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
}
