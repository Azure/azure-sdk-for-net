// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetTropicalStormSearchOptions
    {
        /// <summary> Year of the cyclone(s). </summary>
        public int Year { get; set; }
        /// <summary> Basin identifier. Allowed values: "AL" | "EP" | "SI" | "NI" | "CP" | "NP" | "SP". </summary>
        public BasinId BasinId { get; set; }
        /// <summary> Government storm Id. </summary>
        public int GovernmentStormId { get; set; }
    }
}