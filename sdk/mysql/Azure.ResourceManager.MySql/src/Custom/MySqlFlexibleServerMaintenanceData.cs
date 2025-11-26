// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MySql.FlexibleServers
{
    /// <summary>
    /// A class representing the MySqlFlexibleServerMaintenance data model.
    /// Represents a maintenance.
    /// </summary>
    [CodeGenModel(Usage = new[] { "input" })]
    public partial class MySqlFlexibleServerMaintenanceData : ResourceData
    {
    }
}
