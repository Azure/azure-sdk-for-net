// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

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
