// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerRegistry.Models
{
    public partial class ContainerRegistrySyncResult
    {
        /// <summary> Initializes a new instance of <see cref="ContainerRegistrySyncResult"/>. </summary>
        /// <param name="syncTrigger"> The action that triggered the most recent registry sync. </param>
        /// <param name="syncState"> The status of the connected registry's most recent sync. </param>
        public ContainerRegistrySyncResult(ContainerRegistrySyncTrigger syncTrigger, ContainerRegistrySyncState syncState)
        {
            SyncTrigger = syncTrigger;
            SyncState = syncState;
        }
    }
}
