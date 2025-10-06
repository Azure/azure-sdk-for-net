// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Maps.TimeZones;

namespace Azure.Maps.TimeZones
{
    /// <summary> Options for TimeZone Client. </summary>
    public class GetTimeZoneOptions
    {
        /// <summary> Specifies the language code in which the timezone names should be returned. Please refer to <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported Languages</see> </summary>
        public string AcceptLanguage { get; set; }

        /// <summary> Options available for types of additional information returned in the result. </summary>
        public AdditionalTimeZoneReturnInformation? AdditionalTimeZoneReturnInformation { get; set; }

        /// <summary> Reference time, if omitted, the API will use the machine time serving the request. </summary>
        public DateTimeOffset? TimeStamp { get; set; }

        /// <summary> The start date from which daylight savings time (DST) transitions are requested, only applies when "options" = all or "options" = transitions. </summary>
        public DateTimeOffset? DaylightSavingsTimeTransitionFrom { get; set; }

        /// <summary> The number of years from "transitionsFrom" for which DST transitions are requested, only applies when "options" = all or "options" = transitions. </summary>
        public int? DaylightSavingsTimeTransitionInYears { get; set; }
    }
}
