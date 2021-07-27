// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core
{
    /// <summary>
    /// Represents an error returned by an Azure Service.
    /// </summary>
    [JsonConverter(typeof(Converter))]
    public sealed class ResponseError
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ResponseError"/>.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <param name="message">The error message.</param>
        /// <param name="innerError">The inner error.</param>
        /// <param name="target">The error target.</param>
        /// <param name="details">The error details.</param>
        public ResponseError(string? code, string? message, ResponseInnerError? innerError, string? target, IReadOnlyList<ResponseError>? details)
        {
            Code = code;
            Message = message;
            InnerError = innerError;
            Target = target;
            Details = details ?? Array.Empty<ResponseError>();
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

        /// <summary>
        /// Gets the error target.
        /// </summary>
        public string? Target { get; }

        /// <summary>
        /// Gets the list of related errors.
        /// </summary>
        public IReadOnlyList<ResponseError> Details { get; }

        private class Converter : JsonConverter<ResponseError?>
        {
            public override ResponseError? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                var element = document.RootElement;
                return Read(element);
            }

            private static ResponseError? Read(JsonElement element)
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
                    innererror = ResponseInnerError.Converter.Read(property);
                }

                List<ResponseError>? details = null;
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

                return new ResponseError(code, message, innererror, target, details);
            }

            public override void Write(Utf8JsonWriter writer, ResponseError? value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendFormat(CultureInfo.InvariantCulture, "{0}: {1}{2}", Code, Message, Environment.NewLine);

            if (Target != null)
            {
                builder.AppendFormat(CultureInfo.InvariantCulture, "Target: {0}{1}", Target, Environment.NewLine);
            }

            if (InnerError != null)
            {
                builder.AppendLine("Inner Error:");
                builder.Append(InnerError);
            }

            if (Details.Count > 0)
            {
                builder.AppendLine("Details:");
                foreach (var detail in Details)
                {
                    builder.Append(detail);
                }
            }

            return builder.ToString();
        }
    }
}