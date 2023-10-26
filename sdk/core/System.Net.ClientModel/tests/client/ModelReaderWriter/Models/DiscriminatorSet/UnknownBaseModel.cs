// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using System.Text.Json;

namespace System.Net.ClientModel.Tests.Client.ModelReaderWriterTests.Models
{
    internal class UnknownBaseModel : BaseModel, IUtf8JsonContentWriteable, IJsonModel<BaseModel>
    {
        public UnknownBaseModel()
            : base(null)
        {
            Kind = "Unknown";
        }

        internal UnknownBaseModel(string kind, string name, Dictionary<string, BinaryData> rawData)
            : base(rawData)
        {
            Kind = kind;
            Name = name;
        }

        void IUtf8JsonContentWriteable.Write(Utf8JsonWriter writer) => Serialize(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<BaseModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            Serialize(writer, options);
        }

        private void Serialize(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            if (OptionalProperty.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                SerializeRawData(writer);
            }
            writer.WriteEndObject();
        }

        internal static BaseModel DeserializeUnknownBaseModel(JsonElement element, ModelReaderWriterOptions options = default) => DeserializeBaseModel(element, options);

        BaseModel IModel<BaseModel>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            return DeserializeUnknownBaseModel(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        BaseModel IJsonModel<BaseModel>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeUnknownBaseModel(doc.RootElement, options);
        }

        BinaryData IModel<BaseModel>.Write(ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            return ModelReaderWriter.WriteCore(this, options);
        }
    }
}
