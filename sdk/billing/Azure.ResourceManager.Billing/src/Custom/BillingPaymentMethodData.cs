// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing
{
    // The MPG generator's @@Legacy.flattenProperty(PaymentMethod.properties) flattens every
    // public property of PaymentMethodProjectionProperties into BillingPaymentMethodData,
    // including the [Obsolete] back-compat alias `PaymentMethodProjectionPropertiesType`
    // declared in Custom/Models/PaymentMethodProjectionProperties.cs. That pass-through call
    // triggers CS0618 (escalated to error via eng/Directory.Build.Common.props
    // TreatWarningsAsErrors=true) and adds a property that does not exist on the GA
    // BillingPaymentMethodData contract. Suppress it so the auto-flattening side-effect
    // is dropped and the API surface matches GA exactly.
    [CodeGenSuppress("PaymentMethodProjectionPropertiesType")]
    public partial class BillingPaymentMethodData
    {
    }
}
