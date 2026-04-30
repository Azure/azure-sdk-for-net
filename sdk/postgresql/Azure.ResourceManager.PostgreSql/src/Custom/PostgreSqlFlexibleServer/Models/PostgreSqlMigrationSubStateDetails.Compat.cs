// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // The TypeSpec property is output-only, but marking it with @visibility(Lifecycle.Read) would be unscoped
    // and affect all emitters. Use CodeGenMember to preserve the previous GA IReadOnlyDictionary type in C# only.
    public partial class PostgreSqlMigrationSubStateDetails
    {
        /// <summary> Gets the DbDetails. </summary>
        [CodeGenMember("DbDetails")]
        [WirePath("dbDetails")]
        public IReadOnlyDictionary<string, DbMigrationStatus> DbDetails { get; internal set; }
    }
}
