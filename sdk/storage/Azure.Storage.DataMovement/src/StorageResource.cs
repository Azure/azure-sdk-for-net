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
        /// Defines whether the storage resource is a container.
        /// </summary>
        protected internal abstract bool IsContainer { get; }

        /// <summary>
        /// Gets the Uri of the Storage Resource.
        /// </summary>
        public abstract Uri Uri { get; }
    }
}
