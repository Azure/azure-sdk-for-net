// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public partial class AddressValue
    {
        /// <summary> Apartment or office number. </summary>
        internal string Unit { get; }

        /// <summary> Districts or boroughs within a city, such as Brooklyn in New York City or City of Westminster in London. </summary>
        internal string CityDistrict { get; }

        /// <summary> Second-level administrative division used in certain locales. </summary>
        internal string StateDistrict { get; }

        /// <summary> Unofficial neighborhood name, like Chinatown. </summary>
        internal string Suburb { get; }

        /// <summary> Build name, such as World Trade Center. </summary>
        internal string House { get; }

        /// <summary> Floor number, such as 3F. </summary>
        internal string Level { get; }
    }
}
