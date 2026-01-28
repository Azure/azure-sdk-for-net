// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Renames generated DocumentKeysOrIds to ResetDocumentOptions and customizes property name.
    /// </summary>
    [CodeGenType("ResetDocumentOptions")]
    public partial class ResetDocumentOptions
    {
        /// <summary> DataSource document identifiers to be reset. </summary>
        [CodeGenMember("DatasourceDocumentIds")]
        public IList<string> DataSourceDocumentIds { get; }
    }
}
