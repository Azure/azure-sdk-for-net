// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS1591
#pragma warning disable SA1402
#pragma warning disable SA1508

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("ConnectionState")]
    public partial class ManagedInstancePrivateEndpointConnectionData
    {
        private Azure.ResourceManager.Sql.Models.ManagedInstancePrivateLinkServiceConnectionStateProperty _compatConnectionState;

        [Azure.ResourceManager.Sql.WirePath("properties.privateLinkServiceConnectionState")]
        public Azure.ResourceManager.Sql.Models.ManagedInstancePrivateLinkServiceConnectionStateProperty ConnectionState
        {
            get => _compatConnectionState ?? (default);
            set => _compatConnectionState = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("ConnectionState")]
    public partial class ServerPrivateEndpointConnectionProperties
    {
        private Azure.ResourceManager.Sql.Models.SqlPrivateLinkServiceConnectionStateProperty _compatConnectionState;

        [Azure.ResourceManager.Sql.WirePath("privateLinkServiceConnectionState")]
        public Azure.ResourceManager.Sql.Models.SqlPrivateLinkServiceConnectionStateProperty ConnectionState
        {
            get => _compatConnectionState ?? (default);
            set => _compatConnectionState = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("ConnectionState")]
    public partial class SqlPrivateEndpointConnectionData
    {
        private Azure.ResourceManager.Sql.Models.SqlPrivateLinkServiceConnectionStateProperty _compatConnectionState;

        [Azure.ResourceManager.Sql.WirePath("properties.privateLinkServiceConnectionState")]
        public Azure.ResourceManager.Sql.Models.SqlPrivateLinkServiceConnectionStateProperty ConnectionState
        {
            get => _compatConnectionState ?? (default);
            set => _compatConnectionState = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("BaselineAdjustedResult")]
    [CodeGenSuppress("Remediation")]
    [CodeGenSuppress("RuleMetadata")]
    [CodeGenSuppress("Status")]
    public partial class SqlVulnerabilityAssessmentScanResultData
    {
        private Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineAdjustedResult _compatBaselineAdjustedResult;

        [Azure.ResourceManager.Sql.WirePath("properties.baselineAdjustedResult")]
        public Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentBaselineAdjustedResult BaselineAdjustedResult
        {
            get => _compatBaselineAdjustedResult ?? (default);
            set => _compatBaselineAdjustedResult = value;
        }

        private Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentRemediation _compatRemediation;

        [Azure.ResourceManager.Sql.WirePath("properties.remediation")]
        public Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentRemediation Remediation
        {
            get => _compatRemediation ?? (default);
            set => _compatRemediation = value;
        }

        private Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentRuleMetadata _compatRuleMetadata;

        [Azure.ResourceManager.Sql.WirePath("properties.ruleMetadata")]
        public Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentRuleMetadata RuleMetadata
        {
            get => _compatRuleMetadata ?? (default);
            set => _compatRuleMetadata = value;
        }

        private System.Nullable<Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentRuleStatus> _compatStatus;

        [Azure.ResourceManager.Sql.WirePath("properties.status")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.SqlVulnerabilityAssessmentRuleStatus> Status
        {
            get => _compatStatus ?? (default);
            set => _compatStatus = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("SensitivityLabel")]
    [CodeGenSuppress("Column")]
    [CodeGenSuppress("Op")]
    [CodeGenSuppress("Schema")]
    [CodeGenSuppress("Table")]
    public partial class SensitivityLabelUpdate
    {
        private System.String _compatColumn;

        [Azure.ResourceManager.Sql.WirePath("properties.column")]
        public System.String Column
        {
            get => _compatColumn ?? (default);
            set => _compatColumn = value;
        }

        private System.Nullable<Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateKind> _compatOp;

        [Azure.ResourceManager.Sql.WirePath("properties.op")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.SensitivityLabelUpdateKind> Op
        {
            get => _compatOp ?? (default);
            set => _compatOp = value;
        }

        private System.String _compatSchema;

        [Azure.ResourceManager.Sql.WirePath("properties.schema")]
        public System.String Schema
        {
            get => _compatSchema ?? (default);
            set => _compatSchema = value;
        }

        private Azure.ResourceManager.Sql.SensitivityLabelData _compatSensitivityLabel;

        [Azure.ResourceManager.Sql.WirePath("properties.sensitivityLabel")]
        public Azure.ResourceManager.Sql.SensitivityLabelData SensitivityLabel
        {
            get => _compatSensitivityLabel ?? (default);
            set => _compatSensitivityLabel = value;
        }

        private System.String _compatTable;

        [Azure.ResourceManager.Sql.WirePath("properties.table")]
        public System.String Table
        {
            get => _compatTable ?? (default);
            set => _compatTable = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("FailoverDatabases")]
    public partial class FailoverGroupData
    {
        private System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> _compatFailoverDatabases;

        [Azure.ResourceManager.Sql.WirePath("properties.databases")]
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> FailoverDatabases
        {
            get => _compatFailoverDatabases ?? (default);
            set => _compatFailoverDatabases = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("FailoverDatabases")]
    public partial class FailoverGroupPatch
    {
        private System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> _compatFailoverDatabases;

        [Azure.ResourceManager.Sql.WirePath("properties.databases")]
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> FailoverDatabases
        {
            get => _compatFailoverDatabases ?? (default);
            set => _compatFailoverDatabases = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("Intervals")]
    public partial class QueryStatistics
    {
        private System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.QueryMetricInterval> _compatIntervals;

        [Azure.ResourceManager.Sql.WirePath("properties.intervals")]
        public System.Collections.Generic.IList<Azure.ResourceManager.Sql.Models.QueryMetricInterval> Intervals
        {
            get => _compatIntervals ?? (default);
            set => _compatIntervals = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("ActionDetails")]
    public partial class RecommendedActionData
    {
        private System.Collections.Generic.IReadOnlyDictionary<System.String, System.String> _compatActionDetails;

        [Azure.ResourceManager.Sql.WirePath("properties.details")]
        public System.Collections.Generic.IReadOnlyDictionary<System.String, System.String> ActionDetails
        {
            get => _compatActionDetails ?? (default);
            set => _compatActionDetails = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("UnrestorableFileList")]
    [CodeGenSuppress("CompletedPercent")]
    [CodeGenSuppress("CurrentRestoredSizeInMB")]
    [CodeGenSuppress("CurrentRestorePlanSizeInMB")]
    [CodeGenSuppress("NumberOfFilesFound")]
    [CodeGenSuppress("RestoreType")]
    public partial class ManagedDatabaseRestoreDetailData
    {
        private System.Nullable<System.Int32> _compatCompletedPercent;

        [Azure.ResourceManager.Sql.WirePath("properties.percentCompleted")]
        public System.Nullable<System.Int32> CompletedPercent
        {
            get => _compatCompletedPercent ?? (default);
            set => _compatCompletedPercent = value;
        }

        private System.Nullable<System.Int32> _compatCurrentRestoredSizeInMB;

        [Azure.ResourceManager.Sql.WirePath("properties.currentRestoredSizeMB")]
        public System.Nullable<System.Int32> CurrentRestoredSizeInMB
        {
            get => _compatCurrentRestoredSizeInMB ?? (default);
            set => _compatCurrentRestoredSizeInMB = value;
        }

        private System.Nullable<System.Int32> _compatCurrentRestorePlanSizeInMB;

        [Azure.ResourceManager.Sql.WirePath("properties.currentRestorePlanSizeMB")]
        public System.Nullable<System.Int32> CurrentRestorePlanSizeInMB
        {
            get => _compatCurrentRestorePlanSizeInMB ?? (default);
            set => _compatCurrentRestorePlanSizeInMB = value;
        }

        private System.Nullable<System.Int32> _compatNumberOfFilesFound;

        [Azure.ResourceManager.Sql.WirePath("properties.numberOfFilesDetected")]
        public System.Nullable<System.Int32> NumberOfFilesFound
        {
            get => _compatNumberOfFilesFound ?? (default);
            set => _compatNumberOfFilesFound = value;
        }

        private System.String _compatRestoreType;

        [Azure.ResourceManager.Sql.WirePath("properties.type")]
        public System.String RestoreType
        {
            get => _compatRestoreType ?? (default);
            set => _compatRestoreType = value;
        }

        private System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ManagedDatabaseRestoreDetailUnrestorableFileProperties> _compatUnrestorableFileList;

        [Azure.ResourceManager.Sql.WirePath("properties.unrestorableFiles")]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sql.Models.ManagedDatabaseRestoreDetailUnrestorableFileProperties> UnrestorableFileList
        {
            get => _compatUnrestorableFileList ?? (default);
            set => _compatUnrestorableFileList = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("ClientIP")]
    public partial class SecurityEvent
    {
        private System.Net.IPAddress _compatClientIP;

        [Azure.ResourceManager.Sql.WirePath("properties.clientIp")]
        public System.Net.IPAddress ClientIP
        {
            get => _compatClientIP ?? (default);
            set => _compatClientIP = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("OperationMode")]
    [CodeGenSuppress("StorageKey")]
    [CodeGenSuppress("StorageKeyType")]
    [CodeGenSuppress("StorageUri")]
    public partial class SqlDatabaseExtension
    {
        private System.Nullable<Azure.ResourceManager.Sql.Models.DatabaseExtensionOperationMode> _compatOperationMode;

        [Azure.ResourceManager.Sql.WirePath("properties.operationMode")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.DatabaseExtensionOperationMode> OperationMode
        {
            get => _compatOperationMode ?? (default);
            set => _compatOperationMode = value;
        }

        private System.String _compatStorageKey;

        [Azure.ResourceManager.Sql.WirePath("properties.storageKey")]
        public System.String StorageKey
        {
            get => _compatStorageKey ?? (default);
            set => _compatStorageKey = value;
        }

        private System.Nullable<Azure.ResourceManager.Sql.Models.StorageKeyType> _compatStorageKeyType;

        [Azure.ResourceManager.Sql.WirePath("properties.storageKeyType")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.StorageKeyType> StorageKeyType
        {
            get => _compatStorageKeyType ?? (default);
            set => _compatStorageKeyType = value;
        }

        private System.Uri _compatStorageUri;

        [Azure.ResourceManager.Sql.WirePath("properties.storageUri")]
        public System.Uri StorageUri
        {
            get => _compatStorageUri ?? (default);
            set => _compatStorageUri = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("GeoBackupPolicyState")]
    public partial class GeoBackupPolicyData
    {
        private System.Nullable<Azure.ResourceManager.Sql.Models.GeoBackupPolicyState> _compatGeoBackupPolicyState;

        [Azure.ResourceManager.Sql.WirePath("properties.state")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.GeoBackupPolicyState> GeoBackupPolicyState
        {
            get => _compatGeoBackupPolicyState ?? (default);
            set => _compatGeoBackupPolicyState = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("ProvisioningState")]
    public partial class ManagedInstanceData
    {
        private System.Nullable<Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState> _compatProvisioningState;

        [Azure.ResourceManager.Sql.WirePath("properties.provisioningState")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState> ProvisioningState
        {
            get => _compatProvisioningState ?? (default);
            set => _compatProvisioningState = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("ProvisioningState")]
    public partial class ManagedInstancePatch
    {
        private System.Nullable<Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState> _compatProvisioningState;

        [Azure.ResourceManager.Sql.WirePath("properties.provisioningState")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.ManagedInstancePropertiesProvisioningState> ProvisioningState
        {
            get => _compatProvisioningState ?? (default);
            set => _compatProvisioningState = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("ReplicationState")]
    public partial class SqlServerDatabaseReplicationLinkData
    {
        private System.Nullable<Azure.ResourceManager.Sql.Models.ReplicationLinkState> _compatReplicationState;

        [Azure.ResourceManager.Sql.WirePath("properties.replicationState")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.ReplicationLinkState> ReplicationState
        {
            get => _compatReplicationState ?? (default);
            set => _compatReplicationState = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("PublicNetworkAccess")]
    public partial class SqlServerPatch
    {
        private System.Nullable<Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag> _compatPublicNetworkAccess;

        [Azure.ResourceManager.Sql.WirePath("properties.publicNetworkAccess")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag> PublicNetworkAccess
        {
            get => _compatPublicNetworkAccess ?? (default);
            set => _compatPublicNetworkAccess = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("PublicNetworkAccess")]
    public partial class SqlServerData
    {
        private System.Nullable<Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag> _compatPublicNetworkAccess;

        [Azure.ResourceManager.Sql.WirePath("properties.publicNetworkAccess")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.ServerNetworkAccessFlag> PublicNetworkAccess
        {
            get => _compatPublicNetworkAccess ?? (default);
            set => _compatPublicNetworkAccess = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("InstanceLinkRole")]
    [CodeGenSuppress("PartnerLinkRole")]
    public partial class SqlDistributedAvailabilityGroupData
    {
        private System.Nullable<Azure.ResourceManager.Sql.Models.SqlServerSideLinkRole> _compatInstanceLinkRole;

        [Azure.ResourceManager.Sql.WirePath("properties.instanceLinkRole")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.SqlServerSideLinkRole> InstanceLinkRole
        {
            get => _compatInstanceLinkRole ?? (default);
            set => _compatInstanceLinkRole = value;
        }

        private System.Nullable<Azure.ResourceManager.Sql.Models.SqlServerSideLinkRole> _compatPartnerLinkRole;

        [Azure.ResourceManager.Sql.WirePath("properties.partnerLinkRole")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.SqlServerSideLinkRole> PartnerLinkRole
        {
            get => _compatPartnerLinkRole ?? (default);
            set => _compatPartnerLinkRole = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("AllowAutoCompleteRestore")]
    public partial class ManagedDatabaseData
    {
        private System.Nullable<System.Boolean> _compatAllowAutoCompleteRestore;

        [Azure.ResourceManager.Sql.WirePath("properties.autoCompleteRestore")]
        public System.Nullable<System.Boolean> AllowAutoCompleteRestore
        {
            get => _compatAllowAutoCompleteRestore ?? (default);
            set => _compatAllowAutoCompleteRestore = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("SendToEmailAccountAdmins")]
    public partial class ManagedDatabaseSecurityAlertPolicyData
    {
        private System.Nullable<System.Boolean> _compatSendToEmailAccountAdmins;

        [Azure.ResourceManager.Sql.WirePath("properties.emailAccountAdmins")]
        public System.Nullable<System.Boolean> SendToEmailAccountAdmins
        {
            get => _compatSendToEmailAccountAdmins ?? (default);
            set => _compatSendToEmailAccountAdmins = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("IsAzureADOnlyAuthenticationEnabled")]
    public partial class ManagedInstanceAzureADOnlyAuthenticationData
    {
        private System.Nullable<System.Boolean> _compatIsAzureADOnlyAuthenticationEnabled;

        [Azure.ResourceManager.Sql.WirePath("properties.azureADOnlyAuthentication")]
        public System.Nullable<System.Boolean> IsAzureADOnlyAuthenticationEnabled
        {
            get => _compatIsAzureADOnlyAuthenticationEnabled ?? (default);
            set => _compatIsAzureADOnlyAuthenticationEnabled = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("SendToEmailAccountAdmins")]
    public partial class ManagedServerSecurityAlertPolicyData
    {
        private System.Nullable<System.Boolean> _compatSendToEmailAccountAdmins;

        [Azure.ResourceManager.Sql.WirePath("properties.emailAccountAdmins")]
        public System.Nullable<System.Boolean> SendToEmailAccountAdmins
        {
            get => _compatSendToEmailAccountAdmins ?? (default);
            set => _compatSendToEmailAccountAdmins = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("AllowAutoCompleteRestore")]
    public partial class ManagedDatabasePatch
    {
        private System.Nullable<System.Boolean> _compatAllowAutoCompleteRestore;

        [Azure.ResourceManager.Sql.WirePath("properties.autoCompleteRestore")]
        public System.Nullable<System.Boolean> AllowAutoCompleteRestore
        {
            get => _compatAllowAutoCompleteRestore ?? (default);
            set => _compatAllowAutoCompleteRestore = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("IsAzureADOnlyAuthenticationEnabled")]
    public partial class ManagedInstanceExternalAdministrator
    {
        private System.Nullable<System.Boolean> _compatIsAzureADOnlyAuthenticationEnabled;

        [Azure.ResourceManager.Sql.WirePath("azureADOnlyAuthentication")]
        public System.Nullable<System.Boolean> IsAzureADOnlyAuthenticationEnabled
        {
            get => _compatIsAzureADOnlyAuthenticationEnabled ?? (default);
            set => _compatIsAzureADOnlyAuthenticationEnabled = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("IsAzureADOnlyAuthenticationEnabled")]
    public partial class ServerExternalAdministrator
    {
        private System.Nullable<System.Boolean> _compatIsAzureADOnlyAuthenticationEnabled;

        [Azure.ResourceManager.Sql.WirePath("azureADOnlyAuthentication")]
        public System.Nullable<System.Boolean> IsAzureADOnlyAuthenticationEnabled
        {
            get => _compatIsAzureADOnlyAuthenticationEnabled ?? (default);
            set => _compatIsAzureADOnlyAuthenticationEnabled = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("SendToEmailAccountAdmins")]
    public partial class SqlDatabaseSecurityAlertPolicyData
    {
        private System.Nullable<System.Boolean> _compatSendToEmailAccountAdmins;

        [Azure.ResourceManager.Sql.WirePath("properties.emailAccountAdmins")]
        public System.Nullable<System.Boolean> SendToEmailAccountAdmins
        {
            get => _compatSendToEmailAccountAdmins ?? (default);
            set => _compatSendToEmailAccountAdmins = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("IsAzureADOnlyAuthenticationEnabled")]
    public partial class SqlServerAzureADAdministratorData
    {
        private System.Nullable<System.Boolean> _compatIsAzureADOnlyAuthenticationEnabled;

        [Azure.ResourceManager.Sql.WirePath("properties.azureADOnlyAuthentication")]
        public System.Nullable<System.Boolean> IsAzureADOnlyAuthenticationEnabled
        {
            get => _compatIsAzureADOnlyAuthenticationEnabled ?? (default);
            set => _compatIsAzureADOnlyAuthenticationEnabled = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("IsAzureADOnlyAuthenticationEnabled")]
    public partial class SqlServerAzureADOnlyAuthenticationData
    {
        private System.Nullable<System.Boolean> _compatIsAzureADOnlyAuthenticationEnabled;

        [Azure.ResourceManager.Sql.WirePath("properties.azureADOnlyAuthentication")]
        public System.Nullable<System.Boolean> IsAzureADOnlyAuthenticationEnabled
        {
            get => _compatIsAzureADOnlyAuthenticationEnabled ?? (default);
            set => _compatIsAzureADOnlyAuthenticationEnabled = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("SendToEmailAccountAdmins")]
    public partial class SqlServerSecurityAlertPolicyData
    {
        private System.Nullable<System.Boolean> _compatSendToEmailAccountAdmins;

        [Azure.ResourceManager.Sql.WirePath("properties.emailAccountAdmins")]
        public System.Nullable<System.Boolean> SendToEmailAccountAdmins
        {
            get => _compatSendToEmailAccountAdmins ?? (default);
            set => _compatSendToEmailAccountAdmins = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("IsConflictLoggingEnabled")]
    public partial class SyncGroupData
    {
        private System.Nullable<System.Boolean> _compatIsConflictLoggingEnabled;

        [Azure.ResourceManager.Sql.WirePath("properties.enableConflictLogging")]
        public System.Nullable<System.Boolean> IsConflictLoggingEnabled
        {
            get => _compatIsConflictLoggingEnabled ?? (default);
            set => _compatIsConflictLoggingEnabled = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("BackupExpireOn")]
    [CodeGenSuppress("DatabaseDeletedOn")]
    [CodeGenSuppress("IsBackupImmutable")]
    [CodeGenSuppress("LegalHoldImmutability")]
    [CodeGenSuppress("RequestedBackupStorageRedundancy")]
    [CodeGenSuppress("TimeBasedImmutability")]
    [CodeGenSuppress("TimeBasedImmutabilityMode")]
    public partial class LongTermRetentionBackupData
    {
        private System.Nullable<System.DateTimeOffset> _compatBackupExpireOn;

        [Azure.ResourceManager.Sql.WirePath("properties.backupExpirationTime")]
        public System.Nullable<System.DateTimeOffset> BackupExpireOn
        {
            get => _compatBackupExpireOn ?? (default);
            set => _compatBackupExpireOn = value;
        }

        private System.Nullable<System.DateTimeOffset> _compatDatabaseDeletedOn;

        [Azure.ResourceManager.Sql.WirePath("properties.databaseDeletionTime")]
        public System.Nullable<System.DateTimeOffset> DatabaseDeletedOn
        {
            get => _compatDatabaseDeletedOn ?? (default);
            set => _compatDatabaseDeletedOn = value;
        }

        private System.Nullable<System.Boolean> _compatIsBackupImmutable;

        [Azure.ResourceManager.Sql.WirePath("properties.isBackupImmutable")]
        public System.Nullable<System.Boolean> IsBackupImmutable
        {
            get => _compatIsBackupImmutable ?? (default);
            set => _compatIsBackupImmutable = value;
        }

        private System.Nullable<Azure.ResourceManager.Sql.Models.SetLegalHoldImmutability> _compatLegalHoldImmutability;

        [Azure.ResourceManager.Sql.WirePath("properties.legalHoldImmutability")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.SetLegalHoldImmutability> LegalHoldImmutability
        {
            get => _compatLegalHoldImmutability ?? (default);
            set => _compatLegalHoldImmutability = value;
        }

        private System.Nullable<Azure.ResourceManager.Sql.Models.SqlBackupStorageRedundancy> _compatRequestedBackupStorageRedundancy;

        [Azure.ResourceManager.Sql.WirePath("properties.requestedBackupStorageRedundancy")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.SqlBackupStorageRedundancy> RequestedBackupStorageRedundancy
        {
            get => _compatRequestedBackupStorageRedundancy ?? (default);
            set => _compatRequestedBackupStorageRedundancy = value;
        }

        private System.Nullable<Azure.ResourceManager.Sql.Models.TimeBasedImmutability> _compatTimeBasedImmutability;

        [Azure.ResourceManager.Sql.WirePath("properties.timeBasedImmutability")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.TimeBasedImmutability> TimeBasedImmutability
        {
            get => _compatTimeBasedImmutability ?? (default);
            set => _compatTimeBasedImmutability = value;
        }

        private System.Nullable<Azure.ResourceManager.Sql.Models.TimeBasedImmutabilityMode> _compatTimeBasedImmutabilityMode;

        [Azure.ResourceManager.Sql.WirePath("properties.timeBasedImmutabilityMode")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.TimeBasedImmutabilityMode> TimeBasedImmutabilityMode
        {
            get => _compatTimeBasedImmutabilityMode ?? (default);
            set => _compatTimeBasedImmutabilityMode = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("BackupExpireOn")]
    [CodeGenSuppress("DatabaseDeletedOn")]
    public partial class ManagedInstanceLongTermRetentionBackupData
    {
        private System.Nullable<System.DateTimeOffset> _compatBackupExpireOn;

        [Azure.ResourceManager.Sql.WirePath("properties.backupExpirationTime")]
        public System.Nullable<System.DateTimeOffset> BackupExpireOn
        {
            get => _compatBackupExpireOn ?? (default);
            set => _compatBackupExpireOn = value;
        }

        private System.Nullable<System.DateTimeOffset> _compatDatabaseDeletedOn;

        [Azure.ResourceManager.Sql.WirePath("properties.databaseDeletionTime")]
        public System.Nullable<System.DateTimeOffset> DatabaseDeletedOn
        {
            get => _compatDatabaseDeletedOn ?? (default);
            set => _compatDatabaseDeletedOn = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("EstimatedCompleteOn")]
    public partial class ManagedInstanceOperationData
    {
        private System.Nullable<System.DateTimeOffset> _compatEstimatedCompleteOn;

        [Azure.ResourceManager.Sql.WirePath("properties.estimatedCompletionTime")]
        public System.Nullable<System.DateTimeOffset> EstimatedCompleteOn
        {
            get => _compatEstimatedCompleteOn ?? (default);
            set => _compatEstimatedCompleteOn = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("EstimatedCompleteOn")]
    public partial class DatabaseOperationData
    {
        private System.Nullable<System.DateTimeOffset> _compatEstimatedCompleteOn;

        [Azure.ResourceManager.Sql.WirePath("properties.estimatedCompletionTime")]
        public System.Nullable<System.DateTimeOffset> EstimatedCompleteOn
        {
            get => _compatEstimatedCompleteOn ?? (default);
            set => _compatEstimatedCompleteOn = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("EstimatedCompleteOn")]
    public partial class ElasticPoolOperationData
    {
        private System.Nullable<System.DateTimeOffset> _compatEstimatedCompleteOn;

        [Azure.ResourceManager.Sql.WirePath("properties.estimatedCompletionTime")]
        public System.Nullable<System.DateTimeOffset> EstimatedCompleteOn
        {
            get => _compatEstimatedCompleteOn ?? (default);
            set => _compatEstimatedCompleteOn = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("RestoreFinishedOn")]
    [CodeGenSuppress("RestoreStartedOn")]
    [CodeGenSuppress("BackupSizeInMB")]
    public partial class ManagedDatabaseRestoreDetailBackupSetProperties
    {
        private System.Nullable<System.Int32> _compatBackupSizeInMB;

        [Azure.ResourceManager.Sql.WirePath("backupSizeMB")]
        public System.Nullable<System.Int32> BackupSizeInMB
        {
            get => _compatBackupSizeInMB ?? (default);
            set => _compatBackupSizeInMB = value;
        }

        private System.Nullable<System.DateTimeOffset> _compatRestoreFinishedOn;

        [Azure.ResourceManager.Sql.WirePath("restoreFinishedTimestampUtc")]
        public System.Nullable<System.DateTimeOffset> RestoreFinishedOn
        {
            get => _compatRestoreFinishedOn ?? (default);
            set => _compatRestoreFinishedOn = value;
        }

        private System.Nullable<System.DateTimeOffset> _compatRestoreStartedOn;

        [Azure.ResourceManager.Sql.WirePath("restoreStartedTimestampUtc")]
        public System.Nullable<System.DateTimeOffset> RestoreStartedOn
        {
            get => _compatRestoreStartedOn ?? (default);
            set => _compatRestoreStartedOn = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("EstimatedCompleteOn")]
    public partial class ServerOperationData
    {
        private System.Nullable<System.DateTimeOffset> _compatEstimatedCompleteOn;

        [Azure.ResourceManager.Sql.WirePath("properties.estimatedCompletionTime")]
        public System.Nullable<System.DateTimeOffset> EstimatedCompleteOn
        {
            get => _compatEstimatedCompleteOn ?? (default);
            set => _compatEstimatedCompleteOn = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("SourceDatabaseDeletedOn")]
    public partial class SqlDatabasePatch
    {
        private System.Nullable<System.DateTimeOffset> _compatSourceDatabaseDeletedOn;

        [Azure.ResourceManager.Sql.WirePath("properties.sourceDatabaseDeletionDate")]
        public System.Nullable<System.DateTimeOffset> SourceDatabaseDeletedOn
        {
            get => _compatSourceDatabaseDeletedOn ?? (default);
            set => _compatSourceDatabaseDeletedOn = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("NextResetOn")]
    [CodeGenSuppress("ResourceName")]
    public partial class SqlServerUsage
    {
        private System.Nullable<System.DateTimeOffset> _compatNextResetOn;

        [Azure.ResourceManager.Sql.WirePath("properties.nextResetTime")]
        public System.Nullable<System.DateTimeOffset> NextResetOn
        {
            get => _compatNextResetOn ?? (default);
            set => _compatNextResetOn = value;
        }

        private System.String _compatResourceName;

        [Azure.ResourceManager.Sql.WirePath("properties.resourceName")]
        public System.String ResourceName
        {
            get => _compatResourceName ?? (default);
            set => _compatResourceName = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("LastCheckedOn")]
    public partial class SqlAdvisorData
    {
        private System.Nullable<System.DateTimeOffset> _compatLastCheckedOn;

        [Azure.ResourceManager.Sql.WirePath("properties.lastChecked")]
        public System.Nullable<System.DateTimeOffset> LastCheckedOn
        {
            get => _compatLastCheckedOn ?? (default);
            set => _compatLastCheckedOn = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("SourceDatabaseDeletedOn")]
    public partial class SqlDatabaseData
    {
        private System.Nullable<System.DateTimeOffset> _compatSourceDatabaseDeletedOn;

        [Azure.ResourceManager.Sql.WirePath("properties.sourceDatabaseDeletionDate")]
        public System.Nullable<System.DateTimeOffset> SourceDatabaseDeletedOn
        {
            get => _compatSourceDatabaseDeletedOn ?? (default);
            set => _compatSourceDatabaseDeletedOn = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("EstimatedCompleteOn")]
    public partial class SqlInstancePoolOperationData
    {
        private System.Nullable<System.DateTimeOffset> _compatEstimatedCompleteOn;

        [Azure.ResourceManager.Sql.WirePath("properties.estimatedCompletionTime")]
        public System.Nullable<System.DateTimeOffset> EstimatedCompleteOn
        {
            get => _compatEstimatedCompleteOn ?? (default);
            set => _compatEstimatedCompleteOn = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("RestorePointCreatedOn")]
    public partial class SqlServerDatabaseRestorePointData
    {
        private System.Nullable<System.DateTimeOffset> _compatRestorePointCreatedOn;

        [Azure.ResourceManager.Sql.WirePath("properties.restorePointCreationDate")]
        public System.Nullable<System.DateTimeOffset> RestorePointCreatedOn
        {
            get => _compatRestorePointCreatedOn ?? (default);
            set => _compatRestorePointCreatedOn = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("ExpireOn")]
    public partial class SyncAgentData
    {
        private System.Nullable<System.DateTimeOffset> _compatExpireOn;

        [Azure.ResourceManager.Sql.WirePath("properties.expiryTime")]
        public System.Nullable<System.DateTimeOffset> ExpireOn
        {
            get => _compatExpireOn ?? (default);
            set => _compatExpireOn = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("XATransactionsDefaultTimeoutInSeconds")]
    [CodeGenSuppress("XATransactionsMaximumTimeoutInSeconds")]
    public partial class ManagedInstanceDtcSecuritySettings
    {
        private System.Nullable<System.Int32> _compatXATransactionsDefaultTimeoutInSeconds;

        [Azure.ResourceManager.Sql.WirePath("xaTransactionsDefaultTimeout")]
        public System.Nullable<System.Int32> XATransactionsDefaultTimeoutInSeconds
        {
            get => _compatXATransactionsDefaultTimeoutInSeconds ?? (default);
            set => _compatXATransactionsDefaultTimeoutInSeconds = value;
        }

        private System.Nullable<System.Int32> _compatXATransactionsMaximumTimeoutInSeconds;

        [Azure.ResourceManager.Sql.WirePath("xaTransactionsMaximumTimeout")]
        public System.Nullable<System.Int32> XATransactionsMaximumTimeoutInSeconds
        {
            get => _compatXATransactionsMaximumTimeoutInSeconds ?? (default);
            set => _compatXATransactionsMaximumTimeoutInSeconds = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("EndIPAddress")]
    [CodeGenSuppress("StartIPAddress")]
    public partial class SqlFirewallRuleData
    {
        private System.String _compatEndIPAddress;

        [Azure.ResourceManager.Sql.WirePath("properties.endIpAddress")]
        public System.String EndIPAddress
        {
            get => _compatEndIPAddress ?? (default);
            set => _compatEndIPAddress = value;
        }

        private System.String _compatStartIPAddress;

        [Azure.ResourceManager.Sql.WirePath("properties.startIpAddress")]
        public System.String StartIPAddress
        {
            get => _compatStartIPAddress ?? (default);
            set => _compatStartIPAddress = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("ColumnType")]
    [CodeGenSuppress("IsComputed")]
    [CodeGenSuppress("IsMemoryOptimized")]
    [CodeGenSuppress("TemporalType")]
    public partial class DatabaseColumnData
    {
        private System.Nullable<Azure.ResourceManager.Sql.Models.SqlColumnDataType> _compatColumnType;

        [Azure.ResourceManager.Sql.WirePath("properties.columnType")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.SqlColumnDataType> ColumnType
        {
            get => _compatColumnType ?? (default);
            set => _compatColumnType = value;
        }

        private System.Nullable<System.Boolean> _compatIsComputed;

        [Azure.ResourceManager.Sql.WirePath("properties.isComputed")]
        public System.Nullable<System.Boolean> IsComputed
        {
            get => _compatIsComputed ?? (default);
            set => _compatIsComputed = value;
        }

        private System.Nullable<System.Boolean> _compatIsMemoryOptimized;

        [Azure.ResourceManager.Sql.WirePath("properties.memoryOptimized")]
        public System.Nullable<System.Boolean> IsMemoryOptimized
        {
            get => _compatIsMemoryOptimized ?? (default);
            set => _compatIsMemoryOptimized = value;
        }

        private System.Nullable<Azure.ResourceManager.Sql.Models.TableTemporalType> _compatTemporalType;

        [Azure.ResourceManager.Sql.WirePath("properties.temporalType")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.TableTemporalType> TemporalType
        {
            get => _compatTemporalType ?? (default);
            set => _compatTemporalType = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("IsMemoryOptimized")]
    [CodeGenSuppress("TemporalType")]
    public partial class DatabaseTableData
    {
        private System.Nullable<System.Boolean> _compatIsMemoryOptimized;

        [Azure.ResourceManager.Sql.WirePath("properties.memoryOptimized")]
        public System.Nullable<System.Boolean> IsMemoryOptimized
        {
            get => _compatIsMemoryOptimized ?? (default);
            set => _compatIsMemoryOptimized = value;
        }

        private System.Nullable<Azure.ResourceManager.Sql.Models.TableTemporalType> _compatTemporalType;

        [Azure.ResourceManager.Sql.WirePath("properties.temporalType")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.TableTemporalType> TemporalType
        {
            get => _compatTemporalType ?? (default);
            set => _compatTemporalType = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("PublicBlob")]
    public partial class EndpointCertificateData
    {
        private System.String _compatPublicBlob;

        [Azure.ResourceManager.Sql.WirePath("properties.publicBlob")]
        public System.String PublicBlob
        {
            get => _compatPublicBlob ?? (default);
            set => _compatPublicBlob = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("AllowMultipleMaintenanceWindowsPerCycle")]
    [CodeGenSuppress("DefaultDurationInMinutes")]
    [CodeGenSuppress("IsEnabled")]
    [CodeGenSuppress("MinCycles")]
    [CodeGenSuppress("MinDurationInMinutes")]
    [CodeGenSuppress("TimeGranularityInMinutes")]
    public partial class MaintenanceWindowOptionData
    {
        private System.Nullable<System.Boolean> _compatAllowMultipleMaintenanceWindowsPerCycle;

        [Azure.ResourceManager.Sql.WirePath("properties.allowMultipleMaintenanceWindowsPerCycle")]
        public System.Nullable<System.Boolean> AllowMultipleMaintenanceWindowsPerCycle
        {
            get => _compatAllowMultipleMaintenanceWindowsPerCycle ?? (default);
            set => _compatAllowMultipleMaintenanceWindowsPerCycle = value;
        }

        private System.Nullable<System.Int32> _compatDefaultDurationInMinutes;

        [Azure.ResourceManager.Sql.WirePath("properties.defaultDurationInMinutes")]
        public System.Nullable<System.Int32> DefaultDurationInMinutes
        {
            get => _compatDefaultDurationInMinutes ?? (default);
            set => _compatDefaultDurationInMinutes = value;
        }

        private System.Nullable<System.Boolean> _compatIsEnabled;

        [Azure.ResourceManager.Sql.WirePath("properties.isEnabled")]
        public System.Nullable<System.Boolean> IsEnabled
        {
            get => _compatIsEnabled ?? (default);
            set => _compatIsEnabled = value;
        }

        private System.Nullable<System.Int32> _compatMinCycles;

        [Azure.ResourceManager.Sql.WirePath("properties.minCycles")]
        public System.Nullable<System.Int32> MinCycles
        {
            get => _compatMinCycles ?? (default);
            set => _compatMinCycles = value;
        }

        private System.Nullable<System.Int32> _compatMinDurationInMinutes;

        [Azure.ResourceManager.Sql.WirePath("properties.minDurationInMinutes")]
        public System.Nullable<System.Int32> MinDurationInMinutes
        {
            get => _compatMinDurationInMinutes ?? (default);
            set => _compatMinDurationInMinutes = value;
        }

        private System.Nullable<System.Int32> _compatTimeGranularityInMinutes;

        [Azure.ResourceManager.Sql.WirePath("properties.timeGranularityInMinutes")]
        public System.Nullable<System.Int32> TimeGranularityInMinutes
        {
            get => _compatTimeGranularityInMinutes ?? (default);
            set => _compatTimeGranularityInMinutes = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("Column")]
    [CodeGenSuppress("Op")]
    [CodeGenSuppress("Schema")]
    [CodeGenSuppress("Table")]
    public partial class RecommendedSensitivityLabelUpdate
    {
        private System.String _compatColumn;

        [Azure.ResourceManager.Sql.WirePath("properties.column")]
        public System.String Column
        {
            get => _compatColumn ?? (default);
            set => _compatColumn = value;
        }

        private System.Nullable<Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdateKind> _compatOp;

        [Azure.ResourceManager.Sql.WirePath("properties.op")]
        public System.Nullable<Azure.ResourceManager.Sql.Models.RecommendedSensitivityLabelUpdateKind> Op
        {
            get => _compatOp ?? (default);
            set => _compatOp = value;
        }

        private System.String _compatSchema;

        [Azure.ResourceManager.Sql.WirePath("properties.schema")]
        public System.String Schema
        {
            get => _compatSchema ?? (default);
            set => _compatSchema = value;
        }

        private System.String _compatTable;

        [Azure.ResourceManager.Sql.WirePath("properties.table")]
        public System.String Table
        {
            get => _compatTable ?? (default);
            set => _compatTable = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("Name")]
    [CodeGenSuppress("Properties")]
    public partial class SqlNetworkSecurityPerimeterConfigAccessRule
    {
        private System.String _compatName;

        [Azure.ResourceManager.Sql.WirePath("name")]
        public System.String Name
        {
            get => _compatName ?? (default);
            set => _compatName = value;
        }

        private Azure.ResourceManager.Sql.Models.SqlNetworkSecurityPerimeterConfigAccessRuleProperties _compatProperties;

        [Azure.ResourceManager.Sql.WirePath("properties")]
        public Azure.ResourceManager.Sql.Models.SqlNetworkSecurityPerimeterConfigAccessRuleProperties Properties
        {
            get => _compatProperties ?? (default);
            set => _compatProperties = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("Direction")]
    public partial class SqlNetworkSecurityPerimeterConfigAccessRuleProperties
    {
        private System.String _compatDirection;

        [Azure.ResourceManager.Sql.WirePath("direction")]
        public System.String Direction
        {
            get => _compatDirection ?? (default);
            set => _compatDirection = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("AccessMode")]
    [CodeGenSuppress("Name")]
    public partial class SqlNetworkSecurityPerimeterConfigAssociation
    {
        private System.String _compatAccessMode;

        [Azure.ResourceManager.Sql.WirePath("accessMode")]
        public System.String AccessMode
        {
            get => _compatAccessMode ?? (default);
            set => _compatAccessMode = value;
        }

        private System.String _compatName;

        [Azure.ResourceManager.Sql.WirePath("name")]
        public System.String Name
        {
            get => _compatName ?? (default);
            set => _compatName = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("Id")]
    [CodeGenSuppress("Location")]
    [CodeGenSuppress("PerimeterGuid")]
    public partial class SqlNetworkSecurityPerimeterConfigPerimeter
    {
        private System.String _compatId;

        [Azure.ResourceManager.Sql.WirePath("id")]
        public System.String Id
        {
            get => _compatId ?? (default);
            set => _compatId = value;
        }

        private System.Nullable<Azure.Core.AzureLocation> _compatLocation;

        [Azure.ResourceManager.Sql.WirePath("location")]
        public System.Nullable<Azure.Core.AzureLocation> Location
        {
            get => _compatLocation ?? (default);
            set => _compatLocation = value;
        }

        private System.String _compatPerimeterGuid;

        [Azure.ResourceManager.Sql.WirePath("perimeterGuid")]
        public System.String PerimeterGuid
        {
            get => _compatPerimeterGuid ?? (default);
            set => _compatPerimeterGuid = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("AccessRulesVersion")]
    [CodeGenSuppress("Name")]
    public partial class SqlNetworkSecurityPerimeterConfigProfile
    {
        private System.String _compatAccessRulesVersion;

        [Azure.ResourceManager.Sql.WirePath("accessRulesVersion")]
        public System.String AccessRulesVersion
        {
            get => _compatAccessRulesVersion ?? (default);
            set => _compatAccessRulesVersion = value;
        }

        private System.String _compatName;

        [Azure.ResourceManager.Sql.WirePath("name")]
        public System.String Name
        {
            get => _compatName ?? (default);
            set => _compatName = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("Id")]
    [CodeGenSuppress("Location")]
    [CodeGenSuppress("PerimeterGuid")]
    public partial class SqlNetworkSecurityPerimeterConfigRule
    {
        private System.String _compatId;

        [Azure.ResourceManager.Sql.WirePath("id")]
        public System.String Id
        {
            get => _compatId ?? (default);
            set => _compatId = value;
        }

        private System.Nullable<Azure.Core.AzureLocation> _compatLocation;

        [Azure.ResourceManager.Sql.WirePath("location")]
        public System.Nullable<Azure.Core.AzureLocation> Location
        {
            get => _compatLocation ?? (default);
            set => _compatLocation = value;
        }

        private System.String _compatPerimeterGuid;

        [Azure.ResourceManager.Sql.WirePath("perimeterGuid")]
        public System.String PerimeterGuid
        {
            get => _compatPerimeterGuid ?? (default);
            set => _compatPerimeterGuid = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("Name")]
    [CodeGenSuppress("Properties")]
    public partial class SqlNetworkSecurityPerimeterProvisioningIssue
    {
        private System.String _compatName;

        [Azure.ResourceManager.Sql.WirePath("name")]
        public System.String Name
        {
            get => _compatName ?? (default);
            set => _compatName = value;
        }

        private Azure.ResourceManager.Sql.Models.SqlNetworkSecurityPerimeterProvisioningIssueProperties _compatProperties;

        [Azure.ResourceManager.Sql.WirePath("properties")]
        public Azure.ResourceManager.Sql.Models.SqlNetworkSecurityPerimeterProvisioningIssueProperties Properties
        {
            get => _compatProperties ?? (default);
            set => _compatProperties = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("Description")]
    [CodeGenSuppress("IssueType")]
    [CodeGenSuppress("Severity")]
    public partial class SqlNetworkSecurityPerimeterProvisioningIssueProperties
    {
        private System.String _compatDescription;

        [Azure.ResourceManager.Sql.WirePath("description")]
        public System.String Description
        {
            get => _compatDescription ?? (default);
            set => _compatDescription = value;
        }

        private System.String _compatIssueType;

        [Azure.ResourceManager.Sql.WirePath("issueType")]
        public System.String IssueType
        {
            get => _compatIssueType ?? (default);
            set => _compatIssueType = value;
        }

        private System.String _compatSeverity;

        [Azure.ResourceManager.Sql.WirePath("severity")]
        public System.String Severity
        {
            get => _compatSeverity ?? (default);
            set => _compatSeverity = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("LinkConnectionName")]
    [CodeGenSuppress("WorkspaceId")]
    public partial class SqlSynapseLinkWorkspaceInfo
    {
        private System.String _compatLinkConnectionName;

        [Azure.ResourceManager.Sql.WirePath("linkConnectionName")]
        public System.String LinkConnectionName
        {
            get => _compatLinkConnectionName ?? (default);
            set => _compatLinkConnectionName = value;
        }

        private Azure.Core.ResourceIdentifier _compatWorkspaceId;

        [Azure.ResourceManager.Sql.WirePath("workspaceId")]
        public Azure.Core.ResourceIdentifier WorkspaceId
        {
            get => _compatWorkspaceId ?? (default);
            set => _compatWorkspaceId = value;
        }
    }
}

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("PrivateBlob")]
    public partial class TdeCertificate
    {
        private System.String _compatPrivateBlob;

        [Azure.ResourceManager.Sql.WirePath("properties.privateBlob")]
        public System.String PrivateBlob
        {
            get => _compatPrivateBlob ?? (default);
            set => _compatPrivateBlob = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("Sku")]
    public partial class RestorableDroppedDatabaseData
    {
        private Azure.ResourceManager.Sql.Models.SqlSku _compatSku;

        [Azure.ResourceManager.Sql.WirePath("sku")]
        public Azure.ResourceManager.Sql.Models.SqlSku Sku
        {
            get => _compatSku ?? (default);
            set => _compatSku = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("NetworkSecurityPerimeter")]
    [CodeGenSuppress("Profile")]
    [CodeGenSuppress("ResourceAssociation")]
    public partial class SqlNetworkSecurityPerimeterConfigurationData
    {
        private Azure.ResourceManager.Sql.Models.SqlNetworkSecurityPerimeterConfigPerimeter _compatNetworkSecurityPerimeter;

        [Azure.ResourceManager.Sql.WirePath("properties.networkSecurityPerimeter")]
        public Azure.ResourceManager.Sql.Models.SqlNetworkSecurityPerimeterConfigPerimeter NetworkSecurityPerimeter
        {
            get => _compatNetworkSecurityPerimeter ?? (default);
            set => _compatNetworkSecurityPerimeter = value;
        }

        private Azure.ResourceManager.Sql.Models.SqlNetworkSecurityPerimeterConfigProfile _compatProfile;

        [Azure.ResourceManager.Sql.WirePath("properties.profile")]
        public Azure.ResourceManager.Sql.Models.SqlNetworkSecurityPerimeterConfigProfile Profile
        {
            get => _compatProfile ?? (default);
            set => _compatProfile = value;
        }

        private Azure.ResourceManager.Sql.Models.SqlNetworkSecurityPerimeterConfigAssociation _compatResourceAssociation;

        [Azure.ResourceManager.Sql.WirePath("properties.resourceAssociation")]
        public Azure.ResourceManager.Sql.Models.SqlNetworkSecurityPerimeterConfigAssociation ResourceAssociation
        {
            get => _compatResourceAssociation ?? (default);
            set => _compatResourceAssociation = value;
        }
    }
}

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("CurrentAttempts")]
    public partial class SqlServerJobExecutionData
    {
        private System.Nullable<System.Int32> _compatCurrentAttempts;

        [Azure.ResourceManager.Sql.WirePath("properties.currentAttempts")]
        public System.Nullable<System.Int32> CurrentAttempts
        {
            get => _compatCurrentAttempts ?? (default);
            set => _compatCurrentAttempts = value;
        }
    }
}
