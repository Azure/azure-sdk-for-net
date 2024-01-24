// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    [TypeReferenceType(true, new string[] { nameof(Target), nameof(Details) })]
    public sealed class ResponseError
    {
        private readonly JsonElement _element;

        /// <summary>
        /// Initializes a new instance of <see cref="ResponseError"/>.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <param name="message">The error message.</param>
        [InitializationConstructor]
        public ResponseError(string? code, string? message) : this(code, message, null, default)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ResponseError"/>.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <param name="message">The error message.</param>
        /// <param name="element">The raw JSON element the error was parsed from.</param>
        /// <param name="innerError">The inner error.</param>
        /// <param name="target">The error target.</param>
        /// <param name="details">The error details.</param>
        [SerializationConstructor]
        internal ResponseError(string? code, string? message, string? target, JsonElement element, ResponseInnerError? innerError = null, IReadOnlyList<ResponseError>? details = null)
        {
            _element = element;
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
        internal ResponseInnerError? InnerError { get; }

        /// <summary>
        /// Gets the error target.
        /// </summary>
        internal string? Target { get; }

        /// <summary>
        /// Gets the list of related errors.
        /// </summary>
        internal IReadOnlyList<ResponseError> Details { get; }

        // This class needs to be internal rather than private so that it can be used by the System.Text.Json source generator
        internal class Converter : JsonConverter<ResponseError?>
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

                return new ResponseError(code, message, target, element.Clone(), innererror, details);
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

            Append(builder, includeRaw: true);

            return builder.ToString();
        }

        internal void Append(StringBuilder builder, bool includeRaw)
        {
            builder.AppendFormat(CultureInfo.InvariantCulture, "{0}: {1}{2}", Code, Message, Environment.NewLine);

            if (Target != null)
            {
                builder.AppendFormat(CultureInfo.InvariantCulture, "Target: {0}{1}", Target, Environment.NewLine);
            }

            var innerError = InnerError;

            if (innerError != null)
            {
                builder.AppendLine();
                builder.AppendLine("Inner Errors:");
                while (innerError != null)
                {
                    builder.AppendLine(innerError.Code);
                    innerError = innerError.InnerError;
                }
            }

            if (Details.Count > 0)
            {
                builder.AppendLine();
                builder.AppendLine("Details:");
                foreach (var detail in Details)
                {
                    detail.Append(builder, includeRaw: false);
                }
            }

            if (includeRaw && _element.ValueKind != JsonValueKind.Undefined)
            {
                builder.AppendLine();
                builder.AppendLine("Raw:");
                builder.Append(_element.GetRawText());
            }
        }
    }
}
