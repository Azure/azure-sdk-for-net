// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing.Models
{
    // Suppress the generated public parameterless ctor on `InvoicePropertiesRebillDetails`
    // for the same reason as `RebillDetails` above. The base class' parameterless ctor is
    // also internal, so this subclass must match. (GA 1.2.2 did not have this type at all
    // — its existence is a side effect of how the TypeSpec spec defines
    // `InvoicePropertiesRebillDetails extends RebillDetails {}`. The type can stay; only
    // its ctor visibility needs to match the base.)
    [CodeGenSuppress("InvoicePropertiesRebillDetails")]
    public partial class InvoicePropertiesRebillDetails
    {
        /// <summary> Initializes a new instance of <see cref="InvoicePropertiesRebillDetails"/>. </summary>
        internal InvoicePropertiesRebillDetails()
        {
        }
    }
}
