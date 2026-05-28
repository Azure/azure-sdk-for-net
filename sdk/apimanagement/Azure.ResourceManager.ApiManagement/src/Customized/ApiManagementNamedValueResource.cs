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
    public partial class ApiManagementNamedValueResource
    {
        /// <summary>
        /// Back-compat overload that accepts an <see cref="ETag"/> for the If-Match header. Delegates to the string overload.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="ifMatch"> ETag of the entity. ETag should match the current entity state from the header response of the GET request or it should be * for unconditional update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, ETag ifMatch, CancellationToken cancellationToken = default)
            => await DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Back-compat overload that accepts an <see cref="ETag"/> for the If-Match header. Delegates to the string overload.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="ifMatch"> ETag of the entity. ETag should match the current entity state from the header response of the GET request or it should be * for unconditional update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, ETag ifMatch, CancellationToken cancellationToken = default)
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <summary>
        /// Back-compat overload that accepts an <see cref="ETag"/> for the If-Match header. Delegates to the string overload.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> or <see cref="WaitUntil.Started"/>. </param>
        /// <param name="ifMatch"> ETag of the entity. </param>
        /// <param name="patch"> The patch to apply. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ApiManagementNamedValueResource>> UpdateAsync(WaitUntil waitUntil, ETag ifMatch, ApiManagementNamedValuePatch patch, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, ifMatch.ToString(), patch, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Back-compat overload that accepts an <see cref="ETag"/> for the If-Match header. Delegates to the string overload.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> or <see cref="WaitUntil.Started"/>. </param>
        /// <param name="ifMatch"> ETag of the entity. </param>
        /// <param name="patch"> The patch to apply. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ApiManagementNamedValueResource> Update(WaitUntil waitUntil, ETag ifMatch, ApiManagementNamedValuePatch patch, CancellationToken cancellationToken = default)
            => Update(waitUntil, ifMatch.ToString(), patch, cancellationToken);

        /// <summary>
        /// Gets the entity state (ETag) version of the resource. Returns <c>true</c> when the resource exists.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _namedValueClientDiagnostics.CreateScope("ApiManagementNamedValueResource.GetEntityTag");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _namedValueRestClient.CreateNamedValueGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
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
            using DiagnosticScope scope = _namedValueClientDiagnostics.CreateScope("ApiManagementNamedValueResource.GetEntityTag");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _namedValueRestClient.CreateNamedValueGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(response.Status == 200, response);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

    }
}

