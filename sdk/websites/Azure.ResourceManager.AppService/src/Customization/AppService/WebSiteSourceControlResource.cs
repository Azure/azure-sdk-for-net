// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

// ROOT CAUSE: GA 1.5.0 exposed a single Update(SiteSourceControlData) method on
// WebSiteSourceControlResource. The TypeSpec emitter renamed this to UpdateSourceControl.
// This [EditorBrowsable(Never)] shim forwards the GA-named Update to the new method to
// preserve the C# API surface. Renaming the method in the spec would change the REST
// operation id used by other SDKs (Python/JS/Java).
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
