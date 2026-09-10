// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

// ROOT CAUSE: GA 1.5.0 exposed a single Update(AppServiceWorkerPoolData) method on
// HostingEnvironmentMultiRolePoolResource. The TypeSpec emitter renamed this to
// UpdateMultiRolePool. This [EditorBrowsable(Never)] shim forwards the GA-named Update
// to the new method to preserve the C# API surface. Renaming the method in the spec
// would change the REST operation id used by other SDKs (Python/JS/Java).
namespace Azure.ResourceManager.AppService
{
    public partial class HostingEnvironmentMultiRolePoolResource
    {
        /// <summary> Description for Update a multi-role pool of an App Service Environment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<HostingEnvironmentMultiRolePoolResource>> UpdateAsync(AppServiceWorkerPoolData data, CancellationToken cancellationToken = default)
            => UpdateMultiRolePoolAsync(data, cancellationToken);

        /// <summary> Description for Update a multi-role pool of an App Service Environment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HostingEnvironmentMultiRolePoolResource> Update(AppServiceWorkerPoolData data, CancellationToken cancellationToken = default)
            => UpdateMultiRolePool(data, cancellationToken);
    }
}
