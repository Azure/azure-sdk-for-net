// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: replace latest-emitter generated setter that targets a read-only nested property.
    [CodeGenSuppress("EncryptionKeyIdentifier")]
    public partial class MachineLearningWorkspacePropertiesPatch
    {
        /// <summary> Gets the KeyIdentifier. </summary>
        [WirePath("encryption.keyVaultProperties.keyIdentifier")]
        public string EncryptionKeyIdentifier
        {
            get => Encryption is null ? default : Encryption.KeyIdentifier;
            set => Encryption = new EncryptionUpdateProperties(value);
        }
    }
}
