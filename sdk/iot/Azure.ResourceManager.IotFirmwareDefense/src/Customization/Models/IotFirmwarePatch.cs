// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> Firmware definition. </summary>
    public partial class IotFirmwarePatch
    {
        /// <summary> File name for a firmware that user uploaded. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FileName { get; set; }
        /// <summary> Firmware vendor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Vendor { get; set; }
        /// <summary> Firmware model. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Model { get; set; }
        /// <summary> Firmware version. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Version { get; set; }
        /// <summary> User-specified description of the firmware. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Description { get; set; }
        /// <summary> File size of the uploaded firmware image. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? FileSize { get; set; }
        /// <summary> The status of firmware scan. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FirmwareAnalysisStatus? Status { get; set; }
        /// <summary> A list of errors or other messages generated during firmware analysis. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<FirmwareAnalysisStatusMessage> StatusMessages { get; }
        /// <summary> Provisioning state of the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FirmwareProvisioningState? ProvisioningState { get; }
    }
}
