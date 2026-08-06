// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Net;

namespace Azure.Maps.Geolocation
{
    /// <summary> Model factory for models. </summary>
    public static partial class MapsGeolocationModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="CountryRegionResult"/> for mocking. </summary>
        /// <param name="isoCode"> The IP Address's 2-character code (ISO 3166-1) of the country or region. </param>
        /// <param name="ipAddress"> The IP Address of the request. </param>
        /// <returns> A new <see cref="CountryRegionResult"/> instance for mocking. </returns>
        public static CountryRegionResult CountryRegionResult(string isoCode = null, IPAddress ipAddress = null)
        {
            return new CountryRegionResult(isoCode, ipAddress);
        }
    }
}
