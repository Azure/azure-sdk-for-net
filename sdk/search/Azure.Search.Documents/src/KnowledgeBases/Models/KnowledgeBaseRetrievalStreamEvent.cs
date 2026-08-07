// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

# pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    /// <summary> Base type for events emitted by a streaming knowledge base retrieval. </summary>
    public abstract class KnowledgeBaseRetrievalStreamEvent
    {
        private protected KnowledgeBaseRetrievalStreamEvent()
        {
        }
    }

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

    /// <summary> An event type not recognized by this version of the client library. </summary>
    public sealed class UnknownKnowledgeBaseRetrievalStreamEvent : KnowledgeBaseRetrievalStreamEvent
    {
        internal UnknownKnowledgeBaseRetrievalStreamEvent(BinaryData data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        /// <summary> Gets the raw JSON payload for the unknown event. </summary>
        public BinaryData Data { get; }
    }

    public partial class KnowledgeBaseRetrievalStartedEvent : KnowledgeBaseRetrievalStreamEvent
    {
    }

    public partial class KnowledgeBaseActivityStartedEvent : KnowledgeBaseRetrievalStreamEvent
    {
    }

    public abstract partial class KnowledgeBaseActivityRecord : KnowledgeBaseRetrievalStreamEvent
    {
    }

    public partial class KnowledgeBaseAnswerCompletedEvent : KnowledgeBaseRetrievalStreamEvent
    {
    }

    public partial class KnowledgeBaseStreamErrorEvent : KnowledgeBaseRetrievalStreamEvent
    {
    }

    public partial class KnowledgeBaseResponseCompletedEvent : KnowledgeBaseRetrievalStreamEvent
    {
    }
}
