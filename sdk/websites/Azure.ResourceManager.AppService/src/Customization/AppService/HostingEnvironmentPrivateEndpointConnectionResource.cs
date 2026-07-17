// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// ROOT CAUSE: GA 1.5.0 shipped Update overloads on private endpoint connection resource types
// accepting the legacy PrivateLinkConnectionApprovalRequestInfo wrapper. The TypeSpec generator
// emits the same operations using RemotePrivateEndpointConnectionARMResourceData directly.
// These [EditorBrowsable(Never)] shims forward calls through PrivateLinkConnectionApprovalRequestInfoConverter
// to preserve the GA C# API without a breaking change. Changing the parameter type in spec
// would break the REST contract for other language SDKs.
namespace Azure.ResourceManager.AppService
{
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(CancellationToken))]
    public partial class HostingEnvironmentPrivateEndpointConnectionResource
    {
        /// <summary> Description for Deletes a private endpoint connection. </summary>
        public virtual async Task<ArmOperation<BinaryData>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _remotePrivateEndpointConnectionARMResourcesClientDiagnostics.CreateScope("HostingEnvironmentPrivateEndpointConnectionResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _remotePrivateEndpointConnectionARMResourcesRestClient.CreateDeletePrivateEndpointConnectionRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                AppServiceArmOperation<BinaryData> operation = new AppServiceArmOperation<BinaryData>(
                    new BinaryDataOperationSource(),
                    _remotePrivateEndpointConnectionARMResourcesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
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

        /// <summary> Description for Deletes a private endpoint connection. </summary>
        public virtual ArmOperation<BinaryData> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _remotePrivateEndpointConnectionARMResourcesClientDiagnostics.CreateScope("HostingEnvironmentPrivateEndpointConnectionResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _remotePrivateEndpointConnectionARMResourcesRestClient.CreateDeletePrivateEndpointConnectionRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                AppServiceArmOperation<BinaryData> operation = new AppServiceArmOperation<BinaryData>(
                    new BinaryDataOperationSource(),
                    _remotePrivateEndpointConnectionARMResourcesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
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

        /// <summary> Description for Approves or rejects a private endpoint connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<HostingEnvironmentPrivateEndpointConnectionResource>> UpdateAsync(WaitUntil waitUntil, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => UpdateAsync(waitUntil, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);

        /// <summary> Description for Approves or rejects a private endpoint connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<HostingEnvironmentPrivateEndpointConnectionResource> Update(WaitUntil waitUntil, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => Update(waitUntil, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);
    }
}
