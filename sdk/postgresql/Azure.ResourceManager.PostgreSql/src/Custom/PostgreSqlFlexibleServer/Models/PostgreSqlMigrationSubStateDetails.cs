// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("DbDetails")]
    public partial class PostgreSqlMigrationSubStateDetails
    {
        /// <summary> Gets the DbDetails. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("dbDetails")]
        public IReadOnlyDictionary<string, DbMigrationStatus> DbDetails { get; }
    }
}
