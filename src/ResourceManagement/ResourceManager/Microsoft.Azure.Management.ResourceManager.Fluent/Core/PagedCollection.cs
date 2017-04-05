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
    public class PagedCollection<IFluentResourceT, InnerResourceT> : IPagedCollection<IFluentResourceT>
    {
        private IList<IFluentResourceT> innerCollection;

        private Func<InnerResourceT, CancellationToken, Task<IFluentResourceT>> WrapModelAsyncDelegate { get; set; }

        private Func<string, CancellationToken, Task<IPage<InnerResourceT>>> ListInnerNextAsyncDelegate { get; set; }

        private string NextPageLink { get; set; }

        public static IPagedCollection<IFluentResourceT> CreateFromEnumerable(IEnumerable<IFluentResourceT> fluentResourceList)
        {
            var pagedCollection = new PagedCollection<IFluentResourceT, InnerResourceT>();

            ((List<IFluentResourceT>)pagedCollection.innerCollection).AddRange(fluentResourceList);

            return pagedCollection;
        }


        public static async Task<IPagedCollection<IFluentResourceT>> LoadPage(
            Func<CancellationToken, Task<IEnumerable<InnerResourceT>>> listInnerAsync,
            Func<InnerResourceT, IFluentResourceT> wrapModel,
            CancellationToken cancellationToken)
        {
            return await LoadPage(async(cancellation) => Extensions.ConvertToPage(await listInnerAsync(cancellation)),
                async(nextLink, cancellation) => await Task.FromResult<IPage<InnerResourceT>>(null),
                wrapModel, false, cancellationToken);
        }

        public static async Task<IPagedCollection<IFluentResourceT>> LoadPage(
            Func<CancellationToken, Task<IPage<InnerResourceT>>> listInnerAsync,
            Func<string, CancellationToken, Task<IPage<InnerResourceT>>> listInnerNext,
            Func<InnerResourceT, IFluentResourceT> wrapModel,
            bool loadAllPages,
            CancellationToken cancellationToken)
        {
            return await LoadPageWithWrapModelAsync(listInnerAsync, listInnerNext,
                async (InnerResourceT, cancellation) => await Task.FromResult(wrapModel(InnerResourceT)),
                loadAllPages, cancellationToken);
        }


        public static async Task<IPagedCollection<IFluentResourceT>> LoadPageWithWrapModelAsync(
            Func<CancellationToken, Task<IPage<InnerResourceT>>> listInnerAsync,
            Func<string, CancellationToken, Task<IPage<InnerResourceT>>> listInnerNext,
            Func<InnerResourceT, CancellationToken, Task<IFluentResourceT>> wrapModelAsync,
            bool loadAllPages,
            CancellationToken cancellationToken)
        {
            var pagedCollection = new PagedCollection<IFluentResourceT, InnerResourceT>()
            {
                WrapModelAsyncDelegate = wrapModelAsync,
                ListInnerNextAsyncDelegate = listInnerNext
            };

            var currentPage = await listInnerAsync(cancellationToken);

            do
            {
                await pagedCollection.AddCollection(currentPage, pagedCollection, cancellationToken);
            } while (loadAllPages && currentPage?.NextPageLink != null &&
                     !cancellationToken.IsCancellationRequested &&
                     (currentPage = await pagedCollection.ListInnerNextAsyncDelegate(pagedCollection.NextPageLink, cancellationToken)) != null);

            return pagedCollection;
        }

        public PagedCollection()
        {
            innerCollection = new List<IFluentResourceT>();
            NextPageLink = null;
        }

        public IEnumerator<IFluentResourceT> GetEnumerator()
        {
            return innerCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerCollection.GetEnumerator();
        }

        public async Task<IPagedCollection<IFluentResourceT>> GetNextPageAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (NextPageLink == null)
            {
                return null;
            }

            var currentPage = await ListInnerNextAsyncDelegate(NextPageLink, cancellationToken);

            var pagedCollection = new PagedCollection<IFluentResourceT, InnerResourceT>()
            {
                WrapModelAsyncDelegate = this.WrapModelAsyncDelegate,
                ListInnerNextAsyncDelegate = this.ListInnerNextAsyncDelegate
            };

            await AddCollection(currentPage, pagedCollection, cancellationToken);

            return pagedCollection;
        }

        private async Task AddCollection(IPage<InnerResourceT> currentPage, PagedCollection<IFluentResourceT, InnerResourceT> pagedCollection,
            CancellationToken cancellationToken)
        {
            if (currentPage != null && currentPage.Any())
            {
                pagedCollection.NextPageLink = currentPage.NextPageLink;
                var resources = await Task.WhenAll(currentPage.Select(async (inner) => await this.WrapModelAsyncDelegate(inner, cancellationToken)));
                ((List<IFluentResourceT>)pagedCollection.innerCollection).AddRange(resources);
            }
        }

        
    }
}
