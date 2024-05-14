// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The MachineLearningEncryptionKeyVaultProperties. </summary>
    public partial class MachineLearningEncryptionKeyVaultProperties
    {
        /// <summary> Initializes a new instance of MachineLearningEncryptionKeyVaultProperties. </summary>
        /// <param name="keyVaultArmId"> The ArmId of the keyVault where the customer owned encryption key is present. </param>
        /// <param name="keyIdentifier"> Key vault uri to access the encryption key. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVaultArmId"/> or <paramref name="keyIdentifier"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningEncryptionKeyVaultProperties(ResourceIdentifier keyVaultArmId, string keyIdentifier)
        {
            Argument.AssertNotNull(keyVaultArmId, nameof(keyVaultArmId));
            Argument.AssertNotNull(keyIdentifier, nameof(keyIdentifier));

            KeyVaultArmId = keyVaultArmId;
            KeyIdentifier = keyIdentifier;
        }

        /// <summary> Initializes a new instance of MachineLearningEncryptionKeyVaultProperties. </summary>
        /// <param name="keyVaultArmId"> The ArmId of the keyVault where the customer owned encryption key is present. </param>
        /// <param name="keyIdentifier"> Key vault uri to access the encryption key. </param>
        /// <param name="identityClientId"> For future use - The client id of the identity which will be used to access key vault. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal MachineLearningEncryptionKeyVaultProperties(ResourceIdentifier keyVaultArmId, string keyIdentifier, string identityClientId)
        {
            KeyVaultArmId = keyVaultArmId;
            KeyIdentifier = keyIdentifier;
            IdentityClientId = identityClientId;
        }
    }
}
