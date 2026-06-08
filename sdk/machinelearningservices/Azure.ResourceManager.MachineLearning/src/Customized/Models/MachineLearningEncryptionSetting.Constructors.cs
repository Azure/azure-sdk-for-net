// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningEncryptionSetting
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningEncryptionSetting"/>. </summary>
        public MachineLearningEncryptionSetting(MachineLearningEncryptionStatus status, MachineLearningEncryptionKeyVaultProperties keyVaultProperties)
            : this(status, identity: null, keyVaultProperties, serializedAdditionalRawData: null)
        {
        }
    }
}
