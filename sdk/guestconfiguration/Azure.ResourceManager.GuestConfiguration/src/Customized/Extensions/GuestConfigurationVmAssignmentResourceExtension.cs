// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.GuestConfiguration.Mock
{
    [CodeGenSuppress("GetGuestConfigurationAssignmentsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetGuestConfigurationAssignments", typeof(CancellationToken))]
    public partial class GuestConfigurationVmAssignmentResourceExtension : ArmResource
    {
        /// <summary>
        /// List all guest configuration assignments for a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments
        /// Operation Id: GuestConfigurationAssignments_RGList
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="GuestConfigurationAssignmentData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(CancellationToken cancellationToken = default)
        {
            if (Id.ResourceType == SubscriptionResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => GuestConfigurationVmAssignmentGuestConfigurationAssignmentsRestClient.CreateSubscriptionListRequest(Id.SubscriptionId);
                return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, GuestConfigurationAssignmentData.DeserializeGuestConfigurationAssignmentData, GuestConfigurationVmAssignmentGuestConfigurationAssignmentsClientDiagnostics, Pipeline, "GuestConfigurationVmAssignmentResourceExtension.GetGuestConfigurationAssignments", "value", null, cancellationToken);
            }
            else if (Id.ResourceType == ResourceGroupResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => GuestConfigurationVmAssignmentGuestConfigurationAssignmentsRestClient.CreateRGListRequest(Id.SubscriptionId, Id.ResourceGroupName);
                return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, GuestConfigurationAssignmentData.DeserializeGuestConfigurationAssignmentData, GuestConfigurationVmAssignmentGuestConfigurationAssignmentsClientDiagnostics, Pipeline, "GuestConfigurationVmAssignmentResourceExtension.GetGuestConfigurationAssignments", "value", null, cancellationToken);
            }
            else
            {
                throw new InvalidOperationException($"{Id.ResourceType} is not supported here");
            }
        }

        /// <summary>
        /// List all guest configuration assignments for a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments
        /// Operation Id: GuestConfigurationAssignments_RGList
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GuestConfigurationAssignmentData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentData(CancellationToken cancellationToken = default)
        {
            if (Id.ResourceType == SubscriptionResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => GuestConfigurationVmAssignmentGuestConfigurationAssignmentsRestClient.CreateSubscriptionListRequest(Id.SubscriptionId);
                return PageableHelpers.CreatePageable(FirstPageRequest, null, GuestConfigurationAssignmentData.DeserializeGuestConfigurationAssignmentData, GuestConfigurationVmAssignmentGuestConfigurationAssignmentsClientDiagnostics, Pipeline, "GuestConfigurationVmAssignmentResourceExtension.GetGuestConfigurationAssignments", "value", null, cancellationToken);
            }
            else if (Id.ResourceType == ResourceGroupResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => GuestConfigurationVmAssignmentGuestConfigurationAssignmentsRestClient.CreateRGListRequest(Id.SubscriptionId, Id.ResourceGroupName);
                return PageableHelpers.CreatePageable(FirstPageRequest, null, GuestConfigurationAssignmentData.DeserializeGuestConfigurationAssignmentData, GuestConfigurationVmAssignmentGuestConfigurationAssignmentsClientDiagnostics, Pipeline, "GuestConfigurationVmAssignmentResourceExtension.GetGuestConfigurationAssignments", "value", null, cancellationToken);
            }
            else
            {
                throw new InvalidOperationException($"{Id.ResourceType} is not supported here");
            }
        }
    }
}
