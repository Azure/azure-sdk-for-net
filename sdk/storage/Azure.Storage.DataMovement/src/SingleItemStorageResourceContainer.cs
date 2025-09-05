// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// An internal container to wrap a single item.
    /// </summary>
    internal class SingleItemStorageResourceContainer : StorageResourceContainer
    {
        public override Uri Uri => _resourceItem.Uri;

        public override string ProviderId => _resourceItem.ProviderId;

        private StorageResourceItem _resourceItem;

        public SingleItemStorageResourceContainer(StorageResourceItem resourceItem)
        {
            Argument.AssertNotNull(resourceItem, nameof(resourceItem));
            _resourceItem = resourceItem;
        }

        protected internal override Task CreateIfNotExistsAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

        protected internal override StorageResourceContainer GetChildStorageResourceContainer(string path)
        {
            // This should never be called for a single item
            throw Errors.SingleItemContainerNoChildren();
        }

        protected internal override StorageResourceCheckpointDetails GetDestinationCheckpointDetails()
        {
            return _resourceItem.GetDestinationCheckpointDetails();
        }

        protected internal override StorageResourceCheckpointDetails GetSourceCheckpointDetails()
        {
            return _resourceItem.GetSourceCheckpointDetails();
        }

        protected internal override StorageResourceItem GetStorageResourceReference(string path, string resourceId)
        {
            return _resourceItem;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        protected internal async override IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(
            StorageResourceContainer destinationContainer = null,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            yield return _resourceItem;
        }

        protected internal override Task<StorageResourceContainerProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            // This should never be called for a single item
            throw Errors.SingleItemContainerNoGetProperties();
        }
    }
}
