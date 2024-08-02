// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Maps.TimeZone;

namespace Azure.Maps.TimeZone.Models.Options
{
    /// <summary> Options for TimeZone Client. </summary>
    public class TimeZoneBaseOptions
    {
        /// <summary> Specifies the language code in which the timezone names should be returned. Please refer to <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported Languages</see> </summary>
        public string AcceptLanguage { get; set; }

        /// <summary> Options available for types of information returned in the result. </summary>
        public TimeZoneOptions? Options { get; set; }

        /// <summary> Reference time, if omitted, the API will use the machine time serving the request. </summary>
        public DateTimeOffset? TimeStamp { get; set; }

        /// <summary> The start date from which daylight savings time (DST) transitions are requested, only applies when "options" = all or "options" = transitions. </summary>
        public DateTimeOffset? DaylightSavingsTimeFrom { get; set; }

        /// <summary> The number of years from "transitionsFrom" for which DST transitions are requested, only applies when "options" = all or "options" = transitions. </summary>
        public int? DaylightSavingsTimeLastingYears { get; set; }
    }
}
