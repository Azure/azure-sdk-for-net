// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class SearchIndexerSkillset
    {
        [CodeGenMember("etag")]
        private string _etag;

        /// <summary>
        /// The <see cref="Azure.ETag"/> of the <see cref="SearchIndexerSkillset"/>.
        /// </summary>
        public ETag? ETag
        {
            get => _etag is null ? (ETag?)null : new ETag(_etag);
            set => _etag = value?.ToString();
        }

        /// <summary> A list of skills in the skillset. </summary>
        public IList<SearchIndexerSkill> Skills { get; }
    }
}
