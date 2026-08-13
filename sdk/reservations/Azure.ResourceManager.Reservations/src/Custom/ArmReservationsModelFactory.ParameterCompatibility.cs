// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Reservations;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Reservations.Models
{
    [CodeGenSuppress("ReservationProperties", typeof(ReservedResourceType?), typeof(InstanceFlexibility?), typeof(string), typeof(IEnumerable<string>), typeof(AppliedScopeType?), typeof(bool?), typeof(string), typeof(int?), typeof(ReservationProvisioningState?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(ExtendedStatusInfo), typeof(ReservationBillingPlan?), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(ReservationSplitProperties), typeof(ReservationMergeProperties), typeof(ReservationSwapProperties), typeof(AppliedScopeProperties), typeof(ResourceIdentifier), typeof(bool?), typeof(string), typeof(string), typeof(RenewProperties), typeof(ReservationTerm?), typeof(string), typeof(string), typeof(ReservationPropertiesUtilization))]
    public static partial class ArmReservationsModelFactory
    {
        // TODO: Remove these compatibility factory methods after https://github.com/Azure/azure-sdk-for-net/issues/61815 is fixed.

        /// <param name="reservedResourceType"> The type of the resource that is being reserved. </param>
        /// <param name="instanceFlexibility"> Allows reservation discount to be applied across skus within the same auto fit group. Not all skus support instance size flexibility. </param>
        /// <param name="displayName"> Friendly name for user to easily identify the reservation. </param>
        /// <param name="appliedScopes"> The list of applied scopes. </param>
        /// <param name="appliedScopeType"> The applied scope type. </param>
        /// <param name="isArchived"> Indicates if the reservation is archived. </param>
        /// <param name="capabilities"> Capabilities of the reservation. </param>
        /// <param name="quantity"> Quantity of the skus that are part of the reservation. Must be greater than zero. </param>
        /// <param name="provisioningState"> Current state of the reservation. </param>
        /// <param name="effectOn"> DateTime of the reservation starting when this version is effective from. </param>
        /// <param name="benefitStartOn"> This is the DateTime when the reservation benefit started. </param>
        /// <param name="lastUpdatedOn"> DateTime of the last time the reservation was updated. </param>
        /// <param name="reservationExpireOn"> This is the date when the reservation will expire. </param>
        /// <param name="expireOn"> This is the date-time when the reservation will expire. </param>
        /// <param name="reviewOn"> This is the date-time when the Azure Hybrid Benefit needs to be reviewed. </param>
        /// <param name="skuDescription"> Description of the sku in english. </param>
        /// <param name="extendedStatusInfo"> The message giving detailed information about the status code. </param>
        /// <param name="billingPlan"> The billing plan options available for this sku. </param>
        /// <param name="displayProvisioningState"> The provisioning state of the reservation for display, e.g. Succeeded. </param>
        /// <param name="provisioningSubState"> The provisioning sub-state of the reservation, e.g. Succeeded. </param>
        /// <param name="reservationPurchaseOn"> This is the date when the reservation was purchased. </param>
        /// <param name="purchaseOn"> This is the date-time when the reservation was purchased. </param>
        /// <param name="splitProperties"> Properties of reservation split. </param>
        /// <param name="mergeProperties"> Properties of reservation merge. </param>
        /// <param name="swapProperties"> Properties of reservation swap. </param>
        /// <param name="appliedScopeProperties"> Properties specific to applied scope type. Not required if not applicable. Required and need to provide tenantId and managementGroupId if AppliedScopeType is ManagementGroup. </param>
        /// <param name="billingScopeId"> Subscription that will be charged for purchasing reservation or savings plan. </param>
        /// <param name="isRenewEnabled"> Setting this to true will automatically purchase a new reservation on the expiration date time. </param>
        /// <param name="renewSource"> Reservation Id of the reservation from which this reservation is renewed. Format of the resource Id is /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}. </param>
        /// <param name="renewDestination"> Reservation Id of the reservation which is purchased because of renew. Format of the resource Id is /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}. </param>
        /// <param name="renewProperties"> The renew properties for a reservation. </param>
        /// <param name="term"> Represent the term of reservation. </param>
        /// <param name="userFriendlyAppliedScopeType"> The applied scope type of the reservation for display, e.g. Shared. </param>
        /// <param name="userFriendlyRenewState"> The renew state of the reservation for display, e.g. On. </param>
        /// <param name="utilization"> Reservation utilization. </param>
        /// <returns> A new <see cref="Models.ReservationProperties"/> instance for mocking. </returns>
        public static ReservationProperties ReservationProperties(ReservedResourceType? reservedResourceType = default, InstanceFlexibility? instanceFlexibility = default, string displayName = default, IEnumerable<string> appliedScopes = default, AppliedScopeType? appliedScopeType = default, bool? isArchived = default, string capabilities = default, int? quantity = default, ReservationProvisioningState? provisioningState = default, DateTimeOffset? effectOn = default, DateTimeOffset? benefitStartOn = default, DateTimeOffset? lastUpdatedOn = default, DateTimeOffset? expireOn = default, DateTimeOffset? reservationExpireOn = default, DateTimeOffset? reviewOn = default, string skuDescription = default, ExtendedStatusInfo extendedStatusInfo = default, ReservationBillingPlan? billingPlan = default, string displayProvisioningState = default, string provisioningSubState = default, DateTimeOffset? purchaseOn = default, DateTimeOffset? reservationPurchaseOn = default, ReservationSplitProperties splitProperties = default, ReservationMergeProperties mergeProperties = default, ReservationSwapProperties swapProperties = default, AppliedScopeProperties appliedScopeProperties = default, ResourceIdentifier billingScopeId = default, bool? isRenewEnabled = default, string renewSource = default, string renewDestination = default, RenewProperties renewProperties = default, ReservationTerm? term = default, string userFriendlyAppliedScopeType = default, string userFriendlyRenewState = default, ReservationPropertiesUtilization utilization = default)
        {
            appliedScopes ??= new ChangeTrackingList<string>();

            return new ReservationProperties(
                reservedResourceType,
                instanceFlexibility,
                displayName,
                (appliedScopes ?? new ChangeTrackingList<string>()).ToList(),
                appliedScopeType,
                isArchived,
                capabilities,
                quantity,
                provisioningState,
                effectOn,
                benefitStartOn,
                lastUpdatedOn,
                reservationExpireOn,
                expireOn,
                reviewOn,
                skuDescription,
                extendedStatusInfo,
                billingPlan,
                displayProvisioningState,
                provisioningSubState,
                reservationPurchaseOn,
                purchaseOn,
                splitProperties,
                mergeProperties,
                swapProperties,
                appliedScopeProperties,
                billingScopeId,
                isRenewEnabled,
                renewSource,
                renewDestination,
                renewProperties,
                term,
                userFriendlyAppliedScopeType,
                userFriendlyRenewState,
                utilization,
                default);
        }
    }
}
