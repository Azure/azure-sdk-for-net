// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace ClientModel.Tests.Paging;

internal class PageCollectionHelpers
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

        public override ContinuationToken? ContinuationToken { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

        public override IEnumerable<BinaryData> AsRawValues()
        {
            throw new NotImplementedException();
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
    }

    private class PaginatedCollectionResult : CollectionResult
    {
        private readonly PageEnumerator _pageEnumerator;

        public PaginatedCollectionResult(PageEnumerator pageEnumerator)
        {
            _pageEnumerator = pageEnumerator;
        }

        public override ContinuationToken? ContinuationToken
        {
            get => throw new NotImplementedException();
            protected set => throw new NotImplementedException();
        }

        public override IEnumerable<BinaryData> AsRawValues()
        {
            while (_pageEnumerator.MoveNext())
            {
                ClientResult page = _pageEnumerator.Current;
                foreach (BinaryData rawValue in GetValuesFromPage(page))
                {
                    yield return rawValue;
                }
            }
        }

        // TODO: This has to be custom to the service schema
        private IEnumerable<BinaryData> GetValuesFromPage(ClientResult page)
        {
            PipelineResponse response = page.GetRawResponse();

            using JsonDocument doc = JsonDocument.Parse(response.Content);

            IEnumerable<JsonElement> els = doc.RootElement.EnumerateArray();
            foreach (JsonElement el in els)
            {
                // TODO: fix perf
                yield return BinaryData.FromString(el.ToString());
            }
        }
    }
}
