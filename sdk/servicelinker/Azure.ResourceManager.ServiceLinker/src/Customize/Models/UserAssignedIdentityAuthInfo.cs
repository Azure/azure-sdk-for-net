// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary> The authentication info when authType is userAssignedIdentity. </summary>
    [CodeGenSuppress("UserAssignedIdentityAuthInfo", typeof(LinkerAuthType), typeof(string), typeof(string))]
    public partial class UserAssignedIdentityAuthInfo : AuthBaseInfo
    {
        /// <summary> Initializes a new instance of UserAssignedIdentityAuthInfo. </summary>
        /// <param name="authType"> The authentication type. </param>
        /// <param name="clientId"> Client Id for userAssignedIdentity. </param>
        /// <param name="subscriptionId"> Subscription id for userAssignedIdentity. </param>
        internal UserAssignedIdentityAuthInfo(LinkerAuthType authType, string clientId, string subscriptionId)
        {
            ClientId = clientId;
            SubscriptionId = subscriptionId;
            AuthType = authType;
        }
    }
}
