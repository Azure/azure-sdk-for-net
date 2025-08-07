// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.GeoJson;

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetDailyHistoricalRecordsOptions
    {
        /// <summary> Specifies the coordinates. </summary>
        public GeoPosition Coordinates { get; set; }
        /// <summary> Start date in ISO 8601 format, for example, 2019-10-27. The date range supported is 1 to 31 calendar days, so be sure to specify a startDate and endDate that does not exceed a maximum of 31 days (i.e.: startDate=2012-01-01&amp;endDate=2012-01-31). </summary>
        public DateTimeOffset StartDate { get; set; }
        /// <summary> End date in ISO 8601 format, for example, 2019-10-27. The date range supported is 1 to 31 calendar days, so be sure to specify a startDate and endDate that does not exceed a maximum of 31 days (i.e.: startDate=2012-01-01&amp;endDate=2012-01-31). </summary>
        public DateTimeOffset EndDate { get; set; }
        /// <summary> Specifies to return the data in either metric units or imperial units. </summary>
        public WeatherDataUnit? Unit { get; set; }
    }
}