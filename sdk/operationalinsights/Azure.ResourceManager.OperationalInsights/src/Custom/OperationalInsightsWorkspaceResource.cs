// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.OperationalInsights
{
    // Backward-compat justification: the GA SDK exposed gateway deletion overloads with Guid gateway IDs.
    public partial class OperationalInsightsWorkspaceResource
    {
        /// <summary> Delete a Log Analytics gateway. </summary>
        public virtual Task<Response> DeleteGatewayAsync(Guid gatewayId, CancellationToken cancellationToken = default)
            => DeleteGatewayAsync(gatewayId.ToString(), cancellationToken);

        /// <summary> Delete a Log Analytics gateway. </summary>
        public virtual Response DeleteGateway(Guid gatewayId, CancellationToken cancellationToken = default)
            => DeleteGateway(gatewayId.ToString(), cancellationToken);
    }
}
