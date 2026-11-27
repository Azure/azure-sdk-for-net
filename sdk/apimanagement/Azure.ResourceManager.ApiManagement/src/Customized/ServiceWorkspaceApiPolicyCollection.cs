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
    public partial class ServiceWorkspaceApiPolicyCollection
    {
        /// <summary> Checks whether the resource exists. </summary>
        /// <param name="policyId"> The resource identifier. </param>
        /// <param name="format"> The export format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Exists without a selector or GetIfExists to retrieve the resource with a selector.", false)]
        public virtual async Task<Response<bool>> ExistsAsync(PolicyName policyId, PolicyExportFormat? format, CancellationToken cancellationToken)
        {
            if (!format.HasValue)
            {
                return await ExistsAsync(policyId, cancellationToken).ConfigureAwait(false);
            }

            using DiagnosticScope scope = _workspaceApiPolicyClientDiagnostics.CreateScope("ServiceWorkspaceApiPolicyCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _workspaceApiPolicyRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, policyId.ToString(), format?.ToString(), context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response response = message.Response;
                if (response.Status == 404)
                {
                    return Response.FromValue(false, response);
                }
                if (response.Status == 200)
                {
                    return Response.FromValue(PolicyContractData.FromResponse(response) != null, response);
                }
                throw new RequestFailedException(response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks whether the resource exists. </summary>
        /// <param name="policyId"> The resource identifier. </param>
        /// <param name="format"> The export format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Exists without a selector or GetIfExists to retrieve the resource with a selector.", false)]
        public virtual Response<bool> Exists(PolicyName policyId, PolicyExportFormat? format, CancellationToken cancellationToken)
        {
            if (!format.HasValue)
            {
                return Exists(policyId, cancellationToken);
            }

            using DiagnosticScope scope = _workspaceApiPolicyClientDiagnostics.CreateScope("ServiceWorkspaceApiPolicyCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _workspaceApiPolicyRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, policyId.ToString(), format?.ToString(), context);
                Pipeline.Send(message, context.CancellationToken);
                Response response = message.Response;
                if (response.Status == 404)
                {
                    return Response.FromValue(false, response);
                }
                if (response.Status == 200)
                {
                    return Response.FromValue(PolicyContractData.FromResponse(response) != null, response);
                }
                throw new RequestFailedException(response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
