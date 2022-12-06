// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Maps.Search.Models
{
    /// <summary> Options. </summary>
    public class SearchStructuredAddressOptions: SearchBaseOptions
    {
        /// <summary>
        /// Specifies the level of filtering performed on geographies. Narrows the search for specified geography entity types, e.g. return only municipality. The resulting response will contain the geography ID as well as the entity type matched. If you provide more than one entity as a comma separated list, endpoint will return the &apos;smallest entity available&apos;. Returned Geometry ID can be used to get the geometry of that geography via <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchpolygon">Get Search Polygon</see> API.
        /// The following parameters are ignored when entityType is set:
        /// <list>
        /// <item><description> heading </description></item>
        /// <item><description> number </description></item>
        /// <item><description> returnRoadUse </description></item>
        /// <item><description> returnSpeedLimit </description></item>
        /// <item><description> roadUse </description></item>
        /// <item><description> returnMatchType </description></item>
        /// </list>
        /// </summary>
        public GeographicEntity? EntityType { get; set; }

        /// <summary>
        /// Indexes for which extended postal codes should be included in the results.
        /// Please refer to <see cref="SearchIndex" /> for all the available search indexes
        /// </summary>
        public IEnumerable<SearchIndex> ExtendedPostalCodesFor { get; set; }
    }
}
