// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("IndexColumns")]
    [CodeGenSuppress("IncludedColumns")]
    public partial class ObjectRecommendationDetails
    {
        /// <summary> Index columns. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("indexColumns")]
        public IReadOnlyList<string> IndexColumns { get; private set; } = new ChangeTrackingList<string>();

        /// <summary> Index included columns. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("includedColumns")]
        public IReadOnlyList<string> IncludedColumns { get; private set; } = new ChangeTrackingList<string>();
    }
}
