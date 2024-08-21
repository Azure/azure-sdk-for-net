// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

// Mini-client base type to support obtaining pages of values

#pragma warning disable CS1591
public abstract class PageableResult : ClientResult
{
    public abstract ClientResult GetNextPage(ClientResult? result, RequestOptions options);
    public abstract Task<ClientResult> GetNextPageAsync(ClientResult? result, RequestOptions options);

    public abstract bool HasNext(ClientResult result);

    protected virtual bool TryGetPage<T>(ClientResult result, out PageResult<T>? page)
    {
        page = default;
        return false;
    }

    private PageResult<T> ToPage<T>(ClientResult result)
    {
        if (!TryGetPage(result, out PageResult<T>? page) || page is null)
        {
            throw new InvalidOperationException("Cannot convert result to PageResult<T>");
        }

        return page;
    }

    public AsyncPageCollection<T> ToAsyncPageCollection<T>()
    {
        PageEnumerator<T> enumerator = new(this, ToPage<T>);
        return new AsyncEnumeratorPageCollection<T>(enumerator);
    }

    public PageCollection<T> ToPageCollection<T>()
    {
        PageEnumerator<T> enumerator = new(this, ToPage<T>);
        return new EnumeratorPageCollection<T>(enumerator);
    }

    public async IAsyncEnumerable<ClientResult> ToAsyncEnumerable()
    {
        PageEnumerator enumerator = new(this);
        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
        {
            yield return enumerator.Current;
        }
    }

    public IEnumerable<ClientResult> ToEnumerable()
    {
        PageEnumerator enumerator = new(this);
        while (enumerator.MoveNext())
        {
            yield return enumerator.Current;
        }
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
}
#pragma warning restore CS1591
