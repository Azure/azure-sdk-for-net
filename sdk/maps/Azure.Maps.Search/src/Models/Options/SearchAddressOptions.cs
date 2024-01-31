// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core.GeoJson;

namespace Azure.Maps.Search
{
    /// <summary> Options for Search Address API. </summary>
    public class SearchAddressOptions: SearchAddressBaseOptions
    {
        /// <summary> bounding box. </summary>
        public GeoBoundingBox BoundingBox { get; set; }
        /// <summary> Boolean. If the typeahead flag is set, the query will be interpreted as a partial input and the search will enter predictive mode. </summary>
        public bool? IsTypeAhead { get; set; }

        /// <summary>
        /// Indexes for which extended postal codes should be included in the results.
        /// Available indexes are:
        /// <list type="bullet">
        /// <item><description> <c>Addr</c> - Address ranges </description></item>
        /// <item><description> <c>Geo</c> - Geographies </description></item>
        /// <item><description> <c>PAD</c> - Point Addresses </description></item>
        /// <item><description> <c>POI</c> - Points of Interest </description></item>
        /// <item><description> <c>Str</c> - Streets </description></item>
        /// <item><description> <c>XStr</c> - Cross Streets (intersections) </description></item>
        /// </list>
        /// Value should be a comma separated list of index types (in any order) or <c>null</c> for no indexes.
        /// By default extended postal codes are included for all indexes except Geo. Extended postal code lists for geographies can be quite long so they have to be explicitly requested when needed.
        /// </summary>
        public IEnumerable<SearchIndex> ExtendedPostalCodesFor { get; set; }

        /// <summary>
        /// Specifies the level of filtering performed on geographies. Narrows the search for specified geography entity types, e.g. return only municipality. The resulting response will contain the geography ID as well as the entity type matched. If you provide more than one entity as a comma separated list, endpoint will return the &apos;smallest entity available&apos;. Returned Geometry ID can be used to get the geometry of that geography via <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchpolygon">Get Search Polygon</see> API.
        /// The following parameters are ignored when entityType is set:
        /// <list type="bullet">
        /// <item><description> heading </description></item>
        /// <item><description> number </description></item>
        /// <item><description> returnRoadUse </description></item>
        /// <item><description> returnSpeedLimit </description></item>
        /// <item><description> roadUse </description></item>
        /// <item><description> returnMatchType </description></item>
        /// </list>
        /// </summary>
        public GeographicEntity? EntityType { get; set; }
    }
}
