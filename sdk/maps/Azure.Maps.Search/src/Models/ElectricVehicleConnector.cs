// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Maps.Search
{
    /// <summary> The ElectricVehicleConnector. </summary>
    [CodeGenModel("ElectricVehicleConnector")]
    public readonly partial struct ElectricVehicleConnector : IEquatable<ElectricVehicleConnector>
    {
        /// <summary>
        /// These are the standard household connectors for a certain region. They are all AC single phase and the standard Voltage and standard Amperage.
        /// See also: [Plug &amp; socket types - World Standards](https://www.worldstandards.eu/electricity/plugs-and-sockets)
        /// </summary>
        /// <summary> Type 1 connector as defined in the IEC 62196-2 standard. Also called Yazaki after the original manufacturer or SAE J1772 after the standard that first published it. Mostly used in combination with 120V single phase or up to 240V single phase infrastructure. </summary>
        [CodeGenMember("IEC62196Type1")]
        public static ElectricVehicleConnector Iec62196Type1 { get; } = new ElectricVehicleConnector(Iec62196Type1Value);
        /// <summary> Type 1 based combo connector as defined in the IEC 62196-3 standard. The connector is based on the Type 1 connector – as defined in the IEC 62196-2 standard – with two additional direct current (DC) contacts to allow DC fast charging. </summary>
        [CodeGenMember("IEC62196Type1CCS")]
        public static ElectricVehicleConnector Iec62196Type1CCS { get; } = new ElectricVehicleConnector(Iec62196Type1CCSValue);
        /// <summary> Type 2 connector as defined in the IEC 62196-2 standard. Provided as a cable and plug attached to the charging point. </summary>
        [CodeGenMember("IEC62196Type2CableAttached")]
        public static ElectricVehicleConnector Iec62196Type2CableAttached { get; } = new ElectricVehicleConnector(Iec62196Type2CableAttachedValue);
        /// <summary> Type 2 connector as defined in the IEC 62196-2 standard. Provided as a socket set into the charging point. </summary>
        [CodeGenMember("IEC62196Type2Outlet")]
        public static ElectricVehicleConnector Iec62196Type2Outlet { get; } = new ElectricVehicleConnector(Iec62196Type2OutletValue);
        /// <summary> Type 2 based combo connector as defined in the IEC 62196-3 standard. The connector is based on the Type 2 connector – as defined in the IEC 62196-2 standard – with two additional direct current (DC) contacts to allow DC fast charging. </summary>
        [CodeGenMember("IEC62196Type2CCS")]
        public static ElectricVehicleConnector Iec62196Type2CCS { get; } = new ElectricVehicleConnector(Iec62196Type2CCSValue);
        /// <summary> Type 3 connector as defined in the IEC 62196-2 standard. Also called Scame after the original manufacturer. Mostly used in combination with up to 240V single phase or up to 420V three phase infrastructure. </summary>
        [CodeGenMember("IEC62196Type3")]
        public static ElectricVehicleConnector Iec62196Type3 { get; } = new ElectricVehicleConnector(Iec62196Type3Value);
        /// <summary> Industrial Blue connector is a connector defined in the IEC 60309 standard. It is sometime referred to as by some combination of the standard, the color and the fact that is a single phase connector. The connector usually has the &quot;P+N+E, 6h&quot; configuration. </summary>
        [CodeGenMember("IEC60309AC1PhaseBlue")]
        public static ElectricVehicleConnector Iec60309AC1PhaseBlue { get; } = new ElectricVehicleConnector(Iec60309AC1PhaseBlueValue);
        /// <summary> Industrial White connector is a DC connector defined in the IEC 60309 standard. </summary>
        [CodeGenMember("IEC60309DCWhite")]
        public static ElectricVehicleConnector Iec60309DCWhite { get; } = new ElectricVehicleConnector(Iec60309DCWhiteValue);
    }
}
