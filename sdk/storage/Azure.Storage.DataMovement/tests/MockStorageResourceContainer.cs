// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement.Tests
{
    internal class MockStorageResourceContainer : StorageResourceContainer
    {
        private readonly Uri _uri;
        private readonly long _fileSize;
        private readonly int _resourceCount;

        public override Uri Uri => _uri;

        public override string ProviderId => "mock";

        public MockStorageResourceContainer(Uri uri, long fileSize = 4 * Constants.KB, int resourceCount = 3)
        {
            _uri = uri;
            _fileSize = fileSize;
            _resourceCount = resourceCount;
        }

        protected internal override Task CreateIfNotExistsAsync(CancellationToken cancellationToken = default)
            => Task.CompletedTask;

        protected internal override StorageResourceContainer GetChildStorageResourceContainer(string path)
        {
            // Currently not implemented as GetStorageResourcesAsync does not return any containers
            throw new NotImplementedException();
        }

        protected internal override StorageResourceCheckpointDetails GetDestinationCheckpointDetails()
        {
            return new MockResourceCheckpointDetails();
        }

        protected internal override StorageResourceCheckpointDetails GetSourceCheckpointDetails()
        {
            return new MockResourceCheckpointDetails();
        }

        protected internal override StorageResourceItem GetStorageResourceReference(string path, string resourceId)
        {
            UriBuilder uri = new(_uri);
            uri.Path = Path.Combine(uri.Path, path);
            return MockStorageResourceItem.MakeDestinationResource(uri.Uri);
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        protected internal async override IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(
            StorageResourceContainer destinationContainer = null,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            foreach (int i in Enumerable.Range(0, _resourceCount))
            {
                UriBuilder uri = new(_uri);
                uri.Path = Path.Combine(uri.Path, $"file{i}");
                yield return MockStorageResourceItem.MakeSourceResource(_fileSize, uri.Uri);
            }
        }

        protected internal override async Task<StorageResourceContainerProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(new StorageResourceContainerProperties());
        }
    }
}
