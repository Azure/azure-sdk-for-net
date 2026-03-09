// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("Messages")]
    public partial class ValidationSummaryItem
    {
        /// <summary> Validation messages. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("messages")]
        public IReadOnlyList<PostgreSqlFlexibleServersValidationMessage> Messages { get; }
    }
}
