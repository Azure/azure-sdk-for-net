// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Maps.TimeZones
{
    /// <summary> Details in effect at the local time. </summary>
    public partial class ReferenceTime
    {
        /// <summary> Initializes a new instance of <see cref="ReferenceTime"/>. </summary>
        /// <param name="tag"> Time zone name in effect at the reference timestamp (i.e. PST or PDT depending whether Daylight Savings Time is in effect). </param>
        /// <param name="standardOffset"> UTC offset in effect at the `ReferenceUTCTimestamp`. </param>
        /// <param name="daylightSavings"> Time saving in minutes in effect at the `ReferenceUTCTimestamp`. </param>
        /// <param name="wallTime"> Current wall time at the given time zone as shown in the `Tag` property. </param>
        /// <param name="posixTzValidYear"> The year this POSIX string is valid for. Note: A POSIX string will only be valid in the given year. </param>
        /// <param name="posixTz"> POSIX string used to set the time zone environment variable. </param>
        /// <param name="sunrise"> Sunrise at the given time zone as shown in the `Tag` property. The sunrise is described in the ISO8601 format. (Only be populated if the call is byCoordinates). </param>
        /// <param name="sunset"> Sunset at the given time zone as shown in the `Tag` property. The sunset is described in the ISO8601 format.(Only be populated if the call is byCoordinates). </param>
        internal ReferenceTime(string tag, string standardOffset, string daylightSavings, string wallTime, int? posixTzValidYear, string posixTz, DateTimeOffset? sunrise, DateTimeOffset? sunset)
        {
            Tag = tag;
            _standardOffset = standardOffset;
            if (TimeSpan.TryParse(standardOffset, out TimeSpan StandardOffsetValue))
            {
                StandardOffset = StandardOffsetValue;
            }

            _daylightSavings = daylightSavings;
            if (TimeSpan.TryParse(daylightSavings, out TimeSpan DaylightSavingsValue))
            {
                DaylightSavingsOffset = DaylightSavingsValue;
            }

            _wallTime = wallTime;
            if (DateTimeOffset.TryParse(wallTime, out DateTimeOffset WallTimeValue))
            {
                WallTime = WallTimeValue;
            }

            PosixTimeZoneValidYear = posixTzValidYear;
            PosixTimeZone = posixTz;
            Sunrise = sunrise;
            Sunset = sunset;
        }

        [CodeGenMember("StandardOffset")]
        internal string _standardOffset { get; }
        /// <summary> UTC offset in <see cref="TimeSpan"/> format in effect at the <c>ReferenceUTCTimestamp</c>. </summary>
        public TimeSpan StandardOffset { get; }

        [CodeGenMember("DaylightSavings")]
        internal string _daylightSavings { get; }
        /// <summary> Time saving in <see cref="TimeSpan"/> format in effect at the <c>ReferenceUTCTimestamp</c>. </summary>
        public TimeSpan DaylightSavingsOffset { get; }

        /// <summary> Current wall time at the given time zone as shown in the <c>Tag</c> property. </summary>
        [CodeGenMember("WallTime")]
        internal string _wallTime { get; }
        /// <summary> Current wall time at the given time zone as shown in the <c>Tag</c> property. </summary>
        public DateTimeOffset WallTime { get; }

        /// <summary> The year this POSIX string is valid for. Note: A POSIX string will only be valid in the given year. </summary>
        [CodeGenMember("PosixTzValidYear")]
        public int? PosixTimeZoneValidYear { get; }
        /// <summary> POSIX string used to set the time zone environment variable. </summary>
        [CodeGenMember("PosixTz")]
        public string PosixTimeZone { get; }
    }
}
