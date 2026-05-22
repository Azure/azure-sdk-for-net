// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Wraps <see cref="BlobBaseClient.GetLayout(BlobGetLayoutOptions, CancellationToken)"/> /
    /// <see cref="BlobBaseClient.GetLayoutAsync(BlobGetLayoutOptions, CancellationToken)"/> and
    /// projects the returned <see cref="BlobLayoutInfo"/> values into <see cref="DataLakeFileLayoutInfo"/>
    /// values without altering the underlying paging behavior. All pagination state (continuation tokens,
    /// page boundaries, ETag locking) is owned by the inner Blobs pageable, so this wrapper makes the
    /// same number of REST calls as calling the Blobs API directly.
    /// </summary>
    internal class GetLayoutAsyncCollection
    {
        private readonly BlockBlobClient _client;
        private readonly BlobGetLayoutOptions _options;

        public GetLayoutAsyncCollection(
            BlockBlobClient client,
            BlobGetLayoutOptions options)
        {
            _client = client;
            _options = options;
        }

        private static Page<DataLakeFileLayoutInfo> ConvertPage(Page<BlobLayoutInfo> page)
        {
            return Page<DataLakeFileLayoutInfo>.FromValues(
                page.Values.Select(ConvertItem).ToArray(),
                page.ContinuationToken,
                page.GetRawResponse());
        }

        private static DataLakeFileLayoutInfo ConvertItem(BlobLayoutInfo item)
        {
            return item.ToDataLakeFileLayoutInfo();
        }

        private static AsyncPageable<BlobLayoutInfo> ConvertCollectionAsync(GetLayoutAsyncCollection collection, CancellationToken cancellationToken)
        {
            return collection._client.GetLayoutAsync(
                collection._options,
                cancellationToken);
        }

        private static Pageable<BlobLayoutInfo> ConvertCollection(GetLayoutAsyncCollection collection, CancellationToken cancellationToken)
        {
            return collection._client.GetLayout(
                collection._options,
                cancellationToken);
        }

        public Pageable<DataLakeFileLayoutInfo> ToSyncCollection(CancellationToken cancellationToken)
        {
            return new StoragePageable(this, cancellationToken);
        }

        public AsyncPageable<DataLakeFileLayoutInfo> ToAsyncCollection(CancellationToken cancellationToken)
        {
            return new StorageAsyncPageable(this, cancellationToken);
        }

        /// <summary>
        /// Abstract the Storage pattern for sync iteration.
        /// </summary>
        private class StoragePageable : Pageable<DataLakeFileLayoutInfo>
        {
            private readonly GetLayoutAsyncCollection _collection;

            public StoragePageable(GetLayoutAsyncCollection collection, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _collection = collection;
            }

            /// <summary>
            /// Enumerate the values a <see cref="Page{T}"/> at a time. This may
            /// make multiple service requests.
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
            /// A sequence of <see cref="Page{T}"/>s.
            /// </returns>
            public override IEnumerable<Page<DataLakeFileLayoutInfo>> AsPages(
                string continuationToken = default,
                int? pageHintSize = default)
            {
                return ConvertCollection(_collection, CancellationToken)
                    .AsPages(continuationToken, pageHintSize)
                    .Select(ConvertPage);
            }

            /// <summary>
            /// Enumerate the values in the collection synchronously. This may
            /// make multiple service requests.
            /// </summary>
            /// <returns>A sequence of values.</returns>
            public override IEnumerator<DataLakeFileLayoutInfo> GetEnumerator()
            {
                return ConvertCollection(_collection, CancellationToken)
                    .Select(ConvertItem)
                    .GetEnumerator();
            }
        }

        /// <summary>
        /// Abstract the Storage pattern for async iteration.
        /// </summary>
        private class StorageAsyncPageable : AsyncPageable<DataLakeFileLayoutInfo>
        {
            private readonly GetLayoutAsyncCollection _collection;

            // for mocking
            protected StorageAsyncPageable()
                : base()
            {
            }

            public StorageAsyncPageable(GetLayoutAsyncCollection collection, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _collection = collection;
            }

            /// <summary>
            /// Enumerate the values a <see cref="Page{T}"/> at a time. This may
            /// make multiple service requests.
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
            public override async IAsyncEnumerable<Page<DataLakeFileLayoutInfo>> AsPages(
                string continuationToken = default,
                int? pageHintSize = default)
            {
                IAsyncEnumerable<Page<BlobLayoutInfo>> pages =
                    ConvertCollectionAsync(_collection, CancellationToken)
                    .AsPages(continuationToken, pageHintSize);

                await foreach (Page<BlobLayoutInfo> page in pages.ConfigureAwait(false))
                {
                    yield return ConvertPage(page);
                }
            }

            /// <summary>
            /// Enumerate the values in the collection asynchronously. This may
            /// make multiple service requests.
            /// </summary>
            /// <param name="cancellationToken">
            /// The <see cref="CancellationToken"/> used for requests made while
            /// enumerating asynchronously.
            /// </param>
            /// <returns>An async sequence of values.</returns>
            public override async IAsyncEnumerator<DataLakeFileLayoutInfo> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            {
                // This is the only method that takes its own CancellationToken, but
                // we'll still use the original CancellationToken if one wasn't passed.
                if (cancellationToken == default)
                {
                    cancellationToken = CancellationToken;
                }

                IAsyncEnumerable<Page<BlobLayoutInfo>> pages =
                    ConvertCollectionAsync(_collection, cancellationToken)
                    .AsPages();

                await foreach (Page<BlobLayoutInfo> page in pages.ConfigureAwait(false))
                {
                    foreach (BlobLayoutInfo item in page.Values)
                    {
                        yield return ConvertItem(item);
                    }
                }
            }
        }
    }
}
