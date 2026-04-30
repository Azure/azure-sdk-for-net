// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserve the previous GA IReadOnlyList types for these output-only collection properties.
    public partial class ObjectRecommendationDetails
    {
        /// <summary> Index columns. </summary>
        [CodeGenMember("IndexColumns")]
        [WirePath("indexColumns")]
        public IReadOnlyList<string> IndexColumns { get; internal set; }

        /// <summary> Index included columns. </summary>
        [CodeGenMember("IncludedColumns")]
        [WirePath("includedColumns")]
        public IReadOnlyList<string> IncludedColumns { get; internal set; }
    }
}
