// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Rest.Azure;
using System.Threading.Tasks;
using System.Threading;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public class PagedCollection<T> : IEnumerable<T>
    {
        private IList<T> innerCollection;
        private Func<string, CancellationToken, Task<IPage<T>>> nextPageDelegate;

        public PagedCollection()
        {
            innerCollection = new List<T>();
        }

        public async static Task<PagedCollection<T>> Load(
            Func<Task<IPage<T>>> firstPageAsyncDelegate, 
            Func<string, CancellationToken, Task<IPage<T>>> nextPageAsyncDelegate,
            CancellationToken cancellationToken)
        {
            var pagedCollection = new PagedCollection<T>();

            var currentPage = await firstPageAsyncDelegate();

            do
            {
                if (currentPage == null ||
                    !currentPage.Any())
                {
                    break;
                }

                ((List<T>)pagedCollection.innerCollection).AddRange(currentPage);

            } while (currentPage.NextPageLink != null &&
                     !cancellationToken.IsCancellationRequested &&
                     (currentPage = await nextPageAsyncDelegate(currentPage.NextPageLink, cancellationToken)) != null);

            return pagedCollection;
        }

        private async Task<IPage<T>> LoadNextPageAsync(string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await nextPageDelegate(nextPageLink, cancellationToken);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return innerCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerCollection.GetEnumerator();
        }
    }
}
