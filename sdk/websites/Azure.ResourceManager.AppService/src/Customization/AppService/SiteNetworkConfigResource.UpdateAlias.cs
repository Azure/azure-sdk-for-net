// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.AppService
{
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
}
