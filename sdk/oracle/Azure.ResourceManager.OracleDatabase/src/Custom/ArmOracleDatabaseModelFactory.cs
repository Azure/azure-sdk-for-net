// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    public partial class ArmOracleDatabaseModelFactory
    {
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
            return new AutonomousDBVersionProperties(
                version,
                dbWorkload,
                isDefaultForFree,
                isDefaultForPaid,
                isFreeTierEnabled,
                isPaidEnabled,
                serializedAdditionalRawData: null);
        }
/*
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CloudVmClusterDBNodeProperties CloudVmClusterDBNodeProperties(ResourceIdentifier ocid, string additionalDetails, ResourceIdentifier backupIPId, ResourceIdentifier backupVnic2Id, ResourceIdentifier backupVnicId, int? cpuCoreCount, int? dbNodeStorageSizeInGbs, ResourceIdentifier dbServerId, ResourceIdentifier dbSystemId, string faultDomain, ResourceIdentifier hostIPId, string hostname, DBNodeProvisioningState? lifecycleState, string lifecycleDetails, DBNodeMaintenanceType? maintenanceType, int? memorySizeInGbs, int? softwareStorageSizeInGb, DateTimeOffset? timeCreated, DateTimeOffset? timeMaintenanceWindowEnd, DateTimeOffset? timeMaintenanceWindowStart, ResourceIdentifier vnic2Id, ResourceIdentifier vnicId, OracleDatabaseResourceProvisioningState? provisioningState)
            => CloudVmClusterDBNodeProperties(ocid, additionalDetails, backupIPId, backupVnic2Id, backupVnicId, cpuCoreCount, dbNodeStorageSizeInGbs, dbServerId, dbSystemId, faultDomain, hostIPId, hostname, (DBNodeProvisioningState)lifecycleState, lifecycleDetails, maintenanceType, memorySizeInGbs, softwareStorageSizeInGb, (DateTimeOffset)timeCreated, timeMaintenanceWindowEnd, timeMaintenanceWindowStart, vnic2Id, vnicId, provisioningState);
*/
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
        public static OracleDBSystemShapeProperties OracleDBSystemShapeProperties(string shapeFamily, int availableCoreCount, int? minimumCoreCount, int? runtimeMinimumCoreCount, int? coreCountIncrement, int? minStorageCount, int? maxStorageCount, double? availableDataStoragePerServerInTbs, int? availableMemoryPerNodeInGbs, int? availableDBNodePerNodeInGbs, int? minCoreCountPerNode, int? availableMemoryInGbs, int? minMemoryPerNodeInGbs, int? availableDBNodeStorageInGbs, int? minDBNodeStoragePerNodeInGbs, int? availableDataStorageInTbs, int? minDataStorageInTbs, int? minimumNodeCount, int? maximumNodeCount, int? availableCoreCountPerNode)
        {
            return new OracleDBSystemShapeProperties(
                shapeFamily,
                default,
                availableCoreCount,
                minimumCoreCount,
                runtimeMinimumCoreCount,
                coreCountIncrement,
                minStorageCount,
                maxStorageCount,
                availableDataStoragePerServerInTbs,
                availableMemoryPerNodeInGbs,
                availableDBNodePerNodeInGbs,
                minCoreCountPerNode,
                availableMemoryInGbs,
                minMemoryPerNodeInGbs,
                availableDBNodeStorageInGbs,
                minDBNodeStoragePerNodeInGbs,
                availableDataStorageInTbs,
                minDataStorageInTbs,
                minimumNodeCount,
                maximumNodeCount,
                availableCoreCountPerNode,
                default,
                default,
                default,
                null);
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OracleDnsPrivateViewProperties OracleDnsPrivateViewProperties(ResourceIdentifier ocid, string displayName, bool isProtected, DnsPrivateViewsLifecycleState? lifecycleState, string self, DateTimeOffset createdOn, DateTimeOffset updatedOn, OracleDatabaseResourceProvisioningState? provisioningState)
        {
            return new OracleDnsPrivateViewProperties(
                ocid,
                displayName,
                isProtected,
                (DnsPrivateViewsLifecycleState)lifecycleState,
                self,
                createdOn,
                updatedOn,
                provisioningState,
                serializedAdditionalRawData: null);
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OracleDnsPrivateZoneProperties OracleDnsPrivateZoneProperties(ResourceIdentifier ocid, bool isProtected, DnsPrivateZonesLifecycleState? lifecycleState, string self, int serial, string version, ResourceIdentifier viewId, OracleDnsPrivateZoneType zoneType, DateTimeOffset createdOn, OracleDatabaseResourceProvisioningState? provisioningState)
        {
            return new OracleDnsPrivateZoneProperties(
                ocid,
                isProtected,
                (DnsPrivateZonesLifecycleState)lifecycleState,
                self,
                serial,
                version,
                viewId?.ToString(),
                zoneType,
                createdOn,
                provisioningState,
                serializedAdditionalRawData: null);
        }
    }
}
