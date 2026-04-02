// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat property shim: OSType was renamed to OsType in TypeSpec migration.

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class CachedImages
    {
        /// <summary> The OS type of the cached image. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OSType => OsType;
    }
}
