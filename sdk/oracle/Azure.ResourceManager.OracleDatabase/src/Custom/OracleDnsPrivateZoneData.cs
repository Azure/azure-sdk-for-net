// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;
using Azure.ResourceManager.OracleDatabase.Models;

namespace Azure.ResourceManager.OracleDatabase
{
    /// <summary>
    /// A class representing the OracleDnsPrivateZone data model.
    /// DnsPrivateZone resource definition
    /// </summary>
    public partial class OracleDnsPrivateZoneData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="OracleDnsPrivateZoneData"/>. </summary>
        public OracleDnsPrivateZoneData()
        {
        }

        /// <summary> The resource-specific properties for this resource. </summary>
        public OracleDnsPrivateZoneProperties Properties { get; set; }
    }
}
