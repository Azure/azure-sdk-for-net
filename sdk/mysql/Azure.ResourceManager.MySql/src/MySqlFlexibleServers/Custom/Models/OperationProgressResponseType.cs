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
        internal static OperationProgressResponseType ToBackupAndExportResponseType(OperationProgressResponseType operationProgressResponseType)
        {
            if (operationProgressResponseType == null)
                return null;
            if (operationProgressResponseType is UnknownOperationProgressResponseType)
            {
                // LRO polling doesnt return the ObjectType, so we need to check the serializedAdditionalRawData to determine the type
                Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
                long? DatasourceSizeInBytes = null;
                long? DataTransferredInBytes = null;
                string BackupMetadata = null;
                foreach (var item in operationProgressResponseType._serializedAdditionalRawData)
                {
                    switch (item.Key)
                    {
                        case "datasourceSizeInBytes":
                            DatasourceSizeInBytes = item.Value.ToObjectFromJson<long>();
                            break;
                        case "dataTransferredInBytes":
                            DataTransferredInBytes = item.Value.ToObjectFromJson<long>();
                            break;
                        case "backupMetadata":
                            BackupMetadata = item.Value.ToObjectFromJson<string>();
                            break;
                        default:
                            serializedAdditionalRawData.Add(item.Key, item.Value);
                            break;
                    }
                }
                return new BackupAndExportResponseType(MySqlFlexibleServerOperationType.BackupAndExportResponse, serializedAdditionalRawData, DatasourceSizeInBytes, DataTransferredInBytes, BackupMetadata);
            }
            return operationProgressResponseType;
        }

        /// <summary>
        /// Converts the OperationProgressResponseType to ImportFromStorageResponseType.
        /// <param name="operationProgressResponseType"> Instance of OperationProgressResponseType. </param>
        /// <returns> An instance of ImportFromStorageResponseType. </returns>
        /// </summary>
        internal static OperationProgressResponseType ToImportFromStorageResponseType(OperationProgressResponseType operationProgressResponseType)
        {
            if (operationProgressResponseType == null)
                return null;

            if (operationProgressResponseType is UnknownOperationProgressResponseType)
            {
                // LRO polling doesnt return the ObjectType, so we need to check the serializedAdditionalRawData to determine the type
                Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
                DateTimeOffset? estimatedCompletionOn = null;
                foreach (var item in operationProgressResponseType._serializedAdditionalRawData)
                {
                    switch (item.Key)
                    {
                        case "estimatedCompletionTime":
                            estimatedCompletionOn = item.Value.ToObjectFromJson<DateTimeOffset>();
                            break;
                        default:
                            serializedAdditionalRawData.Add(item.Key, item.Value);
                            break;
                    }
                }
                return new ImportFromStorageResponseType(MySqlFlexibleServerOperationType.BackupAndExportResponse, serializedAdditionalRawData, estimatedCompletionOn);
            }
            return operationProgressResponseType;
        }
    }
}
