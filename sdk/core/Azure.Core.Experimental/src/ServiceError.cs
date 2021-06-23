// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core
{
    /// <summary>
    /// Represents an error returned by an Azure Service.
    /// </summary>
    [JsonConverter(typeof(Converter))]
    public sealed class ServiceError
    {
        internal ServiceError(string? code, string? message, ServiceInnerError? innerError, string? target, IReadOnlyList<ServiceError>? details)
        {
            Code = code;
            Message = message;
            InnerError = innerError;
            Target = target;
            Details = details ?? Array.Empty<ServiceError>();
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

        /// <summary>
        /// Gets the error target.
        /// </summary>
        public string? Target { get; }

        /// <summary>
        /// Gets the list of related errors.
        /// </summary>
        public IReadOnlyList<ServiceError> Details { get; }

        private class Converter : JsonConverter<ServiceError?>
        {
            public override ServiceError? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                var element = document.RootElement;
                return Read(element);
            }

            private static ServiceError? Read(JsonElement element)
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

                ServiceInnerError? innererror = null;
                if (element.TryGetProperty("innererror", out property))
                {
                    innererror = ServiceInnerError.Converter.Read(property);
                }

                List<ServiceError>? details = null;
                if (element.TryGetProperty("details", out property) &&
                    property.ValueKind == JsonValueKind.Array)
                {
                    foreach (var item in property.EnumerateArray())
                    {
                        var detail = Read(item);
                        if (detail != null)
                        {
                            details ??= new();
                            details.Add(detail);
                        }
                    }
                }

                return new ServiceError(code, message, innererror, target, details);
            }

            public override void Write(Utf8JsonWriter writer, ServiceError? value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}