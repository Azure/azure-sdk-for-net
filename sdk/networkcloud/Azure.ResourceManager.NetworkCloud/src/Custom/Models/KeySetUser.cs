// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // Customization: Provides a constructor overload accepting NetworkCloudSshPublicKey
    // and directly assigns it to the internal SshPublicKey property.
    public partial class KeySetUser
    {
        /// <summary> Initializes a new instance of <see cref="KeySetUser"/>. </summary>
        /// <param name="azureUserName"> The user name that will be used for access. </param>
        /// <param name="sshPublicKey"> The SSH public key that will be provisioned for user access. The user is expected to have the corresponding SSH private key for logging in. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="azureUserName"/> or <paramref name="sshPublicKey"/> is null. </exception>
        public KeySetUser(string azureUserName, NetworkCloudSshPublicKey sshPublicKey)
        {
            Argument.AssertNotNull(azureUserName, nameof(azureUserName));
            Argument.AssertNotNull(sshPublicKey, nameof(sshPublicKey));

            AzureUserName = azureUserName;
            SshPublicKey = sshPublicKey;
        }
    }
}
