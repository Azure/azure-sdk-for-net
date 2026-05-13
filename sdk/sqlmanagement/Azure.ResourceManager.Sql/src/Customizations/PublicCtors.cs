// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: add public parameterless constructors to types that were not sealed in AutoRest v1.4.0.

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1402 // File may only contain a single type

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("EndpointCertificateData")]
    public partial class EndpointCertificateData { public EndpointCertificateData() { } }

    [CodeGenSuppress("LongTermRetentionBackupData")]
    public partial class LongTermRetentionBackupData { public LongTermRetentionBackupData() { } }

    [CodeGenSuppress("MaintenanceWindowOptionData")]
    public partial class MaintenanceWindowOptionData { public MaintenanceWindowOptionData() { } }

    [CodeGenSuppress("ManagedInstanceLongTermRetentionBackupData")]
    public partial class ManagedInstanceLongTermRetentionBackupData { public ManagedInstanceLongTermRetentionBackupData() { } }

    [CodeGenSuppress("ManagedInstanceOperationData")]
    public partial class ManagedInstanceOperationData { public ManagedInstanceOperationData() { } }

    [CodeGenSuppress("ManagedInstancePrivateLinkData")]
    public partial class ManagedInstancePrivateLinkData { public ManagedInstancePrivateLinkData() { } }

    [CodeGenSuppress("ManagedServerDnsAliasData")]
    public partial class ManagedServerDnsAliasData { public ManagedServerDnsAliasData() { } }

    [CodeGenSuppress("OutboundFirewallRuleData")]
    public partial class OutboundFirewallRuleData { public OutboundFirewallRuleData() { } }

    [CodeGenSuppress("RecoverableDatabaseData")]
    public partial class RecoverableDatabaseData { public RecoverableDatabaseData() { } }

    [CodeGenSuppress("RecoverableManagedDatabaseData")]
    public partial class RecoverableManagedDatabaseData { public RecoverableManagedDatabaseData() { } }

    [CodeGenSuppress("RestorableDroppedDatabaseData")]
    public partial class RestorableDroppedDatabaseData { public RestorableDroppedDatabaseData() { } }

    [CodeGenSuppress("RestorableDroppedManagedDatabaseData")]
    public partial class RestorableDroppedManagedDatabaseData { public RestorableDroppedManagedDatabaseData() { } }

    [CodeGenSuppress("SqlInstancePoolOperationData")]
    public partial class SqlInstancePoolOperationData { public SqlInstancePoolOperationData() { } }

    [CodeGenSuppress("SqlNetworkSecurityPerimeterConfigurationData")]
    public partial class SqlNetworkSecurityPerimeterConfigurationData { public SqlNetworkSecurityPerimeterConfigurationData() { } }

    [CodeGenSuppress("SqlPrivateLinkResourceData")]
    public partial class SqlPrivateLinkResourceData { public SqlPrivateLinkResourceData() { } }

    [CodeGenSuppress("SqlServerDatabaseRestorePointData")]
    public partial class SqlServerDatabaseRestorePointData { public SqlServerDatabaseRestorePointData() { } }

    [CodeGenSuppress("SqlServerDnsAliasData")]
    public partial class SqlServerDnsAliasData { public SqlServerDnsAliasData() { } }

    [CodeGenSuppress("SqlServerJobExecutionData")]
    public partial class SqlServerJobExecutionData { public SqlServerJobExecutionData() { } }

    [CodeGenSuppress("SqlServerJobVersionData")]
    public partial class SqlServerJobVersionData { public SqlServerJobVersionData() { } }

    [CodeGenSuppress("SqlTimeZoneData")]
    public partial class SqlTimeZoneData { public SqlTimeZoneData() { } }

    [CodeGenSuppress("SqlVulnerabilityAssessmentBaselineData")]
    public partial class SqlVulnerabilityAssessmentBaselineData { public SqlVulnerabilityAssessmentBaselineData() { } }

    [CodeGenSuppress("SqlVulnerabilityAssessmentBaselineRuleData")]
    public partial class SqlVulnerabilityAssessmentBaselineRuleData { public SqlVulnerabilityAssessmentBaselineRuleData() { } }

    [CodeGenSuppress("SqlVulnerabilityAssessmentScanData")]
    public partial class SqlVulnerabilityAssessmentScanData { public SqlVulnerabilityAssessmentScanData() { } }

    [CodeGenSuppress("SqlVulnerabilityAssessmentScanResultData")]
    public partial class SqlVulnerabilityAssessmentScanResultData { public SqlVulnerabilityAssessmentScanResultData() { } }

    [CodeGenSuppress("SubscriptionUsageData")]
    public partial class SubscriptionUsageData { public SubscriptionUsageData() { } }

    [CodeGenSuppress("VulnerabilityAssessmentScanRecordData")]
    public partial class VulnerabilityAssessmentScanRecordData { public VulnerabilityAssessmentScanRecordData() { } }

    [CodeGenSuppress("DatabaseColumnData")]
    public partial class DatabaseColumnData { public DatabaseColumnData() { } }

    [CodeGenSuppress("DatabaseSchemaData")]
    public partial class DatabaseSchemaData { public DatabaseSchemaData() { } }

    [CodeGenSuppress("DatabaseTableData")]
    public partial class DatabaseTableData { public DatabaseTableData() { } }

    [CodeGenSuppress("DataWarehouseUserActivityData")]
    public partial class DataWarehouseUserActivityData { public DataWarehouseUserActivityData() { } }

    [CodeGenSuppress("DeletedServerData")]
    public partial class DeletedServerData { public DeletedServerData() { } }

    [CodeGenSuppress("ManagedDatabaseRestoreDetailData")]
    public partial class ManagedDatabaseRestoreDetailData { public ManagedDatabaseRestoreDetailData() { } }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("DatabaseOperationData")]
    public partial class DatabaseOperationData { public DatabaseOperationData() { } }

    [CodeGenSuppress("DatabaseUsage")]
    public partial class DatabaseUsage { public DatabaseUsage() { } }

    [CodeGenSuppress("DatabaseVulnerabilityAssessmentScansExport")]
    public partial class DatabaseVulnerabilityAssessmentScansExport { public DatabaseVulnerabilityAssessmentScansExport() { } }

    [CodeGenSuppress("ElasticPoolOperationData")]
    public partial class ElasticPoolOperationData { public ElasticPoolOperationData() { } }

    [CodeGenSuppress("ImportExportOperationResult")]
    public partial class ImportExportOperationResult { public ImportExportOperationResult() { } }

    [CodeGenSuppress("LongTermRetentionBackupOperationResult")]
    public partial class LongTermRetentionBackupOperationResult { public LongTermRetentionBackupOperationResult() { } }

    [CodeGenSuppress("QueryMetricInterval")]
    public partial class QueryMetricInterval { public QueryMetricInterval() { } }

    [CodeGenSuppress("QueryMetricProperties")]
    public partial class QueryMetricProperties { public QueryMetricProperties() { } }

    [CodeGenSuppress("QueryStatistics")]
    public partial class QueryStatistics { public QueryStatistics() { } }

    [CodeGenSuppress("RefreshExternalGovernanceStatusOperationResult")]
    public partial class RefreshExternalGovernanceStatusOperationResult { public RefreshExternalGovernanceStatusOperationResult() { } }

    [CodeGenSuppress("SecurityEvent")]
    public partial class SecurityEvent { public SecurityEvent() { } }

    [CodeGenSuppress("ServerOperationData")]
    public partial class ServerOperationData { public ServerOperationData() { } }

    [CodeGenSuppress("SqlManagedInstanceRefreshExternalGovernanceStatusOperationResult")]
    public partial class SqlManagedInstanceRefreshExternalGovernanceStatusOperationResult { public SqlManagedInstanceRefreshExternalGovernanceStatusOperationResult() { } }

    [CodeGenSuppress("SqlNetworkSecurityPerimeterConfigAccessRule")]
    public partial class SqlNetworkSecurityPerimeterConfigAccessRule { public SqlNetworkSecurityPerimeterConfigAccessRule() { } }

    [CodeGenSuppress("SqlNetworkSecurityPerimeterConfigAccessRuleProperties")]
    public partial class SqlNetworkSecurityPerimeterConfigAccessRuleProperties { public SqlNetworkSecurityPerimeterConfigAccessRuleProperties() { } }

    [CodeGenSuppress("SqlNetworkSecurityPerimeterConfigAssociation")]
    public partial class SqlNetworkSecurityPerimeterConfigAssociation { public SqlNetworkSecurityPerimeterConfigAssociation() { } }

    [CodeGenSuppress("SqlNetworkSecurityPerimeterConfigPerimeter")]
    public partial class SqlNetworkSecurityPerimeterConfigPerimeter { public SqlNetworkSecurityPerimeterConfigPerimeter() { } }

    [CodeGenSuppress("SqlNetworkSecurityPerimeterConfigProfile")]
    public partial class SqlNetworkSecurityPerimeterConfigProfile { public SqlNetworkSecurityPerimeterConfigProfile() { } }

    [CodeGenSuppress("SqlNetworkSecurityPerimeterConfigRule")]
    public partial class SqlNetworkSecurityPerimeterConfigRule { public SqlNetworkSecurityPerimeterConfigRule() { } }

    [CodeGenSuppress("SqlNetworkSecurityPerimeterProvisioningIssue")]
    public partial class SqlNetworkSecurityPerimeterProvisioningIssue { public SqlNetworkSecurityPerimeterProvisioningIssue() { } }

    [CodeGenSuppress("SqlNetworkSecurityPerimeterProvisioningIssueProperties")]
    public partial class SqlNetworkSecurityPerimeterProvisioningIssueProperties { public SqlNetworkSecurityPerimeterProvisioningIssueProperties() { } }

    [CodeGenSuppress("SqlServerUsage")]
    public partial class SqlServerUsage { public SqlServerUsage() { } }

    [CodeGenSuppress("SqlSynapseLinkWorkspace")]
    public partial class SqlSynapseLinkWorkspace { public SqlSynapseLinkWorkspace() { } }

    [CodeGenSuppress("SqlSynapseLinkWorkspaceInfo")]
    public partial class SqlSynapseLinkWorkspaceInfo { public SqlSynapseLinkWorkspaceInfo() { } }

    [CodeGenSuppress("SyncAgentLinkedDatabase")]
    public partial class SyncAgentLinkedDatabase { public SyncAgentLinkedDatabase() { } }

    [CodeGenSuppress("ManagedInstanceUpdateDnsServersOperationData")]
    public partial class ManagedInstanceUpdateDnsServersOperationData { public ManagedInstanceUpdateDnsServersOperationData() { } }
}

#pragma warning restore CS1591
