// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    // Backward-compatibility shim: the TypeSpec-based generator only emits a
    // parameterless public ctor and an internal 6-parameter ctor.  The previous
    // AutoRest-generated SDK (≤ 1.4.0) exposed a public 2-parameter ctor
    // (ContainerRegistrySyncTrigger, ContainerRegistrySyncState).
    // This partial class restores that constructor so existing callers are not broken.
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
