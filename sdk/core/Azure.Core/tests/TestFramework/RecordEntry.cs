// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core.Pipeline;

namespace Azure.Core.Testing
{
    public class RecordEntry
    {
        public string RequestUri { get; set; }

        public RequestMethod RequestMethod { get; set; }

        public byte[] RequestBody { get; set; }

        public SortedDictionary<string, string[]> RequestHeaders { get; set; } = new SortedDictionary<string, string[]>(StringComparer.InvariantCultureIgnoreCase);

        public SortedDictionary<string, string[]> ResponseHeaders { get; set; } = new SortedDictionary<string, string[]>(StringComparer.InvariantCultureIgnoreCase);

        public byte[] ResponseBody { get; set; }

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

            if (element.TryGetProperty(nameof(RequestHeaders), out property))
            {
                DeserializeHeaders(record.RequestHeaders, property);
            }

            if (element.TryGetProperty(nameof(RequestBody), out property))
            {
                record.RequestBody = DeserializeBody(record.RequestHeaders, property);
            }

            if (element.TryGetProperty(nameof(StatusCode), out property) &&
                property.TryGetInt32(out var statusCode))
            {
                record.StatusCode = statusCode;
            }

            if (element.TryGetProperty(nameof(ResponseHeaders), out property))
            {
                DeserializeHeaders(record.ResponseHeaders, property);
            }

            if (element.TryGetProperty(nameof(ResponseBody), out property))
            {
                record.ResponseBody = DeserializeBody(record.ResponseHeaders, property);
            }

            return record;
        }

        private static byte[] DeserializeBody(IDictionary<string, string[]> headers, in JsonElement property)
        {
            if (property.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            if (IsTextContentType(headers, out Encoding encoding))
            {
                if (property.ValueKind == JsonValueKind.Object)
                {
                    var arrayBufferWriter = new ArrayBufferWriter<byte>();
                    using var writer = new Utf8JsonWriter(arrayBufferWriter);
                    property.WriteTo(writer);
                    writer.Flush();
                    return arrayBufferWriter.WrittenMemory.ToArray();
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
            jsonWriter.WriteStartObject(nameof(RequestHeaders));
            SerializeHeaders(jsonWriter, RequestHeaders);
            jsonWriter.WriteEndObject();

            SerializeBody(jsonWriter, nameof(RequestBody), RequestBody, RequestHeaders);

            jsonWriter.WriteNumber(nameof(StatusCode), StatusCode);

            jsonWriter.WriteStartObject(nameof(ResponseHeaders));
            SerializeHeaders(jsonWriter, ResponseHeaders);
            jsonWriter.WriteEndObject();

            SerializeBody(jsonWriter, nameof(ResponseBody), ResponseBody, ResponseHeaders);
            jsonWriter.WriteEndObject();
        }

        private void SerializeBody(Utf8JsonWriter jsonWriter, string name, byte[] requestBody, IDictionary<string, string[]> headers)
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
                    jsonWriter.WritePropertyName(name.AsSpan());
                    document.RootElement.WriteTo(jsonWriter);
                    return;
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

        private static bool TryGetContentType(IDictionary<string, string[]> requestHeaders, out string contentType)
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

        private static bool IsTextContentType(IDictionary<string, string[]> requestHeaders, out Encoding encoding)
        {
            encoding = null;
            return TryGetContentType(requestHeaders, out string contentType) &&
                   TestFrameworkContentTypeUtilities.TryGetTextEncoding(contentType, out encoding);
        }

        public void Sanitize(RecordedTestSanitizer sanitizer)
        {
            RequestUri = sanitizer.SanitizeUri(RequestUri);
            if (RequestBody != null)
            {
                int contentLength = RequestBody.Length;
                TryGetContentType(RequestHeaders, out string contentType);
                if (IsTextContentType(RequestHeaders, out Encoding encoding))
                {
                    RequestBody = Encoding.UTF8.GetBytes(sanitizer.SanitizeTextBody(contentType, encoding.GetString(RequestBody)));
                }
                else
                {
                    RequestBody = sanitizer.SanitizeBody(contentType, RequestBody);
                }
                UpdateSanitizedContentLength(RequestHeaders, contentLength, RequestBody?.Length ?? 0);
            }

            sanitizer.SanitizeHeaders(RequestHeaders);

            if (ResponseBody != null)
            {
                int contentLength = ResponseBody.Length;
                TryGetContentType(ResponseHeaders, out string contentType);
                if (IsTextContentType(ResponseHeaders, out Encoding encoding))
                {
                    ResponseBody = Encoding.UTF8.GetBytes(sanitizer.SanitizeTextBody(contentType, encoding.GetString(ResponseBody)));
                }
                else
                {
                    ResponseBody = sanitizer.SanitizeBody(contentType, ResponseBody);
                }
                UpdateSanitizedContentLength(ResponseHeaders, contentLength, ResponseBody?.Length ?? 0);
            }

            sanitizer.SanitizeHeaders(ResponseHeaders);
        }

        /// <summary>
        /// Optionally update the Content-Length header if we've sanitized it
        /// and the new value is a different length from the original
        /// Content-Length header.  We don't add a Content-Length header if it
        /// wasn't already present.
        /// </summary>
        /// <param name="headers">The Request or Response headers</param>
        /// <param name="originalLength">THe original Content-Length</param>
        /// <param name="sanitizedLength">The sanitized Content-Length</param>
        private static void UpdateSanitizedContentLength(IDictionary<string, string[]> headers, int originalLength, int sanitizedLength)
        {
            // Note: If the RequestBody/ResponseBody was set to null by our
            // sanitizer, we'll pass 0 as the sanitizedLength and use that as
            // our new Content-Length.  That's fine for all current scenarios
            // (i.e., we never do that), but it's possible we may want to
            // remove the Content-Length header in the future.
            if (originalLength != sanitizedLength && headers.ContainsKey("Content-Length"))
            {
                headers["Content-Length"] = new string[] { sanitizedLength.ToString() };
            }
        }
    }
}
