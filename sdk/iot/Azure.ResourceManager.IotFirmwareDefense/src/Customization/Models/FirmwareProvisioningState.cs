// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> Provisioning state of the resource. </summary>
    public readonly partial struct FirmwareProvisioningState
    {
        private const string AcceptedValue = "Accepted";

        /// <summary> Accepted. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FirmwareProvisioningState Accepted => new FirmwareProvisioningState(AcceptedValue);
    }
}
