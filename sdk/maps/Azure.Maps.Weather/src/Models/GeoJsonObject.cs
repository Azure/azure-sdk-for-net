// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Weather.Models
{
    /// <summary>
    /// A valid `GeoJSON` object. Please refer to [RFC 7946](https://tools.ietf.org/html/rfc7946#section-3) for details.
    /// Please note <see cref="GeoJsonObject"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes..
    /// </summary>
    [CodeGenModel("GeoJsonObject")]
    internal abstract partial class GeoJsonObject
    {
    }
}
