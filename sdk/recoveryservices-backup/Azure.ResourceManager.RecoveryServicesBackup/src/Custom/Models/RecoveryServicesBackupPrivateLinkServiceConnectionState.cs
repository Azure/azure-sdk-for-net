// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    public partial class RecoveryServicesBackupPrivateLinkServiceConnectionState
    {
        /// <summary> ActionRequired </summary>
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
