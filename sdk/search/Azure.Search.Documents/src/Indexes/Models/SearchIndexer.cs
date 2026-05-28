// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class SearchIndexer
    {
        [CodeGenMember("ETag")]
        private string _etag;

        /// <summary>
        /// The <see cref="Azure.ETag"/> of the <see cref="SearchIndexer"/>.
        /// </summary>
        public ETag? ETag
        {
            get => _etag is null ? (ETag?)null : new ETag(_etag);
            set => _etag = value?.ToString();
        }

        /// <summary> Defines mappings between fields in the data source and corresponding target fields in the index. </summary>
        public IList<FieldMapping> FieldMappings { get; }

        /// <summary> Output field mappings are applied after enrichment and immediately before indexing. </summary>
        public IList<FieldMapping> OutputFieldMappings { get; }
    }
}
