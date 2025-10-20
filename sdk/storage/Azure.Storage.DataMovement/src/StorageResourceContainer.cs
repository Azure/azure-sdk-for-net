// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

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
        /// Properties of the Storage Resource Container.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal StorageResourceContainerProperties ResourceProperties { get; set; }

        /// <summary>
        /// Lists all the child storage resources in the path.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal abstract IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(
            StorageResourceContainer destinationContainer = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns storage resources from the parent resource container
        /// </summary>
        /// <param name="path"></param>
        /// <param name="resourceId"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal abstract StorageResourceItem GetStorageResourceReference(string path, string resourceId);

        /// <summary>
        /// This has been deprecated. See <see cref="CreateAsync(bool, StorageResourceContainerProperties, CancellationToken)"/>.
        /// Creates storage resource container if it does not already exists.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal abstract Task CreateIfNotExistsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the child StorageResourceContainer of the respective container.
        /// </summary>
        /// <param name="path">
        /// The path of the child container.
        /// </param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal abstract StorageResourceContainer GetChildStorageResourceContainer(string path);

        /// <summary>
        /// Get properties of the resource container.
        ///
        /// See <see cref="StorageResourceContainerProperties"/>.
        /// </summary>
        /// <returns>Returns the properties of the Storage Resource Container. See <see cref="StorageResourceContainerProperties"/></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal virtual Task<StorageResourceContainerProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        /// <summary>
        /// This has been deprecated. See <see cref="CreateAsync(bool, StorageResourceContainerProperties, CancellationToken)"/>.
        /// Creates storage resource container using the source's properties if it does not already exists.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal virtual Task CreateIfNotExistsAsync(
            StorageResourceContainerProperties sourceProperties,
            CancellationToken cancellationToken = default)
            => CreateIfNotExistsAsync(cancellationToken);

        /// <summary>
        /// Creates storage resource container using the source's properties. Supports overwriting the existing container.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal virtual Task CreateAsync(
            bool overwrite,
            StorageResourceContainerProperties sourceProperties,
            CancellationToken cancellationToken = default)
            => Task.CompletedTask;

        /// <summary>
        /// Storage Resource is a container.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal override bool IsContainer => true;
    }
}
