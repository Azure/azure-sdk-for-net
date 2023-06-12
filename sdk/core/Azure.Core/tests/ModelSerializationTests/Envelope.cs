// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.ModelSerializationTests
{
    public class Envelope<T> : IJsonSerializable, IUtf8JsonSerializable
    {
        private Dictionary<string, BinaryData> RawData { get; set; } = new Dictionary<string, BinaryData>();

        public string ReadOnlyProperty { get; private set; } = "readonly";

        public Envelope()
        {
        }

        public Envelope(string location)
        {
            ReadOnlyProperty = location;
        }

        internal Envelope(string property, CatReadOnlyProperty cat, T modelC, Dictionary<string, BinaryData> rawData)
        {
            ReadOnlyProperty = property;
            ModelA = cat;
            ModelC = modelC;
            RawData = rawData;
        }

        public CatReadOnlyProperty ModelA { get; set; }
        public T ModelC { get; set; }

        #region Serialization
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (!options.IgnoreReadOnlyProperties)
            {
                writer.WritePropertyName("readOnlyProperty"u8);
                writer.WriteStringValue(ReadOnlyProperty);
            }

            writer.WritePropertyName("modelA"u8);
            ((IUtf8JsonSerializable)ModelA).Write(writer, options);
            writer.WritePropertyName("modelC"u8);
            SerializeT(writer, options);

            if (!options.IgnoreAdditionalProperties)
            {
                //write out the raw data
                foreach (var property in RawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static Envelope<T> DeserializeEnvelope(JsonElement element, SerializableOptions options)
        {
            string readonlyProperty = "";
            CatReadOnlyProperty modelA = new CatReadOnlyProperty();
            T modelC = default(T);
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("readOnlyProperty"u8))
                {
                    readonlyProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("modelA"u8))
                {
                    modelA = CatReadOnlyProperty.DeserializeCatReadOnlyProperty(property.Value, options);
                    continue;
                }
                if (property.NameEquals("modelC"u8))
                {
                    modelC = DeserializeT(property.Value, options);
                    continue;
                }

                if (!options.IgnoreAdditionalProperties)
                {
                    //this means it's an modelC property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new Envelope<T>(readonlyProperty, modelA, modelC, rawData);
        }

        private void SerializeT(Utf8JsonWriter writer, SerializableOptions options)
        {
            ObjectSerializer serializer = GetObjectSerializer(options);
            BinaryData data = serializer.Serialize(ModelC);
#if NET6_0_OR_GREATER
            writer.WriteRawValue(data);
#else
            JsonSerializer.Serialize(writer, JsonDocument.Parse(data.ToString()).RootElement);
#endif
        }

        private static ObjectSerializer GetObjectSerializer(SerializableOptions options)
        {
            ObjectSerializer serializer;
            if (options.Serializers.TryGetValue(typeof(T), out serializer))
            {
                // serializer is from the dictionary
                return serializer;
            }
            // default
            return JsonObjectSerializer.Default;
        }

        private static T DeserializeT(JsonElement element, SerializableOptions options)
        {
            ObjectSerializer serializer = GetObjectSerializer(options);
            MemoryStream m = new MemoryStream();
            Utf8JsonWriter w = new Utf8JsonWriter(m);
            element.WriteTo(w);
            w.Flush();
            m.Position = 0;
            return (T)serializer.Deserialize(m, typeof(T), default);
        }
#endregion

        #region InterfaceImplementation
        public bool TryDeserialize(Stream stream, out long bytesConsumed, SerializableOptions options = default)
        {
            bytesConsumed = 0;
            try
            {
                Deserialize(stream, options);
                bytesConsumed = stream.Length;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TrySerialize(Stream stream, out long bytesWritten, SerializableOptions options = default)
        {
            bytesWritten = 0;
            try
            {
                Serialize(stream, options);
                bytesWritten = stream.Length;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Deserialize(Stream stream, SerializableOptions options = default)
        {
            JsonDocument jsonDocument = JsonDocument.Parse(stream);
            var model = DeserializeEnvelope(jsonDocument.RootElement, options ?? new SerializableOptions());
            this.ReadOnlyProperty = model.ReadOnlyProperty;
            this.ModelA = model.ModelA;
            this.ModelC = model.ModelC;
            this.RawData = model.RawData;
        }

        public void Serialize(Stream stream, SerializableOptions options = default)
        {
            JsonWriterOptions jsonWriterOptions = new JsonWriterOptions();
            if (options.PrettyPrint)
            {
                jsonWriterOptions.Indented = true;
            }
            Utf8JsonWriter writer = new Utf8JsonWriter(stream, jsonWriterOptions);
            ((IUtf8JsonSerializable)this).Write(writer, options ?? new SerializableOptions());
            writer.Flush();
        }
        #endregion
    }
}
