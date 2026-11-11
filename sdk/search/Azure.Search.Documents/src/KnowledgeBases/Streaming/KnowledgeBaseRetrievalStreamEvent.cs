// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    /// <summary> Base type for events emitted by a streaming knowledge base retrieval. </summary>
    [CodeGenSuppress("DeserializeKnowledgeBaseRetrievalStreamEvent", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public abstract partial class KnowledgeBaseRetrievalStreamEvent
    {
        private readonly string _eventName;

        private protected KnowledgeBaseRetrievalStreamEvent(string eventName)
        {
            _eventName = eventName;
        }

        /// <summary> Gets the wire name of the server-sent event. </summary>
        public string EventName => _eventName ?? this switch
        {
            KnowledgeBaseRetrievalStartedStreamEvent => "retrieval.started",
            KnowledgeBaseActivityStartedStreamEvent => "activity.started",
            KnowledgeBaseActivityCompletedStreamEvent => "activity.completed",
            KnowledgeBaseAnswerCompletedStreamEvent => "answer.completed",
            KnowledgeBaseReferencesCompletedStreamEvent => "references.completed",
            KnowledgeBaseErrorStreamEvent => "error",
            KnowledgeBaseResponseCompletedStreamEvent => "response.completed",
            _ => throw new InvalidOperationException("The retrieval stream event does not have an event name.")
        };

        /// <summary> Gets whether this event terminates the retrieval stream. </summary>
        public virtual bool IsTerminal => false;

        internal static KnowledgeBaseRetrievalStreamEvent DeserializeKnowledgeBaseRetrievalStreamEvent(
            JsonElement element,
            ModelReaderWriterOptions options) =>
            throw new NotSupportedException("A server-sent event name is required to deserialize a knowledge base retrieval event. Use RetrieveStreamAsync to read typed events.");

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
