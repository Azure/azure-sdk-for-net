// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.AppService
{
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
}
