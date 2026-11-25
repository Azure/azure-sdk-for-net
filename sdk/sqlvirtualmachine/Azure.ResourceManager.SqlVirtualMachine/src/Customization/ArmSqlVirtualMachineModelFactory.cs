// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SqlVirtualMachine.Models
{
    public static partial class ArmSqlVirtualMachineModelFactory
    {
        /// <summary> Creates a SQL virtual machine for mocking. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SqlVmData SqlVmData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, ResourceIdentifier virtualMachineResourceId = default, string provisioningState = default, string sqlImageOffer = default, SqlServerLicenseType? sqlServerLicenseType = default, SqlManagementMode? sqlManagement = default, SqlVmLeastPrivilegeMode? leastPrivilegeMode = default, SqlImageSku? sqlImageSku = default, ResourceIdentifier sqlVmGroupResourceId = default, WindowsServerFailoverClusterDomainCredentials windowsServerFailoverClusterDomainCredentials = default, IPAddress windowsServerFailoverClusterStaticIP = default, SqlVmAutoPatchingSettings autoPatchingSettings = default, SqlVmAutoBackupSettings autoBackupSettings = default, SqlVmKeyVaultCredentialSettings keyVaultCredentialSettings = default, SqlServerConfigurationsManagementSettings serverConfigurationsManagementSettings = default, SqlVmStorageConfigurationSettings storageConfigurationSettings = default, SqlVmTroubleshootingStatus troubleshootingStatus = default, SqlVmAssessmentSettings assessmentSettings = default, bool? enableAutomaticUpgrade = default, SqlVmAdditionalOsPatch? additionalVmPatch = default, SqlVmIdentity virtualMachineIdentitySettings = default, SqlVmOsType? osType = default, string sqlVmName = default, ManagedServiceIdentity identity = default)
        {
            return new SqlVmData(
                id,
                name,
                resourceType,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                virtualMachineResourceId is null && provisioningState is null && sqlImageOffer is null && sqlServerLicenseType is null && sqlManagement is null && leastPrivilegeMode is null && sqlImageSku is null && sqlVmGroupResourceId is null && windowsServerFailoverClusterDomainCredentials is null && windowsServerFailoverClusterStaticIP is null && autoPatchingSettings is null && autoBackupSettings is null && keyVaultCredentialSettings is null && serverConfigurationsManagementSettings is null && storageConfigurationSettings is null && troubleshootingStatus is null && assessmentSettings is null && enableAutomaticUpgrade is null && additionalVmPatch is null && virtualMachineIdentitySettings is null && osType is null ? default : new SqlVirtualMachineProperties(
                    virtualMachineResourceId,
                    provisioningState,
                    sqlImageOffer,
                    sqlServerLicenseType,
                    sqlManagement,
                    leastPrivilegeMode,
                    sqlImageSku,
                    sqlVmGroupResourceId,
                    windowsServerFailoverClusterDomainCredentials,
                    windowsServerFailoverClusterStaticIP,
                    autoPatchingSettings,
                    autoBackupSettings,
                    keyVaultCredentialSettings,
                    serverConfigurationsManagementSettings,
                    storageConfigurationSettings,
                    troubleshootingStatus,
                    assessmentSettings,
                    enableAutomaticUpgrade,
                    additionalVmPatch,
                    virtualMachineIdentitySettings,
                    osType,
                    default),
                sqlVmName,
                identity,
                default);
        }
    }
}
