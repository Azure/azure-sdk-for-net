// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    public partial class BoundaryProperties
    {
        /// <summary> A URL that lists many of the data providers for Azure Maps and their related copyright information. </summary>
        [CodeGenMember("CopyrightURL")]
        public string CopyrightUrl { get; }
    }
}
