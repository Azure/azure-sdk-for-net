// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.IotFirmwareDefense.Models;

namespace Azure.ResourceManager.IotFirmwareDefense
{
    public partial class FirmwareAnalysisWorkspaceData
    {
        /// <summary> The status of the last operation. </summary>
        public FirmwareProvisioningState? ProvisioningState => WorkspaceProvisioningState;
    }
}
