// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ComputeBulkActions
{
    /// <summary>
    /// A class representing a BulkAction along with the instance operations that can be performed on it.
    /// </summary>
    public partial class BulkActionResource
    {
        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BulkActionResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _bulkActionsClientDiagnostics.CreateScope("BulkActionResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _bulkActionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<BulkActionData> response = Response.FromValue(BulkActionData.FromResponse(result), result);
                return Response.FromValue(new BulkActionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BulkActionResource> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _bulkActionsClientDiagnostics.CreateScope("BulkActionResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _bulkActionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<BulkActionData> response = Response.FromValue(BulkActionData.FromResponse(result), result);
                return Response.FromValue(new BulkActionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
