// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VpnServerConfigurationResource type. </summary>
    [CodeGenSuppress("GetRadiusSecretsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetRadiusSecrets", typeof(CancellationToken))]
    public partial class VpnServerConfigurationResource
    {
        /// <summary> Invokes the GetRadiusSecretsAsync compatibility operation. </summary>
        public virtual AsyncPageable<RadiusAuthServer> GetRadiusSecretsAsync(CancellationToken cancellationToken = default) => default;
        /// <summary> Invokes the GetRadiusSecrets compatibility operation. </summary>
        public virtual Pageable<RadiusAuthServer> GetRadiusSecrets(CancellationToken cancellationToken = default) => default;
    }
}
