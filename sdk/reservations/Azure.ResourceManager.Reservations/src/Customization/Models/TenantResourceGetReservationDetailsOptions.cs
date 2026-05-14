// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA exposed an options-bag overload for TenantResource.GetReservationDetails
// (TenantResourceGetReservationDetailsOptions). The new TypeSpec generator emits long-form
// parameters; this type and overloads preserve the GA options-bag surface.

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations.Models
{
    public partial class TenantResourceGetReservationDetailsOptions
    {
        public TenantResourceGetReservationDetailsOptions()
        {
        }

        public string Filter { get; set; }
        public string Orderby { get; set; }
        public string RefreshSummary { get; set; }
        public float? Skiptoken { get; set; }
        public string SelectedState { get; set; }
        public float? Take { get; set; }
    }
}
