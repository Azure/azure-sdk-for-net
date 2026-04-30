// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserve the previous GA IReadOnlyList type for this output-only collection property.
    public partial class ValidationSummaryItem
    {
        /// <summary> Validation messages. </summary>
        [CodeGenMember("Messages")]
        [WirePath("messages")]
        public IReadOnlyList<PostgreSqlFlexibleServersValidationMessage> Messages { get; internal set; }
    }
}
