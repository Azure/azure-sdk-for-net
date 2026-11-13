// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.DevCenter
{
    // Backward compatibility overloads for getting a Schedule from a Pool resource.
    // The baseline SDK included a "top" (int?) query parameter on the Schedule GET operation.
    // These overloads accept but ignore the "top" parameter to preserve backward API compatibility.
    public partial class DevCenterPoolResource
    {
        /// <summary> Gets a schedule resource. </summary>
        /// <param name="scheduleName"> The name of the schedule. </param>
        /// <param name="top"> The maximum number of resources to return. This parameter is accepted for backward compatibility but is not used. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<DevCenterScheduleResource>> GetDevCenterScheduleAsync(string scheduleName, int? top, CancellationToken cancellationToken = default)
        {
            return await GetDevCenterScheduleAsync(scheduleName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a schedule resource. </summary>
        /// <param name="scheduleName"> The name of the schedule. </param>
        /// <param name="top"> The maximum number of resources to return. This parameter is accepted for backward compatibility but is not used. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<DevCenterScheduleResource> GetDevCenterSchedule(string scheduleName, int? top, CancellationToken cancellationToken = default)
        {
            return GetDevCenterSchedule(scheduleName, cancellationToken);
        }
    }
}
