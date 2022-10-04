// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

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
        /// returns path split up
        /// </summary>
        /// <returns></returns>
        public abstract List<String> GetPath();

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
