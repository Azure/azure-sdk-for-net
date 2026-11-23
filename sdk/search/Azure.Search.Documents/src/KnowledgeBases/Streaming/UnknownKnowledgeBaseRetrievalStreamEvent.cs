// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    /// <summary> An event type not recognized by this version of the client library. </summary>
    public sealed class UnknownKnowledgeBaseRetrievalStreamEvent : KnowledgeBaseRetrievalStreamEvent
    {
        internal UnknownKnowledgeBaseRetrievalStreamEvent(string eventName, BinaryData data)
        {
            EventName = eventName;
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        /// <summary> Gets the wire name of the unrecognized server-sent event. </summary>
        public string EventName { get; }

        /// <summary> Gets the raw JSON payload for the unknown event. </summary>
        public BinaryData Data { get; }
    }
}
