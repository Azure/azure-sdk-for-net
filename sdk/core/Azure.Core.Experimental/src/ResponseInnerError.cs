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

        /// <summary>
        /// Attempts to retrieve a service specific property from the error.
        /// </summary>
        /// <param name="name">The name of the error.</param>
        /// <param name="value">The variable to assign the value to.</param>
        /// <typeparam name="T">The type of the requested property.</typeparam>
        /// <returns><c>true</c> if the property exists, <c>false</c> otherwise.</returns>
        public bool TryGetCustomProperty<T>(string name, out T? value)
        {
            if (_innerErrorElement.TryGetProperty(name, out JsonElement property))
            {
                var json = property.GetRawText();
                value = JsonSerializer.Deserialize<T>(json);
                return true;
            }

            value = default;
            return false;
        }

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

            builder.AppendFormat(CultureInfo.InvariantCulture, "{0}: {1}", Code, Environment.NewLine);
            if (InnerError != null)
            {
                builder.AppendLine("Inner Error:");
                builder.Append(InnerError);
            }

            return builder.ToString();
        }
    }
}