// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

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
    public partial class ExpressRoutePortResource
    {
        public virtual ExpressRoutePortAuthorizationCollection GetExpressRoutePortAuthorizations()
            => GetCachedClient(client => new ExpressRoutePortAuthorizationCollection(client, Id));

        [ForwardsClientCalls]
        public virtual Task<Response<ExpressRoutePortAuthorizationResource>> GetExpressRoutePortAuthorizationAsync(string authorizationName, CancellationToken cancellationToken = default)
            => GetExpressRoutePortAuthorizations().GetAsync(Id.Name, authorizationName, cancellationToken);

        [ForwardsClientCalls]
        public virtual Response<ExpressRoutePortAuthorizationResource> GetExpressRoutePortAuthorization(string authorizationName, CancellationToken cancellationToken = default)
            => GetExpressRoutePortAuthorizations().Get(Id.Name, authorizationName, cancellationToken);

        public virtual Task<Response<GenerateExpressRoutePortsLoaResult>> GenerateLoaAsync(GenerateExpressRoutePortsLoaContent content, CancellationToken cancellationToken) => default;
        public virtual Response<GenerateExpressRoutePortsLoaResult> GenerateLoa(GenerateExpressRoutePortsLoaContent content, CancellationToken cancellationToken) => default;
    }
}
