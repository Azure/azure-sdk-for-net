// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.TestFramework.Mocks;

/// <summary>
/// Represents a mock implementation of the <see cref="AsyncPageableCollection{T}"/> class.
/// </summary>
/// <typeparam name="TValue">The type of the values in the collection.</typeparam>
public class MockAsyncPageableCollection<TValue> : AsyncPageableCollection<TValue>
{
    private readonly Func<IAsyncEnumerable<TValue>> _enumerateAsyncFunc;
    private readonly PipelineResponse _response;
    private bool _responseSet;

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    /// <param name="enumerateAsyncFunc">The function that enumerates the collection asynchronously.</param>
    /// <param name="response">The pipeline response.</param>
    public MockAsyncPageableCollection(Func<IAsyncEnumerable<TValue>> enumerateAsyncFunc, PipelineResponse response)
    {
        _enumerateAsyncFunc = enumerateAsyncFunc ?? throw new ArgumentNullException(nameof(enumerateAsyncFunc));
        _response = response;
    }

    /// <inheritdoc />
    public override async IAsyncEnumerable<ResultPage<TValue>> AsPages(string? continuationToken = null, int? pageSizeHint = null)
    {
        int itemsPerPage = pageSizeHint ?? 5;
        List<TValue> items = new(itemsPerPage);
        int rolling = 0;

        await foreach (TValue value in _enumerateAsyncFunc())
        {
            SetResponse();
            items.Add(value);
            rolling++;
            if (items.Count == itemsPerPage)
            {
                yield return ResultPage<TValue>.Create(items, rolling.ToString(), _response);
                items.Clear();
            }
        }

        if (items.Count > 0)
        {
            yield return ResultPage<TValue>.Create(items, rolling.ToString(), _response);
        }
    }

    private void SetResponse()
    {
        if (_responseSet)
        {
            return;
        }

        _responseSet = true;
        SetRawResponse(_response);
    }
}
