// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.AppService;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql;
using Azure.ResourceManager.Sql.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class SqlSpecification() :
    Specification("Sql", typeof(SqlExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<BackupShortTermRetentionPolicyResource>("PolicyName");
        RemoveProperty<DatabaseAdvancedThreatProtectionResource>("AdvancedThreatProtectionName");
        RemoveProperty<EncryptionProtectorResource>("EncryptionProtectorName");
        RemoveProperty<ExtendedDatabaseBlobAuditingPolicyResource>("BlobAuditingPolicyName");
        RemoveProperty<ExtendedServerBlobAuditingPolicyResource>("BlobAuditingPolicyName");
        RemoveProperty<FailoverGroupResource>("ReadOnlyEndpointFailoverPolicy");
        RemoveProperty<FailoverGroupResource>("Databases");
        RemoveProperty<GeoBackupPolicyResource>("GeoBackupPolicyName");
        RemoveProperty<LedgerDigestUploadResource>("LedgerDigestUploads");
        RemoveProperty<LogicalDatabaseTransparentDataEncryptionResource>("TdeName");
        RemoveProperty<LongTermRetentionPolicyResource>("PolicyName");
        RemoveProperty<ManagedBackupShortTermRetentionPolicyResource>("PolicyName");
        RemoveProperty<ManagedDatabaseAdvancedThreatProtectionResource>("AdvancedThreatProtectionName");
        RemoveProperty<ManagedDatabaseSecurityAlertPolicyResource>("SecurityAlertPolicyName");
        RemoveProperty<ManagedDatabaseVulnerabilityAssessmentResource>("VulnerabilityAssessmentName");
        RemoveProperty<ManagedDatabaseVulnerabilityAssessmentRuleBaselineResource>("BaselineName");
        RemoveProperty<ManagedDatabaseVulnerabilityAssessmentRuleBaselineResource>("RuleId");
        RemoveProperty<ManagedInstanceAdministratorResource>("AdministratorName");
        RemoveProperty<ManagedInstanceAdvancedThreatProtectionResource>("AdvancedThreatProtectionName");
        RemoveProperty<ManagedInstanceAzureADOnlyAuthenticationResource>("AuthenticationName");
        RemoveProperty<ManagedInstanceDtcResource>("DtcName");
        RemoveProperty<ManagedInstanceEncryptionProtectorResource>("EncryptionProtectorName");
        RemoveProperty<ManagedInstanceLongTermRetentionPolicyResource>("PolicyName");
        RemoveProperty<ManagedInstanceResource>("DnsZonePartner");
        RemoveProperty<ManagedInstanceServerConfigurationOptionResource>("ServerConfigurationOptionName");
        RemoveProperty<ManagedInstanceStartStopScheduleResource>("StartStopScheduleName");
        RemoveProperty<ManagedInstanceVulnerabilityAssessmentResource>("VulnerabilityAssessmentName");
        RemoveProperty<ManagedLedgerDigestUploadResource>("LedgerDigestUploads");
        RemoveProperty<ManagedRestorableDroppedDbBackupShortTermRetentionPolicyResource>("PolicyName");
        RemoveProperty<ManagedServerSecurityAlertPolicyResource>("SecurityAlertPolicyName");
        RemoveProperty<ManagedTransparentDataEncryptionResource>("TdeName");
        RemoveProperty<OutboundFirewallRuleResource>("OutboundRuleFqdn");
        RemoveProperty<ServerAdvancedThreatProtectionResource>("AdvancedThreatProtectionName");
        RemoveProperty<SqlDatabaseBlobAuditingPolicyResource>("BlobAuditingPolicyName");
        RemoveProperty<SqlDatabaseSecurityAlertPolicyResource>("SecurityAlertPolicyName");
        RemoveProperty<SqlDatabaseSqlVulnerabilityAssessmentBaselineResource>("BaselineName");
        RemoveProperty<SqlDatabaseSqlVulnerabilityAssessmentBaselineRuleResource>("RuleId");
        RemoveProperty<SqlDatabaseVulnerabilityAssessmentResource>("VulnerabilityAssessmentName");
        RemoveProperty<SqlDatabaseVulnerabilityAssessmentRuleBaselineResource>("BaselineName");
        RemoveProperty<SqlDatabaseVulnerabilityAssessmentRuleBaselineResource>("RuleId");
        RemoveProperty<SqlServerAzureADAdministratorResource>("AdministratorName");
        RemoveProperty<SqlServerAzureADOnlyAuthenticationResource>("AuthenticationName");
        RemoveProperty<SqlServerBlobAuditingPolicyResource>("BlobAuditingPolicyName");
        RemoveProperty<SqlServerConnectionPolicyResource>("ConnectionPolicyName");
        RemoveProperty<SqlServerDatabaseRestorePointResource>("CreateDatabaseRestorePointDefinition");
        RemoveProperty<SqlServerResource>("MinimalTlsVersion");
        RemoveProperty<SqlServerSecurityAlertPolicyResource>("SecurityAlertPolicyName");
        RemoveProperty<SqlServerSqlVulnerabilityAssessmentBaselineResource>("BaselineName");
        RemoveProperty<SqlServerSqlVulnerabilityAssessmentBaselineRuleResource>("RuleId");
        RemoveProperty<SqlServerSqlVulnerabilityAssessmentResource>("VulnerabilityAssessmentName");
        RemoveProperty<SqlServerVulnerabilityAssessmentResource>("VulnerabilityAssessmentName");
        RemoveProperty<ManagedInstanceDtcSecuritySettings>("XaTransactionsEnabled");

        // Patch models
        RemoveModel<DiffBackupIntervalInHours>(); // TODO: Maybe support extensible enums of other types?
        CustomizeProperty<BackupShortTermRetentionPolicyResource>("DiffBackupIntervalInHours", p => p.PropertyType = TypeRegistry.Get<int>());
        CustomizePropertyIsoDuration<SqlServerJobSchedule>("Interval");
        OrderEnum<ManagedInstancePropertiesProvisioningState>("Creating", "Deleting", "Updating", "Unknown", "Succeeded", "Failed", "Accepted", "Created", "Deleted", "Unrecognized", "Running", "Canceled", "NotSpecified", "Registering", "TimedOut");
        // Not generated today:
        // CustomizePropertyIsoDuration<MaintenanceWindowTimeRange>("Duration");
        IncludeVersions<ManagedInstanceAdvancedThreatProtectionResource>("2021-11-01");
        IncludeVersions<ManagedDatabaseAdvancedThreatProtectionResource>("2021-11-01");
        IncludeVersions<ManagedLedgerDigestUploadResource>("2021-11-01");
        IncludeVersions<SqlServerSqlVulnerabilityAssessmentResource>("2014-01-01", "2014-04-01", "2021-11-01");
        IncludeVersions<SqlServerSqlVulnerabilityAssessmentBaselineResource>("2014-01-01", "2014-04-01", "2021-11-01");
        IncludeVersions<SqlServerSqlVulnerabilityAssessmentBaselineRuleResource>("2014-01-01", "2014-04-01", "2021-11-01");

        // Naming requirements
        AddNameRequirements<ManagedInstanceResource>(min: 1, max: 63, lower: true, digits: true, hyphen: true);
        AddNameRequirements<SqlServerResource>(min: 1, max: 63, lower: true, digits: true, hyphen: true);
        CustomizeProperty<SqlServerAzureADAdministratorResource>("Name", p => { p.GenerateDefaultValue = true; p.HideAccessors = true; }); // must be `ActiveDirectory`
        AddNameRequirements<SqlDatabaseResource>(min: 1, max: 128, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);
        AddNameRequirements<SyncGroupResource>(min: 1, max: 150, lower: true, upper: true, digits: true, hyphen: true, underscore: true);
        AddNameRequirements<ElasticPoolResource>(min: 1, max: 128, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);
        AddNameRequirements<FailoverGroupResource>(min: 1, max: 63, lower: true, digits: true, hyphen: true);
        AddNameRequirements<SqlFirewallRuleResource>(min: 1, max: 128, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);

        // Roles
        Roles.Add(new Role("SqlDBContributor", "9b7fa17d-e63e-47b0-bb0a-15c516ac86ec", "Lets you manage SQL databases, but not access to them. Also, you can't manage their security-related policies or their parent SQL servers."));
        Roles.Add(new Role("SqlManagedInstanceContributor", "4939a1f6-9ae0-4e48-a1e0-f2cbe897382d", "Lets you manage SQL Managed Instances and required network configuration, but can't give access to others."));
        Roles.Add(new Role("SqlSecurityManager", "056cd41c-7e88-42e1-933e-88ba6a50c9c3", "Lets you manage the security-related policies of SQL servers and databases, but not access to them."));
        Roles.Add(new Role("SqlServerContributor", "6d8ee4ec-f05a-4a1d-8b00-a9b17e38b437", "Lets you manage SQL servers and databases, but not access to them, and not their security-related policies."));
        Roles.Add(new Role("AzureConnectedSqlServerOnboarding", "e8113dce-c529-4d33-91fa-e9b972617508", "Allows for read and write access to Azure resources for SQL Server on Arc-enabled servers."));

        // Assign Roles
        CustomizeResource<SqlServerResource>(r => r.GenerateRoleAssignment = true);
    }
}
