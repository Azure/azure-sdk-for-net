// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary> The authentication info when authType is systemAssignedIdentity. </summary>
    [CodeGenSuppress("SystemAssignedIdentityAuthInfo", typeof(LinkerAuthType))]
    public partial class SystemAssignedIdentityAuthInfo : AuthBaseInfo
    {
        /// <summary> Initializes a new instance of SystemAssignedIdentityAuthInfo. </summary>
        /// <param name="authType"> The authentication type. </param>
        internal SystemAssignedIdentityAuthInfo(LinkerAuthType authType)
        {
            AuthType = authType;
        }
    }
}
