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
