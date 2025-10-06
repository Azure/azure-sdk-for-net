// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    internal partial class GeoJsonGeometry : GeoJsonObject
    {
        /// <summary> Initializes a new instance of GeoJsonGeometry. </summary>
        public GeoJsonGeometry()
        {
            Type = GeoJsonObjectType.GeoJsonGeometryCollection;
        }
    }
}
