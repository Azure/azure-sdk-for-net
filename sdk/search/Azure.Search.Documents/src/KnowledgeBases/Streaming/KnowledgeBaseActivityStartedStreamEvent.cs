// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    /// <summary> Wraps an <c>activity.started</c> event payload. </summary>
    public sealed class KnowledgeBaseActivityStartedStreamEvent : KnowledgeBaseRetrievalStreamEvent
    {
        internal KnowledgeBaseActivityStartedStreamEvent(KnowledgeBaseActivityStartedEvent value)
            : base("activity.started") => Value = value;

        /// <summary> Gets the event payload. </summary>
        public KnowledgeBaseActivityStartedEvent Value { get; }
    }
}
