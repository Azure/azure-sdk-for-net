// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects
{
    // Data plane generated sub-client.
    /// <summary> The Deployments sub-client. </summary>
    public partial class DeploymentsOperations
    {
        public virtual ClientResult<ModelDeployment> GetModelDeployment(string name, string clientRequestId = default, CancellationToken cancellationToken = default)
        {
            ClientResult<AssetDeployment> result = GetDeployment(name, clientRequestId, cancellationToken);
            return ClientResult.FromValue((ModelDeployment)result, result.GetRawResponse());
        }

        public virtual async Task<ClientResult<ModelDeployment>> GetModelDeploymentAsync(string name, string clientRequestId = default, CancellationToken cancellationToken = default)
        {
            ClientResult<AssetDeployment> response = await GetDeploymentAsync(name, clientRequestId, cancellationToken).ConfigureAwait(false);
            return ClientResult.FromValue((ModelDeployment)response, response.GetRawResponse());
        }
    }
}
