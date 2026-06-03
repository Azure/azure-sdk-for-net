// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat for GA 1.2.2 API surface. GA exposed:
    //   - A single-parameter ctor `BillingSavingsPlanModelData(BillingSku)` because all other
    //     properties were @visibility(Read). The new MPG generator emits a parameterless internal
    //     ctor only (Sku no longer required for read-only models).
    //   - `ProvisioningState` with a private setter for source-compat with code that assigned it.
    // Restore both surfaces via this partial; the property setter is hidden via EditorBrowsable.
    public partial class BillingSavingsPlanModelData
    {
        /// <summary> Initializes a new instance of <see cref="BillingSavingsPlanModelData"/>. </summary>
        /// <param name="sku"> Savings plan SKU. </param>
        public BillingSavingsPlanModelData(BillingSku sku)
        {
            Sku = sku;
        }

        /// <summary> The provisioning state of the resource during a long-running operation. </summary>
        [WirePath("properties.provisioningState")]
        public BillingProvisioningState? ProvisioningState { get; [EditorBrowsable(EditorBrowsableState.Never)] set; }
    }
}
