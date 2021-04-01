// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Billing;
using Azure.ResourceManager.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Proto.Billing
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific availability set.
    /// </summary>
    public class BillingAccountOperations : ResourceOperationsBase<TenantResourceIdentifier, BillingAccount>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResourceOperations"/> class.
        /// </summary>
        /// <param name="genericOperations"> An instance of <see cref="GenericResourceOperations"/> that has an id for an availability set. </param>
        internal BillingAccountOperations(GenericResourceOperations genericOperations)
            : base(genericOperations, genericOperations.Id)
        {
        }

        //TODO : dicuss ways to not pass in Subscription subscription for tenant only resources
        internal BillingAccountOperations(TenantOperations tenant, string billingAccountId)
            : base(tenant, $"/providers/{ResourceType}/{billingAccountId}")
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
        public static readonly ResourceType ResourceType = "Microsoft.Billing/billingAccounts";

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceType;

        private BillingAccountsOperations Operations => new BillingManagementClient(
            BaseUri,
            Guid.Empty.ToString(),
            Credential,
            ClientOptions.Convert<BillingManagementClientOptions>()).BillingAccounts;


        /// <inheritdoc/>
        public override ArmResponse<BillingAccount> Get(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<BillingAccount, Azure.ResourceManager.Billing.Models.BillingAccount>(
                Operations.Get(Id.Name, cancellationToken: cancellationToken),
                Converter());
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<BillingAccount>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<BillingAccount, Azure.ResourceManager.Billing.Models.BillingAccount>(
                await Operations.GetAsync(Id.Name, null, cancellationToken).ConfigureAwait(false),
                Converter());
        }

        private Func<Azure.ResourceManager.Billing.Models.BillingAccount, BillingAccount> Converter()
        {
            return s => new BillingAccount(this, new BillingAccountData(s));
        }
    }
}
