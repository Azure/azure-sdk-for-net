// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Route.Models
{
    /// <summary> A valid `GeoJSON MultiLineString` geometry type. Please refer to [RFC 7946](https://tools.ietf.org/html/rfc7946#section-3.1.5) for details. </summary>
    [CodeGenModel("GeoJsonMultiLineString")]
    internal partial class GeoJsonMultiLineString : GeoJsonGeometry
    {
    }
}
