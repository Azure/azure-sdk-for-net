// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Messaging
{
    /// <summary>
    /// A custom converter that attributes the <see cref="CloudEvent"/> type.
    /// This allows System.Text.Json to serialize and deserialize CloudEvents by default.
    /// </summary>
    [RequiresUnreferencedCode(DynamicData.SerializationRequiresUnreferencedCode)]
    [RequiresDynamicCode(DynamicData.SerializationRequiresUnreferencedCode)]
    internal class CloudEventConverter : JsonConverter<CloudEvent>
    {
        /// <summary>
        /// Gets or sets the serializer to use for the data portion of the <see cref="CloudEvent"/>. If not specified,
        /// JsonObjectSerializer is used.
        /// </summary>
        /// <inheritdoc cref="JsonConverter{CloudEvent}.Read(ref Utf8JsonReader, Type, JsonSerializerOptions)"/>
        public override CloudEvent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument requestDocument = JsonDocument.ParseValue(ref reader);
            return DeserializeCloudEvent(requestDocument.RootElement, skipValidation: false);
        }

        internal static CloudEvent DeserializeCloudEvent(JsonElement element, bool skipValidation)
        {
            var cloudEvent = new CloudEvent();
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals(CloudEventConstants.Id))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    cloudEvent.Id = property.Value.GetString()!;
                }
                else if (property.NameEquals(CloudEventConstants.Source))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    cloudEvent.Source = property.Value.GetString()!;
                }
                else if (property.NameEquals(CloudEventConstants.Data))
                {
                    cloudEvent.Data = new BinaryData(property.Value);
                    cloudEvent.DataFormat = CloudEventDataFormat.Json;
                }
                else if (property.NameEquals(CloudEventConstants.DataBase64))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    cloudEvent.Data = BinaryData.FromBytes(property.Value.GetBytesFromBase64());
                    cloudEvent.DataFormat = CloudEventDataFormat.Binary;
                }
                else if (property.NameEquals(CloudEventConstants.Type))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    cloudEvent.Type = property.Value.GetString()!;
                }
                else if (property.NameEquals(CloudEventConstants.Time))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    cloudEvent.Time = property.Value.GetDateTimeOffset();
                }
                else if (property.NameEquals(CloudEventConstants.SpecVersion))
                {
                    cloudEvent.SpecVersion = property.Value.GetString()!;
                }
                else if (property.NameEquals(CloudEventConstants.DataSchema))
                {
                    cloudEvent.DataSchema = property.Value.GetString();
                }
                else if (property.NameEquals(CloudEventConstants.DataContentType))
                {
                    cloudEvent.DataContentType = property.Value.GetString();
                }
                else if (property.NameEquals(CloudEventConstants.Subject))
                {
                    cloudEvent.Subject = property.Value.GetString();
                }
                else
                {
                    if (!skipValidation)
                    {
                        cloudEvent.ExtensionAttributes.Add(property.Name, GetObject(property.Value)!);
                    }
                    else
                    {
                        // This aspect of skipValidation would not be supported for converters that live in a different
                        // package since CloudEventExtensionAttributes is internal.
                        ((CloudEventExtensionAttributes<string, object>)cloudEvent.ExtensionAttributes).AddWithoutValidation(property.Name, GetObject(property.Value)!);
                    }
                }
            }
            if (!skipValidation)
            {
                if (cloudEvent.Source == null)
                {
                    throw new ArgumentException(
                        "The source property must be specified in each CloudEvent. " +
                        Environment.NewLine +
                        CloudEventConstants.ErrorSkipValidationSuggestion);
                }
                if (cloudEvent.Type == null)
                {
                    throw new ArgumentException(
                        "The type property must be specified in each CloudEvent. " +
                        Environment.NewLine +
                        CloudEventConstants.ErrorSkipValidationSuggestion);
                }
                if (cloudEvent.Id == null)
                {
                    throw new ArgumentException(
                        "The Id property must be specified in each CloudEvent. " +
                        Environment.NewLine +
                        CloudEventConstants.ErrorSkipValidationSuggestion);
                }
                if (cloudEvent.SpecVersion != "1.0")
                {
                    // cspell:word specverion
                    if (cloudEvent.SpecVersion == null)
                    {
                        throw new ArgumentException(
                            "The specverion was not set in at least one of the events in the payload. " +
                            "This type only supports specversion '1.0', which must be set for each event. " +
                            Environment.NewLine +
                            CloudEventConstants.ErrorSkipValidationSuggestion +
                            Environment.NewLine +
                            element,
                            nameof(element));
                    }
                    else
                    {
                        throw new ArgumentException(
                            $"The specverion value of '{cloudEvent.SpecVersion}' is not supported by CloudEvent. " +
                            "This type only supports specversion '1.0'. " +
                            Environment.NewLine +
                            CloudEventConstants.ErrorSkipValidationSuggestion +
                            Environment.NewLine +
                            element,
                            nameof(element));
                    }
                };
            }
            return cloudEvent;
        }

        /// <inheritdoc cref="JsonConverter{CloudEvent}.Write(Utf8JsonWriter, CloudEvent, JsonSerializerOptions)"/>
        public override void Write(Utf8JsonWriter writer, CloudEvent value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            // These properties are required and thus assumed to be populated.
            // It is possible for them to be null if a CloudEvent was created by using Parse and passing
            // strict = false. However, we still will write the properties.
            writer.WritePropertyName(CloudEventConstants.Id);
            writer.WriteStringValue(value.Id);
            writer.WritePropertyName(CloudEventConstants.Source);
            writer.WriteStringValue(value.Source);
            writer.WritePropertyName(CloudEventConstants.Type);
            writer.WriteStringValue(value.Type);

            if (value.Data != null)
            {
                switch (value.DataFormat)
                {
                    case CloudEventDataFormat.Binary:
                        writer.WritePropertyName(CloudEventConstants.DataBase64);
                        writer.WriteBase64StringValue(value.Data.ToArray());
                        break;
                    case CloudEventDataFormat.Json:
                        using (JsonDocument doc = JsonDocument.Parse(value.Data.ToMemory()))
                        {
                            writer.WritePropertyName(CloudEventConstants.Data);
                            doc.RootElement.WriteTo(writer);
                            break;
                        }
                }
            }
            if (value.Time != null)
            {
                writer.WritePropertyName(CloudEventConstants.Time);
                writer.WriteStringValue(value.Time.Value);
            }
            writer.WritePropertyName(CloudEventConstants.SpecVersion);
            writer.WriteStringValue(value.SpecVersion);
            if (value.DataSchema != null)
            {
                writer.WritePropertyName(CloudEventConstants.DataSchema);
                writer.WriteStringValue(value.DataSchema);
            }
            if (value.DataContentType != null)
            {
                writer.WritePropertyName(CloudEventConstants.DataContentType);
                writer.WriteStringValue(value.DataContentType);
            }
            if (value.Subject != null)
            {
                writer.WritePropertyName(CloudEventConstants.Subject);
                writer.WriteStringValue(value.Subject);
            }
            foreach (KeyValuePair<string, object> item in value.ExtensionAttributes)
            {
                writer.WritePropertyName(item.Key);
                WriteObjectValue(writer, item.Value);
            }
            writer.WriteEndObject();
        }

        private static void WriteObjectValue(Utf8JsonWriter writer, object? value)
        {
            switch (value)
            {
                case null:
                    writer.WriteNullValue();
                    break;
                case byte[] bytes:
                    writer.WriteStringValue(Convert.ToBase64String(bytes));
                    break;
                case ReadOnlyMemory<byte> rom:
                    writer.WriteStringValue(Convert.ToBase64String(rom.ToArray()));
                    break;
                case int i:
                    writer.WriteNumberValue(i);
                    break;
                case string s:
                    writer.WriteStringValue(s);
                    break;
                case bool b:
                    writer.WriteBooleanValue(b);
                    break;
                case Guid g:
                    writer.WriteStringValue(g);
                    break;
                case Uri u:
                    writer.WriteStringValue(u.ToString());
                    break;
                case DateTimeOffset dateTimeOffset:
                    writer.WriteStringValue(dateTimeOffset);
                    break;
                case DateTime dateTime:
                    writer.WriteStringValue(dateTime);
                    break;
                case IEnumerable<KeyValuePair<string, object>> enumerable:
                    writer.WriteStartObject();
                    foreach (KeyValuePair<string, object> pair in enumerable)
                    {
                        writer.WritePropertyName(pair.Key);
                        WriteObjectValue(writer, pair.Value);
                    }
                    writer.WriteEndObject();
                    break;
                case IEnumerable<object> objectEnumerable:
                    writer.WriteStartArray();
                    foreach (object item in objectEnumerable)
                    {
                        WriteObjectValue(writer, item);
                    }
                    writer.WriteEndArray();
                    break;

                default:
                    throw new NotSupportedException("Not supported type " + value.GetType());
            }
        }

        private static object? GetObject(in JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.String:
                    return element.GetString();
                case JsonValueKind.Number:
                    if (element.TryGetInt32(out int intValue))
                    {
                        return intValue;
                    }
                    if (element.TryGetInt64(out long longValue))
                    {
                        return longValue;
                    }
                    return element.GetDouble();
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.False:
                    return false;
                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                    return null;
                case JsonValueKind.Object:
                    var dictionary = new Dictionary<string, object?>();
                    foreach (JsonProperty jsonProperty in element.EnumerateObject())
                    {
                        dictionary.Add(jsonProperty.Name, GetObject(jsonProperty.Value));
                    }
                    return dictionary;
                case JsonValueKind.Array:
                    var list = new List<object?>();
                    foreach (JsonElement item in element.EnumerateArray())
                    {
                        list.Add(GetObject(item));
                    }
                    return list.ToArray();
                default:
                    throw new NotSupportedException("Not supported value kind " + element.ValueKind);
            }
        }
    }
}
