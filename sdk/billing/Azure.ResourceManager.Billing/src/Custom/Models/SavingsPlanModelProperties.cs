// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Billing;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing.Models
{
    // Paired with BillingSavingsPlanModelData.cs in Custom/. The 2024-04-01 TypeSpec marks
    // SavingsPlanModelProperties.provisioningState as Lifecycle.Read (matching the ARM contract
    // — provisioningState is server-controlled), so the generator emits the inner property as
    // get-only. GA 1.2.2 exposed a setter on the public-facing flatten proxy
    // BillingSavingsPlanModelData.ProvisioningState. To restore that setter without rebuilding
    // SavingsPlanModelProperties via its 25-parameter internal constructor on every assignment,
    // suppress the get-only property here and re-declare it as { get; set; }. This holder type
    // is internal, so adding a setter has no ApiCompat surface impact of its own; it only
    // enables the public BillingSavingsPlanModelData.ProvisioningState setter to delegate
    // through cleanly.
    internal partial class SavingsPlanModelProperties
    {
        /// <summary> The provisioning state of the resource during a long-running operation. </summary>
        [WirePath("provisioningState")]
        public BillingProvisioningState? ProvisioningState { get; set; }
    }
}
