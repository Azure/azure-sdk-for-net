// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;

namespace Azure.ResourceManager.GuestConfiguration.Mocking
{
    public partial class MockableGuestConfigurationResourceGroupResource
    {
        /// <summary> List all guest configuration assignments for a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentData(CancellationToken cancellationToken = default)
        {
            return new PageableWrapper<GuestConfigurationVmAssignmentResource, GuestConfigurationAssignmentData>(
                RGList(cancellationToken),
                resource => resource.Data);
        }

        /// <summary> List all guest configuration assignments for a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<GuestConfigurationVmAssignmentResource, GuestConfigurationAssignmentData>(
                RGListAsync(cancellationToken),
                resource => resource.Data);
        }

        // backward compatible for generator bug fixes
        /// <summary>
        /// List all guest configuration assignments for a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GuestConfigurationAssignmentsOperationGroup_RGList. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-04-05. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GuestConfigurationVmAssignmentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GuestConfigurationVmAssignmentResource> RGListAsync(CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<GuestConfigurationAssignmentData, GuestConfigurationVmAssignmentResource>(GetGuestConfigurationAssignmentsAsync(cancellationToken), data => new GuestConfigurationVmAssignmentResource(Client, data));
        }

        /// <summary>
        /// List all guest configuration assignments for a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GuestConfigurationAssignmentsOperationGroup_RGList. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-04-05. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GuestConfigurationVmAssignmentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GuestConfigurationVmAssignmentResource> RGList(CancellationToken cancellationToken = default)
        {
            return new PageableWrapper<GuestConfigurationAssignmentData, GuestConfigurationVmAssignmentResource>(GetGuestConfigurationAssignments(cancellationToken), data => new GuestConfigurationVmAssignmentResource(Client, data));
        }
    }
}
