// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// This class wraps the DateLakeServiceClient.GetFileSystemsAsync return values
    /// and maps them into DataLake types.
    /// </summary>
    internal class GetFileSystemsAsyncCollection
    {
        private readonly BlobServiceClient _client;
        private readonly FileSystemTraits _traits;
        private readonly FileSystemStates _states;
        private readonly string _prefix;

        public GetFileSystemsAsyncCollection(
            BlobServiceClient client,
            FileSystemTraits traits,
            FileSystemStates states,
            string prefix = default)
        {
            _client = client;
            _traits = traits;
            _states = states;
            _prefix = prefix;
        }

        private static Page<FileSystemItem> ConvertPage(Page<BlobContainerItem> page)
        {
            return Page<FileSystemItem>.FromValues(
                page.Values.Select(ConvertItem).ToArray(),
                page.ContinuationToken,
                page.GetRawResponse());
        }

        private static FileSystemItem ConvertItem(BlobContainerItem item)
        {
            return item.ToFileSystemItem();
        }

        private static AsyncPageable<BlobContainerItem> ConvertCollection(GetFileSystemsAsyncCollection collection, CancellationToken cancellationToken)
        {
            return collection._client.GetBlobContainersAsync(
                       (BlobContainerTraits)collection._traits,
                       (BlobContainerStates)collection._states,
                       collection._prefix,
                       cancellationToken);
        }

        public Pageable<FileSystemItem> ToSyncCollection(CancellationToken cancellationToken)
        {
            return new StoragePageable(this, cancellationToken);
        }

        public AsyncPageable<FileSystemItem> ToAsyncCollection(CancellationToken cancellationToken)
        {
            return new StorageAsyncPageable(this, cancellationToken);
        }

        /// <summary>
        /// Abstract the Storage pattern for async iteration.
        /// </summary>
        private class StoragePageable : Pageable<FileSystemItem>
        {
            private GetFileSystemsAsyncCollection _collection;

            public StoragePageable(GetFileSystemsAsyncCollection collection, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _collection = collection;
            }

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
            public override IEnumerable<Page<FileSystemItem>> AsPages(
                string continuationToken = default,
                int? pageHintSize = default)
            {
                return _collection._client.GetBlobContainers(
                    (BlobContainerTraits)_collection._traits,
                    (BlobContainerStates)_collection._states,
                    _collection._prefix,
                    CancellationToken)
                    .AsPages(continuationToken, pageHintSize)
                    .Select(ConvertPage);
            }

            /// <summary>
            /// Enumerate the values in the collection synchronously.  This may
            /// make multiple service requests.
            /// </summary>
            /// <returns>A sequence of values.</returns>
            public override IEnumerator<FileSystemItem> GetEnumerator()
            {
                return _collection._client.GetBlobContainers(
                    (BlobContainerTraits)_collection._traits,
                    (BlobContainerStates)_collection._states,
                    _collection._prefix,
                    CancellationToken)
                    .Select(ConvertItem)
                    .GetEnumerator();
            }
        }

        /// <summary>
        /// Abstract the Storage pattern for async iteration.
        /// </summary>
        private class StorageAsyncPageable : AsyncPageable<FileSystemItem>
        {
            private GetFileSystemsAsyncCollection _collection;

            // for mocking
            protected StorageAsyncPageable()
                : base()
            {
            }

            public StorageAsyncPageable(GetFileSystemsAsyncCollection collection, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _collection = collection;
            }

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
            public override async IAsyncEnumerable<Page<FileSystemItem>> AsPages(
                string continuationToken = default,
                int? pageHintSize = default)
            {
                IAsyncEnumerable<Page<BlobContainerItem>> pages =
                    ConvertCollection(_collection, CancellationToken)
                    .AsPages(continuationToken, pageHintSize);

                await foreach (Page<BlobContainerItem> page in pages.ConfigureAwait(false))
                {
                    yield return ConvertPage(page);
                }
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
            public override async IAsyncEnumerator<FileSystemItem> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            {
                // This is the only method that takes its own CancellationToken, but
                // we'll still use the original CancellationToken if one wasn't passed.
                if (cancellationToken == default)
                {
                    cancellationToken = CancellationToken;
                }

                IAsyncEnumerable<Page<BlobContainerItem>> pages =
                    ConvertCollection(_collection, cancellationToken)
                    .AsPages();

                await foreach (Page<BlobContainerItem> page in pages.ConfigureAwait(false))
                {
                    foreach (BlobContainerItem item in page.Values)
                    {
                        yield return ConvertItem(item);
                    }
                }
            }
        }
    }
}
