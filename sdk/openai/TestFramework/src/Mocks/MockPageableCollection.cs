// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.TestFramework.Mocks;

/// <summary>
/// Represents a mock implementation of the <see cref="PageableCollection{T}"/> class.
/// </summary>
/// <typeparam name="TValue">The type of the values in the collection.</typeparam>
public class MockPageableCollection<TValue> : PageableCollection<TValue>
{
    private readonly Func<IEnumerable<TValue>> _enumerateFunc;
    private readonly PipelineResponse _response;
    bool _responseSet;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="enumerateFunc">The function used to enumerate the collection.</param>
    /// <param name="response">The pipeline response.</param>
    public MockPageableCollection(Func<IEnumerable<TValue>> enumerateFunc, PipelineResponse response)
    {
        _enumerateFunc = enumerateFunc ?? throw new ArgumentNullException(nameof(enumerateFunc));
        _response = response;
    }

    /// <inheritdoc />
    public override IEnumerable<ResultPage<TValue>> AsPages(string? continuationToken = null, int? pageSizeHint = null)
    {
        int itemsPerPage = pageSizeHint ?? 5;
        List<TValue> items = new(itemsPerPage);
        int rolling = 0;

        foreach (TValue item in _enumerateFunc())
        {
            SetResponse();
            items.Add(item);
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
