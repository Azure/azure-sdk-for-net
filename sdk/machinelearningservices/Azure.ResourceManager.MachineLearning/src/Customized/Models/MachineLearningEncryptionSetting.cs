// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The MachineLearningEncryptionSetting. </summary>
    public partial class MachineLearningEncryptionSetting : EncryptionProperty, IJsonModel<MachineLearningEncryptionSetting>
    {
        /// <summary> Initializes a new instance of MachineLearningEncryptionSetting. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningEncryptionSetting(MachineLearningEncryptionStatus status, KeyVaultProperties keyVaultProperties) : base(keyVaultProperties, status)
        {
        }

        /// <summary> Initializes a new instance of MachineLearningEncryptionSetting. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningEncryptionSetting(MachineLearningEncryptionStatus status, MachineLearningEncryptionKeyVaultProperties keyVaultProperties) : base(keyVaultProperties, status)
        {
        }

        /// <summary> KeyVault details to do the encryption. </summary>
        [WirePath("keyVaultProperties")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new MachineLearningEncryptionKeyVaultProperties KeyVaultProperties
        {
            get => base.KeyVaultProperties as MachineLearningEncryptionKeyVaultProperties;
            set => base.KeyVaultProperties = value;
        }

        /// <summary> UserAssignedIdentity to be used to fetch the encryption key from keyVault. </summary>
        [WirePath("identity.userAssignedIdentity")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ResourceIdentifier UserAssignedIdentity
        {
            get => base.UserAssignedIdentity is null ? null : new ResourceIdentifier(base.UserAssignedIdentity);
            set => base.UserAssignedIdentity = value?.ToString();
        }

        void IJsonModel<MachineLearningEncryptionSetting>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<EncryptionProperty>)this).Write(writer, options);
        }

        MachineLearningEncryptionSetting IJsonModel<MachineLearningEncryptionSetting>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMachineLearningEncryptionSetting(document.RootElement, options);
        }

        BinaryData IPersistableModel<MachineLearningEncryptionSetting>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<EncryptionProperty>)this).Write(options);
        }

        MachineLearningEncryptionSetting IPersistableModel<MachineLearningEncryptionSetting>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MachineLearningEncryptionSetting>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeMachineLearningEncryptionSetting(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MachineLearningEncryptionSetting)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MachineLearningEncryptionSetting>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private static MachineLearningEncryptionSetting DeserializeMachineLearningEncryptionSetting(JsonElement element, ModelReaderWriterOptions options)
        {
            EncryptionProperty encryptionProperty = EncryptionProperty.DeserializeEncryptionProperty(element, options);
            if (encryptionProperty?.KeyVaultProperties is null)
            {
                return null;
            }

            var keyVaultProperties = encryptionProperty.KeyVaultProperties as MachineLearningEncryptionKeyVaultProperties
                ?? new MachineLearningEncryptionKeyVaultProperties(encryptionProperty.KeyVaultProperties.KeyIdentifier, encryptionProperty.KeyVaultProperties.KeyVaultArmId);
            return new MachineLearningEncryptionSetting(encryptionProperty.Status, keyVaultProperties)
            {
                CosmosDbResourceId = encryptionProperty.CosmosDbResourceId,
                SearchAccountResourceId = encryptionProperty.SearchAccountResourceId,
                StorageAccountResourceId = encryptionProperty.StorageAccountResourceId,
                UserAssignedIdentity = encryptionProperty.UserAssignedIdentity is null ? null : new ResourceIdentifier(encryptionProperty.UserAssignedIdentity)
            };
        }
    }
}
