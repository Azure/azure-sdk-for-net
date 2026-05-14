// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA exposed flattened MsrpP1Y on ReservationCatalog. The new TypeSpec generator
// keeps the Msrp envelope object; this shim surfaces the GA-flat property for back-compat.

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations.Models
{
    public partial class ReservationCatalog
    {
        public PurchasePrice MsrpP1Y => Msrp?.P1Y;
    }
}
