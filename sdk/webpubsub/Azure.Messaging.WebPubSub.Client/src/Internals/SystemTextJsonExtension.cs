// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Azure.Messaging.WebPubSub.Clients
{
    internal static class SystemTextJsonExtension
    {
        public static bool CheckRead(this ref Utf8JsonReader reader)
        {
            if (!reader.Read())
            {
                throw new InvalidDataException("Unexpected end when reading JSON.");
            }

            return true;
        }

        public static void EnsureObjectStart(this ref Utf8JsonReader reader)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new InvalidDataException($"Unexpected JSON Token Type '{reader.GetTokenString()}'. Expected a JSON Object.");
            }
        }

        public static string GetTokenString(this ref Utf8JsonReader reader)
        {
            return GetTokenString(reader.TokenType);
        }

        public static string GetTokenString(JsonTokenType tokenType)
        {
            switch (tokenType)
            {
                case JsonTokenType.None:
                    break;
                case JsonTokenType.StartObject:
                    return "Object";
                case JsonTokenType.StartArray:
                    return "Array";
                case JsonTokenType.PropertyName:
                    return "Property";
                default:
                    break;
            }
            return tokenType.ToString();
        }

        public static void EnsureArrayStart(this ref Utf8JsonReader reader)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new InvalidDataException($"Unexpected JSON Token Type '{reader.GetTokenString()}'. Expected a JSON Array.");
            }
        }

        public static bool ReadAsBoolean(this ref Utf8JsonReader reader, string propertyName)
        {
            reader.Read();

            return reader.TokenType switch
            {
                JsonTokenType.False => false,
                JsonTokenType.True => true,
                _ => throw new InvalidDataException($"Expected '{propertyName}' to be true or false."),
            };
        }

        public static string ReadAsNullableString(this ref Utf8JsonReader reader, string propertyName)
        {
            reader.Read();

            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType != JsonTokenType.String)
            {
                throw new InvalidDataException($"Expected '{propertyName}' to be of type {JsonTokenType.String}.");
            }

            return reader.GetString();
        }

        public static int? ReadAsInt32(this ref Utf8JsonReader reader, string propertyName)
        {
            reader.Read();

            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType != JsonTokenType.Number)
            {
                throw new InvalidDataException($"Expected '{propertyName}' to be of type {JsonTokenType.Number}.");
            }

            return reader.GetInt32();
        }

        public static long? ReadAsLongNonNegtive(this ref Utf8JsonReader reader, string propertyName)
        {
            reader.Read();
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            if (reader.TokenType != JsonTokenType.Number)
            {
                throw new InvalidDataException($"Expected '{propertyName}' to be of type {JsonTokenType.Number}.");
            }
            var result = reader.GetInt64();
            if (result < 0)
            {
                throw new InvalidDataException($"Value of '{propertyName}' must be non-negative. Actual value is ${result}.");
            }
            return result;
        }
    }
}
