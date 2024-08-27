// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.TestFramework.Mocks;

/// <summary>
/// Represents a mock implementation of the <see cref="AsyncResultCollection{TValue}"/> class.
/// </summary>
/// <typeparam name="TValue">The type of the values in the collection.</typeparam>
public class MockAsyncCollectionResult<TValue> : AsyncCollectionResult<TValue>
{
    private readonly Func<IAsyncEnumerable<TValue>> _enumerateAsyncFunc;

    /// <summary>
    /// Initializes a new instance of the <see cref="MockAsyncCollectionResult{TValue}"/> class
    /// with the specified asynchronous enumeration function and optional pipeline response.
    /// </summary>
    /// <param name="enumerateAsyncFunc">The function that asynchronously enumerates the values in the collection.</param>
    /// <param name="response">The optional pipeline response.</param>
    public MockAsyncCollectionResult(Func<IAsyncEnumerable<TValue>> enumerateAsyncFunc, PipelineResponse? response = null) :
        base(response ?? new MockPipelineResponse())
    {
        _enumerateAsyncFunc = enumerateAsyncFunc ?? throw new ArgumentNullException(nameof(enumerateAsyncFunc));
    }

    /// <inheritdoc/>
    public override IAsyncEnumerator<TValue> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        => _enumerateAsyncFunc().GetAsyncEnumerator(cancellationToken);
}
