// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MySql.FlexibleServers
{
    /// <summary>
    /// A class representing the MySqlFlexibleServerBackup data model.
    /// Server backup properties
    /// </summary>
    [CodeGenModel(Usage = new[] { "input" })]
    public partial class MySqlFlexibleServerBackupData : ResourceData
    {
    }
}
