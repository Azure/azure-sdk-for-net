// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Billing.Models
{
    // Back-compat aliases for GA 1.2.2 flattened property names. The new generator emits
    // the spec property names directly (InstanceFlexibility / ReservedInstanceFlexibility);
    // GA generated disambiguating prefixes from the nested `InstanceFlexibilityProperties`
    // wrapper that no longer surfaces in the new shape.
    public partial class ReservationPurchaseRequest
    {
        /// <summary> Type of the Instance Flexibility. </summary>
        public InstanceFlexibility? InstanceFlexibilityPropertiesInstanceFlexibility
        {
            get => InstanceFlexibility;
            set => InstanceFlexibility = value;
        }

        /// <summary> Type of the Instance Flexibility. </summary>
        public InstanceFlexibility? InstanceFlexibilityPropertiesReservedResourcePropertiesInstanceFlexibility
        {
            get => ReservedInstanceFlexibility;
            set => ReservedInstanceFlexibility = value;
        }
    }
}
