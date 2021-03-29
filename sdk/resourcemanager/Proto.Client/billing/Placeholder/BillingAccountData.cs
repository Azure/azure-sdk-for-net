// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core;

namespace Proto.Billing
{
    /// <summary>
    /// A class representing the availability set data model.
    /// </summary>
    public class BillingAccountData : TrackedResource<TenantResourceIdentifier, Azure.ResourceManager.Billing.Models.BillingAccount>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingAccountData"/> class.
        /// </summary>
        /// <param name="billingAccount"> The availability set to initialize. </param>
        public BillingAccountData(Azure.ResourceManager.Billing.Models.BillingAccount billingAccount)
            : base(billingAccount.Id, "westus", billingAccount)
        {
        }
    }
}
