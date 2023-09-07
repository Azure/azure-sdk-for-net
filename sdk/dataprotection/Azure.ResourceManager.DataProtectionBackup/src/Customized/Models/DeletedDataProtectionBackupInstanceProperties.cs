// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    /// <summary>
    /// Backup Instance Properties
    /// </summary>
    public partial class DeletedDataProtectionBackupInstanceProperties
    {
        internal DeletedDataProtectionBackupInstanceProperties(string friendlyName, DataSourceInfo dataSourceInfo, DataSourceSetInfo dataSourceSetInfo, BackupInstancePolicyInfo policyInfo, BackupInstanceProtectionStatusDetails protectionStatus, CurrentProtectionState? currentProtectionState, ResponseError protectionErrorDetails, string provisioningState, DataProtectionBackupAuthCredentials dataSourceAuthCredentials, BackupValidationType? validationType, string objectType, BackupInstanceDeletionInfo deletionInfo) : base(friendlyName, dataSourceInfo, dataSourceSetInfo, policyInfo, protectionStatus, currentProtectionState, protectionErrorDetails, provisioningState, dataSourceAuthCredentials, validationType, objectType)
        {
            DeletionInfo = deletionInfo;
            IdentityDetails = null;
        }
    }
}
