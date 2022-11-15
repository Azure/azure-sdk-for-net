// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Routing.Models
{
    /// <summary> A valid `GeoJSON Polygon` geometry type. Please refer to <see href="https://tools.ietf.org/html/rfc7946#section-3.1.6">RFC 7946</see> for details. </summary>
    [CodeGenModel("GeoJsonPolygon")]
    internal partial class GeoJsonPolygon : GeoJsonGeometry
    {
    }
}
