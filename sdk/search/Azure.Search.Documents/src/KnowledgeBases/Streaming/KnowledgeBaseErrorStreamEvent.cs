// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    /// <summary> Wraps an <c>error</c> event payload. </summary>
    public sealed class KnowledgeBaseErrorStreamEvent : KnowledgeBaseRetrievalStreamEvent
    {
        internal KnowledgeBaseErrorStreamEvent(KnowledgeBaseStreamErrorEvent value)
            : base("error") => Value = value;

        /// <summary> Gets the event payload. </summary>
        public KnowledgeBaseStreamErrorEvent Value { get; }

        /// <inheritdoc />
        public override bool IsTerminal => true;
    }
}
