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
    public partial class Deployments
    {
        public virtual ModelDeployment GetModelDeployment(string name, string clientRequestId, RequestOptions options)
        {
            ClientResult response = Get(name, clientRequestId, options);
            ModelDeployment deployment = (ModelDeployment)response;
            return deployment;
        }
        public virtual ModelDeployment GetModelDeployment(string name, string clientRequestId = default, CancellationToken cancellationToken = default)
        {
            ClientResult response = Get(name, clientRequestId, cancellationToken);
            ModelDeployment deployment = (ModelDeployment)response;
            return deployment;
        }
        public virtual async Task<ModelDeployment> GetModelDeploymentAsync(string name, string clientRequestId, RequestOptions options)
        {
            ClientResult response = await GetAsync(name, clientRequestId, options).ConfigureAwait(false);
            ModelDeployment deployment = (ModelDeployment)response;
            return deployment;
        }

        public virtual async Task<ModelDeployment> GetModelDeploymentAsync(string name, string clientRequestId = default, CancellationToken cancellationToken = default)
        {
            ClientResult response = await GetAsync(name, clientRequestId, cancellationToken).ConfigureAwait(false);
            ModelDeployment deployment = (ModelDeployment)response;
            return deployment;
        }
    }
}
