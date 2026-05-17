// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Azure;

namespace Azure.ResourceManager.AppConfiguration
{
    public partial class DeletedAppConfigurationStoreCollection : IEnumerable<DeletedAppConfigurationStoreResource>, IAsyncEnumerable<DeletedAppConfigurationStoreResource>
    {
        /// <summary>
        /// Gets information about the deleted configuration stores in a subscription.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeletedAppConfigurationStoreResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DeletedAppConfigurationStoreResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Client.GetSubscriptionResource(Id).GetDeletedAppConfigurationStoresAsync(cancellationToken);
        }

        /// <summary>
        /// Gets information about the deleted configuration stores in a subscription.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeletedAppConfigurationStoreResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DeletedAppConfigurationStoreResource> GetAll(CancellationToken cancellationToken = default)
        {
            return Client.GetSubscriptionResource(Id).GetDeletedAppConfigurationStores(cancellationToken);
        }

        IEnumerator<DeletedAppConfigurationStoreResource> IEnumerable<DeletedAppConfigurationStoreResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DeletedAppConfigurationStoreResource> IAsyncEnumerable<DeletedAppConfigurationStoreResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
