// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class SearchAlias
    {
        [CodeGenMember("etag")]
        private string _etag;

        /// <summary>
        /// The <see cref="Azure.ETag"/> of the <see cref="SearchAlias"/>.
        /// </summary>
        public ETag? ETag
        {
            get => _etag is null ? null : new ETag(_etag);
            set => _etag = value?.ToString();
        }
    }
}
