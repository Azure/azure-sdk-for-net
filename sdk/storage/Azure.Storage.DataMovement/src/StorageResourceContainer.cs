﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Abstract class for a storage resource container.
    /// </summary>
    public abstract class StorageResourceContainer : StorageResource
    {
        /// <summary>
        /// For mocking.
        /// </summary>
        protected StorageResourceContainer() { }

        /// <summary>
        /// Lists all the child storage resources in the path.
        /// </summary>
        protected internal abstract IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns storage resources from the parent resource container
        /// </summary>
        /// <param name="path"></param>
        protected internal abstract StorageResourceItem GetStorageResourceReference(string path);

        /// <summary>
        /// Storage Resource is a container.
        /// </summary>
        protected internal override bool IsContainer => true;
    }
}
