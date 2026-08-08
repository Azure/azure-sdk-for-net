// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.KnowledgeBases.Models

#pragma warning disable SA1402 // File may only contain a single type
{
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
