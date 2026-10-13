// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    /// <summary> Wraps an <c>activity.completed</c> event payload. </summary>
    public sealed class KnowledgeBaseActivityCompletedStreamEvent : KnowledgeBaseRetrievalStreamEvent
    {
        internal KnowledgeBaseActivityCompletedStreamEvent(KnowledgeBaseActivityRecord value)
            : base("activity.completed") => Value = value;

        /// <summary> Gets the event payload. </summary>
        public KnowledgeBaseActivityRecord Value { get; }
    }
}
