// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing.Models
{
    // Drop the meaningless setter on `BillingInvoiceProperties.RebillDetails`. The nested
    // `RebillDetails` model's fields are all `@visibility(Lifecycle.Read)`, but the
    // parent's `@@usage(BillingInvoiceProperties, Usage.input, "csharp")` emits a setter
    // here even though the value is read-only. Suppressing the generated property and
    // re-declaring as get-only restores the GA 1.2.2 shape byte-for-byte. The internal
    // full ctor still assigns the value during deserialization (auto-property setter on a
    // `{ get; }` is accessible from same-class partials).
    [CodeGenSuppress("RebillDetails")]
    public partial class BillingInvoiceProperties
    {
        /// <summary> Rebill details for an invoice. </summary>
        [WirePath("rebillDetails")]
        public RebillDetails RebillDetails { get; }
    }
}
