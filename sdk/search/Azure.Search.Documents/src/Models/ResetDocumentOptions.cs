// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    [CodeGenModel("DocumentKeysOrIds")]
    public partial class ResetDocumentOptions
    {
        /// <summary> DataSource document identifiers to be reset. </summary>
        [CodeGenMember("DatasourceDocumentIds")]
        public IList<string> DataSourceDocumentIds { get; }
    }
}
