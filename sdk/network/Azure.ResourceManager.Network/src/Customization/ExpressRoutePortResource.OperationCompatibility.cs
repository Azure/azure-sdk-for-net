// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRoutePortResource type. </summary>
    public partial class ExpressRoutePortResource
    {
        /// <summary> Invokes the GetExpressRoutePortAuthorizations compatibility operation. </summary>
        public virtual ExpressRoutePortAuthorizationCollection GetExpressRoutePortAuthorizations()
            => GetCachedClient(client => new ExpressRoutePortAuthorizationCollection(client, Id));
        /// <summary> Invokes the GetExpressRoutePortAuthorizationAsync compatibility operation. </summary>

        [ForwardsClientCalls]
        public virtual Task<Response<ExpressRoutePortAuthorizationResource>> GetExpressRoutePortAuthorizationAsync(string authorizationName, CancellationToken cancellationToken = default)
            => GetExpressRoutePortAuthorizations().GetAsync(authorizationName, cancellationToken);
        /// <summary> Invokes the GetExpressRoutePortAuthorization compatibility operation. </summary>

        [ForwardsClientCalls]
        public virtual Response<ExpressRoutePortAuthorizationResource> GetExpressRoutePortAuthorization(string authorizationName, CancellationToken cancellationToken = default)
            => GetExpressRoutePortAuthorizations().Get(authorizationName, cancellationToken);

        /// <summary> Invokes the GenerateLoaAsync compatibility operation. </summary>
        public virtual Task<Response<GenerateExpressRoutePortsLoaResult>> GenerateLoaAsync(GenerateExpressRoutePortsLoaContent content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GenerateLoa compatibility operation. </summary>
        public virtual Response<GenerateExpressRoutePortsLoaResult> GenerateLoa(GenerateExpressRoutePortsLoaContent content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
