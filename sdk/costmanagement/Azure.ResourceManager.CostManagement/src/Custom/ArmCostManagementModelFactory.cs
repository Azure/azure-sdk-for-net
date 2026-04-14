// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.CostManagement;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.CostManagement.Models
{
    public static partial class ArmCostManagementModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.ExportRun"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ExportRun ExportRun(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ExportRunExecutionType? executionType, ExportRunExecutionStatus? status, string submittedBy, DateTimeOffset? submittedOn, DateTimeOffset? processingStartOn, DateTimeOffset? processingEndOn, string fileName, CommonExportProperties runSettings, ExportRunErrorDetails error, ETag? eTag)
        {
            return ExportRun(
                id: id,
                name: name,
                etag: eTag,
                executionType: executionType,
                status: status,
                submittedBy: submittedBy,
                submittedOn: submittedOn,
                processingStartOn: processingStartOn,
                processingEndOn: processingEndOn,
                fileName: fileName,
                runSettings: runSettings,
                error: error);
        }
    }
}
