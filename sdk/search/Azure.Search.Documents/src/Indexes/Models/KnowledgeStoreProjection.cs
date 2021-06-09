// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("SearchIndexerKnowledgeStoreProjection")]
    public partial class KnowledgeStoreProjection
    {
        /// <summary> Projections to Azure Blob storage. </summary>
        [CodeGenMember("Objects")]
        public IList<KnowledgeStoreObjectProjectionSelector> Blobs { get; }
    }
}
