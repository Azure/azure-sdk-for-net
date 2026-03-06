// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.BillingBenefits
{
    // Workaround: The generator constructs CollectionResults with incorrect parameter mapping.
    // The CollectionResult expects all query parameters, but the generated code passes
    // a path parameter (Id.Name) where query parameters are expected.
    [CodeGenSuppress("GetAllAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(CancellationToken))]
    public partial class SavingsPlanModelCollection
    {
        /// <summary>
        /// List savings plans in an order.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SavingsPlanModelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SavingsPlanModelResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<SavingsPlanModelData, SavingsPlanModelResource>(
                new SavingsPlanGetAllAsyncCollectionResultOfT(_savingsPlanRestClient, null, null, null, null, null, null, context),
                data => new SavingsPlanModelResource(Client, data));
        }

        /// <summary>
        /// List savings plans in an order.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SavingsPlanModelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SavingsPlanModelResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<SavingsPlanModelData, SavingsPlanModelResource>(
                new SavingsPlanGetAllCollectionResultOfT(_savingsPlanRestClient, null, null, null, null, null, null, context),
                data => new SavingsPlanModelResource(Client, data));
        }
    }
}
