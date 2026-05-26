// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Reservations.Models
{
    // Justification: GA exposed an options-bag overload for TenantResource.GetReservationDetails
    // (TenantResourceGetReservationDetailsOptions). The new TypeSpec generator emits long-form
    // parameters; this type and overloads preserve the GA options-bag surface.
    /// <summary> The TenantResourceGetReservationDetailsOptions. </summary>
    public partial class TenantResourceGetReservationDetailsOptions
    {
        /// <summary> Initializes a new instance of <see cref="TenantResourceGetReservationDetailsOptions"/>. </summary>
        public TenantResourceGetReservationDetailsOptions()
        {
        }

        /// <summary> May be used to filter by reservation properties. The filter supports 'eq', 'or', and 'and'. It does not currently support 'ne', 'gt', 'le', 'ge', or 'not'. Reservation properties include sku/name, properties/{appliedScopeType, archived, displayName, displayProvisioningState, effectiveDateTime, expiryDate, expiryDateTime, provisioningState, quantity, renew, reservedResourceType, term, userFriendlyAppliedScopeType, userFriendlyRenewState}. </summary>
        public string Filter { get; set; }
        /// <summary> May be used to sort order by reservation properties. </summary>
        public string Orderby { get; set; }
        /// <summary> To indicate whether to refresh the roll up counts of the reservations group by provisioning states. </summary>
        public string RefreshSummary { get; set; }
        /// <summary> The number of reservations to skip from the list before returning results. </summary>
        public float? Skiptoken { get; set; }
        /// <summary> The selected provisioning state. </summary>
        public string SelectedState { get; set; }
        /// <summary> To number of reservations to return. </summary>
        public float? Take { get; set; }
    }
}
