// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Maps.Search.Models;

namespace Azure.Maps.Search
{
    /// <summary> Options. </summary>
    public class SearchPointOfInterestOptions: SearchAddressBaseOptions
    {
        /// <summary>
        /// A comma-separated list of category set IDs which could be used to restrict the result to specific Points of Interest categories. ID order does not matter. When multiple category identifiers are provided, only POIs that belong to (at least) one of the categories from the provided list will be returned. The list of supported categories can be discovered using  [POI Categories API](https://aka.ms/AzureMapsPOICategoryTree). Usage examples:
        ///
        /// * **categorySet=7315** (Search Points of Interest from category Restaurant)
        ///
        /// * **categorySet=7315025,7315017** (Search Points of Interest of category either Italian or French Restaurant)
        /// </summary>
        public IEnumerable<int> CategoryFilter { get; set; }
        /// <summary>
        /// A comma-separated list of brand names which could be used to restrict the result to specific brands. Item order does not matter. When multiple brands are provided, only results that belong to (at least) one of the provided list will be returned. Brands that contain a &quot;,&quot; in their name should be put into quotes.
        ///
        /// Usage examples:
        ///
        ///  brandSet=Foo
        ///
        ///  brandSet=Foo,Bar
        ///
        ///  brandSet=&quot;A,B,C Comma&quot;,Bar
        /// </summary>
        public IEnumerable<string> BrandFilter { get; set; }
        /// <summary>
        /// A comma-separated list of connector types which could be used to restrict the result to Electric Vehicle Station supporting specific connector types. Item order does not matter. When multiple connector types are provided, only results that belong to (at least) one of the provided list will be returned.
        ///
        /// Available connector types are:
        ///   * `StandardHouseholdCountrySpecific` - These are the standard household connectors for a certain region. They are all AC single phase and the standard Voltage and standard Amperage. See also: [Plug &amp; socket types - World Standards](https://www.worldstandards.eu/electricity/plugs-and-sockets).
        ///   * `IEC62196Type1` - Type 1 connector as defined in the IEC 62196-2 standard. Also called Yazaki after the original manufacturer or SAE J1772 after the standard that first published it. Mostly used in combination with 120V single phase or up to 240V single phase infrastructure.
        ///   * `IEC62196Type1CCS` - Type 1 based combo connector as defined in the IEC 62196-3 standard. The connector is based on the Type 1 connector – as defined in the IEC 62196-2 standard – with two additional direct current (DC) contacts to allow DC fast charging.
        ///   * `IEC62196Type2CableAttached` - Type 2 connector as defined in the IEC 62196-2 standard. Provided as a cable and plug attached to the charging point.
        ///   * `IEC62196Type2Outlet` - Type 2 connector as defined in the IEC 62196-2 standard. Provided as a socket set into the charging point.
        ///   * `IEC62196Type2CCS` - Type 2 based combo connector as defined in the IEC 62196-3 standard. The connector is based on the Type 2 connector – as defined in the IEC 62196-2 standard – with two additional direct current (DC) contacts to allow DC fast charging.
        ///   * `IEC62196Type3` - Type 3 connector as defined in the IEC 62196-2 standard. Also called Scame after the original manufacturer. Mostly used in combination with up to 240V single phase or up to 420V three phase infrastructure.
        ///   * `Chademo` - CHAdeMO connector named after an association formed by the Tokyo Electric Power Company and industrial partners. Because of this is is also known as the TEPCO&apos;s connector. It supports fast DC charging.
        ///   * `IEC60309AC1PhaseBlue` - Industrial Blue connector is a connector defined in the IEC 60309 standard. It is sometime referred to as by some combination of the standard, the color and the fact that is a single phase connector. The connector usually has the &quot;P+N+E, 6h&quot; configuration.
        ///   * `IEC60309DCWhite` - Industrial White connector is a DC connector defined in the IEC 60309 standard.
        ///   * `Tesla` - The Tesla connector is the regionally specific Tesla Supercharger connector. I.e. it refers to either Tesla&apos;s proprietary connector, sometimes referred to as Tesla Port mostly limited to North America or the modified Type 2 (DC over Type 2) in Europe.
        ///
        /// Usage examples:
        ///
        ///  connectorSet=IEC62196Type2CableAttached
        ///  connectorSet=IEC62196Type2Outlet,IEC62196Type2CableAttached
        /// </summary>
        public IEnumerable<ElectricVehicleConnector> ElectricVehicleConnectorFilter { get; set; }

        /// <summary>
        /// Indexes for which extended postal codes should be included in the results.
        ///
        /// Available indexes are:
        ///
        ///  **POI** = Points of Interest
        ///
        /// Value should be **POI** or **None** to disable extended postal codes.
        ///
        /// By default extended postal codes are included.
        ///
        /// Usage examples:
        ///
        ///  extendedPostalCodesFor=POI
        ///
        ///  extendedPostalCodesFor=None
        ///
        /// Extended postal code is returned as an **extendedPostalCode** property of an address. Availability is region-dependent.
        /// </summary>
        public IEnumerable<PointOfInterestExtendedPostalCodes> ExtendedPostalCodesFor { get; set; }
    }
}
