// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;

namespace Azure.Maps.TimeZones
{
    /// <summary> Model factory for models. </summary>
    public static partial class MapsTimeZonesModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="WindowsTimeZoneData"/> for mocking. </summary>
        /// <param name="windowsTimeZones"> The list of Windows time zones. </param>
        /// <returns> A new <see cref="WindowsTimeZoneData"/> instance for mocking. </returns>
        public static WindowsTimeZoneData WindowsTimeZoneData(IEnumerable<WindowsTimeZone> windowsTimeZones = null)
        {
            windowsTimeZones ??= new List<WindowsTimeZone>();
            return new WindowsTimeZoneData(windowsTimeZones.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="IanaIdData"/> for mocking. </summary>
        /// <param name="ianaIds"> The list of IANA IDs. </param>
        /// <returns> A new <see cref="IanaIdData"/> instance for mocking. </returns>
        public static IanaIdData IanaIdData(IEnumerable<IanaId> ianaIds = null)
        {
            ianaIds ??= new List<IanaId>();
            return new IanaIdData(ianaIds.ToList());
        }
    }
}
