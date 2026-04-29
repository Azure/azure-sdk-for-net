// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserves the previous IReadOnlyList API shape while keeping the generated mutable list for serialization.
    [CodeGenSuppress("Summary")]
    public partial class DbLevelValidationStatus
    {
        /// <summary> Summary of database level validations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("summary")]
        public IReadOnlyList<ValidationSummaryItem> Summary
        {
            get => (IReadOnlyList<ValidationSummaryItem>)SummaryInternal;
        }

        [CodeGenMember("Summary")]
        internal IList<ValidationSummaryItem> SummaryInternal { get; }
    }
}
