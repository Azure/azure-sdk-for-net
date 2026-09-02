// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

// ROOT CAUSE: GA 1.5.0 exposed a single Update(SwiftVirtualNetworkData) method on
// SiteNetworkConfigResource. The TypeSpec emitter renamed this to
// UpdateSwiftVirtualNetworkConnectionWithCheck. This [EditorBrowsable(Never)] shim
// forwards the GA-named Update to the new method to preserve the C# API surface.
// Renaming the method in the spec would change the REST operation id used by other SDKs.
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
