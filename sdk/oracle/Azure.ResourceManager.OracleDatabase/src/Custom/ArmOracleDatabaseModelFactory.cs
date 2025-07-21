// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using static Azure.Core.Pipeline.TaskExtensions;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    public partial class ArmOracleDatabaseModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.AutonomousDatabaseBaseProperties"/>. </summary>
        /// <param name="adminPassword"> Admin password. </param>
        /// <param name="dataBaseType"> Database type to be created. </param>
        /// <param name="autonomousMaintenanceScheduleType"> The maintenance schedule type of the Autonomous Database Serverless. </param>
        /// <param name="characterSet"> The character set for the autonomous database. </param>
        /// <param name="computeCount"> The compute amount (CPUs) available to the database. </param>
        /// <param name="computeModel"> The compute model of the Autonomous Database. </param>
        /// <param name="cpuCoreCount"> The number of CPU cores to be made available to the database. </param>
        /// <param name="customerContacts"> Customer Contacts. </param>
        /// <param name="dataStorageSizeInTbs"> The quantity of data in the database, in terabytes. </param>
        /// <param name="dataStorageSizeInGbs"> The size, in gigabytes, of the data volume that will be created and attached to the database. </param>
        /// <param name="dbVersion"> A valid Oracle Database version for Autonomous Database. </param>
        /// <param name="dbWorkload"> The Autonomous Database workload type. </param>
        /// <param name="displayName"> The user-friendly name for the Autonomous Database. </param>
        /// <param name="isAutoScalingEnabled"> Indicates if auto scaling is enabled for the Autonomous Database CPU core count. </param>
        /// <param name="isAutoScalingForStorageEnabled"> Indicates if auto scaling is enabled for the Autonomous Database storage. </param>
        /// <param name="peerDBIds"> The list of [OCIDs](https://docs.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of standby databases located in Autonomous Data Guard remote regions that are associated with the source database. Note that for Autonomous Database Serverless instances, standby databases located in the same region as the source primary database do not have OCIDs. </param>
        /// <param name="peerDBId"> The database OCID of the Disaster Recovery peer database, which is located in a different region from the current peer database. </param>
        /// <param name="isLocalDataGuardEnabled"> Indicates whether the Autonomous Database has local or called in-region Data Guard enabled. </param>
        /// <param name="isRemoteDataGuardEnabled"> Indicates whether the Autonomous Database has Cross Region Data Guard enabled. </param>
        /// <param name="localDisasterRecoveryType"> Indicates the local disaster recovery (DR) type of the Autonomous Database Serverless instance.Autonomous Data Guard (ADG) DR type provides business critical DR with a faster recovery time objective (RTO) during failover or switchover.Backup-based DR type provides lower cost DR with a slower RTO during failover or switchover. </param>
        /// <param name="localStandbyDB"> Local Autonomous Disaster Recovery standby database details. </param>
        /// <param name="failedDataRecoveryInSeconds"> Indicates the number of seconds of data loss for a Data Guard failover. </param>
        /// <param name="isMtlsConnectionRequired"> Specifies if the Autonomous Database requires mTLS connections. </param>
        /// <param name="isPreviewVersionWithServiceTermsAccepted"> Specifies if the Autonomous Database preview version is being provisioned. </param>
        /// <param name="licenseModel"> The Oracle license model that applies to the Oracle Autonomous Database. The default is LICENSE_INCLUDED. </param>
        /// <param name="ncharacterSet"> The character set for the Autonomous Database. </param>
        /// <param name="lifecycleDetails"> Additional information about the current lifecycle state. </param>
        /// <param name="provisioningState"> Azure resource provisioning state. </param>
        /// <param name="lifecycleState"> Views lifecycleState. </param>
        /// <param name="scheduledOperations"> The list of scheduled operations. </param>
        /// <param name="privateEndpointIP"> The private endpoint Ip address for the resource. </param>
        /// <param name="privateEndpointLabel"> The resource's private endpoint label. </param>
        /// <param name="ociUri"> HTTPS link to OCI resources exposed to Azure Customer via Azure Interface. </param>
        /// <param name="subnetId"> Client subnet. </param>
        /// <param name="vnetId"> VNET for network connectivity. </param>
        /// <param name="createdOn"> The date and time that the database was created. </param>
        /// <param name="maintenanceBeginOn"> The date and time when maintenance will begin. </param>
        /// <param name="maintenanceEndOn"> The date and time when maintenance will end. </param>
        /// <param name="actualUsedDataStorageSizeInTbs"> The current amount of storage in use for user and system data, in terabytes (TB). </param>
        /// <param name="allocatedStorageSizeInTbs"> The amount of storage currently allocated for the database tables and billed for, rounded up. </param>
        /// <param name="apexDetails"> Information about Oracle APEX Application Development. </param>
        /// <param name="availableUpgradeVersions"> List of Oracle Database versions available for a database upgrade. If there are no version upgrades available, this list is empty. </param>
        /// <param name="connectionStrings"> The connection string used to connect to the Autonomous Database. </param>
        /// <param name="connectionUrls"> The URLs for accessing Oracle Application Express (APEX) and SQL Developer Web with a browser from a Compute instance within your VCN or that has a direct connection to your VCN. </param>
        /// <param name="dataSafeStatus"> Status of the Data Safe registration for this Autonomous Database. </param>
        /// <param name="databaseEdition"> The Oracle Database Edition that applies to the Autonomous databases. </param>
        /// <param name="autonomousDatabaseId"> Autonomous Database ID. </param>
        /// <param name="inMemoryAreaInGbs"> The area assigned to In-Memory tables in Autonomous Database. </param>
        /// <param name="nextLongTermBackupCreatedOn"> The date and time when the next long-term backup would be created. </param>
        /// <param name="longTermBackupSchedule"> Details for the long-term backup schedule. </param>
        /// <param name="isPreview"> Indicates if the Autonomous Database version is a preview version. </param>
        /// <param name="localAdgAutoFailoverMaxDataLossLimit"> Parameter that allows users to select an acceptable maximum data loss limit in seconds, up to which Automatic Failover will be triggered when necessary for a Local Autonomous Data Guard. </param>
        /// <param name="memoryPerOracleComputeUnitInGbs"> The amount of memory (in GBs) enabled per ECPU or OCPU. </param>
        /// <param name="openMode"> Indicates the Autonomous Database mode. </param>
        /// <param name="operationsInsightsStatus"> Status of Operations Insights for this Autonomous Database. </param>
        /// <param name="permissionLevel"> The Autonomous Database permission level. </param>
        /// <param name="privateEndpoint"> The private endpoint for the resource. </param>
        /// <param name="provisionableCpus"> An array of CPU values that an Autonomous Database can be scaled to. </param>
        /// <param name="role"> The Data Guard role of the Autonomous Container Database or Autonomous Database, if Autonomous Data Guard is enabled. </param>
        /// <param name="serviceConsoleUri"> The URL of the Service Console for the Autonomous Database. </param>
        /// <param name="sqlWebDeveloperUri"> The SQL Web Developer URL for the Oracle Autonomous Database. </param>
        /// <param name="supportedRegionsToCloneTo"> The list of regions that support the creation of an Autonomous Database clone or an Autonomous Data Guard standby database. </param>
        /// <param name="dataGuardRoleChangedOn"> The date and time the Autonomous Data Guard role was switched for the Autonomous Database. </param>
        /// <param name="freeAutonomousDatabaseDeletedOn"> The date and time the Always Free database will be automatically deleted because of inactivity. </param>
        /// <param name="timeLocalDataGuardEnabled"> The date and time that Autonomous Data Guard was enabled for an Autonomous Database where the standby was provisioned in the same region as the primary database. </param>
        /// <param name="lastFailoverHappenedOn"> The timestamp of the last failover operation. </param>
        /// <param name="lastRefreshHappenedOn"> The date and time when last refresh happened. </param>
        /// <param name="lastRefreshPointTimestamp"> The refresh point timestamp (UTC). </param>
        /// <param name="lastSwitchoverHappenedOn"> The timestamp of the last switchover operation for the Autonomous Database. </param>
        /// <param name="freeAutonomousDatabaseStoppedOn"> The date and time the Always Free database will be stopped because of inactivity. </param>
        /// <param name="usedDataStorageSizeInGbs"> The storage space consumed by Autonomous Database in GBs. </param>
        /// <param name="usedDataStorageSizeInTbs"> The amount of storage that has been used, in terabytes. </param>
        /// <param name="ocid"> Database ocid. </param>
        /// <param name="backupRetentionPeriodInDays"> Retention period, in days, for long-term backups. </param>
        /// <param name="whitelistedIPs"> The client IP access control list (ACL). This is an array of CIDR notations and/or IP addresses. Values should be separate strings, separated by commas. Example: ['1.1.1.1','1.1.1.0/24','1.1.2.25']. </param>
        /// <returns> A new <see cref="Models.AutonomousDatabaseBaseProperties"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AutonomousDatabaseBaseProperties AutonomousDatabaseBaseProperties(string adminPassword, string dataBaseType, AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType, string characterSet, float? computeCount, AutonomousDatabaseComputeModel? computeModel, int? cpuCoreCount, IEnumerable<OracleCustomerContact> customerContacts, int? dataStorageSizeInTbs, int? dataStorageSizeInGbs, string dbVersion, AutonomousDatabaseWorkloadType? dbWorkload, string displayName, bool? isAutoScalingEnabled, bool? isAutoScalingForStorageEnabled, IEnumerable<string> peerDBIds, string peerDBId, bool? isLocalDataGuardEnabled, bool? isRemoteDataGuardEnabled, DisasterRecoveryType? localDisasterRecoveryType, AutonomousDatabaseStandbySummary localStandbyDB, int? failedDataRecoveryInSeconds, bool? isMtlsConnectionRequired, bool? isPreviewVersionWithServiceTermsAccepted, OracleLicenseModel? licenseModel, string ncharacterSet, string lifecycleDetails, OracleDatabaseProvisioningState? provisioningState, AutonomousDatabaseLifecycleState? lifecycleState, ScheduledOperationsType scheduledOperations, string privateEndpointIP, string privateEndpointLabel, Uri ociUri, ResourceIdentifier subnetId, ResourceIdentifier vnetId, DateTimeOffset? createdOn, DateTimeOffset? maintenanceBeginOn, DateTimeOffset? maintenanceEndOn, double? actualUsedDataStorageSizeInTbs, double? allocatedStorageSizeInTbs, OracleApexDetailsType apexDetails, IEnumerable<string> availableUpgradeVersions, AutonomousDatabaseConnectionStrings connectionStrings, AutonomousDatabaseConnectionUrls connectionUrls, DataSafeStatusType? dataSafeStatus, OracleDatabaseEditionType? databaseEdition, ResourceIdentifier autonomousDatabaseId, int? inMemoryAreaInGbs, DateTimeOffset? nextLongTermBackupCreatedOn, LongTermBackUpScheduleDetails longTermBackupSchedule, bool? isPreview, int? localAdgAutoFailoverMaxDataLossLimit, int? memoryPerOracleComputeUnitInGbs, AutonomousDatabaseModeType? openMode, OperationsInsightsStatusType? operationsInsightsStatus, AutonomousDatabasePermissionLevelType? permissionLevel, string privateEndpoint, IEnumerable<int> provisionableCpus, DataGuardRoleType? role, Uri serviceConsoleUri, Uri sqlWebDeveloperUri, IEnumerable<string> supportedRegionsToCloneTo, DateTimeOffset? dataGuardRoleChangedOn, DateTimeOffset? freeAutonomousDatabaseDeletedOn, string timeLocalDataGuardEnabled, DateTimeOffset? lastFailoverHappenedOn, DateTimeOffset? lastRefreshHappenedOn, DateTimeOffset? lastRefreshPointTimestamp, DateTimeOffset? lastSwitchoverHappenedOn, DateTimeOffset? freeAutonomousDatabaseStoppedOn, int? usedDataStorageSizeInGbs, int? usedDataStorageSizeInTbs, ResourceIdentifier ocid, int? backupRetentionPeriodInDays, IEnumerable<string> whitelistedIPs)
        {
            throw new NotSupportedException("This method is not supported. Use the new version of this factory method instead.");
        }

        /// <summary> Initializes a new instance of <see cref="Models.AutonomousDatabaseBackupProperties"/>. </summary>
        /// <param name="autonomousDatabaseOcid"> The OCID of the Autonomous Database. </param>
        /// <param name="databaseSizeInTbs"> The size of the database in terabytes at the time the backup was taken. </param>
        /// <param name="dbVersion"> A valid Oracle Database version for Autonomous Database. </param>
        /// <param name="displayName"> The user-friendly name for the backup. The name does not have to be unique. </param>
        /// <param name="ocid"> The OCID of the Autonomous Database backup. </param>
        /// <param name="isAutomatic"> Indicates whether the backup is user-initiated or automatic. </param>
        /// <param name="isRestorable"> Indicates whether the backup can be used to restore the associated Autonomous Database. </param>
        /// <param name="lifecycleDetails"> Additional information about the current lifecycle state. </param>
        /// <param name="lifecycleState"> The current state of the backup. </param>
        /// <param name="retentionPeriodInDays"> Retention period, in days, for long-term backups. </param>
        /// <param name="sizeInTbs"> The backup size in terabytes (TB). </param>
        /// <param name="timeAvailableTil"> Timestamp until when the backup will be available. </param>
        /// <param name="timeStarted"> The date and time the backup started. </param>
        /// <param name="timeEnded"> The date and time the backup completed. </param>
        /// <param name="backupType"> The type of backup. </param>
        /// <param name="provisioningState"> Azure resource provisioning state. </param>
        /// <returns> A new <see cref="Models.AutonomousDatabaseBackupProperties"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AutonomousDatabaseBackupProperties AutonomousDatabaseBackupProperties(ResourceIdentifier autonomousDatabaseOcid, double? databaseSizeInTbs, string dbVersion, string displayName, ResourceIdentifier ocid, bool? isAutomatic, bool? isRestorable, string lifecycleDetails, AutonomousDatabaseBackupLifecycleState? lifecycleState, int? retentionPeriodInDays, double? sizeInTbs, DateTimeOffset? timeAvailableTil, string timeStarted, string timeEnded, AutonomousDatabaseBackupType? backupType, OracleDatabaseProvisioningState? provisioningState)
        {
            throw new NotSupportedException("This method is not supported. Use the new version of this factory method instead.");
        }

        /// <summary> Initializes a new instance of <see cref="Models.AutonomousDatabaseCloneProperties"/>. </summary>
        /// <param name="adminPassword"> Admin password. </param>
        /// <param name="autonomousMaintenanceScheduleType"> The maintenance schedule type of the Autonomous Database Serverless. </param>
        /// <param name="characterSet"> The character set for the autonomous database. </param>
        /// <param name="computeCount"> The compute amount (CPUs) available to the database. </param>
        /// <param name="computeModel"> The compute model of the Autonomous Database. </param>
        /// <param name="cpuCoreCount"> The number of CPU cores to be made available to the database. </param>
        /// <param name="customerContacts"> Customer Contacts. </param>
        /// <param name="dataStorageSizeInTbs"> The quantity of data in the database, in terabytes. </param>
        /// <param name="dataStorageSizeInGbs"> The size, in gigabytes, of the data volume that will be created and attached to the database. </param>
        /// <param name="dbVersion"> A valid Oracle Database version for Autonomous Database. </param>
        /// <param name="dbWorkload"> The Autonomous Database workload type. </param>
        /// <param name="displayName"> The user-friendly name for the Autonomous Database. </param>
        /// <param name="isAutoScalingEnabled"> Indicates if auto scaling is enabled for the Autonomous Database CPU core count. </param>
        /// <param name="isAutoScalingForStorageEnabled"> Indicates if auto scaling is enabled for the Autonomous Database storage. </param>
        /// <param name="peerDBIds"> The list of [OCIDs](https://docs.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of standby databases located in Autonomous Data Guard remote regions that are associated with the source database. Note that for Autonomous Database Serverless instances, standby databases located in the same region as the source primary database do not have OCIDs. </param>
        /// <param name="peerDBId"> The database OCID of the Disaster Recovery peer database, which is located in a different region from the current peer database. </param>
        /// <param name="isLocalDataGuardEnabled"> Indicates whether the Autonomous Database has local or called in-region Data Guard enabled. </param>
        /// <param name="isRemoteDataGuardEnabled"> Indicates whether the Autonomous Database has Cross Region Data Guard enabled. </param>
        /// <param name="localDisasterRecoveryType"> Indicates the local disaster recovery (DR) type of the Autonomous Database Serverless instance.Autonomous Data Guard (ADG) DR type provides business critical DR with a faster recovery time objective (RTO) during failover or switchover.Backup-based DR type provides lower cost DR with a slower RTO during failover or switchover. </param>
        /// <param name="localStandbyDB"> Local Autonomous Disaster Recovery standby database details. </param>
        /// <param name="failedDataRecoveryInSeconds"> Indicates the number of seconds of data loss for a Data Guard failover. </param>
        /// <param name="isMtlsConnectionRequired"> Specifies if the Autonomous Database requires mTLS connections. </param>
        /// <param name="isPreviewVersionWithServiceTermsAccepted"> Specifies if the Autonomous Database preview version is being provisioned. </param>
        /// <param name="licenseModel"> The Oracle license model that applies to the Oracle Autonomous Database. The default is LICENSE_INCLUDED. </param>
        /// <param name="ncharacterSet"> The character set for the Autonomous Database. </param>
        /// <param name="lifecycleDetails"> Additional information about the current lifecycle state. </param>
        /// <param name="provisioningState"> Azure resource provisioning state. </param>
        /// <param name="lifecycleState"> Views lifecycleState. </param>
        /// <param name="scheduledOperations"> The list of scheduled operations. </param>
        /// <param name="privateEndpointIP"> The private endpoint Ip address for the resource. </param>
        /// <param name="privateEndpointLabel"> The resource's private endpoint label. </param>
        /// <param name="ociUri"> HTTPS link to OCI resources exposed to Azure Customer via Azure Interface. </param>
        /// <param name="subnetId"> Client subnet. </param>
        /// <param name="vnetId"> VNET for network connectivity. </param>
        /// <param name="createdOn"> The date and time that the database was created. </param>
        /// <param name="maintenanceBeginOn"> The date and time when maintenance will begin. </param>
        /// <param name="maintenanceEndOn"> The date and time when maintenance will end. </param>
        /// <param name="actualUsedDataStorageSizeInTbs"> The current amount of storage in use for user and system data, in terabytes (TB). </param>
        /// <param name="allocatedStorageSizeInTbs"> The amount of storage currently allocated for the database tables and billed for, rounded up. </param>
        /// <param name="apexDetails"> Information about Oracle APEX Application Development. </param>
        /// <param name="availableUpgradeVersions"> List of Oracle Database versions available for a database upgrade. If there are no version upgrades available, this list is empty. </param>
        /// <param name="connectionStrings"> The connection string used to connect to the Autonomous Database. </param>
        /// <param name="connectionUrls"> The URLs for accessing Oracle Application Express (APEX) and SQL Developer Web with a browser from a Compute instance within your VCN or that has a direct connection to your VCN. </param>
        /// <param name="dataSafeStatus"> Status of the Data Safe registration for this Autonomous Database. </param>
        /// <param name="databaseEdition"> The Oracle Database Edition that applies to the Autonomous databases. </param>
        /// <param name="autonomousDatabaseId"> Autonomous Database ID. </param>
        /// <param name="inMemoryAreaInGbs"> The area assigned to In-Memory tables in Autonomous Database. </param>
        /// <param name="nextLongTermBackupCreatedOn"> The date and time when the next long-term backup would be created. </param>
        /// <param name="longTermBackupSchedule"> Details for the long-term backup schedule. </param>
        /// <param name="isPreview"> Indicates if the Autonomous Database version is a preview version. </param>
        /// <param name="localAdgAutoFailoverMaxDataLossLimit"> Parameter that allows users to select an acceptable maximum data loss limit in seconds, up to which Automatic Failover will be triggered when necessary for a Local Autonomous Data Guard. </param>
        /// <param name="memoryPerOracleComputeUnitInGbs"> The amount of memory (in GBs) enabled per ECPU or OCPU. </param>
        /// <param name="openMode"> Indicates the Autonomous Database mode. </param>
        /// <param name="operationsInsightsStatus"> Status of Operations Insights for this Autonomous Database. </param>
        /// <param name="permissionLevel"> The Autonomous Database permission level. </param>
        /// <param name="privateEndpoint"> The private endpoint for the resource. </param>
        /// <param name="provisionableCpus"> An array of CPU values that an Autonomous Database can be scaled to. </param>
        /// <param name="role"> The Data Guard role of the Autonomous Container Database or Autonomous Database, if Autonomous Data Guard is enabled. </param>
        /// <param name="serviceConsoleUri"> The URL of the Service Console for the Autonomous Database. </param>
        /// <param name="sqlWebDeveloperUri"> The SQL Web Developer URL for the Oracle Autonomous Database. </param>
        /// <param name="supportedRegionsToCloneTo"> The list of regions that support the creation of an Autonomous Database clone or an Autonomous Data Guard standby database. </param>
        /// <param name="dataGuardRoleChangedOn"> The date and time the Autonomous Data Guard role was switched for the Autonomous Database. </param>
        /// <param name="freeAutonomousDatabaseDeletedOn"> The date and time the Always Free database will be automatically deleted because of inactivity. </param>
        /// <param name="timeLocalDataGuardEnabled"> The date and time that Autonomous Data Guard was enabled for an Autonomous Database where the standby was provisioned in the same region as the primary database. </param>
        /// <param name="lastFailoverHappenedOn"> The timestamp of the last failover operation. </param>
        /// <param name="lastRefreshHappenedOn"> The date and time when last refresh happened. </param>
        /// <param name="lastRefreshPointTimestamp"> The refresh point timestamp (UTC). </param>
        /// <param name="lastSwitchoverHappenedOn"> The timestamp of the last switchover operation for the Autonomous Database. </param>
        /// <param name="freeAutonomousDatabaseStoppedOn"> The date and time the Always Free database will be stopped because of inactivity. </param>
        /// <param name="usedDataStorageSizeInGbs"> The storage space consumed by Autonomous Database in GBs. </param>
        /// <param name="usedDataStorageSizeInTbs"> The amount of storage that has been used, in terabytes. </param>
        /// <param name="ocid"> Database ocid. </param>
        /// <param name="backupRetentionPeriodInDays"> Retention period, in days, for long-term backups. </param>
        /// <param name="whitelistedIPs"> The client IP access control list (ACL). This is an array of CIDR notations and/or IP addresses. Values should be separate strings, separated by commas. Example: ['1.1.1.1','1.1.1.0/24','1.1.2.25']. </param>
        /// <param name="source"> The source of the database. </param>
        /// <param name="sourceId"> The Azure ID of the Autonomous Database that was cloned to create the current Autonomous Database. </param>
        /// <param name="cloneType"> The Autonomous Database clone type. </param>
        /// <param name="isReconnectCloneEnabled"> Indicates if the refreshable clone can be reconnected to its source database. </param>
        /// <param name="isRefreshableClone"> Indicates if the Autonomous Database is a refreshable clone. </param>
        /// <param name="refreshableModel"> The refresh mode of the clone. </param>
        /// <param name="refreshableStatus"> The refresh status of the clone. </param>
        /// <param name="reconnectCloneEnabledOn"> The time and date as an RFC3339 formatted string, e.g., 2022-01-01T12:00:00.000Z, to set the limit for a refreshable clone to be reconnected to its source database. </param>
        /// <returns> A new <see cref="Models.AutonomousDatabaseCloneProperties"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AutonomousDatabaseCloneProperties AutonomousDatabaseCloneProperties(string adminPassword, AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType, string characterSet, float? computeCount, AutonomousDatabaseComputeModel? computeModel, int? cpuCoreCount, IEnumerable<OracleCustomerContact> customerContacts, int? dataStorageSizeInTbs, int? dataStorageSizeInGbs, string dbVersion, AutonomousDatabaseWorkloadType? dbWorkload, string displayName, bool? isAutoScalingEnabled, bool? isAutoScalingForStorageEnabled, IEnumerable<string> peerDBIds, string peerDBId, bool? isLocalDataGuardEnabled, bool? isRemoteDataGuardEnabled, DisasterRecoveryType? localDisasterRecoveryType, AutonomousDatabaseStandbySummary localStandbyDB, int? failedDataRecoveryInSeconds, bool? isMtlsConnectionRequired, bool? isPreviewVersionWithServiceTermsAccepted, OracleLicenseModel? licenseModel, string ncharacterSet, string lifecycleDetails, OracleDatabaseProvisioningState? provisioningState, AutonomousDatabaseLifecycleState? lifecycleState, ScheduledOperationsType scheduledOperations, string privateEndpointIP, string privateEndpointLabel, Uri ociUri, ResourceIdentifier subnetId, ResourceIdentifier vnetId, DateTimeOffset? createdOn, DateTimeOffset? maintenanceBeginOn, DateTimeOffset? maintenanceEndOn, double? actualUsedDataStorageSizeInTbs, double? allocatedStorageSizeInTbs, OracleApexDetailsType apexDetails, IEnumerable<string> availableUpgradeVersions, AutonomousDatabaseConnectionStrings connectionStrings, AutonomousDatabaseConnectionUrls connectionUrls, DataSafeStatusType? dataSafeStatus, OracleDatabaseEditionType? databaseEdition, ResourceIdentifier autonomousDatabaseId, int? inMemoryAreaInGbs, DateTimeOffset? nextLongTermBackupCreatedOn, LongTermBackUpScheduleDetails longTermBackupSchedule, bool? isPreview, int? localAdgAutoFailoverMaxDataLossLimit, int? memoryPerOracleComputeUnitInGbs, AutonomousDatabaseModeType? openMode, OperationsInsightsStatusType? operationsInsightsStatus, AutonomousDatabasePermissionLevelType? permissionLevel, string privateEndpoint, IEnumerable<int> provisionableCpus, DataGuardRoleType? role, Uri serviceConsoleUri, Uri sqlWebDeveloperUri, IEnumerable<string> supportedRegionsToCloneTo, DateTimeOffset? dataGuardRoleChangedOn, DateTimeOffset? freeAutonomousDatabaseDeletedOn, string timeLocalDataGuardEnabled, DateTimeOffset? lastFailoverHappenedOn, DateTimeOffset? lastRefreshHappenedOn, DateTimeOffset? lastRefreshPointTimestamp, DateTimeOffset? lastSwitchoverHappenedOn, DateTimeOffset? freeAutonomousDatabaseStoppedOn, int? usedDataStorageSizeInGbs, int? usedDataStorageSizeInTbs, ResourceIdentifier ocid, int? backupRetentionPeriodInDays, IEnumerable<string> whitelistedIPs, AutonomousDatabaseSourceType? source, ResourceIdentifier sourceId, AutonomousDatabaseCloneType cloneType, bool? isReconnectCloneEnabled, bool? isRefreshableClone, RefreshableModelType? refreshableModel, RefreshableStatusType? refreshableStatus, DateTimeOffset? reconnectCloneEnabledOn)
        {
            throw new NotSupportedException("This method is not supported. Use the new version of this factory method instead.");
        }

        /// <summary> Initializes a new instance of <see cref="Models.AutonomousDatabaseProperties"/>. </summary>
        /// <param name="adminPassword"> Admin password. </param>
        /// <param name="autonomousMaintenanceScheduleType"> The maintenance schedule type of the Autonomous Database Serverless. </param>
        /// <param name="characterSet"> The character set for the autonomous database. </param>
        /// <param name="computeCount"> The compute amount (CPUs) available to the database. </param>
        /// <param name="computeModel"> The compute model of the Autonomous Database. </param>
        /// <param name="cpuCoreCount"> The number of CPU cores to be made available to the database. </param>
        /// <param name="customerContacts"> Customer Contacts. </param>
        /// <param name="dataStorageSizeInTbs"> The quantity of data in the database, in terabytes. </param>
        /// <param name="dataStorageSizeInGbs"> The size, in gigabytes, of the data volume that will be created and attached to the database. </param>
        /// <param name="dbVersion"> A valid Oracle Database version for Autonomous Database. </param>
        /// <param name="dbWorkload"> The Autonomous Database workload type. </param>
        /// <param name="displayName"> The user-friendly name for the Autonomous Database. </param>
        /// <param name="isAutoScalingEnabled"> Indicates if auto scaling is enabled for the Autonomous Database CPU core count. </param>
        /// <param name="isAutoScalingForStorageEnabled"> Indicates if auto scaling is enabled for the Autonomous Database storage. </param>
        /// <param name="peerDBIds"> The list of [OCIDs](https://docs.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of standby databases located in Autonomous Data Guard remote regions that are associated with the source database. Note that for Autonomous Database Serverless instances, standby databases located in the same region as the source primary database do not have OCIDs. </param>
        /// <param name="peerDBId"> The database OCID of the Disaster Recovery peer database, which is located in a different region from the current peer database. </param>
        /// <param name="isLocalDataGuardEnabled"> Indicates whether the Autonomous Database has local or called in-region Data Guard enabled. </param>
        /// <param name="isRemoteDataGuardEnabled"> Indicates whether the Autonomous Database has Cross Region Data Guard enabled. </param>
        /// <param name="localDisasterRecoveryType"> Indicates the local disaster recovery (DR) type of the Autonomous Database Serverless instance.Autonomous Data Guard (ADG) DR type provides business critical DR with a faster recovery time objective (RTO) during failover or switchover.Backup-based DR type provides lower cost DR with a slower RTO during failover or switchover. </param>
        /// <param name="localStandbyDB"> Local Autonomous Disaster Recovery standby database details. </param>
        /// <param name="failedDataRecoveryInSeconds"> Indicates the number of seconds of data loss for a Data Guard failover. </param>
        /// <param name="isMtlsConnectionRequired"> Specifies if the Autonomous Database requires mTLS connections. </param>
        /// <param name="isPreviewVersionWithServiceTermsAccepted"> Specifies if the Autonomous Database preview version is being provisioned. </param>
        /// <param name="licenseModel"> The Oracle license model that applies to the Oracle Autonomous Database. The default is LICENSE_INCLUDED. </param>
        /// <param name="ncharacterSet"> The character set for the Autonomous Database. </param>
        /// <param name="lifecycleDetails"> Additional information about the current lifecycle state. </param>
        /// <param name="provisioningState"> Azure resource provisioning state. </param>
        /// <param name="lifecycleState"> Views lifecycleState. </param>
        /// <param name="scheduledOperations"> The list of scheduled operations. </param>
        /// <param name="privateEndpointIP"> The private endpoint Ip address for the resource. </param>
        /// <param name="privateEndpointLabel"> The resource's private endpoint label. </param>
        /// <param name="ociUri"> HTTPS link to OCI resources exposed to Azure Customer via Azure Interface. </param>
        /// <param name="subnetId"> Client subnet. </param>
        /// <param name="vnetId"> VNET for network connectivity. </param>
        /// <param name="createdOn"> The date and time that the database was created. </param>
        /// <param name="maintenanceBeginOn"> The date and time when maintenance will begin. </param>
        /// <param name="maintenanceEndOn"> The date and time when maintenance will end. </param>
        /// <param name="actualUsedDataStorageSizeInTbs"> The current amount of storage in use for user and system data, in terabytes (TB). </param>
        /// <param name="allocatedStorageSizeInTbs"> The amount of storage currently allocated for the database tables and billed for, rounded up. </param>
        /// <param name="apexDetails"> Information about Oracle APEX Application Development. </param>
        /// <param name="availableUpgradeVersions"> List of Oracle Database versions available for a database upgrade. If there are no version upgrades available, this list is empty. </param>
        /// <param name="connectionStrings"> The connection string used to connect to the Autonomous Database. </param>
        /// <param name="connectionUrls"> The URLs for accessing Oracle Application Express (APEX) and SQL Developer Web with a browser from a Compute instance within your VCN or that has a direct connection to your VCN. </param>
        /// <param name="dataSafeStatus"> Status of the Data Safe registration for this Autonomous Database. </param>
        /// <param name="databaseEdition"> The Oracle Database Edition that applies to the Autonomous databases. </param>
        /// <param name="autonomousDatabaseId"> Autonomous Database ID. </param>
        /// <param name="inMemoryAreaInGbs"> The area assigned to In-Memory tables in Autonomous Database. </param>
        /// <param name="nextLongTermBackupCreatedOn"> The date and time when the next long-term backup would be created. </param>
        /// <param name="longTermBackupSchedule"> Details for the long-term backup schedule. </param>
        /// <param name="isPreview"> Indicates if the Autonomous Database version is a preview version. </param>
        /// <param name="localAdgAutoFailoverMaxDataLossLimit"> Parameter that allows users to select an acceptable maximum data loss limit in seconds, up to which Automatic Failover will be triggered when necessary for a Local Autonomous Data Guard. </param>
        /// <param name="memoryPerOracleComputeUnitInGbs"> The amount of memory (in GBs) enabled per ECPU or OCPU. </param>
        /// <param name="openMode"> Indicates the Autonomous Database mode. </param>
        /// <param name="operationsInsightsStatus"> Status of Operations Insights for this Autonomous Database. </param>
        /// <param name="permissionLevel"> The Autonomous Database permission level. </param>
        /// <param name="privateEndpoint"> The private endpoint for the resource. </param>
        /// <param name="provisionableCpus"> An array of CPU values that an Autonomous Database can be scaled to. </param>
        /// <param name="role"> The Data Guard role of the Autonomous Container Database or Autonomous Database, if Autonomous Data Guard is enabled. </param>
        /// <param name="serviceConsoleUri"> The URL of the Service Console for the Autonomous Database. </param>
        /// <param name="sqlWebDeveloperUri"> The SQL Web Developer URL for the Oracle Autonomous Database. </param>
        /// <param name="supportedRegionsToCloneTo"> The list of regions that support the creation of an Autonomous Database clone or an Autonomous Data Guard standby database. </param>
        /// <param name="dataGuardRoleChangedOn"> The date and time the Autonomous Data Guard role was switched for the Autonomous Database. </param>
        /// <param name="freeAutonomousDatabaseDeletedOn"> The date and time the Always Free database will be automatically deleted because of inactivity. </param>
        /// <param name="timeLocalDataGuardEnabled"> The date and time that Autonomous Data Guard was enabled for an Autonomous Database where the standby was provisioned in the same region as the primary database. </param>
        /// <param name="lastFailoverHappenedOn"> The timestamp of the last failover operation. </param>
        /// <param name="lastRefreshHappenedOn"> The date and time when last refresh happened. </param>
        /// <param name="lastRefreshPointTimestamp"> The refresh point timestamp (UTC). </param>
        /// <param name="lastSwitchoverHappenedOn"> The timestamp of the last switchover operation for the Autonomous Database. </param>
        /// <param name="freeAutonomousDatabaseStoppedOn"> The date and time the Always Free database will be stopped because of inactivity. </param>
        /// <param name="usedDataStorageSizeInGbs"> The storage space consumed by Autonomous Database in GBs. </param>
        /// <param name="usedDataStorageSizeInTbs"> The amount of storage that has been used, in terabytes. </param>
        /// <param name="ocid"> Database ocid. </param>
        /// <param name="backupRetentionPeriodInDays"> Retention period, in days, for long-term backups. </param>
        /// <param name="whitelistedIPs"> The client IP access control list (ACL). This is an array of CIDR notations and/or IP addresses. Values should be separate strings, separated by commas. Example: ['1.1.1.1','1.1.1.0/24','1.1.2.25']. </param>
        /// <returns> A new <see cref="Models.AutonomousDatabaseProperties"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AutonomousDatabaseProperties AutonomousDatabaseProperties(string adminPassword, AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType, string characterSet, float? computeCount, AutonomousDatabaseComputeModel? computeModel, int? cpuCoreCount, IEnumerable<OracleCustomerContact> customerContacts, int? dataStorageSizeInTbs, int? dataStorageSizeInGbs, string dbVersion, AutonomousDatabaseWorkloadType? dbWorkload, string displayName, bool? isAutoScalingEnabled, bool? isAutoScalingForStorageEnabled, IEnumerable<string> peerDBIds, string peerDBId, bool? isLocalDataGuardEnabled, bool? isRemoteDataGuardEnabled, DisasterRecoveryType? localDisasterRecoveryType, AutonomousDatabaseStandbySummary localStandbyDB, int? failedDataRecoveryInSeconds, bool? isMtlsConnectionRequired, bool? isPreviewVersionWithServiceTermsAccepted, OracleLicenseModel? licenseModel, string ncharacterSet, string lifecycleDetails, OracleDatabaseProvisioningState? provisioningState, AutonomousDatabaseLifecycleState? lifecycleState, ScheduledOperationsType scheduledOperations, string privateEndpointIP, string privateEndpointLabel, Uri ociUri, ResourceIdentifier subnetId, ResourceIdentifier vnetId, DateTimeOffset? createdOn, DateTimeOffset? maintenanceBeginOn, DateTimeOffset? maintenanceEndOn, double? actualUsedDataStorageSizeInTbs, double? allocatedStorageSizeInTbs, OracleApexDetailsType apexDetails, IEnumerable<string> availableUpgradeVersions, AutonomousDatabaseConnectionStrings connectionStrings, AutonomousDatabaseConnectionUrls connectionUrls, DataSafeStatusType? dataSafeStatus, OracleDatabaseEditionType? databaseEdition, ResourceIdentifier autonomousDatabaseId, int? inMemoryAreaInGbs, DateTimeOffset? nextLongTermBackupCreatedOn, LongTermBackUpScheduleDetails longTermBackupSchedule, bool? isPreview, int? localAdgAutoFailoverMaxDataLossLimit, int? memoryPerOracleComputeUnitInGbs, AutonomousDatabaseModeType? openMode, OperationsInsightsStatusType? operationsInsightsStatus, AutonomousDatabasePermissionLevelType? permissionLevel, string privateEndpoint, IEnumerable<int> provisionableCpus, DataGuardRoleType? role, Uri serviceConsoleUri, Uri sqlWebDeveloperUri, IEnumerable<string> supportedRegionsToCloneTo, DateTimeOffset? dataGuardRoleChangedOn, DateTimeOffset? freeAutonomousDatabaseDeletedOn, string timeLocalDataGuardEnabled, DateTimeOffset? lastFailoverHappenedOn, DateTimeOffset? lastRefreshHappenedOn, DateTimeOffset? lastRefreshPointTimestamp, DateTimeOffset? lastSwitchoverHappenedOn, DateTimeOffset? freeAutonomousDatabaseStoppedOn, int? usedDataStorageSizeInGbs, int? usedDataStorageSizeInTbs, ResourceIdentifier ocid, int? backupRetentionPeriodInDays, IEnumerable<string> whitelistedIPs)
        {
            throw new NotSupportedException("This method is not supported. Use the new version of this factory method instead.");
        }

        /// <summary> Initializes a new instance of <see cref="Models.AutonomousDBVersionProperties"/>. </summary>
        /// <param name="version"> Supported Autonomous Db versions. </param>
        /// <param name="dbWorkload"> The Autonomous Database workload type. </param>
        /// <param name="isDefaultForFree"> True if this version of the Oracle Database software's default is free. </param>
        /// <param name="isDefaultForPaid"> True if this version of the Oracle Database software's default is paid. </param>
        /// <param name="isFreeTierEnabled"> True if this version of the Oracle Database software can be used for Always-Free Autonomous Databases. </param>
        /// <param name="isPaidEnabled"> True if this version of the Oracle Database software has payments enabled. </param>
        /// <returns> A new <see cref="Models.AutonomousDBVersionProperties"/> instance for mocking. </returns>
        public static AutonomousDBVersionProperties AutonomousDBVersionProperties(string version, AutonomousDatabaseWorkloadType? dbWorkload, bool? isDefaultForFree, bool? isDefaultForPaid, bool? isFreeTierEnabled, bool? isPaidEnabled)
        {
            throw new NotSupportedException("This method is not supported. Use the new version of this factory method instead.");
        }

        /// <summary> Initializes a new instance of <see cref="Models.CloudExadataInfrastructureProperties"/>. </summary>
        /// <param name="ocid"> Exadata infra ocid. </param>
        /// <param name="computeCount"> The number of compute servers for the cloud Exadata infrastructure. </param>
        /// <param name="storageCount"> The number of storage servers for the cloud Exadata infrastructure. </param>
        /// <param name="totalStorageSizeInGbs"> The total storage allocated to the cloud Exadata infrastructure resource, in gigabytes (GB). </param>
        /// <param name="availableStorageSizeInGbs"> The available storage can be allocated to the cloud Exadata infrastructure resource, in gigabytes (GB). </param>
        /// <param name="createdOn"> The date and time the cloud Exadata infrastructure resource was created. </param>
        /// <param name="lifecycleDetails"> Additional information about the current lifecycle state. </param>
        /// <param name="maintenanceWindow"> maintenanceWindow property. </param>
        /// <param name="estimatedPatchingTime"> The estimated total time required in minutes for all patching operations (database server, storage server, and network switch patching). </param>
        /// <param name="customerContacts"> The list of customer email addresses that receive information from Oracle about the specified OCI Database service resource. Oracle uses these email addresses to send notifications about planned and unplanned software maintenance updates, information about system hardware, and other information needed by administrators. Up to 10 email addresses can be added to the customer contacts for a cloud Exadata infrastructure instance. </param>
        /// <param name="provisioningState"> CloudExadataInfrastructure provisioning state. </param>
        /// <param name="lifecycleState"> CloudExadataInfrastructure lifecycle state. </param>
        /// <param name="shape"> The model name of the cloud Exadata infrastructure resource. </param>
        /// <param name="ociUri"> HTTPS link to OCI resources exposed to Azure Customer via Azure Interface. </param>
        /// <param name="cpuCount"> The total number of CPU cores allocated. </param>
        /// <param name="maxCpuCount"> The total number of CPU cores available. </param>
        /// <param name="memorySizeInGbs"> The memory allocated in GBs. </param>
        /// <param name="maxMemoryInGbs"> The total memory available in GBs. </param>
        /// <param name="dbNodeStorageSizeInGbs"> The local node storage to be allocated in GBs. </param>
        /// <param name="maxDBNodeStorageSizeInGbs"> The total local node storage available in GBs. </param>
        /// <param name="dataStorageSizeInTbs"> The quantity of data in the database, in terabytes. </param>
        /// <param name="maxDataStorageInTbs"> The total available DATA disk group size. </param>
        /// <param name="dbServerVersion"> The software version of the database servers (dom0) in the Exadata infrastructure. </param>
        /// <param name="storageServerVersion"> The software version of the storage servers (cells) in the Exadata infrastructure. </param>
        /// <param name="activatedStorageCount"> The requested number of additional storage servers activated for the Exadata infrastructure. </param>
        /// <param name="additionalStorageCount"> The requested number of additional storage servers for the Exadata infrastructure. </param>
        /// <param name="displayName"> The name for the Exadata infrastructure. </param>
        /// <param name="lastMaintenanceRunId"> The OCID of the last maintenance run. </param>
        /// <param name="nextMaintenanceRunId"> The OCID of the next maintenance run. </param>
        /// <param name="monthlyDBServerVersion"> Monthly Db Server version. </param>
        /// <param name="monthlyStorageServerVersion"> Monthly Storage Server version. </param>
        /// <returns> A new <see cref="Models.CloudExadataInfrastructureProperties"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CloudExadataInfrastructureProperties CloudExadataInfrastructureProperties(ResourceIdentifier ocid, int? computeCount, int? storageCount, int? totalStorageSizeInGbs, int? availableStorageSizeInGbs, DateTimeOffset? createdOn, string lifecycleDetails, OracleDatabaseMaintenanceWindow maintenanceWindow, EstimatedPatchingTime estimatedPatchingTime, IEnumerable<OracleCustomerContact> customerContacts, OracleDatabaseProvisioningState? provisioningState, CloudExadataInfrastructureLifecycleState? lifecycleState, string shape, Uri ociUri, int? cpuCount, int? maxCpuCount, int? memorySizeInGbs, int? maxMemoryInGbs, int? dbNodeStorageSizeInGbs, int? maxDBNodeStorageSizeInGbs, double? dataStorageSizeInTbs, double? maxDataStorageInTbs, string dbServerVersion, string storageServerVersion, int? activatedStorageCount, int? additionalStorageCount, string displayName, ResourceIdentifier lastMaintenanceRunId, ResourceIdentifier nextMaintenanceRunId, string monthlyDBServerVersion, string monthlyStorageServerVersion)
        {
            throw new NotSupportedException("This method is not supported. Use the new version of this factory method instead.");
        }

        /// <summary> Initializes a new instance of <see cref="Models.CloudVmClusterDBNodeProperties"/>. </summary>
        /// <param name="ocid"> DbNode OCID. </param>
        /// <param name="additionalDetails"> Additional information about the planned maintenance. </param>
        /// <param name="backupIPId"> The OCID of the backup IP address associated with the database node. </param>
        /// <param name="backupVnic2Id"> The OCID of the second backup VNIC. </param>
        /// <param name="backupVnicId"> The OCID of the backup VNIC. </param>
        /// <param name="cpuCoreCount"> The number of CPU cores enabled on the Db node. </param>
        /// <param name="dbNodeStorageSizeInGbs"> The allocated local node storage in GBs on the Db node. </param>
        /// <param name="dbServerId"> The OCID of the Exacc Db server associated with the database node. </param>
        /// <param name="dbSystemId"> The OCID of the DB system. </param>
        /// <param name="faultDomain"> The name of the Fault Domain the instance is contained in. </param>
        /// <param name="hostIPId"> The OCID of the host IP address associated with the database node. </param>
        /// <param name="hostname"> The host name for the database node. </param>
        /// <param name="lifecycleState"> The current state of the database node. </param>
        /// <param name="lifecycleDetails"> Lifecycle details of Db Node. </param>
        /// <param name="maintenanceType"> The type of database node maintenance. </param>
        /// <param name="memorySizeInGbs"> The allocated memory in GBs on the Db node. </param>
        /// <param name="softwareStorageSizeInGb"> The size (in GB) of the block storage volume allocation for the DB system. This attribute applies only for virtual machine DB systems. </param>
        /// <param name="timeCreated"> The date and time that the database node was created. </param>
        /// <param name="timeMaintenanceWindowEnd"> End date and time of maintenance window. </param>
        /// <param name="timeMaintenanceWindowStart"> Start date and time of maintenance window. </param>
        /// <param name="vnic2Id"> The OCID of the second VNIC. </param>
        /// <param name="vnicId"> The OCID of the VNIC. </param>
        /// <param name="provisioningState"> Azure resource provisioning state. </param>
        /// <returns> A new <see cref="Models.CloudVmClusterDBNodeProperties"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CloudVmClusterDBNodeProperties CloudVmClusterDBNodeProperties(ResourceIdentifier ocid, string additionalDetails, ResourceIdentifier backupIPId, ResourceIdentifier backupVnic2Id, ResourceIdentifier backupVnicId, int? cpuCoreCount, int? dbNodeStorageSizeInGbs, ResourceIdentifier dbServerId, ResourceIdentifier dbSystemId, string faultDomain, ResourceIdentifier hostIPId, string hostname, DBNodeProvisioningState? lifecycleState, string lifecycleDetails, DBNodeMaintenanceType? maintenanceType, int? memorySizeInGbs, int? softwareStorageSizeInGb, DateTimeOffset? timeCreated, DateTimeOffset? timeMaintenanceWindowEnd, DateTimeOffset? timeMaintenanceWindowStart, ResourceIdentifier vnic2Id, ResourceIdentifier vnicId, OracleDatabaseResourceProvisioningState? provisioningState)
        {
            throw new NotSupportedException("This method is not supported. Use the new version of this factory method instead.");
        }

        /// <summary> Initializes a new instance of <see cref="Models.CloudVmClusterProperties"/>. </summary>
        /// <param name="ocid"> Cloud VM Cluster ocid. </param>
        /// <param name="listenerPort"> The port number configured for the listener on the cloud VM cluster. </param>
        /// <param name="nodeCount"> The number of nodes in the cloud VM cluster. </param>
        /// <param name="storageSizeInGbs"> The data disk group size to be allocated in GBs per VM. </param>
        /// <param name="dataStorageSizeInTbs"> The data disk group size to be allocated in TBs. </param>
        /// <param name="dbNodeStorageSizeInGbs"> The local node storage to be allocated in GBs. </param>
        /// <param name="memorySizeInGbs"> The memory to be allocated in GBs. </param>
        /// <param name="createdOn"> The date and time that the cloud VM cluster was created. </param>
        /// <param name="lifecycleDetails"> Additional information about the current lifecycle state. </param>
        /// <param name="timeZone"> The time zone of the cloud VM cluster. For details, see [Exadata Infrastructure Time Zones](/Content/Database/References/timezones.htm). </param>
        /// <param name="zoneId"> The OCID of the zone the cloud VM cluster is associated with. </param>
        /// <param name="hostname"> The hostname for the cloud VM cluster. </param>
        /// <param name="domain"> The domain name for the cloud VM cluster. </param>
        /// <param name="cpuCoreCount"> The number of CPU cores enabled on the cloud VM cluster. </param>
        /// <param name="ocpuCount"> The number of OCPU cores to enable on the cloud VM cluster. Only 1 decimal place is allowed for the fractional part. </param>
        /// <param name="clusterName"> The cluster name for cloud VM cluster. The cluster name must begin with an alphabetic character, and may contain hyphens (-). Underscores (_) are not permitted. The cluster name can be no longer than 11 characters and is not case sensitive. </param>
        /// <param name="dataStoragePercentage"> The percentage assigned to DATA storage (user data and database files). The remaining percentage is assigned to RECO storage (database redo logs, archive logs, and recovery manager backups). Accepted values are 35, 40, 60 and 80. The default is 80 percent assigned to DATA storage. See [Storage Configuration](/Content/Database/Concepts/exaoverview.htm#Exadata) in the Exadata documentation for details on the impact of the configuration settings on storage. </param>
        /// <param name="isLocalBackupEnabled"> If true, database backup on local Exadata storage is configured for the cloud VM cluster. If false, database backup on local Exadata storage is not available in the cloud VM cluster. </param>
        /// <param name="cloudExadataInfrastructureId"> Cloud Exadata Infrastructure ID. </param>
        /// <param name="isSparseDiskgroupEnabled"> If true, sparse disk group is configured for the cloud VM cluster. If false, sparse disk group is not created. </param>
        /// <param name="systemVersion"> Operating system version of the image. </param>
        /// <param name="sshPublicKeys"> The public key portion of one or more key pairs used for SSH access to the cloud VM cluster. </param>
        /// <param name="licenseModel"> The Oracle license model that applies to the cloud VM cluster. The default is LICENSE_INCLUDED. </param>
        /// <param name="diskRedundancy"> The type of redundancy configured for the cloud Vm cluster. NORMAL is 2-way redundancy. HIGH is 3-way redundancy. </param>
        /// <param name="scanIPIds"> The Single Client Access Name (SCAN) IP addresses associated with the cloud VM cluster. SCAN IP addresses are typically used for load balancing and are not assigned to any interface. Oracle Clusterware directs the requests to the appropriate nodes in the cluster. **Note:** For a single-node DB system, this list is empty. </param>
        /// <param name="vipIds"> The virtual IP (VIP) addresses associated with the cloud VM cluster. The Cluster Ready Services (CRS) creates and maintains one VIP address for each node in the Exadata Cloud Service instance to enable failover. If one node fails, the VIP is reassigned to another active node in the cluster. **Note:** For a single-node DB system, this list is empty. </param>
        /// <param name="scanDnsName"> The FQDN of the DNS record for the SCAN IP addresses that are associated with the cloud VM cluster. </param>
        /// <param name="scanListenerPortTcp"> The TCP Single Client Access Name (SCAN) port. The default port is 1521. </param>
        /// <param name="scanListenerPortTcpSsl"> The TCPS Single Client Access Name (SCAN) port. The default port is 2484. </param>
        /// <param name="scanDnsRecordId"> The OCID of the DNS record for the SCAN IP addresses that are associated with the cloud VM cluster. </param>
        /// <param name="shape"> The model name of the Exadata hardware running the cloud VM cluster. </param>
        /// <param name="provisioningState"> CloudVmCluster provisioning state. </param>
        /// <param name="lifecycleState"> CloudVmCluster lifecycle state. </param>
        /// <param name="vnetId"> VNET for network connectivity. </param>
        /// <param name="giVersion"> Oracle Grid Infrastructure (GI) software version. </param>
        /// <param name="ociUri"> HTTPS link to OCI resources exposed to Azure Customer via Azure Interface. </param>
        /// <param name="nsgUri"> HTTPS link to OCI Network Security Group exposed to Azure Customer via the Azure Interface. </param>
        /// <param name="subnetId"> Client subnet. </param>
        /// <param name="backupSubnetCidr"> Client OCI backup subnet CIDR, default is 192.168.252.0/22. </param>
        /// <param name="nsgCidrs"> CIDR blocks for additional NSG ingress rules. The VNET CIDRs used to provision the VM Cluster will be added by default. </param>
        /// <param name="dataCollectionOptions"> Indicates user preferences for the various diagnostic collection options for the VM cluster/Cloud VM cluster/VMBM DBCS. </param>
        /// <param name="displayName"> Display Name. </param>
        /// <param name="computeNodes"> The list of compute servers to be added to the cloud VM cluster. </param>
        /// <param name="iormConfigCache"> iormConfigCache details for cloud VM cluster. </param>
        /// <param name="lastUpdateHistoryEntryId"> The OCID of the last maintenance update history entry. </param>
        /// <param name="dbServers"> The list of DB servers. </param>
        /// <param name="compartmentId"> Cluster compartmentId. </param>
        /// <param name="subnetOcid"> Cluster subnet ocid. </param>
        /// <returns> A new <see cref="Models.CloudVmClusterProperties"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CloudVmClusterProperties CloudVmClusterProperties(ResourceIdentifier ocid, long? listenerPort, int? nodeCount, int? storageSizeInGbs, double? dataStorageSizeInTbs, int? dbNodeStorageSizeInGbs, int? memorySizeInGbs, DateTimeOffset? createdOn, string lifecycleDetails, string timeZone, ResourceIdentifier zoneId, string hostname, string domain, int cpuCoreCount, float? ocpuCount, string clusterName, int? dataStoragePercentage, bool? isLocalBackupEnabled, ResourceIdentifier cloudExadataInfrastructureId, bool? isSparseDiskgroupEnabled, string systemVersion, IEnumerable<string> sshPublicKeys, OracleLicenseModel? licenseModel, CloudVmClusterDiskRedundancy? diskRedundancy, IEnumerable<string> scanIPIds, IEnumerable<string> vipIds, string scanDnsName, int? scanListenerPortTcp, int? scanListenerPortTcpSsl, ResourceIdentifier scanDnsRecordId, string shape, OracleDatabaseProvisioningState? provisioningState, CloudVmClusterLifecycleState? lifecycleState, ResourceIdentifier vnetId, string giVersion, Uri ociUri, Uri nsgUri, ResourceIdentifier subnetId, string backupSubnetCidr, IEnumerable<CloudVmClusterNsgCidr> nsgCidrs, DiagnosticCollectionConfig dataCollectionOptions, string displayName, IEnumerable<ResourceIdentifier> computeNodes, ExadataIormConfig iormConfigCache, ResourceIdentifier lastUpdateHistoryEntryId, IEnumerable<ResourceIdentifier> dbServers, ResourceIdentifier compartmentId, ResourceIdentifier subnetOcid)
        {
            throw new NotSupportedException("This method is not supported. Use the new version of this factory method instead.");
        }

        /// <summary> Initializes a new instance of <see cref="Models.CloudVmClusterVirtualNetworkAddressProperties"/>. </summary>
        /// <param name="ipAddress"> Virtual network Address address. </param>
        /// <param name="vmOcid"> Virtual Machine OCID. </param>
        /// <param name="ocid"> Application VIP OCID. </param>
        /// <param name="domain"> Virtual network address fully qualified domain name. </param>
        /// <param name="lifecycleDetails"> Additional information about the current lifecycle state of the application virtual IP (VIP) address. </param>
        /// <param name="provisioningState"> Azure resource provisioning state. </param>
        /// <param name="lifecycleState"> virtual network address lifecycle state. </param>
        /// <param name="assignedOn"> The date and time when the create operation for the application virtual IP (VIP) address completed. </param>
        /// <returns> A new <see cref="Models.CloudVmClusterVirtualNetworkAddressProperties"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CloudVmClusterVirtualNetworkAddressProperties CloudVmClusterVirtualNetworkAddressProperties(string ipAddress, ResourceIdentifier vmOcid, ResourceIdentifier ocid, string domain, string lifecycleDetails, OracleDatabaseProvisioningState? provisioningState, VirtualNetworkAddressLifecycleState? lifecycleState, DateTimeOffset? assignedOn)
        {
            throw new NotSupportedException("This method is not supported. Use the new version of this factory method instead.");
        }

        /// <summary> Initializes a new instance of <see cref="Models.OracleDBServerProperties"/>. </summary>
        /// <param name="ocid"> Db server name. </param>
        /// <param name="displayName"> The name for the Db Server. </param>
        /// <param name="compartmentId"> The OCID of the compartment. </param>
        /// <param name="exadataInfrastructureId"> The OCID of the Exadata infrastructure. </param>
        /// <param name="cpuCoreCount"> The number of CPU cores enabled on the Db server. </param>
        /// <param name="dbServerPatchingDetails"> dbServerPatching details of the Db server. </param>
        /// <param name="maxMemoryInGbs"> The total memory available in GBs. </param>
        /// <param name="dbNodeStorageSizeInGbs"> The allocated local node storage in GBs on the Db server. </param>
        /// <param name="vmClusterIds"> The OCID of the VM Clusters associated with the Db server. </param>
        /// <param name="dbNodeIds"> The OCID of the Db nodes associated with the Db server. </param>
        /// <param name="lifecycleDetails"> Lifecycle details of dbServer. </param>
        /// <param name="lifecycleState"> DbServer provisioning state. </param>
        /// <param name="maxCpuCount"> The total number of CPU cores available. </param>
        /// <param name="autonomousVmClusterIds"> The list of OCIDs of the Autonomous VM Clusters associated with the Db server. </param>
        /// <param name="autonomousVirtualMachineIds"> The list of OCIDs of the Autonomous Virtual Machines associated with the Db server. </param>
        /// <param name="maxDBNodeStorageInGbs"> The total max dbNode storage in GBs. </param>
        /// <param name="memorySizeInGbs"> The total memory size in GBs. </param>
        /// <param name="shape"> The shape of the Db server. The shape determines the amount of CPU, storage, and memory resources available. </param>
        /// <param name="createdOn"> The date and time that the Db Server was created. </param>
        /// <param name="provisioningState"> Azure resource provisioning state. </param>
        /// <returns> A new <see cref="Models.OracleDBServerProperties"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OracleDBServerProperties OracleDBServerProperties(ResourceIdentifier ocid, string displayName, ResourceIdentifier compartmentId, ResourceIdentifier exadataInfrastructureId, int? cpuCoreCount, DBServerPatchingDetails dbServerPatchingDetails, int? maxMemoryInGbs, int? dbNodeStorageSizeInGbs, IEnumerable<ResourceIdentifier> vmClusterIds, IEnumerable<ResourceIdentifier> dbNodeIds, string lifecycleDetails, DBServerProvisioningState? lifecycleState, int? maxCpuCount, IEnumerable<ResourceIdentifier> autonomousVmClusterIds, IEnumerable<ResourceIdentifier> autonomousVirtualMachineIds, int? maxDBNodeStorageInGbs, int? memorySizeInGbs, string shape, DateTimeOffset? createdOn, OracleDatabaseResourceProvisioningState? provisioningState)
        {
            throw new NotSupportedException("This method is not supported. Use the new version of this factory method instead.");
        }

        /// <summary> Initializes a new instance of <see cref="Models.OracleDBSystemShapeProperties"/>. </summary>
        /// <param name="shapeFamily"> The family of the shape used for the DB system. </param>
        /// <param name="availableCoreCount"> The maximum number of CPU cores that can be enabled on the DB system for this shape. </param>
        /// <param name="minimumCoreCount"> The minimum number of CPU cores that can be enabled on the DB system for this shape. </param>
        /// <param name="runtimeMinimumCoreCount"> The runtime minimum number of CPU cores that can be enabled on the DB system for this shape. </param>
        /// <param name="coreCountIncrement"> The discrete number by which the CPU core count for this shape can be increased or decreased. </param>
        /// <param name="minStorageCount"> The minimum number of Exadata storage servers available for the Exadata infrastructure. </param>
        /// <param name="maxStorageCount"> The maximum number of Exadata storage servers available for the Exadata infrastructure. </param>
        /// <param name="availableDataStoragePerServerInTbs"> The maximum data storage available per storage server for this shape. Only applicable to ExaCC Elastic shapes. </param>
        /// <param name="availableMemoryPerNodeInGbs"> The maximum memory available per database node for this shape. Only applicable to ExaCC Elastic shapes. </param>
        /// <param name="availableDBNodePerNodeInGbs"> The maximum Db Node storage available per database node for this shape. Only applicable to ExaCC Elastic shapes. </param>
        /// <param name="minCoreCountPerNode"> The minimum number of CPU cores that can be enabled per node for this shape. </param>
        /// <param name="availableMemoryInGbs"> The maximum memory that can be enabled for this shape. </param>
        /// <param name="minMemoryPerNodeInGbs"> The minimum memory that need be allocated per node for this shape. </param>
        /// <param name="availableDBNodeStorageInGbs"> The maximum Db Node storage that can be enabled for this shape. </param>
        /// <param name="minDBNodeStoragePerNodeInGbs"> The minimum Db Node storage that need be allocated per node for this shape. </param>
        /// <param name="availableDataStorageInTbs"> The maximum DATA storage that can be enabled for this shape. </param>
        /// <param name="minDataStorageInTbs"> The minimum data storage that need be allocated for this shape. </param>
        /// <param name="minimumNodeCount"> The minimum number of database nodes available for this shape. </param>
        /// <param name="maximumNodeCount"> The maximum number of database nodes available for this shape. </param>
        /// <param name="availableCoreCountPerNode"> The maximum number of CPU cores per database node that can be enabled for this shape. Only applicable to the flex Exadata shape and ExaCC Elastic shapes. </param>
        /// <returns> A new <see cref="Models.OracleDBSystemShapeProperties"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OracleDBSystemShapeProperties OracleDBSystemShapeProperties(string shapeFamily, int availableCoreCount, int? minimumCoreCount, int? runtimeMinimumCoreCount, int? coreCountIncrement, int? minStorageCount, int? maxStorageCount, double? availableDataStoragePerServerInTbs, int? availableMemoryPerNodeInGbs, int? availableDBNodePerNodeInGbs, int? minCoreCountPerNode, int? availableMemoryInGbs, int? minMemoryPerNodeInGbs, int? availableDBNodeStorageInGbs, int? minDBNodeStoragePerNodeInGbs, int? availableDataStorageInTbs, int? minDataStorageInTbs, int? minimumNodeCount, int? maximumNodeCount, int? availableCoreCountPerNode)
        {
            throw new NotSupportedException("This method is not supported. Use the new version of this factory method instead.");
        }

        /// <summary> Initializes a new instance of <see cref="Models.OracleDnsPrivateViewProperties"/>. </summary>
        /// <param name="ocid"> The OCID of the view. </param>
        /// <param name="displayName"> The display name of the view resource. </param>
        /// <param name="isProtected"> A Boolean flag indicating whether or not parts of the resource are unable to be explicitly managed. </param>
        /// <param name="lifecycleState"> Views lifecycleState. </param>
        /// <param name="self"> The canonical absolute URL of the resource. </param>
        /// <param name="createdOn"> views timeCreated. </param>
        /// <param name="updatedOn"> views timeCreated. </param>
        /// <param name="provisioningState"> Azure resource provisioning state. </param>
        /// <returns> A new <see cref="Models.OracleDnsPrivateViewProperties"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OracleDnsPrivateViewProperties OracleDnsPrivateViewProperties(ResourceIdentifier ocid, string displayName, bool isProtected, DnsPrivateViewsLifecycleState? lifecycleState, string self, DateTimeOffset createdOn, DateTimeOffset updatedOn, OracleDatabaseResourceProvisioningState? provisioningState)
        {
            throw new NotSupportedException("This method is not supported. Use the new version of this factory method instead.");
        }

        /// <summary> Initializes a new instance of <see cref="Models.OracleDnsPrivateZoneProperties"/>. </summary>
        /// <param name="ocid"> The OCID of the Zone. </param>
        /// <param name="isProtected"> A Boolean flag indicating whether or not parts of the resource are unable to be explicitly managed. </param>
        /// <param name="lifecycleState"> Zones lifecycleState. </param>
        /// <param name="self"> The canonical absolute URL of the resource. </param>
        /// <param name="serial"> The current serial of the zone. As seen in the zone's SOA record. </param>
        /// <param name="version"> Version is the never-repeating, totally-orderable, version of the zone, from which the serial field of the zone's SOA record is derived. </param>
        /// <param name="viewId"> The OCID of the private view containing the zone. This value will be null for zones in the global DNS, which are publicly resolvable and not part of a private view. </param>
        /// <param name="zoneType"> The type of the zone. Must be either PRIMARY or SECONDARY. SECONDARY is only supported for GLOBAL zones. </param>
        /// <param name="createdOn"> Zones timeCreated. </param>
        /// <param name="provisioningState"> Azure resource provisioning state. </param>
        /// <returns> A new <see cref="Models.OracleDnsPrivateZoneProperties"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OracleDnsPrivateZoneProperties OracleDnsPrivateZoneProperties(ResourceIdentifier ocid, bool isProtected, DnsPrivateZonesLifecycleState? lifecycleState, string self, int serial, string version, ResourceIdentifier viewId, OracleDnsPrivateZoneType zoneType, DateTimeOffset createdOn, OracleDatabaseResourceProvisioningState? provisioningState)
        {
            throw new NotSupportedException("This method is not supported. Use the new version of this factory method instead.");
        }

        /// <summary> Initializes a new instance of <see cref="Models.OracleSubscriptionProperties"/>. </summary>
        /// <param name="provisioningState"> OracleSubscriptionProvisioningState provisioning state. </param>
        /// <param name="saasSubscriptionId"> SAAS subscription ID generated by Marketplace. </param>
        /// <param name="cloudAccountId"> Cloud Account Id. </param>
        /// <param name="cloudAccountState"> Cloud Account provisioning state. </param>
        /// <param name="termUnit"> Term Unit. P1Y, P3Y, etc, see Durations https://en.wikipedia.org/wiki/ISO_8601. </param>
        /// <param name="productCode"> Product code for the term unit. </param>
        /// <param name="intent"> Intent for the update operation. </param>
        /// <returns> A new <see cref="Models.OracleSubscriptionProperties"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OracleSubscriptionProperties OracleSubscriptionProperties(OracleSubscriptionProvisioningState? provisioningState, string saasSubscriptionId, ResourceIdentifier cloudAccountId, CloudAccountProvisioningState? cloudAccountState, string termUnit, string productCode, OracleSubscriptionUpdateIntent? intent)
        {
            throw new NotSupportedException("This method is not supported. Use the new version of this factory method instead.");
        }

        /// <summary> Initializes a new instance of <see cref="Models.PrivateIPAddressResult"/>. </summary>
        /// <param name="displayName"> PrivateIpAddresses displayName. </param>
        /// <param name="hostnameLabel"> PrivateIpAddresses hostnameLabel. </param>
        /// <param name="ocid"> PrivateIpAddresses Id. </param>
        /// <param name="ipAddress"> PrivateIpAddresses ipAddress. </param>
        /// <param name="subnetId"> PrivateIpAddresses subnetId. </param>
        /// <returns> A new <see cref="Models.PrivateIPAddressResult"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PrivateIPAddressResult PrivateIPAddressResult(string displayName, string hostnameLabel, ResourceIdentifier ocid, string ipAddress, ResourceIdentifier subnetId)
        {
            throw new NotSupportedException("This method is not supported. Use the new version of this factory method instead.");
        }
    }
}
