// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

// ROOT CAUSE: GA 1.5.0 exposed a single Update(SiteConfigData) method on
// WebSiteSlotConfigResource. The TypeSpec emitter renamed this to UpdateConfigurationSlot.
// This [EditorBrowsable(Never)] shim forwards the GA-named Update to the new method to
// preserve the C# API surface. Renaming the method in the spec would change the REST
// operation id used by other SDKs (Python/JS/Java).
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
