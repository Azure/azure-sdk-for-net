// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.IotFirmwareDefense.Models;

namespace Azure.ResourceManager.IotFirmwareDefense
{
    public partial class FirmwareAnalysisWorkspaceData
    {
        /// <summary> Initializes a new instance of <see cref="FirmwareAnalysisWorkspaceData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        public FirmwareAnalysisWorkspaceData(AzureLocation location) : base(location)
        {
            // Preserve the empty properties envelope sent by the shipped workspace create operation.
            Properties = new WorkspaceProperties();
        }
    }
}
