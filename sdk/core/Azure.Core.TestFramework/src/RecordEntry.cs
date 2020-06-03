// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Azure.Core.Pipeline;

namespace Azure.Core.TestFramework
{
    public class RecordEntry
    {
        private static readonly JsonWriterOptions RequestWriterOptions = new JsonWriterOptions();
        // Responses are usually formatted using Newtonsoft.Json that has more relaxed encoding rules
        // To enable us to store more responses as JSON instead of string in Recording files use
        // relaxed settings for roundrip
        private static readonly JsonWriterOptions ResponseWriterOptions = new JsonWriterOptions()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public RecordEntryMessage Request { get; } = new RecordEntryMessage();

        public RecordEntryMessage Response { get; } = new RecordEntryMessage();

        public string RequestUri { get; set; }

        public bool IsTrack1Recording { get; set; }

        public RequestMethod RequestMethod { get; set; }

        public int StatusCode { get; set; }

        public static RecordEntry Deserialize(JsonElement element)
        {
            var record = new RecordEntry();

            if (element.TryGetProperty(nameof(RequestMethod), out JsonElement property))
            {
                record.RequestMethod = RequestMethod.Parse(property.GetString());
            }

            if (element.TryGetProperty(nameof(RequestUri), out property))
            {
                record.RequestUri = property.GetString();
            }

            if (element.TryGetProperty("EncodedRequestUri", out property))
            {
                record.IsTrack1Recording = true;
            }

            if (element.TryGetProperty("RequestHeaders", out property))
            {
                DeserializeHeaders(record.Request.Headers, property);
            }

            if (element.TryGetProperty("RequestBody", out property))
            {
                record.Request.Body = DeserializeBody(record.Request.Headers, property, RequestWriterOptions);
            }

            if (element.TryGetProperty(nameof(StatusCode), out property) &&
                property.TryGetInt32(out var statusCode))
            {
                record.StatusCode = statusCode;
            }

            if (element.TryGetProperty("ResponseHeaders", out property))
            {
                DeserializeHeaders(record.Response.Headers, property);
            }

            if (element.TryGetProperty("ResponseBody", out property))
            {
                record.Response.Body = DeserializeBody(record.Response.Headers, property, ResponseWriterOptions);
            }

            return record;
        }

