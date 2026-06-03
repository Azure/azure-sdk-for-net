// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
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
