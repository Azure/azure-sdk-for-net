// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Peering.Models;

namespace Azure.ResourceManager.Peering
{
    public partial class PeeringServiceResource
    {
        /// <summary>
        /// Updates tags for a peering service with the specified name under the given subscription and resource group.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Peering/peeringServices/{peeringServiceName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PeeringServices_Update. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-05-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="PeeringServiceResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The resource tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<Response<PeeringServiceResource>> UpdateAsync(PeeringServicePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _peeringServicesClientDiagnostics.CreateScope("PeeringServiceResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _peeringServicesRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, PeeringServicePatch.ToRequestContent(patch), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<PeeringServiceData> response = Response.FromValue(PeeringServiceData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new PeeringServiceResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates tags for a peering service with the specified name under the given subscription and resource group.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Peering/peeringServices/{peeringServiceName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PeeringServices_Update. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-05-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="PeeringServiceResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The resource tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual Response<PeeringServiceResource> Update(PeeringServicePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _peeringServicesClientDiagnostics.CreateScope("PeeringServiceResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _peeringServicesRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, PeeringServicePatch.ToRequestContent(patch), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<PeeringServiceData> response = Response.FromValue(PeeringServiceData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new PeeringServiceResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
