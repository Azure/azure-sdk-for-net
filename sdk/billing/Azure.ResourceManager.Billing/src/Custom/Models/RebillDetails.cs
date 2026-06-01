// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing.Models
{
    // Restore the GA 1.2.2 `internal RebillDetails()` parameterless ctor visibility.
    // The new TypeSpec spec models `RebillDetails` with all-readOnly fields, but the
    // `@@usage(BillingInvoiceProperties, Usage.input, "csharp")` block propagates
    // transitively through `BillingInvoiceProperties.rebillDetails:
    // InvoicePropertiesRebillDetails extends RebillDetails` and MPG's default for any
    // Usage.input model is a public parameterless ctor. Suppress the generated public
    // ctor and re-declare as internal to match GA byte-for-byte.
    [CodeGenSuppress("RebillDetails")]
    public partial class RebillDetails
    {
        /// <summary> Initializes a new instance of <see cref="RebillDetails"/>. </summary>
        internal RebillDetails()
        {
        }
    }
}
