// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary> The authentication info when authType is servicePrincipal secret. </summary>
    [CodeGenSuppress("ServicePrincipalSecretAuthInfo", typeof(LinkerAuthType), typeof(string), typeof(Guid), typeof(string))]
    public partial class ServicePrincipalSecretAuthInfo : AuthBaseInfo
    {
        /// <summary> Initializes a new instance of ServicePrincipalSecretAuthInfo. </summary>
        /// <param name="authType"> The authentication type. </param>
        /// <param name="clientId"> ServicePrincipal application clientId for servicePrincipal auth. </param>
        /// <param name="principalId"> Principal Id for servicePrincipal auth. </param>
        /// <param name="secret"> Secret for servicePrincipal auth. </param>
        internal ServicePrincipalSecretAuthInfo(LinkerAuthType authType, string clientId, Guid principalId, string secret)
        {
            ClientId = clientId;
            PrincipalId = principalId;
            Secret = secret;
            AuthType = authType;
        }
    }
}
