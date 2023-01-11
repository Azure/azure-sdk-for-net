// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Maps.Search
{
    /// <summary> Options for Reverse Search API. </summary>
    public class ReverseSearchOptions: ReverseSearchBaseOptions
    {
        /// <summary> Boolean. To enable return of the posted speed limit. </summary>
        public bool? IncludeSpeedLimit { get; set; }

        /// <summary> Boolean. To enable return of the road use array for reverse geocodes at street level. </summary>
        public bool? IncludeRoadUse { get; set; }

        /// <summary> Include information on the type of match the geocoder achieved in the response. </summary>
        public bool? IncludeMatchType { get; set; }

        /// <summary> Street number. If a number is sent in along with the request, the response may include the side of the street (Left/Right) and also an offset position for that number. </summary>
        public int? StreetNumber { get; set; }

        /// <summary> To restrict reverse geocodes to a certain type of road use. The road use array for reverse geocodes can be one or more of LimitedAccess, Arterial, Terminal, Ramp, Rotary, LocalStreet. </summary>
        public IEnumerable<RoadKind> RoadUse { get; set; }

        /// <summary>
        /// Format of newlines in the formatted address.
        ///
        /// If <c>true</c>, the address will contain newlines.
        /// If <c>false</c>, newlines will be converted to commas.
        /// </summary>
        public bool? AllowFreeformNewline { get; set; }

        /// <summary>
        /// Specifies the level of filtering performed on geographies. Narrows the search for specified geography entity types, e.g. return only municipality. The resulting response will contain the geography ID as well as the entity type matched. If you provide more than one entity as a comma separated list, endpoint will return the &apos;smallest entity available&apos;. Returned Geometry ID can be used to get the geometry of that geography via <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchpolygon">Get Search Polygon</see> API. The following parameters are ignored when entityType is set:
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
    }
}
