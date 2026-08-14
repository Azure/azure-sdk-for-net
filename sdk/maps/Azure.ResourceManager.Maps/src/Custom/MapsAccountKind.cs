// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Maps.Models
{
    // Backward compat: Gen1 was removed in API version 2025-10-01-preview but must be
    // preserved to avoid breaking existing callers of the GA SDK (1.1.0).
    // MapsAccountKind is an extensible enum so adding the value back is safe.
    public readonly partial struct MapsAccountKind
    {
        /// <summary> Gen1. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MapsAccountKind Gen1 { get; } = new MapsAccountKind("Gen1");
    }
}
