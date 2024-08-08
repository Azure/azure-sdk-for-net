// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.TestFramework.Mocks;

/// <summary>
/// Represents a mock implementation of the <see cref="AsyncPageableCollection{T}"/> class.
/// </summary>
/// <typeparam name="TValue">The type of the values in the collection.</typeparam>
public class MockAsyncPageCollection<TValue> : AsyncPageCollection<TValue>
{
    private readonly Func<IAsyncEnumerable<TValue>> _enumerateAsyncFunc;
    private readonly PipelineResponse _response;
    private readonly int _itemsPerPage;
    private PageResult<TValue>? _currentPage;

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    /// <param name="enumerateAsyncFunc">The function that enumerates the collection asynchronously.</param>
    /// <param name="response">The pipeline response.</param>
    public MockAsyncPageCollection(Func<IAsyncEnumerable<TValue>> enumerateAsyncFunc, PipelineResponse response, int itemsPerPage = 5)
    {
        if (itemsPerPage <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(itemsPerPage));
        }

        _enumerateAsyncFunc = enumerateAsyncFunc ?? throw new ArgumentNullException(nameof(enumerateAsyncFunc));
        _response = response;
        _itemsPerPage = itemsPerPage;
    }

    /// <inheritdoc />
    protected override Task<PageResult<TValue>> GetCurrentPageAsyncCore()
        => Task.FromResult(_currentPage ?? throw new InvalidOperationException("Please call MoveNextAsync first."));

    /// <inheritdoc />
    protected override async IAsyncEnumerator<PageResult<TValue>> GetAsyncEnumeratorCore(CancellationToken cancellationToken = default)
    {
        List<TValue> items = new(_itemsPerPage);
        int pageStart = 0;
        int rolling = 0;

        await foreach (TValue value in _enumerateAsyncFunc())
        {
            items.Add(value);
            rolling++;
            if (items.Count == _itemsPerPage)
            {
                _currentPage = PageResult<TValue>.Create(items, ToContinuation(pageStart), ToContinuation(rolling), _response);
                yield return _currentPage;
                items.Clear();
                pageStart = rolling;
            }
        }

        if (items.Count > 0)
        {
            _currentPage = PageResult<TValue>.Create(items, ToContinuation(pageStart), ToContinuation(rolling), _response);
            yield return _currentPage;
        }
    }

    private static ContinuationToken ToContinuation(int offset)
        => ContinuationToken.FromBytes(BinaryData.FromBytes(BitConverter.GetBytes(offset)));
}
