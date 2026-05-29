// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Billing.Models
{
    // Back-compat alias for the GA 1.2.2 `PaymentMethodProjectionPropertiesType` property.
    // GA generated a flattening-disambiguator name; new generator emits the spec name
    // directly as `PaymentMethodType`.
    public partial class PaymentMethodProjectionProperties
    {
        /// <summary> The type of payment method. </summary>
        public string PaymentMethodProjectionPropertiesType => PaymentMethodType;
    }
}
