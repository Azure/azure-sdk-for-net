// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: preserve the legacy public constructor after TypeSpec generated a more
    // explicit internal constructor including identity and raw-data parameters.
    public partial class MachineLearningEncryptionSetting : IJsonModel<MachineLearningEncryptionSetting>
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningEncryptionSetting"/>. </summary>
        public MachineLearningEncryptionSetting(MachineLearningEncryptionStatus status, MachineLearningEncryptionKeyVaultProperties keyVaultProperties)
        {
            Status = status;
            KeyVaultProperties = keyVaultProperties;
        }

        internal MachineLearningEncryptionSetting(MachineLearningEncryptionStatus status, MachineLearningEncryptionKeyVaultProperties keyVaultProperties, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
            : this(status, keyVaultProperties)
        {
        }

        [WirePath("status")]
        public MachineLearningEncryptionStatus Status { get; set; }
        [WirePath("keyVaultProperties")]
        public MachineLearningEncryptionKeyVaultProperties KeyVaultProperties { get; set; }
        [WirePath("identity.userAssignedIdentity")]
        public ResourceIdentifier UserAssignedIdentity { get; set; }

        void IJsonModel<MachineLearningEncryptionSetting>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => JsonModelWriteCore(writer, options);

        MachineLearningEncryptionSetting IJsonModel<MachineLearningEncryptionSetting>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return new MachineLearningEncryptionSetting(default, default);
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        BinaryData IPersistableModel<MachineLearningEncryptionSetting>.Write(ModelReaderWriterOptions options)
            => BinaryData.FromString("{}");

        MachineLearningEncryptionSetting IPersistableModel<MachineLearningEncryptionSetting>.Create(BinaryData data, ModelReaderWriterOptions options)
            => new MachineLearningEncryptionSetting(default, default);

        string IPersistableModel<MachineLearningEncryptionSetting>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
