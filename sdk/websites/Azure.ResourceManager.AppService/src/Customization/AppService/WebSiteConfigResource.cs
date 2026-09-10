// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
}
