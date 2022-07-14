// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary>
    /// The authentication info
    /// Please note <see cref="AuthBaseInfo"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="SecretAuthInfo"/>, <see cref="ServicePrincipalCertificateAuthInfo"/>, <see cref="ServicePrincipalSecretAuthInfo"/>, <see cref="SystemAssignedIdentityAuthInfo"/> and <see cref="UserAssignedIdentityAuthInfo"/>.
    /// </summary>
    public abstract partial class AuthBaseInfo
    {
    }
}
