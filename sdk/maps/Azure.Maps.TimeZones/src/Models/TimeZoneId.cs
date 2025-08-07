// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure.Core;
using Azure.Core.GeoJson;

namespace Azure.Maps.TimeZones
{
    /// <summary> The Time Zone ID. </summary>
    [CodeGenModel("TimezoneId")]
    public partial class TimeZoneId
    {
        /// <summary> Initializes a new instance of <see cref="TimeZoneId"/>. </summary>
        internal TimeZoneId(string id, IReadOnlyList<string> aliases, IReadOnlyList<CountryRecord> countries, TimeZoneName name, ReferenceTime referenceTime, RepresentativePoint representativePoint, IReadOnlyList<TimeTransition> timeTransitions)
        {
            Id = id;
            Aliases = aliases;
            Countries = countries;
            Name = name;
            ReferenceTime = referenceTime;
            _representativePoint = representativePoint;
            if (representativePoint != null && representativePoint.Latitude != null && representativePoint.Longitude != null)
            {
                RepresentativePoint = new GeoPosition(
                    Convert.ToDouble(representativePoint.Longitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(representativePoint.Latitude, CultureInfo.InvariantCulture.NumberFormat)
                );
            }
            TimeTransitions = timeTransitions;
        }

        /// <summary> Representative point property. </summary>
        [CodeGenMember("RepresentativePoint")]
        internal RepresentativePoint _representativePoint { get; }

        /// <summary> Representative point representing a coordinate in <c>GeoPosition</c> format. </summary>
        public GeoPosition RepresentativePoint { get; }

        /// <summary> Time zone name object. </summary>
        [CodeGenMember("Names")]
        public TimeZoneName Name { get; }
    }
}
