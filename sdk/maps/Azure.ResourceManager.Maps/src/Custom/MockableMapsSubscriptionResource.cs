// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maps.Mocking
{
    /// <summary>
    /// Suppress the generated OperationStatus Get/GetAsync methods that call
    /// OperationStatusResult.FromResponse() — a method that does not exist on
    /// the ARM common type. This is a generator bug; the emitter produces
    /// deserialization code referencing a non-existent static method.
    /// The replacement methods below use ModelReaderWriter instead.
    /// </summary>
    [CodeGenSuppress("GetAsync", typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    public partial class MockableMapsSubscriptionResource
    {
        internal virtual async Task<Response<OperationStatusResult>> GetAsync(AzureLocation location, string operationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = OperationStatusClientDiagnostics.CreateScope("MockableMapsSubscriptionResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = OperationStatusRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), location, operationId, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
#pragma warning disable AZC0150, IL2026, IL3050 // OperationStatusResult is from Azure.ResourceManager; its context isn't available here
                OperationStatusResult value = ModelReaderWriter.Read<OperationStatusResult>(result.Content);
#pragma warning restore AZC0150, IL2026, IL3050
                return Response.FromValue(value, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual Response<OperationStatusResult> Get(AzureLocation location, string operationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = OperationStatusClientDiagnostics.CreateScope("MockableMapsSubscriptionResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = OperationStatusRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), location, operationId, context);
                Response result = Pipeline.ProcessMessage(message, context);
#pragma warning disable AZC0150, IL2026, IL3050 // OperationStatusResult is from Azure.ResourceManager; its context isn't available here
                OperationStatusResult value = ModelReaderWriter.Read<OperationStatusResult>(result.Content);
#pragma warning restore AZC0150, IL2026, IL3050
                return Response.FromValue(value, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
