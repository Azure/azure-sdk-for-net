// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary> The KnowledgeAgent. </summary>
    public partial class KnowledgeAgent
    {
        [CodeGenMember("ETag")]
        private string _eTag;

        /// <summary>
        /// The <see cref="Azure.ETag"/> of the <see cref="KnowledgeAgent"/>.
        /// </summary>
        public ETag? ETag
        {
            get => _eTag is null ? (ETag?)null : new ETag(_eTag);
            set => _eTag = value?.ToString();
        }
    }
}
