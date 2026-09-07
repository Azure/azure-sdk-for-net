// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppService
{
    [CodeGenSuppress("GetCallbackUriAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetCallbackUri", typeof(CancellationToken))]
    public partial class WorkflowTriggerResource
    {
        // TODO: Remove these custom methods after https://github.com/microsoft/typespec/issues/11708 is fixed.
        /// <summary> Get the callback URL for a workflow trigger. </summary>
        public virtual async Task<Response<WorkflowTriggerCallbackUri>> GetCallbackUrlAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _workflowTriggersClientDiagnostics.CreateScope("WorkflowTriggerResource.GetCallbackUrl");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _workflowTriggersRestClient.CreateGetCallbackUrlRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<WorkflowTriggerCallbackUri> response = Response.FromValue(WorkflowTriggerCallbackUri.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the callback URL for a workflow trigger. </summary>
        public virtual Response<WorkflowTriggerCallbackUri> GetCallbackUrl(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _workflowTriggersClientDiagnostics.CreateScope("WorkflowTriggerResource.GetCallbackUrl");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _workflowTriggersRestClient.CreateGetCallbackUrlRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<WorkflowTriggerCallbackUri> response = Response.FromValue(WorkflowTriggerCallbackUri.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
