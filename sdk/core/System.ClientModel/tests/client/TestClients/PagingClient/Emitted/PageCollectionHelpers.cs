// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.Tests.Paging;

internal class PageCollectionHelpers
{
    public static PageCollection<T> Create<T>(PageEnumerator<T> enumerator)
        => new EnumeratorPageCollection<T>(enumerator);

    public static AsyncPageCollection<T> CreateAsync<T>(PageEnumerator<T> enumerator)
        => new AsyncEnumeratorPageCollection<T>(enumerator);

    public static IEnumerable<ClientResult> Create(PageResultEnumerator enumerator)
    {
        while (enumerator.MoveNext())
        {
            yield return enumerator.Current;
        }
    }

    public static async IAsyncEnumerable<ClientResult> CreateAsync(PageResultEnumerator enumerator)
    {
        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
        {
            yield return enumerator.Current;
        }
    }

    private class EnumeratorPageCollection<T> : PageCollection<T>
    {
        private readonly PageEnumerator<T> _enumerator;

        public EnumeratorPageCollection(PageEnumerator<T> enumerator)
        {
            _enumerator = enumerator;
        }

        protected override PageResult<T> GetCurrentPageCore()
            => _enumerator.GetCurrentPage();

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

        protected override async Task<PageResult<T>> GetCurrentPageAsyncCore()
            => await _enumerator.GetCurrentPageAsync().ConfigureAwait(false);

        protected override IAsyncEnumerator<PageResult<T>> GetAsyncEnumeratorCore(CancellationToken cancellationToken = default)
            => _enumerator;
    }
}
