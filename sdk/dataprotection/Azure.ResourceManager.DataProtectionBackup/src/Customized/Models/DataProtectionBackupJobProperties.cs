// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    /// <summary>
    /// Backup Instance Properties
    /// </summary>
    public partial class DataProtectionBackupJobProperties
    {
        internal DataProtectionBackupJobProperties(string activityId, string backupInstanceFriendlyName, ResourceIdentifier backupInstanceId, ResourceIdentifier dataSourceId, AzureLocation dataSourceLocation, string dataSourceName, string dataSourceSetName, string dataSourceType, TimeSpan? duration, DateTimeOffset? endOn, IReadOnlyList<ResponseError> errorDetails, BackupJobExtendedInfo extendedInfo, bool isUserTriggered, string operation, string operationCategory, ResourceIdentifier policyId, string policyName, bool isProgressEnabled, Uri progressUri, string restoreType, string sourceResourceGroup, string sourceSubscriptionId, DateTimeOffset startOn, string status, string subscriptionId, IList<string> supportedActions, string vaultName, ETag? eTag, string sourceDataStoreName, string destinationDataStoreName)
        {
            ActivityId = activityId;
            BackupInstanceFriendlyName = backupInstanceFriendlyName;
            BackupInstanceId = backupInstanceId;
            DataSourceId = dataSourceId;
            DataSourceLocation = dataSourceLocation;
            DataSourceName = dataSourceName;
            DataSourceSetName = dataSourceSetName;
            DataSourceType = dataSourceType;
            Duration = duration;
            EndOn = endOn;
            ErrorDetails = errorDetails;
            ExtendedInfo = extendedInfo;
            IsUserTriggered = isUserTriggered;
            Operation = operation;
            OperationCategory = operationCategory;
            PolicyId = policyId;
            PolicyName = policyName;
            IsProgressEnabled = isProgressEnabled;
            ProgressUri = progressUri;
            RestoreType = restoreType;
            SourceResourceGroup = sourceResourceGroup;
            SourceSubscriptionId = sourceSubscriptionId;
            StartOn = startOn;
            Status = status;
            SubscriptionId = subscriptionId;
            SupportedActions = supportedActions;
            VaultName = vaultName;
            ETag = eTag;
            SourceDataStoreName = sourceDataStoreName;
            DestinationDataStoreName = destinationDataStoreName;
        }
    }
}
