// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Globalization;
using OpenAI.TestFramework.Adapters;

namespace OpenAI.TestFramework.Mocks;

/// <summary>
/// Represents a mock implementation of the <see cref="AsyncResultCollection{TValue}"/> class.
/// </summary>
/// <typeparam name="TValue">The type of the values in the collection.</typeparam>
public class MockAsyncCollectionResult<TValue> : AsyncCollectionResult<TValue>
{
    private readonly Func<IAsyncEnumerable<TValue>> _enumerateAsyncFunc;
    private readonly int _itemsPerPage;

    /// <summary>
    /// Initializes a new instance of the <see cref="MockAsyncCollectionResult{TValue}"/> class
    /// with the specified asynchronous enumeration function and optional pipeline response.
    /// </summary>
    /// <param name="enumerateAsyncFunc">The function that asynchronously enumerates the values in the collection.</param>
    /// <param name="response">The optional pipeline response.</param>
    public MockAsyncCollectionResult(Func<IAsyncEnumerable<TValue>> enumerateAsyncFunc, int itemsPerPage = 5)
    {
        if (itemsPerPage < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(itemsPerPage), "Items per page must be greater than 0.");
        }

        _enumerateAsyncFunc = enumerateAsyncFunc ?? throw new ArgumentNullException(nameof(enumerateAsyncFunc));
        _itemsPerPage = itemsPerPage;
    }

    /// <inheritdoc />
    public override ContinuationToken? GetContinuationToken(ClientResult page)
    {
        MockPage<TValue>? parsed = MockPage<TValue>.FromClientResult(page);

        if (parsed == null)
        {
            return null;
        }

        string token = parsed.Next.ToString(CultureInfo.InvariantCulture);
        return ContinuationToken.FromBytes(BinaryData.FromString(token));
    }

    /// <inheritdoc />
    public override async IAsyncEnumerable<ClientResult> GetRawPagesAsync()
    {
        List<TValue> items = new(_itemsPerPage);
        int next = 0;

        await foreach (TValue item in _enumerateAsyncFunc())
        {
            items.Add(item);
            next++;
            if (items.Count == _itemsPerPage)
            {
                yield return new MockPage<TValue>
                {
                    Values = items,
                    Next = next
                }.AsClientResult();

                items.Clear();
            }
        }

        if (items.Count > 0)
        {
            yield return new MockPage<TValue>
            {
                Values = items,
                Next = next
            }.AsClientResult();
        }
    }

    /// <inheritdoc />
    protected override IAsyncEnumerable<TValue> GetValuesFromPageAsync(ClientResult page)
        => new SyncToAsyncEnumerable<TValue>(MockPage<TValue>.FromClientResult(page)?.Values ?? []);
}
