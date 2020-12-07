// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Security.Attestation
{
    internal class Utilities
    {
        internal static string SerializeJsonElement(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            string serializedObject = string.Empty;
            switch (reader.TokenType)
            {
                case JsonTokenType.PropertyName:
                    serializedObject += SerializeJsonProperty(ref reader, options);
                    break;
                case JsonTokenType.Number:
                    serializedObject += SerializeJsonNumber(ref reader, options);
                    break;
                case JsonTokenType.False:
                    serializedObject += SerializeJsonBoolean(ref reader, options);
                    break;
                case JsonTokenType.True:
                    serializedObject += SerializeJsonBoolean(ref reader, options);
                    break;
                case JsonTokenType.String:
                    serializedObject += SerializeJsonString(ref reader, options);
                    break;
                case JsonTokenType.StartObject:
                    serializedObject += SerializeJsonObject(ref reader, options);
                    break;
                case JsonTokenType.StartArray:
                    serializedObject += SerializeJsonArray(ref reader, options);
                    break;
                default:
                    throw new JsonException();
            }
            return serializedObject;
        }

        internal static string SerializeJsonObject(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            if (options.MaxDepth != 0 && reader.CurrentDepth >= options.MaxDepth)
            {
                throw new JsonException();
            }

            string serializedObject = string.Empty;
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            serializedObject += "{";
            reader.Read();
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                serializedObject += SerializeJsonElement(ref reader, options);
                if (reader.TokenType != JsonTokenType.EndObject)
                {
                    serializedObject += ", ";
                }
            }
            serializedObject += "}";
            reader.Read();

            return serializedObject;
        }

        internal static string SerializeJsonNumber(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            if (options.MaxDepth != 0 && reader.CurrentDepth >= options.MaxDepth)
            {
                throw new JsonException();
            }

            Int32 numberValue = reader.GetInt32();
            reader.Read();
            return numberValue.ToString(CultureInfo.InvariantCulture);
        }

        internal static string SerializeJsonBoolean(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            if (options.MaxDepth != 0 && reader.CurrentDepth >= options.MaxDepth)
            {
                throw new JsonException();
            }

            bool boolValue = reader.GetBoolean();
            reader.Read();
            if (boolValue)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
        internal static string SerializeJsonArray(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            if (options.MaxDepth != 0 && reader.CurrentDepth >= options.MaxDepth)
            {
                throw new JsonException();
            }
            reader.Read(); // Consume the [.
            string arrayValue = "[";

            while (reader.TokenType != JsonTokenType.EndArray)
            {
                arrayValue += SerializeJsonElement(ref reader, options);

                if (reader.TokenType != JsonTokenType.EndArray)
                {
                    arrayValue += ",";
                }
            }
            reader.Read();
            arrayValue += "]";
            return arrayValue;
        }

        internal static string SerializeJsonProperty(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            string serializedObject = string.Empty;

            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }
            // Read the property name.
            string collateralName = reader.GetString();
            reader.Read();
            serializedObject += "\"";
            serializedObject += collateralName;
            serializedObject += "\": ";

            serializedObject += SerializeJsonElement(ref reader, options);

            return serializedObject;
        }
        internal static string SerializeJsonString(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            if (options.MaxDepth != 0 && reader.CurrentDepth >= options.MaxDepth)
            {
                throw new JsonException();
            }

            string stringValue = reader.GetString();
            reader.Read();
            string returnValue = "\"";
            returnValue += stringValue;
            returnValue += "\"";
            return returnValue;
        }
    }
}
