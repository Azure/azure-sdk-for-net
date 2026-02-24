// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    /// <summary>
    /// Shared helpers used across unit tests for crafting minimal server event JSON payloads and
    /// performing common JSON assertions.
    /// </summary>
    public static class TestUtilities
    {
        private static readonly JsonSerializerOptions s_defaultJsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null,
            WriteIndented = false
        };

        /// <summary>
        /// Builds a JSON string representing a generic server event: {"type":"<paramref name="type"/>", ... }.
        /// Any additional properties defined on <paramref name="anonymousPayloadExtra"/> are merged into the
        /// top-level object. Properties named "type" in the extra object are ignored to avoid collisions.
        /// </summary>
        /// <param name="type">The event type value.</param>
        /// <param name="anonymousPayloadExtra">An anonymous object supplying additional properties (may be null).</param>
        /// <returns>The merged JSON string.</returns>
        public static string BuildServerEvent(string type, object anonymousPayloadExtra)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            using var ms = new MemoryStream();
            using (var writer = new Utf8JsonWriter(ms, new JsonWriterOptions { Indented = false }))
            {
                writer.WriteStartObject();
                writer.WriteString("type", type);

                if (anonymousPayloadExtra != null)
                {
                    // Serialize the extra object then merge its top-level properties.
                    var extraJson = JsonSerializer.SerializeToUtf8Bytes(anonymousPayloadExtra, s_defaultJsonOptions);
                    using var extraDoc = JsonDocument.Parse(extraJson);
                    if (extraDoc.RootElement.ValueKind == JsonValueKind.Object)
                    {
                        foreach (var prop in extraDoc.RootElement.EnumerateObject())
                        {
                            if (prop.NameEquals("type"))
                            {
                                continue; // Preserve the explicit type parameter.
                            }
                            prop.WriteTo(writer);
                        }
                    }
                    else
                    {
                        // If the extra payload isn't an object, expose it as a property named "payload".
                        writer.WritePropertyName("payload");
                        extraDoc.RootElement.WriteTo(writer);
                    }
                }

                writer.WriteEndObject();
            }
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        /// <summary>
        /// Constructs a minimal valid session.created server event JSON payload.
        /// Schema: {"type":"session.created","session":{"id":"<paramref name="sessionId"/>"}}
        /// </summary>
        /// <param name="sessionId">The session identifier (defaults to "session-123").</param>
        public static string BuildSessionCreatedEvent(string sessionId = "session-123")
        {
            if (sessionId == null) throw new ArgumentNullException(nameof(sessionId));
            return "{\"type\":\"session.created\",\"session\":{\"id\":\"{EscapeString(sessionId)}\"}}";
        }

        /// <summary>
        /// Constructs a minimal response.audio.delta event.
        /// Schema: {"type":"response.audio.delta","delta":"<paramref name="base64Audio"/>"}
        /// </summary>
        public static string BuildResponseAudioDeltaEvent(string base64Audio = "AAAA")
        {
            if (base64Audio == null) throw new ArgumentNullException(nameof(base64Audio));
            return "{\"type\":\"response.audio.delta\",\"delta\":\"{EscapeString(base64Audio)}\"}";
        }

        /// <summary>
        /// Constructs a response.function_call.arguments.done event.
        /// Schema: {"type":"response.function_call.arguments.done","name":"<paramref name="name"/>","call_id":"<paramref name="callId"/>","arguments":"<paramref name="argumentsJson"/>"}
        /// </summary>
        /// <param name="name">The function name.</param>
        /// <param name="callId">The function call identifier.</param>
        /// <param name="argumentsJson">The raw JSON string (kept as a literal string value in the payload).</param>
        public static string BuildResponseFunctionCallArgumentsDoneEvent(string name, string callId, string argumentsJson)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (callId == null) throw new ArgumentNullException(nameof(callId));
            if (argumentsJson == null) throw new ArgumentNullException(nameof(argumentsJson));
            return $"{{\"type\":\"response.function_call_arguments.done\",\"name\":\"{EscapeString(name)}\",\"call_id\":\"{EscapeString(callId)}\",\"arguments\":\"{EscapeString(argumentsJson)}\"}}";
        }

        /// <summary>
        /// Constructs a minimal assistant message output item added event.
        /// Sample structure:
        /// {
        ///   "type":"response.output_item.added",
        ///   "response_id":"<responseId>",
        ///   "item":{
        ///       "id":"<itemId>",
        ///       "type":"message",
        ///       "role":"assistant",
        ///       "content":[]
        ///   }
        /// }
        /// </summary>
        /// <param name="itemId">The output item id.</param>
        /// <param name="responseId">The response id to associate.</param>
        public static string BuildResponseOutputItemAdded_AssistantMessage(string itemId, string responseId)
        {
            if (itemId == null) throw new ArgumentNullException(nameof(itemId));
            if (responseId == null) throw new ArgumentNullException(nameof(responseId));
            return "{\"type\":\"response.output_item.added\",\"response_id\":\"{EscapeString(responseId)}\",\"item\":{\"id\":\"{EscapeString(itemId)}\",\"type\":\"message\",\"role\":\"assistant\",\"content\":[]}}";
        }

        /// <summary>
        /// Parses a collection of JSON textual payloads into a list of <see cref="JsonDocument"/> instances for assertion.
        /// Caller is responsible for disposing the returned documents when finished (tests can rely on teardown).
        /// </summary>
        /// <param name="messages">Enumerable of JSON strings.</param>
        public static List<JsonDocument> ParseSentPayloads(IEnumerable<string> messages)
        {
            if (messages == null) throw new ArgumentNullException(nameof(messages));
            var docs = new List<JsonDocument>();
            foreach (var m in messages)
            {
                if (string.IsNullOrWhiteSpace(m))
                {
                    continue; // Skip empty frames.
                }
                docs.Add(JsonDocument.Parse(m));
            }
            return docs;
        }

        /// <summary>
        /// Asserts that the supplied JSON element contains a property specified by a dotted path (e.g. "session.id").
        /// Each segment must correspond to an object property (arrays are not traversed by this helper).
        /// </summary>
        /// <param name="root">The root JSON element.</param>
        /// <param name="dottedPath">Dot-delimited property path.</param>
        public static void AssertJsonHasProperty(JsonElement root, string dottedPath)
        {
            if (dottedPath == null) throw new ArgumentNullException(nameof(dottedPath));
            var segments = dottedPath.Split(new char[] {'.'},StringSplitOptions.RemoveEmptyEntries );
            if (segments.Length == 0)
            {
                Assert.Fail("Path must contain at least one segment.");
            }

            JsonElement current = root;
            var traversed = new List<string>();
            foreach (var segment in segments)
            {
                traversed.Add(segment);
                if (current.ValueKind != JsonValueKind.Object)
                {
                    Assert.Fail($"Segment '{segment}' expected an object at path '{string.Join(".", traversed.Take(traversed.Count - 1))}' but found {current.ValueKind}.");
                }
                if (!current.TryGetProperty(segment, out var next))
                {
                    var available = string.Join(",", current.EnumerateObject().Select(p => p.Name));
                    Assert.Fail($"Property '{segment}' not found at path '{string.Join(".", traversed.Take(traversed.Count - 1))}'. Available: [{available}]");
                }
                current = next;
            }
        }

        /// <summary>
        /// Returns the top-level "type" property value if present; otherwise null.
        /// </summary>
        public static string? GetTopLevelType(JsonElement root)
        {
            if (root.ValueKind == JsonValueKind.Object && root.TryGetProperty("type", out var val) && val.ValueKind == JsonValueKind.String)
            {
                return val.GetString();
            }
            return null;
        }

        /// <summary>
        /// Filters sent messages from a <see cref="FakeWebSocket"/> by message type and returns them as parsed <see cref="JsonDocument"/> instances.
        /// Caller is responsible for disposing the returned documents when finished (tests can rely on teardown).
        /// </summary>
        /// <param name="socket">The fake WebSocket containing sent messages.</param>
        /// <param name="type">The message type to filter by (e.g., "session.update", "input_audio_buffer.append").</param>
        /// <returns>A list of <see cref="JsonDocument"/> instances matching the specified type.</returns>
        internal static List<JsonDocument> GetMessagesOfType(FakeWebSocket socket, string type)
        {
            if (socket == null) throw new ArgumentNullException(nameof(socket));
            if (type == null) throw new ArgumentNullException(nameof(type));

            var list = new List<JsonDocument>();
            foreach (var msg in socket.GetSentTextMessages())
            {
                if (string.IsNullOrWhiteSpace(msg)) continue;
                try
                {
                    var doc = JsonDocument.Parse(msg);
                    if (GetTopLevelType(doc.RootElement) == type)
                    {
                        list.Add(doc);
                    }
                    else
                    {
                        doc.Dispose();
                    }
                }
                catch (JsonException)
                {
                    // Skip invalid JSON
                }
            }
            return list;
        }

        /// <summary>
        /// Gets the last sent message from a <see cref="FakeWebSocket"/> that matches the specified type.
        /// Returns null if no matching message is found.
        /// Caller is responsible for disposing the returned document when finished.
        /// </summary>
        /// <param name="socket">The fake WebSocket containing sent messages.</param>
        /// <param name="type">The message type to filter by (e.g., "session.update", "input_audio_buffer.append").</param>
        /// <returns>The last <see cref="JsonDocument"/> matching the specified type, or null if none found.</returns>
        internal static JsonDocument? GetLastMessageOfType(FakeWebSocket socket, string type)
        {
            if (socket == null) throw new ArgumentNullException(nameof(socket));
            if (type == null) throw new ArgumentNullException(nameof(type));

            foreach (var msg in socket.GetSentTextMessages().Reverse())
            {
                if (string.IsNullOrWhiteSpace(msg)) continue;
                try
                {
                    var doc = JsonDocument.Parse(msg);
                    if (GetTopLevelType(doc.RootElement) == type)
                    {
                        return doc;
                    }
                    doc.Dispose();
                }
                catch (JsonException)
                {
                    // Skip invalid JSON
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the last sent JSON message from a <see cref="FakeWebSocket"/> regardless of type.
        /// Returns null if no valid JSON message is found.
        /// Caller is responsible for disposing the returned document when finished.
        /// </summary>
        /// <param name="socket">The fake WebSocket containing sent messages.</param>
        /// <returns>The last valid <see cref="JsonDocument"/>, or null if none found.</returns>
        internal static JsonDocument? GetLastJsonMessage(FakeWebSocket socket)
        {
            if (socket == null) throw new ArgumentNullException(nameof(socket));

            foreach (var msg in socket.GetSentTextMessages().Reverse())
            {
                if (string.IsNullOrWhiteSpace(msg)) continue;
                try
                {
                    return JsonDocument.Parse(msg);
                }
                catch (JsonException)
                {
                    // Skip invalid JSON
                }
            }
            return null;
        }

        /// <summary>
        /// Counts the number of sent messages from a <see cref="FakeWebSocket"/> that match the specified type.
        /// </summary>
        /// <param name="socket">The fake WebSocket containing sent messages.</param>
        /// <param name="type">The message type to count (e.g., "session.update", "input_audio_buffer.append").</param>
        /// <returns>The number of messages matching the specified type.</returns>
        internal static int CountMessagesOfType(FakeWebSocket socket, string type)
        {
            if (socket == null) throw new ArgumentNullException(nameof(socket));
            if (type == null) throw new ArgumentNullException(nameof(type));

            return socket.GetSentTextMessages().Count(m =>
            {
                if (string.IsNullOrWhiteSpace(m))
                    return false;
                try
                {
                    using var doc = JsonDocument.Parse(m);
                    return GetTopLevelType(doc.RootElement) == type;
                }
                catch (JsonException)
                {
                    return false;
                }
            });
        }

        private static string EscapeString(string value)
        {
            // Use JsonEncodedText to ensure proper escaping without allocating a JsonDocument.
            return JsonEncodedText.Encode(value).ToString();
        }
    }
}
