// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Marketplace.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Marketplace
{
    // Fix generator bug: generated GetAll() returns Response<CollectionsList> but IEnumerable
    // implementations call GetAll().GetEnumerator() which doesn't exist on Response<T>.
    // Suppress the generated methods and provide Pageable<T>/AsyncPageable<T> versions instead.
    [CodeGenSuppress("GetAll", typeof(CancellationToken))]
    [CodeGenSuppress("GetAllAsync", typeof(CancellationToken))]
    public partial class PrivateStoreCollectionInfoCollection
    {
        /// <summary> Gets private store collections list. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PrivateStoreCollectionInfoResource> GetAll(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _privateStoreCollectionInfoClientDiagnostics.CreateScope("PrivateStoreCollectionInfoCollection.GetAll");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _privateStoreCollectionInfoRestClient.CreateGetAllRequest(Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                var list = CollectionsList.FromResponse(result);
                var items = (list.Value ?? Array.Empty<PrivateStoreCollectionInfoData>())
                    .Select(data => new PrivateStoreCollectionInfoResource(Client, data))
                    .ToList();
                var page = Page<PrivateStoreCollectionInfoResource>.FromValues(items, null, result);
                return Pageable<PrivateStoreCollectionInfoResource>.FromPages(new[] { page });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets private store collections list. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PrivateStoreCollectionInfoResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            // Use sync HTTP call wrapped in AsyncPageable for this single-page non-paginated API
            return AsyncPageable<PrivateStoreCollectionInfoResource>.FromPages(GetAll(cancellationToken).AsPages());
        }
    }
}
