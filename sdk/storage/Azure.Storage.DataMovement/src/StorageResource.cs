// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// The base class for all storage resources.
    /// </summary>
    public abstract class StorageResource
    {
        /// <summary>
        /// The protected constructor for the abstract StorageResource class (to allow for mocking).
        /// </summary>
        protected StorageResource()
        {
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        public abstract string Path { get; }

        /// <summary>
        /// Defines whether the storage resource is a container.
        /// </summary>
        protected internal abstract bool IsContainer { get; }

        /// <summary>
        /// Attempts to get the Uri of the Storage Resource.
        /// </summary>
        /// <param name="uri">
        /// The <see cref="Uri"/> of the Storage Resource if the Storage Resource has one.
        /// </param>
        /// <returns>
        /// Returns true if retrieving the <see cref="Uri"/> was successful. Returns false if not.
        /// </returns>
        public abstract bool TryGetUri(out Uri uri);
    }
}
