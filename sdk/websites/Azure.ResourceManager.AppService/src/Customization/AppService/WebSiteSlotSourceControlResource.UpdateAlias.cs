// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.AppService
{
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
}
