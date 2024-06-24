// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Maps.Timezone.Models.Options
{
    /// <summary> Options. </summary>
    public class TimezoneBaseOptions
    {
        /// <summary> Specifies the language code in which the timezone names should be returned. Please refer to <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported Languages</see> </summary>
        public string AcceptLanguage { get; set; }

        /// <summary> Alternatively, use alias "o". Options available for types of information returned in the result. </summary>
        public TimezoneOptions? Options { get; set; }

        /// <summary> Alternatively, use alias "stamp", or "s". Reference time, if omitted, the API will use the machine time serving the request. </summary>
        public DateTimeOffset? TimeStamp { get; set; }

        /// <summary> Alternatively, use alias "tf". The start date from which daylight savings time (DST) transitions are requested, only applies when "options" = all or "options" = transitions. </summary>
        public DateTimeOffset? DaylightSavingsTimeFrom { get; set; }

        /// <summary> Alternatively, use alias "ty". The number of years from "transitionsFrom" for which DST transitions are requested, only applies when "options" = all or "options" = transitions. </summary>
        public int? DaylightSavingsTimeLastingYears { get; set; }
    }
}
