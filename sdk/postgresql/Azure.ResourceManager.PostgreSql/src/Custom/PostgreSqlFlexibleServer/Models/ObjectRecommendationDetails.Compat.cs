// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("IndexColumns")]
    [CodeGenSuppress("IncludedColumns")]
    public partial class ObjectRecommendationDetails
    {
        /// <summary> Columns of the index. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("indexColumns")]
        public IReadOnlyList<string> IndexColumns
        {
            get => (IReadOnlyList<string>)IndexColumnsInternal;
        }

        internal IList<string> IndexColumnsInternal { get; }

        /// <summary> Included columns of the index. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("includedColumns")]
        public IReadOnlyList<string> IncludedColumns
        {
            get => (IReadOnlyList<string>)IncludedColumnsInternal;
        }

        internal IList<string> IncludedColumnsInternal { get; }
    }
}
