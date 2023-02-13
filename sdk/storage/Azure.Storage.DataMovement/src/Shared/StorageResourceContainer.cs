// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Inheritable class for storage container
    /// </summary>
    public abstract class StorageResourceContainer : StorageResourceBase
    {
        /// <summary>
        /// For mocking
        /// </summary>
        protected StorageResourceContainer() { }

        /// <summary>
        /// Lists all the child storage resources in the path.
        /// </summary>
        public abstract IAsyncEnumerable<StorageResourceBase> GetStorageResourcesAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns storage resources from the parent resource container
        /// </summary>
        /// <param name="path"></param>
        public abstract StorageResource GetChildStorageResource(string path);

        /// <summary>
        /// Returns storage resource container from the parent container
        /// </summary>
        public abstract StorageResourceContainer GetParentStorageResourceContainer();

        /// <summary>
        /// Storage Resource is a container.
        /// </summary>
        public override bool IsContainer => true;
    }
}
