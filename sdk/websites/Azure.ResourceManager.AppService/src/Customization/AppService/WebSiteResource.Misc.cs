// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.AppService.Models;

// ROOT CAUSE: GA 1.5.0 exposed the following names which were renamed or
// re-shaped by the new TypeSpec emitter:
//   * WebSiteResource.SwapSlotWithProduction -> SwapSlot
//   * WebSiteResource.GetMigrateMySqlStatus  -> GetSiteMigrateMySqlStatus
//     (returning SiteMigrateMySqlStatusResource instead of legacy
//     MigrateMySqlStatusResource); both wrap the same MigrateMySqlStatusData
//     so we can convert between them via the internal data ctor.
//   * WebSiteResource.GetNetworkFeatures(view) was a singleton lookup that
//     returned Response<NetworkFeatureResource>; the new generator exposes
//     this via GetSiteNetworkFeatures().Get(view) returning
//     SiteNetworkFeatureResource (sharing NetworkFeatureData).
namespace Azure.ResourceManager.AppService
{
    public partial class WebSiteResource
    {
        /// <summary> Description for Swaps two deployment slots of an app. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation> SwapSlotWithProductionAsync(WaitUntil waitUntil, CsmSlotEntity slotSwapEntity, CancellationToken cancellationToken = default)
            => SwapSlotAsync(waitUntil, slotSwapEntity, cancellationToken);

        /// <summary> Description for Swaps two deployment slots of an app. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation SwapSlotWithProduction(WaitUntil waitUntil, CsmSlotEntity slotSwapEntity, CancellationToken cancellationToken = default)
            => SwapSlot(waitUntil, slotSwapEntity, cancellationToken);

        /// <summary> Description for Returns the status of the latest MySql migration for the specified web app. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<MigrateMySqlStatusResource>> GetMigrateMySqlStatusAsync(CancellationToken cancellationToken = default)
        {
            Response<SiteMigrateMySqlStatusResource> r = await GetSiteMigrateMySqlStatus().GetAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new MigrateMySqlStatusResource(Client, r.Value.Data), r.GetRawResponse());
        }

        /// <summary> Description for Returns the status of the latest MySql migration for the specified web app. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<MigrateMySqlStatusResource> GetMigrateMySqlStatus(CancellationToken cancellationToken = default)
        {
            Response<SiteMigrateMySqlStatusResource> r = GetSiteMigrateMySqlStatus().Get(cancellationToken);
            return Response.FromValue(new MigrateMySqlStatusResource(Client, r.Value.Data), r.GetRawResponse());
        }

        /// <summary> Description for Get all network features used by the app (or deployment slot, if specified). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetworkFeatureResource>> GetNetworkFeaturesAsync(string view, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(view, nameof(view));
            Response<SiteNetworkFeatureResource> r = await GetSiteNetworkFeatures().GetAsync(view, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new NetworkFeatureResource(Client, r.Value.Data), r.GetRawResponse());
        }

        /// <summary> Description for Get all network features used by the app (or deployment slot, if specified). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetworkFeatureResource> GetNetworkFeatures(string view, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(view, nameof(view));
            Response<SiteNetworkFeatureResource> r = GetSiteNetworkFeatures().Get(view, cancellationToken);
            return Response.FromValue(new NetworkFeatureResource(Client, r.Value.Data), r.GetRawResponse());
        }
    }
}
