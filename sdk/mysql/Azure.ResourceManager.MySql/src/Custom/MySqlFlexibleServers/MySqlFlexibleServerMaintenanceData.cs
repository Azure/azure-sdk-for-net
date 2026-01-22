// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.MySql.FlexibleServers
{
    public partial class MySqlFlexibleServerMaintenanceData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="MySqlFlexibleServerMaintenanceData"/> for deserialization. </summary>
        public MySqlFlexibleServerMaintenanceData()
        {
        }
    }
}
