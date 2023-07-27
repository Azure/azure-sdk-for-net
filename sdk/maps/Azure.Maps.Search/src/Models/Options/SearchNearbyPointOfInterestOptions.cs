// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Maps.Search
{
    /// <summary> Options. </summary>
    public class SearchNearbyPointOfInterestOptions: SearchPointOfInterestOptions
    {
        /// <summary>
        /// Indexes for which extended postal codes should be included in the results.
        /// Please refer to <see cref="SearchIndex" /> for all the available search indexes
        /// </summary>
        public new IEnumerable<SearchIndex> ExtendedPostalCodesFor { get; set; }
    }
}
