// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat ctor for GA 1.2.2 callers. GA exposed a required-arg ctor that accepted
    // BillingSku because every other property was @visibility(Read); the new MPG generator
    // emits only a parameterless ctor.
    public partial class BillingSavingsPlanModelData
    {
        /// <summary> Initializes a new instance of <see cref="BillingSavingsPlanModelData"/>. </summary>
        /// <param name="sku"> Savings plan SKU. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sku"/> is null. </exception>
        public BillingSavingsPlanModelData(BillingSku sku)
        {
            Argument.AssertNotNull(sku, nameof(sku));

            Sku = sku;
            Tags = new ChangeTrackingDictionary<string, string>();
        }
    }
}
