// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // The TypeSpec properties are output-only, but marking them with @visibility(Lifecycle.Read) would be unscoped
    // and affect all emitters. Use CodeGenMember to preserve the previous GA IReadOnlyList types in C# only.
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
