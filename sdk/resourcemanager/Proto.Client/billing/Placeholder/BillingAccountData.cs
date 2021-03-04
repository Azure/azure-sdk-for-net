using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;
using System;
using System.Collections.Generic;

namespace Proto.Billing
{
    /// <summary>
    /// A class representing the availability set data model.
    /// </summary>
    public class BillingAccountData : TrackedResource<Microsoft.Azure.Management.Billing.Models.BillingAccount>
    {
        /// <summary>
        /// Gets the resource type definition for an availability set.
        /// </summary>
        public static ResourceType ResourceType => "Microsoft.Billing/BillingAccount";

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingAccountData"/> class.
        /// </summary>
        /// <param name="aset"> The availability set to initialize. </param>
        public BillingAccountData(Microsoft.Azure.Management.Billing.Models.BillingAccount billingAccount)
            : base(billingAccount.Id, "westus", billingAccount)
        {
        }
    }
}
