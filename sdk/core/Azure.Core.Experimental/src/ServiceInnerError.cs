// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core
{
    /// <summary>
    /// Represents an inner error.
    /// </summary>
    [JsonConverter(typeof(Converter))]
    public sealed class ServiceInnerError
    {
        internal ServiceInnerError(string? code, string? message, ServiceInnerError? innerError)
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
        public ServiceInnerError? InnerError { get; }

        internal class Converter : JsonConverter<ServiceInnerError?>
        {
            public override ServiceInnerError? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                var element = document.RootElement;
                return Read(element);
            }

            internal static ServiceInnerError? Read(JsonElement element)
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

                ServiceInnerError? innererror = null;
                if (element.TryGetProperty("innererror", out property))
                {
                    innererror = Read(property);
                }

                return new ServiceInnerError(code, message, innererror);
            }

            public override void Write(Utf8JsonWriter writer, ServiceInnerError? value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}