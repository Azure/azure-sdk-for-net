// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DatabaseWatcher.Models
{
    /// <summary> The type used for update operations of the Watcher. </summary>
    public partial class DatabaseWatcherPatch
    {
        /// <summary> The managed service identities assigned to this resource. </summary>
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get; set; }
    }
}
