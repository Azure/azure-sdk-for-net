// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.AppService.Models;

// ROOT CAUSE: GA 1.5.0 shipped Update overloads on private endpoint connection resource types
// accepting the legacy PrivateLinkConnectionApprovalRequestInfo wrapper. The TypeSpec generator
// emits the same operations using RemotePrivateEndpointConnectionARMResourceData directly.
// These [EditorBrowsable(Never)] shims forward calls through PrivateLinkConnectionApprovalRequestInfoConverter
// to preserve the GA C# API without a breaking change. Changing the parameter type in spec
// would break the REST contract for other language SDKs.
namespace Azure.ResourceManager.AppService
{
    public partial class SitePrivateEndpointConnectionResource
    {
        /// <summary> Description for Approves or rejects a private endpoint connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<SitePrivateEndpointConnectionResource>> UpdateAsync(WaitUntil waitUntil, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => UpdateAsync(waitUntil, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);

        /// <summary> Description for Approves or rejects a private endpoint connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SitePrivateEndpointConnectionResource> Update(WaitUntil waitUntil, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => Update(waitUntil, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);
    }
}
