// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Batch
{
    public partial class BatchAccountPoolResource
    {
        // Keep the 1.7.0 overloads and serialize the original data model alongside the new patch API.

        /// <summary> Updates the properties of an existing pool. </summary>
        /// <param name="data"> Pool properties to update. Properties not supplied are unchanged. </param>
        /// <param name="ifMatch"> The entity tag of the pool. Omit it or use "*" to update unconditionally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<Response<BatchAccountPoolResource>> UpdateAsync(BatchAccountPoolData data, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _poolClientDiagnostics.CreateScope("BatchAccountPoolResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _poolRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, BatchAccountPoolData.ToRequestContent(data), ifMatch, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return CreateUpdateResponse(result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the properties of an existing pool. </summary>
        /// <param name="data"> Pool properties to update. Properties not supplied are unchanged. </param>
        /// <param name="ifMatch"> The entity tag of the pool. Omit it or use "*" to update unconditionally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual Response<BatchAccountPoolResource> Update(BatchAccountPoolData data, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _poolClientDiagnostics.CreateScope("BatchAccountPoolResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _poolRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, BatchAccountPoolData.ToRequestContent(data), ifMatch, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return CreateUpdateResponse(result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<BatchAccountPoolResource> CreateUpdateResponse(Response response)
        {
            BatchAccountPoolData data = BatchAccountPoolData.FromResponse(response);
            if (data == null)
            {
                throw new RequestFailedException(response);
            }

            return Response.FromValue(new BatchAccountPoolResource(Client, data), response);
        }
    }
}
