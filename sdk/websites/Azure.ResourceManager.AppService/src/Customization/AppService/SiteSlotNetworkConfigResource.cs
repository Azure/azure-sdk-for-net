// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

// ROOT CAUSE: GA 1.5.0 exposed a single Update(SwiftVirtualNetworkData) method on
// SiteSlotNetworkConfigResource. The TypeSpec emitter renamed this to
// UpdateSwiftVirtualNetworkConnectionWithCheckSlot. This [EditorBrowsable(Never)] shim
// forwards the GA-named Update to the new method to preserve the C# API surface.
// Renaming the method in the spec would change the REST operation id used by other SDKs.
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
