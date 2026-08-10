// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // The TypeSpec properties are output-only, but marking them with @visibility(Lifecycle.Read) would be unscoped
    // and affect all emitters. Preserve the previous GA IReadOnlyList types in C# custom code only.
    public partial class PostgreSqlFlexibleServersValidationDetails
    {
        /// <summary> Details of server level validations. </summary>
        [WirePath("serverLevelValidationDetails")]
        public IReadOnlyList<ValidationSummaryItem> ServerLevelValidationDetails { get; internal set; }

        /// <summary> Details of server level validations. </summary>
        [WirePath("dbLevelValidationDetails")]
        public IReadOnlyList<DbLevelValidationStatus> DbLevelValidationDetails { get; internal set; }
    }
}
