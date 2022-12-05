// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Storage Resource Base
    /// </summary>
    public abstract class StorageResourceBase
    {
        /// <summary>
        /// For mocking
        /// </summary>
        protected StorageResourceBase() { }

        /// <summary>
        /// Defines whether we can produce a Uri
        /// </summary>
        public abstract ProduceUriType CanProduceUri { get; }

        /// <summary>
        /// Gets Uri
        /// </summary>
        public abstract Uri Uri { get; }

        /// <summary>
        /// Gets path split up
        /// </summary>
        public abstract string Path { get; }

        /// <summary>
        /// Defines whether the storage resource is a container.
        /// </summary>
        public abstract bool IsContainer { get; }
    }
}
