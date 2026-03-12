// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct AllowedCopyScope
    {
        /// <summary> Backward-compatible alias for AAD. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AllowedCopyScope Aad { get; } = AAD;
    }
}
