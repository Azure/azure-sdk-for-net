// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    /// <summary> Wraps a <c>references.completed</c> event payload. </summary>
    public sealed class KnowledgeBaseReferencesCompletedStreamEvent : KnowledgeBaseRetrievalStreamEvent
    {
        internal KnowledgeBaseReferencesCompletedStreamEvent(IReadOnlyList<KnowledgeBaseReference> value)
            : base("references.completed")
        {
            Value = value;
        }

        /// <summary> Gets the event payload. </summary>
        public IReadOnlyList<KnowledgeBaseReference> Value { get; }
    }
}
