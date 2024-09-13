// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace ClientModel.Tests.Paging;

internal class CollectionResultHelpers
{
    //public static AsyncCollectionResult<T> CreateAsync<T>(PageEnumerator<T> enumerator)
    //    => new AsyncPaginatedCollectionResult<T>(enumerator);

    public static CollectionResult<T> Create<T>(PageEnumerator<T> enumerator)
        => new PaginatedCollectionResult<T>(enumerator);

    //public static AsyncCollectionResult CreateAsync(PageEnumerator enumerator)
    //    => new AsyncPaginatedCollectionResult(enumerator);

    public static CollectionResult Create(PageEnumerator enumerator)
        => new PaginatedCollectionResult(enumerator);

    private class PaginatedCollectionResult<T> : CollectionResult<T>
    {
        private readonly PageEnumerator<T> _pageEnumerator;

        public PaginatedCollectionResult(PageEnumerator<T> pageEnumerator)
        {
            _pageEnumerator = pageEnumerator;
        }

        public override ContinuationToken? GetContinuationToken(ClientResult page)
        {
            return _pageEnumerator.GetNextPageToken(page);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            while (_pageEnumerator.MoveNext())
            {
                IEnumerable<T> page = _pageEnumerator.GetCurrentPage();
                foreach (T value in page)
                {
                    yield return value;
                }
            }
        }

        public override IEnumerable<ClientResult> GetRawPages()
        {
            while (_pageEnumerator.MoveNext())
            {
                yield return _pageEnumerator.Current;
            }
        }
    }

    private class PaginatedCollectionResult : CollectionResult
    {
        private readonly PageEnumerator _pageEnumerator;

        public PaginatedCollectionResult(PageEnumerator pageEnumerator)
        {
            _pageEnumerator = pageEnumerator;
        }

        public override ContinuationToken GetContinuationToken(ClientResult result)
        {
            // TODO: Validate continuation
            throw new NotImplementedException();
        }

        public override IEnumerable<ClientResult> GetRawPages()
        {
            while (_pageEnumerator.MoveNext())
            {
                yield return _pageEnumerator.Current;
            }
        }
    }
}
