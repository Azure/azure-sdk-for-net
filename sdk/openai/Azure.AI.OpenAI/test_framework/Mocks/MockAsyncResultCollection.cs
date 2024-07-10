// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel.TestFramework.Mocks;

public class MockAsyncResultCollection<TValue> : AsyncResultCollection<TValue>
{
    private readonly Func<IAsyncEnumerable<TValue>> _enumerateAsyncFunc;

    public MockAsyncResultCollection(Func<IAsyncEnumerable<TValue>> enumerateAsyncFunc, PipelineResponse? response = null) :
        base(response ?? new MockPipelineResponse())
    {
        _enumerateAsyncFunc = enumerateAsyncFunc ?? throw new ArgumentNullException(nameof(enumerateAsyncFunc));
    }


    public override IAsyncEnumerator<TValue> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        => _enumerateAsyncFunc().GetAsyncEnumerator(cancellationToken);
}
