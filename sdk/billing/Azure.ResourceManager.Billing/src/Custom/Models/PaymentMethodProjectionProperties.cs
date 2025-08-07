// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Billing.Models
{
    /// <summary> The properties of a payment method projection. </summary>
    public partial class PaymentMethodProjectionProperties
    {
        /// <summary> The type of payment method. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `PaymentMethodType` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PaymentMethodProjectionPropertiesType { get => PaymentMethodType; }
    }
}
