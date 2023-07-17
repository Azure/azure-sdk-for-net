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
        /// Defines whether the storage resource type can produce a web URL.
        /// </summary>
        protected internal abstract bool CanProduceUri { get; }

        /// <summary>
        /// Gets the Uri.
        /// </summary>
        public abstract Uri Uri { get; }

        /// <summary>
        /// Gets the path.
        /// </summary>
        public abstract string Path { get; }

        /// <summary>
        /// Defines whether the storage resource is a container.
        /// </summary>
        protected internal abstract bool IsContainer { get; }
    }
}
