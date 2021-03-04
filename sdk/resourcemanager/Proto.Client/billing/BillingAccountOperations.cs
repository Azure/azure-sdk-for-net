using Azure;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Billing;
using Azure.Core;

namespace Proto.Billing
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific availability set.
    /// </summary>
    public class BillingAccountOperations : ResourceOperationsBase<BillingAccount>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResourceOperations"/> class.
        /// </summary>
        /// <param name="genericOperations"> An instance of <see cref="GenericResourceOperations"/> that has an id for an availability set. </param>
        internal BillingAccountOperations(GenericResourceOperations genericOperations)
            : base(genericOperations)
        {
        }

        internal BillingAccountOperations(AzureResourceManagerClientOptions options, string billingAccountId, TokenCredential credential, Uri baseUri)
            : base(options, $"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}", credential, baseUri)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResourceOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal BillingAccountOperations(ResourceOperationsBase options, ResourceIdentifier id)
            : base(options, id)
        {
        }

        /// <summary>
        /// Gets the resource type definition for an availability set.
        /// </summary>
        public static readonly ResourceType ResourceType = "/Microsoft.Billing/billingAccounts";

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceType;

        private IBillingAccountsOperations Operations => new BillingManagementClient(
            BaseUri,
            null).BillingAccounts;


        /// <inheritdoc/>
        public override ArmResponse<BillingAccount> Get()
        {
            return null;
        }

        /// <inheritdoc/>
        public async override Task<ArmResponse<BillingAccount>> GetAsync(CancellationToken cancellationToken = default)
        {
            return null;
        }

    }
}
