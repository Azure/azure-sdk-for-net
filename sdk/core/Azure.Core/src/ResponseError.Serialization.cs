// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure
{
    /// <summary>
    /// Represents an error returned by an Azure Service.
    /// </summary>
    [JsonConverter(typeof(Converter))]
    [TypeReferenceType(true, [nameof(Target), nameof(Details)])]
    public sealed partial class ResponseError : IJsonModel<ResponseError>
    {
        // This class needs to be internal rather than private so that it can be used by the System.Text.Json source generator
        internal class Converter : JsonConverter<ResponseError?>
        {
            public override ResponseError? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                var element = document.RootElement;
                return ReadFromJson(element);
            }

            public override void Write(Utf8JsonWriter writer, ResponseError? value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Writes the <see cref="ResponseError"/> to the provided <see cref="Utf8JsonWriter"/>.
        /// </summary>
        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();

            if (Code != null)
            {
                writer.WritePropertyName("code");
                writer.WriteStringValue(Code);
            }

            if (Message != null)
            {
                writer.WritePropertyName("message");
                writer.WriteStringValue(Message);
            }

            if (Target != null)
            {
                writer.WritePropertyName("target");
                writer.WriteStringValue(Target);
            }

            if (InnerError != null)
            {
                writer.WritePropertyName("innererror");
                InnerError.Write(writer, ModelReaderWriterOptions.Json);
            }

            if (Details.Count > 0)
            {
                writer.WritePropertyName("details");
                writer.WriteStartArray();

                foreach (var detail in Details)
                {
                    if (detail == null)
                    {
                        writer.WriteNullValue();
                    }
                    else
                    {
                        detail.Write(writer, options);
                    }
                }

                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }

        /// <inheritdoc />
        public ResponseError Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ResponseError)} does not support '{format}' format.");
            }

            using var document = JsonDocument.ParseValue(ref reader);
            var element = document.RootElement;
            return ReadFromJson(element) ?? new ResponseError();
        }

        /// <summary>
        /// Writes the <see cref="ResponseError"/> to the provided <see cref="Utf8JsonWriter"/>.
        /// </summary>
        public BinaryData Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ResponseError)} does not support '{format}' format.");
            }

            using var stream = new System.IO.MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            Write(writer, options);
            writer.Flush();

            return new BinaryData(stream.ToArray());
        }

        /// <inheritdoc />
        public ResponseError Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ResponseError)} does not support '{format}' format.");
            }

            using var document = JsonDocument.Parse(data);
            var element = document.RootElement;
            return ReadFromJson(element) ?? new ResponseError();
        }

        /// <inheritdoc />
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private static ResponseError? ReadFromJson(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            string? code = null;
            if (element.TryGetProperty("code", out var property))
            {
                code = property.GetString();
            }

            string? message = null;
            if (element.TryGetProperty("message", out property))
            {
                message = property.GetString();
            }

            string? target = null;
            if (element.TryGetProperty("target", out property))
            {
                target = property.GetString();
            }

            ResponseInnerError? innererror = null;
            if (element.TryGetProperty("innererror", out property))
            {
                innererror = ResponseInnerError.ReadFromJson(property);
            }

            List<ResponseError>? details = null;
            if (element.TryGetProperty("details", out property) &&
                property.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in property.EnumerateArray())
                {
                    var detail = ReadFromJson(item);
                    if (detail != null)
                    {
                        details ??= new();
                        details.Add(detail);
                    }
                }
            }

            return new ResponseError(code, message, target, element.Clone(), innererror, details);
        }
    }
}
