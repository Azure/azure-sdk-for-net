// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class CachedImages
    {
        // backward-compat shim: old property was OSType (PascalCase), new is OsType
        /// <summary> The OS type of the cached image. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OSType => OsType;
    }
}