        private static byte[] DeserializeBody(IDictionary<string, string[]> headers, in JsonElement property, JsonWriterOptions writerOptions)
        {
            if (property.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            if (IsTextContentType(headers, out Encoding encoding))
            {
                if (property.ValueKind == JsonValueKind.Object)
                {
                    using var memoryStream = new MemoryStream();
                    using var writer = new Utf8JsonWriter(memoryStream, writerOptions);
                    property.WriteTo(writer);
                    writer.Flush();
                    return memoryStream.ToArray();
                }
                else if (property.ValueKind == JsonValueKind.Array)
                {
                    StringBuilder stringBuilder = new StringBuilder();

                    foreach (JsonElement item in property.EnumerateArray())
                    {
                        stringBuilder.Append(item.GetString());
                    }

                    return encoding.GetBytes(stringBuilder.ToString());
                }
                else
                {
                    return encoding.GetBytes(property.GetString());
                }
            }

            if (property.ValueKind == JsonValueKind.Array)
            {
                return Array.Empty<byte>();
            }

            return Convert.FromBase64String(property.GetString());
        }

        private static void DeserializeHeaders(IDictionary<string, string[]> headers, in JsonElement property)
        {
            foreach (JsonProperty item in property.EnumerateObject())
            {
                if (item.Value.ValueKind == JsonValueKind.Array)
                {
                    var values = new List<string>();
                    foreach (JsonElement headerValue in item.Value.EnumerateArray())
                    {
                        values.Add(headerValue.GetString());
                    }

                    headers[item.Name] = values.ToArray();
                }
                else
                {
                    headers[item.Name] = new[] { item.Value.GetString() };
                }
            }
        }

        public void Serialize(Utf8JsonWriter jsonWriter)
        {
            jsonWriter.WriteStartObject();

            jsonWriter.WriteString(nameof(RequestUri), RequestUri);
            jsonWriter.WriteString(nameof(RequestMethod), RequestMethod.Method);
            jsonWriter.WriteStartObject("RequestHeaders");
            SerializeHeaders(jsonWriter, Request.Headers);
            jsonWriter.WriteEndObject();

            SerializeBody(jsonWriter, "RequestBody", Request.Body, Request.Headers, RequestWriterOptions);

            jsonWriter.WriteNumber(nameof(StatusCode), StatusCode);

            jsonWriter.WriteStartObject("ResponseHeaders");
            SerializeHeaders(jsonWriter, Response.Headers);
            jsonWriter.WriteEndObject();

            SerializeBody(jsonWriter, "ResponseBody", Response.Body, Response.Headers, ResponseWriterOptions);
            jsonWriter.WriteEndObject();
        }

        private void SerializeBody(Utf8JsonWriter jsonWriter, string name, byte[] requestBody, IDictionary<string, string[]> headers, JsonWriterOptions writerOptions)
        {
            if (requestBody == null)
            {
                jsonWriter.WriteNull(name);
            }
            else if (requestBody.Length == 0)
            {
                jsonWriter.WriteStartArray(name);
                jsonWriter.WriteEndArray();
            }
            else if (IsTextContentType(headers, out Encoding encoding))
            {
                // Try parse response as JSON and write it directly if possible
                try
                {
                    using JsonDocument document = JsonDocument.Parse(requestBody);

                    // We use array as a wrapper for string based serialization
                    // so if the root is an array we can't write it directly
                    // fallback to generic string writing
                    if (document.RootElement.ValueKind != JsonValueKind.Array)
                    {
                        // Make sure we can replay JSON is exactly the same as the source
                        // for the case where service response was pre-formatted
                        // fallback to generic string writing
                        using var memoryStream = new MemoryStream();
                        // Settings of this writer should be in sync with the one used in deserialiation
                        using (var reformattedWriter = new Utf8JsonWriter(memoryStream, writerOptions))
                        {
                            document.RootElement.WriteTo(reformattedWriter);
                        }

                        if (memoryStream.ToArray().SequenceEqual(requestBody))
                        {
                            jsonWriter.WritePropertyName(name.AsSpan());
                            document.RootElement.WriteTo(jsonWriter);
                            return;
                        }
                    }
                }
                catch (Exception)
                {
                    // ignore
                }

                ReadOnlySpan<char> text = encoding.GetString(requestBody).AsMemory().Span;

                var indexOfNewline = IndexOfNewline(text);
                if (indexOfNewline == -1)
                {
                    jsonWriter.WriteString(name, text);
                }
                else
                {
                    jsonWriter.WriteStartArray(name);
                    do
                    {
                        jsonWriter.WriteStringValue(text.Slice(0, indexOfNewline + 1));
                        text = text.Slice(indexOfNewline + 1);
                        indexOfNewline = IndexOfNewline(text);
                    } while (indexOfNewline != -1);

                    if (!text.IsEmpty)
                    {
                        jsonWriter.WriteStringValue(text);
                    }

                    jsonWriter.WriteEndArray();
                }
            }
            else
            {
                jsonWriter.WriteString(name, Convert.ToBase64String(requestBody));
            }
        }

        private int IndexOfNewline(ReadOnlySpan<char> span)
        {
            int indexOfNewline = span.IndexOfAny('\r', '\n');

            if (indexOfNewline == -1)
            {
                return -1;
            }

            if (span.Length > indexOfNewline + 1 &&
                (span[indexOfNewline + 1] == '\r' ||
                span[indexOfNewline + 1] == '\n'))
            {
                indexOfNewline++;
            }

            return indexOfNewline;
        }

        private void SerializeHeaders(Utf8JsonWriter jsonWriter, IDictionary<string, string[]> header)
        {
            foreach (KeyValuePair<string, string[]> requestHeader in header)
            {
                if (requestHeader.Value.Length == 1)
                {
                    jsonWriter.WriteString(requestHeader.Key, requestHeader.Value[0]);
                }
                else
                {
                    jsonWriter.WriteStartArray(requestHeader.Key);
                    foreach (var value in requestHeader.Value)
                    {
                        jsonWriter.WriteStringValue(value);
                    }

                    jsonWriter.WriteEndArray();
                }
            }
        }

        public static bool TryGetContentType(IDictionary<string, string[]> requestHeaders, out string contentType)
        {
            contentType = null;
            if (requestHeaders.TryGetValue("Content-Type", out var contentTypes) &&
                contentTypes.Length == 1)
            {
                contentType = contentTypes[0];
                return true;
            }
            return false;
        }

        public static bool IsTextContentType(IDictionary<string, string[]> requestHeaders, out Encoding encoding)
        {
            encoding = null;
            return TryGetContentType(requestHeaders, out string contentType) &&
                   ContentTypeUtilities.TryGetTextEncoding(contentType, out encoding);
        }
    }
}
