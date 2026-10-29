// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("AutonomousDatabaseBaseProperties", typeof(string), typeof(string), typeof(AutonomousMaintenanceScheduleType?), typeof(string), typeof(float?), typeof(OracleDatabaseComputeModel?), typeof(int?), typeof(IEnumerable<OracleCustomerContact>), typeof(int?), typeof(int?), typeof(string), typeof(AutonomousDatabaseWorkloadType?), typeof(string), typeof(bool?), typeof(bool?), typeof(IEnumerable<string>), typeof(string), typeof(bool?), typeof(bool?), typeof(DisasterRecoveryType?), typeof(DateTimeOffset?), typeof(DisasterRecoveryConfigurationDetails), typeof(AutonomousDatabaseStandbySummary), typeof(int?), typeof(bool?), typeof(bool?), typeof(OracleLicenseModel?), typeof(string), typeof(string), typeof(OracleDatabaseProvisioningState?), typeof(AutonomousDatabaseLifecycleState?), typeof(IEnumerable<ScheduledOperationsType>), typeof(string), typeof(string), typeof(Uri), typeof(ResourceIdentifier), typeof(ResourceIdentifier), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(double?), typeof(double?), typeof(OracleApexDetailsType), typeof(IEnumerable<string>), typeof(AutonomousDatabaseConnectionStrings), typeof(AutonomousDatabaseConnectionUrls), typeof(DataSafeStatusType?), typeof(OracleDatabaseEditionType?), typeof(ResourceIdentifier), typeof(int?), typeof(DateTimeOffset?), typeof(LongTermBackUpScheduleDetails), typeof(bool?), typeof(int?), typeof(int?), typeof(AutonomousDatabaseModeType?), typeof(OperationsInsightsStatusType?), typeof(AutonomousDatabasePermissionLevelType?), typeof(string), typeof(IEnumerable<int>), typeof(DataGuardRoleType?), typeof(Uri), typeof(Uri), typeof(IEnumerable<string>), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(int?), typeof(int?), typeof(string), typeof(int?), typeof(IEnumerable<string>))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("OracleDBSystemBaseProperties", typeof(string), typeof(OracleDatabaseProvisioningState?), typeof(Uri), typeof(ResourceIdentifier), typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(int?), typeof(int?), typeof(StorageManagementType?), typeof(DBSystemDiskRedundancyType?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(OracleLicenseModel?), typeof(string), typeof(DBSystemLifecycleState?), typeof(int?), typeof(int?), typeof(int?), typeof(string), typeof(IEnumerable<string>), typeof(string), typeof(IEnumerable<string>), typeof(StorageVolumePerformanceMode?), typeof(string), typeof(string), typeof(OracleDatabaseComputeModel?), typeof(int?))]
    public static partial class ArmOracleDatabaseModelFactory
    {
        /// <summary>
        /// Autonomous Database base resource model.
        /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="Models.AutonomousDatabaseProperties"/>, <see cref="Models.AutonomousDatabaseCloneProperties"/>, <see cref="Models.AutonomousDatabaseCrossRegionDisasterRecoveryProperties"/>, and <see cref="Models.AutonomousDatabaseFromBackupTimestampProperties"/>.
        /// </summary>
        /// <param name="adminPassword"> Admin password. </param>
        /// <param name="dataBaseType"></param>
        /// <param name="autonomousMaintenanceScheduleType"> The maintenance schedule type of the Autonomous Database Serverless. </param>
        /// <param name="characterSet"> The character set for the autonomous database. </param>
        /// <param name="computeCount"> The compute amount (CPUs) available to the database. </param>
        /// <param name="databaseComputeModel"> The compute model of the Autonomous Database. </param>
        /// <param name="cpuCoreCount"> The number of CPU cores to be made available to the database. </param>
        /// <param name="customerContacts"> Customer Contacts. </param>
        /// <param name="dataStorageSizeInTbs"> The quantity of data in the database, in terabytes. </param>
        /// <param name="dataStorageSizeInGbs"> The size, in gigabytes, of the data volume that will be created and attached to the database. </param>
        /// <param name="dbVersion"> A valid Oracle Database version for Autonomous Database. </param>
        /// <param name="dbWorkload"> The Autonomous Database workload type. </param>
        /// <param name="displayName"> The user-friendly name for the Autonomous Database. </param>
        /// <param name="isAutoScalingEnabled"> Indicates if auto scaling is enabled for the Autonomous Database CPU core count. </param>
        /// <param name="isAutoScalingForStorageEnabled"> Indicates if auto scaling is enabled for the Autonomous Database storage. </param>
        /// <param name="peerDBIds"> The list of Azure resource IDs of standby databases located in Autonomous Data Guard remote regions that are associated with the source database. Note that for Autonomous Database Serverless instances, standby databases located in the same region as the source primary database do not have Azure IDs. </param>
        /// <param name="peerDBId"> The Azure resource ID of the Disaster Recovery peer database, which is located in a different region from the current peer database. </param>
        /// <param name="isLocalDataGuardEnabled"> Indicates whether the Autonomous Database has local or called in-region Data Guard enabled. </param>
        /// <param name="isRemoteDataGuardEnabled"> Indicates whether the Autonomous Database has Cross Region Data Guard enabled. </param>
        /// <param name="localDisasterRecoveryType"> Indicates the local disaster recovery (DR) type of the Autonomous Database Serverless instance.Autonomous Data Guard (ADG) DR type provides business critical DR with a faster recovery time objective (RTO) during failover or switchover.Backup-based DR type provides lower cost DR with a slower RTO during failover or switchover. </param>
        /// <param name="disasterRecoveryRoleChangedOn"> The date and time the Disaster Recovery role was switched for the standby Autonomous Database. </param>
        /// <param name="remoteDisasterRecoveryConfiguration"> Indicates remote disaster recovery configuration. </param>
        /// <param name="localStandbyDB"> Local Autonomous Disaster Recovery standby database details. </param>
        /// <param name="failedDataRecoveryInSeconds"> Indicates the number of seconds of data loss for a Data Guard failover. </param>
        /// <param name="isMtlsConnectionRequired"> Specifies if the Autonomous Database requires mTLS connections. </param>
        /// <param name="isPreviewVersionWithServiceTermsAccepted"> Specifies if the Autonomous Database preview version is being provisioned. </param>
        /// <param name="licenseModel"> The Oracle license model that applies to the Oracle Autonomous Database. The default is LICENSE_INCLUDED. </param>
        /// <param name="ncharacterSet"> The character set for the Autonomous Database. </param>
        /// <param name="lifecycleDetails"> Additional information about the current lifecycle state. </param>
        /// <param name="provisioningState"> Azure resource provisioning state. </param>
        /// <param name="lifecycleState"> Views lifecycleState. </param>
        /// <param name="scheduledOperationsList"> The list of scheduled operations. </param>
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
        /// <param name="connectionUrls"> The URLs for accessing Oracle Application Express (APEX) and SQL Developer Web with a browser from a Compute instance within your VCN or that has a direct connection to your VCN. . </param>
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
        /// <param name="databaseOcid"> Database ocid. </param>
        /// <param name="backupRetentionPeriodInDays"> Retention period, in days, for long-term backups. </param>
        /// <param name="whitelistedIPs"> The client IP access control list (ACL). This is an array of CIDR notations and/or IP addresses. Values should be separate strings, separated by commas. Example: ['1.1.1.1','1.1.1.0/24','1.1.2.25']. </param>
        /// <returns> A new <see cref="Models.AutonomousDatabaseBaseProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AutonomousDatabaseBaseProperties AutonomousDatabaseBaseProperties(string adminPassword = default, string dataBaseType = default, AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType = default, string characterSet = default, float? computeCount = default, OracleDatabaseComputeModel? databaseComputeModel = default, int? cpuCoreCount = default, IEnumerable<OracleCustomerContact> customerContacts = default, int? dataStorageSizeInTbs = default, int? dataStorageSizeInGbs = default, string dbVersion = default, AutonomousDatabaseWorkloadType? dbWorkload = default, string displayName = default, bool? isAutoScalingEnabled = default, bool? isAutoScalingForStorageEnabled = default, IEnumerable<string> peerDBIds = default, string peerDBId = default, bool? isLocalDataGuardEnabled = default, bool? isRemoteDataGuardEnabled = default, DisasterRecoveryType? localDisasterRecoveryType = default, DateTimeOffset? disasterRecoveryRoleChangedOn = default, DisasterRecoveryConfigurationDetails remoteDisasterRecoveryConfiguration = default, AutonomousDatabaseStandbySummary localStandbyDB = default, int? failedDataRecoveryInSeconds = default, bool? isMtlsConnectionRequired = default, bool? isPreviewVersionWithServiceTermsAccepted = default, OracleLicenseModel? licenseModel = default, string ncharacterSet = default, string lifecycleDetails = default, OracleDatabaseProvisioningState? provisioningState = default, AutonomousDatabaseLifecycleState? lifecycleState = default, IEnumerable<ScheduledOperationsType> scheduledOperationsList = default, string privateEndpointIP = default, string privateEndpointLabel = default, Uri ociUri = default, ResourceIdentifier subnetId = default, ResourceIdentifier vnetId = default, DateTimeOffset? createdOn = default, DateTimeOffset? maintenanceBeginOn = default, DateTimeOffset? maintenanceEndOn = default, double? actualUsedDataStorageSizeInTbs = default, double? allocatedStorageSizeInTbs = default, OracleApexDetailsType apexDetails = default, IEnumerable<string> availableUpgradeVersions = default, AutonomousDatabaseConnectionStrings connectionStrings = default, AutonomousDatabaseConnectionUrls connectionUrls = default, DataSafeStatusType? dataSafeStatus = default, OracleDatabaseEditionType? databaseEdition = default, ResourceIdentifier autonomousDatabaseId = default, int? inMemoryAreaInGbs = default, DateTimeOffset? nextLongTermBackupCreatedOn = default, LongTermBackUpScheduleDetails longTermBackupSchedule = default, bool? isPreview = default, int? localAdgAutoFailoverMaxDataLossLimit = default, int? memoryPerOracleComputeUnitInGbs = default, AutonomousDatabaseModeType? openMode = default, OperationsInsightsStatusType? operationsInsightsStatus = default, AutonomousDatabasePermissionLevelType? permissionLevel = default, string privateEndpoint = default, IEnumerable<int> provisionableCpus = default, DataGuardRoleType? role = default, Uri serviceConsoleUri = default, Uri sqlWebDeveloperUri = default, IEnumerable<string> supportedRegionsToCloneTo = default, DateTimeOffset? dataGuardRoleChangedOn = default, DateTimeOffset? freeAutonomousDatabaseDeletedOn = default, string timeLocalDataGuardEnabled = default, DateTimeOffset? lastFailoverHappenedOn = default, DateTimeOffset? lastRefreshHappenedOn = default, DateTimeOffset? lastRefreshPointTimestamp = default, DateTimeOffset? lastSwitchoverHappenedOn = default, DateTimeOffset? freeAutonomousDatabaseStoppedOn = default, int? usedDataStorageSizeInGbs = default, int? usedDataStorageSizeInTbs = default, string databaseOcid = default, int? backupRetentionPeriodInDays = default, IEnumerable<string> whitelistedIPs = default)
        {
            return new UnknownAutonomousDatabaseBaseProperties(
                adminPassword,
                dataBaseType is null ? default : new OracleDataBaseType(dataBaseType),
                autonomousMaintenanceScheduleType,
                characterSet,
                computeCount,
                databaseComputeModel,
                cpuCoreCount,
                (customerContacts ?? new ChangeTrackingList<OracleCustomerContact>()).ToList(),
                dataStorageSizeInTbs,
                dataStorageSizeInGbs,
                dbVersion,
                dbWorkload,
                displayName,
                isAutoScalingEnabled,
                isAutoScalingForStorageEnabled,
                (peerDBIds ?? new ChangeTrackingList<string>()).ToList(),
                peerDBId,
                isLocalDataGuardEnabled,
                isRemoteDataGuardEnabled,
                localDisasterRecoveryType,
                disasterRecoveryRoleChangedOn,
                remoteDisasterRecoveryConfiguration,
                localStandbyDB,
                failedDataRecoveryInSeconds,
                isMtlsConnectionRequired,
                isPreviewVersionWithServiceTermsAccepted,
                licenseModel,
                ncharacterSet,
                lifecycleDetails,
                provisioningState,
                lifecycleState,
                (scheduledOperationsList ?? new ChangeTrackingList<ScheduledOperationsType>()).ToList(),
                privateEndpointIP,
                privateEndpointLabel,
                ociUri,
                subnetId,
                vnetId,
                createdOn,
                maintenanceBeginOn,
                maintenanceEndOn,
                actualUsedDataStorageSizeInTbs,
                allocatedStorageSizeInTbs,
                apexDetails,
                (availableUpgradeVersions ?? new ChangeTrackingList<string>()).ToList(),
                connectionStrings,
                connectionUrls,
                dataSafeStatus,
                databaseEdition,
                autonomousDatabaseId,
                inMemoryAreaInGbs,
                nextLongTermBackupCreatedOn,
                longTermBackupSchedule,
                isPreview,
                localAdgAutoFailoverMaxDataLossLimit,
                memoryPerOracleComputeUnitInGbs,
                openMode,
                operationsInsightsStatus,
                permissionLevel,
                privateEndpoint,
                (provisionableCpus ?? new ChangeTrackingList<int>()).ToList(),
                role,
                serviceConsoleUri,
                sqlWebDeveloperUri,
                (supportedRegionsToCloneTo ?? new ChangeTrackingList<string>()).ToList(),
                dataGuardRoleChangedOn,
                freeAutonomousDatabaseDeletedOn,
                timeLocalDataGuardEnabled,
                lastFailoverHappenedOn,
                lastRefreshHappenedOn,
                lastRefreshPointTimestamp,
                lastSwitchoverHappenedOn,
                freeAutonomousDatabaseStoppedOn,
                usedDataStorageSizeInGbs,
                usedDataStorageSizeInTbs,
                databaseOcid,
                backupRetentionPeriodInDays,
                (whitelistedIPs ?? new ChangeTrackingList<string>()).ToList(),
                default,
                default,
                default,
                default,
                default,
                default,
                default);
        }

        /// <summary>
        /// DbSystem resource base model.
        /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="Models.OracleDBSystemProperties"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="provisioningState"> dbSystem provisioning state. </param>
        /// <param name="ociUri"> HTTPS link to OCI resources exposed to Azure Customer via Azure Interface. </param>
        /// <param name="resourceAnchorId"> Azure Resource Anchor ID. </param>
        /// <param name="networkAnchorId"> Azure Network Anchor ID. </param>
        /// <param name="clusterName"> The cluster name for Exadata and 2-node RAC virtual machine DB systems. The cluster name must begin with an alphabetic character, and may contain hyphens (-). Underscores (_) are not permitted. The cluster name can be no longer than 11 characters and is not case sensitive. </param>
        /// <param name="displayName"> The user-friendly name for the DB system. The name does not have to be unique. </param>
        /// <param name="initialDataStorageSizeInGb"> Size in GB of the initial data volume that will be created and attached to a virtual machine DB system. You can scale up storage after provisioning, as needed. Note that the total storage size attached will be more than the amount you specify to allow for REDO/RECO space and software volume. </param>
        /// <param name="dataStorageSizeInGbs"> The data storage size, in gigabytes, that is currently available to the DB system. Applies only for virtual machine DB systems. </param>
        /// <param name="dbSystemOptionsStorageManagement"> The storage option used in DB system. ASM - Automatic storage management, LVM - Logical Volume management. </param>
        /// <param name="diskRedundancy"> The type of redundancy configured for the DB system. NORMAL is 2-way redundancy. HIGH is 3-way redundancy. </param>
        /// <param name="domainV2"> The domain name for the DB system. </param>
        /// <param name="gridImageOcid"> The OCID of a grid infrastructure software image. This is a database software image of the type GRID_IMAGE. </param>
        /// <param name="hostname"> The hostname for the DB system. </param>
        /// <param name="ocid"> The OCID of the DB system. </param>
        /// <param name="licenseModelV2"> The Oracle license model that applies to all the databases on the DB system. The default is LicenseIncluded. </param>
        /// <param name="lifecycleDetails"> Additional information about the current lifecycle state. </param>
        /// <param name="lifecycleState"> The current state of the DB system. </param>
        /// <param name="listenerPort"> The port number configured for the listener on the DB system. </param>
        /// <param name="memorySizeInGbs"> Memory allocated to the DB system, in gigabytes. </param>
        /// <param name="nodeCount"> The number of nodes in the DB system. For RAC DB systems, the value is greater than 1. </param>
        /// <param name="scanDnsName"> The FQDN of the DNS record for the SCAN IP addresses that are associated with the DB system. </param>
        /// <param name="scanIPs"> The list of Single Client Access Name (SCAN) IP addresses associated with the DB system. SCAN IP addresses are typically used for load balancing and are not assigned to any interface. Oracle Clusterware directs the requests to the appropriate nodes in the cluster. Note: For a single-node DB system, this list is empty. </param>
        /// <param name="shape"> The shape of the DB system. The shape determines resources to allocate to the DB system. For virtual machine shapes, the number of CPU cores and memory. For bare metal and Exadata shapes, the number of CPU cores, storage, and memory. </param>
        /// <param name="sshPublicKeys"> The public key portion of one or more key pairs used for SSH access to the DB system. </param>
        /// <param name="storageVolumePerformanceMode"> The block storage volume performance level. Valid values are Balanced and HighPerformance. See [Block Volume Performance](/Content/Block/Concepts/blockvolumeperformance.htm) for more information. </param>
        /// <param name="timeZone"> The time zone of the DB system, e.g., UTC, to set the timeZone as UTC. </param>
        /// <param name="version"> The Oracle Database version of the DB system. </param>
        /// <param name="computeModel"> The compute model for Base Database Service. This is required if using the `computeCount` parameter. If using `cpuCoreCount` then it is an error to specify `computeModel` to a non-null value. The ECPU compute model is the recommended model, and the OCPU compute model is legacy. </param>
        /// <param name="computeCount"> The number of compute servers for the DB system. </param>
        /// <returns> A new <see cref="Models.OracleDBSystemBaseProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OracleDBSystemBaseProperties OracleDBSystemBaseProperties(string source = default, OracleDatabaseProvisioningState? provisioningState = default, Uri ociUri = default, ResourceIdentifier resourceAnchorId = default, ResourceIdentifier networkAnchorId = default, string clusterName = default, string displayName = default, int? initialDataStorageSizeInGb = default, int? dataStorageSizeInGbs = default, StorageManagementType? dbSystemOptionsStorageManagement = default, DBSystemDiskRedundancyType? diskRedundancy = default, string domainV2 = default, string gridImageOcid = default, string hostname = default, string ocid = default, OracleLicenseModel? licenseModelV2 = default, string lifecycleDetails = default, DBSystemLifecycleState? lifecycleState = default, int? listenerPort = default, int? memorySizeInGbs = default, int? nodeCount = default, string scanDnsName = default, IEnumerable<string> scanIPs = default, string shape = default, IEnumerable<string> sshPublicKeys = default, StorageVolumePerformanceMode? storageVolumePerformanceMode = default, string timeZone = default, string version = default, OracleDatabaseComputeModel? computeModel = default, int? computeCount = default)
        {
            return new UnknownOracleDBSystemBaseProperties(
                source is null ? (DBSystemSourceType?)null : new DBSystemSourceType(source),
                provisioningState,
                ociUri,
                resourceAnchorId,
                networkAnchorId,
                clusterName,
                displayName,
                initialDataStorageSizeInGb,
                dataStorageSizeInGbs,
                dbSystemOptionsStorageManagement is null ? default : new OracleDBSystemOptions(dbSystemOptionsStorageManagement, default),
                diskRedundancy,
                domainV2,
                gridImageOcid,
                hostname,
                ocid,
                licenseModelV2,
                lifecycleDetails,
                lifecycleState,
                listenerPort,
                memorySizeInGbs,
                nodeCount,
                scanDnsName,
                (scanIPs ?? new ChangeTrackingList<string>()).ToList(),
                shape,
                (sshPublicKeys ?? new ChangeTrackingList<string>()).ToList(),
                storageVolumePerformanceMode,
                timeZone,
                version,
                computeModel,
                computeCount,
                default,
                default,
                default,
                default);
        }
    }
}
