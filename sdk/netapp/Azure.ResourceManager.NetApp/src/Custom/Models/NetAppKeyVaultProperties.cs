// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Properties of key vault. </summary>
    public partial class NetAppKeyVaultProperties
    {
        /// <summary> Initializes a new instance of <see cref="NetAppKeyVaultProperties"/>. </summary>
        /// <param name="keyVaultUri"> The Uri of KeyVault. </param>
        /// <param name="keyName"> The name of KeyVault key. </param>
        /// <param name="keyVaultResourceId"> The resource ID of KeyVault. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVaultUri"/>, <paramref name="keyName"/> or <paramref name="keyVaultResourceId"/> is null. </exception>
        // Backward compatibility: this ctor was the only public ctor in v1.15.0 and remains the primary
        // way to construct NetAppKeyVaultProperties. Do not hide with [EditorBrowsable(Never)] without a replacement.
        public NetAppKeyVaultProperties(Uri keyVaultUri, string keyName, string keyVaultResourceId)
        {
            Argument.AssertNotNull(keyVaultUri, nameof(keyVaultUri));
            Argument.AssertNotNull(keyName, nameof(keyName));
            Argument.AssertNotNull(keyVaultResourceId, nameof(keyVaultResourceId));

            KeyVaultUri = keyVaultUri;
            KeyName = keyName;
            KeyVaultArmResourceId = new ResourceIdentifier(keyVaultResourceId);
        }

        /// <summary> The resource ID of KeyVault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string KeyVaultResourceId
        {
            get => KeyVaultArmResourceId?.ToString();
            set => KeyVaultArmResourceId = string.IsNullOrEmpty(value) ? null : new ResourceIdentifier(value);
        }
    }
}
