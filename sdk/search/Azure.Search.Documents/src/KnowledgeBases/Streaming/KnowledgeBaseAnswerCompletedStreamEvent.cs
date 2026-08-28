// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    /// <summary> Wraps an <c>answer.completed</c> event payload. </summary>
    public sealed class KnowledgeBaseAnswerCompletedStreamEvent : KnowledgeBaseRetrievalStreamEvent
    {
        internal KnowledgeBaseAnswerCompletedStreamEvent(KnowledgeBaseAnswerCompletedEvent value)
            : base("answer.completed") => Value = value;

        /// <summary> Gets the event payload. </summary>
        public KnowledgeBaseAnswerCompletedEvent Value { get; }
    }
}
