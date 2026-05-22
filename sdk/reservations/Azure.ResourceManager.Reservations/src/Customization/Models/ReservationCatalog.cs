// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations.Models
{
    // The new generator preserves the msrp envelope as ReservationCatalog.Msrp.P1Y;
    // this shim restores the GA-flat ReservationCatalog.MsrpP1Y property for compatibility.
    public partial class ReservationCatalog
    {
        public PurchasePrice MsrpP1Y => Msrp?.P1Y;
    }
}
