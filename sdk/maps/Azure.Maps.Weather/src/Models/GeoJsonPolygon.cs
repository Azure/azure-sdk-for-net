// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Weather.Models
{
    /// <summary> A valid `GeoJSON Polygon` geometry type. Please refer to [RFC 7946](https://tools.ietf.org/html/rfc7946#section-3.1.6) for details. </summary>
    [CodeGenModel("GeoJsonPolygon")]
    internal partial class GeoJsonPolygon : GeoJsonGeometry
    {
    }
}