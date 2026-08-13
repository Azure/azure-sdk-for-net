// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Sql;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Sql.Models
{
    [CodeGenSuppress("TdeCertificate", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(string))]
    [CodeGenSuppress("ManagedInstanceVcoresCapability", typeof(string), typeof(int?), typeof(MaxLimitRangeCapability), typeof(MaxLimitRangeCapability), typeof(MaxSizeCapability), typeof(IEnumerable<MaxSizeRangeCapability>), typeof(long?), typeof(MaxLimitRangeCapability), typeof(double?), typeof(double?), typeof(long?), typeof(MaxLimitRangeCapability), typeof(double?), typeof(double?), typeof(bool?), typeof(bool?), typeof(IEnumerable<ManagedInstanceMaintenanceConfigurationCapability>), typeof(SqlCapabilityStatus?), typeof(string))]
    [CodeGenSuppress("ManagedInstanceVcoresCapability", typeof(string), typeof(int?), typeof(MaxLimitRangeCapability), typeof(MaxSizeCapability), typeof(IEnumerable<MaxSizeRangeCapability>), typeof(long?), typeof(MaxLimitRangeCapability), typeof(double?), typeof(double?), typeof(long?), typeof(MaxLimitRangeCapability), typeof(double?), typeof(double?), typeof(bool?), typeof(bool?), typeof(IEnumerable<ManagedInstanceMaintenanceConfigurationCapability>), typeof(SqlCapabilityStatus?), typeof(string))]
    public static partial class ArmSqlModelFactory
    {
        // TODO: Remove these compatibility factory methods after https://github.com/Azure/azure-sdk-for-net/issues/61815 is fixed.

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="certPassword"> The certificate password. </param>
        /// <param name="privateBlob"> The base64 encoded certificate private blob. </param>
        /// <returns> A new <see cref="Models.TdeCertificate"/> instance for mocking. </returns>
        public static TdeCertificate TdeCertificate(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string privateBlob = default, string certPassword = default)
        {
            return new TdeCertificate(
                id,
                name,
                resourceType,
                systemData,
                privateBlob is null && certPassword is null ? default : new TdeCertificateProperties(privateBlob, certPassword, default),
                default);
        }

        /// <param name="name"> The virtual cores identifier. </param>
        /// <param name="value"> The virtual cores value. </param>
        /// <param name="supportedMemoryLimitsInMB"> Memory limit MB ranges. </param>
        /// <param name="supportedMemorySizesInGB"> Supported memory sizes in GB. </param>
        /// <param name="includedMaxSize"> Included size. </param>
        /// <param name="supportedStorageSizes"> Storage size ranges. </param>
        /// <param name="includedStorageIOps"> Included storage IOps. </param>
        /// <param name="supportedStorageIOps"> Storage IOps ranges. </param>
        /// <param name="iopsMinValueOverrideFactorPerSelectedStorageGB"> Min IOps override factor per selected storage GB. </param>
        /// <param name="iopsIncludedValueOverrideFactorPerSelectedStorageGB"> Included IOps override factor per selected storage GB. </param>
        /// <param name="includedStorageThroughputMBps"> Included storage throughput MBps. </param>
        /// <param name="supportedStorageThroughputMBps"> Storage throughput MBps ranges. </param>
        /// <param name="throughputMBpsMinValueOverrideFactorPerSelectedStorageGB"> Min throughput MBps override factor per selected storage GB. </param>
        /// <param name="throughputMBpsIncludedValueOverrideFactorPerSelectedStorageGB"> Included throughput MBps override factor per selected storage GB. </param>
        /// <param name="isInstancePoolSupported"> True if this service objective is supported for managed instances in an instance pool. </param>
        /// <param name="isStandaloneSupported"> True if this service objective is supported for standalone managed instances. </param>
        /// <param name="supportedMaintenanceConfigurations"> List of supported maintenance configurations. </param>
        /// <param name="status"> The status of the capability. </param>
        /// <param name="reason"> The reason for the capability not being available. </param>
        /// <returns> A new <see cref="Models.ManagedInstanceVcoresCapability"/> instance for mocking. </returns>
        public static ManagedInstanceVcoresCapability ManagedInstanceVcoresCapability(string name = default, int? value = default, MaxLimitRangeCapability supportedMemoryLimitsInMB = default, MaxLimitRangeCapability supportedMemorySizesInGB = default, MaxSizeCapability includedMaxSize = default, IEnumerable<MaxSizeRangeCapability> supportedStorageSizes = default, long? includedStorageIOps = default, MaxLimitRangeCapability supportedStorageIOps = default, double? iopsMinValueOverrideFactorPerSelectedStorageGB = default, double? iopsIncludedValueOverrideFactorPerSelectedStorageGB = default, long? includedStorageThroughputMBps = default, MaxLimitRangeCapability supportedStorageThroughputMBps = default, double? throughputMBpsMinValueOverrideFactorPerSelectedStorageGB = default, double? throughputMBpsIncludedValueOverrideFactorPerSelectedStorageGB = default, bool? isInstancePoolSupported = default, bool? isStandaloneSupported = default, IEnumerable<ManagedInstanceMaintenanceConfigurationCapability> supportedMaintenanceConfigurations = default, SqlCapabilityStatus? status = default, string reason = default)
        {
            supportedStorageSizes ??= new ChangeTrackingList<MaxSizeRangeCapability>();
            supportedMaintenanceConfigurations ??= new ChangeTrackingList<ManagedInstanceMaintenanceConfigurationCapability>();

            return new ManagedInstanceVcoresCapability(
                name,
                value,
                supportedMemorySizesInGB,
                supportedMemoryLimitsInMB,
                includedMaxSize,
                (supportedStorageSizes ?? new ChangeTrackingList<MaxSizeRangeCapability>()).ToList(),
                includedStorageIOps,
                supportedStorageIOps,
                iopsMinValueOverrideFactorPerSelectedStorageGB,
                iopsIncludedValueOverrideFactorPerSelectedStorageGB,
                includedStorageThroughputMBps,
                supportedStorageThroughputMBps,
                throughputMBpsMinValueOverrideFactorPerSelectedStorageGB,
                throughputMBpsIncludedValueOverrideFactorPerSelectedStorageGB,
                isInstancePoolSupported,
                isStandaloneSupported,
                (supportedMaintenanceConfigurations ?? new ChangeTrackingList<ManagedInstanceMaintenanceConfigurationCapability>()).ToList(),
                status,
                reason,
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ManagedInstanceVcoresCapability"/>. </summary>
        /// <param name="name"> The virtual cores identifier. </param>
        /// <param name="value"> The virtual cores value. </param>
        /// <param name="supportedMemorySizesInGB"> Supported memory sizes in GB. </param>
        /// <param name="includedMaxSize"> Included size. </param>
        /// <param name="supportedStorageSizes"> Storage size ranges. </param>
        /// <param name="includedStorageIOps"> Included storage IOps. </param>
        /// <param name="supportedStorageIOps"> Storage IOps ranges. </param>
        /// <param name="iopsMinValueOverrideFactorPerSelectedStorageGB"> Min IOps override factor per selected storage GB. </param>
        /// <param name="iopsIncludedValueOverrideFactorPerSelectedStorageGB"> Included IOps override factor per selected storage GB. </param>
        /// <param name="includedStorageThroughputMBps"> Included storage throughput MBps. </param>
        /// <param name="supportedStorageThroughputMBps"> Storage throughput MBps ranges. </param>
        /// <param name="throughputMBpsMinValueOverrideFactorPerSelectedStorageGB"> Min throughput MBps override factor per selected storage GB. </param>
        /// <param name="throughputMBpsIncludedValueOverrideFactorPerSelectedStorageGB"> Included throughput MBps override factor per selected storage GB. </param>
        /// <param name="isInstancePoolSupported"> True if this service objective is supported for managed instances in an instance pool. </param>
        /// <param name="isStandaloneSupported"> True if this service objective is supported for standalone managed instances. </param>
        /// <param name="supportedMaintenanceConfigurations"> List of supported maintenance configurations. </param>
        /// <param name="status"> The status of the capability. </param>
        /// <param name="reason"> The reason for the capability not being available. </param>
        /// <returns> A new <see cref="Models.ManagedInstanceVcoresCapability"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedInstanceVcoresCapability ManagedInstanceVcoresCapability(string name, int? value, MaxLimitRangeCapability supportedMemorySizesInGB, MaxSizeCapability includedMaxSize, IEnumerable<MaxSizeRangeCapability> supportedStorageSizes = default, long? includedStorageIOps = default, MaxLimitRangeCapability supportedStorageIOps = default, double? iopsMinValueOverrideFactorPerSelectedStorageGB = default, double? iopsIncludedValueOverrideFactorPerSelectedStorageGB = default, long? includedStorageThroughputMBps = default, MaxLimitRangeCapability supportedStorageThroughputMBps = default, double? throughputMBpsMinValueOverrideFactorPerSelectedStorageGB = default, double? throughputMBpsIncludedValueOverrideFactorPerSelectedStorageGB = default, bool? isInstancePoolSupported = default, bool? isStandaloneSupported = default, IEnumerable<ManagedInstanceMaintenanceConfigurationCapability> supportedMaintenanceConfigurations = default, SqlCapabilityStatus? status = default, string reason = default)
        {
            return new ManagedInstanceVcoresCapability(
                name,
                value,
                supportedMemorySizesInGB,
                default,
                includedMaxSize,
                (supportedStorageSizes ?? new ChangeTrackingList<MaxSizeRangeCapability>()).ToList(),
                includedStorageIOps,
                supportedStorageIOps,
                iopsMinValueOverrideFactorPerSelectedStorageGB,
                iopsIncludedValueOverrideFactorPerSelectedStorageGB,
                includedStorageThroughputMBps,
                supportedStorageThroughputMBps,
                throughputMBpsMinValueOverrideFactorPerSelectedStorageGB,
                throughputMBpsIncludedValueOverrideFactorPerSelectedStorageGB,
                isInstancePoolSupported,
                isStandaloneSupported,
                (supportedMaintenanceConfigurations ?? new ChangeTrackingList<ManagedInstanceMaintenanceConfigurationCapability>()).ToList(),
                status,
                reason,
                default);
        }
    }
}
