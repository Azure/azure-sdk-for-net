// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.DevCenter
{
    // Backward compatibility overloads for Schedule resource Get methods.
    // The baseline SDK included a "top" (int?) query parameter on the Schedule GET operation.
    // These overloads accept but ignore the "top" parameter to preserve backward API compatibility.
    public partial class DevCenterScheduleResource
    {
        /// <summary> Gets a schedule resource. </summary>
        /// <param name="top"> The maximum number of resources to return. This parameter is accepted for backward compatibility but is not used. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DevCenterScheduleResource>> GetAsync(int? top, CancellationToken cancellationToken = default)
        {
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a schedule resource. </summary>
        /// <param name="top"> The maximum number of resources to return. This parameter is accepted for backward compatibility but is not used. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DevCenterScheduleResource> Get(int? top, CancellationToken cancellationToken = default)
        {
            return Get(cancellationToken);
        }
    }
}
