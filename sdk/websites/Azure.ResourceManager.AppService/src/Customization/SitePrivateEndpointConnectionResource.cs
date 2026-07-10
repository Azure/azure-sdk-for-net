// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppService
{
    // The generator now models this delete as non-generic ArmOperation, but the shipped SDK returned ArmOperation<BinaryData>.
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(CancellationToken))]
    public partial class SitePrivateEndpointConnectionResource
    {
        /// <summary> Deletes a private endpoint connection. </summary>
        public virtual async Task<ArmOperation<BinaryData>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _remotePrivateEndpointConnectionARMResourceOperationGroupClientDiagnostics.CreateScope("SitePrivateEndpointConnectionResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _remotePrivateEndpointConnectionARMResourceOperationGroupRestClient.CreateDeletePrivateEndpointConnectionRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                AppServiceArmOperation<BinaryData> operation = new AppServiceArmOperation<BinaryData>(new AppServiceBinaryDataOperationSource(), _remotePrivateEndpointConnectionARMResourceOperationGroupClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a private endpoint connection. </summary>
        public virtual ArmOperation<BinaryData> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _remotePrivateEndpointConnectionARMResourceOperationGroupClientDiagnostics.CreateScope("SitePrivateEndpointConnectionResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _remotePrivateEndpointConnectionARMResourceOperationGroupRestClient.CreateDeletePrivateEndpointConnectionRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                AppServiceArmOperation<BinaryData> operation = new AppServiceArmOperation<BinaryData>(new AppServiceBinaryDataOperationSource(), _remotePrivateEndpointConnectionARMResourceOperationGroupClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
