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
    public partial class ServiceWorkspaceApiSchemaResource
    {
        // TODO: Remove manual implementation once https://github.com/Azure/azure-sdk-for-net/issues/59089
        // is fixed in the MPG generator. The generator currently emits broken Response<bool> code for
        // HEAD operations annotated with @responseAsBool (extra 'accept' parameter + CS0472 + IL2026/IL3050).
        /// <summary>
        /// Gets the entity state (ETag) version of the resource. Returns <c>true</c> when the resource exists.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _workspaceApiSchemaClientDiagnostics.CreateScope("ServiceWorkspaceApiSchemaResource.GetEntityTag");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _workspaceApiSchemaRestClient.CreateWorkspaceApiSchemaGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(response.Status == 200, response);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        // TODO: Remove manual implementation once https://github.com/Azure/azure-sdk-for-net/issues/59089
        // is fixed in the MPG generator. The generator currently emits broken Response<bool> code for
        // HEAD operations annotated with @responseAsBool (extra 'accept' parameter + CS0472 + IL2026/IL3050).
        /// <summary>
        /// Gets the entity state (ETag) version of the resource. Returns <c>true</c> when the resource exists.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _workspaceApiSchemaClientDiagnostics.CreateScope("ServiceWorkspaceApiSchemaResource.GetEntityTag");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _workspaceApiSchemaRestClient.CreateWorkspaceApiSchemaGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(response.Status == 200, response);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }
    }
}
