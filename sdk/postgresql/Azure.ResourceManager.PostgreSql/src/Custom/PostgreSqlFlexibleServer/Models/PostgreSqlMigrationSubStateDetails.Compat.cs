// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserve the previous GA IReadOnlyDictionary type for this output-only dictionary property.
    public partial class PostgreSqlMigrationSubStateDetails
    {
        /// <summary> Gets the DbDetails. </summary>
        [CodeGenMember("DbDetails")]
        [WirePath("dbDetails")]
        public IReadOnlyDictionary<string, DbMigrationStatus> DbDetails { get; internal set; }
    }
}
