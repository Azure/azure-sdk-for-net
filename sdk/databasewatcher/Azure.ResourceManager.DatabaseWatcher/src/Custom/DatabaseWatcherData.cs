// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DatabaseWatcher
{
    /// <summary>
    /// A class representing the DatabaseWatcher data model.
    /// The DatabaseWatcherProviderHub resource.
    /// </summary>
    public partial class DatabaseWatcherData : TrackedResourceData
    {
        /// <summary> The managed service identities assigned to this resource. </summary>
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get; set; }
    }
}
