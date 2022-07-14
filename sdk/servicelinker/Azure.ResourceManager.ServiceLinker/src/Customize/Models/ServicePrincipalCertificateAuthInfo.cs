// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary> The authentication info when authType is servicePrincipal certificate. </summary>
    [CodeGenSuppress("ServicePrincipalCertificateAuthInfo", typeof(LinkerAuthType), typeof(string), typeof(Guid), typeof(string))]
    public partial class ServicePrincipalCertificateAuthInfo : AuthBaseInfo
    {
        /// <summary> Initializes a new instance of ServicePrincipalCertificateAuthInfo. </summary>
        /// <param name="authType"> The authentication type. </param>
        /// <param name="clientId"> Application clientId for servicePrincipal auth. </param>
        /// <param name="principalId"> Principal Id for servicePrincipal auth. </param>
        /// <param name="certificate"> ServicePrincipal certificate for servicePrincipal auth. </param>
        internal ServicePrincipalCertificateAuthInfo(LinkerAuthType authType, string clientId, Guid principalId, string certificate)
        {
            ClientId = clientId;
            PrincipalId = principalId;
            Certificate = certificate;
            AuthType = authType;
        }
    }
}
