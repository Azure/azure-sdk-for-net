// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.KeyVault.Models;

namespace Azure.ResourceManager.KeyVault
{
    public partial class KeyVaultSecretData
    {
        /// <summary> Initializes a new instance of <see cref="KeyVaultSecretData"/>. </summary>
        /// <param name="properties"> Properties of the secret. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public KeyVaultSecretData(SecretProperties properties)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            Properties = properties;
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Properties of the secret. </summary>
        [WirePath("properties")]
        public SecretProperties Properties { get; set; }
    }
}
