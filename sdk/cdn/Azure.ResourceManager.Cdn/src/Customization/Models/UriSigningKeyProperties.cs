// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class UriSigningKeyProperties
    {
        // Backward compatibility: old API used WritableSubResource secretSource parameter
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriSigningKeyProperties(string keyId, WritableSubResource secretSource) : base(SecretType.UriSigningKey)
        {
            Argument.AssertNotNull(keyId, nameof(keyId));
            Argument.AssertNotNull(secretSource, nameof(secretSource));

            KeyId = keyId;
            SecretSource = new WritableSubResource { Id = secretSource.Id };
        }

        /// <summary> Initializes a new instance of <see cref="UriSigningKeyProperties"/>. </summary>
        /// <param name="keyId"> Defines the customer defined key Id. This id will exist in the incoming request to indicate the key used to form the hash. </param>
        /// <param name="secretSource"> Resource reference to the Azure Key Vault secret. Expected to be in format of /subscriptions/{​​​​​​​​​subscriptionId}​​​​​​​​​/resourceGroups/{​​​​​​​​​resourceGroupName}​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​/providers/Microsoft.KeyVault/vaults/{vaultName}​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​/secrets/{secretName}​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​. </param>
        /// <param name="secretVersion"> Version of the secret to be used. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="keyId"/>, <paramref name="secretSource"/> or <paramref name="secretVersion"/> is null. </exception>
        public UriSigningKeyProperties(string keyId, WritableSubResource secretSource, string secretVersion)
        {
            Argument.AssertNotNull(keyId, nameof(keyId));
            Argument.AssertNotNull(secretSource, nameof(secretSource));
            Argument.AssertNotNull(secretVersion, nameof(secretVersion));

            KeyId = keyId;
            SecretSource = secretSource;
            SecretVersion = secretVersion;
            SecretType = SecretType.UriSigningKey;
        }

        /// <summary> Gets or sets Id. </summary>
        [WirePath("secretSource.id")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier SecretSourceId
        {
            get => SecretSource is null ? default : SecretSource.Id;
            set
            {
                if (SecretSource is null)
                    SecretSource = new WritableSubResource();
                SecretSource.Id = value;
            }
        }
    }
}
