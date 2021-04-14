// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core;
using System;

namespace Proto.Billing
{
    /// <summary>
    /// A class to add extension methods to an ArmClient.
    /// </summary>
    public static class TenantExtensions
    {

        /// <summary>
        /// Gets the BillingAccountsOperations.
        /// </summary>
        /// <param name="client"> The <see cref="TenantOperations" /> instance the method will execute against. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="BillingAccountOperations" />. </returns>
        public static BillingAccountOperations GetBillingAccountsOperations(this TenantOperations tenant, string billingAccountId)
        {
            if (string.IsNullOrEmpty(billingAccountId))
                throw new ArgumentException(nameof(billingAccountId));
            return new BillingAccountOperations(tenant, billingAccountId);
        }
    }
}
