// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Maps.TimeZones
{
    /// <summary> The TimeTransition. </summary>
    public partial class TimeTransition
    {
        /// <summary> Initializes a new instance of <see cref="TimeTransition"/>. </summary>
        /// <param name="tag"> Tag property. </param>
        /// <param name="standardOffset"> StandardOffset property. </param>
        /// <param name="daylightSavings"> DaylightSavings property. </param>
        /// <param name="utcStart"> Start date, start time for this transition period. </param>
        /// <param name="utcEnd"> End date, end time for this transition period. </param>
        internal TimeTransition(string tag, string standardOffset, string daylightSavings, DateTimeOffset? utcStart, DateTimeOffset? utcEnd)
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

            UtcStart = utcStart;
            UtcEnd = utcEnd;
        }

        [CodeGenMember("StandardOffset")]
        internal string _standardOffset { get; }
        /// <summary> UTC offset in <see cref="TimeSpan"/> format in effect at the <c>ReferenceUTCTimestamp</c>. </summary>
        public TimeSpan StandardOffset { get; }

        [CodeGenMember("DaylightSavings")]
        internal string _daylightSavings { get; }
        /// <summary> Time saving in <see cref="TimeSpan"/> format in effect at the <c>ReferenceUTCTimestamp</c>. </summary>
        public TimeSpan DaylightSavingsOffset { get; }
    }
}
