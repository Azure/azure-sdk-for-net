// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class SearchIndexerSkillset
    {
        [CodeGenMember("ETag")]
        private string _etag;

        /// <summary>
        /// The <see cref="global::Azure.ETag"/> of the <see cref="SearchIndexerSkillset"/>.
        /// </summary>
        public ETag? ETag
        {
            get => _etag is null ? (ETag?)null : new ETag(_etag);
            set => _etag = value?.ToString();
        }
    }
}
