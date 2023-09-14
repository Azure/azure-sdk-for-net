// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    public class Envelope<T> : IModelJsonSerializable<Envelope<T>>, IUtf8JsonSerializable
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

        public static implicit operator RequestContent(Envelope<T> envelope)
        {
            if (envelope == null)
            {
                return null;
            }

            return RequestContent.Create(envelope, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator Envelope<T>(Response response)
        {
            Argument.AssertNotNull(response, nameof(response));

            using JsonDocument jsonDocument = JsonDocument.Parse(response.ContentStream);
            return DeserializeEnvelope(jsonDocument.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        #region Serialization
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Envelope<T>>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<Envelope<T>>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            Serialize(writer, options);
        }

        private void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("readOnlyProperty"u8);
                writer.WriteStringValue(ReadOnlyProperty);
            }

            writer.WritePropertyName("modelA"u8);
            ((IModelJsonSerializable<CatReadOnlyProperty>)ModelA).Serialize(writer, options);
            writer.WritePropertyName("modelC"u8);
            SerializeT(writer, options);

            if (options.Format == ModelSerializerFormat.Json)
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

        internal static Envelope<T> DeserializeEnvelope(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

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

                if (options.Format == ModelSerializerFormat.Json)
                {
                    //this means it's an modelC property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new Envelope<T>(readonlyProperty, modelA, modelT, rawData);
        }

        private void SerializeT(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ObjectSerializer serializer = GetObjectSerializer(options);
            BinaryData data = serializer.Serialize(ModelT);
#if NET6_0_OR_GREATER
            writer.WriteRawValue(data);
#else
            JsonSerializer.Serialize(writer, JsonDocument.Parse(data.ToString()).RootElement);
#endif
        }

        private static ObjectSerializer GetObjectSerializer(ModelSerializerOptions options)
        {
            var serializer = options.ObjectSerializerResolver is not null ? options.ObjectSerializerResolver(typeof(T)) : null;
            return serializer ?? JsonObjectSerializer.Default;
        }

        private static T DeserializeT(JsonElement element, ModelSerializerOptions options)
        {
            ObjectSerializer serializer = GetObjectSerializer(options);
            MemoryStream m = new MemoryStream();
            Utf8JsonWriter w = new Utf8JsonWriter(m);
            element.WriteTo(w);
            w.Flush();
            m.Position = 0;
            return (T)serializer.Deserialize(m, typeof(T), default);
        }

        Envelope<T> IModelSerializable<Envelope<T>>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return DeserializeEnvelope(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        Envelope<T> IModelJsonSerializable<Envelope<T>>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeEnvelope(doc.RootElement, options);
        }

        BinaryData IModelSerializable<Envelope<T>>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }
        #endregion
    }
}
