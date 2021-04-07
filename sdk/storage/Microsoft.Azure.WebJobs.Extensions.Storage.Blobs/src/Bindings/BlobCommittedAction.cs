// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings
{
    internal class BlobCommittedAction : IBlobCommitedAction
    {
        private readonly BlobWithContainer<BlobBaseClient> _blob;
        private readonly SharedMemoryMetadata _sharedMemoryMeta;
        private readonly IBlobWrittenWatcher _blobWrittenWatcher;
        private readonly IFunctionDataCache _functionDataCache;
        private bool _isClosed;

        public BlobCommittedAction(BlobWithContainer<BlobBaseClient> blob, IBlobWrittenWatcher blobWrittenWatcher,
            SharedMemoryMetadata sharedMemoryMeta, IFunctionDataCache functionDataCache)
        {
            _blob = blob;
            _blobWrittenWatcher = blobWrittenWatcher;
            _functionDataCache = functionDataCache;
            _sharedMemoryMeta = sharedMemoryMeta;
            _isClosed = false;
        }

        public async Task ExecuteAsync(bool isClosing, CancellationToken cancellationToken)
        {
            if (_blobWrittenWatcher != null)
            {
                _blobWrittenWatcher.Notify(_blob);
            }

            if (isClosing && !_isClosed)
            {
                await TryPutToFunctionDataCacheAsync(cancellationToken).ConfigureAwait(false);
                _isClosed = true;
            }
        }

        public Task ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecuteAsync(isClosing: false, cancellationToken);
        }

        public void Execute(bool isClosing)
        {
            if (_blobWrittenWatcher != null)
            {
                _blobWrittenWatcher.Notify(_blob);
            }

            if (isClosing && !_isClosed)
            {
                TryPutToFunctionDataCache();
                _isClosed = true;
            }
        }

        public void Execute()
        {
            Execute(isClosing: false);
        }

        private async Task<bool> TryPutToFunctionDataCacheAsync(CancellationToken cancellationToken = default)
        {
            if (_sharedMemoryMeta == null)
            {
                return false;
            }

            BlobProperties properties = await _blob.BlobClient.FetchPropertiesOrNullIfNotExistAsync(cancellationToken).ConfigureAwait(false);
            return TryPutToFunctionDataCacheCore(properties);
        }

        private bool TryPutToFunctionDataCache()
        {
            if (_sharedMemoryMeta == null)
            {
                return false;
            }

            BlobProperties properties = _blob.BlobClient.GetProperties();
            return TryPutToFunctionDataCacheCore(properties);
        }

        private bool TryPutToFunctionDataCacheCore(BlobProperties properties)
        {
            string eTag = properties.ETag.ToString();
            string id = _blob.BlobClient.Uri.ToString();
            FunctionDataCacheKey cacheKey = new FunctionDataCacheKey(id, eTag);
            return _functionDataCache.TryPut(cacheKey, _sharedMemoryMeta);
        }
    }
}
