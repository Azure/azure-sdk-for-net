// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Text.Json;
using Azure.Storage.Cryptography.Models;

namespace Azure.Storage.Queues.Specialized.Models
{
    internal static class EncryptedMessageSerializer
    {
        private const string EncryptedMessage_EncryptedMessageTextName = "EncryptedMessageContents";

        #region Serialize
        public static string Serialize(EncryptedMessage data)
        {
            return Encoding.UTF8.GetString(SerializeEncryptedMessage(data).ToArray());
        }

        public static ReadOnlyMemory<byte> SerializeEncryptedMessage(EncryptedMessage message)
        {
            var writer = new Core.ArrayBufferWriter<byte>();
            using var json = new Utf8JsonWriter(writer);

            json.WriteStartObject();
            WriteEncryptedMessage(json, message);
            json.WriteEndObject();

            json.Flush();
            return writer.WrittenMemory;
        }

        public static void WriteEncryptedMessage(Utf8JsonWriter json, EncryptedMessage message)
        {
            json.WriteString(EncryptedMessage_EncryptedMessageTextName, message.EncryptedMessageText);

            json.WriteStartObject(nameof(message.EncryptionData));
            EncryptionDataSerializer.WriteEncryptionData(json, message.EncryptionData);
            json.WriteEndObject();
        }
        #endregion

        #region Deserialize
        public static bool TryDeserialize(string serializedData, out EncryptedMessage encryptedMessage)
        {
            try
            {
                encryptedMessage = Deserialize(serializedData);
                return true;
            }
            // JsonException does not actually cover everything. InvalidOperationException can be thrown
            // on some string inputs, as we can't assume input is even JSON.
            catch (Exception)
            {
                encryptedMessage = default;
                return false;
            }
        }

        public static EncryptedMessage Deserialize(string serializedData)
        {
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(serializedData));
            return DeserializeEncryptedMessage(ref reader);
        }

        public static EncryptedMessage DeserializeEncryptedMessage(ref Utf8JsonReader reader)
        {
            using JsonDocument json = JsonDocument.ParseValue(ref reader);
            JsonElement root = json.RootElement;
            return ReadEncryptionData(root);
        }

        private static EncryptedMessage ReadEncryptionData(JsonElement root)
        {
            var data = new EncryptedMessage();
            foreach (var property in root.EnumerateObject())
            {
                ReadPropertyValue(data, property);
            }

            if (data.EncryptionData == default || data.EncryptedMessageText == default)
            {
                throw new FormatException($"Failed to find non-optional properties while deserializing `{typeof(EncryptedMessage).FullName}`.");
            }

            return data;
        }

        private static void ReadPropertyValue(EncryptedMessage data, JsonProperty property)
        {
            if (property.NameEquals(EncryptedMessage_EncryptedMessageTextName))
            {
                data.EncryptedMessageText = property.Value.GetString();
            }
            else if (property.NameEquals(nameof(data.EncryptionData)))
            {
                data.EncryptionData = EncryptionDataSerializer.ReadEncryptionData(property.Value);
            }
            else
            {
                throw new FormatException($"Failed to deserialize `{typeof(EncryptedMessage).FullName}`. Unrecognized property `{property.Name}`.");
            }
        }
        #endregion
    }
}
