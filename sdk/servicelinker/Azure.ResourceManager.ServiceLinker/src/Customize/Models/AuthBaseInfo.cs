// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary>
    /// The authentication info
    /// Please note <see cref="AuthBaseInfo"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="SecretAuthInfo"/>, <see cref="ServicePrincipalCertificateAuthInfo"/>, <see cref="ServicePrincipalSecretAuthInfo"/>, <see cref="SystemAssignedIdentityAuthInfo"/> and <see cref="UserAssignedIdentityAuthInfo"/>.
    /// </summary>
    [CodeGenSuppress("AuthBaseInfo")]
    [CodeGenSuppress("AuthBaseInfo", typeof(LinkerAuthType))]
    public abstract partial class AuthBaseInfo
    {
        /// <summary> The authentication type. </summary>
        internal LinkerAuthType AuthType { get; set; }
    }
}
