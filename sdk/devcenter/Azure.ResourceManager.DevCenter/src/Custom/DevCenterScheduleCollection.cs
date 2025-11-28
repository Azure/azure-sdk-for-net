// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.DevCenter
{
    // Because the parameter 'int? top' is missing, the related methods are added back in this way.
    public partial class DevCenterScheduleCollection
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
        /// <exception cref="ArgumentException"> <paramref name="scheduleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="scheduleName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DevCenterScheduleResource>> GetAsync(string scheduleName, int? top, CancellationToken cancellationToken = default)
        {
            return await GetAsync(scheduleName, cancellationToken).ConfigureAwait(false);
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
        /// <exception cref="ArgumentException"> <paramref name="scheduleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="scheduleName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DevCenterScheduleResource> Get(string scheduleName, int? top, CancellationToken cancellationToken = default)
        {
            return Get(scheduleName, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <exception cref="ArgumentException"> <paramref name="scheduleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="scheduleName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string scheduleName, int? top, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(scheduleName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <exception cref="ArgumentException"> <paramref name="scheduleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="scheduleName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string scheduleName, int? top, CancellationToken cancellationToken = default)
        {
            return Exists(scheduleName, cancellationToken);
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
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
        /// <exception cref="ArgumentException"> <paramref name="scheduleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="scheduleName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<DevCenterScheduleResource>> GetIfExistsAsync(string scheduleName, int? top, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(scheduleName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
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
        /// <exception cref="ArgumentException"> <paramref name="scheduleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="scheduleName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DevCenterScheduleResource> GetIfExists(string scheduleName, int? top, CancellationToken cancellationToken = default)
        {
            return GetIfExists(scheduleName, cancellationToken);
        }
    }
}
