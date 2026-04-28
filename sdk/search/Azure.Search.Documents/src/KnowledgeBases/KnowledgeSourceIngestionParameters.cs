// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    public partial class KnowledgeSourceIngestionParameters
    {
        /// <summary>
        /// Optional list of permission types to ingest together with document content.
        /// If specified, it will set the indexer permission options for the data source.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("IngestionPermissionOptions is no longer supported. This property is retained for backward compatibility only.")]
        public IList<KnowledgeSourceIngestionPermissionOption> IngestionPermissionOptions { get; set; } = new List<KnowledgeSourceIngestionPermissionOption>();
    }
}
