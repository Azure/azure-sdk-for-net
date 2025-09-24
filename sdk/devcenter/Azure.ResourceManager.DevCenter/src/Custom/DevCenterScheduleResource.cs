// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.DevCenter
{
    // Because the parameter 'int? top' is missing, the related methods are added back in this way.
    public partial class DevCenterScheduleResource
    {
        /// <summary>
        /// Gets a schedule resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/pools/{poolName}/schedules/{scheduleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Schedules_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DevCenterScheduleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: '$top=10'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DevCenterScheduleResource>> GetAsync(int? top, CancellationToken cancellationToken = default)
        {
            return await GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a schedule resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/pools/{poolName}/schedules/{scheduleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Schedules_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DevCenterScheduleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: '$top=10'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DevCenterScheduleResource> Get(int? top, CancellationToken cancellationToken = default)
        {
            return Get(cancellationToken);
        }
    }
}
