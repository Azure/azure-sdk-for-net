// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.DevCenter
{
    public partial class DevCenterPoolResource
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
        /// <param name="scheduleName"> The name of the schedule that uniquely identifies it. </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: '$top=10'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scheduleName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="scheduleName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DevCenterScheduleResource>> GetDevCenterScheduleAsync(string scheduleName, int? top = null, CancellationToken cancellationToken = default)
        {
            return await GetDevCenterScheduleAsync(scheduleName, cancellationToken).ConfigureAwait(false);
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
        /// <param name="scheduleName"> The name of the schedule that uniquely identifies it. </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: '$top=10'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scheduleName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="scheduleName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DevCenterScheduleResource> GetDevCenterSchedule(string scheduleName, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetDevCenterSchedule(scheduleName, cancellationToken);
        }
    }
}
