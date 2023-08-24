// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    internal partial class MergePatchDictionary<T> : IModelJsonSerializable<MergePatchDictionary<T>>
    {
        #region Serialize
        void IModelJsonSerializable<MergePatchDictionary<T>>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidatePatchFormat(this, options.Format);

            if (options.Format.ToString() == ModelSerializerFormat.Json ||
                options.Format.ToString() == ModelSerializerFormat.Wire)
            {
                SerializeFull(writer);
            }
            else if (options.Format.ToString() == ModelSerializerFormat.JsonMergePatch)
            {
                SerializePatch(writer);
            }
        }

        BinaryData IModelSerializable<MergePatchDictionary<T>>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidatePatchFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        private void SerializeFull(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            foreach (KeyValuePair<string, T> kvp in _dictionary)
            {
                if (kvp.Value == null)
                {
                    writer.WritePropertyName(kvp.Key);
                    writer.WriteNullValue();
                }
                else
                {
                    _serializeItem(writer, kvp.Key, kvp.Value);
                }
            }

            writer.WriteEndObject();
        }

        private void SerializePatch(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            foreach (KeyValuePair<string, bool> kvp in _changed)
            {
                if (kvp.Value)
                {
                    if (!_dictionary.TryGetValue(kvp.Key, out T? value) || value == null)
                    {
                        writer.WritePropertyName(kvp.Key);
                        writer.WriteNullValue();
                    }
                    else
                    {
                        _serializeItem(writer, kvp.Key, value);
                    }
                }
            }

            writer.WriteEndObject();
        }
        #endregion

        #region Deserialize

        public static MergePatchDictionary<T> Deserialize(JsonElement element,
            Func<JsonElement, T> deserializeItem,
            Action<Utf8JsonWriter, string, T> serializeItem,
            Func<T, bool>? itemHasChanges = default)
        {
            Dictionary<string, T> values = new();
            foreach (JsonProperty property in element.EnumerateObject())
            {
                values.Add(property.Name, deserializeItem(property.Value));
            }

            return new MergePatchDictionary<T>(
                deserializeItem,
                serializeItem,
                itemHasChanges,
                values);
        }

        MergePatchDictionary<T> IModelJsonSerializable<MergePatchDictionary<T>>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return Deserialize(doc.RootElement,
                _deserializeItem,
                _serializeItem,
                _itemHasChanges);
        }

        MergePatchDictionary<T> IModelSerializable<MergePatchDictionary<T>>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using JsonDocument doc = JsonDocument.Parse(data);
            return Deserialize(doc.RootElement,
                _deserializeItem,
                _serializeItem,
                _itemHasChanges);
        }

        #endregion
    }
}
