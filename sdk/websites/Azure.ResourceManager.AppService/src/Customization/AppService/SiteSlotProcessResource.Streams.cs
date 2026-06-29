// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppService
{
    [CodeGenSuppress("GetProcessDumpSlotAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetProcessDumpSlot", typeof(CancellationToken))]
    public partial class SiteSlotProcessResource
    {
        /// <summary> Description for Get a memory dump of a process by its ID for a specific scaled-out instance (slot). </summary>
        public virtual async Task<Response<Stream>> GetProcessDumpSlotAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _processSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotProcessResource.GetProcessDumpSlot");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _processSlotOperationGroupRestClient.CreateGetProcessDumpSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Get a memory dump of a process by its ID for a specific scaled-out instance (slot). </summary>
        public virtual Response<Stream> GetProcessDumpSlot(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _processSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotProcessResource.GetProcessDumpSlot");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _processSlotOperationGroupRestClient.CreateGetProcessDumpSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
