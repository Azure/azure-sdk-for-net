// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserve the previous GA IReadOnlyList types for these output-only collection properties.
    public partial class PostgreSqlFlexibleServersValidationDetails
    {
        /// <summary> Details of server level validations. </summary>
        [CodeGenMember("ServerLevelValidationDetails")]
        [WirePath("serverLevelValidationDetails")]
        public IReadOnlyList<ValidationSummaryItem> ServerLevelValidationDetails { get; internal set; }

        /// <summary> Details of server level validations. </summary>
        [CodeGenMember("DbLevelValidationDetails")]
        [WirePath("dbLevelValidationDetails")]
        public IReadOnlyList<DbLevelValidationStatus> DbLevelValidationDetails { get; internal set; }
    }
}
