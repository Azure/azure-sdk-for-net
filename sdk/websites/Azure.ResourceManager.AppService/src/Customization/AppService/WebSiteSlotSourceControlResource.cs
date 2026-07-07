// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

// ROOT CAUSE: GA 1.5.0 exposed a single Update(SiteSourceControlData) method on
// WebSiteSlotSourceControlResource. The TypeSpec emitter renamed this to UpdateSourceControlSlot.
// This [EditorBrowsable(Never)] shim forwards the GA-named Update to the new method to
// preserve the C# API surface. Renaming the method in the spec would change the REST
// operation id used by other SDKs (Python/JS/Java).
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
