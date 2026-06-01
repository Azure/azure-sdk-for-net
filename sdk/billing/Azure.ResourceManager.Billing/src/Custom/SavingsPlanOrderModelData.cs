// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    public partial class SavingsPlanOrderModelData
    {
        // Back-compat ctor for GA 1.2.2 callers. Same pattern as BillingSavingsPlanModelData:
        // the new MPG generator emits only a parameterless public ctor + an internal full
        // ctor; GA exposed a required-arg ctor that accepts BillingSku.
        /// <summary> Initializes a new instance of <see cref="SavingsPlanOrderModelData"/>. </summary>
        /// <param name="sku"> Savings plan SKU. </param>
        public SavingsPlanOrderModelData(BillingSku sku) : this()
        {
            Sku = sku;
        }
    }
}
