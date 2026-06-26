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
    public partial class WebSiteResource : ArmResource
    {
        public virtual AsyncPageable<SiteConfigData> GetAllConfigurationDataAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");
        public virtual Pageable<SiteConfigData> GetAllConfigurationData(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");

        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetHybridConnectionsAsync` instead", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<HybridConnectionData>> GetAllHybridConnectionDataAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("Obsolete method, use GetHybridConnectionsAsync instead.");

        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetHybridConnectionsAsync` instead", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HybridConnectionData> GetAllHybridConnectionData(CancellationToken cancellationToken = default) => throw new NotSupportedException("Obsolete method, use GetHybridConnectionsAsync instead.");

        public virtual Task<Response<RelayServiceConnectionEntityData>> GetAllRelayServiceConnectionDataAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");
        public virtual Response<RelayServiceConnectionEntityData> GetAllRelayServiceConnectionData(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");
        public virtual AsyncPageable<WebAppBackupData> GetAllSiteBackupDataAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");
        public virtual Pageable<WebAppBackupData> GetAllSiteBackupData(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");
        public virtual Task<Response<PremierAddOnData>> GetAllPremierAddOnDataAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");
        public virtual Response<PremierAddOnData> GetAllPremierAddOnData(CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility member is not supported by the TypeSpec-generated client.");

        public virtual WebSiteSlotTriggeredWebJobCollection GetWebSiteSlotTriggeredWebJobs() => GetCachedClient(Client => new WebSiteSlotTriggeredWebJobCollection(Client, Id));

        [ForwardsClientCalls]
        public virtual async Task<Response<WebSiteSlotTriggeredWebJobResource>> GetWebSiteSlotTriggeredWebJobAsync(string webJobName, CancellationToken cancellationToken = default)
            => await GetWebSiteSlotTriggeredWebJobs().GetAsync(webJobName, cancellationToken).ConfigureAwait(false);

        [ForwardsClientCalls]
        public virtual Response<WebSiteSlotTriggeredWebJobResource> GetWebSiteSlotTriggeredWebJob(string webJobName, CancellationToken cancellationToken = default)
            => GetWebSiteSlotTriggeredWebJobs().Get(webJobName, cancellationToken);
    }
}
