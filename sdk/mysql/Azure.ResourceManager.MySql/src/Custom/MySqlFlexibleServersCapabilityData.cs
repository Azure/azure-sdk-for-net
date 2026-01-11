// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MySql.FlexibleServers
{
    /// <summary>
    /// A class representing the MySqlFlexibleServersCapability data model.
    /// Represents a location capability set.
    /// </summary>
    [CodeGenModel(Usage = new[] { "input" })]
    public partial class MySqlFlexibleServersCapabilityData : ResourceData
    {
    }
}
