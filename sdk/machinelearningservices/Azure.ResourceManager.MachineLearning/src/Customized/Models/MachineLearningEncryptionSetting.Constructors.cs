// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: preserve the legacy public constructor after TypeSpec generated a more
    // explicit internal constructor including identity and raw-data parameters.
    public partial class MachineLearningEncryptionSetting
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningEncryptionSetting"/>. </summary>
        public MachineLearningEncryptionSetting(MachineLearningEncryptionStatus status, MachineLearningEncryptionKeyVaultProperties keyVaultProperties)
            : this(status, identity: null, keyVaultProperties, serializedAdditionalRawData: null)
        {
        }
    }
}
