// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MySql.FlexibleServers.Models
{
    /// <summary> Represents a logFile. </summary>
    [CodeGenModel(Usage = new[] { "input" })]
    public partial class MySqlFlexibleServerLogFile : ResourceData
    {
    }
}
