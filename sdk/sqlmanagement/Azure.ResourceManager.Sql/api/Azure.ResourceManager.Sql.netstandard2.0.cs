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
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy GetBackupShortTermRetentionPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.DatabaseAutomaticTuning GetDatabaseAutomaticTuning(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy GetDatabaseBlobAuditingPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy GetDatabaseSecurityAlertPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.DataMaskingPolicy GetDataMaskingPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.DataWarehouseUserActivities GetDataWarehouseUserActivities(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.DeletedServer GetDeletedServer(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ElasticPool GetElasticPool(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.EncryptionProtector GetEncryptionProtector(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy GetExtendedDatabaseBlobAuditingPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy GetExtendedServerBlobAuditingPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.FailoverGroup GetFailoverGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.FirewallRule GetFirewallRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.GeoBackupPolicy GetGeoBackupPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.InstanceFailoverGroup GetInstanceFailoverGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.InstancePool GetInstancePool(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.JobAgent GetJobAgent(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.JobCredential GetJobCredential(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.JobTargetGroup GetJobTargetGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.JobVersion GetJobVersion(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.LedgerDigestUploads GetLedgerDigestUploads(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption GetLogicalDatabaseTransparentDataEncryption(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.LongTermRetentionPolicy GetLongTermRetentionPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.MaintenanceWindowOptions GetMaintenanceWindowOptions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.MaintenanceWindows GetMaintenanceWindows(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedDatabase GetManagedDatabase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResult GetManagedDatabaseRestoreDetailsResult(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy GetManagedDatabaseSecurityAlertPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstance GetManagedInstance(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceAdministrator GetManagedInstanceAdministrator(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication GetManagedInstanceAzureADOnlyAuthentication(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy GetManagedInstanceDatabaseBackupShortTermRetentionPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema GetManagedInstanceDatabaseSchema(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable GetManagedInstanceDatabaseSchemaTable(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn GetManagedInstanceDatabaseSchemaTableColumn(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel GetManagedInstanceDatabaseSchemaTableColumnSensitivityLabel(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment GetManagedInstanceDatabaseVulnerabilityAssessment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline GetManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan GetManagedInstanceDatabaseVulnerabilityAssessmentScan(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector GetManagedInstanceEncryptionProtector(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceKey GetManagedInstanceKey(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy GetManagedInstanceLongTermRetentionPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceOperation GetManagedInstanceOperation(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection GetManagedInstancePrivateEndpointConnection(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstancePrivateLink GetManagedInstancePrivateLink(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment GetManagedInstanceVulnerabilityAssessment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy GetManagedRestorableDroppedDbBackupShortTermRetentionPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy GetManagedServerSecurityAlertPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedTransparentDataEncryption GetManagedTransparentDataEncryption(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.OutboundFirewallRule GetOutboundFirewallRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.PrivateEndpointConnection GetPrivateEndpointConnection(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.PrivateLinkResource GetPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.RecommendedAction GetRecommendedAction(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.RecoverableDatabase GetRecoverableDatabase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.RecoverableManagedDatabase GetRecoverableManagedDatabase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ReplicationLink GetReplicationLink(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup GetResourceGroupLongTermRetentionBackup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup GetResourceGroupLongTermRetentionManagedInstanceBackup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.RestorableDroppedDatabase GetRestorableDroppedDatabase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase GetRestorableDroppedManagedDatabase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.RestorePoint GetRestorePoint(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerAdvisor GetServerAdvisor(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerAutomaticTuning GetServerAutomaticTuning(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerAzureADAdministrator GetServerAzureADAdministrator(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication GetServerAzureADOnlyAuthentication(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerBlobAuditingPolicy GetServerBlobAuditingPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerCommunicationLink GetServerCommunicationLink(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerConnectionPolicy GetServerConnectionPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseAdvisor GetServerDatabaseAdvisor(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseSchema GetServerDatabaseSchema(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseSchemaTable GetServerDatabaseSchemaTable(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn GetServerDatabaseSchemaTableColumn(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabel GetServerDatabaseSchemaTableColumnSensitivityLabel(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment GetServerDatabaseVulnerabilityAssessment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaseline GetServerDatabaseVulnerabilityAssessmentRuleBaseline(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan GetServerDatabaseVulnerabilityAssessmentScan(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings GetServerDevOpsAuditingSettings(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerDnsAlias GetServerDnsAlias(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerJobAgentJobExecution GetServerJobAgentJobExecution(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep GetServerJobAgentJobExecutionStep(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget GetServerJobAgentJobExecutionStepTarget(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerJobAgentJobStep GetServerJobAgentJobStep(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep GetServerJobAgentJobVersionStep(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerKey GetServerKey(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerSecurityAlertPolicy GetServerSecurityAlertPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerTrustGroup GetServerTrustGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServerVulnerabilityAssessment GetServerVulnerabilityAssessment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.ServiceObjective GetServiceObjective(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SqlAgentConfiguration GetSqlAgentConfiguration(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SqlDatabase GetSqlDatabase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SqlJob GetSqlJob(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SqlServer GetSqlServer(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SqlTimeZone GetSqlTimeZone(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup GetSubscriptionLongTermRetentionBackup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup GetSubscriptionLongTermRetentionManagedInstanceBackup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SubscriptionUsage GetSubscriptionUsage(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SyncAgent GetSyncAgent(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SyncGroup GetSyncGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.SyncMember GetSyncMember(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.VirtualCluster GetVirtualCluster(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.VirtualNetworkRule GetVirtualNetworkRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.WorkloadClassifier GetWorkloadClassifier(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sql.WorkloadGroup GetWorkloadGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class BackupShortTermRetentionPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupShortTermRetentionPolicy() { }
        public virtual Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string policyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupShortTermRetentionPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy>, System.Collections.IEnumerable
    {
        protected BackupShortTermRetentionPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy> Get(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy>> GetAsync(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy> GetIfExists(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupShortTermRetentionPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public BackupShortTermRetentionPolicyData() { }
        public Azure.ResourceManager.Sql.Models.DiffBackupIntervalInHours? DiffBackupIntervalInHours { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
    }
    public partial class DatabaseAutomaticTuning : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAutomaticTuning() { }
        public virtual Azure.ResourceManager.Sql.DatabaseAutomaticTuningData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseAutomaticTuning> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseAutomaticTuning>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseAutomaticTuning> Update(Azure.ResourceManager.Sql.DatabaseAutomaticTuningData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseAutomaticTuning>> UpdateAsync(Azure.ResourceManager.Sql.DatabaseAutomaticTuningData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAutomaticTuningData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseAutomaticTuningData() { }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningMode? ActualState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningMode? DesiredState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Sql.Models.AutomaticTuningOptions> Options { get { throw null; } }
    }
    public partial class DatabaseBlobAuditingPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseBlobAuditingPolicy() { }
        public virtual Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string blobAuditingPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseBlobAuditingPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy>, System.Collections.IEnumerable
    {
        protected DatabaseBlobAuditingPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy> Get(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy>> GetAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy> GetIfExists(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy>.GetEnumerator() { throw null; }
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
    public partial class DatabaseSecurityAlertPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseSecurityAlertPolicy() { }
        public virtual Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseSecurityAlertPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy>, System.Collections.IEnumerable
    {
        protected DatabaseSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy> Get(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy>> GetAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy> GetIfExists(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseSecurityAlertPolicyData() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public bool? EmailAccountAdmins { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecurityAlertsPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
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
    public partial class DataMaskingPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataMaskingPolicy() { }
        public virtual Azure.ResourceManager.Sql.DataMaskingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DataMaskingPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.DataMaskingPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DataMaskingPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.DataMaskingPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DataMaskingRule> CreateOrUpdateDataMaskingRule(string dataMaskingRuleName, Azure.ResourceManager.Sql.Models.DataMaskingRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DataMaskingRule>> CreateOrUpdateDataMaskingRuleAsync(string dataMaskingRuleName, Azure.ResourceManager.Sql.Models.DataMaskingRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DataMaskingPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DataMaskingPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.DataMaskingRule> GetDataMaskingRules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.DataMaskingRule> GetDataMaskingRulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DataWarehouseUserActivities : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataWarehouseUserActivities() { }
        public virtual Azure.ResourceManager.Sql.DataWarehouseUserActivitiesData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string dataWarehouseUserActivityName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DataWarehouseUserActivities> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DataWarehouseUserActivities>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataWarehouseUserActivitiesCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DataWarehouseUserActivities>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DataWarehouseUserActivities>, System.Collections.IEnumerable
    {
        protected DataWarehouseUserActivitiesCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DataWarehouseUserActivities> Get(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.DataWarehouseUserActivities> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.DataWarehouseUserActivities> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DataWarehouseUserActivities>> GetAsync(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DataWarehouseUserActivities> GetIfExists(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DataWarehouseUserActivities>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.DataWarehouseUserActivities> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DataWarehouseUserActivities>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.DataWarehouseUserActivities> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DataWarehouseUserActivities>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataWarehouseUserActivitiesData : Azure.ResourceManager.Models.ResourceData
    {
        public DataWarehouseUserActivitiesData() { }
        public int? ActiveQueriesCount { get { throw null; } }
    }
    public partial class DeletedServer : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedServer() { }
        public virtual Azure.ResourceManager.Sql.DeletedServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string deletedServerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DeletedServer> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DeletedServer>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DeletedServer> Recover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.DeletedServer>> RecoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedServerCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DeletedServer>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DeletedServer>, System.Collections.IEnumerable
    {
        protected DeletedServerCollection() { }
        public virtual Azure.Response<bool> Exists(string deletedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deletedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DeletedServer> Get(string deletedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.DeletedServer> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.DeletedServer> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DeletedServer>> GetAsync(string deletedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DeletedServer> GetIfExists(string deletedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DeletedServer>> GetIfExistsAsync(string deletedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.DeletedServer> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.DeletedServer>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.DeletedServer> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.DeletedServer>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeletedServerData : Azure.ResourceManager.Models.ResourceData
    {
        public DeletedServerData() { }
        public System.DateTimeOffset? DeletionTime { get { throw null; } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public string OriginalId { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ElasticPool : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ElasticPool() { }
        public virtual Azure.ResourceManager.Sql.ElasticPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ElasticPool> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ElasticPool>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelElasticPoolOperation(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelElasticPoolOperationAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string elasticPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Failover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ElasticPool> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ElasticPool>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlDatabase> GetDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlDatabase> GetDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Sql.ElasticPool> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ElasticPool>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ElasticPool> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ElasticPool>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ElasticPool> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.PatchableElasticPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ElasticPool>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.PatchableElasticPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticPoolCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ElasticPool>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ElasticPool>, System.Collections.IEnumerable
    {
        protected ElasticPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ElasticPool> CreateOrUpdate(Azure.WaitUntil waitUntil, string elasticPoolName, Azure.ResourceManager.Sql.ElasticPoolData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ElasticPool>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string elasticPoolName, Azure.ResourceManager.Sql.ElasticPoolData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ElasticPool> Get(string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ElasticPool> GetAll(int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ElasticPool> GetAllAsync(int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ElasticPool>> GetAsync(string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ElasticPool> GetIfExists(string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ElasticPool>> GetIfExistsAsync(string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ElasticPool> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ElasticPool>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ElasticPool> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ElasticPool>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ElasticPoolData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ElasticPoolData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ElasticPoolLicenseType? LicenseType { get { throw null; } set { } }
        public string MaintenanceConfigurationId { get { throw null; } set { } }
        public long? MaxSizeBytes { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ElasticPoolPerDatabaseSettings PerDatabaseSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ElasticPoolState? State { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class EncryptionProtector : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EncryptionProtector() { }
        public virtual Azure.ResourceManager.Sql.EncryptionProtectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string encryptionProtectorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.EncryptionProtector> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.EncryptionProtector>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Revalidate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevalidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EncryptionProtectorCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.EncryptionProtector>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.EncryptionProtector>, System.Collections.IEnumerable
    {
        protected EncryptionProtectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.EncryptionProtector> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Sql.EncryptionProtectorData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.EncryptionProtector>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Sql.EncryptionProtectorData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.EncryptionProtector> Get(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.EncryptionProtector> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.EncryptionProtector> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.EncryptionProtector>> GetAsync(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.EncryptionProtector> GetIfExists(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.EncryptionProtector>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.EncryptionProtector> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.EncryptionProtector>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.EncryptionProtector> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.EncryptionProtector>.GetEnumerator() { throw null; }
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
    public partial class ExtendedDatabaseBlobAuditingPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExtendedDatabaseBlobAuditingPolicy() { }
        public virtual Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string blobAuditingPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExtendedDatabaseBlobAuditingPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy>, System.Collections.IEnumerable
    {
        protected ExtendedDatabaseBlobAuditingPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy> Get(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy>> GetAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy> GetIfExists(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy>.GetEnumerator() { throw null; }
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
    public partial class ExtendedServerBlobAuditingPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExtendedServerBlobAuditingPolicy() { }
        public virtual Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string blobAuditingPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExtendedServerBlobAuditingPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy>, System.Collections.IEnumerable
    {
        protected ExtendedServerBlobAuditingPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy> Get(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy>> GetAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy> GetIfExists(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy>.GetEnumerator() { throw null; }
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
    public partial class FailoverGroup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FailoverGroup() { }
        public virtual Azure.ResourceManager.Sql.FailoverGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FailoverGroup> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FailoverGroup>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string failoverGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroup> Failover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroup>> FailoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroup> ForceFailoverAllowDataLoss(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroup>> ForceFailoverAllowDataLossAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FailoverGroup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FailoverGroup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FailoverGroup> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FailoverGroup>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FailoverGroup> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FailoverGroup>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroup> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.PatchableFailoverGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroup>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.PatchableFailoverGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FailoverGroupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.FailoverGroup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.FailoverGroup>, System.Collections.IEnumerable
    {
        protected FailoverGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroup> CreateOrUpdate(Azure.WaitUntil waitUntil, string failoverGroupName, Azure.ResourceManager.Sql.FailoverGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FailoverGroup>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string failoverGroupName, Azure.ResourceManager.Sql.FailoverGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FailoverGroup> Get(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.FailoverGroup> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.FailoverGroup> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FailoverGroup>> GetAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FailoverGroup> GetIfExists(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FailoverGroup>> GetIfExistsAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.FailoverGroup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.FailoverGroup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.FailoverGroup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.FailoverGroup>.GetEnumerator() { throw null; }
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
    public partial class FirewallRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirewallRule() { }
        public virtual Azure.ResourceManager.Sql.FirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FirewallRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FirewallRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FirewallRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.FirewallRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.FirewallRule>, System.Collections.IEnumerable
    {
        protected FirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FirewallRule> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.Sql.FirewallRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.FirewallRule>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.Sql.FirewallRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FirewallRule> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.FirewallRule> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.FirewallRule> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FirewallRule>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FirewallRule> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FirewallRule>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.FirewallRule> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.FirewallRule>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.FirewallRule> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.FirewallRule>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirewallRuleData : Azure.ResourceManager.Sql.Models.ProxyResourceWithWritableName
    {
        public FirewallRuleData() { }
        public string EndIPAddress { get { throw null; } set { } }
        public string StartIPAddress { get { throw null; } set { } }
    }
    public partial class GeoBackupPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GeoBackupPolicy() { }
        public virtual Azure.ResourceManager.Sql.GeoBackupPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string geoBackupPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.GeoBackupPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.GeoBackupPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GeoBackupPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.GeoBackupPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.GeoBackupPolicy>, System.Collections.IEnumerable
    {
        protected GeoBackupPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.GeoBackupPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, Azure.ResourceManager.Sql.GeoBackupPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.GeoBackupPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, Azure.ResourceManager.Sql.GeoBackupPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.GeoBackupPolicy> Get(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.GeoBackupPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.GeoBackupPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.GeoBackupPolicy>> GetAsync(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.GeoBackupPolicy> GetIfExists(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.GeoBackupPolicy>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.GeoBackupPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.GeoBackupPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.GeoBackupPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.GeoBackupPolicy>.GetEnumerator() { throw null; }
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
    public partial class InstanceFailoverGroup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InstanceFailoverGroup() { }
        public virtual Azure.ResourceManager.Sql.InstanceFailoverGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string locationName, string failoverGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstanceFailoverGroup> Failover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstanceFailoverGroup>> FailoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstanceFailoverGroup> ForceFailoverAllowDataLoss(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstanceFailoverGroup>> ForceFailoverAllowDataLossAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstanceFailoverGroupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.InstanceFailoverGroup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.InstanceFailoverGroup>, System.Collections.IEnumerable
    {
        protected InstanceFailoverGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstanceFailoverGroup> CreateOrUpdate(Azure.WaitUntil waitUntil, string failoverGroupName, Azure.ResourceManager.Sql.InstanceFailoverGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstanceFailoverGroup>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string failoverGroupName, Azure.ResourceManager.Sql.InstanceFailoverGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroup> Get(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.InstanceFailoverGroup> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.InstanceFailoverGroup> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroup>> GetAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroup> GetIfExists(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroup>> GetIfExistsAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.InstanceFailoverGroup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.InstanceFailoverGroup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.InstanceFailoverGroup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.InstanceFailoverGroup>.GetEnumerator() { throw null; }
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
    public partial class InstancePool : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InstancePool() { }
        public virtual Azure.ResourceManager.Sql.InstancePoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstancePool> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstancePool>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instancePoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstancePool> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstancePool>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstance> GetManagedInstances(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstance> GetManagedInstancesAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.InstancePoolUsage> GetUsages(bool? expandChildren = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.InstancePoolUsage> GetUsagesAsync(bool? expandChildren = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstancePool> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstancePool>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstancePool> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstancePool>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstancePoolCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.InstancePool>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.InstancePool>, System.Collections.IEnumerable
    {
        protected InstancePoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstancePool> CreateOrUpdate(Azure.WaitUntil waitUntil, string instancePoolName, Azure.ResourceManager.Sql.InstancePoolData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.InstancePool>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string instancePoolName, Azure.ResourceManager.Sql.InstancePoolData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstancePool> Get(string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.InstancePool> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.InstancePool> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstancePool>> GetAsync(string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.InstancePool> GetIfExists(string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstancePool>> GetIfExistsAsync(string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.InstancePool> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.InstancePool>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.InstancePool> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.InstancePool>.GetEnumerator() { throw null; }
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
    public partial class JobAgent : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobAgent() { }
        public virtual Azure.ResourceManager.Sql.JobAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobAgent> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobAgent>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobAgent> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobAgent>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobCredential> GetJobCredential(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobCredential>> GetJobCredentialAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.JobCredentialCollection GetJobCredentials() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecution> GetJobExecutionsByAgent(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecution> GetJobExecutionsByAgentAsync(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobTargetGroup> GetJobTargetGroup(string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobTargetGroup>> GetJobTargetGroupAsync(string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.JobTargetGroupCollection GetJobTargetGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlJob> GetSqlJob(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlJob>> GetSqlJobAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SqlJobCollection GetSqlJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobAgent> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobAgent>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobAgent> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobAgent>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobAgentCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobAgent>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobAgent>, System.Collections.IEnumerable
    {
        protected JobAgentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.JobAgent> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobAgentName, Azure.ResourceManager.Sql.JobAgentData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.JobAgent>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobAgentName, Azure.ResourceManager.Sql.JobAgentData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobAgent> Get(string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.JobAgent> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.JobAgent> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobAgent>> GetAsync(string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobAgent> GetIfExists(string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobAgent>> GetIfExistsAsync(string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.JobAgent> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobAgent>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.JobAgent> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobAgent>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobAgentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public JobAgentData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string DatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobAgentState? State { get { throw null; } }
    }
    public partial class JobCredential : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobCredential() { }
        public virtual Azure.ResourceManager.Sql.JobCredentialData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string credentialName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobCredential> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobCredential>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobCredentialCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobCredential>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobCredential>, System.Collections.IEnumerable
    {
        protected JobCredentialCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.JobCredential> CreateOrUpdate(Azure.WaitUntil waitUntil, string credentialName, Azure.ResourceManager.Sql.JobCredentialData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.JobCredential>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string credentialName, Azure.ResourceManager.Sql.JobCredentialData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobCredential> Get(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.JobCredential> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.JobCredential> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobCredential>> GetAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobCredential> GetIfExists(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobCredential>> GetIfExistsAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.JobCredential> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobCredential>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.JobCredential> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobCredential>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobCredentialData : Azure.ResourceManager.Models.ResourceData
    {
        public JobCredentialData() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class JobExecutionData : Azure.ResourceManager.Models.ResourceData
    {
        public JobExecutionData() { }
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
    public partial class JobTargetGroup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobTargetGroup() { }
        public virtual Azure.ResourceManager.Sql.JobTargetGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string targetGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobTargetGroup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobTargetGroup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobTargetGroupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobTargetGroup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobTargetGroup>, System.Collections.IEnumerable
    {
        protected JobTargetGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.JobTargetGroup> CreateOrUpdate(Azure.WaitUntil waitUntil, string targetGroupName, Azure.ResourceManager.Sql.JobTargetGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.JobTargetGroup>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string targetGroupName, Azure.ResourceManager.Sql.JobTargetGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobTargetGroup> Get(string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.JobTargetGroup> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.JobTargetGroup> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobTargetGroup>> GetAsync(string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobTargetGroup> GetIfExists(string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobTargetGroup>> GetIfExistsAsync(string targetGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.JobTargetGroup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobTargetGroup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.JobTargetGroup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobTargetGroup>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobTargetGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public JobTargetGroupData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.JobTarget> Members { get { throw null; } }
    }
    public partial class JobVersion : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobVersion() { }
        public virtual Azure.ResourceManager.Sql.JobVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, string jobVersion) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobVersion> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobVersion>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep> GetServerJobAgentJobVersionStep(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep>> GetServerJobAgentJobVersionStepAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerJobAgentJobVersionStepCollection GetServerJobAgentJobVersionSteps() { throw null; }
    }
    public partial class JobVersionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobVersion>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobVersion>, System.Collections.IEnumerable
    {
        protected JobVersionCollection() { }
        public virtual Azure.Response<bool> Exists(int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobVersion> Get(int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.JobVersion> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.JobVersion> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobVersion>> GetAsync(int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobVersion> GetIfExists(int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobVersion>> GetIfExistsAsync(int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.JobVersion> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.JobVersion>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.JobVersion> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.JobVersion>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public JobVersionData() { }
    }
    public partial class LedgerDigestUploads : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LedgerDigestUploads() { }
        public virtual Azure.ResourceManager.Sql.LedgerDigestUploadsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string ledgerDigestUploads) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LedgerDigestUploads> Disable(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LedgerDigestUploads>> DisableAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LedgerDigestUploads> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LedgerDigestUploads>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LedgerDigestUploadsCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.LedgerDigestUploads>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.LedgerDigestUploads>, System.Collections.IEnumerable
    {
        protected LedgerDigestUploadsCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LedgerDigestUploads> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, Azure.ResourceManager.Sql.LedgerDigestUploadsData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LedgerDigestUploads>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, Azure.ResourceManager.Sql.LedgerDigestUploadsData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LedgerDigestUploads> Get(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.LedgerDigestUploads> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.LedgerDigestUploads> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LedgerDigestUploads>> GetAsync(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LedgerDigestUploads> GetIfExists(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LedgerDigestUploads>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.LedgerDigestUploads> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.LedgerDigestUploads>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.LedgerDigestUploads> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.LedgerDigestUploads>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LedgerDigestUploadsData : Azure.ResourceManager.Models.ResourceData
    {
        public LedgerDigestUploadsData() { }
        public string DigestStorageEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.LedgerDigestUploadsState? State { get { throw null; } }
    }
    public partial class LogicalDatabaseTransparentDataEncryption : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicalDatabaseTransparentDataEncryption() { }
        public virtual Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string tdeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicalDatabaseTransparentDataEncryptionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption>, System.Collections.IEnumerable
    {
        protected LogicalDatabaseTransparentDataEncryptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption> Get(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption>> GetAsync(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption> GetIfExists(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicalDatabaseTransparentDataEncryptionData : Azure.ResourceManager.Models.ResourceData
    {
        public LogicalDatabaseTransparentDataEncryptionData() { }
        public Azure.ResourceManager.Sql.Models.TransparentDataEncryptionState? State { get { throw null; } set { } }
    }
    public partial class LongTermRetentionBackupData : Azure.ResourceManager.Models.ResourceData
    {
        public LongTermRetentionBackupData() { }
        public System.DateTimeOffset? BackupExpirationTime { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.BackupStorageRedundancy? BackupStorageRedundancy { get { throw null; } }
        public System.DateTimeOffset? BackupTime { get { throw null; } }
        public System.DateTimeOffset? DatabaseDeletionTime { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.BackupStorageRedundancy? RequestedBackupStorageRedundancy { get { throw null; } set { } }
        public System.DateTimeOffset? ServerCreateTime { get { throw null; } }
        public string ServerName { get { throw null; } }
    }
    public partial class LongTermRetentionPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LongTermRetentionPolicy() { }
        public virtual Azure.ResourceManager.Sql.LongTermRetentionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string policyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LongTermRetentionPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LongTermRetentionPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LongTermRetentionPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.LongTermRetentionPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.LongTermRetentionPolicy>, System.Collections.IEnumerable
    {
        protected LongTermRetentionPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LongTermRetentionPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.LongTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.LongTermRetentionPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.LongTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LongTermRetentionPolicy> Get(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.LongTermRetentionPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.LongTermRetentionPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LongTermRetentionPolicy>> GetAsync(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LongTermRetentionPolicy> GetIfExists(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LongTermRetentionPolicy>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.LongTermRetentionPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.LongTermRetentionPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.LongTermRetentionPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.LongTermRetentionPolicy>.GetEnumerator() { throw null; }
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
    public partial class MaintenanceWindowOptions : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenanceWindowOptions() { }
        public virtual Azure.ResourceManager.Sql.MaintenanceWindowOptionsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.MaintenanceWindowOptions> Get(string maintenanceWindowOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.MaintenanceWindowOptions>> GetAsync(string maintenanceWindowOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class MaintenanceWindows : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenanceWindows() { }
        public virtual Azure.ResourceManager.Sql.MaintenanceWindowsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdate(Azure.WaitUntil waitUntil, string maintenanceWindowName, Azure.ResourceManager.Sql.MaintenanceWindowsData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string maintenanceWindowName, Azure.ResourceManager.Sql.MaintenanceWindowsData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.MaintenanceWindows> Get(string maintenanceWindowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.MaintenanceWindows>> GetAsync(string maintenanceWindowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaintenanceWindowsData : Azure.ResourceManager.Models.ResourceData
    {
        public MaintenanceWindowsData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.MaintenanceWindowTimeRange> TimeRanges { get { throw null; } }
    }
    public partial class ManagedBackupShortTermRetentionPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedBackupShortTermRetentionPolicyData() { }
        public int? RetentionDays { get { throw null; } set { } }
    }
    public partial class ManagedDatabase : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedDatabase() { }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabase> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabase>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CompleteRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CompleteDatabaseRestoreDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CompleteRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CompleteDatabaseRestoreDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabase> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabase>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel> GetCurrentManagedDatabaseSensitivityLabels(string skipToken = null, bool? count = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel> GetCurrentManagedDatabaseSensitivityLabelsAsync(string skipToken = null, bool? count = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn> GetManagedDatabaseColumnsByDatabase(System.Collections.Generic.IEnumerable<string> schema = null, System.Collections.Generic.IEnumerable<string> table = null, System.Collections.Generic.IEnumerable<string> column = null, System.Collections.Generic.IEnumerable<string> orderBy = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn> GetManagedDatabaseColumnsByDatabaseAsync(System.Collections.Generic.IEnumerable<string> schema = null, System.Collections.Generic.IEnumerable<string> table = null, System.Collections.Generic.IEnumerable<string> column = null, System.Collections.Generic.IEnumerable<string> orderBy = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceQuery> GetManagedDatabaseQuery(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.ManagedInstanceQuery>> GetManagedDatabaseQueryAsync(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResult> GetManagedDatabaseRestoreDetailsResult(Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResult>> GetManagedDatabaseRestoreDetailsResultAsync(Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResultCollection GetManagedDatabaseRestoreDetailsResults() { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyCollection GetManagedDatabaseSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy> GetManagedDatabaseSecurityAlertPolicy(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy>> GetManagedDatabaseSecurityAlertPolicyAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SecurityEvent> GetManagedDatabaseSecurityEventsByDatabase(string filter = null, int? skip = default(int?), int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SecurityEvent> GetManagedDatabaseSecurityEventsByDatabaseAsync(string filter = null, int? skip = default(int?), int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicyCollection GetManagedInstanceDatabaseBackupShortTermRetentionPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy> GetManagedInstanceDatabaseBackupShortTermRetentionPolicy(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy>> GetManagedInstanceDatabaseBackupShortTermRetentionPolicyAsync(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema> GetManagedInstanceDatabaseSchema(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema>> GetManagedInstanceDatabaseSchemaAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaCollection GetManagedInstanceDatabaseSchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment> GetManagedInstanceDatabaseVulnerabilityAssessment(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment>> GetManagedInstanceDatabaseVulnerabilityAssessmentAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentCollection GetManagedInstanceDatabaseVulnerabilityAssessments() { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyCollection GetManagedInstanceLongTermRetentionPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy> GetManagedInstanceLongTermRetentionPolicy(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy>> GetManagedInstanceLongTermRetentionPolicyAsync(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption> GetManagedTransparentDataEncryption(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption>> GetManagedTransparentDataEncryptionAsync(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionCollection GetManagedTransparentDataEncryptions() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.QueryStatistics> GetQueryStatistics(string queryId, string startTime = null, string endTime = null, Azure.ResourceManager.Sql.Models.QueryTimeGrainType? interval = default(Azure.ResourceManager.Sql.Models.QueryTimeGrainType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.QueryStatistics> GetQueryStatisticsAsync(string queryId, string startTime = null, string endTime = null, Azure.ResourceManager.Sql.Models.QueryTimeGrainType? interval = default(Azure.ResourceManager.Sql.Models.QueryTimeGrainType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel> GetRecommendedManagedDatabaseSensitivityLabels(string skipToken = null, bool? includeDisabledRecommendations = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel> GetRecommendedManagedDatabaseSensitivityLabelsAsync(string skipToken = null, bool? includeDisabledRecommendations = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabase> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabase>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabase> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabase>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedDatabase> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.PatchableManagedDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedDatabase>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.PatchableManagedDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateManagedDatabaseSensitivityLabel(Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateList parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateManagedDatabaseSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateList parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateRecommendedManagedDatabaseSensitivityLabel(Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdateList parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateRecommendedManagedDatabaseSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdateList parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabaseCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedDatabase>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedDatabase>, System.Collections.IEnumerable
    {
        protected ManagedDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedDatabase> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Sql.ManagedDatabaseData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedDatabase>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Sql.ManagedDatabaseData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabase> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedDatabase> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedDatabase> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabase>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabase> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabase>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedDatabase> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedDatabase>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedDatabase> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedDatabase>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedDatabaseData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedDatabaseData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
        public System.Uri StorageContainerUri { get { throw null; } set { } }
    }
    public partial class ManagedDatabaseRestoreDetailsResult : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedDatabaseRestoreDetailsResult() { }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string restoreDetailsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResult> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResult>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabaseRestoreDetailsResultCollection : Azure.ResourceManager.Core.ArmCollection
    {
        protected ManagedDatabaseRestoreDetailsResultCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResult> Get(Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResult>> GetAsync(Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResult> GetIfExists(Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseRestoreDetailsResult>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.RestoreDetailsName restoreDetailsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabaseRestoreDetailsResultData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedDatabaseRestoreDetailsResultData() { }
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
    public partial class ManagedDatabaseSecurityAlertPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedDatabaseSecurityAlertPolicy() { }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDatabaseSecurityAlertPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy>, System.Collections.IEnumerable
    {
        protected ManagedDatabaseSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy> Get(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy>> GetAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy> GetIfExists(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedDatabaseSecurityAlertPolicy>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedDatabaseSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedDatabaseSecurityAlertPolicyData() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public bool? EmailAccountAdmins { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ManagedInstance : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstance() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstance> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstance>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateManagedInstanceTdeCertificate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TdeCertificate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateManagedInstanceTdeCertificateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TdeCertificate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Failover(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ReplicaType? replicaType = default(Azure.ResourceManager.Sql.Models.ReplicaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ReplicaType? replicaType = default(Azure.ResourceManager.Sql.Models.ReplicaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstance> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstance>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedDatabase> GetInaccessibleManagedDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedDatabase> GetInaccessibleManagedDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedDatabase> GetManagedDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedDatabase>> GetManagedDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedDatabaseCollection GetManagedDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAdministrator> GetManagedInstanceAdministrator(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAdministrator>> GetManagedInstanceAdministratorAsync(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceAdministratorCollection GetManagedInstanceAdministrators() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication> GetManagedInstanceAzureADOnlyAuthentication(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication>> GetManagedInstanceAzureADOnlyAuthenticationAsync(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationCollection GetManagedInstanceAzureADOnlyAuthentications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector> GetManagedInstanceEncryptionProtector(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector>> GetManagedInstanceEncryptionProtectorAsync(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorCollection GetManagedInstanceEncryptionProtectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceKey> GetManagedInstanceKey(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceKey>> GetManagedInstanceKeyAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceKeyCollection GetManagedInstanceKeys() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperation> GetManagedInstanceOperation(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperation>> GetManagedInstanceOperationAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceOperationCollection GetManagedInstanceOperations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection> GetManagedInstancePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection>> GetManagedInstancePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionCollection GetManagedInstancePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateLink> GetManagedInstancePrivateLink(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateLink>> GetManagedInstancePrivateLinkAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstancePrivateLinkCollection GetManagedInstancePrivateLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment> GetManagedInstanceVulnerabilityAssessment(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment>> GetManagedInstanceVulnerabilityAssessmentAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentCollection GetManagedInstanceVulnerabilityAssessments() { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyCollection GetManagedServerSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy> GetManagedServerSecurityAlertPolicy(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy>> GetManagedServerSecurityAlertPolicyAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecoverableManagedDatabase> GetRecoverableManagedDatabase(string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecoverableManagedDatabase>> GetRecoverableManagedDatabaseAsync(string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.RecoverableManagedDatabaseCollection GetRecoverableManagedDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase> GetRestorableDroppedManagedDatabase(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase>> GetRestorableDroppedManagedDatabaseAsync(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseCollection GetRestorableDroppedManagedDatabases() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerTrustGroup> GetServerTrustGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerTrustGroup> GetServerTrustGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SqlAgentConfiguration GetSqlAgentConfiguration() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.TopQueries> GetTopQueries(int? numberOfQueries = default(int?), string databases = null, string startTime = null, string endTime = null, Azure.ResourceManager.Sql.Models.QueryTimeGrainType? interval = default(Azure.ResourceManager.Sql.Models.QueryTimeGrainType?), Azure.ResourceManager.Sql.Models.AggregationFunctionType? aggregationFunction = default(Azure.ResourceManager.Sql.Models.AggregationFunctionType?), Azure.ResourceManager.Sql.Models.MetricType? observationMetric = default(Azure.ResourceManager.Sql.Models.MetricType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.TopQueries> GetTopQueriesAsync(int? numberOfQueries = default(int?), string databases = null, string startTime = null, string endTime = null, Azure.ResourceManager.Sql.Models.QueryTimeGrainType? interval = default(Azure.ResourceManager.Sql.Models.QueryTimeGrainType?), Azure.ResourceManager.Sql.Models.AggregationFunctionType? aggregationFunction = default(Azure.ResourceManager.Sql.Models.AggregationFunctionType?), Azure.ResourceManager.Sql.Models.MetricType? observationMetric = default(Azure.ResourceManager.Sql.Models.MetricType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstance> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstance>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstance> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstance>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstance> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.PatchableManagedInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstance>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.PatchableManagedInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceAdministrator : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceAdministrator() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceAdministratorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string administratorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAdministrator> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAdministrator>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceAdministratorCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAdministrator>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAdministrator>, System.Collections.IEnumerable
    {
        protected ManagedInstanceAdministratorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceAdministrator> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AdministratorName administratorName, Azure.ResourceManager.Sql.ManagedInstanceAdministratorData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceAdministrator>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AdministratorName administratorName, Azure.ResourceManager.Sql.ManagedInstanceAdministratorData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAdministrator> Get(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceAdministrator> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceAdministrator> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAdministrator>> GetAsync(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAdministrator> GetIfExists(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAdministrator>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceAdministrator> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAdministrator>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceAdministrator> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAdministrator>.GetEnumerator() { throw null; }
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
    public partial class ManagedInstanceAzureADOnlyAuthentication : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceAzureADOnlyAuthentication() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string authenticationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceAzureADOnlyAuthenticationCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication>, System.Collections.IEnumerable
    {
        protected ManagedInstanceAzureADOnlyAuthenticationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthenticationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication> Get(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication>> GetAsync(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication> GetIfExists(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceAzureADOnlyAuthentication>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceAzureADOnlyAuthenticationData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstanceAzureADOnlyAuthenticationData() { }
        public bool? AzureADOnlyAuthentication { get { throw null; } set { } }
    }
    public partial class ManagedInstanceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstance>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstance>, System.Collections.IEnumerable
    {
        protected ManagedInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstance> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedInstanceName, Azure.ResourceManager.Sql.ManagedInstanceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstance>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedInstanceName, Azure.ResourceManager.Sql.ManagedInstanceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedInstanceName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedInstanceName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstance> Get(string managedInstanceName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstance> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstance> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstance>> GetAsync(string managedInstanceName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstance> GetIfExists(string managedInstanceName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstance>> GetIfExistsAsync(string managedInstanceName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstance> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstance>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstance> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstance>.GetEnumerator() { throw null; }
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
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
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
    public partial class ManagedInstanceDatabaseBackupShortTermRetentionPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseBackupShortTermRetentionPolicy() { }
        public virtual Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string policyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceDatabaseBackupShortTermRetentionPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy>, System.Collections.IEnumerable
    {
        protected ManagedInstanceDatabaseBackupShortTermRetentionPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy> Get(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy>> GetAsync(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy> GetIfExists(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseBackupShortTermRetentionPolicy>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchema : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseSchema() { }
        public virtual Azure.ResourceManager.Sql.DatabaseSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string schemaName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable> GetManagedInstanceDatabaseSchemaTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable>> GetManagedInstanceDatabaseSchemaTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableCollection GetManagedInstanceDatabaseSchemaTables() { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchemaCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema>, System.Collections.IEnumerable
    {
        protected ManagedInstanceDatabaseSchemaCollection() { }
        public virtual Azure.Response<bool> Exists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema> Get(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema>> GetAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema> GetIfExists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema>> GetIfExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchema>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchemaTable : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseSchemaTable() { }
        public virtual Azure.ResourceManager.Sql.DatabaseTableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn> GetManagedInstanceDatabaseSchemaTableColumn(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn>> GetManagedInstanceDatabaseSchemaTableColumnAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnCollection GetManagedInstanceDatabaseSchemaTableColumns() { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchemaTableCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable>, System.Collections.IEnumerable
    {
        protected ManagedInstanceDatabaseSchemaTableCollection() { }
        public virtual Azure.Response<bool> Exists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable> Get(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable>> GetAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable> GetIfExists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable>> GetIfExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTable>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchemaTableColumn : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseSchemaTableColumn() { }
        public virtual Azure.ResourceManager.Sql.DatabaseColumnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName, string columnName) { throw null; }
        public virtual Azure.Response DisableRecommendationManagedDatabaseSensitivityLabel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableRecommendationManagedDatabaseSensitivityLabelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableRecommendationManagedDatabaseSensitivityLabel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableRecommendationManagedDatabaseSensitivityLabelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel> GetManagedInstanceDatabaseSchemaTableColumnSensitivityLabel(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel>> GetManagedInstanceDatabaseSchemaTableColumnSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelCollection GetManagedInstanceDatabaseSchemaTableColumnSensitivityLabels() { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchemaTableColumnCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn>, System.Collections.IEnumerable
    {
        protected ManagedInstanceDatabaseSchemaTableColumnCollection() { }
        public virtual Azure.Response<bool> Exists(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn> Get(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn>> GetAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn> GetIfExists(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn>> GetIfExistsAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumn>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel() { }
        public virtual Azure.ResourceManager.Sql.SensitivityLabelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string schemaName, string tableName, string columnName, string sensitivityLabelSource) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelCollection : Azure.ResourceManager.Core.ArmCollection
    {
        protected ManagedInstanceDatabaseSchemaTableColumnSensitivityLabelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SensitivityLabelData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SensitivityLabelData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel> Get(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel>> GetAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel> GetIfExists(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseSchemaTableColumnSensitivityLabel>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceDatabaseVulnerabilityAssessment : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseVulnerabilityAssessment() { }
        public virtual Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string vulnerabilityAssessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline> GetManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline>> GetManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineAsync(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineCollection GetManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan> GetManagedInstanceDatabaseVulnerabilityAssessmentScan(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan>> GetManagedInstanceDatabaseVulnerabilityAssessmentScanAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScanCollection GetManagedInstanceDatabaseVulnerabilityAssessmentScans() { throw null; }
    }
    public partial class ManagedInstanceDatabaseVulnerabilityAssessmentCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment>, System.Collections.IEnumerable
    {
        protected ManagedInstanceDatabaseVulnerabilityAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment> Get(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment>> GetAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment> GetIfExists(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessment>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline() { }
        public virtual Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentRuleBaselineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string vulnerabilityAssessmentName, string ruleId, string baselineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineCollection : Azure.ResourceManager.Core.ArmCollection
    {
        protected ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaselineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentRuleBaselineData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentRuleBaselineData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline> Get(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline>> GetAsync(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline> GetIfExists(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentRuleBaseline>> GetIfExistsAsync(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceDatabaseVulnerabilityAssessmentScan : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceDatabaseVulnerabilityAssessmentScan() { }
        public virtual Azure.ResourceManager.Sql.VulnerabilityAssessmentScanRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string vulnerabilityAssessmentName, string scanId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentScansExport> Export(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentScansExport>> ExportAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation InitiateScan(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InitiateScanAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceDatabaseVulnerabilityAssessmentScanCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan>, System.Collections.IEnumerable
    {
        protected ManagedInstanceDatabaseVulnerabilityAssessmentScanCollection() { }
        public virtual Azure.Response<bool> Exists(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan> Get(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan>> GetAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan> GetIfExists(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan>> GetIfExistsAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceDatabaseVulnerabilityAssessmentScan>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceEncryptionProtector : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceEncryptionProtector() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string encryptionProtectorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Revalidate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevalidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceEncryptionProtectorCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector>, System.Collections.IEnumerable
    {
        protected ManagedInstanceEncryptionProtectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtectorData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector> Get(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector>> GetAsync(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector> GetIfExists(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceEncryptionProtector>.GetEnumerator() { throw null; }
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
    public partial class ManagedInstanceKey : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceKey() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string keyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceKey> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceKey>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceKeyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceKey>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceKey>, System.Collections.IEnumerable
    {
        protected ManagedInstanceKeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceKey> CreateOrUpdate(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.Sql.ManagedInstanceKeyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceKey>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.Sql.ManagedInstanceKeyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceKey> Get(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceKey> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceKey> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceKey>> GetAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceKey> GetIfExists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceKey>> GetIfExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceKey> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceKey>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceKey> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceKey>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceKeyData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstanceKeyData() { }
        public bool? AutoRotationEnabled { get { throw null; } }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ServerKeyType? ServerKeyType { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ManagedInstanceLongTermRetentionBackupData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstanceLongTermRetentionBackupData() { }
        public System.DateTimeOffset? BackupExpirationTime { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.BackupStorageRedundancy? BackupStorageRedundancy { get { throw null; } }
        public System.DateTimeOffset? BackupTime { get { throw null; } }
        public System.DateTimeOffset? DatabaseDeletionTime { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? ManagedInstanceCreateTime { get { throw null; } }
        public string ManagedInstanceName { get { throw null; } }
    }
    public partial class ManagedInstanceLongTermRetentionPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceLongTermRetentionPolicy() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string policyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceLongTermRetentionPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy>, System.Collections.IEnumerable
    {
        protected ManagedInstanceLongTermRetentionPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy> Get(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy>> GetAsync(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy> GetIfExists(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.ManagedInstanceLongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionPolicy>.GetEnumerator() { throw null; }
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
    public partial class ManagedInstanceOperation : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceOperation() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceOperationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string operationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperation> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperation>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceOperationCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceOperation>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceOperation>, System.Collections.IEnumerable
    {
        protected ManagedInstanceOperationCollection() { }
        public virtual Azure.Response<bool> Exists(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperation> Get(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceOperation> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceOperation> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperation>> GetAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperation> GetIfExists(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceOperation>> GetIfExistsAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceOperation> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceOperation>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceOperation> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceOperation>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceOperationData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstanceOperationData() { }
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
    public partial class ManagedInstancePrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstancePrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstancePrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected ManagedInstancePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnectionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateEndpointConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstancePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstancePrivateEndpointConnectionData() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ManagedInstancePrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ManagedInstancePrivateLink : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstancePrivateLink() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstancePrivateLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateLink> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateLink>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstancePrivateLinkCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateLink>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateLink>, System.Collections.IEnumerable
    {
        protected ManagedInstancePrivateLinkCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateLink> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstancePrivateLink> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstancePrivateLink> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateLink>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateLink> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstancePrivateLink>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstancePrivateLink> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateLink>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstancePrivateLink> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstancePrivateLink>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstancePrivateLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedInstancePrivateLinkData() { }
        public Azure.ResourceManager.Sql.Models.ManagedInstancePrivateLinkProperties Properties { get { throw null; } }
    }
    public partial class ManagedInstanceVulnerabilityAssessment : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceVulnerabilityAssessment() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string vulnerabilityAssessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceVulnerabilityAssessmentCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment>, System.Collections.IEnumerable
    {
        protected ManagedInstanceVulnerabilityAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessmentData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment> Get(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment>> GetAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment> GetIfExists(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedInstanceVulnerabilityAssessment>.GetEnumerator() { throw null; }
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
    public partial class ManagedRestorableDroppedDbBackupShortTermRetentionPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedRestorableDroppedDbBackupShortTermRetentionPolicy() { }
        public virtual Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string restorableDroppedDatabaseId, string policyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedRestorableDroppedDbBackupShortTermRetentionPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy>, System.Collections.IEnumerable
    {
        protected ManagedRestorableDroppedDbBackupShortTermRetentionPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, Azure.ResourceManager.Sql.ManagedBackupShortTermRetentionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy> Get(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy>> GetAsync(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy> GetIfExists(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedServerSecurityAlertPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedServerSecurityAlertPolicy() { }
        public virtual Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedServerSecurityAlertPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy>, System.Collections.IEnumerable
    {
        protected ManagedServerSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy> Get(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy>> GetAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy> GetIfExists(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedServerSecurityAlertPolicy>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedServerSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedServerSecurityAlertPolicyData() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public bool? EmailAccountAdmins { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecurityAlertsPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ManagedTransparentDataEncryption : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedTransparentDataEncryption() { }
        public virtual Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string tdeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedTransparentDataEncryptionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption>, System.Collections.IEnumerable
    {
        protected ManagedTransparentDataEncryptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, Azure.ResourceManager.Sql.ManagedTransparentDataEncryptionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption> Get(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption>> GetAsync(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption> GetIfExists(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ManagedTransparentDataEncryption>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedTransparentDataEncryptionData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedTransparentDataEncryptionData() { }
        public Azure.ResourceManager.Sql.Models.TransparentDataEncryptionState? State { get { throw null; } set { } }
    }
    public partial class OutboundFirewallRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OutboundFirewallRule() { }
        public virtual Azure.ResourceManager.Sql.OutboundFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string outboundRuleFqdn) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.OutboundFirewallRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.OutboundFirewallRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OutboundFirewallRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.OutboundFirewallRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.OutboundFirewallRule>, System.Collections.IEnumerable
    {
        protected OutboundFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.OutboundFirewallRule> CreateOrUpdate(Azure.WaitUntil waitUntil, string outboundRuleFqdn, Azure.ResourceManager.Sql.OutboundFirewallRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.OutboundFirewallRule>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string outboundRuleFqdn, Azure.ResourceManager.Sql.OutboundFirewallRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string outboundRuleFqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string outboundRuleFqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.OutboundFirewallRule> Get(string outboundRuleFqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.OutboundFirewallRule> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.OutboundFirewallRule> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.OutboundFirewallRule>> GetAsync(string outboundRuleFqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.OutboundFirewallRule> GetIfExists(string outboundRuleFqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.OutboundFirewallRule>> GetIfExistsAsync(string outboundRuleFqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.OutboundFirewallRule> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.OutboundFirewallRule>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.OutboundFirewallRule> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.OutboundFirewallRule>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OutboundFirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public OutboundFirewallRuleData() { }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.Sql.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.PrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.PrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.PrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.PrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.PrivateEndpointConnection> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Sql.PrivateEndpointConnectionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.PrivateEndpointConnection>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Sql.PrivateEndpointConnectionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.PrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.PrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.PrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.PrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.PrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.PrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.PrivateEndpointConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.PrivateEndpointConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.PrivateEndpointConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.PrivateEndpointConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateEndpointConnectionData() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.PrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.PrivateEndpointProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateLinkResource() { }
        public virtual Azure.ResourceManager.Sql.PrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.PrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.PrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.PrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.PrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.PrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.PrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.PrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.PrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.PrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.PrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.PrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.PrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.PrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.PrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateLinkResourceData() { }
        public Azure.ResourceManager.Sql.Models.PrivateLinkResourceProperties Properties { get { throw null; } }
    }
    public partial class RecommendedAction : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecommendedAction() { }
        public virtual Azure.ResourceManager.Sql.RecommendedActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string advisorName, string recommendedActionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecommendedAction> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecommendedAction>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecommendedAction> Update(Azure.ResourceManager.Sql.RecommendedActionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecommendedAction>> UpdateAsync(Azure.ResourceManager.Sql.RecommendedActionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecommendedActionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RecommendedAction>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RecommendedAction>, System.Collections.IEnumerable
    {
        protected RecommendedActionCollection() { }
        public virtual Azure.Response<bool> Exists(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecommendedAction> Get(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.RecommendedAction> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.RecommendedAction> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecommendedAction>> GetAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecommendedAction> GetIfExists(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecommendedAction>> GetIfExistsAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.RecommendedAction> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RecommendedAction>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.RecommendedAction> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RecommendedAction>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecommendedActionData : Azure.ResourceManager.Models.ResourceData
    {
        public RecommendedActionData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Details { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.RecommendedActionErrorInfo ErrorDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.RecommendedActionImpactRecord> EstimatedImpact { get { throw null; } }
        public System.TimeSpan? ExecuteActionDuration { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.RecommendedActionInitiatedBy? ExecuteActionInitiatedBy { get { throw null; } }
        public System.DateTimeOffset? ExecuteActionInitiatedTime { get { throw null; } }
        public System.DateTimeOffset? ExecuteActionStartTime { get { throw null; } }
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
        public System.DateTimeOffset? RevertActionInitiatedTime { get { throw null; } }
        public System.DateTimeOffset? RevertActionStartTime { get { throw null; } }
        public int? Score { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.RecommendedActionStateInfo State { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.RecommendedActionMetricInfo> TimeSeries { get { throw null; } }
        public System.DateTimeOffset? ValidSince { get { throw null; } }
    }
    public partial class RecoverableDatabase : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoverableDatabase() { }
        public virtual Azure.ResourceManager.Sql.RecoverableDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecoverableDatabase> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecoverableDatabase>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoverableDatabaseCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RecoverableDatabase>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RecoverableDatabase>, System.Collections.IEnumerable
    {
        protected RecoverableDatabaseCollection() { }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecoverableDatabase> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.RecoverableDatabase> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.RecoverableDatabase> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecoverableDatabase>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecoverableDatabase> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecoverableDatabase>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.RecoverableDatabase> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RecoverableDatabase>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.RecoverableDatabase> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RecoverableDatabase>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoverableDatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public RecoverableDatabaseData() { }
        public string Edition { get { throw null; } }
        public string ElasticPoolName { get { throw null; } }
        public System.DateTimeOffset? LastAvailableBackupDate { get { throw null; } }
        public string ServiceLevelObjective { get { throw null; } }
    }
    public partial class RecoverableManagedDatabase : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoverableManagedDatabase() { }
        public virtual Azure.ResourceManager.Sql.RecoverableManagedDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string recoverableDatabaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecoverableManagedDatabase> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecoverableManagedDatabase>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoverableManagedDatabaseCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RecoverableManagedDatabase>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RecoverableManagedDatabase>, System.Collections.IEnumerable
    {
        protected RecoverableManagedDatabaseCollection() { }
        public virtual Azure.Response<bool> Exists(string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecoverableManagedDatabase> Get(string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.RecoverableManagedDatabase> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.RecoverableManagedDatabase> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecoverableManagedDatabase>> GetAsync(string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecoverableManagedDatabase> GetIfExists(string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecoverableManagedDatabase>> GetIfExistsAsync(string recoverableDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.RecoverableManagedDatabase> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RecoverableManagedDatabase>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.RecoverableManagedDatabase> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RecoverableManagedDatabase>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoverableManagedDatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public RecoverableManagedDatabaseData() { }
        public string LastAvailableBackupDate { get { throw null; } }
    }
    public partial class ReplicationLink : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReplicationLink() { }
        public virtual Azure.ResourceManager.Sql.ReplicationLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string linkId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Failover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation FailoverAllowDataLoss(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAllowDataLossAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ReplicationLink> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ReplicationLink>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Unlink(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.UnlinkOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UnlinkAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.UnlinkOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReplicationLinkCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ReplicationLink>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ReplicationLink>, System.Collections.IEnumerable
    {
        protected ReplicationLinkCollection() { }
        public virtual Azure.Response<bool> Exists(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ReplicationLink> Get(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ReplicationLink> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ReplicationLink> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ReplicationLink>> GetAsync(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ReplicationLink> GetIfExists(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ReplicationLink>> GetIfExistsAsync(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ReplicationLink> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ReplicationLink>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ReplicationLink> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ReplicationLink>.GetEnumerator() { throw null; }
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
        public System.DateTimeOffset? StartTime { get { throw null; } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroup> GetInstanceFailoverGroup(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstanceFailoverGroup>> GetInstanceFailoverGroupAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.InstanceFailoverGroupCollection GetInstanceFailoverGroups(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.InstancePool> GetInstancePool(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.InstancePool>> GetInstancePoolAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string instancePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.InstancePoolCollection GetInstancePools(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> GetLongTermRetentionBackupsByResourceGroupLocation(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> GetLongTermRetentionBackupsByResourceGroupLocationAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> GetLongTermRetentionBackupsByResourceGroupServer(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> GetLongTermRetentionBackupsByResourceGroupServerAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstance(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, string managedInstanceName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> GetLongTermRetentionManagedInstanceBackupsByResourceGroupInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, string managedInstanceName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocation(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> GetLongTermRetentionManagedInstanceBackupsByResourceGroupLocationAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.ManagedInstance> GetManagedInstance(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string managedInstanceName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedInstance>> GetManagedInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string managedInstanceName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.ManagedInstanceCollection GetManagedInstances(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup> GetResourceGroupLongTermRetentionBackup(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup>> GetResourceGroupLongTermRetentionBackupAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackupCollection GetResourceGroupLongTermRetentionBackups(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup> GetResourceGroupLongTermRetentionManagedInstanceBackup(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup>> GetResourceGroupLongTermRetentionManagedInstanceBackupAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackupCollection GetResourceGroupLongTermRetentionManagedInstanceBackups(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, string managedInstanceName, string databaseName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.ServerTrustGroup> GetServerTrustGroup(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, string serverTrustGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerTrustGroup>> GetServerTrustGroupAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName, string serverTrustGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.ServerTrustGroupCollection GetServerTrustGroups(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string locationName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.SqlServer> GetSqlServer(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string serverName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServer>> GetSqlServerAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string serverName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.SqlServerCollection GetSqlServers(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.VirtualCluster> GetVirtualCluster(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualCluster>> GetVirtualClusterAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.VirtualClusterCollection GetVirtualClusters(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class ResourceGroupLongTermRetentionBackup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGroupLongTermRetentionBackup() { }
        public virtual Azure.ResourceManager.Sql.LongTermRetentionBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult> CopyByResourceGroup(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CopyLongTermRetentionBackupOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult>> CopyByResourceGroupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CopyLongTermRetentionBackupOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult> UpdateByResourceGroup(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.UpdateLongTermRetentionBackupOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult>> UpdateByResourceGroupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.UpdateLongTermRetentionBackupOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupLongTermRetentionBackupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup>, System.Collections.IEnumerable
    {
        protected ResourceGroupLongTermRetentionBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup> GetAll(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup> GetAllAsync(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup> GetIfExists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup>> GetIfExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionBackup>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGroupLongTermRetentionManagedInstanceBackup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGroupLongTermRetentionManagedInstanceBackup() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string locationName, string managedInstanceName, string databaseName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupLongTermRetentionManagedInstanceBackupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup>, System.Collections.IEnumerable
    {
        protected ResourceGroupLongTermRetentionManagedInstanceBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup> GetAll(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup> GetAllAsync(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup> GetIfExists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup>> GetIfExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ResourceGroupLongTermRetentionManagedInstanceBackup>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorableDroppedDatabase : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorableDroppedDatabase() { }
        public virtual Azure.ResourceManager.Sql.RestorableDroppedDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabase> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabase>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string restorableDroppedDatabaseId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabase> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabase>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabase> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabase>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabase> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabase>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorableDroppedDatabaseCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RestorableDroppedDatabase>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RestorableDroppedDatabase>, System.Collections.IEnumerable
    {
        protected RestorableDroppedDatabaseCollection() { }
        public virtual Azure.Response<bool> Exists(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabase> Get(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.RestorableDroppedDatabase> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.RestorableDroppedDatabase> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabase>> GetAsync(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabase> GetIfExists(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabase>> GetIfExistsAsync(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.RestorableDroppedDatabase> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RestorableDroppedDatabase>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.RestorableDroppedDatabase> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RestorableDroppedDatabase>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorableDroppedDatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public RestorableDroppedDatabaseData() { }
        public Azure.ResourceManager.Sql.Models.RestorableDroppedDatabasePropertiesBackupStorageRedundancy? BackupStorageRedundancy { get { throw null; } }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? DeletionDate { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreDate { get { throw null; } }
        public string ElasticPoolId { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public long? MaxSizeBytes { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class RestorableDroppedManagedDatabase : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorableDroppedManagedDatabase() { }
        public virtual Azure.ResourceManager.Sql.RestorableDroppedManagedDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string restorableDroppedDatabaseId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicyCollection GetManagedRestorableDroppedDbBackupShortTermRetentionPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy> GetManagedRestorableDroppedDbBackupShortTermRetentionPolicy(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy>> GetManagedRestorableDroppedDbBackupShortTermRetentionPolicyAsync(Azure.ResourceManager.Sql.Models.ManagedShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorableDroppedManagedDatabaseCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase>, System.Collections.IEnumerable
    {
        protected RestorableDroppedManagedDatabaseCollection() { }
        public virtual Azure.Response<bool> Exists(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase> Get(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase>> GetAsync(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase> GetIfExists(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase>> GetIfExistsAsync(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RestorableDroppedManagedDatabase>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorableDroppedManagedDatabaseData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RestorableDroppedManagedDatabaseData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? DeletionDate { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreDate { get { throw null; } }
    }
    public partial class RestorePoint : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorePoint() { }
        public virtual Azure.ResourceManager.Sql.RestorePointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string restorePointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorePoint> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorePoint>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RestorePoint>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RestorePoint>, System.Collections.IEnumerable
    {
        protected RestorePointCollection() { }
        public virtual Azure.Response<bool> Exists(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorePoint> Get(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.RestorePoint> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.RestorePoint> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorePoint>> GetAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorePoint> GetIfExists(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorePoint>> GetIfExistsAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.RestorePoint> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.RestorePoint>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.RestorePoint> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.RestorePoint>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorePointData : Azure.ResourceManager.Models.ResourceData
    {
        public RestorePointData() { }
        public System.DateTimeOffset? EarliestRestoreDate { get { throw null; } }
        public string Location { get { throw null; } }
        public System.DateTimeOffset? RestorePointCreationDate { get { throw null; } }
        public string RestorePointLabel { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.RestorePointType? RestorePointType { get { throw null; } }
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
    public partial class ServerAdvisor : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerAdvisor() { }
        public virtual Azure.ResourceManager.Sql.AdvisorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string advisorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAdvisor> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAdvisor>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAdvisor> Update(Azure.ResourceManager.Sql.AdvisorData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAdvisor>> UpdateAsync(Azure.ResourceManager.Sql.AdvisorData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAdvisorCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerAdvisor>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerAdvisor>, System.Collections.IEnumerable
    {
        protected ServerAdvisorCollection() { }
        public virtual Azure.Response<bool> Exists(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAdvisor> Get(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerAdvisor> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerAdvisor> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAdvisor>> GetAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAdvisor> GetIfExists(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAdvisor>> GetIfExistsAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerAdvisor> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerAdvisor>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerAdvisor> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerAdvisor>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerAutomaticTuning : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerAutomaticTuning() { }
        public virtual Azure.ResourceManager.Sql.ServerAutomaticTuningData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAutomaticTuning> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAutomaticTuning>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAutomaticTuning> Update(Azure.ResourceManager.Sql.ServerAutomaticTuningData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAutomaticTuning>> UpdateAsync(Azure.ResourceManager.Sql.ServerAutomaticTuningData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAutomaticTuningData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerAutomaticTuningData() { }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningServerMode? ActualState { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.AutomaticTuningServerMode? DesiredState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Sql.Models.AutomaticTuningServerOptions> Options { get { throw null; } }
    }
    public partial class ServerAzureADAdministrator : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerAzureADAdministrator() { }
        public virtual Azure.ResourceManager.Sql.ServerAzureADAdministratorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string administratorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAzureADAdministrator> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAzureADAdministrator>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAzureADAdministratorCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerAzureADAdministrator>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerAzureADAdministrator>, System.Collections.IEnumerable
    {
        protected ServerAzureADAdministratorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerAzureADAdministrator> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AdministratorName administratorName, Azure.ResourceManager.Sql.ServerAzureADAdministratorData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerAzureADAdministrator>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AdministratorName administratorName, Azure.ResourceManager.Sql.ServerAzureADAdministratorData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAzureADAdministrator> Get(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerAzureADAdministrator> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerAzureADAdministrator> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAzureADAdministrator>> GetAsync(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAzureADAdministrator> GetIfExists(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAzureADAdministrator>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerAzureADAdministrator> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerAzureADAdministrator>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerAzureADAdministrator> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerAzureADAdministrator>.GetEnumerator() { throw null; }
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
    public partial class ServerAzureADOnlyAuthentication : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerAzureADOnlyAuthentication() { }
        public virtual Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string authenticationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAzureADOnlyAuthenticationCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication>, System.Collections.IEnumerable
    {
        protected ServerAzureADOnlyAuthenticationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication> Get(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication>> GetAsync(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication> GetIfExists(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerAzureADOnlyAuthenticationData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerAzureADOnlyAuthenticationData() { }
        public bool? AzureADOnlyAuthentication { get { throw null; } set { } }
    }
    public partial class ServerBlobAuditingPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerBlobAuditingPolicy() { }
        public virtual Azure.ResourceManager.Sql.ServerBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string blobAuditingPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerBlobAuditingPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy>, System.Collections.IEnumerable
    {
        protected ServerBlobAuditingPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.ServerBlobAuditingPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Sql.ServerBlobAuditingPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy> Get(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy>> GetAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy> GetIfExists(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy>.GetEnumerator() { throw null; }
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
    public partial class ServerCommunicationLink : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerCommunicationLink() { }
        public virtual Azure.ResourceManager.Sql.ServerCommunicationLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string communicationLinkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerCommunicationLink> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerCommunicationLink>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerCommunicationLinkCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerCommunicationLink>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerCommunicationLink>, System.Collections.IEnumerable
    {
        protected ServerCommunicationLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerCommunicationLink> CreateOrUpdate(Azure.WaitUntil waitUntil, string communicationLinkName, Azure.ResourceManager.Sql.ServerCommunicationLinkData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerCommunicationLink>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string communicationLinkName, Azure.ResourceManager.Sql.ServerCommunicationLinkData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerCommunicationLink> Get(string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerCommunicationLink> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerCommunicationLink> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerCommunicationLink>> GetAsync(string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerCommunicationLink> GetIfExists(string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerCommunicationLink>> GetIfExistsAsync(string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerCommunicationLink> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerCommunicationLink>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerCommunicationLink> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerCommunicationLink>.GetEnumerator() { throw null; }
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
    public partial class ServerConnectionPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerConnectionPolicy() { }
        public virtual Azure.ResourceManager.Sql.ServerConnectionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string connectionPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerConnectionPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerConnectionPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerConnectionPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerConnectionPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerConnectionPolicy>, System.Collections.IEnumerable
    {
        protected ServerConnectionPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerConnectionPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, Azure.ResourceManager.Sql.ServerConnectionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerConnectionPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, Azure.ResourceManager.Sql.ServerConnectionPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerConnectionPolicy> Get(Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerConnectionPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerConnectionPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerConnectionPolicy>> GetAsync(Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerConnectionPolicy> GetIfExists(Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerConnectionPolicy>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerConnectionPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerConnectionPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerConnectionPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerConnectionPolicy>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerConnectionPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerConnectionPolicyData() { }
        public Azure.ResourceManager.Sql.Models.ServerConnectionType? ConnectionType { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } }
    }
    public partial class ServerDatabaseAdvisor : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseAdvisor() { }
        public virtual Azure.ResourceManager.Sql.AdvisorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string advisorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisor> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisor>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecommendedAction> GetRecommendedAction(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecommendedAction>> GetRecommendedActionAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.RecommendedActionCollection GetRecommendedActions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisor> Update(Azure.ResourceManager.Sql.AdvisorData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisor>> UpdateAsync(Azure.ResourceManager.Sql.AdvisorData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDatabaseAdvisorCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseAdvisor>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseAdvisor>, System.Collections.IEnumerable
    {
        protected ServerDatabaseAdvisorCollection() { }
        public virtual Azure.Response<bool> Exists(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisor> Get(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseAdvisor> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseAdvisor> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisor>> GetAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisor> GetIfExists(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisor>> GetIfExistsAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDatabaseAdvisor> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseAdvisor>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDatabaseAdvisor> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseAdvisor>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerDatabaseSchema : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseSchema() { }
        public virtual Azure.ResourceManager.Sql.DatabaseSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string schemaName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchema> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchema>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable> GetServerDatabaseSchemaTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable>> GetServerDatabaseSchemaTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseSchemaTableCollection GetServerDatabaseSchemaTables() { throw null; }
    }
    public partial class ServerDatabaseSchemaCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchema>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchema>, System.Collections.IEnumerable
    {
        protected ServerDatabaseSchemaCollection() { }
        public virtual Azure.Response<bool> Exists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchema> Get(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseSchema> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseSchema> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchema>> GetAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchema> GetIfExists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchema>> GetIfExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDatabaseSchema> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchema>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDatabaseSchema> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchema>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerDatabaseSchemaTable : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseSchemaTable() { }
        public virtual Azure.ResourceManager.Sql.DatabaseTableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn> GetServerDatabaseSchemaTableColumn(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn>> GetServerDatabaseSchemaTableColumnAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnCollection GetServerDatabaseSchemaTableColumns() { throw null; }
    }
    public partial class ServerDatabaseSchemaTableCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable>, System.Collections.IEnumerable
    {
        protected ServerDatabaseSchemaTableCollection() { }
        public virtual Azure.Response<bool> Exists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable> Get(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable>> GetAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable> GetIfExists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable>> GetIfExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTable>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerDatabaseSchemaTableColumn : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseSchemaTableColumn() { }
        public virtual Azure.ResourceManager.Sql.DatabaseColumnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName, string columnName) { throw null; }
        public virtual Azure.Response DisableRecommendationSensitivityLabel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableRecommendationSensitivityLabelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableRecommendationSensitivityLabel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableRecommendationSensitivityLabelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabel> GetServerDatabaseSchemaTableColumnSensitivityLabel(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabel>> GetServerDatabaseSchemaTableColumnSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabelCollection GetServerDatabaseSchemaTableColumnSensitivityLabels() { throw null; }
    }
    public partial class ServerDatabaseSchemaTableColumnCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn>, System.Collections.IEnumerable
    {
        protected ServerDatabaseSchemaTableColumnCollection() { }
        public virtual Azure.Response<bool> Exists(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn> Get(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn>> GetAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn> GetIfExists(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn>> GetIfExistsAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerDatabaseSchemaTableColumnSensitivityLabel : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseSchemaTableColumnSensitivityLabel() { }
        public virtual Azure.ResourceManager.Sql.SensitivityLabelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName, string columnName, string sensitivityLabelSource) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabel> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabel>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDatabaseSchemaTableColumnSensitivityLabelCollection : Azure.ResourceManager.Core.ArmCollection
    {
        protected ServerDatabaseSchemaTableColumnSensitivityLabelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabel> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SensitivityLabelData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabel>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SensitivityLabelData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabel> Get(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabel>> GetAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabel> GetIfExists(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabel>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDatabaseVulnerabilityAssessment : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseVulnerabilityAssessment() { }
        public virtual Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string vulnerabilityAssessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaseline> GetServerDatabaseVulnerabilityAssessmentRuleBaseline(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaseline>> GetServerDatabaseVulnerabilityAssessmentRuleBaselineAsync(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaselineCollection GetServerDatabaseVulnerabilityAssessmentRuleBaselines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan> GetServerDatabaseVulnerabilityAssessmentScan(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan>> GetServerDatabaseVulnerabilityAssessmentScanAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScanCollection GetServerDatabaseVulnerabilityAssessmentScans() { throw null; }
    }
    public partial class ServerDatabaseVulnerabilityAssessmentCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment>, System.Collections.IEnumerable
    {
        protected ServerDatabaseVulnerabilityAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment> Get(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment>> GetAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment> GetIfExists(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerDatabaseVulnerabilityAssessmentRuleBaseline : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseVulnerabilityAssessmentRuleBaseline() { }
        public virtual Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentRuleBaselineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string vulnerabilityAssessmentName, string ruleId, string baselineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaseline> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaseline>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDatabaseVulnerabilityAssessmentRuleBaselineCollection : Azure.ResourceManager.Core.ArmCollection
    {
        protected ServerDatabaseVulnerabilityAssessmentRuleBaselineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaseline> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentRuleBaselineData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaseline>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Sql.DatabaseVulnerabilityAssessmentRuleBaselineData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaseline> Get(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaseline>> GetAsync(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaseline> GetIfExists(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentRuleBaseline>> GetIfExistsAsync(string ruleId, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDatabaseVulnerabilityAssessmentScan : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDatabaseVulnerabilityAssessmentScan() { }
        public virtual Azure.ResourceManager.Sql.VulnerabilityAssessmentScanRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string vulnerabilityAssessmentName, string scanId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentScansExport> Export(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.DatabaseVulnerabilityAssessmentScansExport>> ExportAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation InitiateScan(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InitiateScanAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDatabaseVulnerabilityAssessmentScanCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan>, System.Collections.IEnumerable
    {
        protected ServerDatabaseVulnerabilityAssessmentScanCollection() { }
        public virtual Azure.Response<bool> Exists(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan> Get(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan>> GetAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan> GetIfExists(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan>> GetIfExistsAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentScan>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerDevOpsAuditingSettings : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDevOpsAuditingSettings() { }
        public virtual Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string devOpsAuditingSettingsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDevOpsAuditingSettingsCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings>, System.Collections.IEnumerable
    {
        protected ServerDevOpsAuditingSettingsCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings> CreateOrUpdate(Azure.WaitUntil waitUntil, string devOpsAuditingSettingsName, Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string devOpsAuditingSettingsName, Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string devOpsAuditingSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string devOpsAuditingSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings> Get(string devOpsAuditingSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings>> GetAsync(string devOpsAuditingSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings> GetIfExists(string devOpsAuditingSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings>> GetIfExistsAsync(string devOpsAuditingSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings>.GetEnumerator() { throw null; }
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
    public partial class ServerDnsAlias : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerDnsAlias() { }
        public virtual Azure.ResourceManager.Sql.ServerDnsAliasData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDnsAlias> Acquire(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ServerDnsAliasAcquisition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDnsAlias>> AcquireAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ServerDnsAliasAcquisition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string dnsAliasName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDnsAlias> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDnsAlias>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerDnsAliasCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDnsAlias>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDnsAlias>, System.Collections.IEnumerable
    {
        protected ServerDnsAliasCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDnsAlias> CreateOrUpdate(Azure.WaitUntil waitUntil, string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerDnsAlias>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDnsAlias> Get(string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDnsAlias> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDnsAlias> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDnsAlias>> GetAsync(string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDnsAlias> GetIfExists(string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDnsAlias>> GetIfExistsAsync(string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerDnsAlias> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerDnsAlias>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerDnsAlias> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerDnsAlias>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerDnsAliasData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerDnsAliasData() { }
        public string AzureDnsRecord { get { throw null; } }
    }
    public partial class ServerJobAgentJobExecution : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerJobAgentJobExecution() { }
        public virtual Azure.ResourceManager.Sql.JobExecutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, string jobExecutionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecution> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecution>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep> GetServerJobAgentJobExecutionStep(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep>> GetServerJobAgentJobExecutionStepAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepCollection GetServerJobAgentJobExecutionSteps() { throw null; }
    }
    public partial class ServerJobAgentJobExecutionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecution>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecution>, System.Collections.IEnumerable
    {
        protected ServerJobAgentJobExecutionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerJobAgentJobExecution> CreateOrUpdate(Azure.WaitUntil waitUntil, System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerJobAgentJobExecution>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecution> Get(System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecution> GetAll(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecution> GetAllAsync(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecution>> GetAsync(System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecution> GetIfExists(System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecution>> GetIfExistsAsync(System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget> GetJobTargetExecutions(System.Guid jobExecutionId, System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget> GetJobTargetExecutionsAsync(System.Guid jobExecutionId, System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobExecution> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecution>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobExecution> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecution>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerJobAgentJobExecutionStep : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerJobAgentJobExecutionStep() { }
        public virtual Azure.ResourceManager.Sql.JobExecutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, string jobExecutionId, string stepName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget> GetServerJobAgentJobExecutionStepTarget(System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget>> GetServerJobAgentJobExecutionStepTargetAsync(System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTargetCollection GetServerJobAgentJobExecutionStepTargets() { throw null; }
    }
    public partial class ServerJobAgentJobExecutionStepCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep>, System.Collections.IEnumerable
    {
        protected ServerJobAgentJobExecutionStepCollection() { }
        public virtual Azure.Response<bool> Exists(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep> Get(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep> GetAll(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep> GetAllAsync(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep>> GetAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep> GetIfExists(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep>> GetIfExistsAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStep>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerJobAgentJobExecutionStepTarget : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerJobAgentJobExecutionStepTarget() { }
        public virtual Azure.ResourceManager.Sql.JobExecutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, string jobExecutionId, string stepName, string targetId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerJobAgentJobExecutionStepTargetCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget>, System.Collections.IEnumerable
    {
        protected ServerJobAgentJobExecutionStepTargetCollection() { }
        public virtual Azure.Response<bool> Exists(System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget> Get(System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget> GetAll(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget> GetAllAsync(System.DateTimeOffset? createTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? createTimeMax = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMin = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeMax = default(System.DateTimeOffset?), bool? isActive = default(bool?), int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget>> GetAsync(System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget> GetIfExists(System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget>> GetIfExistsAsync(System.Guid targetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobExecutionStepTarget>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerJobAgentJobStep : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerJobAgentJobStep() { }
        public virtual Azure.ResourceManager.Sql.JobStepData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, string stepName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobStep> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobStep>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerJobAgentJobStepCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobStep>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobStep>, System.Collections.IEnumerable
    {
        protected ServerJobAgentJobStepCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerJobAgentJobStep> CreateOrUpdate(Azure.WaitUntil waitUntil, string stepName, Azure.ResourceManager.Sql.JobStepData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerJobAgentJobStep>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string stepName, Azure.ResourceManager.Sql.JobStepData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobStep> Get(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerJobAgentJobStep> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerJobAgentJobStep> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobStep>> GetAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobStep> GetIfExists(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobStep>> GetIfExistsAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobStep> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobStep>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobStep> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobStep>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerJobAgentJobVersionStep : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerJobAgentJobVersionStep() { }
        public virtual Azure.ResourceManager.Sql.JobStepData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, string jobVersion, string stepName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerJobAgentJobVersionStepCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep>, System.Collections.IEnumerable
    {
        protected ServerJobAgentJobVersionStepCollection() { }
        public virtual Azure.Response<bool> Exists(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep> Get(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep>> GetAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep> GetIfExists(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep>> GetIfExistsAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerJobAgentJobVersionStep>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerKey : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerKey() { }
        public virtual Azure.ResourceManager.Sql.ServerKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string keyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerKey> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerKey>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerKeyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerKey>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerKey>, System.Collections.IEnumerable
    {
        protected ServerKeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerKey> CreateOrUpdate(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.Sql.ServerKeyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerKey>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.Sql.ServerKeyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerKey> Get(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerKey> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerKey> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerKey>> GetAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerKey> GetIfExists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerKey>> GetIfExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerKey> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerKey>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerKey> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerKey>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerKeyData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerKeyData() { }
        public bool? AutoRotationEnabled { get { throw null; } }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ServerKeyType? ServerKeyType { get { throw null; } set { } }
        public string Subregion { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ServerSecurityAlertPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerSecurityAlertPolicy() { }
        public virtual Azure.ResourceManager.Sql.ServerSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerSecurityAlertPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy>, System.Collections.IEnumerable
    {
        protected ServerSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.ServerSecurityAlertPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Sql.ServerSecurityAlertPolicyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy> Get(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy>> GetAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy> GetIfExists(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerSecurityAlertPolicyData() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public bool? EmailAccountAdmins { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecurityAlertsPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ServerTrustGroup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerTrustGroup() { }
        public virtual Azure.ResourceManager.Sql.ServerTrustGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string locationName, string serverTrustGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerTrustGroup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerTrustGroup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerTrustGroupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerTrustGroup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerTrustGroup>, System.Collections.IEnumerable
    {
        protected ServerTrustGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerTrustGroup> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverTrustGroupName, Azure.ResourceManager.Sql.ServerTrustGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerTrustGroup>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverTrustGroupName, Azure.ResourceManager.Sql.ServerTrustGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverTrustGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverTrustGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerTrustGroup> Get(string serverTrustGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerTrustGroup> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerTrustGroup> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerTrustGroup>> GetAsync(string serverTrustGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerTrustGroup> GetIfExists(string serverTrustGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerTrustGroup>> GetIfExistsAsync(string serverTrustGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerTrustGroup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerTrustGroup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerTrustGroup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerTrustGroup>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerTrustGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerTrustGroupData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.ServerInfo> GroupMembers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.ServerTrustGroupPropertiesTrustScopesItem> TrustScopes { get { throw null; } }
    }
    public partial class ServerVulnerabilityAssessment : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerVulnerabilityAssessment() { }
        public virtual Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string vulnerabilityAssessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerVulnerabilityAssessmentCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment>, System.Collections.IEnumerable
    {
        protected ServerVulnerabilityAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment> Get(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment>> GetAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment> GetIfExists(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment>> GetIfExistsAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment>.GetEnumerator() { throw null; }
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
    public partial class ServiceObjective : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceObjective() { }
        public virtual Azure.ResourceManager.Sql.ServiceObjectiveData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string serviceObjectiveName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServiceObjective> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServiceObjective>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceObjectiveCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServiceObjective>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServiceObjective>, System.Collections.IEnumerable
    {
        protected ServiceObjectiveCollection() { }
        public virtual Azure.Response<bool> Exists(string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServiceObjective> Get(string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServiceObjective> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServiceObjective> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServiceObjective>> GetAsync(string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServiceObjective> GetIfExists(string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServiceObjective>> GetIfExistsAsync(string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.ServiceObjective> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.ServiceObjective>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.ServiceObjective> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.ServiceObjective>.GetEnumerator() { throw null; }
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
    public partial class SqlAgentConfiguration : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlAgentConfiguration() { }
        public virtual Azure.ResourceManager.Sql.SqlAgentConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlAgentConfiguration> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SqlAgentConfigurationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlAgentConfiguration>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SqlAgentConfigurationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlAgentConfiguration> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlAgentConfiguration>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlAgentConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlAgentConfigurationData() { }
        public Azure.ResourceManager.Sql.Models.SqlAgentConfigurationPropertiesState? State { get { throw null; } set { } }
    }
    public partial class SqlDatabase : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlDatabase() { }
        public virtual Azure.ResourceManager.Sql.SqlDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabase> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabase>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelDatabaseOperation(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelDatabaseOperationAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportExtensionsOperationResult> CreateOrUpdateDatabaseExtension(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Sql.Models.DatabaseExtensions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportExtensionsOperationResult>> CreateOrUpdateDatabaseExtensionAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Sql.Models.DatabaseExtensions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.RestorePoint> CreateRestorePoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CreateDatabaseRestorePointDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.RestorePoint>> CreateRestorePointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CreateDatabaseRestorePointDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportOperationResult> Export(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ExportDatabaseDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportOperationResult>> ExportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ExportDatabaseDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Failover(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ReplicaType? replicaType = default(Azure.ResourceManager.Sql.Models.ReplicaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ReplicaType? replicaType = default(Azure.ResourceManager.Sql.Models.ReplicaType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabase> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabase>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.BackupShortTermRetentionPolicyCollection GetBackupShortTermRetentionPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy> GetBackupShortTermRetentionPolicy(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.BackupShortTermRetentionPolicy>> GetBackupShortTermRetentionPolicyAsync(Azure.ResourceManager.Sql.Models.ShortTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabel> GetCurrentSensitivityLabels(string skipToken = null, bool? count = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabel> GetCurrentSensitivityLabelsAsync(string skipToken = null, bool? count = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabaseAutomaticTuning GetDatabaseAutomaticTuning() { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicyCollection GetDatabaseBlobAuditingPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy> GetDatabaseBlobAuditingPolicy(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseBlobAuditingPolicy>> GetDatabaseBlobAuditingPolicyAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn> GetDatabaseColumns(System.Collections.Generic.IEnumerable<string> schema = null, System.Collections.Generic.IEnumerable<string> table = null, System.Collections.Generic.IEnumerable<string> column = null, System.Collections.Generic.IEnumerable<string> orderBy = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumn> GetDatabaseColumnsAsync(System.Collections.Generic.IEnumerable<string> schema = null, System.Collections.Generic.IEnumerable<string> table = null, System.Collections.Generic.IEnumerable<string> column = null, System.Collections.Generic.IEnumerable<string> orderBy = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ImportExportExtensionsOperationResult> GetDatabaseExtensions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ImportExportExtensionsOperationResult> GetDatabaseExtensionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.DatabaseOperation> GetDatabaseOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.DatabaseOperation> GetDatabaseOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicyCollection GetDatabaseSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy> GetDatabaseSecurityAlertPolicy(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DatabaseSecurityAlertPolicy>> GetDatabaseSecurityAlertPolicyAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.DatabaseUsage> GetDatabaseUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.DatabaseUsage> GetDatabaseUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.DataMaskingPolicy GetDataMaskingPolicy() { throw null; }
        public virtual Azure.ResourceManager.Sql.DataWarehouseUserActivitiesCollection GetDataWarehouseUserActivities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.DataWarehouseUserActivities> GetDataWarehouseUserActivities(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DataWarehouseUserActivities>> GetDataWarehouseUserActivitiesAsync(Azure.ResourceManager.Sql.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicyCollection GetExtendedDatabaseBlobAuditingPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy> GetExtendedDatabaseBlobAuditingPolicy(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ExtendedDatabaseBlobAuditingPolicy>> GetExtendedDatabaseBlobAuditingPolicyAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.GeoBackupPolicyCollection GetGeoBackupPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.GeoBackupPolicy> GetGeoBackupPolicy(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.GeoBackupPolicy>> GetGeoBackupPolicyAsync(Azure.ResourceManager.Sql.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.LedgerDigestUploadsCollection GetLedgerDigestUploads() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LedgerDigestUploads> GetLedgerDigestUploads(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LedgerDigestUploads>> GetLedgerDigestUploadsAsync(Azure.ResourceManager.Sql.Models.LedgerDigestUploadsName ledgerDigestUploads, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption> GetLogicalDatabaseTransparentDataEncryption(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryption>> GetLogicalDatabaseTransparentDataEncryptionAsync(Azure.ResourceManager.Sql.Models.TransparentDataEncryptionName tdeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.LogicalDatabaseTransparentDataEncryptionCollection GetLogicalDatabaseTransparentDataEncryptions() { throw null; }
        public virtual Azure.ResourceManager.Sql.LongTermRetentionPolicyCollection GetLongTermRetentionPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.LongTermRetentionPolicy> GetLongTermRetentionPolicy(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.LongTermRetentionPolicy>> GetLongTermRetentionPolicyAsync(Azure.ResourceManager.Sql.Models.LongTermRetentionPolicyName policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.MaintenanceWindowOptions GetMaintenanceWindowOptions() { throw null; }
        public virtual Azure.ResourceManager.Sql.MaintenanceWindows GetMaintenanceWindows() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.MetricDefinition> GetMetricDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.MetricDefinition> GetMetricDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SqlMetric> GetMetrics(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SqlMetric> GetMetricsAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabel> GetRecommendedSensitivityLabels(string skipToken = null, bool? includeDisabledRecommendations = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ServerDatabaseSchemaTableColumnSensitivityLabel> GetRecommendedSensitivityLabelsAsync(string skipToken = null, bool? includeDisabledRecommendations = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ReplicationLink> GetReplicationLink(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ReplicationLink>> GetReplicationLinkAsync(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ReplicationLinkCollection GetReplicationLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorePoint> GetRestorePoint(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorePoint>> GetRestorePointAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.RestorePointCollection GetRestorePoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisor> GetServerDatabaseAdvisor(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseAdvisor>> GetServerDatabaseAdvisorAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseAdvisorCollection GetServerDatabaseAdvisors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchema> GetServerDatabaseSchema(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseSchema>> GetServerDatabaseSchemaAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseSchemaCollection GetServerDatabaseSchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment> GetServerDatabaseVulnerabilityAssessment(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessment>> GetServerDatabaseVulnerabilityAssessmentAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDatabaseVulnerabilityAssessmentCollection GetServerDatabaseVulnerabilityAssessments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncGroup> GetSyncGroup(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncGroup>> GetSyncGroupAsync(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncGroupCollection GetSyncGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.WorkloadGroup> GetWorkloadGroup(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.WorkloadGroup>> GetWorkloadGroupAsync(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.WorkloadGroupCollection GetWorkloadGroups() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportOperationResult> Import(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ImportExistingDatabaseDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportOperationResult>> ImportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ImportExistingDatabaseDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabase> Pause(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabase>> PauseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabase> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabase>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Rename(Azure.ResourceManager.Sql.Models.ResourceMoveDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenameAsync(Azure.ResourceManager.Sql.Models.ResourceMoveDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabase> Resume(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabase>> ResumeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabase> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabase>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabase> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.PatchableSqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabase>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.PatchableSqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateRecommendedSensitivityLabel(Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdateList parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateRecommendedSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdateList parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateSensitivityLabel(Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateList parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSensitivityLabelAsync(Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateList parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpgradeDataWarehouse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeDataWarehouseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlDatabaseCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlDatabase>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlDatabase>, System.Collections.IEnumerable
    {
        protected SqlDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabase> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Sql.SqlDatabaseData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlDatabase>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Sql.SqlDatabaseData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabase> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlDatabase> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlDatabase> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabase>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabase> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabase>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SqlDatabase> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlDatabase>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SqlDatabase> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlDatabase>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlDatabaseData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SqlDatabaseData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public int? AutoPauseDelay { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CatalogCollationType? CatalogCollation { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CurrentBackupStorageRedundancy? CurrentBackupStorageRedundancy { get { throw null; } }
        public string CurrentServiceObjectiveName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SqlSku CurrentSku { get { throw null; } }
        public System.Guid? DatabaseId { get { throw null; } }
        public string DefaultSecondaryLocation { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreDate { get { throw null; } }
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
        public System.DateTimeOffset? PausedDate { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.DatabaseReadScale? ReadScale { get { throw null; } set { } }
        public string RecoverableDatabaseId { get { throw null; } set { } }
        public string RecoveryServicesRecoveryPointId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.RequestedBackupStorageRedundancy? RequestedBackupStorageRedundancy { get { throw null; } set { } }
        public string RequestedServiceObjectiveName { get { throw null; } }
        public string RestorableDroppedDatabaseId { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
        public System.DateTimeOffset? ResumedDate { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SampleSchemaName? SampleName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecondaryType? SecondaryType { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? SourceDatabaseDeletionDate { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.DatabaseStatus? Status { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class SqlJob : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlJob() { }
        public virtual Azure.ResourceManager.Sql.SqlJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerJobAgentJobExecution> CreateJobExecution(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.ServerJobAgentJobExecution>> CreateJobExecutionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlJob> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlJob>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobVersion> GetJobVersion(int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobVersion>> GetJobVersionAsync(int jobVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.JobVersionCollection GetJobVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecution> GetServerJobAgentJobExecution(System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobExecution>> GetServerJobAgentJobExecutionAsync(System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerJobAgentJobExecutionCollection GetServerJobAgentJobExecutions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobStep> GetServerJobAgentJobStep(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerJobAgentJobStep>> GetServerJobAgentJobStepAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerJobAgentJobStepCollection GetServerJobAgentJobSteps() { throw null; }
    }
    public partial class SqlJobCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlJob>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlJob>, System.Collections.IEnumerable
    {
        protected SqlJobCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlJob> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.Sql.SqlJobData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlJob>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.Sql.SqlJobData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlJob> Get(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlJob> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlJob> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlJob>> GetAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlJob> GetIfExists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlJob>> GetIfExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SqlJob> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlJob>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SqlJob> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlJob>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlJobData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlJobData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.JobSchedule Schedule { get { throw null; } set { } }
        public int? Version { get { throw null; } }
    }
    public partial class SqlServer : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlServer() { }
        public virtual Azure.ResourceManager.Sql.SqlServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlServer> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServer>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateTdeCertificate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TdeCertificate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateTdeCertificateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.TdeCertificate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlServer> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServer>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ElasticPool> GetElasticPool(string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ElasticPool>> GetElasticPoolAsync(string elasticPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ElasticPoolCollection GetElasticPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.EncryptionProtector> GetEncryptionProtector(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.EncryptionProtector>> GetEncryptionProtectorAsync(Azure.ResourceManager.Sql.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.EncryptionProtectorCollection GetEncryptionProtectors() { throw null; }
        public virtual Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicyCollection GetExtendedServerBlobAuditingPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy> GetExtendedServerBlobAuditingPolicy(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ExtendedServerBlobAuditingPolicy>> GetExtendedServerBlobAuditingPolicyAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FailoverGroup> GetFailoverGroup(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FailoverGroup>> GetFailoverGroupAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.FailoverGroupCollection GetFailoverGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FirewallRule> GetFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FirewallRule>> GetFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.FirewallRuleCollection GetFirewallRules() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlDatabase> GetInaccessibleDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlDatabase> GetInaccessibleDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.JobAgent> GetJobAgent(string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.JobAgent>> GetJobAgentAsync(string jobAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.JobAgentCollection GetJobAgents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.OutboundFirewallRule> GetOutboundFirewallRule(string outboundRuleFqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.OutboundFirewallRule>> GetOutboundFirewallRuleAsync(string outboundRuleFqdn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.OutboundFirewallRuleCollection GetOutboundFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.PrivateEndpointConnection> GetPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.PrivateEndpointConnection>> GetPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.PrivateLinkResource> GetPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.PrivateLinkResource>> GetPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.PrivateLinkResourceCollection GetPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RecoverableDatabase> GetRecoverableDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RecoverableDatabase>> GetRecoverableDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.RecoverableDatabaseCollection GetRecoverableDatabases() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.ReplicationLink> GetReplicationLinks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.ReplicationLink> GetReplicationLinksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabase> GetRestorableDroppedDatabase(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.RestorableDroppedDatabase>> GetRestorableDroppedDatabaseAsync(string restorableDroppedDatabaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.RestorableDroppedDatabaseCollection GetRestorableDroppedDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAdvisor> GetServerAdvisor(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAdvisor>> GetServerAdvisorAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerAdvisorCollection GetServerAdvisors() { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerAutomaticTuning GetServerAutomaticTuning() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAzureADAdministrator> GetServerAzureADAdministrator(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAzureADAdministrator>> GetServerAzureADAdministratorAsync(Azure.ResourceManager.Sql.Models.AdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerAzureADAdministratorCollection GetServerAzureADAdministrators() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication> GetServerAzureADOnlyAuthentication(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerAzureADOnlyAuthentication>> GetServerAzureADOnlyAuthenticationAsync(Azure.ResourceManager.Sql.Models.AuthenticationName authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerAzureADOnlyAuthenticationCollection GetServerAzureADOnlyAuthentications() { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerBlobAuditingPolicyCollection GetServerBlobAuditingPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy> GetServerBlobAuditingPolicy(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerBlobAuditingPolicy>> GetServerBlobAuditingPolicyAsync(Azure.ResourceManager.Sql.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerCommunicationLink> GetServerCommunicationLink(string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerCommunicationLink>> GetServerCommunicationLinkAsync(string communicationLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerCommunicationLinkCollection GetServerCommunicationLinks() { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerConnectionPolicyCollection GetServerConnectionPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerConnectionPolicy> GetServerConnectionPolicy(Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerConnectionPolicy>> GetServerConnectionPolicyAsync(Azure.ResourceManager.Sql.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDevOpsAuditingSettingsCollection GetServerDevOpsAuditingSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings> GetServerDevOpsAuditingSettings(string devOpsAuditingSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDevOpsAuditingSettings>> GetServerDevOpsAuditingSettingsAsync(string devOpsAuditingSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerDnsAlias> GetServerDnsAlias(string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerDnsAlias>> GetServerDnsAliasAsync(string dnsAliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerDnsAliasCollection GetServerDnsAliases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerKey> GetServerKey(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerKey>> GetServerKeyAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerKeyCollection GetServerKeys() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServerOperation> GetServerOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServerOperation> GetServerOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerSecurityAlertPolicyCollection GetServerSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy> GetServerSecurityAlertPolicy(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerSecurityAlertPolicy>> GetServerSecurityAlertPolicyAsync(Azure.ResourceManager.Sql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.ServerUsage> GetServerUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.ServerUsage> GetServerUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment> GetServerVulnerabilityAssessment(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServerVulnerabilityAssessment>> GetServerVulnerabilityAssessmentAsync(Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServerVulnerabilityAssessmentCollection GetServerVulnerabilityAssessments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.ServiceObjective> GetServiceObjective(string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.ServiceObjective>> GetServiceObjectiveAsync(string serviceObjectiveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.ServiceObjectiveCollection GetServiceObjectives() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlDatabase> GetSqlDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlDatabase>> GetSqlDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SqlDatabaseCollection GetSqlDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncAgent> GetSyncAgent(string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncAgent>> GetSyncAgentAsync(string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncAgentCollection GetSyncAgents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualNetworkRule> GetVirtualNetworkRule(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualNetworkRule>> GetVirtualNetworkRuleAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.VirtualNetworkRuleCollection GetVirtualNetworkRules() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportOperationResult> ImportDatabase(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ImportNewDatabaseDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.ImportExportOperationResult>> ImportDatabaseAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.ImportNewDatabaseDefinition parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlServer> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServer>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.FirewallRule> ReplaceFirewallRule(Azure.ResourceManager.Sql.Models.FirewallRuleList parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.FirewallRule>> ReplaceFirewallRuleAsync(Azure.ResourceManager.Sql.Models.FirewallRuleList parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlServer> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServer>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServer> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.PatchableSqlServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServer>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.PatchableSqlServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlServerCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlServer>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlServer>, System.Collections.IEnumerable
    {
        protected SqlServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServer> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.Sql.SqlServerData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServer>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.Sql.SqlServerData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlServer> Get(string serverName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlServer> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServer> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServer>> GetAsync(string serverName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlServer> GetIfExists(string serverName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlServer>> GetIfExistsAsync(string serverName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SqlServer> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlServer>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SqlServer> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlServer>.GetEnumerator() { throw null; }
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
    public partial class SqlTimeZone : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlTimeZone() { }
        public virtual Azure.ResourceManager.Sql.SqlTimeZoneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string timeZoneId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlTimeZone> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlTimeZone>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlTimeZoneCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlTimeZone>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlTimeZone>, System.Collections.IEnumerable
    {
        protected SqlTimeZoneCollection() { }
        public virtual Azure.Response<bool> Exists(string timeZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string timeZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlTimeZone> Get(string timeZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SqlTimeZone> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlTimeZone> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlTimeZone>> GetAsync(string timeZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SqlTimeZone> GetIfExists(string timeZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlTimeZone>> GetIfExistsAsync(string timeZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SqlTimeZone> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SqlTimeZone>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SqlTimeZone> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SqlTimeZone>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlTimeZoneData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlTimeZoneData() { }
        public string DisplayName { get { throw null; } }
        public string TimeZoneId { get { throw null; } }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Sql.Models.CheckNameAvailabilityResponse> CheckNameAvailabilityServer(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Sql.Models.CheckNameAvailabilityRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.CheckNameAvailabilityResponse>> CheckNameAvailabilityServerAsync(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Sql.Models.CheckNameAvailabilityRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.Models.LocationCapabilities> GetByLocationCapability(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, Azure.ResourceManager.Sql.Models.CapabilityGroup? include = default(Azure.ResourceManager.Sql.Models.CapabilityGroup?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.LocationCapabilities>> GetByLocationCapabilityAsync(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, Azure.ResourceManager.Sql.Models.CapabilityGroup? include = default(Azure.ResourceManager.Sql.Models.CapabilityGroup?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.DeletedServer> GetDeletedServer(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string deletedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.DeletedServer>> GetDeletedServerAsync(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string deletedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.DeletedServerCollection GetDeletedServers(this Azure.ResourceManager.Resources.Subscription subscription, string locationName) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.DeletedServer> GetDeletedServers(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.DeletedServer> GetDeletedServersAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.InstancePool> GetInstancePools(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.InstancePool> GetInstancePoolsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> GetLongTermRetentionBackupsByLocation(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> GetLongTermRetentionBackupsByLocationAsync(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> GetLongTermRetentionBackupsByServer(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> GetLongTermRetentionBackupsByServerAsync(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string longTermRetentionServerName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> GetLongTermRetentionManagedInstanceBackupsByInstance(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string managedInstanceName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> GetLongTermRetentionManagedInstanceBackupsByInstanceAsync(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string managedInstanceName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> GetLongTermRetentionManagedInstanceBackupsByLocation(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> GetLongTermRetentionManagedInstanceBackupsByLocationAsync(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.ManagedInstance> GetManagedInstances(this Azure.ResourceManager.Resources.Subscription subscription, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.ManagedInstance> GetManagedInstancesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.Models.OperationsHealth> GetOperationsHealthsByLocation(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.OperationsHealth> GetOperationsHealthsByLocationAsync(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.SqlServer> GetSqlServers(this Azure.ResourceManager.Resources.Subscription subscription, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.SqlServer> GetSqlServersAsync(this Azure.ResourceManager.Resources.Subscription subscription, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.SqlTimeZone> GetSqlTimeZone(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string timeZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SqlTimeZone>> GetSqlTimeZoneAsync(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string timeZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.SqlTimeZoneCollection GetSqlTimeZones(this Azure.ResourceManager.Resources.Subscription subscription, string locationName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> GetSubscriptionLongTermRetentionBackup(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup>> GetSubscriptionLongTermRetentionBackupAsync(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackupCollection GetSubscriptionLongTermRetentionBackups(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> GetSubscriptionLongTermRetentionManagedInstanceBackup(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup>> GetSubscriptionLongTermRetentionManagedInstanceBackupAsync(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string managedInstanceName, string databaseName, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackupCollection GetSubscriptionLongTermRetentionManagedInstanceBackups(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string managedInstanceName, string databaseName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsage> GetSubscriptionUsage(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsage>> GetSubscriptionUsageAsync(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sql.SubscriptionUsageCollection GetSubscriptionUsages(this Azure.ResourceManager.Resources.Subscription subscription, string locationName) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.Models.SubResource> GetSyncDatabaseIdsSyncGroups(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.SubResource> GetSyncDatabaseIdsSyncGroupsAsync(this Azure.ResourceManager.Resources.Subscription subscription, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sql.VirtualCluster> GetVirtualClusters(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sql.VirtualCluster> GetVirtualClustersAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionLongTermRetentionBackup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionLongTermRetentionBackup() { }
        public virtual Azure.ResourceManager.Sql.LongTermRetentionBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult> Copy(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CopyLongTermRetentionBackupOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult>> CopyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.CopyLongTermRetentionBackupOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string longTermRetentionServerName, string longTermRetentionDatabaseName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.UpdateLongTermRetentionBackupOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.Models.LongTermRetentionBackupOperationResult>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.UpdateLongTermRetentionBackupOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionLongTermRetentionBackupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup>, System.Collections.IEnumerable
    {
        protected SubscriptionLongTermRetentionBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> GetAll(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> GetAllAsync(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> GetIfExists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup>> GetIfExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionBackup>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionLongTermRetentionManagedInstanceBackup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionLongTermRetentionManagedInstanceBackup() { }
        public virtual Azure.ResourceManager.Sql.ManagedInstanceLongTermRetentionBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string managedInstanceName, string databaseName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionLongTermRetentionManagedInstanceBackupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup>, System.Collections.IEnumerable
    {
        protected SubscriptionLongTermRetentionManagedInstanceBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> GetAll(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> GetAllAsync(bool? onlyLatestPerDatabase = default(bool?), Azure.ResourceManager.Sql.Models.DatabaseState? databaseState = default(Azure.ResourceManager.Sql.Models.DatabaseState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> GetIfExists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup>> GetIfExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SubscriptionLongTermRetentionManagedInstanceBackup>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionUsage : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionUsage() { }
        public virtual Azure.ResourceManager.Sql.SubscriptionUsageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string usageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsage> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsage>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionUsageCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SubscriptionUsage>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SubscriptionUsage>, System.Collections.IEnumerable
    {
        protected SubscriptionUsageCollection() { }
        public virtual Azure.Response<bool> Exists(string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsage> Get(string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SubscriptionUsage> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SubscriptionUsage> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsage>> GetAsync(string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsage> GetIfExists(string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SubscriptionUsage>> GetIfExistsAsync(string usageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SubscriptionUsage> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SubscriptionUsage>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SubscriptionUsage> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SubscriptionUsage>.GetEnumerator() { throw null; }
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
    public partial class SyncAgent : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SyncAgent() { }
        public virtual Azure.ResourceManager.Sql.SyncAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string syncAgentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.SyncAgentKeyProperties> GenerateKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.SyncAgentKeyProperties>> GenerateKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncAgent> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncAgent>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncAgentLinkedDatabase> GetLinkedDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncAgentLinkedDatabase> GetLinkedDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncAgentCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SyncAgent>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SyncAgent>, System.Collections.IEnumerable
    {
        protected SyncAgentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncAgent> CreateOrUpdate(Azure.WaitUntil waitUntil, string syncAgentName, Azure.ResourceManager.Sql.SyncAgentData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncAgent>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string syncAgentName, Azure.ResourceManager.Sql.SyncAgentData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncAgent> Get(string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SyncAgent> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SyncAgent> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncAgent>> GetAsync(string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncAgent> GetIfExists(string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncAgent>> GetIfExistsAsync(string syncAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SyncAgent> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SyncAgent>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SyncAgent> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SyncAgent>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SyncAgentData : Azure.ResourceManager.Models.ResourceData
    {
        public SyncAgentData() { }
        public System.DateTimeOffset? ExpiryTime { get { throw null; } }
        public bool? IsUpToDate { get { throw null; } }
        public System.DateTimeOffset? LastAliveTime { get { throw null; } }
        public string NamePropertiesName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SyncAgentState? State { get { throw null; } }
        public string SyncDatabaseId { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public partial class SyncGroup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SyncGroup() { }
        public virtual Azure.ResourceManager.Sql.SyncGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response CancelSync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelSyncAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string syncGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncGroup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncGroup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncFullSchemaProperties> GetHubSchemas(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncFullSchemaProperties> GetHubSchemasAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncGroupLogProperties> GetLogs(string startTime, string endTime, Azure.ResourceManager.Sql.Models.SyncGroupLogType type, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncGroupLogProperties> GetLogsAsync(string startTime, string endTime, Azure.ResourceManager.Sql.Models.SyncGroupLogType type, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncMember> GetSyncMember(string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncMember>> GetSyncMemberAsync(string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.SyncMemberCollection GetSyncMembers() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RefreshHubSchema(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshHubSchemaAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response TriggerSync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TriggerSyncAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncGroup> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SyncGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncGroup>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SyncGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncGroupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SyncGroup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SyncGroup>, System.Collections.IEnumerable
    {
        protected SyncGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncGroup> CreateOrUpdate(Azure.WaitUntil waitUntil, string syncGroupName, Azure.ResourceManager.Sql.SyncGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncGroup>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string syncGroupName, Azure.ResourceManager.Sql.SyncGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncGroup> Get(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SyncGroup> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SyncGroup> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncGroup>> GetAsync(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncGroup> GetIfExists(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncGroup>> GetIfExistsAsync(string syncGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SyncGroup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SyncGroup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SyncGroup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SyncGroup>.GetEnumerator() { throw null; }
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
        public System.DateTimeOffset? LastSyncTime { get { throw null; } }
        public string PrivateEndpointName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SyncGroupSchema Schema { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public string SyncDatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SyncGroupState? SyncState { get { throw null; } }
        public bool? UsePrivateLinkConnection { get { throw null; } set { } }
    }
    public partial class SyncMember : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SyncMember() { }
        public virtual Azure.ResourceManager.Sql.SyncMemberData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string syncGroupName, string syncMemberName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncMember> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncMember>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.Models.SyncFullSchemaProperties> GetMemberSchemas(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.Models.SyncFullSchemaProperties> GetMemberSchemasAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RefreshMemberSchema(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshMemberSchemaAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncMember> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SyncMemberData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncMember>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.SyncMemberData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SyncMemberCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SyncMember>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SyncMember>, System.Collections.IEnumerable
    {
        protected SyncMemberCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncMember> CreateOrUpdate(Azure.WaitUntil waitUntil, string syncMemberName, Azure.ResourceManager.Sql.SyncMemberData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SyncMember>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string syncMemberName, Azure.ResourceManager.Sql.SyncMemberData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncMember> Get(string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.SyncMember> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.SyncMember> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncMember>> GetAsync(string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.SyncMember> GetIfExists(string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.SyncMember>> GetIfExistsAsync(string syncMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.SyncMember> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.SyncMember>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.SyncMember> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.SyncMember>.GetEnumerator() { throw null; }
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
    public partial class VirtualCluster : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualCluster() { }
        public virtual Azure.ResourceManager.Sql.VirtualClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualCluster> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualCluster>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualClusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualCluster> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualCluster>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualCluster> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualCluster>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualCluster> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualCluster>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.VirtualCluster> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.PatchableVirtualClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.VirtualCluster>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sql.Models.PatchableVirtualClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.Models.UpdateManagedInstanceDnsServersOperation> UpdateDnsServers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.Models.UpdateManagedInstanceDnsServersOperation>> UpdateDnsServersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualClusterCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.VirtualCluster>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.VirtualCluster>, System.Collections.IEnumerable
    {
        protected VirtualClusterCollection() { }
        public virtual Azure.Response<bool> Exists(string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualCluster> Get(string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.VirtualCluster> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.VirtualCluster> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualCluster>> GetAsync(string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualCluster> GetIfExists(string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualCluster>> GetIfExistsAsync(string virtualClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.VirtualCluster> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.VirtualCluster>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.VirtualCluster> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.VirtualCluster>.GetEnumerator() { throw null; }
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
    public partial class VirtualNetworkRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkRule() { }
        public virtual Azure.ResourceManager.Sql.VirtualNetworkRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string virtualNetworkRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualNetworkRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualNetworkRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.VirtualNetworkRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.VirtualNetworkRule>, System.Collections.IEnumerable
    {
        protected VirtualNetworkRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.VirtualNetworkRule> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.Sql.VirtualNetworkRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.VirtualNetworkRule>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.Sql.VirtualNetworkRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualNetworkRule> Get(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.VirtualNetworkRule> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.VirtualNetworkRule> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualNetworkRule>> GetAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.VirtualNetworkRule> GetIfExists(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.VirtualNetworkRule>> GetIfExistsAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.VirtualNetworkRule> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.VirtualNetworkRule>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.VirtualNetworkRule> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.VirtualNetworkRule>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualNetworkRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public VirtualNetworkRuleData() { }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.VirtualNetworkRuleState? State { get { throw null; } }
        public string VirtualNetworkSubnetId { get { throw null; } set { } }
    }
    public partial class VulnerabilityAssessmentScanRecordData : Azure.ResourceManager.Models.ResourceData
    {
        public VulnerabilityAssessmentScanRecordData() { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanError> Errors { get { throw null; } }
        public int? NumberOfFailedSecurityChecks { get { throw null; } }
        public string ScanId { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanState? State { get { throw null; } }
        public string StorageContainerPath { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.VulnerabilityAssessmentScanTriggerType? TriggerType { get { throw null; } }
    }
    public partial class WorkloadClassifier : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadClassifier() { }
        public virtual Azure.ResourceManager.Sql.WorkloadClassifierData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string workloadGroupName, string workloadClassifierName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.WorkloadClassifier> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.WorkloadClassifier>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadClassifierCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.WorkloadClassifier>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.WorkloadClassifier>, System.Collections.IEnumerable
    {
        protected WorkloadClassifierCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.WorkloadClassifier> CreateOrUpdate(Azure.WaitUntil waitUntil, string workloadClassifierName, Azure.ResourceManager.Sql.WorkloadClassifierData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.WorkloadClassifier>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workloadClassifierName, Azure.ResourceManager.Sql.WorkloadClassifierData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.WorkloadClassifier> Get(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.WorkloadClassifier> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.WorkloadClassifier> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.WorkloadClassifier>> GetAsync(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.WorkloadClassifier> GetIfExists(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.WorkloadClassifier>> GetIfExistsAsync(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.WorkloadClassifier> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.WorkloadClassifier>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.WorkloadClassifier> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.WorkloadClassifier>.GetEnumerator() { throw null; }
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
    public partial class WorkloadGroup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadGroup() { }
        public virtual Azure.ResourceManager.Sql.WorkloadGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string workloadGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.WorkloadGroup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.WorkloadGroup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.WorkloadClassifier> GetWorkloadClassifier(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.WorkloadClassifier>> GetWorkloadClassifierAsync(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sql.WorkloadClassifierCollection GetWorkloadClassifiers() { throw null; }
    }
    public partial class WorkloadGroupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.WorkloadGroup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.WorkloadGroup>, System.Collections.IEnumerable
    {
        protected WorkloadGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.WorkloadGroup> CreateOrUpdate(Azure.WaitUntil waitUntil, string workloadGroupName, Azure.ResourceManager.Sql.WorkloadGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.WorkloadGroup>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workloadGroupName, Azure.ResourceManager.Sql.WorkloadGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.WorkloadGroup> Get(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sql.WorkloadGroup> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sql.WorkloadGroup> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.WorkloadGroup>> GetAsync(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sql.WorkloadGroup> GetIfExists(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sql.WorkloadGroup>> GetIfExistsAsync(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sql.WorkloadGroup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sql.WorkloadGroup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sql.WorkloadGroup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sql.WorkloadGroup>.GetEnumerator() { throw null; }
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
    public partial class ElasticPoolDatabaseActivity : Azure.ResourceManager.Models.ResourceData
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
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.UsageName Name { get { throw null; } }
        public int? RequestedLimit { get { throw null; } }
        public string Type { get { throw null; } }
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
    public partial class PatchableElasticPoolData
    {
        public PatchableElasticPoolData() { }
        public Azure.ResourceManager.Sql.Models.ElasticPoolLicenseType? LicenseType { get { throw null; } set { } }
        public string MaintenanceConfigurationId { get { throw null; } set { } }
        public long? MaxSizeBytes { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.ElasticPoolPerDatabaseSettings PerDatabaseSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class PatchableFailoverGroupData
    {
        public PatchableFailoverGroupData() { }
        public System.Collections.Generic.IList<string> Databases { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.ReadOnlyEndpointFailoverPolicy? ReadOnlyEndpointFailoverPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.FailoverGroupReadWriteEndpoint ReadWriteEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PatchableManagedDatabaseData
    {
        public PatchableManagedDatabaseData() { }
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
        public System.Uri StorageContainerUri { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PatchableManagedInstanceData
    {
        public PatchableManagedInstanceData() { }
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
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
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
    public partial class PatchableSqlDatabaseData
    {
        public PatchableSqlDatabaseData() { }
        public int? AutoPauseDelay { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CatalogCollationType? CatalogCollation { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.CurrentBackupStorageRedundancy? CurrentBackupStorageRedundancy { get { throw null; } }
        public string CurrentServiceObjectiveName { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SqlSku CurrentSku { get { throw null; } }
        public System.Guid? DatabaseId { get { throw null; } }
        public string DefaultSecondaryLocation { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreDate { get { throw null; } }
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
        public System.DateTimeOffset? PausedDate { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.DatabaseReadScale? ReadScale { get { throw null; } set { } }
        public string RecoverableDatabaseId { get { throw null; } set { } }
        public string RecoveryServicesRecoveryPointId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.RequestedBackupStorageRedundancy? RequestedBackupStorageRedundancy { get { throw null; } set { } }
        public string RequestedServiceObjectiveName { get { throw null; } }
        public string RestorableDroppedDatabaseId { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
        public System.DateTimeOffset? ResumedDate { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.SampleSchemaName? SampleName { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SecondaryType? SecondaryType { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.SqlSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? SourceDatabaseDeletionDate { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.Sql.Models.DatabaseStatus? Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class PatchableSqlServerData
    {
        public PatchableSqlServerData() { }
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
    public partial class PatchableVirtualClusterData
    {
        public PatchableVirtualClusterData() { }
        public System.Collections.Generic.IReadOnlyList<string> ChildResources { get { throw null; } }
        public string Family { get { throw null; } set { } }
        public string MaintenanceConfigurationId { get { throw null; } set { } }
        public string SubnetId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
        public System.DateTimeOffset? StartTime { get { throw null; } }
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
        public string Type { get { throw null; } }
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
        public System.DateTimeOffset? EventTime { get { throw null; } }
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
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.MetricValue> MetricValues { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.MetricName Name { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public string TimeGrain { get { throw null; } }
        public Azure.ResourceManager.Sql.Models.UnitType? Unit { get { throw null; } }
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
    public partial class UnlinkOptions
    {
        public UnlinkOptions() { }
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
