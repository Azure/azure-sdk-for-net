// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    /// <summary> Wraps a <c>retrieval.started</c> event payload. </summary>
    public sealed class KnowledgeBaseRetrievalStartedStreamEvent : KnowledgeBaseRetrievalStreamEvent
    {
        internal KnowledgeBaseRetrievalStartedStreamEvent(KnowledgeBaseRetrievalStartedEvent value)
            : base("retrieval.started") => Value = value;

        /// <summary> Gets the event payload. </summary>
        public KnowledgeBaseRetrievalStartedEvent Value { get; }
    }
}
