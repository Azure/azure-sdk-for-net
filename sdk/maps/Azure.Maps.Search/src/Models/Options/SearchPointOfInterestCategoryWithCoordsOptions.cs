// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Maps.Search.Models
{
    /// <summary> Options. </summary>
    public class SearchPointOfInterestCategoryWithCoordsOptions: SearchPointOfInterestCategoryOptions
    {
        /// <summary> Coordinates where results should be biased. E.g. 37.337, -121.89. </summary>
        public LatLong Coordinates { get; set; }
    }
}
