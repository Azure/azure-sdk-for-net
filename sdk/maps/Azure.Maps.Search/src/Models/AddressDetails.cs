// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Core.GeoJson;
using System;

namespace Azure.Maps.Search.Models
{
    /// <summary> The address of the result. </summary>
    [CodeGenModel("Address")]
    public partial class MapsAddress
    {
         /// <summary> ISO alpha-3 country code. </summary>
        [CodeGenMember("CountryCodeISO3")]
        public string CountryCodeIso3 { get; }
    }
}
