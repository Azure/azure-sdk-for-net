// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.AppService
{
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
}
