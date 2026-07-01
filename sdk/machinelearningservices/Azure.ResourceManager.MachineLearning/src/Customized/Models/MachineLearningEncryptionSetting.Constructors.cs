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
    /// <summary> The encryption settings of a workspace. </summary>
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

        /// <summary> Gets or sets the status of the encryption setting. </summary>
        [WirePath("status")]
        public MachineLearningEncryptionStatus Status { get; set; }
        /// <summary> KeyVault details to do the encryption. </summary>
        [WirePath("keyVaultProperties")]
        public MachineLearningEncryptionKeyVaultProperties KeyVaultProperties { get; set; }
        /// <summary> UserAssignedIdentity to be used to fetch the encryption key from keyVault. </summary>
        [WirePath("identity.userAssignedIdentity")]
        public ResourceIdentifier UserAssignedIdentity { get; set; }

        void IJsonModel<MachineLearningEncryptionSetting>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => JsonModelWriteCore(writer, options);

        MachineLearningEncryptionSetting IJsonModel<MachineLearningEncryptionSetting>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return new MachineLearningEncryptionSetting(default, default);
        }

        /// <summary> Writes the JSON representation of the model to the provided writer. </summary>
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
