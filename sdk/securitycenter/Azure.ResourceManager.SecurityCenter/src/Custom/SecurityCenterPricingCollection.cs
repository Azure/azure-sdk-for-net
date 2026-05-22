// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter.Models;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter
{
    // The generated filter overload collides with the GA no-filter overload when IEnumerable calls GetAll().
    [CodeGenSuppress("GetAll", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAllAsync", typeof(string), typeof(CancellationToken))]
    public partial class SecurityCenterPricingCollection
    {
        /// <summary> Lists Microsoft Defender for Cloud pricing configurations of the scope. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityCenterPricingResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityCenterPricingResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<SecurityCenterPricingData, SecurityCenterPricingResource>(new SecurityCenterPricingGetAllAsyncCollectionResultOfT(_pricingsRestClient, Id.ToString(), null, context, "SecurityCenterPricingCollection.GetAll"), data => new SecurityCenterPricingResource(Client, data));
        }

        /// <summary> Lists Microsoft Defender for Cloud pricing configurations of the scope. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityCenterPricingResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityCenterPricingResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<SecurityCenterPricingData, SecurityCenterPricingResource>(new SecurityCenterPricingGetAllCollectionResultOfT(_pricingsRestClient, Id.ToString(), null, context, "SecurityCenterPricingCollection.GetAll"), data => new SecurityCenterPricingResource(Client, data));
        }
    }
}
