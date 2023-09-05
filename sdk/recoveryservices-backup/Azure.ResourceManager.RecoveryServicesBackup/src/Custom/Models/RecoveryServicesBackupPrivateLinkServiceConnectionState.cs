// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    /// <summary> Private Link Service Connection State. </summary>
    public partial class RecoveryServicesBackupPrivateLinkServiceConnectionState
    {
        /// <summary>
        /// ActionRequired
        /// </summary>
        public string ActionRequired
        {
            get => ActionsRequired;
            set
            {
                ActionRequired = value;
            }
        }
    }
}
