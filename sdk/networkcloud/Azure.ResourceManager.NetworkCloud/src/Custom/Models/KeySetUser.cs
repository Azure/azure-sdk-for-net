// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class KeySetUser
    {
        /// <summary> Initializes a new instance of <see cref="KeySetUser"/>. </summary>
        /// <param name="azureUserName"> The user name that will be used for access. </param>
        /// <param name="sshPublicKey"> The SSH public key that will be provisioned for user access. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public KeySetUser(string azureUserName, NetworkCloudSshPublicKey sshPublicKey)
            : this(azureUserName, sshPublicKey?.KeyData)
        {
        }
    }
}
