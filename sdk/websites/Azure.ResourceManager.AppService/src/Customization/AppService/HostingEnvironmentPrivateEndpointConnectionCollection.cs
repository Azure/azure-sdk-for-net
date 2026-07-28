// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.AppService.Models;

// ROOT CAUSE: GA 1.5.0 shipped CreateOrUpdate overloads on private endpoint connection
// collection types accepting the legacy PrivateLinkConnectionApprovalRequestInfo wrapper.
// The TypeSpec generator emits the same operations using RemotePrivateEndpointConnectionARMResourceData
// directly. These [EditorBrowsable(Never)] shims forward calls through
// PrivateLinkConnectionApprovalRequestInfoConverter to preserve the GA C# API without breaking change.
// Changing the parameter type in spec would break the REST contract for other language SDKs.
namespace Azure.ResourceManager.AppService
{
    public partial class HostingEnvironmentPrivateEndpointConnectionCollection
    {
        /// <summary> Description for Approves or rejects a private endpoint connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<HostingEnvironmentPrivateEndpointConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);

        /// <summary> Description for Approves or rejects a private endpoint connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<HostingEnvironmentPrivateEndpointConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);
    }
}
