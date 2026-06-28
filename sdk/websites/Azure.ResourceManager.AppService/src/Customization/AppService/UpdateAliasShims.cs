// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#pragma warning disable SA1402, SA1649

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

// ROOT CAUSE: GA 1.5.0 exposed a single `Update(<Data>)` method on each of these
// config/source-control/network singleton resources. The new TypeSpec emitter
// gives the method a more specific name (UpdateConfiguration, UpdateSourceControl,
// UpdateSwiftVirtualNetworkConnectionWithCheck, etc.). Add GA-named `Update`
// aliases that forward to the new method.
namespace Azure.ResourceManager.AppService
{
    public partial class WebSiteConfigResource
    {
        /// <summary> Description for Updates the configuration of an app. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<WebSiteConfigResource>> UpdateAsync(SiteConfigData data, CancellationToken cancellationToken = default)
            => UpdateConfigurationAsync(data, cancellationToken);

        /// <summary> Description for Updates the configuration of an app. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<WebSiteConfigResource> Update(SiteConfigData data, CancellationToken cancellationToken = default)
            => UpdateConfiguration(data, cancellationToken);
    }

    public partial class WebSiteSlotConfigResource
    {
        /// <summary> Description for Updates the configuration of an app (slot). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<WebSiteSlotConfigResource>> UpdateAsync(SiteConfigData data, CancellationToken cancellationToken = default)
            => UpdateConfigurationSlotAsync(data, cancellationToken);

        /// <summary> Description for Updates the configuration of an app (slot). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<WebSiteSlotConfigResource> Update(SiteConfigData data, CancellationToken cancellationToken = default)
            => UpdateConfigurationSlot(data, cancellationToken);
    }

    public partial class SiteNetworkConfigResource
    {
        /// <summary> Description for Integrates this Web App with a Virtual Network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<SiteNetworkConfigResource>> UpdateAsync(SwiftVirtualNetworkData data, CancellationToken cancellationToken = default)
            => UpdateSwiftVirtualNetworkConnectionWithCheckAsync(data, cancellationToken);

        /// <summary> Description for Integrates this Web App with a Virtual Network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SiteNetworkConfigResource> Update(SwiftVirtualNetworkData data, CancellationToken cancellationToken = default)
            => UpdateSwiftVirtualNetworkConnectionWithCheck(data, cancellationToken);
    }

    public partial class SiteSlotNetworkConfigResource
    {
        /// <summary> Description for Integrates this Web App with a Virtual Network (slot). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<SiteSlotNetworkConfigResource>> UpdateAsync(SwiftVirtualNetworkData data, CancellationToken cancellationToken = default)
            => UpdateSwiftVirtualNetworkConnectionWithCheckSlotAsync(data, cancellationToken);

        /// <summary> Description for Integrates this Web App with a Virtual Network (slot). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SiteSlotNetworkConfigResource> Update(SwiftVirtualNetworkData data, CancellationToken cancellationToken = default)
            => UpdateSwiftVirtualNetworkConnectionWithCheckSlot(data, cancellationToken);
    }

    public partial class WebSiteSourceControlResource
    {
        /// <summary> Description for Updates the source control configuration of an app. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<WebSiteSourceControlResource>> UpdateAsync(SiteSourceControlData data, CancellationToken cancellationToken = default)
            => UpdateSourceControlAsync(data, cancellationToken);

        /// <summary> Description for Updates the source control configuration of an app. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<WebSiteSourceControlResource> Update(SiteSourceControlData data, CancellationToken cancellationToken = default)
            => UpdateSourceControl(data, cancellationToken);
    }

    public partial class WebSiteSlotSourceControlResource
    {
        /// <summary> Description for Updates the source control configuration of an app (slot). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<WebSiteSlotSourceControlResource>> UpdateAsync(SiteSourceControlData data, CancellationToken cancellationToken = default)
            => UpdateSourceControlSlotAsync(data, cancellationToken);

        /// <summary> Description for Updates the source control configuration of an app (slot). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<WebSiteSlotSourceControlResource> Update(SiteSourceControlData data, CancellationToken cancellationToken = default)
            => UpdateSourceControlSlot(data, cancellationToken);
    }

    public partial class HostingEnvironmentMultiRolePoolResource
    {
        /// <summary> Description for Update a multi-role pool of an App Service Environment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<HostingEnvironmentMultiRolePoolResource>> UpdateAsync(AppServiceWorkerPoolData data, CancellationToken cancellationToken = default)
            => UpdateMultiRolePoolAsync(data, cancellationToken);

        /// <summary> Description for Update a multi-role pool of an App Service Environment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HostingEnvironmentMultiRolePoolResource> Update(AppServiceWorkerPoolData data, CancellationToken cancellationToken = default)
            => UpdateMultiRolePool(data, cancellationToken);
    }
}
