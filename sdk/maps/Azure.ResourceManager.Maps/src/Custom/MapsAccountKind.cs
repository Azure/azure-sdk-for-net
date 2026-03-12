// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Maps.Models
{
    /// <summary> The Kind of the Maps Account. </summary>
    public readonly partial struct MapsAccountKind
    {
        /// <summary> Gen1. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MapsAccountKind Gen1 { get; } = new MapsAccountKind("Gen1");
    }
}
