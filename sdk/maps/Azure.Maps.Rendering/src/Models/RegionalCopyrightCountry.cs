// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Rendering
{
    /// <summary> Country property. </summary>
    [CodeGenModel("RegionCopyrightsCountry")]
    public partial class RegionalCopyrightCountry
    {
        /// <summary> ISO3 property. </summary>
        [CodeGenMember("ISO3")]
        public string Iso3 { get; }
    }
}
