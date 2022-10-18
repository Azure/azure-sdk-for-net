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
    public abstract class StorageResourceContainer
    {
        /// <summary>
        /// For mocking
        /// </summary>
        protected StorageResourceContainer() { }

        /// <summary>
        /// Defines whether we can produce a Uri
        /// </summary>
        /// <returns></returns>
        public abstract ProduceUriType CanProduceUri();

        /// <summary>
        /// Gets Uri
        /// </summary>
        /// <returns></returns>
        public abstract Uri GetUri();

        /// <summary>
        /// Gets path split up
        /// </summary>
        /// <returns></returns>
        public abstract List<string> GetPath();

        /// <summary>
        /// Lists all the child storage resources in the path.
        /// </summary>
        /// <returns></returns>
        public abstract IAsyncEnumerable<StorageResource> ListStorageResources(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns storage resources from the parent resource container
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public abstract StorageResource GetStorageResource(List<string> path);

        /// <summary>
        /// Returns storage resource container from the parent container
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public abstract StorageResourceContainer GetStorageResourceContainer(List<string> path);
    }
}
