// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Maps.Models
{
    public readonly partial struct MapsAccountKind
    {
        /// <summary> Gen1. </summary>
        public static MapsAccountKind Gen1 { get; } = new MapsAccountKind("Gen1");
    }
}
