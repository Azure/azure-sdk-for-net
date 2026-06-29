// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningEncryptionKeyVaultProperties : IJsonModel<MachineLearningEncryptionKeyVaultProperties>
    {
        public MachineLearningEncryptionKeyVaultProperties(ResourceIdentifier keyVaultArmId, string keyIdentifier)
        {
            KeyVaultArmId = keyVaultArmId;
            KeyIdentifier = keyIdentifier;
        }

        [WirePath("identityClientId")]
        public string IdentityClientId { get; set; }
        [WirePath("keyIdentifier")]
        public string KeyIdentifier { get; set; }
        [WirePath("keyVaultArmId")]
        public ResourceIdentifier KeyVaultArmId { get; set; }

        void IJsonModel<MachineLearningEncryptionKeyVaultProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => JsonModelWriteCore(writer, options);

        MachineLearningEncryptionKeyVaultProperties IJsonModel<MachineLearningEncryptionKeyVaultProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return new MachineLearningEncryptionKeyVaultProperties(default, default);
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        BinaryData IPersistableModel<MachineLearningEncryptionKeyVaultProperties>.Write(ModelReaderWriterOptions options)
            => BinaryData.FromString("{}");

        MachineLearningEncryptionKeyVaultProperties IPersistableModel<MachineLearningEncryptionKeyVaultProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
            => new MachineLearningEncryptionKeyVaultProperties(default, default);

        string IPersistableModel<MachineLearningEncryptionKeyVaultProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
