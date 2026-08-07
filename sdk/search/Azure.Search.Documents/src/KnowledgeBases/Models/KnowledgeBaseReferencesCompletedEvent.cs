// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    /// <summary> The references used to produce the retrieval response. </summary>
    public sealed class KnowledgeBaseReferencesCompletedEvent : KnowledgeBaseRetrievalStreamEvent
    {
        internal KnowledgeBaseReferencesCompletedEvent(IReadOnlyList<KnowledgeBaseReference> references)
        {
            References = references;
        }

        /// <summary> Gets the references used to produce the retrieval response. </summary>
        public IReadOnlyList<KnowledgeBaseReference> References { get; }
    }
}