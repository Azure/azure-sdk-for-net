// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Projects
{
    // Data plane generated sub-client.
    /// <summary> The Deployments sub-client. </summary>
    public partial class Deployments
    {
        public virtual ModelDeployment GetModelDeployment(string name, CancellationToken cancellationToken = default)
        {
            Response<AIDeployment> response = GetDeployment(name, cancellationToken);
            ModelDeployment deployment = (ModelDeployment)response.Value;
            return deployment;
        }

        public virtual ModelDeployment GetModelDeployment(string name, RequestContext context)
        {
            Response response = GetDeployment(name, context);
            ModelDeployment deployment = (ModelDeployment)AIDeployment.FromResponse(response);
            return deployment;
        }

        public virtual async Task<ModelDeployment> GetModelDeploymentAsync(string name, CancellationToken cancellationToken = default)
        {
            Response<AIDeployment> response = await GetDeploymentAsync(name, cancellationToken).ConfigureAwait(false);;
            ModelDeployment deployment = (ModelDeployment)response.Value;
            return deployment;
        }

        public virtual async Task<ModelDeployment> GetModelDeploymentAsync(string name, RequestContext context)
        {
            Response response = await GetDeploymentAsync(name, context).ConfigureAwait(false);
            ModelDeployment deployment = (ModelDeployment)AIDeployment.FromResponse(response);
            return deployment;
        }
    }
}