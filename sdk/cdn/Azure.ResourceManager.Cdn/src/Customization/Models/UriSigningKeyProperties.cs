// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds old constructors to UriSigningKeyProperties for backward API compatibility.
    // Reason: The old SDK (AutoRest-generated) provided constructors accepting a WritableSubResource-typed secretSource
    // parameter, but after the TypeSpec migration, the generated constructor takes (string keyId, string secretVersion)
    // and the secretSource type changed to CdnResourceReference (an internal type). Two old constructor signatures —
    // (string keyId, WritableSubResource secretSource) and (string keyId, WritableSubResource secretSource, string secretVersion)
    // — are preserved here to avoid breaking user code, internally converting WritableSubResource to CdnResourceReference.
    public partial class UriSigningKeyProperties
    {
        // Backward compatibility: old API used WritableSubResource secretSource parameter
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriSigningKeyProperties(string keyId, WritableSubResource secretSource) : base(SecretType.UriSigningKey)
        {
            Argument.AssertNotNull(keyId, nameof(keyId));
            Argument.AssertNotNull(secretSource, nameof(secretSource));

            KeyId = keyId;
            SecretSource = new CdnResourceReference { Id = secretSource.Id };
        }

        /// <summary> Initializes a new instance of <see cref="UriSigningKeyProperties"/>. </summary>
        /// <param name="keyId"> Defines the customer defined key Id. This id will exist in the incoming request to indicate the key used to form the hash. </param>
        /// <param name="secretSource"> Resource reference to the Azure Key Vault secret. Expected to be in format of /subscriptions/{​​​​​​​​​subscriptionId}​​​​​​​​​/resourceGroups/{​​​​​​​​​resourceGroupName}​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​/providers/Microsoft.KeyVault/vaults/{vaultName}​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​/secrets/{secretName}​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​​. </param>
        /// <param name="secretVersion"> Version of the secret to be used. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="keyId"/>, <paramref name="secretSource"/> or <paramref name="secretVersion"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriSigningKeyProperties(string keyId, WritableSubResource secretSource, string secretVersion) : base(SecretType.UriSigningKey)
        {
            Argument.AssertNotNull(keyId, nameof(keyId));
            Argument.AssertNotNull(secretSource, nameof(secretSource));
            Argument.AssertNotNull(secretVersion, nameof(secretVersion));

            KeyId = keyId;
            SecretSource = new CdnResourceReference { Id = secretSource.Id };
            SecretVersion = secretVersion;
        }
    }
}
