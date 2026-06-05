// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Billing.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing
{
    // Two GA 1.2.2 back-compat shims:
    //   * Public BillingSavingsPlanModelData(BillingSku) ctor — GA exposed a required-arg ctor
    //     that accepted BillingSku because every other property was @visibility(Read); the new
    //     MPG generator emits only a parameterless ctor.
    //   * ProvisioningState setter — the 2024-04-01 TypeSpec marks
    //     SavingsPlanModelProperties.provisioningState as Lifecycle.Read (matching the ARM
    //     contract that provisioningState is server-controlled and ignored when sent in
    //     PUT/PATCH bodies), so the generator emits the flatten proxy here as get-only. GA
    //     exposed the setter and `ApiCompat` flags removing it as a binary break, so suppress
    //     the Generated get-only flavor and re-declare with a setter that delegates to the
    //     (Custom-promoted to writable) Properties.ProvisioningState — see the paired
    //     src/Custom/Models/SavingsPlanModelProperties.cs partial.
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

        /// <summary> The provisioning state of the resource during a long-running operation. </summary>
        [WirePath("properties.provisioningState")]
        public BillingProvisioningState? ProvisioningState
        {
            get => Properties?.ProvisioningState;
            set
            {
                if (Properties is null)
                {
                    Properties = new SavingsPlanModelProperties();
                }
                Properties.ProvisioningState = value;
            }
        }
    }
}
