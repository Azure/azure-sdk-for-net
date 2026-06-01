// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    public partial class BillingSavingsPlanModelData
    {
        // Back-compat ctor for GA 1.2.2 callers. The new MPG generator emits only a
        // parameterless public ctor + an internal full ctor; GA exposed a required-arg
        // ctor that accepts BillingSku. Recreating it here preserves source compat.
        /// <summary> Initializes a new instance of <see cref="BillingSavingsPlanModelData"/>. </summary>
        /// <param name="sku"> Savings plan SKU. </param>
        public BillingSavingsPlanModelData(BillingSku sku) : this()
        {
            Sku = sku;
        }
    }
}
