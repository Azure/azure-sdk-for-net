// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.DevCenter
{
    // Backward compatibility overloads for Schedule collection methods.
    // The baseline SDK included a "top" (int?) query parameter on the Schedule GET operation.
    // These overloads accept but ignore the "top" parameter to preserve backward API compatibility.
    public partial class DevCenterScheduleCollection
    {
        /// <summary> Gets a schedule resource. </summary>
        /// <param name="scheduleName"> The name of the schedule. </param>
        /// <param name="top"> The maximum number of resources to return. This parameter is accepted for backward compatibility but is not used. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DevCenterScheduleResource>> GetAsync(string scheduleName, int? top, CancellationToken cancellationToken = default)
        {
            return await GetAsync(scheduleName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a schedule resource. </summary>
        /// <param name="scheduleName"> The name of the schedule. </param>
        /// <param name="top"> The maximum number of resources to return. This parameter is accepted for backward compatibility but is not used. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DevCenterScheduleResource> Get(string scheduleName, int? top, CancellationToken cancellationToken = default)
        {
            return Get(scheduleName, cancellationToken);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="scheduleName"> The name of the schedule. </param>
        /// <param name="top"> The maximum number of resources to return. This parameter is accepted for backward compatibility but is not used. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string scheduleName, int? top, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(scheduleName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="scheduleName"> The name of the schedule. </param>
        /// <param name="top"> The maximum number of resources to return. This parameter is accepted for backward compatibility but is not used. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string scheduleName, int? top, CancellationToken cancellationToken = default)
        {
            return Exists(scheduleName, cancellationToken);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="scheduleName"> The name of the schedule. </param>
        /// <param name="top"> The maximum number of resources to return. This parameter is accepted for backward compatibility but is not used. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<DevCenterScheduleResource>> GetIfExistsAsync(string scheduleName, int? top, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(scheduleName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="scheduleName"> The name of the schedule. </param>
        /// <param name="top"> The maximum number of resources to return. This parameter is accepted for backward compatibility but is not used. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DevCenterScheduleResource> GetIfExists(string scheduleName, int? top, CancellationToken cancellationToken = default)
        {
            return GetIfExists(scheduleName, cancellationToken);
        }
    }
}
