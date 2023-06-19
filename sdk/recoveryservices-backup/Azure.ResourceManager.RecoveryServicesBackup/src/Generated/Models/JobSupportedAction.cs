// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    /// <summary> The JobSupportedAction. </summary>
    public enum JobSupportedAction
    {
        /// <summary> Invalid. </summary>
        Invalid,
        /// <summary> Cancellable. </summary>
        Cancellable,
        /// <summary> Retriable. </summary>
        Retriable
    }
}
