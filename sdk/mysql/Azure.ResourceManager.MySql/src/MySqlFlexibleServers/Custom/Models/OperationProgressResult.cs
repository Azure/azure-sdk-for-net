// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.MySql.FlexibleServers.Models
{
    /// <summary> Represents Operation Results API Response. </summary>
    public partial class OperationProgressResult : OperationStatusResult
    {
        /// <summary>
        /// Converts the OperationProgressResponseType properties to BackupAndExportResponseType properties.
        /// <returns> An instance of OperationProgressResult. </returns>
        /// </summary>
        internal static OperationProgressResult ToBackupAndExportResponse(OperationProgressResult operationProgressResult)
        {
            return new OperationProgressResult(operationProgressResult.Id,
                                operationProgressResult.ResourceId,
                                operationProgressResult.Name,
                                operationProgressResult.Status,
                                operationProgressResult.PercentComplete,
                                operationProgressResult.StartOn,
                                operationProgressResult.EndOn,
                                operationProgressResult.Operations,
                                operationProgressResult.Error,
                                operationProgressResult._serializedAdditionalRawData,
                                OperationProgressResponseType.ToBackupAndExportResponseType(operationProgressResult.Properties));
        }

        /// <summary>
        /// Converts the OperationProgressResponseType properties to ImportFromStorageResponseType properties.
        /// <returns> An instance of OperationProgressResult. </returns>
        /// </summary>
        internal static OperationProgressResult ToImportFromStorageResponse(OperationProgressResult operationProgressResult)
        {
            return new OperationProgressResult(operationProgressResult.Id,
                                operationProgressResult.ResourceId,
                                operationProgressResult.Name,
                                operationProgressResult.Status,
                                operationProgressResult.PercentComplete,
                                operationProgressResult.StartOn,
                                operationProgressResult.EndOn,
                                operationProgressResult.Operations,
                                operationProgressResult.Error,
                                operationProgressResult._serializedAdditionalRawData,
                                OperationProgressResponseType.ToImportFromStorageResponseType(operationProgressResult.Properties));
        }
    }
}
