// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    /// <summary> Base type for events emitted by a streaming knowledge base retrieval. </summary>
    public abstract class KnowledgeBaseRetrievalStreamEvent
    {
        private protected KnowledgeBaseRetrievalStreamEvent(string eventName)
        {
            EventName = eventName;
        }

        /// <summary> Gets the wire name of the server-sent event. </summary>
        public string EventName { get; }

        /// <summary> Gets whether this event terminates the retrieval stream. </summary>
        public virtual bool IsTerminal => false;

        internal static KnowledgeBaseRetrievalStreamEvent Deserialize(string eventName, BinaryData data)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            JsonElement element = document.RootElement;
            ModelReaderWriterOptions options = ModelSerializationExtensions.WireOptions;

            return eventName switch
            {
                "retrieval.started" => new KnowledgeBaseRetrievalStartedStreamEvent(KnowledgeBaseRetrievalStartedEvent.DeserializeKnowledgeBaseRetrievalStartedEvent(element, options)),
                "activity.started" => new KnowledgeBaseActivityStartedStreamEvent(KnowledgeBaseActivityStartedEvent.DeserializeKnowledgeBaseActivityStartedEvent(element, options)),
                "activity.completed" => new KnowledgeBaseActivityCompletedStreamEvent(KnowledgeBaseActivityRecord.DeserializeKnowledgeBaseActivityRecord(element, options)),
                "answer.completed" => new KnowledgeBaseAnswerCompletedStreamEvent(KnowledgeBaseAnswerCompletedEvent.DeserializeKnowledgeBaseAnswerCompletedEvent(element, options)),
                "references.completed" => new KnowledgeBaseReferencesCompletedStreamEvent(DeserializeReferences(element, options)),
                "error" => new KnowledgeBaseErrorStreamEvent(KnowledgeBaseStreamErrorEvent.DeserializeKnowledgeBaseStreamErrorEvent(element, options)),
                "response.completed" => new KnowledgeBaseResponseCompletedStreamEvent(KnowledgeBaseResponseCompletedEvent.DeserializeKnowledgeBaseResponseCompletedEvent(element, options)),
                _ => new UnknownKnowledgeBaseRetrievalStreamEvent(eventName, data),
            };
        }

        private static IReadOnlyList<KnowledgeBaseReference> DeserializeReferences(
            JsonElement element,
            ModelReaderWriterOptions options)
        {
            if (element.ValueKind != JsonValueKind.Array)
            {
                throw new JsonException("The references.completed event payload must be a JSON array.");
            }

            List<KnowledgeBaseReference> references = new();
            foreach (JsonElement item in element.EnumerateArray())
            {
                references.Add(KnowledgeBaseReference.DeserializeKnowledgeBaseReference(item, options));
            }

            return references;
        }
    }
}
