// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Globalization;

namespace Azure.Maps.Search.Models
{
    /// <summary> The classification for the POI being returned. </summary>
    [CodeGenModel("OperatingHoursTimeRange")]
    public partial class OperatingHoursTimeRange
    {
        [CodeGenMember("StartTime")]
        internal OperatingHoursTime RawStartTime { get; }

        [CodeGenMember("EndTime")]
        internal OperatingHoursTime RawEndTime { get; }

        /// <summary> The point in the next 7 days range when a given POI is being opened, or the beginning of the range if it was opened before the range. </summary>
        public DateTimeOffset StartTime {
            get {
                var dateTime = DateTime.ParseExact(RawStartTime.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                return new DateTimeOffset(
                    year: dateTime.Year,
                    month: dateTime.Month,
                    day: dateTime.Day,
                    hour: RawStartTime.Hour ?? 0,
                    minute: RawStartTime.Minute ?? 0,
                    second: 0,
                    millisecond: 0,
                    offset: TimeSpan.Zero
                );
            }
        }

        /// <summary> The point in the next 7 days range when a given POI is being closed, or the beginning of the range if it was closed before the range. </summary>
        public DateTimeOffset EndTime {
            get {
                var dateTime = DateTime.ParseExact(RawEndTime.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                return new DateTimeOffset(
                    year: dateTime.Year,
                    month: dateTime.Month,
                    day: dateTime.Day,
                    hour: RawEndTime.Hour ?? 0,
                    minute: RawEndTime.Minute ?? 0,
                    second: 0,
                    millisecond: 0,
                    offset: TimeSpan.Zero
                );
            }
        }
    }
}
