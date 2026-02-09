// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public abstract partial class KnowledgeSource
    {
        [CodeGenMember("ETag")]
        private string _eTag;

        /// <summary>
        /// The <see cref="Azure.ETag"/> of the <see cref="KnowledgeSource"/>.
        /// </summary>
        public ETag? ETag
        {
            get => _eTag is null ? (ETag?)null : new ETag(_eTag);
            set => _eTag = value?.ToString();
        }
    }
}
