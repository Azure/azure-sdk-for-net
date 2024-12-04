// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Maps.TimeZones
{
    /// <summary> The Windows time zone to Iana response information. </summary>
    public partial class WindowsTimeZoneData
    {
        /// <summary> Initializes a new instance of <see cref="WindowsTimeZoneData"/>. </summary>
        internal WindowsTimeZoneData(IReadOnlyList<WindowsTimeZone> windowsTimeZones)
        {
            WindowsTimeZones = windowsTimeZones;
        }

        /// <summary> The list of Windows time zones. </summary>
        public IReadOnlyList<WindowsTimeZone> WindowsTimeZones { get; }
    }
}
