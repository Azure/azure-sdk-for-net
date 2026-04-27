// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward compatibility: v1.15.0 exposed a 3-arg ctor (Uri, string, string keyVaultResourceId)
    // and a public string KeyVaultResourceId property. The generated code has only the 2-arg ctor
    // (keyVaultUri, keyName) plus a ResourceIdentifier-typed KeyVaultArmResourceId. The custom
    // 3-arg ctor and KeyVaultResourceId string forwarding shim preserve the v1.15 surface.
    public partial class NetAppKeyVaultProperties
    {
        /// <summary> Initializes a new instance of <see cref="NetAppKeyVaultProperties"/>. </summary>
        /// <param name="keyVaultUri"> The Uri of KeyVault. </param>
        /// <param name="keyName"> The name of KeyVault key. </param>
        /// <param name="keyVaultResourceId"> The resource ID of KeyVault. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVaultUri"/>, <paramref name="keyName"/> or <paramref name="keyVaultResourceId"/> is null. </exception>
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
