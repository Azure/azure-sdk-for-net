// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Collections.Generic;
using System.Threading;

namespace ClientModel.Tests.PagingClient;

internal class PageCollectionHelpers
{
    public static PageCollection<T> Create<T>(PageEnumerator<T> enumerator)
        => new EnumeratorPageCollection<T>(enumerator);

    public static AsyncPageCollection<T> CreateAsync<T>(PageEnumerator<T> enumerator)
        => new AsyncEnumeratorPageCollection<T>(enumerator);

    public static IEnumerable<ClientResult> Create(PageResultEnumerator enumerator)
    {
        do
        {
            if (enumerator.Current is not null)
            {
                yield return enumerator.Current;
            }
        }
        while (enumerator.MoveNext());
    }

    public static async IAsyncEnumerable<ClientResult> CreateAsync(PageResultEnumerator enumerator)
    {
        do
        {
            if (enumerator.Current is not null)
            {
                yield return enumerator.Current;
            }
        }
        while (await enumerator.MoveNextAsync().ConfigureAwait(false));
    }

    private class EnumeratorPageCollection<T> : PageCollection<T>
    {
        private readonly PageEnumerator<T> _enumerator;

        public EnumeratorPageCollection(PageEnumerator<T> enumerator)
        {
            _enumerator = enumerator;
        }

        protected override IEnumerator<PageResult<T>> GetEnumeratorCore()
            => _enumerator;
    }

    private class AsyncEnumeratorPageCollection<T> : AsyncPageCollection<T>
    {
        private readonly PageEnumerator<T> _enumerator;

        public AsyncEnumeratorPageCollection(PageEnumerator<T> enumerator)
        {
            _enumerator = enumerator;
        }

        protected override IAsyncEnumerator<PageResult<T>> GetAsyncEnumeratorCore(CancellationToken cancellationToken = default)
            => _enumerator;
    }
}
