// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure
{
    [JsonConverter(typeof(ResponseInnerErrorConverter))]
    internal sealed partial class ResponseInnerError : IJsonModel<ResponseInnerError>
    {
        internal class ResponseInnerErrorConverter : JsonConverter<ResponseInnerError?>
        {
            public override ResponseInnerError? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                var element = document.RootElement;
                return ReadFromJson(element);
            }

            public override void Write(Utf8JsonWriter writer, ResponseInnerError? value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }

        private static void WriteInnerError(Utf8JsonWriter writer, ResponseInnerError innerError)
        {
            writer.WriteStartObject();

            if (innerError.Code != null)
            {
                writer.WritePropertyName("code");
                writer.WriteStringValue(innerError.Code);
            }

            if (innerError.InnerError != null)
            {
                writer.WritePropertyName("innererror");
                WriteInnerError(writer, innerError.InnerError);
            }

            writer.WriteEndObject();
        }

        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ResponseInnerError)} does not support '{format}' format.");
            }

            WriteInnerError(writer, this);
        }

        public ResponseInnerError Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ResponseInnerError)} does not support '{format}' format.");
            }

            using var document = JsonDocument.ParseValue(ref reader);
            var element = document.RootElement;
            return ReadFromJson(element) ?? new ResponseInnerError(null, null, default);
        }

        public BinaryData Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ResponseInnerError)} does not support '{format}' format.");
            }

            return ModelReaderWriter.Write(this, options, AzureCoreContext.Default);
        }

        public ResponseInnerError Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ResponseInnerError)} does not support '{format}' format.");
            }

            using var document = JsonDocument.Parse(data);
            var element = document.RootElement;
            return ReadFromJson(element) ?? new ResponseInnerError(null, null, default);
        }

        string IPersistableModel<ResponseInnerError>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static ResponseInnerError? ReadFromJson(JsonElement element)
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

            ResponseInnerError? innererror = null;
            if (element.TryGetProperty("innererror", out property))
            {
                innererror = ReadFromJson(property);
            }

            return new ResponseInnerError(code, innererror, element.Clone());
        }
    }
}
