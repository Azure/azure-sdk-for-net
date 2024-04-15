// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class AsyncEnumerableResult<T> : ClientResult, IAsyncEnumerable<T>, IAsyncDisposable
    where T : IPersistableModel<T>
{
    protected internal AsyncEnumerableResult(PipelineResponse response) : base(response)
    {
    }

    public abstract IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default);

    protected abstract ValueTask DisposeAsyncCore();

    protected abstract void Dispose(bool disposing);

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);

        // Dispose of unmanaged resources. Note that DisposeAsyncCore disposes
        // of managed resources asychronously -- we pass false to Dispose so we
        // don't attempt to dispose of them synchronously as well.
        Dispose(disposing: false);

        GC.SuppressFinalize(this);
    }
}
#pragma warning restore CS1591 // public XML comments
