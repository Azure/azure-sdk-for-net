// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("DbDetails")]
    public partial class PostgreSqlMigrationSubStateDetails
    {
        /// <summary> Dictionary of &lt;DbMigrationStatus&gt;. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("dbDetails")]
        public IReadOnlyDictionary<string, DbMigrationStatus> DbDetails
        {
            get => (IReadOnlyDictionary<string, DbMigrationStatus>)DbDetailsInternal;
        }

        internal IDictionary<string, DbMigrationStatus> DbDetailsInternal { get; }
    }
}
