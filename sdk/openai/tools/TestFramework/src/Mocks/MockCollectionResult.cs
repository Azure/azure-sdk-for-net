// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Globalization;

namespace OpenAI.TestFramework.Mocks
{
    /// <summary>
    /// Represents a mock implementation of the <see cref="ResultCollection{TValue}"/> class.
    /// </summary>
    /// <typeparam name="TValue">The type of the values in the collection.</typeparam>
    public class MockCollectionResult<TValue> : CollectionResult<TValue>
    {
        private readonly Func<IEnumerable<TValue>> _enumerateFunc;
        private readonly int _itemsPerPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockCollectionResult{TValue}"/> class with the specified enumeration
        /// function and optional pipeline response.
        /// </summary>
        /// <param name="enumerateFunc">The function used to enumerate the collection.</param>
        /// <param name="itemsPerPage">The number of items per page.</param>
        public MockCollectionResult(Func<IEnumerable<TValue>> enumerateFunc, int itemsPerPage = 5)
        {
            if (itemsPerPage < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(itemsPerPage), "Items per page must be greater than 0.");
            }

            _enumerateFunc = enumerateFunc ?? throw new ArgumentNullException(nameof(enumerateFunc));
            _itemsPerPage = itemsPerPage;
        }

        /// <inheritdoc />
        public override IEnumerable<ClientResult> GetRawPages()
        {
            List<TValue> items = new(_itemsPerPage);
            int next = 0;
            foreach (TValue item in _enumerateFunc())
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
        protected override IEnumerable<TValue> GetValuesFromPage(ClientResult page)
            => MockPage<TValue>.FromClientResult(page)?.Values ?? [];
    }
}
