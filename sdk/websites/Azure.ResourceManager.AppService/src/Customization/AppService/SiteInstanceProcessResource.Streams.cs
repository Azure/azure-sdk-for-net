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

// ROOT CAUSE: GA 1.5.0 shipped GetProcessDump / GetInstanceProcessDump (and
// their slot variants) returning Response<Stream>. The new TypeSpec generator
// emits these as Response<BinaryData>. Suppress and redeclare with the GA
// Stream-returning contract on each ProcessResource class.
namespace Azure.ResourceManager.AppService
{
    [CodeGenSuppress("GetInstanceProcessDumpAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetInstanceProcessDump", typeof(CancellationToken))]
    public partial class SiteInstanceProcessResource
    {
        /// <summary> Description for Get a memory dump of a process by its ID for a specific scaled-out instance. </summary>
        public virtual async Task<Response<Stream>> GetInstanceProcessDumpAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _processInfosClientDiagnostics.CreateScope("SiteInstanceProcessResource.GetInstanceProcessDump");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _processInfosRestClient.CreateGetInstanceProcessDumpRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Get a memory dump of a process by its ID for a specific scaled-out instance. </summary>
        public virtual Response<Stream> GetInstanceProcessDump(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _processInfosClientDiagnostics.CreateScope("SiteInstanceProcessResource.GetInstanceProcessDump");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _processInfosRestClient.CreateGetInstanceProcessDumpRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
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
