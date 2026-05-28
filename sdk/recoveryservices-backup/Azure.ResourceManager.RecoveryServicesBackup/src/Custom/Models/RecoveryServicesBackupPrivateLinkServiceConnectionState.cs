// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    /// <summary> Private Link Service Connection State. </summary>
    public partial class RecoveryServicesBackupPrivateLinkServiceConnectionState
    {
        /// <summary>
        /// ActionRequired
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ActionRequired
        {
            get => ActionsRequired;
            set
            {
                ActionsRequired = value;
            }
        }
    }
}
