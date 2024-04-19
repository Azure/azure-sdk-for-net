// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;

namespace Azure.Maps.Search.Models
{
    public partial class GeocodingBatchRequestItem
    {
        /// <summary>
        /// A rectangular area on the earth defined as a bounding box object. The sides of the rectangles are defined by longitude and latitude values. For more information, see Location and Area Types. When you specify this parameter, the geographical area is taken into account when computing the results of a location query.
        ///
        /// Example: [lon1, lat1, lon2, lat2]
        /// </summary>
        public IList<double> Bbox { get; set; }

        /// <summary> A point on the earth specified as a longitude and latitude. When you specify this parameter, the user’s location is taken into account and the results returned may be more relevant to the user. Example: [lon, lat]. </summary>
        public IList<double> Coordinates { get; set; }
    }
}
