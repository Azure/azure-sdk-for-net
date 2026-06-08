// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Customer Key vault properties. </summary>
    public partial class MachineLearningEncryptionKeyVaultProperties : KeyVaultProperties, IJsonModel<MachineLearningEncryptionKeyVaultProperties>
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningEncryptionKeyVaultProperties"/>. </summary>
        /// <param name="keyIdentifier"> KeyVault key identifier to encrypt the data. </param>
        /// <param name="keyVaultArmId"> KeyVault Arm Id that contains the data encryption key. </param>
        public MachineLearningEncryptionKeyVaultProperties(string keyIdentifier, Azure.Core.ResourceIdentifier keyVaultArmId)
            : base(keyIdentifier, keyVaultArmId)
        {
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningEncryptionKeyVaultProperties"/>. </summary>
        /// <param name="keyIdentifier"> KeyVault key identifier to encrypt the data. </param>
        /// <param name="keyVaultArmId"> KeyVault Arm Id that contains the data encryption key. </param>
        public MachineLearningEncryptionKeyVaultProperties(string keyIdentifier, string keyVaultArmId)
            : base(keyIdentifier, new Azure.Core.ResourceIdentifier(keyVaultArmId))
        {
        }

        void IJsonModel<MachineLearningEncryptionKeyVaultProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<KeyVaultProperties>)this).Write(writer, options);
        }

        MachineLearningEncryptionKeyVaultProperties IJsonModel<MachineLearningEncryptionKeyVaultProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            KeyVaultProperties keyVaultProperties = KeyVaultProperties.DeserializeKeyVaultProperties(document.RootElement, options);
            return keyVaultProperties is null ? null : new MachineLearningEncryptionKeyVaultProperties(keyVaultProperties.KeyIdentifier, keyVaultProperties.KeyVaultArmId);
        }

        BinaryData IPersistableModel<MachineLearningEncryptionKeyVaultProperties>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<KeyVaultProperties>)this).Write(options);
        }

        MachineLearningEncryptionKeyVaultProperties IPersistableModel<MachineLearningEncryptionKeyVaultProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MachineLearningEncryptionKeyVaultProperties>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        KeyVaultProperties keyVaultProperties = KeyVaultProperties.DeserializeKeyVaultProperties(document.RootElement, options);
                        return keyVaultProperties is null ? null : new MachineLearningEncryptionKeyVaultProperties(keyVaultProperties.KeyIdentifier, keyVaultProperties.KeyVaultArmId);
                    }
                default:
                    throw new FormatException($"The model {nameof(MachineLearningEncryptionKeyVaultProperties)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MachineLearningEncryptionKeyVaultProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
