// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core.GeoJson;

namespace Azure.Maps.Search
{
    /// <summary> Options. </summary>
    public class FuzzySearchOptions: SearchPointOfInterestOptions
    {
        /// <summary> bounding box. </summary>
        public GeoBoundingBox BoundingBox { get; set; }
        /// <summary> Boolean. If the typeahead flag is set, the query will be interpreted as a partial input and the search will enter predictive mode. </summary>
        public bool? IsTypeAhead { get; set; }
        /// <summary>
        /// Hours of operation for a POI (Points of Interest). The availability of hours of operation will vary based on the data available. If not passed, then no opening hours information will be returned.
        /// Supported value: nextSevenDays
        /// </summary>
        public OperatingHoursRange? OperatingHours { get; set; }
        /// <summary>
        /// Specifies the level of filtering performed on geographies. Narrows the search for specified geography entity types, e.g. return only municipality. The resulting response will contain the geography ID as well as the entity type matched. If you provide more than one entity as a comma separated list, endpoint will return the &apos;smallest entity available&apos;. Returned Geometry ID can be used to get the geometry of that geography via <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchpolygon">Get Search Polygon</see> API. The following parameters are ignored when entityType is set:
        /// </summary>
        /// <list type="bullet">
        /// <item><description> heading </description></item>
        /// <item><description> number </description></item>
        /// <item><description> returnRoadUse </description></item>
        /// <item><description> returnSpeedLimit </description></item>
        /// <item><description> roadUse </description></item>
        /// <item><description> returnMatchType </description></item>
        /// </list>
        public GeographicEntity? EntityType { get; set; }
        /// <summary>
        /// Minimum fuzziness level to be used. Default: 1, minimum: 1 and maximum: 4
        /// </summary>
        /// <list type="bullet">
        /// <item><description> Level 1 has no spell checking. </description></item>
        /// <item><description> Level 2 uses normal n-gram spell checking. For example, query &quot;restrant&quot; can be matched to &quot;restaurant.&quot; </description></item>
        /// <item><description> Level 3 uses sound-like spell checking, and shingle spell checking. Sound-like spell checking is for &quot;rstrnt&quot; to &quot;restaurant&quot; matching. Shingle spell checking is for &quot;mountainview&quot; to &quot;mountain view&quot; matching. </description></item>
        /// <item><description> Level 4 doesn’t add any more spell checking functions. </description></item>
        /// </list>
        /// The search engine will start looking for a match on the level defined by minFuzzyLevel, and will stop searching at the level specified by maxFuzzyLevel.
        public int? MinFuzzyLevel { get; set; }
        /// <summary>
        /// Maximum fuzziness level to be used. Default: 2, minimum: 1 and maximum: 4
        /// The search engine will start looking for a match on the level defined by minFuzzyLevel, and will stop searching at the level specified by maxFuzzyLevel.
        /// </summary>
        /// <list type="bullet">
        /// <item><description> Level 1 has no spell checking. </description></item>
        /// <item><description> Level 2 uses normal n-gram spell checking. For example, query &quot;restrant&quot; can be matched to &quot;restaurant.&quot; </description></item>
        /// <item><description> Level 3 uses sound-like spell checking, and shingle spell checking. Sound-like spell checking is for &quot;rstrnt&quot; to &quot;restaurant&quot; matching. Shingle spell checking is for &quot;mountainview&quot; to &quot;mountain view&quot; matching. </description></item>
        /// <item><description> Level 4 doesn’t add any more spell checking functions. </description></item>
        /// </list>
        public int? MaxFuzzyLevel { get; set; }

        /// <summary>
        /// Indexes which should be utilized for the search.
        ///
        /// Available indexes are:
        /// <list type="bullet">
        /// <item><description> <c>Addr</c> - Address ranges </description></item>
        /// <item><description> <c>Geo</c> - Geographies </description></item>
        /// <item><description> <c>PAD</c> - Point Addresses </description></item>
        /// <item><description> <c>POI</c> - Points of Interest </description></item>
        /// <item><description> <c>Str</c> - Streets </description></item>
        /// <item><description> <c>XStr</c> - Cross Streets (intersections) </description></item>
        /// </list>
        ///
        /// Value should be a list of search indices (in any order) or <c>null</c> for no indices.
        /// </summary>
        public IEnumerable<SearchIndex> IndexFilter { get; set; }

        /// <summary>
        /// Indexes for which extended postal codes should be included in the results.
        ///
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
        ///
        /// By default extended postal codes are included for all indexes except Geo. Extended postal code lists for geographies can be quite long so they have to be explicitly requested when needed.
        /// </summary>
        public new IEnumerable<SearchIndex> ExtendedPostalCodesFor { get; set; }
    }
}
