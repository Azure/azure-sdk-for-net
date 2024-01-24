// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement.Tests
{
    internal class MemoryStorageResourceContainer : StorageResourceContainer
    {
        public bool ReturnsContainersOnEnumeration { get; set; }

        public List<StorageResource> Children { get; } = new();

        public override Uri Uri { get; }

        public override string ProviderId => "mock";

        public MemoryStorageResourceContainer(Uri uri)
        {
            Uri = uri ?? new Uri($"memory://localhost/mycontainer/mypath-{Guid.NewGuid()}/resource-item-{Guid.NewGuid()}");
        }

        protected internal override StorageResourceItem GetStorageResourceReference(string path)
        {
            UriBuilder builder = new(Uri);
            builder.Path = string.Join("/", new List<string>()
            {
                builder.Path.Trim('/'),
                path.Trim('/'),
            }.Where(s => !string.IsNullOrWhiteSpace(s)));
            Uri expected = builder.Uri;

            foreach (StorageResourceItem item in GetStorageResources(false))
            {
                if (item.Uri == expected)
                {
                    return item;
                }
            }
            return null;
        }

        protected internal override async IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(
            [EnumeratorCancellation]CancellationToken cancellationToken = default)
        {
            foreach (StorageResource storageResource in GetStorageResources(ReturnsContainersOnEnumeration))
            {
                yield return await Task.FromResult(storageResource);
            }
        }

        protected internal override StorageResourceCheckpointData GetDestinationCheckpointData()
        {
            throw new NotImplementedException();
        }

        protected internal override StorageResourceCheckpointData GetSourceCheckpointData()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<StorageResource> GetStorageResources(bool includeContainers)
        {
            Queue<MemoryStorageResourceContainer> queue = new();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                MemoryStorageResourceContainer container = queue.Dequeue();
                foreach (var child in container.Children)
                {
                    if (child is MemoryStorageResourceItem)
                    {
                        yield return child;
                    }
                    else if (child is MemoryStorageResourceContainer)
                    {
                        queue.Enqueue(child as MemoryStorageResourceContainer);
                        if (includeContainers)
                        {
                            yield return child;
                        }
                    }
                    else
                    {
                        throw new Exception($"Do not combine other StorageResource implementations with {nameof(MemoryStorageResourceContainer)}");
                    }
                }
            }
        }

        protected internal override Task CreateIfNotExistsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected internal override StorageResourceContainer GetChildStorageResourceContainer(string path)
        {
            throw new NotImplementedException();
        }
    }
}
