// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#pragma warning disable SA1402, SA1649

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.AppService.Models;

// ROOT CAUSE: GA 1.5.0 exposed CreateOrUpdate / Update overloads on the four
// PrivateEndpointConnection collections+resources (Hosting, Site, SiteSlot,
// StaticSite) that took `PrivateLinkConnectionApprovalRequestInfo`. The new
// TypeSpec emitter renames the body type to
// `RemotePrivateEndpointConnectionARMResourceData`. The GA model survives as
// a customization (see PrivateLinkConnectionApprovalRequestInfo.cs); these
// shims preserve the GA call-site shape by converting between the two models.
namespace Azure.ResourceManager.AppService
{
    internal static class PrivateLinkConnectionApprovalRequestInfoConverter
    {
        public static RemotePrivateEndpointConnectionARMResourceData ToResourceData(PrivateLinkConnectionApprovalRequestInfo info)
        {
            if (info == null)
            {
                return null;
            }
            return new RemotePrivateEndpointConnectionARMResourceData
            {
                Kind = info.Kind,
                PrivateLinkServiceConnectionState = info.PrivateLinkServiceConnectionState,
            };
        }
    }

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

    public partial class HostingEnvironmentPrivateEndpointConnectionResource
    {
        /// <summary> Description for Approves or rejects a private endpoint connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<HostingEnvironmentPrivateEndpointConnectionResource>> UpdateAsync(WaitUntil waitUntil, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => UpdateAsync(waitUntil, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);

        /// <summary> Description for Approves or rejects a private endpoint connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<HostingEnvironmentPrivateEndpointConnectionResource> Update(WaitUntil waitUntil, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => Update(waitUntil, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);
    }

    public partial class SitePrivateEndpointConnectionCollection
    {
        /// <summary> Description for Approves or rejects a private endpoint connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<SitePrivateEndpointConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);

        /// <summary> Description for Approves or rejects a private endpoint connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SitePrivateEndpointConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);
    }

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

    public partial class SiteSlotPrivateEndpointConnectionCollection
    {
        /// <summary> Description for Approves or rejects a private endpoint connection (slot). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<SiteSlotPrivateEndpointConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);

        /// <summary> Description for Approves or rejects a private endpoint connection (slot). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SiteSlotPrivateEndpointConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);
    }

    public partial class SiteSlotPrivateEndpointConnectionResource
    {
        /// <summary> Description for Approves or rejects a private endpoint connection (slot). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<SiteSlotPrivateEndpointConnectionResource>> UpdateAsync(WaitUntil waitUntil, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => UpdateAsync(waitUntil, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);

        /// <summary> Description for Approves or rejects a private endpoint connection (slot). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SiteSlotPrivateEndpointConnectionResource> Update(WaitUntil waitUntil, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => Update(waitUntil, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);
    }

    public partial class StaticSitePrivateEndpointConnectionCollection
    {
        /// <summary> Description for Approves or rejects a private endpoint connection for a Static Site. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<StaticSitePrivateEndpointConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);

        /// <summary> Description for Approves or rejects a private endpoint connection for a Static Site. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StaticSitePrivateEndpointConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfo privateEndpointWrapper, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestInfoConverter.ToResourceData(privateEndpointWrapper), cancellationToken);
    }

    public partial class StaticSitePrivateEndpointConnectionResource
    {
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
