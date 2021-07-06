// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core
{
    /// <summary>
    /// Represents an inner error.
    /// </summary>
    [JsonConverter(typeof(Converter))]
    public sealed class ResponseInnerError
    {
        internal ResponseInnerError(string? code, string? message, ResponseInnerError? innerError)
        {
            Code = code;
            Message = message;
            InnerError = innerError;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string? Code { get; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string? Message { get; }

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

                string? message = null;
                if (element.TryGetProperty("message", out property))
                {
                    message = property.GetString();
                }

                ResponseInnerError? innererror = null;
                if (element.TryGetProperty("innererror", out property))
                {
                    innererror = Read(property);
                }

                return new ResponseInnerError(code, message, innererror);
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

            builder.AppendFormat(CultureInfo.InvariantCulture, "{0}: {1}{2}", Code, Message, Environment.NewLine);
            if (InnerError != null)
            {
                builder.AppendLine("Inner Error:");
                builder.Append(InnerError);
            }

            return builder.ToString();
        }
    }
}