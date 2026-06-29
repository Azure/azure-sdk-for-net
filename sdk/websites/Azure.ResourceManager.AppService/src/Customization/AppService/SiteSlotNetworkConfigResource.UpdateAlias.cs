// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.AppService
{
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
}
