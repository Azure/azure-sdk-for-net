// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Maps.Rendering
{
    /// <summary> The tileset ID for map. It is the tileset ID representing the map tile style to fetch. </summary>
    [CodeGenModel("TilesetID")]
    public readonly partial struct MapTileSetId : IEquatable<MapTileSetId>
    {
    }
}
