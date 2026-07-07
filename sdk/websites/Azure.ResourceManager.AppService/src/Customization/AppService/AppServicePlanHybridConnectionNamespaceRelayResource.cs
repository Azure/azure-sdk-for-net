// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

// ROOT CAUSE: GA 1.5.0 exposed two listing calls on this resource:
//   * GetWebAppsByHybridConnection         → Pageable<string>     (REST: ListWebAppsByHybridConnection — site names)
//   * GetAllWebAppsByHybridConnection      → Pageable<WebSiteData>(GA fan-out over each name)
// The new generator only emits the REST call (renamed to GetWebAppsByHybridConnection
// via @@clientName in client.tsp). The data-listing variant required follow-up
// per-site Get calls which are no longer modelled and cannot be re-implemented
// safely here; throw NotSupportedException to preserve the GA signature.
namespace Azure.ResourceManager.AppService
{
    public partial class AppServicePlanHybridConnectionNamespaceRelayResource
    {
        /// <summary> Description for Get all apps that use a Hybrid Connection in an App Service Plan. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is no longer supported. Use GetWebAppsByHybridConnection() to retrieve site names, then load each WebSiteResource individually.", false)]
        public virtual AsyncPageable<WebSiteData> GetAllWebAppsByHybridConnectionAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use GetWebAppsByHybridConnectionAsync() to retrieve site names, then load each WebSiteResource via WebSiteCollection.GetAsync.");

        /// <summary> Description for Get all apps that use a Hybrid Connection in an App Service Plan. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is no longer supported. Use GetWebAppsByHybridConnection() to retrieve site names, then load each WebSiteResource individually.", false)]
        public virtual Pageable<WebSiteData> GetAllWebAppsByHybridConnection(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use GetWebAppsByHybridConnection() to retrieve site names, then load each WebSiteResource via WebSiteCollection.Get.");
    }
}
