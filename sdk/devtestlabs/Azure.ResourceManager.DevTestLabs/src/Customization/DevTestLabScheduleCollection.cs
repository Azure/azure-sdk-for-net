// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DevTestLabs
{
    public partial class DevTestLabScheduleCollection : ArmCollection, IEnumerable<DevTestLabScheduleResource>, IAsyncEnumerable<DevTestLabScheduleResource>
    {
        /// <summary>
        /// Lists all applicable schedules
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/schedules/{name}/listApplicable. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Schedules_ListApplicable. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DevTestLabScheduleResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the Schedule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabScheduleResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DevTestLabScheduleResource> GetApplicableAsync(string name, CancellationToken cancellationToken = default)
            => GetAsync(name, default, cancellationToken).Result.Value.GetApplicableAsync(cancellationToken);

        /// <summary>
        /// Lists all applicable schedules
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/schedules/{name}/listApplicable. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Schedules_ListApplicable. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DevTestLabScheduleResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the Schedule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabScheduleResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DevTestLabScheduleResource> GetApplicable(string name, CancellationToken cancellationToken = default)
            => Get(name, default, cancellationToken).Value.GetApplicable(cancellationToken);
    }
}
