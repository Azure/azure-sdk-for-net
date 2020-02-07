// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class StorageError : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Message != null)
            {
                writer.WritePropertyName("Message");
                writer.WriteStringValue(Message);
            }
            writer.WriteEndObject();
        }
        internal static StorageError DeserializeStorageError(JsonElement element)
        {
            StorageError result = new StorageError();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Message"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Message = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "StorageError");
            if (Message != null)
            {
                writer.WriteStartElement("Message");
                writer.WriteValue(Message);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static StorageError DeserializeStorageError(XElement element)
        {
            StorageError result = default;
            result = new StorageError(); string value = default;
            var message = element.Element("Message");
            if (message != null)
            {
                value = (string)message;
            }
            result.Message = value;
            return result;
        }
    }
}
