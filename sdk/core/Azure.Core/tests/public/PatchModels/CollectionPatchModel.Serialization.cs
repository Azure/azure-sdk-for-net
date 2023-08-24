// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.PatchModels
{
    public partial class CollectionPatchModel : IModelJsonSerializable<CollectionPatchModel>, IUtf8JsonSerializable
    {
        internal static CollectionPatchModel Deserialize(JsonElement element)
        {
            string id = default;
            MergePatchDictionary<string> variables = default;
            MergePatchDictionary<ChildPatchModel> children = default;

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }

                if (property.NameEquals("variables"))
                {
                    variables = MergePatchDictionary<string>.Deserialize(element, e => e.GetString()!, (w, n, s) => w.WriteString(n, s));
                }

                if (property.NameEquals("children"))
                {
                    children = MergePatchDictionary<ChildPatchModel>.Deserialize(
                        element,
                        ChildPatchModel.Deserialize,
                        (w, n, m) => m.SerializePatchProperty(w, n),
                        c => c.HasChanges);
                }
            }

            return new CollectionPatchModel(id, variables, children);
        }

        CollectionPatchModel IModelJsonSerializable<CollectionPatchModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidatePatchFormat(this, options.Format);
            return Deserialize(ref reader, options);
        }

        private static CollectionPatchModel Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return Deserialize(doc.RootElement);
        }

        CollectionPatchModel IModelSerializable<CollectionPatchModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidatePatchFormat(this, options.Format);
            return Deserialize(data, options);
        }

        private static CollectionPatchModel Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using JsonDocument doc = JsonDocument.Parse(data);
            return Deserialize(doc.RootElement);
        }

        private void SerializeFull(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);

            writer.WritePropertyName("variables");
            writer.WriteStartObject();
            foreach (KeyValuePair<string, string> item in Variables)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();

            if (_children != null)
            {
                writer.WritePropertyName("children");
                writer.WriteStartObject();
                foreach (KeyValuePair<string, ChildPatchModel> item in Children)
                {
                    writer.WritePropertyName(item.Key);
                    item.Value.SerializeFull(writer);
                }
                writer.WriteEndObject();
            }

            writer.WriteEndObject();
        }

        private void SerializePatch(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            if (_changes.HasChanged(IdProperty))
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(Id);
            }

            if (_variables != null && _variables.HasChanges)
            {
                writer.WritePropertyName("variables");

                (_variables as IModelJsonSerializable<MergePatchDictionary<string>>)
                    .Serialize(writer, new ModelSerializerOptions(ModelSerializerFormat.JsonMergePatch));
            }

            if (_children != null && _children.HasChanges)
            {
                writer.WritePropertyName("children");

                (_children as IModelJsonSerializable<MergePatchDictionary<ChildPatchModel>>)
                    .Serialize(writer, new ModelSerializerOptions(ModelSerializerFormat.JsonMergePatch));
            }

            writer.WriteEndObject();
        }

        void IModelJsonSerializable<CollectionPatchModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
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

        BinaryData IModelSerializable<CollectionPatchModel>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidatePatchFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        public static implicit operator RequestContent(CollectionPatchModel model)
            => RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);

        public static explicit operator CollectionPatchModel(Response response)
        {
            Argument.AssertNotNull(response, nameof(response));
            return Deserialize(response.Content, ModelSerializerOptions.DefaultWireOptions);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<SimplePatchModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);
    }
}
