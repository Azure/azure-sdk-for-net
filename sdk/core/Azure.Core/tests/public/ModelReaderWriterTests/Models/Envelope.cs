// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests.Models
{
    public class Envelope<T> : IJsonModel<Envelope<T>>, IUtf8JsonSerializable
    {
        private Dictionary<string, BinaryData> RawData { get; set; } = new Dictionary<string, BinaryData>();

        public string ReadOnlyProperty { get; private set; } = "readonly";

        public Envelope()
        {
        }

        public Envelope(string readOnlyProperty)
        {
            ReadOnlyProperty = readOnlyProperty;
        }

        internal Envelope(string readOnlyProperty, CatReadOnlyProperty modelA, T modelT, Dictionary<string, BinaryData> rawData)
        {
            ReadOnlyProperty = readOnlyProperty;
            ModelA = modelA;
            ModelT = modelT;
            RawData = rawData;
        }

        public CatReadOnlyProperty ModelA { get; set; }
        public T ModelT { get; set; }

        #region Serialization
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<Envelope<T>>)this).Write(writer, ModelReaderWriterHelper.WireOptions);

        void IJsonModel<Envelope<T>>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            Serialize(writer, options);
        }

        private void Serialize(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == "J")
            {
                writer.WritePropertyName("readOnlyProperty"u8);
                writer.WriteStringValue(ReadOnlyProperty);
            }

            writer.WritePropertyName("modelA"u8);
            ((IJsonModel<CatReadOnlyProperty>)ModelA).Write(writer, options);
            writer.WritePropertyName("modelC"u8);
            SerializeT(writer, options);

            if (options.Format == "J")
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

        internal static Envelope<T> DeserializeEnvelope(JsonElement element, ModelReaderWriterOptions options = default)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

            string readonlyProperty = "";
            CatReadOnlyProperty modelA = new CatReadOnlyProperty();
            T modelT = default(T);
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
                    modelT = DeserializeT(property.Value, options);
                    continue;
                }

                if (options.Format == "J")
                {
                    //this means it's an modelC property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new Envelope<T>(readonlyProperty, modelA, modelT, rawData);
        }

        private void SerializeT(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ObjectSerializer serializer = GetObjectSerializer(options);
            BinaryData data = serializer.Serialize(ModelT);
#if NET6_0_OR_GREATER
            writer.WriteRawValue(data);
#else
            JsonSerializer.Serialize(writer, JsonDocument.Parse(data.ToString()).RootElement);
#endif
        }

        private static ObjectSerializer GetObjectSerializer(ModelReaderWriterOptions options)
        {
            //var serializer = options.ObjectSerializerResolver is not null ? options.ObjectSerializerResolver(typeof(T)) : null;
            //return serializer ?? JsonObjectSerializer.Default;
            return JsonObjectSerializer.Default;
        }

        private static T DeserializeT(JsonElement element, ModelReaderWriterOptions options)
        {
            ObjectSerializer serializer = GetObjectSerializer(options);
            MemoryStream m = new MemoryStream();
            Utf8JsonWriter w = new Utf8JsonWriter(m);
            element.WriteTo(w);
            w.Flush();
            m.Position = 0;
            return (T)serializer.Deserialize(m, typeof(T), default);
        }

        Envelope<T> IPersistableModel<Envelope<T>>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            return DeserializeEnvelope(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        Envelope<T> IJsonModel<Envelope<T>>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeEnvelope(doc.RootElement, options);
        }

        BinaryData IPersistableModel<Envelope<T>>.Write(ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            return ModelReaderWriter.Write(this, options);
        }

        string IPersistableModel<Envelope<T>>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        #endregion
    }
}
