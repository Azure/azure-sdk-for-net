// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage
{
    internal abstract class StorageCollectionEnumerator<T>
    {
        public abstract ValueTask<Page<T>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool isAsync,
            CancellationToken cancellationToken);

        public Pageable<T> ToSyncCollection(CancellationToken cancellationToken)
        {
            return new StoragePageable(this, cancellationToken);
        }

        public AsyncPageable<T> ToAsyncCollection(CancellationToken cancellationToken)
        {
            return new StorageAsyncPageable(this, cancellationToken);
        }

        /// <summary>
        /// Abstract the Storage pattern for async iteration
        /// </summary>
        private class StoragePageable : Pageable<T>
        {
            private StorageCollectionEnumerator<T> _enumerator;

            // for mocking
            protected StoragePageable()
                : base()
            {
            }

            public StoragePageable(StorageCollectionEnumerator<T> enumerator, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _enumerator = enumerator;
            }

            /// <summary>
            /// Determine if the iteration can continue.
            /// </summary>
            /// <param name="continuationToken">
            /// The next continuation token provided with the last
            /// <see cref="Page{T}"/>.
            /// </param>
            /// <returns>
            /// True if the iteration can continue, false otherwise.
            /// </returns>
            protected virtual bool CanContinue(string continuationToken) =>
                !string.IsNullOrEmpty(continuationToken);

            /// <summary>
            /// Enumerate the values a <see cref="Page{T}"/> at a time.  This may
            /// make mutliple service requests.
            /// </summary>
            /// <param name="continuationToken">
            /// A continuation token indicating where to resume paging or null to
            /// begin paging from the beginning.
            /// </param>
            /// <param name="pageHintSize">
            /// The size of <see cref="Page{T}"/>s that should be requested (from
            /// service operations that support it).
            /// </param>
            /// <returns>
            /// An async sequence of <see cref="Page{T}"/>s.
            /// </returns>
            public override IEnumerable<Page<T>> AsPages(
                string continuationToken = default,
                int? pageHintSize = default)
            {
                do
                {
                    Page<T> page = _enumerator.GetNextPageAsync(
                        continuationToken,
                        pageHintSize,
                        isAsync: false,
                        cancellationToken: CancellationToken)
                        .EnsureCompleted();
                    continuationToken = page.ContinuationToken;
                    yield return page;
                } while (CanContinue(continuationToken));
            }

            /// <summary>
            /// Enumerate the values in the collection synchronously.  This may
            /// make mutliple service requests.
            /// </summary>
            /// <returns>A sequence of values.</returns>
            public override IEnumerator<T> GetEnumerator()
            {
                string continuationToken = null;
                do
                {
                    Page<T> page = _enumerator.GetNextPageAsync(
                        continuationToken,
                        null,
                        isAsync: false,
                        cancellationToken: CancellationToken)
                        .EnsureCompleted();
                    continuationToken = page.ContinuationToken;
                    foreach (T item in page.Values)
                    {
                        yield return item;
                    }
                } while (CanContinue(continuationToken));
            }
        }

        /// <summary>
        /// Abstract the Storage pattern for async iteration
        /// </summary>
        private class StorageAsyncPageable : AsyncPageable<T>
        {
            private StorageCollectionEnumerator<T> _enumerator;

            // for mocking
            protected StorageAsyncPageable()
                : base()
            {
            }

            public StorageAsyncPageable(StorageCollectionEnumerator<T> enumerator, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _enumerator = enumerator;
            }

            /// <summary>
            /// Determine if the iteration can continue.
            /// </summary>
            /// <param name="continuationToken">
            /// The next continuation token provided with the last
            /// <see cref="Page{T}"/>.
            /// </param>
            /// <returns>
            /// True if the iteration can continue, false otherwise.
            /// </returns>
            protected virtual bool CanContinue(string continuationToken) =>
                !string.IsNullOrEmpty(continuationToken);

            /// <summary>
            /// Enumerate the values a <see cref="Page{T}"/> at a time.  This may
            /// make mutliple service requests.
            /// </summary>
            /// <param name="continuationToken">
            /// A continuation token indicating where to resume paging or null to
            /// begin paging from the beginning.
            /// </param>
            /// <param name="pageHintSize">
            /// The size of <see cref="Page{T}"/>s that should be requested (from
            /// service operations that support it).
            /// </param>
            /// <returns>
            /// An async sequence of <see cref="Page{T}"/>s.
            /// </returns>
            public override async IAsyncEnumerable<Page<T>> AsPages(
                string continuationToken = default,
                int? pageHintSize = default)
            {
                do
                {
                    Page<T> page = await _enumerator.GetNextPageAsync(
                        continuationToken,
                        pageHintSize,
                        isAsync: true,
                        cancellationToken: CancellationToken)
                        .ConfigureAwait(false);
                    continuationToken = page.ContinuationToken;
                    yield return page;
                } while (CanContinue(continuationToken));
            }

            /// <summary>
            /// Enumerate the values in the collection asynchronously.  This may
            /// make mutliple service requests.
            /// </summary>
            /// <param name="cancellationToken">
            /// The <see cref="CancellationToken"/> used for requests made while
            /// enumerating asynchronously.
            /// </param>
            /// <returns>An async sequence of values.</returns>
            public override async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            {
                // This is the only method that takes its own CancellationToken, but
                // we'll still use the original CancellationToken if one wasn't passed.
                if (cancellationToken == default)
                {
                    cancellationToken = CancellationToken;
                }

                string continuationToken = null;
                do
                {
                    Page<T> page = await _enumerator.GetNextPageAsync(
                        continuationToken,
                        null,
                        isAsync: true,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                    continuationToken = page.ContinuationToken;
                    foreach (T item in page.Values)
                    {
                        yield return item;
                    }
                } while (CanContinue(continuationToken));
            }

            /// <summary>
            /// Enumerate the values in the collection synchronously.  This may
            /// make mutliple service requests.
            /// </summary>
            /// <returns>A sequence of values.</returns>
            protected IEnumerator<Response<T>> GetEnumerator()
            {
                string continuationToken = null;
                do
                {
                    Page<T> page = _enumerator.GetNextPageAsync(
                        continuationToken,
                        null,
                        isAsync: false,
                        cancellationToken: CancellationToken)
                        .EnsureCompleted();
                    continuationToken = page.ContinuationToken;
                    foreach (T item in page.Values)
                    {
                        yield return Response.FromValue(item, page.GetRawResponse());
                    }
                } while (CanContinue(continuationToken));
            }
        }
    }
}
