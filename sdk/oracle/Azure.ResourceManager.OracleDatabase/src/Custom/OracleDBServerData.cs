// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;
using Azure.ResourceManager.OracleDatabase.Models;

namespace Azure.ResourceManager.OracleDatabase
{
    /// <summary>
    /// A class representing the OracleDBServer data model.
    /// DbServer resource model
    /// </summary>
    public partial class OracleDBServerData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="OracleDBServerData"/>. </summary>
        public OracleDBServerData()
        {
        }

        /// <summary> The resource-specific properties for this resource. </summary>
        public OracleDBServerProperties Properties { get; set;  }
    }
}
