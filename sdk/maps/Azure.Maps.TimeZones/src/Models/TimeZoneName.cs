// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Maps.TimeZones
{
    /// <summary> Time zone name object. </summary>
    [CodeGenModel("TimeZoneNames")]
    public partial class TimeZoneName
    {
        /// <summary> The ISO 639-1 language code of the Names. </summary>
        [CodeGenMember("ISO6391LanguageCode")]
        public string Iso6391LanguageCode { get; }
    }
}
