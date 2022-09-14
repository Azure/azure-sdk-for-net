// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Maps.GeoLocation;

namespace Azure.Maps.GeoLocation
{
    /// <summary> This object is returned from a successful call to IP Address to country/region API. </summary>
    [CodeGenModel("IpAddressToLocationResult")]
    public partial class IpAddressToLocationResult
    {
        /// <summary> Initializes a new instance of IpAddressToLocationResult. </summary>
        internal IpAddressToLocationResult()
        {
        }

        /// <summary> Initializes a new instance of IpAddressToLocationResult. </summary>
        /// <param name="countryRegion"> The object containing the country/region information. </param>
        /// <param name="ipAddress"> The IP Address of the request. </param>
        internal IpAddressToLocationResult(CountryRegion countryRegion, string ipAddress)
        {
            CountryRegion = countryRegion;
            IpAddress = ipAddress;
            IsoCode = countryRegion.IsoCode;
        }

        /// <summary> The object containing the country/region information. </summary>
        [CodeGenMember("CountryRegion")]
        internal CountryRegion CountryRegion { get; }
        /// <summary> The IP Address's 2-character code <see href="https://www.iso.org/iso-3166-country-codes.html">(ISO 3166-1)</see> of the country or region. Please note, IP address in ranges reserved for special purpose will return Null for country/region. </summary>
        public string IsoCode { get; }

        /// <summary> The IP Address of the request. </summary>
        public string IpAddress { get; }
    }
}
