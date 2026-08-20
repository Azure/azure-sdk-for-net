// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ContainerRegistry.Tasks.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerRegistry.Tasks
{
    [CodeGenSuppress("GetLogSasUriAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetLogSasUri", typeof(CancellationToken))]
    public partial class ContainerRegistryRunResource
    {
        // TODO: Remove these custom methods after https://github.com/microsoft/typespec/issues/11708 is fixed.
        /// <summary> Gets a link to download the run logs. </summary>
        public virtual async Task<Response<ContainerRegistryTaskRunLogResult>> GetLogSasUrlAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _runsClientDiagnostics.CreateScope("ContainerRegistryRunResource.GetLogSasUrl");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _runsRestClient.CreateGetLogSasUriRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ContainerRegistryTaskRunLogResult> response = Response.FromValue(ContainerRegistryTaskRunLogResult.FromResponse(result), result);
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

        /// <summary> Gets a link to download the run logs. </summary>
        public virtual Response<ContainerRegistryTaskRunLogResult> GetLogSasUrl(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _runsClientDiagnostics.CreateScope("ContainerRegistryRunResource.GetLogSasUrl");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _runsRestClient.CreateGetLogSasUriRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ContainerRegistryTaskRunLogResult> response = Response.FromValue(ContainerRegistryTaskRunLogResult.FromResponse(result), result);
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
