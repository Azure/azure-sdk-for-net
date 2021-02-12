// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Messaging
{
    /// <summary>
    /// A custom converter that attributes the CloudEvent type. This allows System.Text.Json to serialize
    /// and deserialize CloudEvents by default.
    /// </summary>
#pragma warning disable AZC0014 // Avoid using banned types in public API
    public class CloudEventConverter : JsonConverter<CloudEvent>
#pragma warning restore AZC0014 // Avoid using banned types in public API
    {
        private static readonly JsonObjectSerializer s_defaultSerializer = new JsonObjectSerializer();

        /// <summary>
        /// Gets or sets the serializer to use for the data portion of the CloudEvent. If not specified,
        /// JsonObjectSerializer is used.
        /// </summary>
        public ObjectSerializer DataSerializer { get; set; } = s_defaultSerializer;

        /// <inheritdoc cref="JsonConverter{CloudEvent}.Read(ref Utf8JsonReader, Type, JsonSerializerOptions)"/>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public override CloudEvent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            JsonDocument requestDocument = JsonDocument.ParseValue(ref reader);
            return DeserializeCloudEvent(requestDocument.RootElement);
        }

        internal static CloudEvent DeserializeCloudEvent(JsonElement element)
        {
            var cloudEvent = new CloudEvent();
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    cloudEvent.Id = property.Value.GetString()!;
                }
                else if (property.NameEquals("source"))
                {
                    cloudEvent.Source = property.Value.GetString();
                }
                else if (property.NameEquals("data"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    cloudEvent.Data = s_defaultSerializer.Serialize(property.Value);
                }
                else if (property.NameEquals("data_base64"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    cloudEvent.DataBase64 = property.Value.GetBytesFromBase64();
                }
                else if (property.NameEquals("type"))
                {
                    cloudEvent.Type = property.Value.GetString();
                }
                else if (property.NameEquals("time"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    cloudEvent.Time = property.Value.GetDateTimeOffset();
                }
                else if (property.NameEquals("specversion"))
                {
                    cloudEvent.SpecVersion = property.Value.GetString()!;
                }
                else if (property.NameEquals("dataschema"))
                {
                    cloudEvent.DataSchema = property.Value.GetString();
                }
                else if (property.NameEquals("datacontenttype"))
                {
                    cloudEvent.DataContentType = property.Value.GetString();
                }
                else if (property.NameEquals("subject"))
                {
                    cloudEvent.Subject = property.Value.GetString();
                }
                else
                {
                    (cloudEvent.ExtensionAttributes as CloudEventExtensionAttributes<string, object?>)!.AddWithoutValidation(property.Name, GetObject(property.Value));
                }
            }
            return cloudEvent;
        }

        /// <inheritdoc cref="JsonConverter{CloudEvent}.Write(Utf8JsonWriter, CloudEvent, JsonSerializerOptions)"/>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public override void Write(Utf8JsonWriter writer, CloudEvent value, JsonSerializerOptions options)
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(value.Id);
            writer.WritePropertyName("source");
            writer.WriteStringValue(value.Source);
            if (value.JsonSerializableData != null)
            {
                writer.WritePropertyName("data");
                using (MemoryStream stream = new MemoryStream())
                {
                    DataSerializer.Serialize(
                        stream,
                        value.JsonSerializableData,
                        value.DataSerializationType!,
                        CancellationToken.None);

                    stream.Position = 0;
                    using JsonDocument document = JsonDocument.Parse(stream);
                    document.RootElement.WriteTo(writer);
                }
            }
            if (value.DataBase64 != null)
            {
                writer.WritePropertyName("data_base64");
                writer.WriteBase64StringValue(value.DataBase64.Value.Span);
            }
            writer.WritePropertyName("type");
            writer.WriteStringValue(value.Type);

            if (value.Time != null)
            {
                writer.WritePropertyName("time");
                writer.WriteStringValue(value.Time.Value);
            }
            writer.WritePropertyName("specversion");
            writer.WriteStringValue(value.SpecVersion);
            if (value.DataSchema != null)
            {
                writer.WritePropertyName("dataschema");
                writer.WriteStringValue(value.DataSchema);
            }
            if (value.DataContentType != null )
            {
                writer.WritePropertyName("datacontenttype");
                writer.WriteStringValue(value.DataContentType);
            }
            if (value.Subject != null)
            {
                writer.WritePropertyName("subject");
                writer.WriteStringValue(value.Subject);
            }
            foreach (KeyValuePair<string, object?> item in value.ExtensionAttributes)
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
                case int i:
                    writer.WriteNumberValue(i);
                    break;
                case decimal d:
                    writer.WriteNumberValue(d);
                    break;
                case double d:
                    writer.WriteNumberValue(d);
                    break;
                case float f:
                    writer.WriteNumberValue(f);
                    break;
                case long l:
                    writer.WriteNumberValue(l);
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
