// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;
using Azure.ResourceManager.OracleDatabase.Models;

namespace Azure.ResourceManager.OracleDatabase
{
    /// <summary>
    /// A class representing the OracleDnsPrivateView data model.
    /// DnsPrivateView resource definition
    /// </summary>
    public partial class OracleDnsPrivateViewData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="OracleDnsPrivateViewData"/>. </summary>
        public OracleDnsPrivateViewData()
        {
        }

        /// <summary> The resource-specific properties for this resource. </summary>
        public OracleDnsPrivateViewProperties Properties { get; set; }
    }
}
