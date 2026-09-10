// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // The TypeSpec property is output-only, but marking it with @visibility(Lifecycle.Read) would be unscoped
    // and affect all emitters. Preserve the previous GA IReadOnlyList type in C# custom code only.
    public partial class DbLevelValidationStatus
    {
        /// <summary> Summary of database level validations. </summary>
        [WirePath("summary")]
        public IReadOnlyList<ValidationSummaryItem> Summary { get; internal set; }
    }
}
