// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> Firmware analysis workspace. </summary>
    public partial class FirmwareAnalysisWorkspacePatch
    {
        /// <summary> Provisioning state of the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FirmwareProvisioningState? ProvisioningState => null;
    }
}
