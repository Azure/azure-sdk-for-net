// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Billing.Models
{
    // Back-compat alias for the GA 1.2.2 `PaymentMethodProjectionPropertiesType` property.
    // GA generated a flattening-disambiguator name; new generator emits the spec name
    // directly as `PaymentMethodType`. Marked [Obsolete] + hidden from IntelliSense to
    // match the GA contract exactly.
    public partial class PaymentMethodProjectionProperties
    {
        /// <summary> The type of payment method. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `PaymentMethodType` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PaymentMethodProjectionPropertiesType { get => PaymentMethodType; }
    }
}
