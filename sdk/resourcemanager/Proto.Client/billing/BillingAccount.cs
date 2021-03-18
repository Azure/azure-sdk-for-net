// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Proto.Billing
{
    /// <summary>
    /// A class representing an availability set along with the instance operations that can be performed on it.
    /// </summary>
    public class BillingAccount : BillingAccountOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BillingAccount"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal BillingAccount(ResourceOperationsBase options, BillingAccountData resource)
            : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary>
        /// Gets or sets the availability set data.
        /// </summary>
        public BillingAccountData Data { get; private set; }

        /// <inheritdoc />
        protected override BillingAccount GetResource()
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<BillingAccount> GetResourceAsync(CancellationToken cancellation = default)
        {
            return Task.FromResult(this);
        }
    }
}
