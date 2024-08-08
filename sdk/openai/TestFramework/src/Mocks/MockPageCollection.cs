// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.TestFramework.Mocks;

/// <summary>
/// Represents a mock implementation of the <see cref="PageableCollection{T}"/> class.
/// </summary>
/// <typeparam name="TValue">The type of the values in the collection.</typeparam>
public class MockPageCollection<TValue> : PageCollection<TValue>
{
    private readonly Func<IEnumerable<TValue>> _enumerateFunc;
    private readonly PipelineResponse _response;
    private readonly int _itemsPerPage;
    private PageResult<TValue>? _currentPage;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="enumerateFunc">The function used to enumerate the collection.</param>
    /// <param name="response">The pipeline response.</param>
    /// <param name="itemsPerPage">(Optional) The number of items per page.</param>
    public MockPageCollection(Func<IEnumerable<TValue>> enumerateFunc, PipelineResponse response, int itemsPerPage = 5)
    {
        if (itemsPerPage <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(itemsPerPage));
        }

        _enumerateFunc = enumerateFunc ?? throw new ArgumentNullException(nameof(enumerateFunc));
        _response = response;
        _itemsPerPage = itemsPerPage;
    }

    /// <inheritdoc />
    protected override PageResult<TValue> GetCurrentPageCore()
        => _currentPage ?? throw new InvalidOperationException("Please call MoveNextAsync first.");

    /// <inheritdoc />
    protected override IEnumerator<PageResult<TValue>> GetEnumeratorCore()
    {
        List<TValue> items = new(_itemsPerPage);
        int pageStart = 0;
        int rolling = 0;

        foreach (TValue item in _enumerateFunc())
        {
            items.Add(item);
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
            _currentPage = PageResult<TValue>.Create(items, ToContinuation(pageStart), null, _response);
            yield return _currentPage;
        }
    }

    private static ContinuationToken ToContinuation(int offset)
        => ContinuationToken.FromBytes(BinaryData.FromBytes(BitConverter.GetBytes(offset)));
}
