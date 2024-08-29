// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Billing.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmBillingModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.PaymentMethodProjectionProperties"/>. </summary>
        /// <param name="paymentMethodId"> Id of payment method. </param>
        /// <param name="family"> The family of payment method. </param>
        /// <param name="paymentMethodProjectionPropertiesType"> The type of payment method. </param>
        /// <param name="accountHolderName"> The account holder name for the payment method. This is only supported for payment methods with family CreditCard. </param>
        /// <param name="expiration"> The expiration month and year of the payment method. This is only supported for payment methods with family CreditCard. </param>
        /// <param name="lastFourDigits"> Last four digits of payment method. </param>
        /// <param name="displayName"> The display name of the payment method. </param>
        /// <param name="logos"> The list of logos for the payment method. </param>
        /// <param name="status"> Status of the payment method. </param>
        /// <returns> A new <see cref="Models.PaymentMethodProjectionProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PaymentMethodProjectionProperties PaymentMethodProjectionProperties(ResourceIdentifier paymentMethodId, BillingPaymentMethodFamily? family, string paymentMethodProjectionPropertiesType, string accountHolderName, string expiration, string lastFourDigits, string displayName, IEnumerable<PaymentMethodLogo> logos, BillingPaymentMethodStatus? status)
            => PaymentMethodProjectionProperties(paymentMethodId, accountHolderName, displayName, expiration, family, lastFourDigits, logos, paymentMethodProjectionPropertiesType, status);
    }
}
