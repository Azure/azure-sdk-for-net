// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    /// <summary>
    /// Backup Instance Properties
    /// </summary>
    public partial class DataProtectionBackupInstanceProperties
    {
        internal DataProtectionBackupInstanceProperties(string friendlyName, DataSourceInfo dataSourceInfo, DataSourceSetInfo dataSourceSetInfo, BackupInstancePolicyInfo policyInfo, BackupInstanceProtectionStatusDetails protectionStatus, CurrentProtectionState? currentProtectionState, ResponseError protectionErrorDetails, string provisioningState, DataProtectionBackupAuthCredentials dataSourceAuthCredentials, BackupValidationType? validationType, string objectType)
        {
            FriendlyName = friendlyName;
            DataSourceInfo = dataSourceInfo;
            DataSourceSetInfo = dataSourceSetInfo;
            PolicyInfo = policyInfo;
            ProtectionStatus = protectionStatus;
            CurrentProtectionState = currentProtectionState;
            ProtectionErrorDetails = protectionErrorDetails;
            ProvisioningState = provisioningState;
            DataSourceAuthCredentials = dataSourceAuthCredentials;
            ValidationType = validationType;
            ObjectType = objectType;
        }
    }
}
