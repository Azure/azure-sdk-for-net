// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat ctor for GA 1.2.2 callers. Same pattern as BillingSavingsPlanModelData:
    // the new MPG generator emits only a parameterless public ctor + an internal full
    // ctor; GA exposed a required-arg ctor that accepts BillingSku.
    public partial class SavingsPlanOrderModelData
    {
        /// <summary> Initializes a new instance of <see cref="SavingsPlanOrderModelData"/>. </summary>
        /// <param name="sku"> Savings plan SKU. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sku"/> is null. </exception>
        public SavingsPlanOrderModelData(BillingSku sku)
        {
            Argument.AssertNotNull(sku, nameof(sku));

            Sku = sku;
            Tags = new ChangeTrackingDictionary<string, string>();
        }
    }
}
