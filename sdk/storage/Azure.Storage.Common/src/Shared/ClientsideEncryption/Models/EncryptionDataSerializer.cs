// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Storage.Cryptography.Models
{
    internal static class EncryptionDataSerializer
    {
        private const string EncryptionAgent_EncryptionVersionName = "Protocol";

        #region Serialize

        /// <summary>
        /// Serializes an EncryptionData instance into JSON.
        /// </summary>
        /// <param name="data">Data to serialize.</param>
        /// <returns>The JSON string.</returns>
        public static string Serialize(EncryptionData data)
        {
            return Encoding.UTF8.GetString(SerializeEncryptionData(data).ToArray());
        }

        /// <summary>
        /// Serializes an EncryptionData instance into JSON.
        /// </summary>
        /// <param name="data">Data to serialize.</param>
        /// <returns>The JSON UTF8 bytes.</returns>
        private static ReadOnlyMemory<byte> SerializeEncryptionData(EncryptionData data)
        {
            var writer = new Core.ArrayBufferWriter<byte>();
            using var json = new Utf8JsonWriter(writer);

            json.WriteStartObject();
            WriteEncryptionData(json, data);
            json.WriteEndObject();

            json.Flush();
            return writer.WrittenMemory;
        }

        /// <summary>
        /// Serializes an EncryptionData instance into JSON and writes it to the given JSON writer.
        /// </summary>
        /// <param name="json">The writer to write the serialization to.</param>
        /// <param name="data">Data to serialize.</param>
        public static void WriteEncryptionData(Utf8JsonWriter json, EncryptionData data)
        {
            json.WriteString(nameof(data.EncryptionMode), data.EncryptionMode);

            json.WriteStartObject(nameof(data.WrappedContentKey));
            WriteWrappedKey(json, data.WrappedContentKey);
            json.WriteEndObject();

            json.WriteStartObject(nameof(data.EncryptionAgent));
            WriteEncryptionAgent(json, data.EncryptionAgent);
            json.WriteEndObject();

            if (data.ContentEncryptionIV != null)
            {
                json.WriteString(nameof(data.ContentEncryptionIV), Convert.ToBase64String(data.ContentEncryptionIV));
            }
            if (data.EncryptedRegionInfo != null)
            {
                json.WriteStartObject(nameof(data.EncryptedRegionInfo));
                WriteEncryptedRegionInfo(json, data.EncryptedRegionInfo);
                json.WriteEndObject();
            }

            json.WriteStartObject(nameof(data.KeyWrappingMetadata));
            WriteDictionary(json, data.KeyWrappingMetadata);
            json.WriteEndObject();
        }

        private static void WriteEncryptedRegionInfo(Utf8JsonWriter json, EncryptedRegionInfo encryptedRegionInfo)
        {
            json.WriteNumber(nameof(encryptedRegionInfo.DataLength), encryptedRegionInfo.DataLength);
            json.WriteNumber(nameof(encryptedRegionInfo.NonceLength), encryptedRegionInfo.NonceLength);
        }

        private static void WriteWrappedKey(Utf8JsonWriter json, KeyEnvelope key)
        {
            json.WriteString(nameof(key.KeyId), key.KeyId);
            json.WriteString(nameof(key.EncryptedKey), Convert.ToBase64String(key.EncryptedKey));
            json.WriteString(nameof(key.Algorithm), key.Algorithm);
        }

        private static void WriteEncryptionAgent(Utf8JsonWriter json, EncryptionAgent encryptionAgent)
        {
            json.WriteString(EncryptionAgent_EncryptionVersionName, encryptionAgent.EncryptionVersion.Serialize());
            json.WriteString(nameof(encryptionAgent.EncryptionAlgorithm), encryptionAgent.EncryptionAlgorithm.ToString());
        }

        private static void WriteDictionary(Utf8JsonWriter json, IDictionary<string, string> dictionary)
        {
            foreach (var entry in dictionary)
            {
                json.WriteString(entry.Key, entry.Value);
            }
        }
        #endregion

        #region Deserialize
        /// <summary>
        /// Deserializes an EncryptionData instance from JSON.
        /// </summary>
        /// <param name="serializedData">The serialized data string.</param>
        /// <returns>The instance.</returns>
        public static EncryptionData Deserialize(string serializedData)
        {
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(serializedData));
            return DeserializeEncryptionData(ref reader);
        }

        /// <summary>
        /// Reads an EncryptionData instance from a JSON reader.
        /// </summary>
        /// <param name="reader">The reader to parse an EncryptionData isntance from.</param>
        /// <returns>The instance.</returns>
        public static EncryptionData DeserializeEncryptionData(ref Utf8JsonReader reader)
        {
            using JsonDocument json = JsonDocument.ParseValue(ref reader);
            JsonElement root = json.RootElement;
            return ReadEncryptionData(root);
        }

        /// <summary>
        /// Reads an EncryptionData instance from a parsed JSON object.
        /// </summary>
        /// <param name="root">The JSON object model.</param>
        /// <returns>The instance.</returns>
        public static EncryptionData ReadEncryptionData(JsonElement root)
        {
            var data = new EncryptionData();
            foreach (var property in root.EnumerateObject())
            {
                ReadPropertyValue(data, property);
            }
            return data;
        }

        private static void ReadPropertyValue(EncryptionData data, JsonProperty property)
        {
            if (property.Name.Equals(nameof(data.EncryptionMode), StringComparison.InvariantCultureIgnoreCase))
            {
                data.EncryptionMode = property.Value.GetString();
            }
            else if (property.Name.Equals(nameof(data.WrappedContentKey), StringComparison.InvariantCultureIgnoreCase))
            {
                var key = new KeyEnvelope();
                foreach (var subProperty in property.Value.EnumerateObject())
                {
                    ReadPropertyValue(key, subProperty);
                }
                data.WrappedContentKey = key;
            }
            else if (property.Name.Equals(nameof(data.EncryptionAgent), StringComparison.InvariantCultureIgnoreCase))
            {
                var agent = new EncryptionAgent();
                foreach (var subProperty in property.Value.EnumerateObject())
                {
                    ReadPropertyValue(agent, subProperty);
                }
                data.EncryptionAgent = agent;
            }
            else if (property.Name.Equals(nameof(data.ContentEncryptionIV), StringComparison.InvariantCultureIgnoreCase))
            {
                data.ContentEncryptionIV = Convert.FromBase64String(property.Value.GetString());
            }
            else if (property.Name.Equals(nameof(data.KeyWrappingMetadata), StringComparison.InvariantCultureIgnoreCase))
            {
                var metadata = new Dictionary<string, string>();
                foreach (var entry in property.Value.EnumerateObject())
                {
                    metadata.Add(entry.Name, entry.Value.GetString());
                }
                data.KeyWrappingMetadata = metadata;
            }
            else if (property.Name.Equals(nameof(data.EncryptedRegionInfo), StringComparison.InvariantCultureIgnoreCase))
            {
                var info = new EncryptedRegionInfo();
                foreach (var subProperty in property.Value.EnumerateObject())
                {
                    ReadPropertyValue(info, subProperty);
                }
                data.EncryptedRegionInfo = info;
            }
        }

        private static void ReadPropertyValue(KeyEnvelope key, JsonProperty property)
        {
            if (property.Name.Equals(nameof(key.Algorithm), StringComparison.InvariantCultureIgnoreCase))
            {
                key.Algorithm = property.Value.GetString();
            }
            else if (property.Name.Equals(nameof(key.EncryptedKey), StringComparison.InvariantCultureIgnoreCase))
            {
                key.EncryptedKey = Convert.FromBase64String(property.Value.GetString());
            }
            else if (property.Name.Equals(nameof(key.KeyId), StringComparison.InvariantCultureIgnoreCase))
            {
                key.KeyId = property.Value.GetString();
            }
        }

        private static void ReadPropertyValue(EncryptionAgent agent, JsonProperty property)
        {
            if (property.Name.Equals(nameof(agent.EncryptionAlgorithm), StringComparison.InvariantCultureIgnoreCase))
            {
                agent.EncryptionAlgorithm = new ClientSideEncryptionAlgorithm(property.Value.GetString());
            }
            else if (property.Name.Equals(EncryptionAgent_EncryptionVersionName, StringComparison.InvariantCultureIgnoreCase))
            {
                agent.EncryptionVersion = property.Value.GetString().ToClientSideEncryptionVersion();
            }
        }

        private static void ReadPropertyValue(EncryptedRegionInfo info, JsonProperty property)
        {
            if (property.Name.Equals(nameof(info.NonceLength), StringComparison.InvariantCultureIgnoreCase))
            {
                info.NonceLength = property.Value.GetInt32();
            }
            else if (property.Name.Equals(nameof(info.DataLength), StringComparison.InvariantCultureIgnoreCase))
            {
                info.DataLength = property.Value.GetInt32();
            }
        }
        #endregion
    }
}
