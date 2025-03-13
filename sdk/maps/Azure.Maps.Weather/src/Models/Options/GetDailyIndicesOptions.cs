// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetDailyIndicesOptions : WeatherBaseOptions
    {
        /// <summary> Specifies for how long the responses are returned. </summary>
        public int? DurationInDays { get; set; }
        /// <summary> Numeric index identifier that can be used for restricting returned results to the corresponding index type. Cannot be paired with <c>indexGroupId</c>. Please refer to [Weather services in Azure Maps](/azure/azure-maps/weather-services-concepts#index-ids-and-index-groups-ids) for details and to see the supported indices. </summary>
        public int? IndexId { get; set; }
        /// <summary> Numeric index group identifier that can be used for restricting returned results to the corresponding subset of indices (index group). Cannot be paired with `indexId`. Please refer to [Weather services in Azure Maps](/azure/azure-maps/weather-services-concepts#index-ids-and-index-groups-ids) for details and to see the supported index groups. </summary>
        public int? IndexGroupId { get; set; }
    }
}