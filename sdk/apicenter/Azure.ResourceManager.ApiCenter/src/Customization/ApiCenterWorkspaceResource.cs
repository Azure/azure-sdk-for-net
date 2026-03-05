// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ApiCenter
{
    public partial class ApiCenterWorkspaceResource
    {
        /// <summary> Checks if this resource exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> HeadAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _workspacesClientDiagnostics.CreateScope("ApiCenterWorkspaceResource.Head");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken,
                    ErrorOptions = ErrorOptions.NoThrow
                };
                HttpMessage message = _workspacesRestClient.CreateHeadWorkspaceRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(response.Status != 404, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks if this resource exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Head(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _workspacesClientDiagnostics.CreateScope("ApiCenterWorkspaceResource.Head");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken,
                    ErrorOptions = ErrorOptions.NoThrow
                };
                HttpMessage message = _workspacesRestClient.CreateHeadWorkspaceRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(response.Status != 404, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
