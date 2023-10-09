// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The MachineLearningEncryptionSetting. </summary>
    public partial class MachineLearningEncryptionSetting
    {
        /// <summary> Initializes a new instance of MachineLearningEncryptionSetting. </summary>
        /// <param name="status"> Indicates whether or not the encryption is enabled for the workspace. </param>
        /// <param name="keyVaultProperties"> Customer Key vault properties. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVaultProperties"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningEncryptionSetting(MachineLearningEncryptionStatus status, MachineLearningEncryptionKeyVaultProperties keyVaultProperties)
        {
            Argument.AssertNotNull(keyVaultProperties, nameof(keyVaultProperties));

            Status = status;
            KeyVaultProperties = keyVaultProperties;
        }

        /// <summary> Initializes a new instance of MachineLearningEncryptionSetting. </summary>
        /// <param name="status"> Indicates whether or not the encryption is enabled for the workspace. </param>
        /// <param name="identity"> The identity that will be used to access the key vault for encryption at rest. </param>
        /// <param name="keyVaultProperties"> Customer Key vault properties. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal MachineLearningEncryptionSetting(MachineLearningEncryptionStatus status, MachineLearningCmkIdentity identity, MachineLearningEncryptionKeyVaultProperties keyVaultProperties)
        {
            Status = status;
            Identity = identity;
            KeyVaultProperties = keyVaultProperties;
        }
    }
}
