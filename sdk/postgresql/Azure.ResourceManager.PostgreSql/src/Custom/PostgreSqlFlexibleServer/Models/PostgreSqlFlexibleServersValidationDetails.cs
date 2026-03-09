// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("ServerLevelValidationDetails")]
    [CodeGenSuppress("DbLevelValidationDetails")]
    public partial class PostgreSqlFlexibleServersValidationDetails
    {
        /// <summary> Details of server level validations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("serverLevelValidationDetails")]
        public IReadOnlyList<ValidationSummaryItem> ServerLevelValidationDetails { get; }

        /// <summary> Details of server level validations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("dbLevelValidationDetails")]
        public IReadOnlyList<DbLevelValidationStatus> DbLevelValidationDetails { get; }
    }
}
