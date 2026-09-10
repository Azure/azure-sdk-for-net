// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure;
using Azure.ResourceManager.CognitiveServices.Models;

namespace Azure.ResourceManager.CognitiveServices.Mocking
{
    public partial class MockableCognitiveServicesSubscriptionResource
    {
        /// <summary>
        /// Returns all deleted Cognitive Services accounts belonging to a subscription.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CognitiveServicesDeletedAccountResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use GetCognitiveServicesDeletedAccounts instead.", false)]
        public virtual AsyncPageable<CognitiveServicesDeletedAccountResource> GetDeletedAccountsAsync(CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<CognitiveServicesAccountData, CognitiveServicesDeletedAccountResource>(
                GetCognitiveServicesDeletedAccountsAsync(cancellationToken),
                data => new CognitiveServicesDeletedAccountResource(Client, data));
        }

        /// <summary>
        /// Returns all deleted Cognitive Services accounts belonging to a subscription.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CognitiveServicesDeletedAccountResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use GetCognitiveServicesDeletedAccounts instead.", false)]
        public virtual Pageable<CognitiveServicesDeletedAccountResource> GetDeletedAccounts(CancellationToken cancellationToken = default)
        {
            return new PageableWrapper<CognitiveServicesAccountData, CognitiveServicesDeletedAccountResource>(
                GetCognitiveServicesDeletedAccounts(cancellationToken),
                data => new CognitiveServicesDeletedAccountResource(Client, data));
        }
    }
}
