// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    /// <summary> Wraps a <c>response.completed</c> event payload. </summary>
    public sealed class KnowledgeBaseResponseCompletedStreamEvent : KnowledgeBaseRetrievalStreamEvent
    {
        internal KnowledgeBaseResponseCompletedStreamEvent(KnowledgeBaseResponseCompletedEvent value)
            : base("response.completed") => Value = value;

        /// <summary> Gets the event payload. </summary>
        public KnowledgeBaseResponseCompletedEvent Value { get; }

        /// <inheritdoc />
        public override bool IsTerminal => true;
    }
}
