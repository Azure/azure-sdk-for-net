// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    public partial class OracleDnsPrivateZoneProperties
    {
        /// <summary> Initializes a new instance of <see cref="OracleDnsPrivateZoneProperties"/>. </summary>
        /// <param name="ocid"> The OCID of the Zone. </param>
        /// <param name="isProtected"> A Boolean flag indicating whether or not parts of the resource are unable to be explicitly managed. </param>
        /// <param name="self"> The canonical absolute URL of the resource. </param>
        /// <param name="serial"> The current serial of the zone. As seen in the zone's SOA record. </param>
        /// <param name="version"> Version is the never-repeating, totally-orderable, version of the zone, from which the serial field of the zone's SOA record is derived. </param>
        /// <param name="zoneType"> The type of the zone. Must be either PRIMARY or SECONDARY. SECONDARY is only supported for GLOBAL zones. </param>
        /// <param name="createdOn"> Zones timeCreated. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future release", false)]
        public OracleDnsPrivateZoneProperties(ResourceIdentifier ocid, bool isProtected, string self, int serial, string version, OracleDnsPrivateZoneType zoneType, DateTimeOffset createdOn)
        {
            IsProtected = isProtected;
            Self = self ?? throw new ArgumentNullException(nameof(self));
            Serial = serial;
            Version = version ?? throw new ArgumentNullException(nameof(version));
            ZoneType = zoneType;
            CreatedOn = createdOn;
        }

        /// <summary> Zones lifecycleState. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsPrivateZonesLifecycleState? LifecycleState { get; }
        /// <summary> The OCID of the Zone. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Ocid { get => new ResourceIdentifier(ZoneOcid); }
        /// <summary> The OCID of the private view containing the zone. This value will be null for zones in the global DNS, which are publicly resolvable and not part of a private view. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ViewId { get => new ResourceIdentifier(ViewOcid); }
    }
}
