// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Properties of key vault. </summary>
    public partial class NetAppKeyVaultProperties
    {
        /// <summary> The resource ID of KeyVault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string KeyVaultResourceId
        {
            get { return KeyVaultArmResourceId.ToString(); }
            set { KeyVaultArmResourceId = string.IsNullOrEmpty(value)? null : new ResourceIdentifier(value); }
        }

        /// <summary> Initializes a new instance of <see cref="NetAppKeyVaultProperties"/>. </summary>
        /// <param name="keyVaultUri"> The Uri of KeyVault. </param>
        /// <param name="keyName"> The name of KeyVault key. </param>
        /// <param name="keyVaultResourceId"> The resource ID of KeyVault. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVaultUri"/>, <paramref name="keyName"/> or <paramref name="keyVaultResourceId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppKeyVaultProperties(Uri keyVaultUri, string keyName, string keyVaultResourceId)
            {
                Argument.AssertNotNull(keyVaultUri, nameof(keyVaultUri));
                Argument.AssertNotNull(keyName, nameof(keyName));
                Argument.AssertNotNull(keyVaultResourceId, nameof(keyVaultResourceId));

                KeyVaultUri = keyVaultUri;
                KeyName = keyName;
                KeyVaultArmResourceId = new ResourceIdentifier(keyVaultResourceId);
            }
        }
}
