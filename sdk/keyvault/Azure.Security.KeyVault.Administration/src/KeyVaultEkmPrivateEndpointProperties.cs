// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary> The properties of an External Key Manager (EKM) proxy private endpoint. </summary>
    [CodeGenType("EkmPrivateEndpointProperties")]
    public partial class KeyVaultEkmPrivateEndpointProperties
    {
        /// <summary> Alias of the Private Link Service that the private endpoint connects to. </summary>
        [CodeGenMember("PrivateLinkServiceId")]
        public string PrivateLinkServiceAlias { get; }
    }
}
