// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Azure.AI.OpenAI.Tests.Utils
{
    /// <summary>
    /// An adapter to make a <see cref="ResultCollection{T}"/> look and work like a <see cref="AsyncResultCollection{T}"/>. This
    /// simplifies writing test cases
    /// </summary>
    /// <typeparam name="T">The type of the items the enumerator returns</typeparam>
    public class SyncToAsyncResultCollection<T> : AsyncResultCollection<T>
    {
        private ResultCollection<T> _syncCollection;

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="syncCollection">The synchronous collection to wrap</param>
        /// <exception cref="ArgumentNullException">If the collection was null</exception>
        public SyncToAsyncResultCollection(ResultCollection<T> syncCollection)
        {
            _syncCollection = syncCollection ?? throw new ArgumentNullException(nameof(syncCollection));
        }

        /// <inheritdoc />
        public override IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return InnerEnumerable(cancellationToken).GetAsyncEnumerator();
        }

        private async IAsyncEnumerable<T> InnerEnumerable([EnumeratorCancellation]CancellationToken cancellationToken = default)
        {
            var asyncWrapper = new SyncToAsyncEnumerator<T>(_syncCollection.GetEnumerator(), cancellationToken);
            while (await asyncWrapper.MoveNextAsync().ConfigureAwait(false))
            {
                TrySetRawResponse();
                yield return asyncWrapper.Current;
            }
        }

        private void TrySetRawResponse()
        {
            // Client result doesn't provide virtual methods so we have to manually set it ourselves here
            try
            {
                var raw = _syncCollection.GetRawResponse();
                if (raw != null)
                {
                    SetRawResponse(raw);
                }
            }
            catch (Exception) { /* dont' care */ }
        }
    }
}
