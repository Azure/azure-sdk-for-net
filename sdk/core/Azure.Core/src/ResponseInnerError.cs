// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure
{
    /// <summary>
    /// Represents an inner error.
    /// </summary>
    [JsonConverter(typeof(Converter))]
    internal sealed class ResponseInnerError
    {
        private readonly JsonElement _innerErrorElement;

        internal ResponseInnerError(string? code, ResponseInnerError? innerError, JsonElement innerErrorElement)
        {
            _innerErrorElement = innerErrorElement;
            Code = code;
            InnerError = innerError;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string? Code { get; }

        /// <summary>
        /// Gets the inner error.
        /// </summary>
        public ResponseInnerError? InnerError { get; }

        internal class Converter : JsonConverter<ResponseInnerError?>
        {
            public override ResponseInnerError? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                var element = document.RootElement;
                return Read(element);
            }

            internal static ResponseInnerError? Read(JsonElement element)
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
                    innererror = Read(property);
                }

                return new ResponseInnerError(code, innererror, element.Clone());
            }

            public override void Write(Utf8JsonWriter writer, ResponseInnerError? value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            var builder = new StringBuilder();

            Append(builder);

            return builder.ToString();
        }

        internal void Append(StringBuilder builder)
        {
            builder.AppendFormat(CultureInfo.InvariantCulture, "{0}: {1}", Code, Environment.NewLine);
            if (InnerError != null)
            {
                builder.AppendLine("Inner Error:");
                builder.Append(InnerError);
            }
        }
    }
}
