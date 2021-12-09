// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Maps.Search.Models
{
    /// <summary> The classification for the POI being returned. </summary>
    [CodeGenModel("Polygon")]
    public partial class Polygon
    {   
        /// <summary> ID of the returned entity. </summary>
        [CodeGenMember("ProviderID")]
        public string ProviderId { get; }
    }
}
