// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppService
{
    public partial class WebSiteSlotResource : ArmResource
    {
        public virtual AsyncPageable<SiteConfigData> GetAllConfigurationSlotDataAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");
        public virtual Pageable<SiteConfigData> GetAllConfigurationSlotData(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");

        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetHybridConnectionsAsync` instead", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<HybridConnectionData>> GetAllHybridConnectionSlotDataAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("Obsolete method, use GetHybridConnectionsAsync instead.");

        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetHybridConnectionsAsync` instead", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HybridConnectionData> GetAllHybridConnectionSlotData(CancellationToken cancellationToken = default) => throw new NotSupportedException("Obsolete method, use GetHybridConnectionsAsync instead.");

        public virtual Task<Response<RelayServiceConnectionEntityData>> GetAllRelayServiceConnectionSlotDataAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");
        public virtual Response<RelayServiceConnectionEntityData> GetAllRelayServiceConnectionSlotData(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");
        public virtual AsyncPageable<WebAppBackupData> GetAllSiteBackupSlotDataAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");
        public virtual Pageable<WebAppBackupData> GetAllSiteBackupSlotData(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");
        public virtual Task<Response<PremierAddOnData>> GetAllPremierAddOnSlotDataAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");
        public virtual Response<PremierAddOnData> GetAllPremierAddOnSlotData(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");

        public virtual WebSiteTriggeredwebJobCollection GetWebSiteTriggeredwebJobs() => GetCachedClient(Client => new WebSiteTriggeredwebJobCollection(Client, Id));

        [ForwardsClientCalls]
        public virtual async Task<Response<WebSiteTriggeredwebJobResource>> GetWebSiteTriggeredwebJobAsync(string webJobName, CancellationToken cancellationToken = default)
            => await GetWebSiteTriggeredwebJobs().GetAsync(webJobName, cancellationToken).ConfigureAwait(false);

        [ForwardsClientCalls]
        public virtual Response<WebSiteTriggeredwebJobResource> GetWebSiteTriggeredwebJob(string webJobName, CancellationToken cancellationToken = default)
            => GetWebSiteTriggeredwebJobs().Get(webJobName, cancellationToken);
    }
}
