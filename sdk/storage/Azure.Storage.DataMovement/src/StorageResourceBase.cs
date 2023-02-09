// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// The abstract class StorageResourceBase.
    /// </summary>
    public abstract class StorageResourceBase
    {
        /// <summary>
        /// The protected constructor for the abstract StorageResourceBase class (to allow for mocking).
        /// </summary>
        protected StorageResourceBase() { }

        /// <summary>
        /// Defines whether we can produce a Uri.
        /// </summary>
        public abstract ProduceUriType CanProduceUri { get; }

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
        public abstract bool IsContainer { get; }
    }
}
