// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

#nullable disable

namespace Azure.Core
{
    [JsonConverter(typeof(DecodedResponseConverter))]
    internal class DecodedResponse : Response
    {
        private readonly Dictionary<string, List<string>> _headers = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        public DecodedResponse()
        {
        }

        internal DecodedResponse(int status, string reasonPhrase, Stream contentStream, string clientRequestId, bool isError, Dictionary<string, List<string>> headers)
        {
            Status = status;
            ReasonPhrase = reasonPhrase;
            ContentStream = contentStream;
            ClientRequestId = clientRequestId;
            _isError = isError;
            _headers = headers;
        }

        internal static DecodedResponse DeserializeDecodedResponse(JsonElement element)
        {
            int status = default;
            string reasonPhrase = default;
            Stream contentStream = new MemoryStream();
            string clientRequestId = default;
            bool isError = default;
            Dictionary<string, List<string>> headers = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Status"))
                {
                    status = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("ReasonPhrase"))
                {
                    reasonPhrase = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ContentStream"))
                {
                    var content = BinaryData.FromObjectAsJson(property.Value);
                    if (content != null)
                    {
                        content.ToStream().CopyTo(contentStream);
                        contentStream.Position = 0;
                    }
                    continue;
                }
                if (property.NameEquals("ClientRequestId"))
                {
                    clientRequestId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("IsError"))
                {
                    isError = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("Headers"))
                {
                    List<HttpHeader> array = new List<HttpHeader>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        string name = default;
                        string value = default;
                        foreach (var property0 in item.EnumerateObject())
                        {
                            if (property0.NameEquals("Name"))
                            {
                                name = property0.Value.GetString();
                                continue;
                            }
                            if (property0.NameEquals("Value"))
                            {
                                value = property0.Value.GetString();
                                continue;
                            }
                        }
                        array.Add(new HttpHeader(name, value));
                    }
                    foreach (var item in array)
                    {
                        if (!headers.TryGetValue(item.Name, out List<string> values))
                        {
                            headers[item.Name] = values = new List<string>();
                        }
                        values.Add(item.Value);
                    }
                    continue;
                }
            }
            return new DecodedResponse(status, reasonPhrase, contentStream, clientRequestId, isError, headers);
        }

        internal partial class DecodedResponseConverter : JsonConverter<DecodedResponse>
        {
            public override void Write(Utf8JsonWriter writer, DecodedResponse model, JsonSerializerOptions options)
            {
                throw new InvalidOperationException("This converter should only be used for deserialization.");
            }
            public override DecodedResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeDecodedResponse(document.RootElement);
            }
        }

        public override int Status { get; }

        public override string ReasonPhrase { get; }

        public override Stream ContentStream { get; set; }

        public override string ClientRequestId { get; set; }

        private bool? _isError;
        public override bool IsError { get => _isError ?? base.IsError; }
        public void SetIsError(bool value) => _isError = value;

        public bool IsDisposed { get; private set; }

        public void SetContent(byte[] content)
        {
            ContentStream = new MemoryStream(content, 0, content.Length, false, true);
        }

        public DecodedResponse SetContent(string content)
        {
            SetContent(Encoding.UTF8.GetBytes(content));
            return this;
        }

        public DecodedResponse AddHeader(string name, string value)
        {
            return AddHeader(new HttpHeader(name, value));
        }

        public DecodedResponse AddHeader(HttpHeader header)
        {
            if (!_headers.TryGetValue(header.Name, out List<string> values))
            {
                _headers[header.Name] = values = new List<string>();
            }

            values.Add(header.Value);
            return this;
        }

#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif
        protected override bool TryGetHeader(string name, out string value)
        {
            if (_headers.TryGetValue(name, out List<string> values))
            {
                value = JoinHeaderValue(values);
                return true;
            }

            value = null;
            return false;
        }

#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif
        protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
        {
            var result = _headers.TryGetValue(name, out List<string> valuesList);
            values = valuesList;
            return result;
        }

#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif
        protected override bool ContainsHeader(string name)
        {
            return TryGetHeaderValues(name, out _);
        }

#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif
        protected override IEnumerable<HttpHeader> EnumerateHeaders() => _headers.Select(h => new HttpHeader(h.Key, JoinHeaderValue(h.Value)));

        private static string JoinHeaderValue(IEnumerable<string> values)
        {
            return string.Join(",", values);
        }

        public override void Dispose()
        {
            IsDisposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
