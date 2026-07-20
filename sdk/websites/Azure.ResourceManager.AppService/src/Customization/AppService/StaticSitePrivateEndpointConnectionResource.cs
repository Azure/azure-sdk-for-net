// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
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
    public partial class StaticSitePrivateEndpointConnectionResource
    {
        /// <summary> Description for Deletes a private endpoint connection for a Static Site. </summary>
        public virtual Task<ArmOperation<BinaryData>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => AppServiceBinaryDataDeleteOperation.DeleteWithLocationAsync(
                _staticSitesClientDiagnostics,
                Pipeline,
                context => _staticSitesRestClient.CreateDeletePrivateEndpointConnectionRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context),
                "StaticSitePrivateEndpointConnectionResource.Delete",
                waitUntil,
                cancellationToken);

        /// <summary> Description for Deletes a private endpoint connection for a Static Site. </summary>
        public virtual ArmOperation<BinaryData> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => AppServiceBinaryDataDeleteOperation.DeleteWithLocation(
                _staticSitesClientDiagnostics,
                Pipeline,
                context => _staticSitesRestClient.CreateDeletePrivateEndpointConnectionRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context),
                "StaticSitePrivateEndpointConnectionResource.Delete",
                waitUntil,
                cancellationToken);

        /// <summary> Description for Approves or rejects a private endpoint connection for a Static Site. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<StaticSitePrivateEndpointConnectionResource>> UpdateAsync(WaitUntil waitUntil, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => UpdateAsync(waitUntil, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);

        /// <summary> Description for Approves or rejects a private endpoint connection for a Static Site. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StaticSitePrivateEndpointConnectionResource> Update(WaitUntil waitUntil, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => Update(waitUntil, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);
    }
}
