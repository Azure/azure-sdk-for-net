// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#pragma warning disable SA1402, SA1649

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

    [CodeGenSuppress("GetProcessDumpAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetProcessDump", typeof(CancellationToken))]
    public partial class SiteProcessResource
    {
        /// <summary> Description for Get a memory dump of a process by its ID for a specific scaled-out instance. </summary>
        public virtual async Task<Response<Stream>> GetProcessDumpAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _processInfoOperationGroupClientDiagnostics.CreateScope("SiteProcessResource.GetProcessDump");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _processInfoOperationGroupRestClient.CreateGetProcessDumpRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
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
        public virtual Response<Stream> GetProcessDump(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _processInfoOperationGroupClientDiagnostics.CreateScope("SiteProcessResource.GetProcessDump");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _processInfoOperationGroupRestClient.CreateGetProcessDumpRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
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

    [CodeGenSuppress("GetInstanceProcessDumpSlotAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetInstanceProcessDumpSlot", typeof(CancellationToken))]
    public partial class SiteSlotInstanceProcessResource
    {
        /// <summary> Description for Get a memory dump of a process by its ID for a specific scaled-out instance (slot). </summary>
        public virtual async Task<Response<Stream>> GetInstanceProcessDumpSlotAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _instanceProcessSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotInstanceProcessResource.GetInstanceProcessDumpSlot");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _instanceProcessSlotOperationGroupRestClient.CreateGetInstanceProcessDumpSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
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
        public virtual Response<Stream> GetInstanceProcessDumpSlot(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _instanceProcessSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotInstanceProcessResource.GetInstanceProcessDumpSlot");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _instanceProcessSlotOperationGroupRestClient.CreateGetInstanceProcessDumpSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
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
