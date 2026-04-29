// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserves the previous IReadOnlyList message property.
    [CodeGenSuppress("Messages")]
    public partial class ValidationSummaryItem
    {
        /// <summary> Validation messages. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("messages")]
        public IReadOnlyList<PostgreSqlFlexibleServersValidationMessage> Messages
        {
            get => (IReadOnlyList<PostgreSqlFlexibleServersValidationMessage>)MessagesInternal;
        }

        [CodeGenMember("Messages")]
        internal IList<PostgreSqlFlexibleServersValidationMessage> MessagesInternal { get; }
    }
}
