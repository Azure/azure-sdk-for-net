// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class PolicyRestrictionContractResource
    {
        /// <summary>
        /// Gets the entity state (ETag) version of the resource. Returns <c>true</c> when the resource exists.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _policyRestrictionClientDiagnostics.CreateScope("PolicyRestrictionContractResource.GetEntityTag");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _policyRestrictionRestClient.CreatePolicyRestrictionGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(response.Status == 200, response);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Gets the entity state (ETag) version of the resource. Returns <c>true</c> when the resource exists.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _policyRestrictionClientDiagnostics.CreateScope("PolicyRestrictionContractResource.GetEntityTag");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _policyRestrictionRestClient.CreatePolicyRestrictionGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(response.Status == 200, response);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

    }
}

