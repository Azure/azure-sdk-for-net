// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Tests.Utils
{
    /// <summary>
    /// An adapter to make a <see cref="PageableCollection{T}"/> look and work like a <see cref="AsyncPageableCollection{T}"/>. This
    /// simplifies writing test cases
    /// </summary>
    /// <typeparam name="T">The type of the items the enumerator returns</typeparam>
    public class SyncToAsyncPageableCollection<T> : AsyncPageableCollection<T>
    {
        private PageableCollection<T> _syncCollection;

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="syncCollection">The synchronous collection to wrap</param>
        /// <exception cref="ArgumentNullException">If the collection was null</exception>
        public SyncToAsyncPageableCollection(PageableCollection<T> syncCollection)
        {
            _syncCollection = syncCollection ?? throw new ArgumentNullException(nameof(syncCollection));
        }

        /// <inheritdoc />
        public override async IAsyncEnumerable<ResultPage<T>> AsPages(string? continuationToken = null, int? pageSizeHint = null)
        {
            IEnumerable<ResultPage<T>> syncEnumerable = _syncCollection.AsPages(continuationToken, pageSizeHint);
            var asyncWrapper = new SyncToAsyncEnumerator<ResultPage<T>>(syncEnumerable.GetEnumerator());
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
