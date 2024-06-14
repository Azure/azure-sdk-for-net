// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MySql.FlexibleServers.Models
{
    /// <summary>
    /// Represents the response properties specific to the operation
    /// Please note <see cref="OperationProgressResponseType"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="BackupAndExportResponseType"/> and <see cref="ImportFromStorageResponseType"/>.
    /// </summary>
    public abstract partial class OperationProgressResponseType
    {
        /// <summary>
        /// Converts the OperationProgressResponseType to BackupAndExportResponseType.
        /// <returns> An instance of BackupAndExportResponseType. </returns>
        /// </summary>
        public static BackupAndExportResponseType ToBackupAndExportResponseType(OperationProgressResponseType operationProgressResponseType)
        {
            if (operationProgressResponseType == null)
            {
                throw new ArgumentNullException(nameof(operationProgressResponseType));
            }

            if (operationProgressResponseType.ObjectType == "Unknown")
            {
                operationProgressResponseType.ObjectType = MySqlFlexibleServerOperationType.BackupAndExportResponse;
            }

            return (BackupAndExportResponseType)operationProgressResponseType;
        }

        /// <summary>
        /// Converts the OperationProgressResponseType to ImportFromStorageResponseType.
        /// <param name="operationProgressResponseType"> Instance of OperationProgressResponseType. </param>
        /// <returns> An instance of ImportFromStorageResponseType. </returns>
        /// </summary>
        public static ImportFromStorageResponseType ToImportFromStorageResponseType(OperationProgressResponseType operationProgressResponseType)
        {
            if (operationProgressResponseType == null)
            {
                throw new ArgumentNullException(nameof(operationProgressResponseType));
            }

            if (operationProgressResponseType.ObjectType == "Unknown")
            {
                operationProgressResponseType.ObjectType = MySqlFlexibleServerOperationType.ImportFromStorageResponse;
            }

            return (ImportFromStorageResponseType)operationProgressResponseType;
        }
    }
}
